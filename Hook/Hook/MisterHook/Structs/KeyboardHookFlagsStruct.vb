Namespace MisterHook.Structs

    'Flags da estrutura de Keyboard
    <Flags()>
    Public Enum KeyboardHookFlagsStruct As UInt32
        LLKHF_EXTENDED = &H1
        LLKHF_INJECTED = &H10
        LLKHF_ALTDOWN = &H20
        LLKHF_UP = &H80
    End Enum

End Namespace