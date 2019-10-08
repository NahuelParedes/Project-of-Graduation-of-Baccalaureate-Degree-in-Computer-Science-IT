Public Class HomeAdministracion

    Private Sub BtnAlumnosAdministracion_Click(sender As Object, e As EventArgs) Handles BtnAlumnosAdministracion.Click ' click en el boton administracion
        MoverPaneles(PanelAlumnosAdministracion)
    End Sub

    Private Sub BtnNotasAdministracion_Click(sender As Object, e As EventArgs) Handles BtnNotasAdministracion.Click 'click en el boton administracion
        MoverPaneles(PanelNotasAdministracion)
    End Sub

    Private Sub BtnProfesoresAdministracion_Click(sender As Object, e As EventArgs) Handles BtnProfesoresAdministracion.Click ' click e el boton profesores
        MoverPaneles(PanelProfesoresAdministracion)
    End Sub

    Private Sub BtnGruposAdministracion_Click(sender As Object, e As EventArgs) Handles BtnGruposAdministracion.Click 'click en el boton grupos
        MoverPaneles(PanelGruposAdministracion)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnCerrarPanelGrupos.Click ' btn cerrar del panel grupos
        Cambiarcerrar(PanelGruposAdministracion)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'click en el boton cerrar panel profesores
        Cambiarcerrar(PanelProfesoresAdministracion)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click ' click en el boton cerrar panel notas
        Cambiarcerrar(PanelNotasAdministracion)
    End Sub

    Private Sub btnCerrarPanelA_Click(sender As Object, e As EventArgs) Handles btnCerrarPanelA.Click ' click en el boton cerrar panel alumnos
        Cambiarcerrar(PanelAlumnosAdministracion)
    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If MsgBox("¿Esta seguro que desea salir?", MsgBoxStyle.YesNo, "Confirmación de salida.") = MsgBoxResult.Yes Then
            ' cerrar la conexion
            Application.Exit()
        End If
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs)
        Me.Close()
        Login.Show()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Cambiarcerrar(PanelMateriasAdministracion)
    End Sub

    Private Sub btnMaterias_Click(sender As Object, e As EventArgs) Handles btnMaterias.Click
        MoverPaneles(PanelMateriasAdministracion)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Me.Close()
        Login.Show()
        Cambiarcerrar(PanelMateriasAdministracion)
        Cambiarcerrar(PanelAlumnosAdministracion)
        Cambiarcerrar(PanelGruposAdministracion)
        Cambiarcerrar(PanelNotasAdministracion)
        Cambiarcerrar(PanelProfesoresAdministracion)
    End Sub

    Private Sub PanelMenuAdministracion_MouseDown(sender As Object, e As MouseEventArgs) Handles TxtSeleccion.MouseDown, TxtMenu.MouseDown, PanelTopAdministracion.MouseDown, PanelMenuAdministracion.MouseDown, PanelHomeAdministracion.MouseDown, Icon3NM.MouseDown
        ' LLAMAMOS AL METODO  DE ARRASTRAR LA VENTANA
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
End Class