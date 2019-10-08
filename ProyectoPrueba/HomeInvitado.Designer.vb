<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeInvitado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HomeInvitado))
        Me.PanelTopInv = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMinimizar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.dgvNotas = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbFiltradoPorMateria = New System.Windows.Forms.ComboBox()
        Me.cbFiltradoPorNota = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFiltradoPorFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnAlumnos = New System.Windows.Forms.Button()
        Me.BtnActualizar = New System.Windows.Forms.Button()
        Me.PanelTopInv.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTopInv
        '
        Me.PanelTopInv.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.PanelTopInv.Controls.Add(Me.PictureBox1)
        Me.PanelTopInv.Controls.Add(Me.Label1)
        Me.PanelTopInv.Controls.Add(Me.btnMinimizar)
        Me.PanelTopInv.Controls.Add(Me.btnCerrar)
        Me.PanelTopInv.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTopInv.Location = New System.Drawing.Point(0, 0)
        Me.PanelTopInv.Name = "PanelTopInv"
        Me.PanelTopInv.Size = New System.Drawing.Size(1284, 54)
        Me.PanelTopInv.TabIndex = 7
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ProyectoPrueba.My.Resources.Resources.InvitadoBlanco
        Me.PictureBox1.Location = New System.Drawing.Point(530, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(56, 54)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(583, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 30)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Invitado"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnMinimizar
        '
        Me.btnMinimizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimizar.BackColor = System.Drawing.Color.Transparent
        Me.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMinimizar.FlatAppearance.BorderSize = 0
        Me.btnMinimizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnMinimizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray
        Me.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimizar.Image = Global.ProyectoPrueba.My.Resources.Resources.Icono_Minimizar
        Me.btnMinimizar.Location = New System.Drawing.Point(1157, 0)
        Me.btnMinimizar.Name = "btnMinimizar"
        Me.btnMinimizar.Size = New System.Drawing.Size(40, 54)
        Me.btnMinimizar.TabIndex = 2
        Me.btnMinimizar.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.Color.Transparent
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Image = Global.ProyectoPrueba.My.Resources.Resources.Icono_cerrar_FN
        Me.btnCerrar.Location = New System.Drawing.Point(1228, 0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(40, 54)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'dgvNotas
        '
        Me.dgvNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNotas.Location = New System.Drawing.Point(23, 91)
        Me.dgvNotas.Name = "dgvNotas"
        Me.dgvNotas.Size = New System.Drawing.Size(671, 461)
        Me.dgvNotas.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(794, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(259, 30)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Busqueda Avanzada"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Location = New System.Drawing.Point(729, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(164, 21)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Filtrado por Materia"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbFiltradoPorMateria
        '
        Me.cbFiltradoPorMateria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbFiltradoPorMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFiltradoPorMateria.FormattingEnabled = True
        Me.cbFiltradoPorMateria.Items.AddRange(New Object() {"1", "2", "3", "4", "6", "5"})
        Me.cbFiltradoPorMateria.Location = New System.Drawing.Point(940, 200)
        Me.cbFiltradoPorMateria.Name = "cbFiltradoPorMateria"
        Me.cbFiltradoPorMateria.Size = New System.Drawing.Size(146, 21)
        Me.cbFiltradoPorMateria.TabIndex = 14
        '
        'cbFiltradoPorNota
        '
        Me.cbFiltradoPorNota.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbFiltradoPorNota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFiltradoPorNota.FormattingEnabled = True
        Me.cbFiltradoPorNota.Location = New System.Drawing.Point(940, 281)
        Me.cbFiltradoPorNota.Name = "cbFiltradoPorNota"
        Me.cbFiltradoPorNota.Size = New System.Drawing.Size(146, 21)
        Me.cbFiltradoPorNota.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.Location = New System.Drawing.Point(738, 278)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 21)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Filtrado por Nota"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(729, 239)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(151, 21)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Filtrado por Fecha"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpFiltradoPorFecha
        '
        Me.dtpFiltradoPorFecha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpFiltradoPorFecha.Location = New System.Drawing.Point(940, 239)
        Me.dtpFiltradoPorFecha.Name = "dtpFiltradoPorFecha"
        Me.dtpFiltradoPorFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtpFiltradoPorFecha.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.Location = New System.Drawing.Point(306, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 30)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "NOTAS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnAlumnos
        '
        Me.BtnAlumnos.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAlumnos.BackColor = System.Drawing.Color.Transparent
        Me.BtnAlumnos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAlumnos.FlatAppearance.BorderSize = 0
        Me.BtnAlumnos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BtnAlumnos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BtnAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAlumnos.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAlumnos.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAlumnos.Image = Global.ProyectoPrueba.My.Resources.Resources.Atras_50x50
        Me.BtnAlumnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAlumnos.Location = New System.Drawing.Point(12, 574)
        Me.BtnAlumnos.Name = "BtnAlumnos"
        Me.BtnAlumnos.Size = New System.Drawing.Size(228, 51)
        Me.BtnAlumnos.TabIndex = 20
        Me.BtnAlumnos.Text = "Volver Atras"
        Me.BtnAlumnos.UseVisualStyleBackColor = False
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.BackColor = System.Drawing.Color.Transparent
        Me.BtnActualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnActualizar.FlatAppearance.BorderSize = 0
        Me.BtnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed
        Me.BtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnActualizar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActualizar.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnActualizar.Location = New System.Drawing.Point(934, 348)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(152, 60)
        Me.BtnActualizar.TabIndex = 10
        Me.BtnActualizar.Text = "Actualizar"
        Me.BtnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnActualizar.UseVisualStyleBackColor = False
        '
        'HomeInvitado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(1284, 637)
        Me.Controls.Add(Me.BtnAlumnos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpFiltradoPorFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbFiltradoPorNota)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbFiltradoPorMateria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvNotas)
        Me.Controls.Add(Me.PanelTopInv)
        Me.Controls.Add(Me.BtnActualizar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "HomeInvitado"
        Me.Text = "HomeInvitado"
        Me.PanelTopInv.ResumeLayout(False)
        Me.PanelTopInv.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelTopInv As Panel
    Friend WithEvents btnMinimizar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents BtnActualizar As Button
    Friend WithEvents dgvNotas As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbFiltradoPorMateria As ComboBox
    Friend WithEvents cbFiltradoPorNota As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpFiltradoPorFecha As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents BtnAlumnos As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
End Class
