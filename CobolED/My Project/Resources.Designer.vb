﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("CobolED.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Background() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Background", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Configuration file : for { 0 } can not be opened , and then use the default settings . | I.
        '''</summary>
        Friend ReadOnly Property CED002_001_I() As String
            Get
                Return ResourceManager.GetString("CED002_001_I", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Component definition file : for { 0 } does not exist , it can not be started . | C.
        '''</summary>
        Friend ReadOnly Property CED002_002_C() As String
            Get
                Return ResourceManager.GetString("CED002_002_C", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to When you establish the analyzer , an error has occurred . ({0}) | C.
        '''</summary>
        Friend ReadOnly Property CED002_003_C() As String
            Get
                Return ResourceManager.GetString("CED002_003_C", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to When establishing the editor , error has occurred . ({0}) | C.
        '''</summary>
        Friend ReadOnly Property CED002_004_C() As String
            Get
                Return ResourceManager.GetString("CED002_004_C", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to When you establish a search engine , an error has occurred . ({0}) | C.
        '''</summary>
        Friend ReadOnly Property CED002_005_C() As String
            Get
                Return ResourceManager.GetString("CED002_005_C", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to When writing the information to the configuration file , an error has occurred . ({0}) | E.
        '''</summary>
        Friend ReadOnly Property CED002_006_E() As String
            Get
                Return ResourceManager.GetString("CED002_006_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Please enter a project name . | E.
        '''</summary>
        Friend ReadOnly Property CED002_007_E() As String
            Get
                Return ResourceManager.GetString("CED002_007_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Please enter the project path . | E.
        '''</summary>
        Friend ReadOnly Property CED002_008_E() As String
            Get
                Return ResourceManager.GetString("CED002_008_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Project path you entered does not exist . | E.
        '''</summary>
        Friend ReadOnly Property CED002_009_E() As String
            Get
                Return ResourceManager.GetString("CED002_009_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Please enter a file name . | E.
        '''</summary>
        Friend ReadOnly Property CED002_010_E() As String
            Get
                Return ResourceManager.GetString("CED002_010_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Please select a template . | E.
        '''</summary>
        Friend ReadOnly Property CED002_011_E() As String
            Get
                Return ResourceManager.GetString("CED002_011_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to File name you entered already exists . | E.
        '''</summary>
        Friend ReadOnly Property CED002_012_E() As String
            Get
                Return ResourceManager.GetString("CED002_012_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to File name you entered already exists . | E.
        '''</summary>
        Friend ReadOnly Property CED002_013_C() As String
            Get
                Return ResourceManager.GetString("CED002_013_C", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to File name you entered already exists . | E.
        '''</summary>
        Friend ReadOnly Property CED002_014_E() As String
            Get
                Return ResourceManager.GetString("CED002_014_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to When you save the project information , an error has occurred . ({0}) | E.
        '''</summary>
        Friend ReadOnly Property CED002_015_E() As String
            Get
                Return ResourceManager.GetString("CED002_015_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Specified file : { 0 } can not be opened . | E.
        '''</summary>
        Friend ReadOnly Property CED002_016_E() As String
            Get
                Return ResourceManager.GetString("CED002_016_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to { 0 } Do you want to save the file ? | Q.
        '''</summary>
        Friend ReadOnly Property CED002_017_Q() As String
            Get
                Return ResourceManager.GetString("CED002_017_Q", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Because the file does not exist , you can not reload . | E.
        '''</summary>
        Friend ReadOnly Property CED002_018_E() As String
            Get
                Return ResourceManager.GetString("CED002_018_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Input line number is not a number . | E.
        '''</summary>
        Friend ReadOnly Property CED002_019_E() As String
            Get
                Return ResourceManager.GetString("CED002_019_E", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Specified string is not found . | I.
        '''</summary>
        Friend ReadOnly Property CED002_020_I() As String
            Get
                Return ResourceManager.GetString("CED002_020_I", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        '''</summary>
        Friend ReadOnly Property CobolED() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("CobolED", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property CobolED80() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("CobolED80", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to CobolEDComponentDefines.xml.
        '''</summary>
        Friend ReadOnly Property ComponentFileName() As String
            Get
                Return ResourceManager.GetString("ComponentFileName", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Edit_CommentCancel() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Edit_CommentCancel", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Edit_CommentOut() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Edit_CommentOut", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Edit_Copy() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Edit_Copy", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Edit_Cut() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Edit_Cut", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Edit_Paste() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Edit_Paste", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Edit_Redo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Edit_Redo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Edit_Undo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Edit_Undo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property File_NewProject() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("File_NewProject", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property File_OpenFile() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("File_OpenFile", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property File_OpenProject() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("File_OpenProject", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property File_PageSetup() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("File_PageSetup", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property File_Print() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("File_Print", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property File_PrintPreview() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("File_PrintPreview", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property File_Save() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("File_Save", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property File_SaveAll() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("File_SaveAll", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Help_GPL() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Help_GPL", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Help_History() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Help_History", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Help_Technology() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Help_Technology", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Search_ClearBookMark() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Search_ClearBookMark", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Search_Find() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Search_Find", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Search_FindNext() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Search_FindNext", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Search_FindPrev() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Search_FindPrev", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Search_GoToDefine() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Search_GoToDefine", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Search_NextBookMark() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Search_NextBookMark", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Search_PrevBookMark() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Search_PrevBookMark", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Search_ReGoTo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Search_ReGoTo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Search_Replace() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Search_Replace", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Search_SetBookMark() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Search_SetBookMark", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Search_UnGoTo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Search_UnGoTo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Setting_Option() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Setting_Option", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to CobolEDSettingDefines.xml.
        '''</summary>
        Friend ReadOnly Property SettingFileName() As String
            Get
                Return ResourceManager.GetString("SettingFileName", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property SplashTitle() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("SplashTitle", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Window_CloseWindow() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Window_CloseWindow", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Window_RevertWindow() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Window_RevertWindow", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace
