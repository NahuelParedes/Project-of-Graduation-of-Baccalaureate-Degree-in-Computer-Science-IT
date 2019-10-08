Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions


Module General


    ' metodo para cerrar los paneles----------------------------------------------------------------------------------

    Dim SiEstaAbierto As Boolean = False '  Comprueba si hay un panel abierto

    Sub Cambiarcerrar(panel As Panel)
        SiEstaAbierto = False
        panel.Location = New Point(2, 0) ' posicion del panel cuando esta visible
        Do Until panel.Location.X = -1100 Or -1200 = panel.Location.X
            panel.Location = New Point(panel.Location.X - 1, 0)
        Loop

    End Sub



    ' METODO PARA MOVER LOS PANELES
    Sub MoverPaneles(moverpanel As Panel)


        If SiEstaAbierto = False Then

            SiEstaAbierto = True
            moverpanel.Visible = True
            moverpanel.Location = New Point(-1270, 0) 'ESTA ES LA POSICION DEL PANEL DE NOTAS CUANDO ESTA ESCONDIDO

            Do Until moverpanel.Location.X = 1
                moverpanel.Location = New Point(moverpanel.Location.X + 1, 0)

            Loop

            Do Until moverpanel.Location.X = 2
                moverpanel.Location = New Point(moverpanel.Location.X + 1, 0)

            Loop


        Else
            MsgBox("Primero cierre el formulario actual para abrir otro.", MsgBoxStyle.Exclamation, "¡CIERRE EL FORMULARIO ACTUAL!")
        End If


    End Sub





    Sub LimpiarTextBox(ByVal panel As Panel) 'Borra el contenido de los textbox de los paneles

        Dim Text As Object
        For Each Text In panel.Controls
            If TypeOf Text Is TextBox Then
                Dim txtTemp As TextBox = CType(Text, TextBox)
                txtTemp.Clear()
            End If
        Next

    End Sub

    Sub LimpiarDatGrid(ByVal datag As DataGridView) 'Refresca el contenido del DataGrid
        Try
            If datag.RowCount >= 1 Then
                For i As Integer = 0 To datag.RowCount - 2
                    datag.Rows.Remove(datag.CurrentRow)
                Next
            End If
        Catch ex As InvalidOperationException ' Esta excepcion es por si ocurriera algun error.
            MsgBox("Error N° XXX: No se puede limpiar el DataGrid.", MsgBoxStyle.Critical, "Operación inválida...")
        End Try
    End Sub


    Sub BlockBotones(ByVal boton As Button)

        If SiEstaAbierto = False Then
            boton.Enabled = False
        Else


        End If


    End Sub

    Sub DesblockBotones(ByVal boton As Button)
        If SiEstaAbierto = False Then
            boton.Enabled = True
        Else

        End If
    End Sub






    Public Function validar_Mail(ByVal sMail As String) As Boolean ' VALIDACION DE EMAIL
        ' retorna true o false   
        Return Regex.IsMatch(sMail, "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
    End Function












    ' PARA PODER MOVER EL FORM DEL MENU COMO QUIERAS

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    ' TERMINA ACA



    ' mostrar y ocultar controles

    Sub ocultar(ByVal control As Control)
        control.Visible = False
    End Sub

    Sub mostrar(ByVal control As Control)
        control.Visible = True
    End Sub



End Module
