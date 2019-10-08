

Public Class HomeProfesor

    Private Sub BtnAlumnos_Click(sender As Object, e As EventArgs) Handles BtnAlumnos.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub PanelTop_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelTop.MouseDown, MyBase.MouseDown, Label6.MouseDown, Label5.MouseDown, Label4.MouseDown, Label3.MouseDown, Label2.MouseDown

        ' llamamos a la funcion para mover el form como quieramos
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If MsgBox("¿Esta seguro que desea salir?", MsgBoxStyle.YesNo, "Confirmación de salida.") = MsgBoxResult.Yes Then

            ' cerrar la conexion
            Application.Exit()

        End If
    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub LineShape5_Click(sender As Object, e As EventArgs) Handles LineShape5.Click

    End Sub

    Private Sub LineShape4_Click(sender As Object, e As EventArgs) Handles LineShape4.Click

    End Sub

    Private Sub LineShape3_Click(sender As Object, e As EventArgs) Handles LineShape3.Click

    End Sub

    Private Sub HomeProfesor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        hpCargarInstituto(cbInstituto)
        hpTipoTareas(cbTipoTarea)

    End Sub

    Private Sub comboGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboGrupo.SelectedIndexChanged
        Dim consulta As String = "SELECT s.nombre_grupo, a.ci_alumno, a.nombre_alumno, a.apellido_alumno, t.telefono, a.mail, a.departamento, a.direccion, a.fecha_nac, a.sexo FROM alumno a INNER JOIN asiste s ON a.ci_alumno = s.ci_alumno INNER JOIN telefono_alumno t ON a.ci_alumno = t.ci_alumno WHERE s.nombre_grupo = " & Chr(34) & comboGrupo.Text & Chr(34) & " AND  a.estado_alumno = 't' ORDER BY apellido_alumno ASC"
        LlenarDgv(consulta, dgvAlumnosProfe)
    End Sub

    Private Sub cbInstituto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbInstituto.SelectedIndexChanged
        hpCargarGrupo(comboGrupo)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        Formula()
    End Sub
End Class