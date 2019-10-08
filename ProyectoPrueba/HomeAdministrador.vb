Imports System.Data.Odbc
Imports System.Text.RegularExpressions


Public Class HomeAdministrador
    Dim conexion As New Odbc.OdbcConnection
    Dim comando As New Odbc.OdbcCommand
    Dim read As OdbcDataReader

    Dim dataadapter As New Odbc.OdbcDataAdapter
    Dim dataset As New Data.DataSet
    Public validacionMAIL As Boolean = False ' Valida que el email fue ingresado correctamente.
    Public CorrOtroTel As Boolean = False ' Para corroborar si agrega un telefono secundario en alumnos
    Public CorrOtroTelProf As Boolean = False ' Para corroborar si agrega un telefono secundario en profes


    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub BtnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PanelMenu_MouseMove(sender As Object, e As MouseEventArgs)
        ReleaseCapture() ' LLAMAS A LA FUNCION PARA MOVER LA VENTANA CUANDO CLICKEE SOBRE UN OBJETO
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs)
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click        ' boton cerrar en panel notas

        Cambiarcerrar(PanelNotas)
        DesblockBotones(BtnNotas)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCerrarPanelA.Click ' boton cerrar del alumno
        Cambiarcerrar(PanelAlumnos) ' Llama al metodo para cerrar el panel de los alumnos.
        DesblockBotones(BtnAlumnos)
        LimpiarTextBox(PanelAlumnos) ' Llama al metodo para limpiar los textbox cuando cierra el panel de los alumnos.
        lblEmailError.Visible = False


        cbDepartamento.SelectedIndex = -1
        cbSexo.SelectedIndex = -1


    End Sub

    Private Sub BtnAlumnos_Click(sender As Object, e As EventArgs) Handles BtnAlumnos.Click  ' click en elboton alumnos del panel de la izquierda

        BlockBotones(BtnAlumnos)

        txtCi.Focus()
        MoverPaneles(PanelAlumnos)







    End Sub

    Private Sub BtnNotas_Click(sender As Object, e As EventArgs) Handles BtnNotas.Click  ' click en el boton notas del panel de la izquierda
        BlockBotones(BtnNotas)

        MoverPaneles(PanelNotas)


        txtCiProf.Focus()

    End Sub

    Private Sub BtnProfesores_Click(sender As Object, e As EventArgs) Handles BtnProfesores.Click ' BTN PROFESOR 
        BlockBotones(BtnProfesores)


        CargarComboDep(cbDepInsProf)
        MoverPaneles(PanelProfesores)

        txtCiProf.Focus()




    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click ' BOTON CERRAR DE LOS PROFESORES
        Cambiarcerrar(PanelProfesores)
        DesblockBotones(BtnProfesores)


        cbMatProf.SelectedIndex = -1
        cbGrupoProf.SelectedIndex = -1
        cbGrupoProf.SelectedIndex = -1
        cbDepartamento.SelectedIndex = -1
        cbSexoProf.SelectedIndex = -1
        cbDepaProf.SelectedIndex = -1




    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click ' btn cerrar del panel grupos
        Cambiarcerrar(PanelGrupos)
        DesblockBotones(BtnGrupos)
        LimpiarTextBox(PanelGrupos) ' Llama al metodo para limpiar los textbox cuando cierra el panel de los grupos.




    End Sub

    Private Sub BtnGrupos_Click(sender As Object, e As EventArgs) Handles BtnGrupos.Click ' click en el boton grupos de la izquierda
        BlockBotones(BtnGrupos)

        CargarComboDep(cbDepInsGrupos)
        MoverPaneles(PanelGrupos)

        txtNombreGrupo.Focus()




    End Sub

    Private Sub BtnInstitutos_Click(sender As Object, e As EventArgs) Handles BtnInstitutos.Click ' CLICK EN EL BOTON INSTITUTOS
        BlockBotones(BtnInstitutos)


        MoverPaneles(PanelInstitutos)
        txtNombreInstituto.Focus()


        Dim consulta As String = "select i.id_instituto, i.nombre_instituto, i.departamento, t.telefono, i.mail, i.direccion FROM instituto i, telefono_instituto t WHERE t.id_instituto = i.id_instituto AND i.estado_instituto = 't'"

        LlenarDgv(consulta, dgvInstitutos)




    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click ' btn cerrar de instituto
        Cambiarcerrar(PanelInstitutos)
        DesblockBotones(BtnInstitutos)
        LimpiarTextBox(PanelInstitutos)
        lblEmailErrorIns.Visible = False
        cbDepartamentoIns.SelectedIndex = -1

    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs)
        Me.Close()
        Login.Show()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If MsgBox("¿Esta seguro que desea salir?", MsgBoxStyle.YesNo, "Confirmación de salida.") = MsgBoxResult.Yes Then

            ' cerrar la conexion
            Application.Exit()

        End If
    End Sub

    Private Sub PanelHome_MouseDown(sender As Object, e As MouseEventArgs) Handles TxtSeleccion.MouseDown, PanelTop.MouseDown, PanelMenu.MouseDown, PanelHome.MouseDown, Label1.MouseDown, Icon3NM.MouseDown
        ' LLAMAMOS AL METODO  DE ARRASTRAR LA VENTANA
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)

    End Sub

    Private Sub btnMaterias_Click(sender As Object, e As EventArgs) Handles btnMaterias.Click ' CLICK EN EL BOTON MATERIAS 
        BlockBotones(btnMaterias)


        MoverPaneles(PanelMaterias)


    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click ' click en el boton cerrar panel materias
        Cambiarcerrar(PanelMaterias)
        DesblockBotones(btnMaterias)
        LimpiarTextBox(PanelMaterias)
        cbDepartamentoIns.SelectedIndex = -1

    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Me.Close()
        Login.Show()

        Cambiarcerrar(PanelAlumnos)
        Cambiarcerrar(PanelGrupos)
        Cambiarcerrar(PanelInstitutos)
        Cambiarcerrar(PanelMaterias)
        Cambiarcerrar(PanelProfesores)
        Cambiarcerrar(PanelNotas)

    End Sub




    Private Sub HomeAdministrador_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        'dgvAlumnos.Columns.Item("Materias").Visible = False






    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress, txtApellido.KeyPress, cbSexo.KeyPress, cbDepartamento.KeyPress ' Control de Objetos que solo ingrese letras del Panel Alumnos.
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        Dim numbers As Windows.Forms.TextBox = sender
        If InStr("1234567890.()-+ ", e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Or (e.KeyChar = "." And InStr(numbers.Text, ".") > 0) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        If Not e.KeyChar.ToString() Like "[a-zA-Z0-9 ]" And Asc(e.KeyChar) <> 8 Then ' Validar que ingrese solo numeros o letras para la direccion.
            e.KeyChar = Chr(0)
            e.Handled = True
        End If
    End Sub

    Private Sub txtEmail_MouseLeave(sender As Object, e As EventArgs) Handles txtEmail.MouseLeave
        If txtEmail.Text = "" Then
            lblEmailError.Visible = False
            validacionMAIL = True
        Else

            If validar_Mail(LCase(txtEmail.Text)) = False Then
                lblEmailError.Visible = True

            Else

                validacionMAIL = True

                lblEmailError.Visible = False

            End If

        End If


    End Sub



    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        AsignarMateriaGrupo()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim consulta As String = "SELECT * FROM materia"
        NuevaMateria()
        LlenarDgv(consulta, dgvMaterias)
        lblMaterias.Text = "MATERIAS"


    End Sub

    Private Sub TextBox13_MouseLeave(sender As Object, e As EventArgs) Handles txtEmailIns.MouseLeave

        If txtEmailIns.Text = "" Then

            validacionMAIL = True

        Else

            If validar_Mail(LCase(txtEmailIns.Text)) = False Then
                lblEmailErrorIns.Visible = True

            Else

                validacionMAIL = True

                lblEmailErrorIns.Visible = False

            End If

        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles btnNuevoInstituto.Click
        NuevoInstituto()
        LimpiarTextBox(PanelInstitutos)

    End Sub


    Private Sub cbInsAlumno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbInsAlumno.SelectedIndexChanged
        CargarGrupoSegunInstitutoYDep(cbGrupoAlum, cbInsAlumno, cbDepInsAlum)
    End Sub

    Private Sub cbGrupoAlum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGrupoAlum.SelectedIndexChanged

        Dim consulta As String = "SELECT DISTINCT a.nro_lista, p.ci, p.nombre, p.apellido, p.telefono, p.telefono_sec, p.fch_nac, p.sexo, p.direccion, p.mail, p.departamento  FROM persona p INNER JOIN alumno k ON p.ci = k.ci INNER JOIN asiste a ON k.id_alumno = a.id_alumno INNER JOIN grupo g ON a.id_grupo = g.id_grupo INNER JOIN instituto i ON i.id_instituto = g.id_instituto WHERE g.nombre_grupo = " & Chr(34) & cbGrupoAlum.Text & Chr(34) & " AND i.nombre_instituto = " & Chr(34) & cbInsAlumno.Text & Chr(34) & " AND a.estado_asiste = 't' AND i.departamento = " & Chr(34) & cbDepInsAlum.Text & Chr(34) & ""
        LlenarDgv(consulta, dgvAlumnos)
        lblAlumnos.Text = "Alumnos: " & dgvAlumnos.Rows.Count - 1
        lblGrupo.Text = "Grupo: " & cbGrupoAlum.Text

        Dim consulta2 As String = "select m.nombre_materia from materia m, tiene t INNER JOIN grupo g ON t.id_grupo = g.id_grupo INNER JOIN instituto i ON i.id_instituto = g.id_instituto  WHERE t.id_materia = m.id_materia AND g.nombre_grupo = " & Chr(34) & cbGrupoAlum.Text & Chr(34) & " AND i.nombre_instituto = " & Chr(34) & cbInsAlumno.Text & Chr(34) & " AND i.departamento = " & Chr(34) & cbDepInsAlum.Text & Chr(34) & " AND m.estado_materia = 't'"

        Dim tabla = "nombre_materia"
        cargarcheckListMaterias(consulta2, CheckedListBox1, tabla)


    End Sub

    Private Sub cbInstituto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbInstitutoGrupos.SelectedIndexChanged
        Dim consulta As String = "SELECT g.id_grupo, g.nombre_grupo, g.orientacion, g.turno, g.ano_lectivo FROM grupo g JOIN instituto i ON i.id_instituto = g.id_instituto WHERE i.nombre_instituto = " & Chr(34) & cbInstitutoGrupos.Text & Chr(34) & "AND i.departamento = " & Chr(34) & cbDepInsGrupos.Text & Chr(34) & " AND g.estado_grupo = 't'"
        LlenarDgv(consulta, dgvGrupos)
        lblGrupos.Text = "Grupos: " & dgvGrupos.Rows.Count - 1
        lblInstituto.Text = "Instituto: " & cbInstitutoGrupos.Text
    End Sub

    Private Sub cbGrupoPMaterias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGrupoPMaterias.SelectedIndexChanged
        Dim consulta As String = "SELECT g.nombre_grupo, m.nombre_materia, t.dia, t.hora_inicio, t.hora_fin FROM grupo g INNER JOIN tiene t ON g.id_grupo = t.id_grupo INNER JOIN materia m ON m.id_materia = t.id_materia INNER JOIN instituto i ON g.id_instituto = i.id_instituto WHERE g.nombre_grupo = " & Chr(34) & cbGrupoPMaterias.Text & Chr(34) & " AND g.estado_grupo = 't' AND i.nombre_instituto = " & Chr(34) & cbInsMaterias.Text & Chr(34) & " AND  i.departamento = " & Chr(34) & cbDepInstitutoMaterias.Text & Chr(34) & ""
        LlenarDgv(consulta, dgvMaterias)
        lblMaterias.Text = "Materias del Grupo " & cbGrupoPMaterias.Text & ""


    End Sub


    Private Sub btnCargarDatosInstituto_Click(sender As Object, e As EventArgs) Handles btnCargarDatosInstituto.Click
        CargarDatosInstituto()
    End Sub

    Private Sub BtnModificarInstituto_Click(sender As Object, e As EventArgs) Handles BtnModificarInstituto.Click
        ModificarInstituto()



    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click

        añadirgrupos()

        LimpiarTextBox(PanelGrupos)
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        CargarDatosGrupo()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        ModificarGrupo()
        Dim consulta As String = "SELECT g.id_grupo, g.nombre_grupo, g.orientacion, g.turno, g.ano_lectivo FROM grupo g JOIN instituto i ON i.id_instituto = g.id_instituto WHERE i.nombre_instituto = " & Chr(34) & cbInstitutoGrupos.Text & Chr(34) & " AND i.departamento = " & Chr(34) & cbDepInsGrupos.Text & Chr(34) & " AND g.estado_grupo = 't'"

        LlenarDgv(consulta, dgvGrupos)
        lblGrupos.Text = "Grupos: " & dgvGrupos.Rows.Count - 1
        lblInstituto.Text = "Instituto: " & cbInstitutoGrupos.Text
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        NuevoAlumno()

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        CargarDatosAlumno()

    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click


        Try

            Dim s As DataTable = Execute("SELECT telefono FROM telefono_persona WHERE ci = " & Chr(34) & txtCi.Text & Chr(34))

            If s.Rows.Count = 1 Then  ' Si el data reader tiene filas (datos)----
                MsgBox("Tiene un tel")

            ElseIf s.Rows.Count = 2 Then
                MsgBox("Tiene mas de uno")

            End If


        Catch ex As Exception
            MsgBox("Error N°XXX al modificar el telefono de un alumno" + ex.Message)
        End Try








        '        '' LO INGRESAMOS A UN GRUPO y A UNA MATERIA
        '        Dim consulta As String = "SELECT a.id_alumno FROM asiste a INNER JOIN grupo g ON a.id_grupo = g.id_grupo INNER JOIN 
        'materia m ON a.id_materia = m.id_materia INNER JOIN instituto i ON i.id_instituto = g.id_instituto WHERE
        ' i.nombre_instituto = 'ITS' AND i.departamento = 'Montevideo' AND g.nombre_grupo = '3XI'  AND m.nombre_materia = 'Matematica Super Avanzada'"


        '        Execute(consulta)

        '        For Each alumnos In dt.Rows

        '            Dim result = Convert.ToInt32(alumnos("id_alumno"))
        '            MsgBox(result)

        '        Next


        '        'Dim consulta2 As String = "select k.id_alumno FROM  alumno k  INNER JOIN persona p ON k.ci = p.ci INNER JOIN asiste a ON k.id_alumno = a.id_alumno  INNER JOIN materia m ON a.id_materia = m.id_materia INNER JOIN grupo g ON a.id_grupo = g.id_grupo INNER JOIN instituto i ON i.id_instituto = g.id_instituto WHERE m.nombre_materia = " & Chr(34) & cbMatProf.Text & Chr(34) & " AND g.nombre_grupo = " & Chr(34) & cbGrupoProf.Text & Chr(34) & " AND i.nombre_instituto = " & Chr(34) & cbInsProf.Text & Chr(34) & ""
        '        'Dim tabla = "id_alumno"

        '        'AsignarAlumnosConProfesor(consulta2, tabla)


    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        ModificarAlumno()


    End Sub

    Private Sub cbInsProf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbInsProf.SelectedIndexChanged
        CargarGrupoSegunInstitutoYDep(cbGrupoProf, cbInsProf, cbDepInsProf)
    End Sub

    Private Sub cbGrupoProf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGrupoProf.SelectedIndexChanged

        cargarMateriasProfesoSegunGrupoInsDep(cbMatProf, cbGrupoProf, cbInsProf, cbDepInsProf)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbInsMaterias.SelectedIndexChanged
        CargarGrupoSegunInstitutoYDep(cbGrupoPMaterias, cbInsMaterias, cbDepInstitutoMaterias)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim consulta As String = "SELECT nombre_materia FROM materia"
        LlenarDgv(consulta, dgvMaterias)
        lblMaterias.Text = "MATERIAS"
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
        'If checkMaterias.CheckState = CheckState.Checked Then

        '    dgvAlumnos.Columns.Item("Materias").Visible = True

        'Else

        '    dgvAlumnos.Columns.Item("Materias").Visible = False



        'End If
    End Sub

    Private Sub cbMatProf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMatProf.SelectedIndexChanged
        Dim consulta As String = "SELECT a.nro_lista, k.ci, p.nombre, p.apellido, p.telefono, p.telefono_sec, p.fch_nac, p.sexo, p.direccion, p.mail, p.departamento  FROM persona p INNER JOIN alumno k ON p.ci = k.ci INNER JOIN asiste a ON k.id_alumno = a.id_alumno INNER JOIN grupo g ON a.id_grupo = g.id_grupo INNER JOIN instituto i ON i.id_instituto = g.id_instituto INNER JOIN materia m ON a.id_materia = m.id_materia WHERE g.nombre_grupo = " & Chr(34) & cbGrupoProf.Text & Chr(34) & " AND i.nombre_instituto = " & Chr(34) & cbInsProf.Text & Chr(34) & " AND p.estado = 't' AND m.nombre_materia =" & Chr(34) & cbMatProf.Text & Chr(34) & " AND a.estado_asiste = 't'"
        LlenarDgv(consulta, dgvProf)

    End Sub


    Private Sub cbDepInstitutoMaterias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepInstitutoMaterias.SelectedIndexChanged

        cargarInstitutosSegunDep(cbInsMaterias, cbDepInstitutoMaterias)
    End Sub

    Private Sub btnHistorial_Click(sender As Object, e As EventArgs) Handles btnHistorial.Click
        Historial.Show()
        Me.Hide()

        Dim consulta As String = "SELECT * FROM historial"
        LlenarDgv(consulta, Historial.dgvHistorial)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbDepInsAlum.SelectedIndexChanged
        cargarInstitutosSegunDep(cbInsAlumno, cbDepInsAlum)
    End Sub

    Private Sub cbDepInsGrupos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepInsGrupos.SelectedIndexChanged
        If cbDepInsGrupos.Text = "" Then
        Else
            cargarInstitutosSegunDep(cbInstitutoGrupos, cbDepInsGrupos)
        End If

    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        CargarDatosMateriaAsignada()

    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        ModificarDatosMateriaAsignada()

    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        NuevoProfesor()
    End Sub

    Private Sub cbDepInsProf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepInsProf.SelectedIndexChanged
        cargarInstitutosSegunDep(cbInsProf, cbDepInsProf)
    End Sub

    Private Sub txtEmailProf_Leave(sender As Object, e As EventArgs) Handles txtEmailProf.Leave



        If txtEmailProf.Text = "" Then
            validacionMAIL = True
            lblErrorEmailProf.Visible = False
        Else

            If validar_Mail(LCase(txtEmailProf.Text)) = False Then
                lblErrorEmailProf.Visible = True

            Else

                validacionMAIL = True

                lblErrorEmailProf.Visible = False


            End If


        End If
    End Sub

    Private Sub btnOtroTel_Click(sender As Object, e As EventArgs) Handles btnOtroTelAgregar.Click
        txtTel2Al.Visible = True
        CorrOtroTel = True
        btnOtroTelAgregar.Visible = False
        btnOtroTelOcultar.Visible = True
        lblTelSec.Visible = True
    End Sub

    Private Sub btnOtroTelOcultar_Click(sender As Object, e As EventArgs) Handles btnOtroTelOcultar.Click
        txtTel2Al.Visible = False
        CorrOtroTel = False
        btnOtroTelAgregar.Visible = True
        btnOtroTelOcultar.Visible = False
        txtTel2Al.Clear()
        lblTelSec.Visible = False
    End Sub

    Private Sub txtTel2Al_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTel2Al.KeyPress
        Dim numbers As Windows.Forms.TextBox = sender
        If InStr("1234567890.()-+ ", e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Or (e.KeyChar = "." And InStr(numbers.Text, ".") > 0) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If
    End Sub

    Private Sub btnOtroTelMasProf_Click(sender As Object, e As EventArgs) Handles btnOtroTelMasProf.Click
        txtOtroTelProf.Visible = True
        CorrOtroTelProf = True
        btnOtroTelMasProf.Visible = False
        btnOtroTelProfMenos.Visible = True
        lblOtroTelProf.Visible = True
    End Sub

    Private Sub btnOtroTelProfMenos_Click(sender As Object, e As EventArgs) Handles btnOtroTelProfMenos.Click
        txtOtroTelProf.Visible = False
        CorrOtroTelProf = False
        btnOtroTelMasProf.Visible = True
        btnOtroTelProfMenos.Visible = False
        txtOtroTelProf.Clear()
        lblOtroTelProf.Visible = False
    End Sub

    Private Sub cbDepartamentoIns_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartamentoIns.SelectedIndexChanged
        Dim consulta As String = "SELECT * FROM instituto WHERE departamento = " & Chr(34) & cbDepartamentoIns.Text & Chr(34)
        LlenarDgv(consulta, dgvInstitutos)
        lblInstituto.Text = "Instituos del Departamento " & cbDepartamentoIns.Text
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click

    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click

    End Sub
End Class
