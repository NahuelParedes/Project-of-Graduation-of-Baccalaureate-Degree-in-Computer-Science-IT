Imports System.Data.Odbc
Imports System.Net


Module ModuloBD

    Public dt As Data.DataTable

    Dim conexion As New Odbc.OdbcConnection
    Dim comando As New Odbc.OdbcCommand

    Dim read, read2 As OdbcDataReader
    Dim dataadapter As New Odbc.OdbcDataAdapter


    Dim dataset As New Data.DataSet


    Dim cont As Boolean = False ' COMPRUEBA QUE EL PERFIL(ROL) FUE DESCUBIERTO 

    Dim id_instituto, id_grupo, id_profesor, id_materia, id_alumno As String

    Dim nombreins, nombre_Anterior, depAnt, grupoAntiguo, ins_anterior As String
    Dim ciAntiguaAl As Char() = HomeAdministrador.txtCi.Text

    '-------- variables para el calculo del  la nota del alumno.

    Dim PrimerEntregaProyecto, SegundaEntregaProyecto, TerceraEntregaProyecto, notaproyecto, otrasnotas As Integer
    Dim notafinal As Integer
    '---------------

    Dim valorIp As String







    Public conexionexitosa As Boolean = False ' Comprar que la conexion fue exitosa en el Sub de conectar
    Public elperfil As String ' esto diferencia en el informix para saber que perfil es 



    Public Sub Conectar()

        Try

            conexion.ConnectionString = "FileDsn=" & Application.StartupPath & "\conexion.dsn;UID=" & Login.txtUsuario.Text & ";PWD=" & Login.txtContraseña.Text


            conexion.Open()
            comando.Connection = conexion
            conexionexitosa = True





        Catch ex As Exception
            MsgBox("Error con la conexion de la bd" + ex.Message)
            conexionexitosa = False

            conexion.Close()
        End Try






    End Sub




    ' LOGIN final con roles y usuarios.


    Public Sub LoginBD()
        If Login.IngresoInvitado = False Then


            Conectar()


            If conexionexitosa = True Then ' VERIFICAMOS QUE LA CONEXION HAYA SIDO EXITOSA CON LA BD.

                ' Ahora procederemos a obtener el rol del usuario que esta intentando logearse y enviarlo a su correspondiente ventana.



                Try
                    comando.CommandText = "SELECT defrole FROM sysusers where username = " & Chr(34) & Login.txtUsuario.Text & Chr(34)
                    read = comando.ExecuteReader
                    read.Read()
                    elperfil = read.Item(0).ToString.Trim
                    cont = True ' verifica que haya descubierto un perfil 

                Catch ex As Exception
                    MsgBox("ERROR N°1: Usuario o contraseña equivocados.")
                    MsgBox(ex.ToString)

                End Try
                conexion.Close()

            End If

        End If

        Try
            If Login.IngresoInvitado = False Then



                If cont = True Then
                    If elperfil = "" Then
                        MsgBox("Error N°XXX: Este usuario no pertenece a ningun ROL.")

                        Return

                    ElseIf elperfil = "admin" Then
                        Login.Hide()
                        HomeAdministrador.Show()



                    ElseIf elperfil = "administracion" Then
                        Login.Hide()
                        HomeAdministracion.Show()


                    ElseIf elperfil = "profesores" Then
                        Login.Hide()
                        HomeProfesor.Show()

                    End If



                End If
            End If

        Catch ex As Exception

            MsgBox("Error N° XXX: Error al verificar el perfil." + ex.Message)
        End Try


        If Login.IngresoInvitado = True Then

            Dim cedula As Char() = Login.txtInvitado.Text
            Dim numeroci, total As Integer
            Try
                numeroci = Int32.Parse(cedula)
                For i = 0 To 6 Step 1
                    numeroci = Int32.Parse(cedula(i))
                    Select Case i
                        Case 0
                            numeroci = numeroci * 2
                        Case 1
                            numeroci = numeroci * 9
                        Case 2
                            numeroci = numeroci * 8
                        Case 3
                            numeroci = numeroci * 7
                        Case 4
                            numeroci = numeroci * 6
                        Case 5
                            numeroci = numeroci * 3
                        Case 6
                            numeroci = numeroci * 4
                    End Select
                    total = total + numeroci
                Next
                If total Mod 10 + Int32.Parse(cedula(7)) = 10 Then

                    HomeInvitado.Show()
                    Login.Hide()

                Else
                    MsgBox("ERROR N°5: Ci Incorrecta!.")
                End If
            Catch
                MsgBox("ERROR N°6: Ci Incorrecta!.")
            Finally
            End Try


        End If




    End Sub

    ' FIN DEL LOGIN

    ' OBTENER IP DE TERMINAL




    ' fin de obtener  ip temrinal
#Region "Administrador"
    ' AÑADIR UN ALUMNO

    Sub NuevoAlumno()



        If HomeAdministrador.txtCi.Text = "" Or HomeAdministrador.txtNombre.Text = "" Or HomeAdministrador.txtApellido.Text = "" Or HomeAdministrador.txtTelefono.Text = "" Or HomeAdministrador.txtDireccion.Text = "" Or HomeAdministrador.cbDepartamento.Text = "" Or HomeAdministrador.cbSexo.Text = "" Or HomeAdministrador.dtpFechaNac.Text = "" Or HomeAdministrador.cbGrupoAlum.Text = "" Then
            MsgBox("Rellene todos los datos!.")

        ElseIf HomeAdministrador.validacionMAIL = False Then

            MsgBox("Error con el emial.")
        Else


            Dim cedula As Boolean = False
            Dim total As Integer
            Dim numeroci As Integer

            Dim cedulac As Char() = HomeAdministrador.txtCi.Text
            Dim fechaNacArmada As String
            'COMPROBAMOS LA EDAD EDAD
            Dim edadA As String
            edadA = DateDiff("yyyy", HomeAdministrador.dtpFechaNac.Value, DateTime.Now).ToString()
            fechaNacArmada = HomeAdministrador.dtpFechaNac.Value.ToString("MM/dd/yyyy")
            If edadA >= 15 Then



                Try
                    numeroci = Int32.Parse(cedulac)
                    For i = 0 To 6 Step 1
                        numeroci = Int32.Parse(cedulac(i))

                        Select Case i
                            Case 0
                                numeroci = numeroci * 2
                            Case 1
                                numeroci = numeroci * 9
                            Case 2
                                numeroci = numeroci * 8
                            Case 3
                                numeroci = numeroci * 7
                            Case 4
                                numeroci = numeroci * 6
                            Case 5
                                numeroci = numeroci * 3
                            Case 6
                                numeroci = numeroci * 4
                        End Select
                        total = total + numeroci
                    Next

                    If total Mod 10 + Int32.Parse(cedulac(7)) = 10 Then
                        cedula = True
                    Else
                        MsgBox("N°Error XXX: Ingrese una Cedula valida.")
                    End If
                Catch
                    MsgBox("N°Error XXX: Ingrese una Cedula valida.")
                End Try
            Else
                MsgBox("N°Error XXX: Alumno debe ser mayor a 16.")
            End If




            ' COMPROBAMOS QUE NO ESTE EN OTRO GRUPO




            ' Comprobamos que ya no este en la BD

            Dim CorrAluno As Boolean = False

            Dim sql As String

            conexion.Open()

            Try

                sql = "SELECT * FROM persona WHERE ci= " & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34)

                comando.Connection = conexion
                comando.CommandText = sql
                read = comando.ExecuteReader()

            Catch ex As Exception

                MsgBox("ERROR XXX: Falla al corroborar la existencia del alumno.")


            End Try


            If read.HasRows Then  ' Si el data reader tiene filas (datos)----

                CorrAluno = True

            Else
                CorrAluno = False
            End If

            conexion.Close()





            If cedula = True Then

                If CorrAluno = False Then


                    ' INGRESAMOS AL ALUMNO ( como persona)
                    conexion.Open()
                        Try
                        comando.CommandText = "insert into persona (ci, nombre, apellido, fch_nac, sexo, direccion, mail, departamento,telefono,telefono_sec, estado) 
values (" & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtNombre.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtApellido.Text & Chr(34) & "," & Chr(34) & fechaNacArmada & Chr(34) & "," & Chr(34) & HomeAdministrador.cbSexo.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtDireccion.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtEmail.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.cbDepartamento.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtTelefono.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtTel2Al.Text & Chr(34) & "," & Chr(34) & "t" & Chr(34) & ");"

                        comando.ExecuteNonQuery()

                            MsgBox("Alumno añadido con exito.")
                        Catch ex As Exception
                            MsgBox(comando.CommandText.ToString)
                            MsgBox("N°Error XXX: Error al añadir alumno." & ex.ToString)
                        Finally
                            conexion.Close()
                        End Try

                    ' INGRESAMOS LA PERSONA COMO ALUMNO


                    conexion.Open()
                        Try
                            comando.CommandText = "insert into alumno (ci)
                                            values (" & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34) & ");"

                            comando.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox("N°Error XXX: Error al ingresar el alumno ." & ex.ToString)
                        End Try
                        conexion.Close()


                        ' Ahora conseguimos el id del alumno y el id del grupo

                        ' ID DEL GRUPO
                        conexion.Open()
                        Try
                            comando.CommandText = "SELECT g.id_grupo FROM grupo g, instituto i WHERE g.id_instituto = i.id_instituto AND g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoAlum.Text & Chr(34) & " AND i.departamento = " & Chr(34) & HomeAdministrador.cbDepInsAlum.Text & Chr(34) & " AND i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsAlumno.Text & Chr(34) & "  AND g.estado_grupo = 't'"
                            read = comando.ExecuteReader
                            read.Read()
                            id_grupo = read("id_grupo")

                        Catch ex As Exception
                            MsgBox("" + ex.Message)
                            MsgBox("ERROR XXX: Falla al obtener el id del grupo ." & comando.CommandText.ToString)
                            Return
                        Finally
                            conexion.Close()
                        End Try

                        ' ID DEL ALUMNO
                        conexion.Open()
                        Try
                            comando.CommandText = "SELECT id_alumno FROM alumno a, persona p WHERE a.ci = p.ci AND p.ci = " & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34) & " AND p.estado = 't'"
                            read = comando.ExecuteReader
                            read.Read()
                            id_alumno = read("id_alumno")

                        Catch ex As Exception
                            MsgBox("ERROR XXX: Falla al obtener el id del alumno." & comando.CommandText.ToString)
                            Return
                        Finally
                            conexion.Close()
                        End Try







                    ' Ahora lo ingresamos al grupo correspondiente y a las materias que selecciono del ListBox.

                    Try

                        If HomeAdministrador.CheckedListBox1.Items.Count > 0 Then

                                For Each checkedItem In HomeAdministrador.CheckedListBox1.CheckedItems

                                    Dim dr As DataRowView = CType(checkedItem, DataRowView)
                                    Dim result As String = dr("nombre_materia").ToString

                                    conexion.Open()
                                    Try
                                        comando.CommandText = "select id_materia from materia where nombre_materia = " & Chr(34) & result & Chr(34) & "
