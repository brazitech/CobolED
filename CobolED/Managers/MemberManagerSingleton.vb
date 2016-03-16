'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  MemberManagerSingleton.vb                               --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolED.Managers                                        --
'--                                                                           --
'--  Project       :  CobolED                                                 --
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

Imports CobolEDCore.Infos.Analyzer
Imports CobolEDCore.EventArgs
Imports CobolEDCore.Document
Imports CobolEDCore.Interfaces.Analyzer
Imports CobolEDCore.Interfaces.Editor
Imports CobolEDCore.Interfaces.View
Imports CobolED.Forms
Imports CobolED.Managers.Manager
Imports System.Threading

Namespace Managers
    Public Class MemberManagerSingleton

        Private _functionInfoTable As Dictionary(Of String, List(Of FunctionInfo))
        Private _variableInfoTable As Dictionary(Of String, List(Of VariableInfo))
        Private _includeInfoTable As Dictionary(Of String, List(Of IncludeInfo))
        Private _needUpdateMemberViewList As List(Of INeedUpdateMember)

        Private Shared _memberManager As MemberManagerSingleton

        Private Sub New()
            _functionInfoTable = New Dictionary(Of String, List(Of FunctionInfo))
            _variableInfoTable = New Dictionary(Of String, List(Of VariableInfo))
            _includeInfoTable = New Dictionary(Of String, List(Of IncludeInfo))
            _needUpdateMemberViewList = New List(Of INeedUpdateMember)
        End Sub

        Public Shared ReadOnly Property MemberManager() As MemberManagerSingleton
            Get
                If _memberManager Is Nothing Then
                    _memberManager = New MemberManagerSingleton
                End If
                Return _memberManager
            End Get
        End Property

        Public Sub Initialize(ByVal ParamArray needUpdateMemberViews() As INeedUpdateMember)
            For Each needUpdateMemberView As INeedUpdateMember In needUpdateMemberViews
                _needUpdateMemberViewList.Add(needUpdateMemberView)
            Next
        End Sub

        Public Sub InitializeMemberInfosFromProjectInfo(ByVal projectInfo As ProjectInfo)
            Dim document As Document
            Dim cobolEDAnalyzer As ICobolEDAnalyzer
            Dim cobolEDSyntax As ICobolEDSyntax

            For Each programinfo As ProgramInfo In projectInfo.ProgramInfos
                document = DocumentManager.Documents(programinfo.ProgramFileName)
                cobolEDAnalyzer = AnalyzerManager.Analyzers(programinfo.ProgramType)
                If cobolEDAnalyzer IsNot Nothing Then
                    cobolEDSyntax = cobolEDAnalyzer.CobolEDSyntax
                Else
                    cobolEDSyntax = Nothing
                End If
                If document IsNot Nothing Then
                    SetMembers(document, cobolEDSyntax)                    
                End If
            Next

        End Sub

        Public Sub SetMembers(ByVal document As Document, ByVal cobolEDSyntax As ICobolEDSyntax)
            Dim functionInfoList As List(Of FunctionInfo)
            Dim variableInfoList As List(Of VariableInfo)
            Dim includeInfoList As List(Of IncludeInfo)


            functionInfoList = New List(Of FunctionInfo)
            variableInfoList = New List(Of VariableInfo)
            includeInfoList = New List(Of IncludeInfo)

            If cobolEDSyntax IsNot Nothing Then
                cobolEDSyntax.GetMembers(document, functionInfoList, variableInfoList, includeInfoList)
                _functionInfoTable.Remove(document.DocumentFileName)
                _functionInfoTable.Add(document.DocumentFileName, functionInfoList)
                _variableInfoTable.Remove(document.DocumentFileName)
                _variableInfoTable.Add(document.DocumentFileName, variableInfoList)
                _includeInfoTable.Remove(document.DocumentFileName)
                _includeInfoTable.Add(document.DocumentFileName, includeInfoList)
            Else
            End If

        End Sub

        Public Sub DeleteMembers(ByVal DocumentName As String)
            _functionInfoTable.Remove(DocumentName)
            _variableInfoTable.Remove(DocumentName)
            _includeInfoTable.Remove(DocumentName)
        End Sub

        Public Sub SetFunctionInfos(ByVal document As Document, ByVal cobolEDSyntax As ICobolEDSyntax)
            Dim functionInfoList As List(Of FunctionInfo)
            If cobolEDSyntax IsNot Nothing Then
                _functionInfoTable.Remove(document.DocumentFileName)
                functionInfoList = cobolEDSyntax.GetFunctions(document)
                _functionInfoTable.Add(document.DocumentFileName, functionInfoList)
            Else
            End If
        End Sub

        Public Sub SetVariableInfos(ByVal document As Document, ByVal cobolEDSyntax As ICobolEDSyntax)
            Dim variableInfoList As List(Of VariableInfo)
            If cobolEDSyntax IsNot Nothing Then
                _variableInfoTable.Remove(document.DocumentFileName)
                variableInfoList = cobolEDSyntax.GetVariables(document)
                _variableInfoTable.Add(document.DocumentFileName, variableInfoList)
            Else
            End If
        End Sub

        Public Sub SetIncludeInfos(ByVal document As Document, ByVal cobolEDSyntax As ICobolEDSyntax)
            Dim includeInfoList As List(Of IncludeInfo)
            If cobolEDSyntax IsNot Nothing Then
                _includeInfoTable.Remove(document.DocumentFileName)
                includeInfoList = cobolEDSyntax.GetIncludes(document)
                _includeInfoTable.Add(document.DocumentFileName, includeInfoList)
            Else
            End If
        End Sub

        Public Sub RemoveAllMember()
            Me._functionInfoTable.Clear()
            Me._includeInfoTable.Clear()
            Me._variableInfoTable.Clear()
        End Sub

        Public Sub AddDocumentForm(ByVal documentForm As DocumentForm)
            AddHandler documentForm.CobolEDEditor.MouseStopAtWord, AddressOf OnEditorMouseStopAtWord
            AddHandler documentForm.CobolEDEditor.NeedUpdateMember, AddressOf OnEditorNeedUpdateMember
            AddHandler documentForm.Load, AddressOf OnDocumentFormLoad
        End Sub

        Public Sub RemoveDocumentForm(ByVal documentForm As DocumentForm)
            RemoveHandler documentForm.CobolEDEditor.MouseStopAtWord, AddressOf OnEditorMouseStopAtWord
            RemoveHandler documentForm.CobolEDEditor.NeedUpdateMember, AddressOf OnEditorNeedUpdateMember
            RemoveHandler documentForm.Load, AddressOf OnDocumentFormLoad
        End Sub

        Public Function GetFunctionInfoList(ByVal documentFileName As String) As List(Of FunctionInfo)
            Dim result As List(Of FunctionInfo)
            If _functionInfoTable.ContainsKey(documentFileName) Then
                result = _functionInfoTable(documentFileName)
            Else
                result = New List(Of FunctionInfo)
                result.Clear()
            End If
            Return result
        End Function

        Public Function GetFunctionInfo(ByVal documentFileName As String, ByVal functionName As String, Optional ByVal withInclude As Boolean = False, Optional ByVal includeInfo As IncludeInfo = Nothing) As FunctionInfo
            Dim result As FunctionInfo
            Dim functionInfoList As List(Of FunctionInfo)
            Dim prefixing As String
            Dim suffixing As String

            result = Nothing
            functionInfoList = GetFunctionInfoList(documentFileName)
            If includeInfo IsNot Nothing Then
                prefixing = includeInfo.IncludePrefixing
                suffixing = includeInfo.IncludeSuffixing
            Else
                prefixing = String.Empty
                suffixing = String.Empty
            End If

            For Each functionInfo As FunctionInfo In functionInfoList
                If functionName = prefixing & functionInfo.FunctionName & suffixing Then
                    result = functionInfo
                    Exit For
                End If
            Next

            If result Is Nothing AndAlso withInclude AndAlso _includeInfoTable.ContainsKey(documentFileName) Then
                For Each subIncludeInfo As IncludeInfo In _includeInfoTable(documentFileName)
                    If functionName.StartsWith(subIncludeInfo.IncludePrefixing) AndAlso _
                       functionName.EndsWith(subIncludeInfo.IncludeSuffixing) Then
                        result = GetFunctionInfo(GetFileNameFromIncludeName(subIncludeInfo.IncludeName), functionName, True, subIncludeInfo)
                        If result IsNot Nothing Then
                            Exit For
                        Else
                        End If
                    End If
                Next
            End If

            Return result
        End Function

        Public Function GetVariableInfoList(ByVal documentFileName As String) As List(Of VariableInfo)
            Dim result As List(Of VariableInfo)
            If _variableInfoTable.ContainsKey(documentFileName) Then
                result = _variableInfoTable(documentFileName)
            Else
                result = New List(Of VariableInfo)
                result.Clear()
            End If
            Return result
        End Function

        Public Function GetVariableInfo(ByVal documentFileName As String, ByVal variableName As String, Optional ByVal withInclude As Boolean = False, Optional ByVal includeInfo As IncludeInfo = Nothing) As VariableInfo
            Dim result As VariableInfo
            Dim variableInfoList As List(Of VariableInfo)
            Dim prefixing As String
            Dim suffixing As String

            result = Nothing
            variableInfoList = GetVariableInfoList(documentFileName)
            If includeInfo IsNot Nothing Then
                prefixing = includeInfo.IncludePrefixing
                suffixing = includeInfo.IncludeSuffixing
            Else
                prefixing = String.Empty
                suffixing = String.Empty
            End If

            For Each variableInfo As VariableInfo In variableInfoList
                If variableName = prefixing & variableInfo.VariableName & suffixing Then
                    result = variableInfo
                    Exit For
                End If
            Next

            If result Is Nothing AndAlso withInclude AndAlso _includeInfoTable.ContainsKey(documentFileName) Then
                For Each subIncludeInfo As IncludeInfo In _includeInfoTable(documentFileName)
                    If variableName.StartsWith(subIncludeInfo.IncludePrefixing) AndAlso _
                       variableName.EndsWith(subIncludeInfo.IncludeSuffixing) Then
                        result = GetVariableInfo(GetFileNameFromIncludeName(subIncludeInfo.IncludeName), variableName, True, subIncludeInfo)
                        If result IsNot Nothing Then
                            Exit For
                        Else
                        End If
                    End If
                Next
            End If

            Return result
        End Function

        Public Function GetIncludeInfoList(ByVal documentFileName As String) As List(Of IncludeInfo)
            Dim result As List(Of IncludeInfo)
            If _includeInfoTable.ContainsKey(documentFileName) Then
                result = _includeInfoTable(documentFileName)
            Else
                result = New List(Of IncludeInfo)
                result.Clear()
            End If
            Return result
        End Function

        Public Function GetFunctionNameList(ByVal documentFileName As String, Optional ByVal withInclude As Boolean = False, Optional ByVal includeInfo As IncludeInfo = Nothing) As List(Of String)
            Dim result As List(Of String)
            Dim prefixing As String
            Dim suffixing As String


            result = New List(Of String)
            If includeInfo IsNot Nothing Then
                prefixing = includeInfo.IncludePrefixing
                suffixing = includeInfo.IncludeSuffixing
            Else
                prefixing = String.Empty
                suffixing = String.Empty
            End If

            If _functionInfoTable.ContainsKey(documentFileName) Then
                For Each functionInfo As FunctionInfo In _functionInfoTable(documentFileName)
                    result.Add(prefixing & functionInfo.FunctionName & suffixing)
                Next
            Else
            End If

            If withInclude AndAlso _includeInfoTable.ContainsKey(documentFileName) Then
                For Each subIncludeInfo As IncludeInfo In _includeInfoTable(documentFileName)
                    result.AddRange(GetFunctionNameList(GetFileNameFromIncludeName(subIncludeInfo.IncludeName), True, subIncludeInfo))
                Next
            Else
            End If
            Return result
        End Function

        Public Function GetVariableNameList(ByVal documentFileName As String, Optional ByVal withInclude As Boolean = False, Optional ByVal includeInfo As IncludeInfo = Nothing) As List(Of String)
            Dim result As List(Of String)

            Dim prefixing As String
            Dim suffixing As String


            result = New List(Of String)
            If includeInfo IsNot Nothing Then
                prefixing = includeInfo.IncludePrefixing
                suffixing = includeInfo.IncludeSuffixing
            Else
                prefixing = String.Empty
                suffixing = String.Empty
            End If

            If _variableInfoTable.ContainsKey(documentFileName) Then
                For Each variableInfo As VariableInfo In _variableInfoTable(documentFileName)
                    result.Add(prefixing & variableInfo.VariableName & suffixing)
                Next
            Else
            End If

            If withInclude AndAlso _includeInfoTable.ContainsKey(documentFileName) Then
                For Each subIncludeInfo As IncludeInfo In _includeInfoTable(documentFileName)
                    result.AddRange(GetVariableNameList(GetFileNameFromIncludeName(subIncludeInfo.IncludeName), True, subIncludeInfo))
                Next
            Else
            End If
            Return result
        End Function

        Private Sub OnEditorMouseStopAtWord(ByVal sender As Object, ByVal e As MouseStopAtWordEventArgs)
            Dim cobolEDEditor As ICobolEDEditor
            Dim functionInfo As FunctionInfo
            Dim variableInfo As VariableInfo
            Dim commentTipPosition As Point

            If TypeOf sender Is ICobolEDEditor Then
                cobolEDEditor = DirectCast(sender, ICobolEDEditor)
                commentTipPosition = e.Position
                commentTipPosition.Offset(16, -16)

                If e.Word.WordType = CobolEDCore.Enums.WordTypeEnum.NormalWord Then
                    functionInfo = GetFunctionInfo(cobolEDEditor.Document.DocumentFileName, e.Word.WordString, True)
                    If functionInfo IsNot Nothing Then
                        cobolEDEditor.ShowCommentTip(functionInfo.FunctionDeclare, commentTipPosition, -1)
                        Return
                    End If
                    variableInfo = GetVariableInfo(cobolEDEditor.Document.DocumentFileName, e.Word.WordString, True)
                    If variableInfo IsNot Nothing Then
                        cobolEDEditor.ShowCommentTip(variableInfo.VariableDeclare, commentTipPosition, -1)
                        Return
                    End If
                    cobolEDEditor.HideCommentTip()
                Else
                    cobolEDEditor.HideCommentTip()
                End If
            Else
            End If
        End Sub

        Private Sub OnDocumentFormLoad(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim documentForm As DocumentForm

            If TypeOf sender Is DocumentForm Then
                documentForm = DirectCast(sender, DocumentForm)
                SetEditorCodeCompletionForm(documentForm.CobolEDEditor)
            End If
        End Sub

        Private Sub OnEditorNeedUpdateMember(ByVal sender As Object, ByVal e As NeedUpdateMemberEventArgs)
            If TypeOf sender Is ICobolEDEditor Then
                UpdateMember(DirectCast(sender, ICobolEDEditor))
            Else
            End If
        End Sub

        Private Sub UpdateMember(ByVal cobolEDEditor As ICobolEDEditor)
            Dim cobolEDSyntax As ICobolEDSyntax
            Dim updateEditorThread As Thread

            If ProjectManager.ProjectInfo IsNot Nothing AndAlso _
               ProjectManager.ProjectInfo.ProgramInfos(cobolEDEditor.Document.DocumentFileName) IsNot Nothing Then

                If cobolEDEditor.CobolEDAnalyzer IsNot Nothing AndAlso _
                   cobolEDEditor.CobolEDAnalyzer.CobolEDSyntax IsNot Nothing Then
                    cobolEDSyntax = cobolEDEditor.CobolEDAnalyzer.CobolEDSyntax
                Else
                    cobolEDSyntax = Nothing
                End If
                SetMembers(cobolEDEditor.Document, cobolEDSyntax)

                updateEditorThread = New Thread(AddressOf SetEditorCodeCompletionForm)
                updateEditorThread.Start(cobolEDEditor)

                UpdateViews(ProjectManager.ProjectInfo.ProgramInfos(cobolEDEditor.Document.DocumentFileName))
            Else
            End If

        End Sub

        Private Sub SetEditorCodeCompletionForm(ByVal threadObject As Object)
            Dim cobolEDEditor As ICobolEDEditor
            Dim keyWords As List(Of String)
            Dim functionList As List(Of String)
            Dim variableList As List(Of String)

            If TypeOf threadObject Is ICobolEDEditor Then
                cobolEDEditor = DirectCast(threadObject, ICobolEDEditor)
                If cobolEDEditor.CobolEDAnalyzer IsNot Nothing AndAlso _
                   cobolEDEditor.CobolEDAnalyzer.CobolEDLex IsNot Nothing Then
                    keyWords = cobolEDEditor.CobolEDAnalyzer.CobolEDLex.KeyWords
                Else
                    keyWords = Nothing
                End If

                functionList = GetFunctionNameList(cobolEDEditor.Document.DocumentFileName, True)
                variableList = GetVariableNameList(cobolEDEditor.Document.DocumentFileName, True)

                cobolEDEditor.InitializeCodeListView(CobolEDCore.Enums.CodeCompletionListTypeEnum.All, _
                                                     keyWords, functionList, variableList)
            Else
            End If
        End Sub

        Private Sub UpdateViews(ByVal programInfo As ProgramInfo)
            For Each needUpdateMemberView As INeedUpdateMember In _needUpdateMemberViewList
                needUpdateMemberView.UpdateMember(programInfo)
            Next
        End Sub

        Private Function GetFileNameFromIncludeName(ByVal includeName As String) As String
            Dim result As String
            result = String.Empty
            For Each programInfo As ProgramInfo In ProjectManager.ProjectInfo.ProgramInfos
                If IO.Path.HasExtension(includeName) Then
                    If IO.Path.GetFileName(programInfo.ProgramFileName) = includeName Then
                        result = programInfo.ProgramFileName
                        Exit For
                    Else
                    End If
                Else
                    If IO.Path.GetFileNameWithoutExtension(programInfo.ProgramFileName) = includeName Then
                        result = programInfo.ProgramFileName
                        Exit For
                    Else
                    End If
                End If
            Next
            Return result
        End Function

    End Class
End Namespace
