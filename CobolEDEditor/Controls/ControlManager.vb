'-------------------------------------------------------------------------------
'--                                                                           --
'--  FILE          :  ControlManager.vb                                       --
'--                                                                           --
'--  Author(s)     :  Robert Skolnick NVSDI                       --
'--                                                                           --
'--  NameSpace     :  CobolEDEditor.Controls                                  --
'--                                                                           --
'--  Project       :  CobolEDEditor                                           --
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

Namespace Controls
    Public Class ControlManager

        Public Shared SCROLLBAR As String = "ScrollBarControl"
        Public Shared TEXTVIEW_CARET As String = "TextViewCaretControl"
        Public Shared TEXTVIEW_EDIT As String = "TextViewEditControl"
        Public Shared TEXTVIEW_SELECTION As String = "TextViewSelectionControl"
        Public Shared TEXTVIEW_UNDO As String = "TextViewUndoControl"
        Public Shared BOOKMARKVIEW As String = "BookMarkViewControl"
        Public Shared RULERVIEW As String = "RulerViewControl"
        Public Shared CODECOMPLETIONFORM As String = "CodeCompletionFormControl"

        Private _controls As Dictionary(Of String, ControlBase)

        Public Sub New()
            _controls = New Dictionary(Of String, ControlBase)
        End Sub

        Public ReadOnly Property Control(ByVal controlName As String) As ControlBase
            Get
                Dim result As ControlBase
                If _controls.ContainsKey(controlName) Then
                    result = _controls(controlName)
                Else
                    result = Nothing
                End If
                Return result
            End Get
        End Property

        Public Sub AddControl(ByVal controlName As String, ByVal control As ControlBase)
            _controls.Add(controlName, control)
            _controls(controlName).Enable = True
        End Sub

        Public Sub RemoveControl(ByVal controlName As String)
            If _controls.ContainsKey(controlName) Then
                _controls(controlName).Enable = False
                _controls.Remove(controlName)
            End If
        End Sub

    End Class

End Namespace