"
                                        read = comando.ExecuteReader
                                        read.Read()
                                        id_materia = read.Item(0).ToString.Trim

                                    Catch ex As Exception
                                        MsgBox("N°Error XXX: Error al ingresar el alumno ." & ex.ToString)
                                    Finally
                                        conexion.Close()

                                    End Try







                                    conexion.Open()
                                    Try
                                        comando.CommandText = "insert into asiste (id_materia,id_alumno,id_grupo,nro_lista,estado_asiste)
                                                              values (" & Chr(34) & id_materia & Chr(34) & "," & Chr(34) & id_alumno & Chr(34) & "," & Chr(34) & id_grupo & Chr(34) & "," & Chr(34) & HomeAdministrador.txtNumeroLista.Text & Chr(34) & "," & Chr(34) & "t" & Chr(34) & ");"




                                        comando.ExecuteNonQuery()
                                    Catch ex As Exception
                                        MsgBox("N°Error XXX: Error al ingresar el alumno ." & ex.ToString)
                                    Finally
                                        conexion.Close()

                                    End Try





                                Next

                                MessageBox.Show("Se ingreso correctamente al alumno.")








                            End If





                        Catch ex As Exception

                        End Try


                    Dim consulta As String = "SELECT DISTINCT a.nro_lista, p.ci, p.nombre, p.apellido, p.telefono, p.telefono_sec, p.fch_nac, p.sexo, p.direccion, p.mail, p.departamento  FROM persona p INNER JOIN alumno k ON p.ci = k.ci INNER JOIN asiste a ON k.id_alumno = a.id_alumno INNER JOIN grupo g ON a.id_grupo = g.id_grupo INNER JOIN instituto i ON i.id_instituto = g.id_instituto WHERE g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoAlum.Text & Chr(34) & " AND i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsAlumno.Text & Chr(34) & " AND a.estado_asiste = 't' AND i.departamento = " & Chr(34) & HomeAdministrador.cbDepInsAlum.Text & Chr(34) & ""
                    LlenarDgv(consulta, HomeAdministrador.dgvAlumnos)
                        HomeAdministrador.lblAlumnos.Text = "Alumnos: " & HomeAdministrador.dgvAlumnos.Rows.Count - 1
                        HomeAdministrador.lblGrupo.Text = "Grupo: " & HomeAdministrador.cbGrupoAlum.Text

                    Else
                        MsgBox("Error N°XXX: Alumno ya ingresado!")



                End If
            Else
                MsgBox("Error N°XXX: Ingrese una Cedula de Identidad valida.")

            End If
        End If







    End Sub




    '------------------------  AÑADIR GRUPOS (ADMINISTRADOR)

    Sub añadirgrupos()

        Dim sql As String
        Dim verificadorgru As Boolean = False ' VERIFICADOR DE LA EXISTENCIA DEL GRUPO

        ' BUSCA EL ID DEL   INSTITUTO -----------------------------------
        conexion.Open()

        Try
            comando.CommandText = "SELECT id_instituto FROM instituto WHERE nombre_instituto = " & Chr(34) & HomeAdministrador.cbInstitutoGrupos.Text & Chr(34) & "AND departamento =" & Chr(34) & HomeAdministrador.cbDepInsGrupos.Text & Chr(34)
            read = comando.ExecuteReader
            read.Read()
            id_instituto = read.Item(0).ToString.Trim


        Catch ex As Exception
            MsgBox("ERROR XXX: Falla al obtener el id del instituto.")


        End Try
        conexion.Close()


        '---------------- COMPROBAMOS LA EXISTENCIA DEL GRUPO EN ESE INSTITUTO

        Try


            If HomeAdministrador.txtNombreGrupo.Text = "" Or HomeAdministrador.txtOrientacionGrupo.Text = "" Or HomeAdministrador.txtTurnoGrupo.Text = "" Then
                MsgBox("No se permite ingresar datos vacios, ingrese ")
            Else


                conexion.Open()

                sql = "SELECT nombre_grupo FROM grupo WHERE nombre_grupo = " & Chr(34) & HomeAdministrador.txtNombreGrupo.Text & Chr(34) & " AND id_instituto = " & Chr(34) & id_instituto & Chr(34)




                comando.Connection = conexion
                comando.CommandText = sql
                read = comando.ExecuteReader()

                If read.HasRows Then  ' Si el data reader tiene filas (datos)----

                    verificadorgru = True

                Else
                    verificadorgru = False
                End If

            End If

        Catch
            MsgBox("ERROR N° XXX: Error al comprobar la existencia del grupo.")
        End Try


        conexion.Close()







        '------------- Finaliza la busqueda


        If verificadorgru = False Then

            conexion.Open()


            Try
                comando.CommandText = "insert into grupo (nombre_grupo, orientacion, id_instituto, ano_lectivo, turno, estado_grupo) 
values (" & Chr(34) & HomeAdministrador.txtNombreGrupo.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtOrientacionGrupo.Text & Chr(34) & "," & Chr(34) & id_instituto & Chr(34) & "," & Chr(34) & "2018" & Chr(34) & "," & Chr(34) & HomeAdministrador.txtTurnoGrupo.Text & Chr(34) & "," & Chr(34) & "t" & Chr(34) & ");"

                comando.ExecuteNonQuery()
                MsgBox("Grupo añadido con exito !")
            Catch ex As Exception
                MsgBox("N°Error xxx: Error al añadir grupo." & ex.ToString)
            End Try
            conexion.Close()





            'CARGAMOS LOS GRUPOS AL DATRAGRID

            Dim consulta As String = "SELECT i.nombre_instituto, g.nombre_grupo, g.ano_lectivo, g.estado_grupo, g.orientacion, g.turno FROM instituto i JOIN grupo g on i.id_instituto = g.id_instituto WHERE i.id_instituto =" & Chr(34) & id_instituto & Chr(34)
            LlenarDgv(consulta, HomeAdministrador.dgvGrupos)

        Else

            MsgBox("ERROR N° XXX: Error, grupo ya ingresado.")

        End If

    End Sub






    Sub AsignarMateriaGrupo()




        Dim sql As String

        Dim verificadorMateria As Boolean = False
        Dim siexiste As Boolean = False ' Para comprobar primero si la materia existe en la BD.


        ' Buscamos la materia en la BD.





        conexion.Open()

        Try

            If HomeAdministrador.txtMateriaPMaterias.Text = "" Then
                MsgBox("ingrese datos")


            Else


                sql = "SELECT nombre_materia FROM materia WHERE nombre_materia = " & Chr(34) & HomeAdministrador.txtMateriaPMaterias.Text & Chr(34) & " AND estado_materia = 't'"




                comando.Connection = conexion
                comando.CommandText = sql
                read = comando.ExecuteReader()

                If read.HasRows Then  ' Si el data reader tiene filas (datos)----

                    siexiste = True


                Else
                    siexiste = False

                End If



            End If

        Catch ex As Exception
            MsgBox("Error N°XXX: Error al buscar la materia en la BD" + ex.Message)
        Finally
            conexion.Close()
        End Try











        If siexiste = True Then





            ' Buscamos el ID de la Materia.

            conexion.Open()

            Try
                comando.CommandText = "SELECT id_materia FROM materia WHERE nombre_materia = " & Chr(34) & HomeAdministrador.txtMateriaPMaterias.Text & Chr(34) & " AND estado_materia = 't'"
                read = comando.ExecuteReader
                read.Read()
                id_materia = read.Item(0).ToString.Trim



            Catch ex As Exception
                MsgBox("ERROR XXX: Falla al obtener el id de materia.")
                Return

            Finally
                conexion.Close()
            End Try


            ' Fin busca de ID de Materia.


            ' BUSCA EL ID DEL   INSTITUTO -----------------------------------

            conexion.Open()

            Try
                comando.CommandText = "SELECT id_instituto FROM instituto WHERE nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsMaterias.Text & Chr(34) & "AND departamento = " & Chr(34) & HomeAdministrador.cbDepInstitutoMaterias.Text & Chr(34)
                read = comando.ExecuteReader
                read.Read()
                id_instituto = read.Item(0).ToString.Trim


            Catch ex As Exception
                MsgBox("ERROR XXX: Falla al obtener el id del instituto.")

            Finally
                conexion.Close()
            End Try




            ' Buscamos el ID del Grupo.

            conexion.Open()

            Try
                comando.CommandText = "select id_grupo FROM grupo  WHERE nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoPMaterias.Text & Chr(34) & " AND id_instituto = " & Chr(34) & id_instituto & Chr(34) & " AND estado_grupo = 't'"
                read = comando.ExecuteReader
                read.Read()

                id_grupo = read.Item(0).ToString.Trim



            Catch ex As Exception
                MsgBox("ERROR XXX: Falla al obtener el id de grupo." + ex.Message)

                Return

            Finally
                conexion.Close()
            End Try


            ' Fin busca de ID de Grupo.

            ' Corroboramos que exista la materia en ese grupo.

            conexion.Open()
            Try


                If HomeAdministrador.txtMateriaPMaterias.Text = "" Or HomeAdministrador.cbGrupoPMaterias.Text = "" Or HomeAdministrador.dtpHoraIniM.Text = "" Or HomeAdministrador.dtpHoraFinM.Text = "" Or HomeAdministrador.txtDiaMateria.Text = "" Then
                    MsgBox("No se permite ingresar datos vacios, ingrese ")
                    Return ' Si ingresa datos vacios vuelve a la condicion y no sigue ejecutando todo el if de abajo.


                Else






                    sql = "select m.nombre_materia from materia m, tiene t INNER JOIN grupo g ON t.id_grupo = g.id_grupo INNER JOIN instituto i ON i.id_instituto = g.id_instituto  WHERE t.id_materia = m.id_materia AND g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoPMaterias.Text & Chr(34) & " AND i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsMaterias.Text & Chr(34) & " AND i.departamento = " & Chr(34) & HomeAdministrador.cbDepInstitutoMaterias.Text & Chr(34) & " AND m.estado_materia = 't' AND m.nombre_materia = " & Chr(34) & HomeAdministrador.txtMateriaPMaterias.Text & Chr(34)



                    comando.Connection = conexion
                    comando.CommandText = sql
                    read = comando.ExecuteReader()

                    If read.HasRows Then  ' Si el data reader tiene filas (datos)----

                        verificadorMateria = True
                        MsgBox("Error N°XXX: La materia que ingresó ya esta asociada a ese grupo.")
                        Return
                    Else
                        verificadorMateria = False

                    End If

                End If




            Catch ex As Exception
                MsgBox("ERROR N° XXX: Error al comprobar la existencia de la materia.")

            Finally
                conexion.Close()

            End Try




            ' Ahora que comprobamos que la materia existe, seguiremos.



            If verificadorMateria = False Then






                ' Ahora asginamos la materia al grupo.




                conexion.Open()

                Try
                    comando.CommandText = "insert into tiene (id_materia, id_grupo, dia, hora_inicio, hora_fin)
