<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGeral
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGeral))
        Me.BtnRecord = New System.Windows.Forms.Button()
        Me.BtnPlayback = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.TmrRecord = New System.Windows.Forms.Timer(Me.components)
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.Fbd1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Ofd1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'BtnRecord
        '
        Me.BtnRecord.Image = CType(resources.GetObject("BtnRecord.Image"), System.Drawing.Image)
        Me.BtnRecord.Location = New System.Drawing.Point(12, 12)
        Me.BtnRecord.Name = "BtnRecord"
        Me.BtnRecord.Size = New System.Drawing.Size(132, 104)
        Me.BtnRecord.TabIndex = 0
        Me.BtnRecord.UseVisualStyleBackColor = True
        '
        'BtnPlayback
        '
        Me.BtnPlayback.Image = CType(resources.GetObject("BtnPlayback.Image"), System.Drawing.Image)
        Me.BtnPlayback.Location = New System.Drawing.Point(288, 12)
        Me.BtnPlayback.Name = "BtnPlayback"
        Me.BtnPlayback.Size = New System.Drawing.Size(132, 104)
        Me.BtnPlayback.TabIndex = 1
        Me.BtnPlayback.UseVisualStyleBackColor = True
        '
        'BtnStop
        '
        Me.BtnStop.Enabled = False
        Me.BtnStop.Image = CType(resources.GetObject("BtnStop.Image"), System.Drawing.Image)
        Me.BtnStop.Location = New System.Drawing.Point(150, 12)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(132, 104)
        Me.BtnStop.TabIndex = 2
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'TmrRecord
        '
        Me.TmrRecord.Interval = 1000
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.Location = New System.Drawing.Point(12, 128)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(190, 13)
        Me.lblRecord.TabIndex = 3
        Me.lblRecord.Text = "A gravação começará em 0 segundos."
        Me.lblRecord.Visible = False
        '
        'FrmGeral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 158)
        Me.Controls.Add(Me.lblRecord)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.BtnPlayback)
        Me.Controls.Add(Me.BtnRecord)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmGeral"
        Me.Text = "Mister Hook"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnRecord As Button
    Friend WithEvents BtnPlayback As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents TmrRecord As Timer
    Friend WithEvents lblRecord As Label
    Friend WithEvents Fbd1 As FolderBrowserDialog
    Friend WithEvents Ofd1 As OpenFileDialog
End Class
