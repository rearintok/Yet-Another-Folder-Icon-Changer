Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

Namespace Microsoft.API
	<UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet := CharSet.Auto)> _
	Public Delegate Function EnumResNameProc(hModule As IntPtr, lpszType As ResourceTypes, lpszName As IntPtr, lParam As IntPtr) As Boolean

	#Region "Enumurations"
	<Flags> _
	Public Enum LoadLibraryExFlags As Integer
		DONT_RESOLVE_DLL_REFERENCES = &H1
		LOAD_LIBRARY_AS_DATAFILE = &H2
		LOAD_WITH_ALTERED_SEARCH_PATH = &H8
	End Enum
	Public Enum GetLastErrorResult As Integer
		ERROR_SUCCESS = 0
		ERROR_FILE_NOT_FOUND = 2
		ERROR_BAD_EXE_FORMAT = 193
		ERROR_RESOURCE_TYPE_NOT_FOUND = 1813
	End Enum
	Public Enum ResourceTypes As Integer
		RT_ICON = 3
		RT_GROUP_ICON = 14
	End Enum
	Public Enum LookupIconIdFromDirectoryExFlags As Integer
		LR_DEFAULTCOLOR = 0
		LR_MONOCHROME = 1
	End Enum
	Public Enum LoadImageTypes As Integer
		IMAGE_BITMAP = 0
		IMAGE_ICON = 1
		IMAGE_CURSOR = 2
	End Enum
	<Flags> _
	Public Enum SHGetFileInfoFlags As Integer
		Icon = &H100
		' get icon
		DisplayName = &H200
		' get display name
		TypeName = &H400
		' get type name
		Attributes = &H800
		' get attributes
		IconLocation = &H1000
		' get icon location
		ExeType = &H2000
		' return exe type
		SysIconIndex = &H4000
		' get system icon index
		LinkOverlay = &H8000
		' put a link overlay on icon
		Selected = &H10000
		' show icon in selected state
		AttrSpecified = &H20000
		' get only specified attributes
		LargeIcon = &H0
		' get large icon
		SmallIcon = &H1
		' get small icon
		OpenIcon = &H2
		' get open icon
		ShellIconSize = &H4
		' get shell size icon
		PIDL = &H8
		' pszPath is a pidl
		UseFileAttributes = &H10
		' use passed dwFileAttribute
	End Enum
	#End Region

	#Region "Structures"
	<StructLayout(LayoutKind.Sequential)> _
	Public Structure SHFILEINFO
		Public hIcon As IntPtr
		Public iIcon As IntPtr
		Public dwAttributes As UInteger
		<MarshalAs(UnmanagedType.ByValTStr, SizeConst := 260)> _
		Public szDisplayName As String
		<MarshalAs(UnmanagedType.ByValTStr, SizeConst := 80)> _
		Public szTypeName As String
	End Structure
	#End Region

	Public NotInheritable Class Win32
		Private Sub New()
		End Sub
		#Region "Constants"
		Public Const MAX_PATH As Integer = 260
		#End Region

		#Region "Helper Functions"
		Public Shared Function IsIntResource(lpszName As IntPtr) As Boolean
            Return ((CUInt(lpszName) >> 16) = 0)
		End Function
		#End Region

		#Region "API Functions"
		<DllImport("kernel32.dll", SetLastError := True, CharSet := CharSet.Auto)> _
		Public Shared Function LoadLibrary(lpFileName As String) As IntPtr
		End Function

		<DllImport("kernel32.dll", SetLastError := True, CharSet := CharSet.Auto)> _
		Public Shared Function LoadLibraryEx(lpFileName As String, hFile As IntPtr, dwFlags As LoadLibraryExFlags) As IntPtr
		End Function

		Public Declare Auto Function FreeLibrary Lib "kernel32.dll" (hModule As IntPtr) As Boolean

		<DllImport("kernel32.dll", SetLastError := True, CharSet := CharSet.Auto)> _
		Public Shared Function GetModuleFileName(hModule As IntPtr, lpFilename As StringBuilder, nSize As Integer) As Integer
		End Function

		<DllImport("kernel32.dll", SetLastError := True, CharSet := CharSet.Auto)> _
		Public Shared Function EnumResourceNames(hModule As IntPtr, lpszType As ResourceTypes, lpEnumFunc As EnumResNameProc, lParam As IntPtr) As Boolean
		End Function

		<DllImport("kernel32.dll", SetLastError := True, CharSet := CharSet.Auto)> _
		Public Shared Function FindResource(hModule As IntPtr, lpName As IntPtr, lpType As ResourceTypes) As IntPtr
		End Function

		Public Declare Auto Function LoadResource Lib "kernel32.dll" (hModule As IntPtr, hResInfo As IntPtr) As IntPtr

		Public Declare Auto Function LockResource Lib "kernel32.dll" (hResData As IntPtr) As IntPtr

		Public Declare Auto Function SizeofResource Lib "kernel32.dll" (hModule As IntPtr, hResInfo As IntPtr) As Integer

		Public Declare Auto Function LookupIconIdFromDirectory Lib "user32.dll" (presbits As IntPtr, fIcon As Boolean) As Integer

		Public Declare Auto Function LookupIconIdFromDirectoryEx Lib "user32.dll" (presbits As IntPtr, fIcon As Boolean, cxDesired As Integer, cyDesired As Integer, Flags As LookupIconIdFromDirectoryExFlags) As Integer

		Public Declare Auto Function LoadImage Lib "user32.dll" Alias "LoadImageW" (hInstance As IntPtr, lpszName As IntPtr, imageType As LoadImageTypes, cxDesired As Integer, cyDesired As Integer, fuLoad As UInteger) As IntPtr

		<DllImport("shell32.dll")> _
		Public Shared Function SHGetFileInfo(pszPath As String, dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, cbSizeFileInfo As UInteger, uFlags As SHGetFileInfoFlags) As IntPtr
		End Function
		#End Region
	End Class
End Namespace