values (" & Chr(34) & id_materia & Chr(34) & "," & Chr(34) & id_grupo & Chr(34) & "," & Chr(34) & HomeAdministrador.txtDiaMateria.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.dtpHoraIniM.Value.ToLongTimeString & Chr(34) & "," & Chr(34) & HomeAdministrador.dtpHoraFinM.Value.ToLongTimeString & Chr(34) & ");"

                    comando.ExecuteNonQuery()
                    MsgBox("Materia asignada con exito!!")
                Catch ex As Exception


                    MsgBox("N°Error xxx: Error al asginar materia al grupo: " & ex.Message)
                Finally
                    conexion.Close()
                End Try


                ' ACA RELLENAMOS EL DGV CON LA NUEVA INFO
                Dim consulta As String = "SELECT g.nombre_grupo, m.nombre_materia, t.dia, t.hora_inicio, t.hora_fin FROM grupo g INNER JOIN tiene t ON g.id_grupo = t.id_grupo INNER JOIN materia m ON m.id_materia = t.id_materia INNER JOIN instituto i ON g.id_instituto = i.id_instituto WHERE g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoPMaterias.Text & Chr(34) & " AND g.estado_grupo = 't' AND i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsMaterias.Text & Chr(34) & " AND  i.departamento = " & Chr(34) & HomeAdministrador.cbDepInstitutoMaterias.Text & Chr(34) & ""
                LlenarDgv(consulta, HomeAdministrador.dgvMaterias)


            Else
                MsgBox("ERROR N° XXX: Error, materia ya fue asociada a ese grupo.")

            End If

        Else
            MsgBox("Error N° XXX: La materia que ingresó no existe.")
        End If




    End Sub


    ' .------------------------------------------------------Ingresar nueva Materia.--------------------------------------------------------------------



    Sub NuevaMateria()
        Dim verificadorMateria As Boolean = False
        Dim sql As String

        '---------------- Comprobamos la exitencia de la materia
        conexion.Open()

        Try


            If HomeAdministrador.txtNuevaMateria.Text = "" Then
                MsgBox("No se permite ingresar datos vacios, ingrese.")
            Else




                sql = "SELECT nombre_materia FROM materia WHERE nombre_materia = " & Chr(34) & HomeAdministrador.txtNuevaMateria.Text & Chr(34) & "AND estado_materia=" & Chr(34) & "t" & Chr(34)







                comando.Connection = conexion
                comando.CommandText = sql
                read = comando.ExecuteReader()

                If read.HasRows Then  ' Si el data reader tiene filas (datos)----

                    verificadorMateria = True

                Else
                    verificadorMateria = False
                End If

            End If


        Catch ex As Exception
            MsgBox("ERROR N° XXX: Error al comprobar la existencia de la materia.")

        Finally

            conexion.Close()

        End Try

        '------------- Finaliza la busqueda





        ' Ahora Ingresamos la nueva materia

        If verificadorMateria = False Then

            conexion.Open()


            Try
                comando.CommandText = "insert into materia (nombre_materia, estado_materia)
values (" & Chr(34) & HomeAdministrador.txtNuevaMateria.Text & Chr(34) & "," & Chr(34) & "t" & Chr(34) & ");"

                comando.ExecuteNonQuery()
                MsgBox("Materia ingresada con exito!!")
            Catch ex As Exception
                MsgBox(comando.CommandText.ToString)

                MsgBox("N°Error xxx: Error al ingresar materia." & ex.Message)
            Finally
                conexion.Close()
            End Try



        Else
            MsgBox("ERROR N° XXX: Error, esta Materia ya esta ingresada.")

        End If
    End Sub



    ' Fin de ingreso de nueva materia.

    ' Ingreso nuevo instituto 



    Sub NuevoInstituto()

        Dim verificadorIns As Boolean = False
        Dim sql As String



        '---------------- COMPROBAMOS LA EXISTENCIA DEL INSTITUTO

        Try


            If HomeAdministrador.txtNombreInstituto.Text = "" Or HomeAdministrador.txtDirIns.Text = "" Or HomeAdministrador.txtTelefonoIns.Text = "" Or HomeAdministrador.txtEmailIns.Text = "" Or HomeAdministrador.cbDepartamentoIns.Text = "" Then
                MsgBox("No se permite ingresar datos vacios, ingrese ")

            ElseIf HomeAdministrador.validacionMAIL = False Then

                MsgBox("Error con el emial.")
            Else


                conexion.Open()

                sql = "SELECT nombre_instituto, departamento FROM instituto WHERE nombre_instituto = " & Chr(34) & HomeAdministrador.txtNombreInstituto.Text & Chr(34) & " AND departamento= " & Chr(34) & HomeAdministrador.cbDepartamentoIns.Text & Chr(34)




                comando.Connection = conexion
                comando.CommandText = sql
                read = comando.ExecuteReader()

                If read.HasRows Then  ' Si el data reader tiene filas (datos)----

                    verificadorIns = True

                Else
                    verificadorIns = False
                End If

            End If

        Catch
            MsgBox("ERROR N° XXX: Error al comprobar la existencia del grupo.")
        End Try


        conexion.Close()









        '------------- Finaliza la busqueda


        If verificadorIns = False Then



            ' INGRESAMOS EL INSTITUTO 

            Conectar()


            Try
                comando.CommandText = "insert into instituto (nombre_instituto, direccion, mail, departamento, estado_instituto) 
values (" & Chr(34) & HomeAdministrador.txtNombreInstituto.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtDirIns.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtEmailIns.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.cbDepartamentoIns.Text & Chr(34) & "," & Chr(34) & "t" & Chr(34) & ");"

                comando.ExecuteNonQuery()
                MsgBox("Instituto añadido con exito !")
            Catch ex As Exception
                MsgBox("N°Error xxx: Error al añadir instituto." & ex.ToString)
            End Try
            conexion.Close()



            ' BUSCA EL ID DEL   INSTITUTO -----------------------------------
            Conectar()

            Try
                comando.CommandText = "SELECT id_instituto FROM instituto WHERE nombre_instituto = " & Chr(34) & HomeAdministrador.txtNombreInstituto.Text & Chr(34) & " AND departamento = " & Chr(34) & HomeAdministrador.cbDepartamentoIns.Text & Chr(34)
                read = comando.ExecuteReader
                read.Read()
                id_instituto = read.Item(0).ToString.Trim


            Catch ex As Exception
                MsgBox("ERROR XXX: Falla al obtener el id del instituto.")


            End Try
            conexion.Close()



            ' FIN DE LA BUSQUEDA DEL ID DEL INSTITUTO





            ' LE INGRESAMOS EL TELEFONO AL INSTITUTO
            Conectar()
            Try
                comando.CommandText = "insert into telefono_instituto (id_instituto, telefono)
                                            values (" & Chr(34) & id_instituto & Chr(34) & "," & Chr(34) & HomeAdministrador.txtTelefonoIns.Text & Chr(34) & ");"

                comando.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("N°Error XXX: Error al ingresar el telefono del Instituto." & ex.ToString)
            End Try
            conexion.Close()


            Dim consulta As String = "select i.id_instituto, i.nombre_instituto, i.departamento, t.telefono, i.mail, i.direccion FROM instituto i, telefono_instituto t WHERE t.id_instituto = i.id_instituto AND i.estado_instituto = 't'"
            LlenarDgv(consulta, HomeAdministrador.dgvInstitutos)











        Else
            MsgBox("ERROR N° XXX: Error, instituto ya ingresado en ese departamento.")

        End If















    End Sub

