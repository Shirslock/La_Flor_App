<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrincipal
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MiCuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSesionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionarProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MiCuentaToolStripMenuItem, Me.GestionarProductosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MiCuentaToolStripMenuItem
        '
        Me.MiCuentaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarSesionToolStripMenuItem})
        Me.MiCuentaToolStripMenuItem.Name = "MiCuentaToolStripMenuItem"
        Me.MiCuentaToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.MiCuentaToolStripMenuItem.Text = "Mi Cuenta"
        '
        'CerrarSesionToolStripMenuItem
        '
        Me.CerrarSesionToolStripMenuItem.Name = "CerrarSesionToolStripMenuItem"
        Me.CerrarSesionToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.CerrarSesionToolStripMenuItem.Text = "Cerrar Sesion"
        '
        'GestionarProductosToolStripMenuItem
        '
        Me.GestionarProductosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerProductosToolStripMenuItem})
        Me.GestionarProductosToolStripMenuItem.Name = "GestionarProductosToolStripMenuItem"
        Me.GestionarProductosToolStripMenuItem.Size = New System.Drawing.Size(126, 20)
        Me.GestionarProductosToolStripMenuItem.Text = "Gestionar Productos"
        '
        'VerProductosToolStripMenuItem
        '
        Me.VerProductosToolStripMenuItem.Name = "VerProductosToolStripMenuItem"
        Me.VerProductosToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.VerProductosToolStripMenuItem.Text = "Ver Productos"
        '
        'FormPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormPrincipal"
        Me.Text = "FormPrincipal"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MiCuentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CerrarSesionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GestionarProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerProductosToolStripMenuItem As ToolStripMenuItem
End Class
