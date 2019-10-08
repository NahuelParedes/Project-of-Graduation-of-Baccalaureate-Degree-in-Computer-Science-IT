Public Class Login
    Public IngresoInvitado As Boolean = False ' Para verificar que ingresó como Invitado luego en el logeo.



    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox3.MouseDown, PictureBox2.MouseDown, PictureBox1.MouseDown, Panel1.MouseDown, lblMensajeBienvenidaLogin.MouseDown
        ' LLAMAMOS AL METODO  DE ARRASTRAR LA VENTANA
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)


    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs)   ' Validacion texto  de usuario, controla que ingrese caracteres disponibles 
        If Not e.KeyChar.ToString() Like "[a-zA-Z0-9]" And Asc(e.KeyChar) <> 8 Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If
    End Sub

    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not e.KeyChar.ToString() Like "[a-zA-Z0-9@#_\.-]" And Asc(e.KeyChar) <> 8 Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Application.Exit()

    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If IngresoInvitado = False Then


            If txtUsuario.Text = "USUARIO..." Or txtContraseña.Text = "CONTRASEÑA..." Or txtUsuario.Text = "" Or txtContraseña.Text = "" Then
                MsgBox("Ingrese algo!")

            Else
                LoginBD()
            End If
        Else

            If txtInvitado.Text = "CI" Or txtInvitado.Text = "" Then
                MsgBox("Porfavor Invitado, ingrese una cedula de identidad.")

            Else
                LoginBD()
            End If

        End If

    End Sub

    Private Sub txtUsuario_Enter(sender As Object, e As EventArgs) Handles txtUsuario.Enter
        If txtUsuario.Text = "USUARIO..." Then
            txtUsuario.Text = ""


        End If
    End Sub

    Private Sub txtUsuario_Leave(sender As Object, e As EventArgs) Handles txtUsuario.Leave
        If txtUsuario.Text = "" Then
            txtUsuario.Text = "USUARIO..."

        End If
    End Sub

    Private Sub txtContraseña_Enter(sender As Object, e As EventArgs) Handles txtContraseña.Enter
        If txtContraseña.Text = "CONTRASEÑA..." Then
            txtContraseña.Text = ""
            txtContraseña.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub txtContraseña_Leave(sender As Object, e As EventArgs) Handles txtContraseña.Leave
        If txtContraseña.Text = "" Then
            txtContraseña.Text = "CONTRASEÑA..."
            txtContraseña.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linklabelInvitado.LinkClicked

        IngresoInvitado = True

        ocultar(txtUsuario)
        ocultar(txtContraseña)
        ocultar(linklabelInvitado)
        mostrar(lbUsuario)
        mostrar(txtInvitado)

        LineShapeCI.Visible = True
        LineShape1.Visible = False
        LineShape2.Visible = False

    End Sub

    Private Sub lbUsuario_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbUsuario.LinkClicked
        IngresoInvitado = False
        ocultar(txtInvitado)
        LineShapeCI.Visible = False
        ocultar(lbUsuario)
        mostrar(txtUsuario)
        mostrar(txtContraseña)
        mostrar(linklabelInvitado)
        LineShape1.Visible = True
        LineShape2.Visible = True
    End Sub

    Private Sub txtInvitado_Enter(sender As Object, e As EventArgs) Handles txtInvitado.Enter
        If txtInvitado.Text = "CI" Then
            txtInvitado.Text = ""


        End If
    End Sub

    Private Sub txtInvitado_Leave(sender As Object, e As EventArgs) Handles txtInvitado.Leave
        If txtInvitado.Text = "" Then
            txtInvitado.Text = "CI"

        End If
    End Sub

    Private Sub Login_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        ' LLAMAMOS AL METODO  DE ARRASTRAR LA VENTANA
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtUsuario.Text = "12255887"
        txtContraseña.Text = "profe"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtUsuario.Text = "tresnmsi"
        txtContraseña.Text = "proyecto2018"
    End Sub

    Private Sub txtInvitado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInvitado.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()

        End If
    End Sub
End Class