#Region "Ingreso de profesor"
    Sub NuevoProfesor()


        ' VERIFICAMOS QUE NO HAYA INGRESADO TEXTO MAL.

        If HomeAdministrador.txtCiProf.Text = "" Or HomeAdministrador.txtNombreProf.Text = "" Or HomeAdministrador.txtApeProf.Text = "" Or HomeAdministrador.txtTelProf.Text = "" Or HomeAdministrador.txtDirProf.Text = "" Or HomeAdministrador.cbDepaProf.Text = "" Or HomeAdministrador.txtEmailProf.Text = "" Or HomeAdministrador.cbSexoProf.Text = "" Or HomeAdministrador.dtpFchaProf.Text = "" Then
            MsgBox("Rellene todos los datos!.")

        ElseIf HomeAdministrador.validacionMAIL = False Then

            MsgBox("Error con el emial.")
        Else


            Dim cedula As Boolean = True
            Dim total As Integer
            Dim numeroci As Integer
            Dim fechaNacArmada As String
            Dim cedulac As Char() = HomeAdministrador.txtCiProf.Text

            'COMPROBAMOS LA EDAD EDAD DEL PROFESOR

            Dim edadA As String
            edadA = DateDiff("yyyy", HomeAdministrador.dtpFchaProf.Value, DateTime.Now).ToString()
            fechaNacArmada = HomeAdministrador.dtpFchaProf.Value.ToString("MM/dd/yyyy")
            If edadA >= 18 And edadA <= 75 Then



                Try
                    numeroci = Int32.Parse(cedulac)
                    For i = 0 To 6 Step 1
                        numeroci = Int32.Parse(cedulac(i))
                        Select Case i
                            Case 0
                                numeroci = numeroci * 2
                            Case 1
                                numeroci = numeroci * 9
                            Case 2
                                numeroci = numeroci * 8
                            Case 3
                                numeroci = numeroci * 7
                            Case 4
                                numeroci = numeroci * 6
                            Case 5
                                numeroci = numeroci * 3
                            Case 6
                                numeroci = numeroci * 4
                        End Select
                        total = total + numeroci
                    Next

                    If total Mod 10 + Int32.Parse(cedulac(7)) = 10 Then
                        cedula = True
                    Else
                        MsgBox("N°Error XXX: Ingrese una Cedula valida.")
                    End If
                Catch
                    MsgBox("N°Error XXX: Ingrese una Cedula valida.")
                End Try
            Else
                MsgBox("N°Error XXX: Profesor debe ser mayor a 18 años y menor a 75.")
                Return

            End If





            If cedula = True Then ' SI LA CEDULA ES VALIDA







                ' Antes de añadir a un profesor corroboramos todo

                Dim CorrDictado As Boolean = False
                Dim HayAlumnos As Boolean = False
                Dim sql As String
                Dim siyaesta As Boolean = False



                ' Si ya esta en la BD



                If siyaesta = False Then
                    MsgBox("El Profesor que intenta añadir ya esta en la BD")
                Else


                    ' Corroboramos si hay un profesor ya dictando en esa materia y en ese gruo
                    Try


                        conexion.Open()

                        Try

                            sql = "SELECT ci FROM profesor WHERE ci = " & Chr(34) & HomeAdministrador.txtCiProf.Text & Chr(34)
                            comando.Connection = conexion
                            comando.CommandText = sql
                            read = comando.ExecuteReader()

                        Catch ex As Exception
                            MsgBox("ERROR XXX:  Error comprobar la ci." + ex.Message)


                        End Try


                        If read.HasRows Then  ' Si el data reader tiene filas (datos)----

                            siyaesta = True

                        Else
                            siyaesta = False
                        End If



                    Catch ex As Exception
                        MsgBox(" Error XXX Al comprobar la ci . " + ex.Message)
                    Finally
                        conexion.Close()

                    End Try





                    ' Corroboramos si hay un profesor ya dictando en esa materia y en ese gruo
                    Try


                        conexion.Open()

                        Try

                            sql = "SELECT p.nombre, p.apellido, p.ci FROM persona p INNER JOIN profesor f ON p.ci = f.ci INNER JOIN dicta d ON d.id_profesor = f.id_profesor INNER JOIN materia m ON m.id_materia = d.id_materia INNER JOIN grupo g ON g.id_grupo = d.id_grupo INNER JOIN instituto i ON i.id_instituto = g.id_instituto WHERE i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsProf.Text & Chr(34) & " AND i.departamento = " & Chr(34) & HomeAdministrador.cbDepInsProf.Text & Chr(34) & " AND g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoProf.Text & Chr(34) & " AND f.ci = '123456' AND m.nombre_materia = " & Chr(34) & HomeAdministrador.cbMatProf.Text & Chr(34) & " AND p.estado = 't'"
                            comando.Connection = conexion
                            comando.CommandText = sql
                            read = comando.ExecuteReader()

                        Catch ex As Exception
                            MsgBox("ERROR XXX: Falla al corroborar si un prof esta en una materia de un grupo.")


                        End Try


                        If read.HasRows Then  ' Si el data reader tiene filas (datos)----

                            CorrDictado = True

                        Else
                            CorrDictado = False
                        End If



                    Catch ex As Exception
                        MsgBox("Error al comprobar si un profesor esta dictando una materia de un grupo " + ex.Message)
                    Finally
                        conexion.Close()

                    End Try


                    If CorrDictado = False Then

                        Try

                            ' Ahora si no hay un profesor dictando esa clase en esa materia CORROBORAMOS QUE EN ESE GRUPO Y EN ESTA MATERIA HAYAN ALUMNOS, YA QUE N PUEDE ASIGNAR UN GRUPO SIN ALUMNOS
                            conexion.Open()

                            Try

                                sql = "SELECT a.id_alumno FROM asiste a INNER JOIN grupo g ON a.id_grupo = g.id_grupo INNER JOIN  materia m ON a.id_materia = m.id_materia INNER JOIN instituto i ON i.id_instituto = g.id_instituto WHERE i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsProf.Text & Chr(34) & " AND i.departamento = " & Chr(34) & HomeAdministrador.cbDepInsProf.Text & Chr(34) & " AND g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoProf.Text & Chr(34) & "  AND m.nombre_materia = " & Chr(34) & HomeAdministrador.cbMatProf.Text & Chr(34)

                                comando.Connection = conexion
                                comando.CommandText = sql
                                read = comando.ExecuteReader()

                            Catch ex As Exception
                                MsgBox("ERROR XXX: Falla al corroborar si hay alumnos en una materia de un grupo.")


                            End Try


                            If read.HasRows Then  ' Si el data reader tiene filas (datos)----

                                HayAlumnos = True

                            Else
                                HayAlumnos = False
                            End If



                        Catch ex As Exception
                            MsgBox("Error al comprobar si un profesor esta dictando una materia " + ex.Message)
                        Finally
                            conexion.Close()

                        End Try





                        If HayAlumnos = True Then







                            ' INGRESO AL PROFESOR 

                            conexion.Open()
                            Try
                                comando.CommandText = "insert into persona (ci, nombre, apellido, fch_nac, sexo, direccion, mail, departamento, estado) 
                       values (" & Chr(34) & HomeAdministrador.txtCiProf.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtNombreProf.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtApeProf.Text & Chr(34) & "," & Chr(34) & fechaNacArmada & Chr(34) & "," & Chr(34) & HomeAdministrador.cbSexoProf.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtDirProf.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtEmailProf.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.cbDepaProf.Text & Chr(34) & "," & Chr(34) & "t" & Chr(34) & ");"
                                comando.ExecuteNonQuery()
                            Catch ex As Exception

                                MsgBox("N°Error XXX: Error al añadir profesor a la BD." & ex.ToString)
                            Finally
                                conexion.Close()
                            End Try


                            ' LE INGRESAMOS EL TELEFONO
                            conexion.Open()
                            Try
                                comando.CommandText = "insert into telefono_persona (ci, telefono)
                                            values (" & Chr(34) & HomeAdministrador.txtCiProf.Text & Chr(34) & "," & Chr(34) & HomeAdministrador.txtTelProf.Text & Chr(34) & ");"

                                comando.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox("N°Error XXX: Error al ingresar el telefono del Profesor." & ex.ToString)
                            Finally
                                conexion.Close()
                            End Try

                            ' INGRESAMOS A ESA PERSONA COMO PROFESOR


                            conexion.Open()
                            Try
                                comando.CommandText = "insert into profesor (ci)
                                            values (" & Chr(34) & HomeAdministrador.txtCiProf.Text & Chr(34) & ");"

                                comando.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox("N°Error XXX: Error al ingresar la persona como profesor ." & ex.ToString)
                            Finally
                                conexion.Close()
                            End Try



                            ' Ahora conseguimos el ID de profesor, el ID de la materia y el ID del grupo.


                            conexion.Open()
                            Try
                                comando.CommandText = "SELECT p.id_profesor, t.id_grupo, t.id_materia FROM profesor p, tiene t INNER JOIN grupo g ON t.id_grupo = g.id_grupo INNER JOIN materia m ON t.id_materia = m.id_materia INNER JOIN instituto i ON g.id_instituto = i.id_instituto WHERE m.nombre_materia = " & Chr(34) & HomeAdministrador.cbMatProf.Text & Chr(34) & " AND i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsProf.Text & Chr(34) & " AND i.departamento = " & Chr(34) & HomeAdministrador.cbDepInsProf.Text & Chr(34) & " AND g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoProf.Text & Chr(34) & " AND p.ci = " & Chr(34) & HomeAdministrador.txtCiProf.Text & Chr(34) & ""
                                read = comando.ExecuteReader
                                read.Read()

                                id_profesor = read("id_profesor")
                                id_grupo = read("id_grupo")
                                id_materia = read("id_materia")



                            Catch ex As Exception
                                MsgBox("ERROR XXX: Falla al obtener el id de materia." & comando.CommandText.ToString)

                            Finally
                                conexion.Close()
                            End Try


                            'Fin de la busqueda de los ID




                            ' INGRESAMOS A A DICTAR AL PROFESOR A UN GRUPO Y A UNA MATERIA Y A UNA MATERIA CON TALES ALUMNOS 




                            Try

                                Dim consulta As String = "SELECT a.id_alumno FROM asiste a INNER JOIN grupo g ON a.id_grupo = g.id_grupo INNER JOIN materia m ON a.id_materia = m.id_materia INNER JOIN instituto i ON i.id_instituto = g.id_instituto WHERE i.nombre_instituto = 'ITS' AND i.departamento = 'Montevideo' AND g.nombre_grupo = '3XI'  AND m.nombre_materia = 'Matematica Super Avanzada'"
                                Execute(consulta)



                                For Each alumnos In dt.Rows


                                    Dim result = Convert.ToInt32(alumnos("id_alumno"))
                                    MsgBox(result)

                                    conexion.Open()
                                    Try
                                        comando.CommandText = "insert into dicta (id_profesor,id_alumno,id_materia,id_grupo)
                                                              values (" & Chr(34) & id_profesor & Chr(34) & "," & Chr(34) & result & Chr(34) & "," & Chr(34) & id_materia & Chr(34) & "," & Chr(34) & id_grupo & Chr(34) & ");
"

                                        comando.ExecuteNonQuery()
                                    Catch ex As Exception
                                        MsgBox("N°Error XXX: Error al ingresar a un grupo a un profesor" & ex.ToString)
                                    Finally
                                        conexion.Close()

                                    End Try


                                Next







                            Catch ex As Exception

                            End Try

                        Else

                            MsgBox("Error N XXX No hay alumnos asistiendo en esa materia de ese grupo")
                            Return

                        End If



                    Else


                        MsgBox("Error N° XXX Ya hay un Profesor dictando esa materia en ese grupo.")
                        Return


                    End If




                End If



            Else
                MsgBox("Error N° XXX Ingrese una CI valida.")
                Return


            End If



        End If


    End Sub

    Sub AsignarProfesor()

        If  Then

        End If




    End Sub
#End Region

