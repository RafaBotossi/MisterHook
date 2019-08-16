Namespace MisterHook.Models

    'Modelo criado para também ter o Timestamp de quando foi pressionada a tecla
    Public Class KeyboardHookModel
        Public Timestamp As Date 'Timestamp usado para fazer o timing entre as ações
        Public KeyboardStruct As Structs.KeyboardHookStruct 'Estrutura de hook do Teclado
    End Class

End Namespace