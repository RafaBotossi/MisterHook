Imports System.Runtime.InteropServices

Namespace MisterHook.Structs

    'Estrutura de ponto para uso na estrutura de hook de mouse
    <StructLayout(LayoutKind.Sequential)> Public Structure MouseHookPointStruct
        Public x As Integer
        Public y As Integer
    End Structure

End Namespace