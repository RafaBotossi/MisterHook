Imports MisterHook.MisterHook

Public Class FrmGeral

    Private hinstance As IntPtr

    'Objetos de Gravação de Mouse e Keyboard com Eventos
    Private WithEvents KeyboardRecorder As Record.KeyboardRecorder
    Private WithEvents MouseRecorder As Record.MouseRecorder

    'Objeto de Playback usado em ambos os objetos de gravação
    Private PlayBackActions As Playback.PlaybackActions

    'Variáveis usadas somente para contagem de segundos no form
    Const _SecondsBeforeRecord As Integer = 2
    Private _CountDownBeforeRecord As Integer
    Const _MilisecondsBeforePlayback As Integer = 1500

    Private _PathToSave As String, _Filename As String

#Region "Eventos do Form"

    'Load do Form, apenas seta a quantidade de segundos para contagem de gravação
    Private Sub FrmGeral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _CountDownBeforeRecord = _SecondsBeforeRecord

        'É necessário enviar o handle da instância do programa executado para os gravadores, se não enviar, a gravação não funciona.
        Dim hinstance As IntPtr = System.Runtime.InteropServices.Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0)).ToInt32

        'Se for haver playback, é necessário enviar o objeto para ambos os gravadores.
        PlayBackActions = New Playback.PlaybackActions(hinstance) 'Também é necessário enviar o handle do programa pro objeto de playback pois se no playback você quiser apertar a tecla 'Pause' para parar o playback, é possível, ou seja, existe um gravador de teclado também sendo executado no playback

    End Sub

    'Evento do botão de gravação. Altera os estados dos botões para não deixar clicar duas vezes e também inicia o Timer para gravação.
    Private Sub BtnRecord_Click(sender As Object, e As EventArgs) Handles BtnRecord.Click

        BtnRecord.Enabled = False
        BtnStop.Enabled = True
        BtnPlayback.Enabled = True

        lblRecord.Text = String.Format("A sua gravação começará em {0} segundos.", _CountDownBeforeRecord)
        lblRecord.Visible = True

        TmrRecord.Enabled = True

    End Sub

    'Evento do botão de parar gravação. Altera os estados dos botões para não deixar clicar duas vezes e também pára a gravação.
    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        BtnRecord.Enabled = True
        BtnStop.Enabled = False
        BtnPlayback.Enabled = True

        TmrRecord.Enabled = False
        lblRecord.Visible = False

        StopRecording()

    End Sub

    'Evento do botão para realizar playback do que foi gravado. Altera os estados dos botões para não deixar clicar duas vezes, inicia playback e ao terminar reativa botões.
    Private Sub BtnPlayback_Click(sender As Object, e As EventArgs) Handles BtnPlayback.Click

        BtnRecord.Enabled = False
        BtnStop.Enabled = False
        BtnPlayback.Enabled = False

        PlayBack()

        BtnRecord.Enabled = True
        BtnStop.Enabled = False
        BtnPlayback.Enabled = True

    End Sub

    'Timer para início da gravação.
    Private Sub TmrRecord_Tick(sender As Object, e As EventArgs) Handles TmrRecord.Tick

        _CountDownBeforeRecord -= 1

        lblRecord.Text = String.Format("A sua gravação começará em {0} segundos.", _CountDownBeforeRecord)

        If _CountDownBeforeRecord = 0 Then
            TmrRecord.Enabled = False
            _CountDownBeforeRecord = _SecondsBeforeRecord
            lblRecord.Visible = False
            StartRecording()
        End If

    End Sub

#End Region

