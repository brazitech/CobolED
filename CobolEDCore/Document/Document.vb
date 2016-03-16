'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  Document.vb                                             --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDCore.Document                                    --
'--                                                                           --
'--  Project       :  CobolEDCore                                             --
'--                                                                           --
'--  Solution      :  NVSDI CobolED                             --
'--                                                                           --
'--  Creation Date :  2016/01/22                                              --
'-------------------------------------------------------------------------------
'--  Modifications :                                                          --
'--                                                                           --
'--                                                                           --
'--                                                                           --
'-------------------------------------------------------------------------------
'-- Copyright(C) 2016, NVSDI, Brazil                         --
'--                                                                           --
'-- This software is released under the GNU General Public License            --
'-------------------------------------------------------------------------------

Imports System.Text
Imports System.io
Imports CobolEDCore.EventArgs
Imports CobolEDCore.Enums
Imports CobolEDCore.Infos.Document

Namespace Document

    Public Class Document

        Private _documentLines As List(Of DocumentLine)
        Private _documentEncoding As Encoding
        Private _documentFileName As String
        Private _documentDirtyFlag As Boolean
        Private _eOL As String
        Private _tabSpan As Integer
        Private _selection As Selection
        Private _undoStack As Stack(Of EditActionInfo)
        Private _redoStack As Stack(Of EditActionInfo)

        Public Event DocumentChanged(ByVal sender As Object, ByVal e As DocumentChangedEventArgs)
        Public Event DocumentDirty(ByVal sender As Object, ByVal e As DocumentDirtyEventArgs)

        Public Sub New(ByVal documentFileName As String, Optional ByVal documentEncoding As Encoding = Nothing)
            Initialize(documentFileName, False, documentEncoding)
            If SetDocumentFromFile(documentFileName) Then
            Else
                _documentLines.Add(New DocumentLine(String.Empty))
            End If
        End Sub

        Public Sub New(ByVal documentFileName As String, ByVal documentLines As List(Of String), Optional ByVal documentEncoding As Encoding = Nothing)
            Initialize(documentFileName, True, documentEncoding)
            For Each documentLineString As String In documentLines
                _documentLines.Add(New DocumentLine(documentLineString))
            Next
        End Sub

        Public Property DocumentFileName() As String
            Get
                Return _documentFileName
            End Get
            Set(ByVal value As String)
                _documentFileName = value
            End Set
        End Property

        Public Property EOL() As String
            Get
                Return _eOL
            End Get
            Set(ByVal value As String)
                _eOL = value
            End Set
        End Property

        Public Property TabSpan() As Integer
            Get
                Return _tabSpan
            End Get
            Set(ByVal value As Integer)
                _tabSpan = value
            End Set
        End Property

        Public ReadOnly Property DocumentLinesCount() As Integer
            Get
                Return _documentLines.Count
            End Get
        End Property

        Public ReadOnly Property DocumentLineString(ByVal index As Integer) As String
            Get
                If index < 0 OrElse index > DocumentLinesCount - 1 Then
                    Return String.Empty
                Else
                    Return _documentLines(index).TextString
                End If
            End Get
        End Property

        Public ReadOnly Property DocumentString(ByVal startPosition As Position, ByVal endPosition As Position) As String
            Get
                Dim result As StringBuilder
                result = New StringBuilder(String.Empty)
                If startPosition.Row = endPosition.Row Then
                    result.Append(_documentLines(startPosition.Row).TextString.Substring(startPosition.Col, endPosition.Col - startPosition.Col + 1))
                Else
                    result.Append(_documentLines(startPosition.Row).TextString.Substring(startPosition.Col) & EOL)
                    For index As Integer = startPosition.Row + 1 To endPosition.Row - 1
                        result.Append(_documentLines(index).TextString & EOL)
                    Next
                    result.Append(_documentLines(endPosition.Row).TextString.Substring(0, endPosition.Col + 1))
                End If
                Return result.ToString
            End Get
        End Property

        Public ReadOnly Property DocumentLineBookMark(ByVal index As Integer) As Boolean
            Get
                If index < 0 OrElse index > DocumentLinesCount - 1 Then
                    Return Nothing
                Else
                    Return _documentLines(index).BookMark
                End If
            End Get
        End Property

        Public ReadOnly Property Selection() As Selection
            Get
                Return _selection
            End Get
        End Property

        Public ReadOnly Property CanUndo() As Boolean
            Get
                If _undoStack.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public ReadOnly Property CanRedo() As Boolean
            Get
                If _redoStack.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public ReadOnly Property DocumentDirtyFlag() As Boolean
            Get
                Return _documentDirtyFlag
            End Get
        End Property

        Public Sub SetBookMark(ByVal index As Integer, ByVal bookMark As Boolean)
            If index >= 0 AndAlso index <= _documentLines.Count - 1 Then
                _documentLines(index).BookMark = bookMark
            End If
        End Sub

        Public Sub Save()
            Dim f As FileStream = Nothing
            Dim w As StreamWriter = Nothing
            Try
                f = New FileStream(_documentFileName, FileMode.Create)
                w = New StreamWriter(f, _documentEncoding)
                For Each documentLine As DocumentLine In _documentLines
                    w.WriteLine(documentLine.TextString)
                Next
                SetDirtyFlag(False)
            Catch ex As Exception
                Throw New Common.MyException(My.Resources.CED001_001_E, _documentFileName, ex.Message)
            Finally
                If w IsNot Nothing Then
                    w.Close()
                End If
                If f IsNot Nothing Then
                    f.Close()
                End If
            End Try
        End Sub

        Public Function SetDocumentFromFile(ByVal documentFileName As String) As Boolean
            Dim result As Boolean = False
            Dim f As FileStream = Nothing
            Dim r As StreamReader = Nothing
            Dim s As String

            If IO.File.Exists(documentFileName) Then
                Try
                    f = New FileStream(documentFileName, FileMode.Open, FileAccess.Read)
                    r = New StreamReader(f, _documentEncoding)
                    s = r.ReadLine()
                    While s IsNot Nothing
                        _documentLines.Add(New DocumentLine(s))
                        ProcessEnterAndTab(DocumentLinesCount - 1)
                        s = r.ReadLine
                    End While
                    SetDirtyFlag(False)
                    result = True
                Catch ex As Exception
                    Throw New Common.MyException(My.Resources.CED001_002_E, documentFileName, ex.Message)
                Finally
                    If r IsNot Nothing Then
                        r.Close()
                    End If
                    If f IsNot Nothing Then
                        f.Close()
                    End If
                End Try
            Else
                result = False
            End If

            Return result
        End Function

        Public Function InsertText(ByVal row As Integer, ByVal col As Integer, ByVal text As String, ByVal sendEvent As Boolean) As String
            Dim e As DocumentChangedEventArgs
            Dim e_documentChangeType As DocumentChangeTypeEnum
            Dim e_row As Integer
            Dim e_col As Integer
            Dim e_text As String
            Dim e_oldText As String


            '妥当性のチェック
            If row < 0 OrElse row > DocumentLinesCount - 1 Then
                Return String.Empty
            End If
            If col < 0 OrElse col > _documentLines(row).Text.Length Then
                Return String.Empty
            End If

            'イベントのvariableを設定
            e_documentChangeType = DocumentChangeTypeEnum.InsertText
            e_row = row
            e_col = col
            e_text = text
            e_oldText = String.Empty

            'insert処理
            _documentLines(row).Text.Insert(col, text)
            SetDirtyFlag(True)

            'Enterキー、Tabキーの転換処理
            ProcessEnterAndTab(row)

            If sendEvent Then
                e = New DocumentChangedEventArgs(New EditActionInfo(e_documentChangeType, e_row, e_col, e_text, e_oldText))
                RaiseEvent DocumentChanged(Me, e)
            Else
            End If

            Return text
        End Function

        Public Function RemoveText(ByVal row As Integer, ByVal col As Integer, ByVal length As Integer, ByVal sendEvent As Boolean) As String
            Dim e As DocumentChangedEventArgs
            Dim e_documentChangeType As DocumentChangeTypeEnum
            Dim e_row As Integer
            Dim e_col As Integer
            Dim e_text As String
            Dim e_oldText As String
            Dim totalDelLength As Integer = length
            Dim delLength As Integer
            Dim str As String
            Dim delString As New StringBuilder(String.Empty)

            e_documentChangeType = DocumentChangeTypeEnum.RemoveText
            e_row = row
            e_col = col
            e_text = String.Empty
            e_oldText = String.Empty


            If _documentLines(row).Text.Length - col > totalDelLength Then
                delLength = totalDelLength
            Else
                delLength = _documentLines(row).Text.Length - col
            End If
            totalDelLength -= delLength
            delString.Append(_documentLines(row).TextString.Substring(col, delLength))
            _documentLines(row).Text.Remove(col, delLength)

            While totalDelLength > 0
                totalDelLength -= 1
                If row + 1 <= DocumentLinesCount - 1 Then
                    str = _documentLines(row + 1).TextString
                Else
                    Exit While
                End If
                _documentLines(row).Text.Append(str)
                delString.Append(EOL)
                _documentLines.RemoveAt(row + 1)

                If _documentLines(row).Text.Length - col > totalDelLength Then
                    delLength = totalDelLength
                Else
                    delLength = _documentLines(row).Text.Length - col
                End If
                totalDelLength -= delLength
                delString.Append(_documentLines(row).TextString.Substring(col, delLength))
                _documentLines(row).Text.Remove(col, delLength)
            End While

            e_oldText = delString.ToString
            SetDirtyFlag(True)

            If sendEvent Then
                e = New DocumentChangedEventArgs(New EditActionInfo(e_documentChangeType, e_row, e_col, e_text, e_oldText))
                RaiseEvent DocumentChanged(Me, e)
            Else
            End If

            Return e_oldText
        End Function

        Public Function ReplaceText(ByVal row As Integer, ByVal col As Integer, ByVal length As Integer, ByVal text As String, ByVal sendEvent As Boolean) As String
            Dim e As DocumentChangedEventArgs
            Dim e_documentChangeType As DocumentChangeTypeEnum
            Dim e_row As Integer
            Dim e_col As Integer
            Dim e_text As String
            Dim e_oldText As String


            e_documentChangeType = DocumentChangeTypeEnum.ReplaceText
            e_row = row
            e_col = col
            e_text = text
            e_oldText = RemoveText(row, col, length, False)
            InsertText(row, col, text, False)
            SetDirtyFlag(True)
            If sendEvent Then
                e = New DocumentChangedEventArgs(New EditActionInfo(e_documentChangeType, e_row, e_col, e_text, e_oldText))
                RaiseEvent DocumentChanged(Me, e)
            End If

            Return e_oldText
        End Function

        Public Function Undo() As EditActionInfo
            Dim editActionInfo As EditActionInfo

            If _undoStack.Count > 0 Then
                editActionInfo = _undoStack.Pop
                Select Case editActionInfo.DocumentChangeType
                    Case DocumentChangeTypeEnum.InsertText
                        InsertText(editActionInfo.Row, editActionInfo.Col, editActionInfo.Text, False)
                    Case DocumentChangeTypeEnum.RemoveText
                        RemoveText(editActionInfo.Row, editActionInfo.Col, editActionInfo.OldText.Replace(EOL, " ").Length, False)
                    Case DocumentChangeTypeEnum.ReplaceText
                        ReplaceText(editActionInfo.Row, editActionInfo.Col, editActionInfo.OldText.Replace(EOL, " ").Length, editActionInfo.Text, False)
                    Case Else
                End Select
                PushActionInfoIntoRedoStack(GetUndoEditActionInfo(editActionInfo))
            Else
                editActionInfo = Nothing
            End If

            Return editActionInfo
        End Function

        Public Function Redo() As EditActionInfo
            Dim editActionInfo As EditActionInfo

            If _redoStack.Count > 0 Then
                editActionInfo = _redoStack.Pop
                Select Case editActionInfo.DocumentChangeType
                    Case DocumentChangeTypeEnum.InsertText
                        InsertText(editActionInfo.Row, editActionInfo.Col, editActionInfo.Text, False)
                    Case DocumentChangeTypeEnum.RemoveText
                        RemoveText(editActionInfo.Row, editActionInfo.Col, editActionInfo.OldText.Replace(EOL, " ").Length, False)
                    Case DocumentChangeTypeEnum.ReplaceText
                        ReplaceText(editActionInfo.Row, editActionInfo.Col, editActionInfo.OldText.Replace(EOL, " ").Length, editActionInfo.Text, False)
                    Case Else
                End Select
                PushActionInfoIntoUndoStack(GetUndoEditActionInfo(editActionInfo))
            Else
                editActionInfo = Nothing
            End If

            Return editActionInfo
        End Function

        Private Sub ProcessEnterAndTab(ByVal row As Integer)
            Dim index As Integer
            Dim str As String

            If row < 0 OrElse row > DocumentLinesCount - 1 Then
                Return
            End If

            'Tabキーの処理
            index = _documentLines(row).TextString.IndexOf(Common.CommonConst.KEY_TAB)
            While index <> -1
                Dim spaceCount As Integer
                str = _documentLines(row).TextString.Substring(0, index)
                spaceCount = TabSpan - (Common.StringTransaction.GetByteCountFromIndex(str, str.Length) Mod TabSpan)
                _documentLines(row).Text.Replace(Common.CommonConst.KEY_TAB, Space(spaceCount), 0, str.Length + 1)
                index = _documentLines(row).TextString.IndexOf(Common.CommonConst.KEY_TAB)
            End While


            'Enterキーの処理
            index = _documentLines(row).TextString.LastIndexOf(EOL)
            While index <> -1
                If index = _documentLines(row).Text.Length - 1 Then
                    str = String.Empty
                    _documentLines(row).Text.Remove(index, EOL.Length)
                Else
                    str = _documentLines(row).TextString.Substring(index + EOL.Length)
                    _documentLines(row).Text.Remove(index, str.Length + EOL.Length)
                End If
                _documentLines.Insert(row + 1, New DocumentLine(str))
                index = _documentLines(row).TextString.LastIndexOf(EOL)
            End While

        End Sub

        Private Sub OnDocumentChanged(ByVal sender As Object, ByVal e As EventArgs.DocumentChangedEventArgs) Handles Me.DocumentChanged
            PushActionInfoIntoUndoStack(GetUndoEditActionInfo(e.EditActionInfo))
        End Sub

        Private Sub PushActionInfoIntoUndoStack(ByVal editActionInfo As EditActionInfo)
            _undoStack.Push(editActionInfo)
        End Sub

        Private Sub PushActionInfoIntoRedoStack(ByVal editActionInfo As EditActionInfo)
            _redoStack.Push(editActionInfo)
        End Sub

        Private Sub SetDirtyFlag(ByVal isDirty As Boolean)
            If _documentDirtyFlag <> isDirty Then
                _documentDirtyFlag = isDirty
                RaiseEvent DocumentDirty(Me, New DocumentDirtyEventArgs(_documentDirtyFlag))
            Else
            End If
        End Sub

        Private Sub Initialize(ByVal documentFileName As String, ByVal dirtyFlag As Boolean, Optional ByVal documentEncoding As Encoding = Nothing)
            _documentFileName = documentFileName
            _documentLines = New List(Of DocumentLine)
            If documentEncoding IsNot Nothing Then
                _documentEncoding = documentEncoding
            Else
                _documentEncoding = Encoding.GetEncoding(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ANSICodePage)
            End If
            _documentDirtyFlag = dirtyFlag
            _eOL = vbCrLf
            _tabSpan = 8
            _selection = New Selection(Me, New Position(0, 0), New Position(0, 0))
            _undoStack = New Stack(Of EditActionInfo)
            _redoStack = New Stack(Of EditActionInfo)
        End Sub

        Private Function GetUndoEditActionInfo(ByVal editActionInfo As EditActionInfo) As EditActionInfo
            Dim result As EditActionInfo
            Dim documentChangeType As DocumentChangeTypeEnum
            Dim row As Integer
            Dim col As Integer
            Dim text As String
            Dim oldText As String

            Select Case editActionInfo.DocumentChangeType

                Case DocumentChangeTypeEnum.InsertText
                    documentChangeType = DocumentChangeTypeEnum.RemoveText
                    row = editActionInfo.Row
                    col = editActionInfo.Col
                    text = String.Empty
                    oldText = editActionInfo.Text

                Case DocumentChangeTypeEnum.RemoveText
                    documentChangeType = DocumentChangeTypeEnum.InsertText
                    row = editActionInfo.Row
                    col = editActionInfo.Col
                    text = editActionInfo.OldText
                    oldText = String.Empty

                Case DocumentChangeTypeEnum.ReplaceText
                    documentChangeType = DocumentChangeTypeEnum.ReplaceText
                    row = editActionInfo.Row
                    col = editActionInfo.Col
                    text = editActionInfo.OldText
                    oldText = editActionInfo.Text

                Case Else
                    documentChangeType = DocumentChangeTypeEnum.Unknown
                    row = editActionInfo.Row
                    col = editActionInfo.Col
                    text = editActionInfo.Text
                    oldText = editActionInfo.OldText

            End Select

            result = New EditActionInfo(documentChangeType, row, col, text, oldText)
            Return result

        End Function

    End Class

End Namespace