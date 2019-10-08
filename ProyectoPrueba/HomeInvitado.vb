Imports System.Data.Odbc


Public Class HomeInvitado
    Dim cx As New Odbc.OdbcConnection
    Dim cm As New Odbc.OdbcCommand
    Dim cm2 As New Odbc.OdbcCommand
    Dim da As New Odbc.OdbcDataAdapter
    Dim ds As New Data.DataSet

    Dim read As OdbcDataReader
    Dim ciAlumno As Integer = Login.txtInvitado.Text



    Sub conexionInvitado() ' Realizamos la conexion para el invitado (Con un usuario generico)
        Try
            cx.ConnectionString = "FileDsn=" & Application.StartupPath & "\conexion.dsn;UID=usuario_invitado1;PWD=usuarioinvitado"
            cx.Open()
            cm.Connection = cx
            MsgBox(ciAlumno)
        Catch ex As Exception
            MsgBox("Error N° XXX: Error en la conexion." & ex.ToString)
        End Try

    End Sub


    Sub DataGridCarga() ' Cargamos el datagrid
        conexionInvitado()

        Try

            cm.CommandText = "SELECT * FROM califica"
            cm.ExecuteNonQuery()
            da.SelectCommand = cm
            da.Fill(ds, "Notas")
            dgvNotas.DataSource = ds.Tables("Notas")
        Catch ex As Exception
            MsgBox("N°Error xxx: Error al cargar la Informacion.")
        End Try
        cx.Close()

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
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub Label6_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelTopInv.MouseDown, MyBase.MouseDown, Label6.MouseDown, Label5.MouseDown, Label4.MouseDown, Label3.MouseDown, Label2.MouseDown
        ' LLAMAMOS AL METODO  DE ARRASTRAR LA VENTANA
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)

    End Sub

    Private Sub BtnAlumnos_Click(sender As Object, e As EventArgs) Handles BtnAlumnos.Click
        Me.Close()
        Login.Show()
    End Sub

    Private Sub HomeInvitado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox(ciAlumno)
        DataGridCarga()


    End Sub
End Class