#Region "Funciones de Informix, Cargar Combox, Cargar DGV, Cargar N Combox."



    Function Execute(sentencia As String) As DataTable
        dt = New Data.DataTable









        conexion.Open()

        Try

            comando.Connection = conexion
            comando.CommandText = sentencia
            dt.Load(comando.ExecuteReader())
            Return dt




        Catch ex As Exception


        Finally
            conexion.Close()



        End Try


    End Function



    Sub cargarInstitutos(combo As ComboBox)
        Dim instituto As DataTable = Execute("select nombre_instituto from instituto")
        If instituto.Rows.Count = 0 Then
            combo.DataSource = Nothing
            Return
        End If
        If instituto.Rows.Count > 0 Then
            With combo
                .DataSource = instituto
                .DisplayMember = "nombre_instituto"
                .ValueMember = "nombre_instituto"

            End With
        End If
    End Sub

    Sub CargarGrupoSegunInstitutoYDep(combogrupo As ComboBox, instituto As ComboBox, departamento As ComboBox)

        Dim grupo As DataTable = Execute("SELECT g.nombre_grupo FROM grupo g, instituto i WHERE i.id_instituto = g.id_instituto AND i.nombre_instituto = " & Chr(34) & instituto.Text & Chr(34) & "AND i.departamento = " & Chr(34) & departamento.Text & Chr(34) & " AND g.estado_grupo = 't'")


        If grupo.Rows.Count = 0 Then
            combogrupo.DataSource = Nothing
            Return
        End If
        If grupo.Rows.Count > 0 Then
            With combogrupo
                .DataSource = grupo
                .DisplayMember = "nombre_grupo"
                .ValueMember = "nombre_grupo"

            End With
        End If





    End Sub

    Sub cargarInstitutosSegunDep(combo As ComboBox, departamento As ComboBox)
        Dim instituto As DataTable = Execute("select nombre_instituto from instituto WHERE departamento = " & Chr(34) & departamento.Text & Chr(34) & "")
        If instituto.Rows.Count = 0 Then
            combo.DataSource = Nothing
            Return
        End If
        If instituto.Rows.Count > 0 Then
            With combo
                .DataSource = instituto
                .DisplayMember = "nombre_instituto"
                .ValueMember = "nombre_instituto"

            End With
        End If
    End Sub

    Sub cargarGrupos(combo As ComboBox)
        Dim grupo As DataTable = Execute("select nombre_grupo from grupo")
        If grupo.Rows.Count = 0 Then
            combo.DataSource = Nothing
            Return
        End If
        If grupo.Rows.Count > 0 Then
            With combo
                .DataSource = grupo
                .DisplayMember = "Nombre Grupo"
                .ValueMember = "nombre_grupo"

            End With
        End If
    End Sub


    Sub cargarMateriasProfesoSegunGrupoInsDep(combo As ComboBox, grupo As ComboBox, ins As ComboBox, dep As ComboBox)
        Dim materias As DataTable = Execute("select m.nombre_materia from materia m, tiene t INNER JOIN grupo g ON t.id_grupo = g.id_grupo INNER JOIN instituto i ON i.id_instituto = g.id_instituto  WHERE t.id_materia = m.id_materia AND g.nombre_grupo = " & Chr(34) & grupo.Text & Chr(34) & " AND i.nombre_instituto = " & Chr(34) & ins.Text & Chr(34) & " AND i.departamento = " & Chr(34) & dep.Text & Chr(34))


        If materias.Rows.Count > 0 Then
            With combo
                .DataSource = materias
                .DisplayMember = "nombre_materia"
                .ValueMember = "nombre_materia"

            End With

        Else

            combo.DataSource = Nothing
            Return

        End If


    End Sub


    Sub CargarGrupoSegunInstituto(combogrupo As ComboBox, instituto As ComboBox)

        Dim grupo As DataTable = Execute("SELECT g.nombre_grupo FROM grupo g JOIN instituto i ON i.id_instituto = g.id_instituto WHERE i.nombre_instituto = " & Chr(34) & instituto.Text & Chr(34))


        If grupo.Rows.Count = 0 Then
            combogrupo.DataSource = Nothing
            Return
        End If
        If grupo.Rows.Count > 0 Then
            With combogrupo
                .DataSource = grupo
                .DisplayMember = "nombre_grupo"
                .ValueMember = "nombre_grupo"

            End With
        End If





    End Sub
    ' check list



    Public Function cargarcheckListMaterias(consulta2 As String, chk As CheckedListBox, tabla As String) As Boolean
        dt = New Data.DataTable
        Try

            Execute(consulta2)

            chk.DataSource = dt
            chk.DisplayMember = tabla
            Return True

        Catch ex As Exception

            MessageBox.Show("En el DataGridView " & chk.Text & " se produjo un error en el relleno de este: " + ex.Message)

            Return False

        Finally

            conexion.Close()

        End Try

    End Function


    Public Function AsignarAlumnosConProfesor(consulta2 As String, tabla As String) As Boolean
        dt = New Data.DataTable

        Execute(consulta2)

        For Each dr As DataRow In dt.Rows

            Dim result As String = dr("id_alumno").ToString


            conexion.Open()
            Try


                comando.CommandText = "SELECT * FROM alumno WHERE id_alumno =" & Chr(34) & result & Chr(34)
                read = comando.ExecuteReader
                read.Read()
                MsgBox(read.Item(0).ToString.Trim)

            Catch ex As Exception
                MsgBox("N°Error XXX: Error al ingresar el alumno ." & ex.ToString)
            Finally
                conexion.Close()

            End Try






        Next

        MessageBox.Show("Inserted Successfully")

    End Function





    ' fin

    ' DATAGRID



    Public Function LlenarDgv(consulta As String, dgv As DataGridView) As Boolean
        dt = New Data.DataTable
        Try

            Execute(consulta)

            dgv.DataSource = dt

            Return True

        Catch ex As Exception

            MessageBox.Show("En el DataGridView " & dgv.Text & " se produjo un error en el relleno de este: " + ex.Message)

            Return False

        Finally

            conexion.Close()

        End Try

    End Function

    ' CARGAR TIPO DE TAREAS

    Sub hpTipoTareas(combo As ComboBox)
        Dim instituto As DataTable = Execute("select nombre_tarea from tareas WHERE NOT id_tarea = '3' ORDER BY id_tarea ASC
")
        If instituto.Rows.Count = 0 Then
            combo.DataSource = Nothing
            Return
        End If
        If instituto.Rows.Count > 0 Then
            With combo
                .DataSource = instituto
                .DisplayMember = "nombre_tarea"
                .ValueMember = "nombre_tarea"

            End With
        End If
    End Sub

    ' CARGAR INSTITUTO AL CUAL DICTA CLASE EL PROFESOR PARA FILTRAR MEJOR Y NO MOSTRAR TODOS LOS GRUPOS O GRUPOS REPETIDOS XDDD


    Sub hpCargarInstituto(combo As ComboBox)
        Dim instituto As DataTable = Execute("SELECT DISTINCT i.nombre_instituto, i.id_instituto FROM dicta d INNER JOIN grupo g ON g.nombre_grupo = d.nombre_grupo INNER JOIN instituto i ON g.id_instituto = i.id_instituto WHERE d.ci_profesor = " & Chr(34) & Login.txtUsuario.Text & Chr(34) & "")
        If instituto.Rows.Count = 0 Then
            combo.DataSource = Nothing
            Return
        End If
        If instituto.Rows.Count > 0 Then
            With combo
                .DataSource = instituto
                .DisplayMember = "nombre_instituto"
                .ValueMember = "nombre_instituto"

            End With
        End If
    End Sub


    Sub hpCargarGrupo(combo As ComboBox)
        Dim grupo As DataTable = Execute("SELECT DISTINCT d.nombre_grupo FROM dicta d INNER JOIN grupo g ON g.nombre_grupo = d.nombre_grupo INNER JOIN instituto i ON g.id_instituto = i.id_instituto WHERE d.ci_profesor = " & Chr(34) & Login.txtUsuario.Text & Chr(34) & " AND i.nombre_instituto = " & Chr(34) & HomeProfesor.cbInstituto.Text & Chr(34) & "")
        If grupo.Rows.Count = 0 Then
            combo.DataSource = Nothing
            Return
        End If
        If grupo.Rows.Count > 0 Then
            With combo
                .DataSource = grupo
                .DisplayMember = "nombre_grupo"
                .ValueMember = "nombre_grupo"

            End With
        End If
    End Sub




    Sub CargarComboDep(combo As ComboBox)
        Dim instituto As DataTable = Execute("SELECT DISTINCT departamento FROM instituto WHERE estado_instituto = 't'")
        If instituto.Rows.Count = 0 Then
            combo.DataSource = Nothing
            Return
        End If
        If instituto.Rows.Count > 0 Then
            With combo
                .DataSource = instituto
                .DisplayMember = "departamento"
                .ValueMember = "departamento"

            End With
        End If
    End Sub

    Sub Historial()




    End Sub
















#End Region

#Region "Modificar"



    Sub CargarDatosInstituto()
        Dim estado As String
        Dim tienedatos As Boolean = False
        Dim sql As String



        If HomeAdministrador.txtIdInstituto.Text = "" Then
            MsgBox("Para cargar datos tendra que ingresar un ID")

        Else

            conexion.Open()

            Try
                comando.CommandText = "SELECT i.nombre_instituto, i.direccion, i.mail, i.departamento, t.telefono, i.estado_instituto FROM telefono_instituto t JOIN instituto i ON i.id_instituto= t.id_instituto WHERE i.id_instituto =" & Chr(34) & HomeAdministrador.txtIdInstituto.Text & Chr(34)
                read = comando.ExecuteReader
                read.Read()
                If read.HasRows Then

                    HomeAdministrador.txtNombreInstituto.Text = read("nombre_instituto")
                    HomeAdministrador.txtDirIns.Text = read("direccion")
                    HomeAdministrador.txtEmailIns.Text = read("mail")
                    HomeAdministrador.txtTelefonoIns.Text = read("telefono")
                    HomeAdministrador.cbDepartamentoIns.SelectedItem = read("departamento")
                    nombre_Anterior = read("nombre_instituto")
                    depAnt = read("departamento")
                Else

                    MsgBox("ERROR N°XXX: Instituto no encontrado, ingrese ID correcto.")

                    Return

                End If

            Catch ex As Exception

                MsgBox("Error N°xxx: Error al cargar datos de institutos" + ex.Message)
            Finally
                conexion.Close()
            End Try


        End If
    End Sub


    Sub ModificarInstituto()
        Dim sentencia, sentencia2 As String
        Dim corrins As Boolean = False

        Dim sql As String

        If HomeAdministrador.txtIdInstituto.Text = "" Or HomeAdministrador.txtNombreInstituto.Text = "" Or HomeAdministrador.txtDirIns.Text = "" Or HomeAdministrador.txtEmailIns.Text = "" Or HomeAdministrador.txtEmailIns.Text = "" Or HomeAdministrador.cbDepartamentoIns.Text = "" Then
            MsgBox("No se permite ingresar datos vacios, ingrese ")

            Return
        ElseIf HomeAdministrador.validacionMAIL = False Then

            MsgBox("Error con el email.")
            Return

        Else



            ' Ahora comprobamos que ese Instituto no este en el mismo departamento




            ' Comprobacion 1  

            conexion.Open()




            Try


                sql = "SELECT id_instituto FROM instituto WHERE nombre_instituto = " & Chr(34) & HomeAdministrador.txtNombreInstituto.Text & Chr(34) & " AND departamento = " & Chr(34) & HomeAdministrador.cbDepartamentoIns.Text & Chr(34) & " EXCEPT SELECT id_instituto  FROM instituto WHERE nombre_instituto = " & Chr(34) & nombre_Anterior & Chr(34) & " AND departamento = " & Chr(34) & depAnt & Chr(34)

                comando.Connection = conexion
                    comando.CommandText = sql
                    read = comando.ExecuteReader()

                If read.HasRows Then

                    corrins = True

                Else
                    corrins = False

                End If


                Catch ex As Exception
                    MsgBox("ERROR XXX: Falla al corroborar el Instituto al modificar los datos.")

                Finally
                    conexion.Close()
                End Try

        End If



        If corrins = True Then
            MsgBox("Error N° XXX No puede ingresar el mismo instituto en un departamento")
            Return
        Else



            Try

                sentencia = "UPDATE instituto SET nombre_instituto = " & Chr(34) & HomeAdministrador.txtNombreInstituto.Text & Chr(34) & ", direccion = " & Chr(34) & HomeAdministrador.txtDirIns.Text & Chr(34) & ", mail = " & Chr(34) & HomeAdministrador.txtEmailIns.Text & Chr(34) & ", departamento = " & Chr(34) & HomeAdministrador.cbDepartamentoIns.Text & Chr(34) & " WHERE id_instituto = " & Chr(34) & HomeAdministrador.txtIdInstituto.Text & Chr(34)

                Execute(sentencia)

                sentencia2 = "UPDATE telefono_instituto SET telefono = " & Chr(34) & HomeAdministrador.txtTelefonoIns.Text & Chr(34) & " WHERE id_instituto = " & Chr(34) & HomeAdministrador.txtIdInstituto.Text & Chr(34)

                Execute(sentencia2)

                MsgBox("Datos modificados correctamente!")


                LimpiarTextBox(HomeAdministrador.PanelInstitutos)

                Dim consulta As String = "SELECT i.id_instituto, i.nombre_instituto, i.direccion, i.mail, i.departamento, t.telefono, i.estado_instituto FROM telefono_instituto t JOIN instituto i ON i.id_instituto= t.id_instituto where i.estado_instituto = 't'"

                LlenarDgv(consulta, HomeAdministrador.dgvInstitutos)


            Catch ex As Exception

                MsgBox("Error N°xxx: Error al modificar datos de institutos" + ex.Message)
            Finally

            End Try




        End If






    End Sub

    Sub CargarDatosGrupo()
        Dim estado As String
        Dim sql As String
        Dim verificadorgru As Boolean = False ' VERIFICADOR DE LA EXISTENCIA DEL GRUPO


        If HomeAdministrador.txtIdGrupo.Text = "" Then
                MsgBox("Para cargar datos, tendra que ingresar un ID en la parte superior")
            Return


        Else


            ' BUSCA EL ID DEL   INSTITUTO -----------------------------------

            conexion.Open()

            Try
                comando.CommandText = "SELECT id_instituto FROM instituto WHERE nombre_instituto = " & Chr(34) & HomeAdministrador.cbInstitutoGrupos.Text & Chr(34) & "AND departamento = " & Chr(34) & HomeAdministrador.cbDepInsGrupos.Text & Chr(34)
                read = comando.ExecuteReader
                read.Read()
                id_instituto = read.Item(0).ToString.Trim


            Catch ex As Exception
                MsgBox("ERROR XXX: Falla al obtener el id del instituto.")

            Finally
                conexion.Close()
            End Try


            ' buscamos el nombre del instituto
            conexion.Open()

            Try
                comando.CommandText = "SELECT nombre_instituto FROM instituto WHERE id_instituto = " & Chr(34) & id_instituto & Chr(34) & " AND departamento = " & Chr(34) & HomeAdministrador.cbDepInsGrupos.Text & Chr(34)
                read = comando.ExecuteReader
                read.Read()
                nombreins = read.Item(0).ToString.Trim


            Catch ex As Exception
                MsgBox("Error N°XXX Error al buscar el Instituto relacionado con el grupo.")
            Finally
                conexion.Close()
            End Try


            conexion.Open()

                Try
                    comando.CommandText = "SELECT nombre_grupo, orientacion, id_instituto, ano_lectivo, turno FROM grupo WHERE id_instituto = " & Chr(34) & id_instituto & Chr(34) & " AND id_grupo = " & Chr(34) & HomeAdministrador.txtIdGrupo.Text & Chr(34)
                    read = comando.ExecuteReader
                    read.Read()
                    If read.HasRows Then

                        HomeAdministrador.txtNombreGrupo.Text = read("nombre_grupo")
                        HomeAdministrador.txtOrientacionGrupo.Text = read("orientacion")
                        MsgBox(id_instituto)
                        HomeAdministrador.cbInstitutoGrupos.SelectedItem = (nombreins)

                        HomeAdministrador.txtTurnoGrupo.Text = read("turno")
                    nombre_Anterior = read("nombre_grupo")
                Else

                        MsgBox("ERROR N°XXX: Grupo no encontrado, ingrese nombre de grupo correcto correcto.")

                    End If

                Catch ex As Exception

                    MsgBox("Error N°xxx: Error al cargar datos de grupo" + ex.Message)
                Finally
                    conexion.Close()
                End Try


            End If




    End Sub



    Sub ModificarGrupo()
        Dim IDS
        Dim sentencia As String
        Dim año_lectivo As String
        año_lectivo = DateTime.Today.Year
        Dim verificadorgru As Boolean = False
        Dim sql As String

        If HomeAdministrador.txtNombreGrupo.Text = "" Or HomeAdministrador.txtOrientacionGrupo.Text = "" Or HomeAdministrador.cbInstitutoGrupos.Text = "" Or HomeAdministrador.txtTurnoGrupo.Text = "" Or HomeAdministrador.txtIdGrupo.Text = "" Then
            MsgBox("No se permite ingresar datos vacios, ingrese ")

        Else


            ' BUSCA EL ID DEL   INSTITUTO -----------------------------------

            conexion.Open()

            Try
                comando.CommandText = "SELECT id_instituto FROM instituto WHERE nombre_instituto = " & Chr(34) & HomeAdministrador.cbInstitutoGrupos.Text & Chr(34) & "AND departamento =" & Chr(34) & HomeAdministrador.cbDepInsGrupos.Text & Chr(34)
                read = comando.ExecuteReader
                read.Read()
                IDS = read.Item(0).ToString.Trim


            Catch ex As Exception
                MsgBox("ERROR XXX: Falla al obtener el id del instituto.")

            Finally
                conexion.Close()
            End Try

            ' AHORA VERIFICAREMOS QUE L NOMBRE DLE GRUPO QUE INGRESO NO ESTE YA EN ESE INSTITUTO
            MsgBox("ids:" + id_instituto)
            MsgBox(nombre_Anterior)
            conexion.Open()
            Try

                sql = " SELECT nombre_grupo FROM grupo WHERE id_instituto = " & Chr(34) & id_instituto & Chr(34) & " AND nombre_grupo = " & Chr(34) & HomeAdministrador.txtNombreGrupo.Text & Chr(34) & " EXCEPT SELECT nombre_grupo  FROM grupo WHERE nombre_grupo = " & Chr(34) & nombre_Anterior & Chr(34)
                comando.Connection = conexion
                comando.CommandText = Sql
                read = comando.ExecuteReader()

                If read.HasRows Then

                    verificadorgru = True
                Else
                    verificadorgru = False


                End If
            Catch ex As Exception
                MsgBox("Error N°xxx: Error al verificar el nombre del grupo que ingreso" + ex.Message)

            Finally

                conexion.Close()
            End Try


            If verificadorgru = True Then
                MsgBox("Error N°XXX El nombre que desea actualizar ya se encuentra en uso.")
                MsgBox("nombre antiguo:" + nombre_Anterior)
                MsgBox("nombre actual" + HomeAdministrador.txtNombreGrupo.Text)

                Return
            Else

                ' AHORA ACTUALIZAMOS LOS DATOS 
                Try

                    sentencia = "UPDATE grupo SET nombre_grupo = " & Chr(34) & HomeAdministrador.txtNombreGrupo.Text & Chr(34) & ", orientacion = " & Chr(34) & HomeAdministrador.txtOrientacionGrupo.Text & Chr(34) & ", ano_lectivo = " & Chr(34) & año_lectivo & Chr(34) & ", turno = " & Chr(34) & HomeAdministrador.txtTurnoGrupo.Text & Chr(34) & " WHERE id_grupo = " & Chr(34) & HomeAdministrador.txtIdGrupo.Text & Chr(34)
                    MsgBox(HomeAdministrador.txtOrientacionGrupo.Text)
                    Execute(sentencia)


                    MsgBox("Datos modificados correctamente!")
                    LimpiarTextBox(HomeAdministrador.PanelGrupos)
                Catch ex As Exception

                    MsgBox("Error N°xxx: Error al modificar datos de grupos" + ex.Message)
                Finally


                End Try

            End If

        End If



    End Sub



    Sub CargarDatosAlumno()

        Dim estado As String
        Dim sql As String
        Dim verificadorAlumno As Boolean = False ' VERIFICADOR DE LA EXISTENCIA DEL ALUMNO
        Dim cedula As Boolean = False
        Dim total As Integer
        Dim numeroci As Integer
        Dim tel2 As Boolean = False



        '' BUSCA EL ID DEL   INSTITUTO -----------------------------------

        'conexion.Open()

        'Try
        '    comando.CommandText = "SELECT id_instituto FROM instituto WHERE nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsAlumno.Text & Chr(34) & "AND departamento = " & Chr(34) & HomeAdministrador.cbDepInsAlum.Text & Chr(34)
        '    read = comando.ExecuteReader
        '    read.Read()
        '    id_instituto = read.Item(0).ToString.Trim


        'Catch ex As Exception
        '    MsgBox("ERROR XXX: Falla al obtener el id del instituto.")

        'Finally
        '    conexion.Close()
        'End Try


        '' buscamos el nombre del instituto
        'conexion.Open()

        'Try
        '    comando.CommandText = "SELECT nombre_instituto FROM instituto WHERE id_instituto = " & Chr(34) & id_instituto & Chr(34)
        '    read = comando.ExecuteReader
        '    read.Read()
        '    nombreins = read.Item(0).ToString.Trim


        'Catch ex As Exception
        '    MsgBox("Error N°XXX Error al buscar el Instituto relacionado con el grupo.")
        'Finally
        '    conexion.Close()
        'End Try



        If HomeAdministrador.txtCi.Text = "" Then
            MsgBox("Para cargar datos, tendra que ingresar una CI.")
            Return


        Else
            ciAntiguaAl = HomeAdministrador.txtCi.Text
            ' VERIFICAMOS QUE LA CEDULA SEA URUGUAYA

            Try
                numeroci = Int32.Parse(ciAntiguaAl)
                For i = 0 To 6 Step 1
                    numeroci = Int32.Parse(ciAntiguaAl(i))

                    Select Case i
                        Case 0
                            numeroci = numeroci * 2
                        Case 1
                            numeroci = numeroci * 9
                        Case 2
                            numeroci = numeroci * 8
                        Case 3
                            numeroci = numeroci * 7
                        Case 4
                            numeroci = numeroci * 6
                        Case 5
                            numeroci = numeroci * 3
                        Case 6
                            numeroci = numeroci * 4
                    End Select
                    total = total + numeroci
                Next

                If total Mod 10 + Int32.Parse(ciAntiguaAl(7)) = 10 Then
                    cedula = True
                Else
                    MsgBox("N°Error XXX: Ingrese una Cedula valida.")
                End If
            Catch ex As Exception
                MsgBox("N°Error XXX: Ingrese una Cedula valida." + ex.Message)
            End Try

            If cedula = True Then

                ' AHORA VERIFICAMOS QUE EL ALUMNO EXISTA

                conexion.Open()
                Try


                    sql = "SELECT a.ci FROM alumno a,  persona p WHERE  p.ci = a.ci AND a.ci = " & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34) & " AND p.estado = 't'"
                    comando.Connection = conexion
                    comando.CommandText = sql
                    read = comando.ExecuteReader()

                    If read.HasRows Then

                        verificadorAlumno = True
                    Else
                        verificadorAlumno = False


                    End If
                Catch ex As Exception
                    MsgBox("Error N°xxx: Error al buscar el alumno." + ex.Message)
                Finally
                    conexion.Close()
                End Try



                If verificadorAlumno = True Then
                    ' Ahora verificamos si tiene uno o dos telefonos 

                    Dim tiene As String

                    conexion.Open()

                    Try
                        comando.CommandText = "SELECT telefono_sec FROM persona WHERE ci = " & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34)
                        read = comando.ExecuteReader
                        read.Read()
                        tiene = read.Item(0).ToString.Trim


                    Catch ex As Exception
                        MsgBox("ERROR XXX: Falla al obtener el id del instituto.")

                    Finally
                        conexion.Close()
                    End Try


                    If tiene = "" Then
                        HomeAdministrador.txtTel2Al.Visible = False
                        HomeAdministrador.lblTelSec.Visible = False

                    Else
                        HomeAdministrador.txtTel2Al.Visible = True
                        HomeAdministrador.lblTelSec.Visible = True
                    End If


                    ' Cargamos los datos del aluumno

                    HomeAdministrador.lblMateriasAlumno.Text = "Materias que asiste el alumno."
                    conexion.Open()

                    Try
                        comando.CommandText = "SELECT DISTINCT i.departamento, g.nombre_grupo, a.nro_lista, p.ci, p.nombre, p.apellido, p.telefono, p.telefono_sec, p.fch_nac, p.sexo, p.direccion, p.mail, p.departamento, i.nombre_instituto  FROM persona p INNER JOIN alumno k ON p.ci = k.ci INNER JOIN asiste a ON k.id_alumno = a.id_alumno INNER JOIN grupo g ON a.id_grupo = g.id_grupo INNER JOIN instituto i ON i.id_instituto = g.id_instituto WHERE k.ci = " & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34)
                        read = comando.ExecuteReader
                        read.Read()
                        If read.HasRows Then
                            HomeAdministrador.cbDepInsAlum.SelectedItem = read.Item(0).ToString.Trim
                            depAnt = read.Item(0).ToString.Trim
                            HomeAdministrador.cbGrupoAlum.SelectedItem = read.Item(1).ToString.Trim
                            grupoAntiguo = read.Item(1).ToString.Trim
                            HomeAdministrador.txtNumeroLista.Text = read.Item(2).ToString.Trim
                            HomeAdministrador.txtCi.Text = read.Item(3).ToString.Trim
                            ciAntiguaAl = read.Item(3).ToString.Trim   ' Aca capturamos la cedula antigua del alumno
                            HomeAdministrador.txtNombre.Text = read.Item(4).ToString.Trim
                            HomeAdministrador.txtApellido.Text = read.Item(5).ToString.Trim
                            HomeAdministrador.txtTelefono.Text = read.Item(6).ToString.Trim
                            HomeAdministrador.txtTel2Al.Text = read.Item(7).ToString.Trim
                            HomeAdministrador.dtpFechaNac.Value = read.Item(8).ToString.Trim
                            HomeAdministrador.cbSexo.SelectedItem = read.Item(9).ToString.Trim
                            HomeAdministrador.txtDireccion.Text = read.Item(10).ToString.Trim
                            HomeAdministrador.txtEmail.Text = read.Item(11).ToString.Trim
                            HomeAdministrador.cbDepartamento.SelectedItem = read.Item(12).ToString.Trim
                            HomeAdministrador.cbInsAlumno.SelectedItem = read.Item(13).ToString.Trim
                            ins_anterior = read.Item(13).ToString.Trim



                        Else

                            MsgBox("ERROR N°XXX: Alumno no encontrado, ingrese un alumno valido.")

                        End If

                    Catch ex As Exception

                        MsgBox("Error N°xxx: Error al cargar datos de grupo" + ex.Message)
                    Finally
                        conexion.Close()
                    End Try


                    ' Cargamos las materias que asiste el alumno


                    Dim consulta2 As String = "SELECT m.nombre_materia FROM materia m INNER JOIN asiste a ON m.id_materia = a.id_materia INNER JOIN alumno k ON a.id_alumno = k.id_alumno INNER JOIN grupo g ON a.id_grupo = g.id_grupo INNER JOIN instituto i

