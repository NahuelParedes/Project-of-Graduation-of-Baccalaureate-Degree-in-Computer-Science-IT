<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeProfesor
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HomeProfesor))
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMinimizar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtciAlumno = New System.Windows.Forms.TextBox()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.dtpfechNota = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbxTipoNota = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.comboGrupo = New System.Windows.Forms.ComboBox()
        Me.BtnAlumnos = New System.Windows.Forms.Button()
        Me.dgvAlumnosProfe = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnModificarInstituto = New System.Windows.Forms.Button()
        Me.BtnBajaInstituto = New System.Windows.Forms.Button()
        Me.btnCargarDatosInstituto = New System.Windows.Forms.Button()
        Me.btnNuevoInstituto = New System.Windows.Forms.Button()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbInstituto = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbTipoTarea = New System.Windows.Forms.ComboBox()
        Me.PanelTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAlumnosProfe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.PictureBox1)
        Me.PanelTop.Controls.Add(Me.Label1)
        Me.PanelTop.Controls.Add(Me.btnMinimizar)
        Me.PanelTop.Controls.Add(Me.btnCerrar)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1284, 54)
        Me.PanelTop.TabIndex = 7
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ProyectoPrueba.My.Resources.Resources.profesoresIcon
        Me.PictureBox1.Location = New System.Drawing.Point(500, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(53, 48)
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
        Me.Label1.Location = New System.Drawing.Point(559, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 30)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Profesores"
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
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Image = Global.ProyectoPrueba.My.Resources.Resources.Icono_cerrar_FN
        Me.btnCerrar.Location = New System.Drawing.Point(1228, 0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(40, 54)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.Location = New System.Drawing.Point(16, 304)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 21)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Ingrese nota:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label3.Location = New System.Drawing.Point(5, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(188, 21)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Ingrese CI del alumno: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label2.Location = New System.Drawing.Point(7, 197)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 21)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Ingrese fecha:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtciAlumno
        '
        Me.txtciAlumno.Location = New System.Drawing.Point(200, 152)
        Me.txtciAlumno.Name = "txtciAlumno"
        Me.txtciAlumno.Size = New System.Drawing.Size(178, 20)
        Me.txtciAlumno.TabIndex = 21
        '
        'txtNota
        '
        Me.txtNota.Location = New System.Drawing.Point(145, 307)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(40, 20)
        Me.txtNota.TabIndex = 22
        '
        'dtpfechNota
        '
        Me.dtpfechNota.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpfechNota.Location = New System.Drawing.Point(135, 197)
        Me.dtpfechNota.Name = "dtpfechNota"
        Me.dtpfechNota.Size = New System.Drawing.Size(200, 20)
        Me.dtpfechNota.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(12, 258)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(113, 21)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Tipo de nota:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbxTipoNota
        '
        Me.cbxTipoNota.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbxTipoNota.FormattingEnabled = True
        Me.cbxTipoNota.Location = New System.Drawing.Point(145, 260)
        Me.cbxTipoNota.Name = "cbxTipoNota"
        Me.cbxTipoNota.Size = New System.Drawing.Size(106, 21)
        Me.cbxTipoNota.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.Location = New System.Drawing.Point(403, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(262, 42)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Seleccione el instituto y el grupo," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " para mostrar los alumnos"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'comboGrupo
        '
        Me.comboGrupo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.comboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboGrupo.FormattingEnabled = True
        Me.comboGrupo.Location = New System.Drawing.Point(766, 105)
        Me.comboGrupo.Name = "comboGrupo"
        Me.comboGrupo.Size = New System.Drawing.Size(169, 21)
        Me.comboGrupo.TabIndex = 28
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
        Me.BtnAlumnos.Location = New System.Drawing.Point(0, 0)
        Me.BtnAlumnos.Name = "BtnAlumnos"
        Me.BtnAlumnos.Size = New System.Drawing.Size(60, 75)
        Me.BtnAlumnos.TabIndex = 39
        Me.BtnAlumnos.UseVisualStyleBackColor = False
        '
        'dgvAlumnosProfe
        '
        Me.dgvAlumnosProfe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAlumnosProfe.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvAlumnosProfe.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.dgvAlumnosProfe.CausesValidation = False
        Me.dgvAlumnosProfe.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgvAlumnosProfe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAlumnosProfe.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAlumnosProfe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlumnosProfe.EnableHeadersVisualStyles = False
        Me.dgvAlumnosProfe.GridColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.dgvAlumnosProfe.Location = New System.Drawing.Point(391, 152)
        Me.dgvAlumnosProfe.Name = "dgvAlumnosProfe"
        Me.dgvAlumnosProfe.ReadOnly = True
        Me.dgvAlumnosProfe.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvAlumnosProfe.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAlumnosProfe.RowHeadersVisible = False
        Me.dgvAlumnosProfe.RowHeadersWidth = 30
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(91, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray
        Me.dgvAlumnosProfe.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAlumnosProfe.Size = New System.Drawing.Size(889, 407)
        Me.dgvAlumnosProfe.TabIndex = 62
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.Panel2.Controls.Add(Me.BtnAlumnos)
        Me.Panel2.Controls.Add(Me.BtnModificarInstituto)
        Me.Panel2.Controls.Add(Me.BtnBajaInstituto)
        Me.Panel2.Controls.Add(Me.btnCargarDatosInstituto)
        Me.Panel2.Controls.Add(Me.btnNuevoInstituto)
        Me.Panel2.Controls.Add(Me.ShapeContainer2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 562)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1284, 75)
        Me.Panel2.TabIndex = 68
        '
        'BtnModificarInstituto
        '
        Me.BtnModificarInstituto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.BtnModificarInstituto.BackColor = System.Drawing.Color.Transparent
        Me.BtnModificarInstituto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnModificarInstituto.FlatAppearance.BorderSize = 0
        Me.BtnModificarInstituto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnModificarInstituto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed
        Me.BtnModificarInstituto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnModificarInstituto.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnModificarInstituto.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnModificarInstituto.Image = Global.ProyectoPrueba.My.Resources.Resources.Editar_50x50
        Me.BtnModificarInstituto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnModificarInstituto.Location = New System.Drawing.Point(863, 2)
        Me.BtnModificarInstituto.Name = "BtnModificarInstituto"
        Me.BtnModificarInstituto.Size = New System.Drawing.Size(195, 70)
        Me.BtnModificarInstituto.TabIndex = 34
        Me.BtnModificarInstituto.Text = "Modificar Nota"
        Me.BtnModificarInstituto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnModificarInstituto.UseVisualStyleBackColor = False
        '
        'BtnBajaInstituto
        '
        Me.BtnBajaInstituto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.BtnBajaInstituto.BackColor = System.Drawing.Color.Transparent
        Me.BtnBajaInstituto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBajaInstituto.FlatAppearance.BorderSize = 0
        Me.BtnBajaInstituto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnBajaInstituto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed
        Me.BtnBajaInstituto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBajaInstituto.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBajaInstituto.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnBajaInstituto.Image = Global.ProyectoPrueba.My.Resources.Resources.Baja_50x50
        Me.BtnBajaInstituto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBajaInstituto.Location = New System.Drawing.Point(360, 0)
        Me.BtnBajaInstituto.Name = "BtnBajaInstituto"
        Me.BtnBajaInstituto.Size = New System.Drawing.Size(215, 71)
        Me.BtnBajaInstituto.TabIndex = 33
        Me.BtnBajaInstituto.Text = "Dar de baja Nota"
        Me.BtnBajaInstituto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBajaInstituto.UseVisualStyleBackColor = False
        '
        'btnCargarDatosInstituto
        '
        Me.btnCargarDatosInstituto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnCargarDatosInstituto.BackColor = System.Drawing.Color.Transparent
        Me.btnCargarDatosInstituto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCargarDatosInstituto.FlatAppearance.BorderSize = 0
        Me.btnCargarDatosInstituto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnCargarDatosInstituto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed
        Me.btnCargarDatosInstituto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCargarDatosInstituto.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargarDatosInstituto.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCargarDatosInstituto.Image = Global.ProyectoPrueba.My.Resources.Resources.Editar_50x50
        Me.btnCargarDatosInstituto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargarDatosInstituto.Location = New System.Drawing.Point(621, 3)
        Me.btnCargarDatosInstituto.Name = "btnCargarDatosInstituto"
        Me.btnCargarDatosInstituto.Size = New System.Drawing.Size(232, 70)
        Me.btnCargarDatosInstituto.TabIndex = 32
        Me.btnCargarDatosInstituto.Text = "Cargar Datos Nota"
        Me.btnCargarDatosInstituto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCargarDatosInstituto.UseVisualStyleBackColor = False
        '
        'btnNuevoInstituto
        '
        Me.btnNuevoInstituto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnNuevoInstituto.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevoInstituto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevoInstituto.FlatAppearance.BorderSize = 0
        Me.btnNuevoInstituto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnNuevoInstituto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed
        Me.btnNuevoInstituto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevoInstituto.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoInstituto.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnNuevoInstituto.Image = Global.ProyectoPrueba.My.Resources.Resources.Agregar_50x50
        Me.btnNuevoInstituto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoInstituto.Location = New System.Drawing.Point(151, 4)
        Me.btnNuevoInstituto.Name = "btnNuevoInstituto"
        Me.btnNuevoInstituto.Size = New System.Drawing.Size(183, 70)
        Me.btnNuevoInstituto.TabIndex = 6
        Me.btnNuevoInstituto.Text = "Ingresar Nota"
        Me.btnNuevoInstituto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevoInstituto.UseVisualStyleBackColor = False
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape6, Me.LineShape5, Me.LineShape4, Me.LineShape3, Me.LineShape2})
        Me.ShapeContainer2.Size = New System.Drawing.Size(1284, 75)
        Me.ShapeContainer2.TabIndex = 35
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape6
        '
        Me.LineShape6.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.LineShape6.Name = "LineShape6"
        Me.LineShape6.X1 = 138
        Me.LineShape6.X2 = 138
        Me.LineShape6.Y1 = 67
        Me.LineShape6.Y2 = 7
        '
        'LineShape5
        '
        Me.LineShape5.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.LineShape5.Name = "LineShape5"
        Me.LineShape5.X1 = 1069
        Me.LineShape5.X2 = 1069
        Me.LineShape5.Y1 = 68
        Me.LineShape5.Y2 = 8
        '
        'LineShape4
        '
        Me.LineShape4.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 857
        Me.LineShape4.X2 = 857
        Me.LineShape4.Y1 = 67
        Me.LineShape4.Y2 = 7
        '
        'LineShape3
        '
        Me.LineShape3.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 599
        Me.LineShape3.X2 = 599
        Me.LineShape3.Y1 = 66
        Me.LineShape3.Y2 = 6
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 345
        Me.LineShape2.X2 = 345
        Me.LineShape2.Y1 = 67
        Me.LineShape2.Y2 = 7
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.Location = New System.Drawing.Point(685, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 21)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Instituto"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.Location = New System.Drawing.Point(685, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 21)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "Grupo"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbInstituto
        '
        Me.cbInstituto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbInstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInstituto.FormattingEnabled = True
        Me.cbInstituto.Location = New System.Drawing.Point(766, 70)
        Me.cbInstituto.Name = "cbInstituto"
        Me.cbInstituto.Size = New System.Drawing.Size(169, 21)
        Me.cbInstituto.TabIndex = 71
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(271, 460)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 72
        Me.Button1.Text = "AAAAAAAAA"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 945
        Me.LineShape1.X2 = 945
        Me.LineShape1.Y1 = 133
        Me.LineShape1.Y2 = 59
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1284, 637)
        Me.ShapeContainer1.TabIndex = 73
        Me.ShapeContainer1.TabStop = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.Location = New System.Drawing.Point(1052, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 21)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "Filtrar Por"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label10.Location = New System.Drawing.Point(951, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 21)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "Tipo de tarea:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbTipoTarea
        '
        Me.cbTipoTarea.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbTipoTarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoTarea.FormattingEnabled = True
        Me.cbTipoTarea.Location = New System.Drawing.Point(1072, 98)
        Me.cbTipoTarea.Name = "cbTipoTarea"
        Me.cbTipoTarea.Size = New System.Drawing.Size(169, 21)
        Me.cbTipoTarea.TabIndex = 75
        '
        'HomeProfesor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(1284, 637)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbTipoTarea)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbInstituto)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgvAlumnosProfe)
        Me.Controls.Add(Me.comboGrupo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbxTipoNota)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpfechNota)
        Me.Controls.Add(Me.txtNota)
        Me.Controls.Add(Me.txtciAlumno)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HomeProfesor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HomeProfesor"
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAlumnosProfe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelTop As Panel
    Friend WithEvents btnMinimizar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtciAlumno As TextBox
    Friend WithEvents txtNota As TextBox
    Friend WithEvents dtpfechNota As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents cbxTipoNota As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents comboGrupo As ComboBox
    Friend WithEvents BtnAlumnos As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvAlumnosProfe As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnModificarInstituto As Button
    Friend WithEvents BtnBajaInstituto As Button
    Friend WithEvents btnCargarDatosInstituto As Button
    Friend WithEvents btnNuevoInstituto As Button
    Friend WithEvents ShapeContainer2 As PowerPacks.ShapeContainer
    Friend WithEvents LineShape6 As PowerPacks.LineShape
    Friend WithEvents LineShape5 As PowerPacks.LineShape
    Friend WithEvents LineShape4 As PowerPacks.LineShape
    Friend WithEvents LineShape3 As PowerPacks.LineShape
    Friend WithEvents LineShape2 As PowerPacks.LineShape
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cbInstituto As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents LineShape1 As PowerPacks.LineShape
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cbTipoTarea As ComboBox
End Class