#Region "Eventos de Gravação e Playback"

    'Evento de início de Gravação.
    Public Sub StartRecording()

        Try

            PlayBackActions.EraseData()

            KeyboardRecorder = New Record.KeyboardRecorder(hinstance, PlayBackActions)
            KeyboardRecorder.StartRecording()
            MouseRecorder = New Record.MouseRecorder(hinstance, PlayBackActions)
            MouseRecorder.StartRecording()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Evento de Stop de gravação
    Public Sub StopRecording()

        Try

            If KeyboardRecorder IsNot Nothing Then
                KeyboardRecorder.StopRecording()
            End If

            If MouseRecorder IsNot Nothing Then
                MouseRecorder.StopRecording()
            End If

            If PlayBackActions IsNot Nothing Then
                If (Fbd1.ShowDialog() = DialogResult.OK) Then
                    _PathToSave = Fbd1.SelectedPath
                End If
                _Filename = String.Format("MisterHook Recording {0}.txt", Now.ToString("yyyy-MM-dd hhmmss"))
                PlayBackActions.SaveRecordToFile(_PathToSave, _Filename)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Evento de Playback do que foi gravado.
    Public Sub PlayBack()
        Try

            Dim PathAndFilename As String = String.Empty
            If MessageBox.Show("Deseja carregar arquivo para playback? Se não, irá rodar playback da última gravação.", "Escolha de tipo de Playback", MessageBoxButtons.OKCancel) = DialogResult.OK Then

                Dim fd As OpenFileDialog = New OpenFileDialog()

                fd.Title = "Open File Dialog"
                fd.InitialDirectory = "C:\"
                fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
                fd.FilterIndex = 2
                fd.RestoreDirectory = True

                If fd.ShowDialog() = DialogResult.OK Then
                    PathAndFilename = fd.FileName
                End If

            End If

            Threading.Thread.Sleep(_MilisecondsBeforePlayback)
            If PlayBackActions IsNot Nothing Then
                PlayBackActions.Playback(PathAndFilename)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region

#Region "Eventos da DLL"

    'Evento passado do objeto de gravação de Keyboard para o Form. Aqui está sendo usado para fazer o Break da gravação de forma que seja possível alterar a tecla responsável por isso. 
    Private Sub KeyboardRecorder_KeyDown(Key As Keys) Handles KeyboardRecorder.KeyDown

        If Key = Keys.Pause Then 'Estou usando a tecla 'Pause' do teclado neste caso

            BtnRecord.Enabled = True
            BtnStop.Enabled = False
            BtnPlayback.Enabled = True

            StopRecording()

        End If

        Debug.Print(String.Format("{0} - Tecla {1} Pressionada", Now, Key.ToString())) 'Também possível fazer Log da ação

    End Sub

    'Função comentada por questões de visualização mais clean no Debug
    'Private Sub KeyboardRecorder_KeyUp(Key As Keys) Handles KeyboardRecorder.KeyUp
    'Debug.Print(String.Format("{0} - Tecla {1} Solta", Now, Key.ToString()))
    'End Sub

    'Log da ação do usuário ao apertar o botão esquerdo do mouse
    Private Sub MouseRecorder_MouseLDown() Handles MouseRecorder.MouseLDown
        Debug.Print(String.Format("{0} - Botão Esquerdo do Mouse Pressionado", Now))
    End Sub

    'Log da ação do usuário ao soltar o botão esquerdo do mouse
    Private Sub MouseRecorder_MouseLUp() Handles MouseRecorder.MouseLUp
        Debug.Print(String.Format("{0} - Botão Esquerdo do Mouse Solto", Now))
    End Sub

    'Log da ação do usuário ao apertar o botão direito do mouse
    Private Sub MouseRecorder_MouseRDown() Handles MouseRecorder.MouseRDown
        Debug.Print(String.Format("{0} - Botão Direito do Mouse Pressionado", Now))
    End Sub

    'Log da ação do usuário ao soltar o botão direito do mouse
    Private Sub MouseRecorder_MouseRUp() Handles MouseRecorder.MouseRUp
        Debug.Print(String.Format("{0} - Botão Direito do Mouse Solto", Now))
    End Sub

#End Region

End Class