ON g.id_instituto = i.id_instituto WHERE i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsAlumno.Text & Chr(34) & " AND i.departamento = " & Chr(34) & HomeAdministrador.cbDepInsAlum.Text & Chr(34) & " AND g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoAlum.Text & Chr(34) & " AND k.ci = " & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34) & "  AND a.estado_asiste = 't'"

                    Dim tabla = "nombre_materia"
                    cargarcheckListMaterias(consulta2, HomeAdministrador.CheckedListBox1, tabla)
















                Else
                    MsgBox("ERROR N°XXX: Alumno no encontrado, ingrese un alumno valido.")


                End If

            End If

        End If










    End Sub



    Sub ModificarAlumno()

        Dim cedula As Boolean = False
        Dim total As Integer
        Dim numeroci As Integer
        Dim fechaNacArmada As String
        Dim cedulaActu As Char() = HomeAdministrador.txtCi.Text

        Dim CorrAlumno As Boolean = False

        Dim sql As String

        'COMPROBAMOS LA EDAD EDAD
        Dim edadA As String
        edadA = DateDiff("yyyy", HomeAdministrador.dtpFechaNac.Value, DateTime.Now).ToString() ' PARA COMPROBAR LA EDAD  CON EL AÑO ACTUAL
        fechaNacArmada = HomeAdministrador.dtpFechaNac.Value.ToString("MM/dd/yyyy")

        If HomeAdministrador.txtCi.Text = "" Or HomeAdministrador.txtNombre.Text = "" Or HomeAdministrador.txtApellido.Text = "" Or HomeAdministrador.txtTelefono.Text = "" Or HomeAdministrador.txtDireccion.Text = "" Or HomeAdministrador.cbDepartamento.Text = "" Or HomeAdministrador.cbSexo.Text = "" Or HomeAdministrador.dtpFechaNac.Text = "" Or HomeAdministrador.cbGrupoAlum.Text = "" Or HomeAdministrador.txtNumeroLista.Text = "" Then
            MsgBox("Rellene todos los datos!.")
            Return
        ElseIf ciAntiguaAl <> HomeAdministrador.txtCi.Text Then
            MsgBox("Ingrese la misma cedula!.")
            Return
        Else


            If edadA >= 15 Then



                Try
                    numeroci = Int32.Parse(cedulaActu)
                    For i = 0 To 6 Step 1
                        numeroci = Int32.Parse(cedulaActu(i))

                        Select Case i
                            Case 0
                                numeroci = numeroci * 2
                            Case 1
                                numeroci = numeroci * 9
                            Case 2
                                numeroci = numeroci * 8
                            Case 3
                                numeroci = numeroci * 7
                            Case 4
                                numeroci = numeroci * 6
                            Case 5
                                numeroci = numeroci * 3
                            Case 6
                                numeroci = numeroci * 4
                        End Select
                        total = total + numeroci
                    Next

                    If total Mod 10 + Int32.Parse(cedulaActu(7)) = 10 Then
                        cedula = True
                    Else
                        MsgBox("N°Error XXX: Ingrese una Cedula valida.")
                        Return
                    End If
                Catch
                    MsgBox("N°Error XXX: Ingrese una Cedula valida.")
                End Try
            Else
                MsgBox("N°Error XXX: Alumno debe ser mayor a 16.")
            End If




            ''-------------------------------------------------------------------
            '' Comprobamos que ese Alumno este asistiendo a un grupo

            'conexion.Open()
            'Try


            '    Try

            '        sql = "SELECT s.* from asiste s JOIN alumno a ON s.ci_alumno = a.ci_alumno WHERE s.ci_alumno = " & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34) & " AND a.estado_alumno = 't'"

            '        comando.Connection = conexion
            '        comando.CommandText = sql
            '        read = comando.ExecuteReader()

            '    Catch ex As Exception

            '        MsgBox("ERROR XXX: Falla al corroborar la existencia del alumno.")


            '    End Try


            '    If read.HasRows Then  ' Si el data reader tiene filas (datos)----

            '        CorrAlumno = True

            '    Else
            '        CorrAlumno = False
            '    End If


            'Catch ex As Exception
            '    MsgBox("Error N°XXX al comprobar la existencia del alumno" + ex.Message)
            'Finally
            '    conexion.Close()
            'End Try


        End If


        If cedula = True Then

            Dim sentencia As String
            Dim estado_grupo As String
            Dim id As String

            Try

                '  Verificamos si el grupo esta activo

                conexion.Open()

                Try
                    comando.CommandText = "SELECT g.estado_grupo FROM grupo g, instituto i WHERE g.id_instituto = i.id_instituto AND i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsAlumno.Text & Chr(34) & " AND i.departamento = " & Chr(34) & HomeAdministrador.cbDepInsAlum.Text & Chr(34) & " AND g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoAlum.Text & Chr(34) & "
