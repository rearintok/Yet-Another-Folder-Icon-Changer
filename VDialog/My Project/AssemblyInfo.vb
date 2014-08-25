Imports System
Imports System.Reflection
Imports System.Resources
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Permissions

' General Information about an assembly is controlled through the following
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("VDialog")> 
<Assembly: AssemblyDescription("VDialog component")> 
<Assembly: AssemblyCompany("Łukasz Świątkowski")> 
<Assembly: AssemblyProduct("VDialog")> 
<Assembly: AssemblyCopyright("Copyright © Łukasz Świątkowski 2007-2008")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("6d62e815-10d4-4dcd-b99b-c355cb644a63")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers
' by using the '*' as shown below:
' <Assembly: AssemblyVersion("1.0.*")>

<Assembly: AssemblyVersion("1.5.*")> 

<Assembly: NeutralResourcesLanguageAttribute("en")> 

<Assembly: AllowPartiallyTrustedCallers()> 
<Assembly: System.Security.Permissions.SecurityPermission(SecurityAction.RequestMinimum, UnmanagedCode:=True)> 
<Assembly: UIPermission(SecurityAction.RequestMinimum, Window:=UIPermissionWindow.SafeSubWindows)> 
