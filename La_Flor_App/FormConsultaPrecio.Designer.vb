<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConsultaPrecio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConsultaPrecio))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvConsultarPrecio = New System.Windows.Forms.DataGridView()
        Me.btnModificarPrecio = New System.Windows.Forms.Button()
        Me.btnConsultarPrecio = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtPrecioNuevo = New System.Windows.Forms.TextBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvConsultarPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(795, 51)
        Me.Panel1.TabIndex = 0
        '
        'dgvConsultarPrecio
        '
        Me.dgvConsultarPrecio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsultarPrecio.Location = New System.Drawing.Point(12, 76)
        Me.dgvConsultarPrecio.Name = "dgvConsultarPrecio"
        Me.dgvConsultarPrecio.RowTemplate.Height = 25
        Me.dgvConsultarPrecio.Size = New System.Drawing.Size(243, 214)
        Me.dgvConsultarPrecio.TabIndex = 1
        '
        'btnModificarPrecio
        '
        Me.btnModificarPrecio.Location = New System.Drawing.Point(13, 345)
        Me.btnModificarPrecio.Name = "btnModificarPrecio"
        Me.btnModificarPrecio.Size = New System.Drawing.Size(106, 23)
        Me.btnModificarPrecio.TabIndex = 2
        Me.btnModificarPrecio.Text = "Modificar Precio"
        Me.btnModificarPrecio.UseVisualStyleBackColor = True
        '
        'btnConsultarPrecio
        '
        Me.btnConsultarPrecio.Location = New System.Drawing.Point(12, 296)
        Me.btnConsultarPrecio.Name = "btnConsultarPrecio"
        Me.btnConsultarPrecio.Size = New System.Drawing.Size(107, 23)
        Me.btnConsultarPrecio.TabIndex = 3
        Me.btnConsultarPrecio.Text = "Consultar Precio"
        Me.btnConsultarPrecio.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 415)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Salir"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Location = New System.Drawing.Point(332, 53)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(466, 405)
        Me.Panel3.TabIndex = 5
        '
        'txtPrecioNuevo
        '
        Me.txtPrecioNuevo.Location = New System.Drawing.Point(125, 345)
        Me.txtPrecioNuevo.Name = "txtPrecioNuevo"
        Me.txtPrecioNuevo.Size = New System.Drawing.Size(114, 23)
        Me.txtPrecioNuevo.TabIndex = 6
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(245, 344)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(38, 23)
        Me.btnOk.TabIndex = 7
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(281, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 27)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "CONSULTA DE PRECIOS"
        '
        'FormConsultaPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.txtPrecioNuevo)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnConsultarPrecio)
        Me.Controls.Add(Me.btnModificarPrecio)
        Me.Controls.Add(Me.dgvConsultarPrecio)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormConsultaPrecio"
        Me.Text = "FormConsultaPrecio"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvConsultarPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvConsultarPrecio As DataGridView
    Friend WithEvents btnModificarPrecio As Button
    Friend WithEvents btnConsultarPrecio As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtPrecioNuevo As TextBox
    Friend WithEvents btnOk As Button
    Friend WithEvents Label1 As Label
End Class