"
                    read = comando.ExecuteReader
                    read.Read()
                    estado_grupo = read.Item(0).ToString.Trim
                Catch ex As Exception
                    MsgBox("ERROR XXX: Falla al obtener el id de grupo." + ex.Message)
                    Return

                Finally
                    conexion.Close()
                End Try


                ' Fin busca de estado del grupo.

                ' Si el usuario cambio de grupo para el alumno por lo tanto el alumno se dara de baja en el grupo anterior que tenia
                ' Si el grupo es igual al anterior entonces modificara los datos menos el grupo y lo demas




                If grupoAntiguo = HomeAdministrador.cbGrupoAlum.Text And ins_anterior = HomeAdministrador.cbInsAlumno.Text And depAnt = HomeAdministrador.cbDepInsAlum.Text Then



                    ' AHORA ACTUALIZAMOS LOS DATOS SIN ACTUALIZAR AL GRUPO
                    Try
                        ' Buscamos el ID del alumno



                        conexion.Open()

                        Try
                            comando.CommandText = "SELECT id_alumno FROM alumno WHERE ci = " & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34)
                            read = comando.ExecuteReader
                            read.Read()
                            id = read.Item(0).ToString.Trim


                        Catch ex As Exception
                            MsgBox("ERROR XXX: Falla al obtener el id del alumno.")
                            Return
                        Finally
                            conexion.Close()
                        End Try


                        ' Modificamos la tabla de personas
                        Try

                            sentencia = "UPDATE persona SET nombre = " & Chr(34) & HomeAdministrador.txtNombre.Text & Chr(34) & ", apellido = " & Chr(34) & HomeAdministrador.txtApellido.Text & Chr(34) & ", fch_nac = " & Chr(34) & fechaNacArmada & Chr(34) & ", sexo = " & Chr(34) & HomeAdministrador.cbSexo.Text & Chr(34) & ", direccion = " & Chr(34) & HomeAdministrador.txtDireccion.Text & Chr(34) & ", mail = " & Chr(34) & HomeAdministrador.txtEmail.Text & Chr(34) & ", departamento = " & Chr(34) & HomeAdministrador.cbDepartamento.Text & Chr(34) & ", telefono = " & Chr(34) & HomeAdministrador.txtTelefono.Text & Chr(34) & " , telefono_sec = " & Chr(34) & HomeAdministrador.txtTel2Al.Text & Chr(34) & " WHERE ci = " & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34)
                            Execute(sentencia)

                            sentencia = "UPDATE asiste SET nro_lista = " & Chr(34) & HomeAdministrador.txtNumeroLista.Text & Chr(34) & " WHERE id_alumno = " & Chr(34) & id & Chr(34)
                            Execute(sentencia)

                            MsgBox("Datos modificados correctamente.")
                            LimpiarTextBox(HomeAdministrador.PanelAlumnos)
                            HomeAdministrador.txtTel2Al.Visible = False
                            HomeAdministrador.lblTelSec.Visible = False
                            HomeAdministrador.btnOtroTelOcultar.Visible = False
                        Catch ex As Exception

                            MsgBox("Error N°xxx: Error al modificar los datos del alumno" + ex.Message)
                        End Try




                    Catch ex As Exception
                        MsgBox("Error N°XXX al modificar el telefono de un alumno" + ex.Message)
                    End Try







                ElseIf estado_grupo = "f" Then
                    MsgBox("No se puede cambiar a un alumno a un grupo dado de baja.")
                    Return

                Else

                    ' Buscamos el ID del Instituto.

                    conexion.Open()

                    Try
                        comando.CommandText = "SELECT id_instituto FROM instituto WHERE nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsAlumno.Text & Chr(34) & "AND departamento = " & Chr(34) & HomeAdministrador.cbDepInsAlum.Text & Chr(34)
                        read = comando.ExecuteReader
                        read.Read()
                        id_instituto = read.Item(0).ToString.Trim


                    Catch ex As Exception
                        MsgBox("ERROR XXX: Falla al obtener el id del instituto.")
                        Return
                    Finally
                        conexion.Close()
                    End Try



                    '  Buscamos el ID del Grupo.

                    conexion.Open()

                    Try
                        comando.CommandText = "select id_grupo FROM grupo  WHERE nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoAlum.Text & Chr(34) & " AND id_instituto = " & Chr(34) & id_instituto & Chr(34) & " AND estado_grupo = 't'"
                        read = comando.ExecuteReader
                        read.Read()
                        id_grupo = read.Item(0).ToString.Trim
                    Catch ex As Exception
                        MsgBox("ERROR XXX: Falla al obtener el id de grupo." + ex.Message)
                        Return

                    Finally
                        conexion.Close()
                    End Try


                    ' Fin busca de ID de Grupo.

                    ' Primero cambiamos la variable de estado de asistencia a f ya que se dio de abaja de ese grupo y todas sus materias relacionadas pero en si NO SE ELIMINA se la base de datos.
                    Dim id_2 As String
                    conexion.Open()

                    Try
                        comando.CommandText = "SELECT id_alumno FROM alumno WHERE ci = " & Chr(34) & HomeAdministrador.txtCi.Text & Chr(34)
                        read = comando.ExecuteReader
                        read.Read()
                        id_2 = read.Item(0).ToString.Trim


                    Catch ex As Exception
                        MsgBox("ERROR XXX: Falla al obtener el id del alumno.")
                        Return
                    Finally
                        conexion.Close()
                    End Try


                    Try

                        sentencia = "UPDATE asiste SET estado_asiste = " & Chr(34) & "f" & Chr(34) & " WHERE id_alumno = " & Chr(34) & id_2 & Chr(34)
                        Execute(sentencia)



                    Catch ex As Exception

                        MsgBox("Error N°xxx: Error al modificar los datos de asiste del alumno" + ex.Message)
                    End Try

                    ' Ahora lo insertamos en el nuevo grupo.

                    ' Ahora lo ingresamos al grupo correspondiente y a las materias que selecciono del ListBox.

                    Try

                        If HomeAdministrador.CheckedListBox1.CheckedItems.Count < 1 Then
                            MsgBox("Seleccione una materia  para que asista el alumno")
                            Return

                        Else


                            If HomeAdministrador.CheckedListBox1.Items.Count > 0 Then

                                For Each checkedItem In HomeAdministrador.CheckedListBox1.CheckedItems

                                    Dim dr As DataRowView = CType(checkedItem, DataRowView)
                                    Dim result As String = dr("nombre_materia").ToString

                                    conexion.Open()
                                    Try
                                        comando.CommandText = "select id_materia from materia where nombre_materia = " & Chr(34) & result & Chr(34) & "
"
                                        read = comando.ExecuteReader
                                        read.Read()
                                        id_materia = read.Item(0).ToString.Trim

                                    Catch ex As Exception
                                        MsgBox("N°Error XXX: Error obtener las materias del alumno." & ex.ToString)
                                    Finally
                                        conexion.Close()

                                    End Try







                                    conexion.Open()
                                    Try
                                        comando.CommandText = "insert into asiste (id_materia,id_alumno,id_grupo,nro_lista,estado_asiste)
                                                              values (" & Chr(34) & id_materia & Chr(34) & "," & Chr(34) & id_2 & Chr(34) & "," & Chr(34) & id_grupo & Chr(34) & "," & Chr(34) & HomeAdministrador.txtNumeroLista.Text & Chr(34) & "," & Chr(34) & "t" & Chr(34) & ");"




                                        comando.ExecuteNonQuery()
                                    Catch ex As Exception
                                        MsgBox("N°Error XXX: Error al ingresar el alumno en el nuevo grupo ." & ex.ToString)
                                    Finally
                                        conexion.Close()

                                    End Try





                                Next

                                MessageBox.Show("Se ingreso correctamente en el nuevo grupo al alumno.")


                                LimpiarTextBox(HomeAdministrador.PanelAlumnos)




                            End If

                        End If


                    Catch ex As Exception

                        MsgBox("Error N°xxx: Error al intentar cambiar de grupo al alumno" + ex.Message)
                    End Try





                End If



                Dim consulta As String = "SELECT DISTINCT a.nro_lista, p.ci, p.nombre, p.apellido, p.telefono, p.telefono_sec, p.fch_nac, p.sexo, p.direccion, p.mail, p.departamento  FROM persona p INNER JOIN alumno k ON p.ci = k.ci INNER JOIN asiste a ON k.id_alumno = a.id_alumno INNER JOIN grupo g ON a.id_grupo = g.id_grupo INNER JOIN instituto i ON i.id_instituto = g.id_instituto WHERE g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoAlum.Text & Chr(34) & " AND i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsAlumno.Text & Chr(34) & " AND a.estado_asiste = 't' AND i.departamento = " & Chr(34) & HomeAdministrador.cbDepInsAlum.Text & Chr(34) & ""
                LlenarDgv(consulta, HomeAdministrador.dgvAlumnos)
                HomeAdministrador.lblAlumnos.Text = "Alumnos: " & HomeAdministrador.dgvAlumnos.Rows.Count - 1
                HomeAdministrador.lblGrupo.Text = "Grupo: " & HomeAdministrador.cbGrupoAlum.Text

            Catch ex As Exception
                MsgBox("Error N°XXX: Error al actualizar la informacion del Alumno" + ex.Message)
            End Try



        Else
            MsgBox("Error N°XXX: Ci No valida.")
        End If












    End Sub

    Sub CargarDatosMateriaAsignada()

        If HomeAdministrador.txtMateriaPMaterias.Text = "" Then
            MsgBox("Erorr N° XXX Ingrese la materia para cargar datos.")

        ElseIf HomeAdministrador.cbDepInstitutoMaterias.Text = "" Then
            MsgBox("Error N° XXX Seleccione un departamento  en el combobox de Departamento de Instituto.")

        ElseIf HomeAdministrador.cbInsMaterias.Text = "" Then
            MsgBox("Error N° XXX Seleccione un Instituto en el combobox de Instituto.")

        ElseIf HomeAdministrador.cbGrupoPMaterias.Text = "" Then
            MsgBox("Error N° XXX Seleccione un grupo en el combobox de grupo.")


        Else



            conexion.Open()

            Try
                comando.CommandText = "SELECT t.id_materia, t.id_grupo, g.nombre_grupo, m.nombre_materia, t.dia, t.hora_inicio, t.hora_fin FROM grupo g INNER JOIN tiene t ON g.id_grupo = t.id_grupo INNER JOIN materia m ON m.id_materia = t.id_materia INNER JOIN instituto i ON g.id_instituto = i.id_instituto WHERE g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoPMaterias.Text & Chr(34) & " AND g.estado_grupo = 't' AND i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsMaterias.Text & Chr(34) & " AND  i.departamento = " & Chr(34) & HomeAdministrador.cbDepInstitutoMaterias.Text & Chr(34) & " AND m.nombre_materia = " & Chr(34) & HomeAdministrador.txtMateriaPMaterias.Text & Chr(34)
                read = comando.ExecuteReader
                read.Read()
                If read.HasRows Then
                    id_grupo = read("id_grupo")
                    id_materia = read("id_materia")
                    HomeAdministrador.cbGrupoPMaterias.SelectedItem = read("nombre_grupo")
                    HomeAdministrador.txtMateriaPMaterias.Text = read("nombre_materia")
                    HomeAdministrador.txtDiaMateria.Text = read("dia")
                    HomeAdministrador.dtpHoraIniM.Text = read("hora_inicio")
                    HomeAdministrador.dtpHoraFinM.Text = read("hora_fin")

                Else

                    MsgBox("ERROR N°XXX: Materia no encontrada, ingrese la informacion correctamente.")

                    Return

                End If

            Catch ex As Exception

                MsgBox("Error N°xxx: Error al cargar datos de Materia Asignada" + ex.Message)
            Finally
                conexion.Close()
            End Try


        End If
    End Sub

    Sub ModificarDatosMateriaAsignada()
        Dim sentencia As String
        Dim sql As String
        Dim corrdatos As Boolean = False

        If HomeAdministrador.txtMateriaPMaterias.Text = "" Then
            MsgBox("Erorr N° XXX Ingrese la materia para modificar datos.")

        ElseIf HomeAdministrador.cbDepInstitutoMaterias.Text = "" Then
            MsgBox("Error N° XXX Seleccione un departamento  en el combobox de Departamento de Instituto.")

        ElseIf HomeAdministrador.cbInsMaterias.Text = "" Then
            MsgBox("Error N° XXX Seleccione un Instituto en el combobox de Instituto.")

        ElseIf HomeAdministrador.cbGrupoPMaterias.Text = "" Then
            MsgBox("Error N° XXX Seleccione un grupo en el combobox de grupo.")


        Else


            conexion.Open()

            Try
                ' Verificamos los datos

                sql = "SELECT g.nombre_grupo, m.nombre_materia, t.dia, t.hora_inicio, t.hora_fin FROM grupo g INNER JOIN tiene t ON g.id_grupo = t.id_grupo INNER JOIN materia m ON m.id_materia = t.id_materia INNER JOIN instituto i ON g.id_instituto = i.id_instituto WHERE g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoPMaterias.Text & Chr(34) & " AND g.estado_grupo = 't' AND i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsMaterias.Text & Chr(34) & " AND  i.departamento = " & Chr(34) & HomeAdministrador.cbDepInstitutoMaterias.Text & Chr(34) & " AND m.nombre_materia = " & Chr(34) & HomeAdministrador.txtMateriaPMaterias.Text & Chr(34)

                comando.Connection = conexion
                comando.CommandText = sql
                read = comando.ExecuteReader()


                If read.HasRows Then

                    corrdatos = True

                Else

                    MsgBox("ERROR N°XXX: Materia no encontrada, ingrese la informacion correctamente.")

                    Return

                End If

            Catch ex As Exception

                MsgBox("Error N°xxx: Error al cargar datos de Materia Asignada" + ex.Message)
            Finally
                conexion.Close()
            End Try

            If corrdatos = True Then


                Try

                    sentencia = "UPDATE tiene SET dia = " & Chr(34) & HomeAdministrador.txtDiaMateria.Text & Chr(34) & ", hora_inicio = " & Chr(34) & HomeAdministrador.dtpHoraIniM.Text & Chr(34) & ", hora_fin = " & Chr(34) & HomeAdministrador.dtpHoraFinM.Text & Chr(34) & " WHERE id_grupo = " & Chr(34) & id_grupo & Chr(34) & " AND id_materia = " & Chr(34) & id_materia & Chr(34)
                    Execute(sentencia)

                    MsgBox("Datos actualizados correctamente.")

                    Dim consulta As String = "SELECT g.nombre_grupo, m.nombre_materia, t.dia, t.hora_inicio, t.hora_fin FROM grupo g INNER JOIN tiene t ON g.id_grupo = t.id_grupo INNER JOIN materia m ON m.id_materia = t.id_materia INNER JOIN instituto i ON g.id_instituto = i.id_instituto WHERE g.nombre_grupo = " & Chr(34) & HomeAdministrador.cbGrupoPMaterias.Text & Chr(34) & " AND g.estado_grupo = 't' AND i.nombre_instituto = " & Chr(34) & HomeAdministrador.cbInsMaterias.Text & Chr(34) & " AND  i.departamento = " & Chr(34) & HomeAdministrador.cbDepInstitutoMaterias.Text & Chr(34) & ""
                    LlenarDgv(consulta, HomeAdministrador.dgvMaterias)
                    HomeAdministrador.lblMaterias.Text = "Materias del Grupo " & HomeAdministrador.cbGrupoPMaterias.Text & ""



                Catch ex As Exception

                    MsgBox("Error N°xxx: Error al modificar los datos del alumno" + ex.Message)
                End Try

            Else
                MsgBox("ERROR N°XXX: Materia no encontrada, ingrese la informacion correctamente.")
                Return



            End If




        End If
    End Sub












#End Region
#End Region ' Blocke de Codigo del adm.


    ' CALCULO DE NOTA




    Function Formula()

        ' PROYECTO

        'Primer Entrega

        Dim consulta As String = "SELECT nota FROM califica WHERE id_tarea = '4'"
        Dim consulta2 As String = "SELECT nota FROM califica WHERE id_tarea = '5'"
        Dim consulta3 As String = "SELECT nota FROM califica WHERE id_tarea = '6'"
        Dim consulta4 As String = "SELECT (SUM(nota*1) / COUNT(nota)) as otrasnotas FROM califica WHERE id_tarea > '6'"
        dt = New Data.DataTable
        Try


            Execute(consulta)


            For Each dr As DataRow In dt.Rows
                PrimerEntregaProyecto = Convert.ToInt32(dr("nota"))
            Next

            MsgBox("LA PRIMERA ENTREGA ES: " + PrimerEntregaProyecto.ToString)

            Execute(consulta2)

            For Each dr As DataRow In dt.Rows
                SegundaEntregaProyecto = Convert.ToInt32(dr("nota"))
            Next

            MsgBox("LA SEGUNDA ENTREGA ES: " + SegundaEntregaProyecto.ToString)

            ' OBTENEMOS 3 
            Execute(consulta3)


            For Each dr As DataRow In dt.Rows
                TerceraEntregaProyecto = Convert.ToInt32(dr("nota"))
            Next


            MsgBox("TERCERA ENTREGA: " + TerceraEntregaProyecto.ToString)

            ' OBTENEMOS OTRAS NOTAS.



            Execute(consulta4)






            For Each dr As DataRow In dt.Rows
                otrasnotas = Convert.ToInt32(dr("otrasnotas"))
            Next


            MsgBox("La nota final de otras notas es: " + otrasnotas.ToString)






            MsgBox("Primer entrega: " & PrimerEntregaProyecto.ToString & ", segunda entrega: " & SegundaEntregaProyecto.ToString & ", tercera entrega: " & TerceraEntregaProyecto.ToString)


            notaproyecto = (PrimerEntregaProyecto * 0.2) + (SegundaEntregaProyecto * 0.2) + (TerceraEntregaProyecto * 0.6)


            notafinal = (notaproyecto + otrasnotas) / 2
            MsgBox("Nota final: " + notafinal.ToString)












            Return True

        Catch ex As Exception

            MessageBox.Show("Error al obtener la nota de la primera entrega del proyecto " + ex.Message)

            Return False

        Finally

            conexion.Close()

        End Try









    End Function




































End Module
