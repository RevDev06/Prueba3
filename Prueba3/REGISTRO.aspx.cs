using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba3
{
    public partial class REGISTRO : System.Web.UI.Page
    {

        String strConexion; // Cadena de conexión
        String strSQL; // Cadena de instrucción de comando en SQ
        SqlConnection conexionSQL;

        //Se utiliza para ejecutar 
        //procedimientos almacenados
        SqlCommand comandoSQL;
        //Representa una cache de memoria interna de datos 
        DataSet datos;
        //variable de tipo entero que muestra el resultado

        //objeto que verifica si existe un registro deseado o no
        Object existe;

        Boolean buscado = false;
        string conexion;
        String mensaje, mostrarMsg;



        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            


            // Cadena de caracteres a configurar para la conexión
            strConexion = "Data Source= (local);" + // Nombre del servidor
                          "Initial Catalog=bdprueba;" + // Nombre de la Base de Datos
                          "Integrated Security=True;"; // Configuración para la seguridad integrada

            // Este es otro ejemplo para la configuración en cadena para la conexión 


            // Comando en SQL para dar de alta en la tabla
            strSQL = "exec Bajas_Clientes " + (txtNombreBuscar.Text);

            // Instanciamos el objeto conexionSQL para empezar la conexión de forma física
            conexionSQL = new System.Data.SqlClient.SqlConnection(strConexion);

            try
            {
                conexionSQL.Open(); // Abrir la conexion

                // Instanciamos el objeto comandoSQL para instroducir la cadena de comando acorde
                // a la cadena de conexión
                comandoSQL = new System.Data.SqlClient.SqlCommand(strSQL, conexionSQL);
                comandoSQL.ExecuteNonQuery();

                // Ejecuta el query sin hacer una consulta 

                mensaje = "Se elimino El registro";
                mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
                Response.Write(mostrarMsg);
            }
            catch (Exception ex)
            {

                mensaje = "Error al Eliminar: ";
                mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
                Response.Write(mostrarMsg);
            }
            finally
            {
                conexionSQL.Close();
                Response.Redirect(Request.RawUrl);
            }
            //limpia todos los campos despues de que agrega un nuevo registro

            id_user.Text = "";
            nombre.Text = "";
            email.Text = "";
            edad.Text = "";
            nom_user.Text = "";
            pass.Text = "";
            txtNombreBuscar.Text = "";



        }
    

    public Boolean BuscarNombre(string id_user) { 

            // Declcaramos cadenas, una para la cadena de conexión y otra para la cadena de comandos en SQL



            // Cadena de caracteres a configurar para la conexión
            conexion = "Data Source= (local);" + // Nombre del servidor
                          "Initial Catalog=bdprueba;" + // Nombre de la Base de Datos
                          "Integrated Security=True;"; // Configuración para la seguridad integrada
                                                       //inicializamos la conexion
            conexionSQL = new SqlConnection(conexion);
            //Abrimos la conexion
            conexionSQL.Open();
            //inicializamos los comandos en sql
            //para ejecutar los procedimientos almaceados
            comandoSQL = new SqlCommand();

            comandoSQL.CommandType = CommandType.Text;

            //comando en SQL para buscar y mostrar datos de una tabla
            comandoSQL.CommandText = "SELECT * FROM usuarios WHERE id_user='" + id_user + "'";
            comandoSQL.Connection = conexionSQL;

            //ejecuta 
            existe = new Object();
            existe = comandoSQL.ExecuteScalar();

            //cerramos la conexion
            conexionSQL.Close();

            if (existe != null)
                return true;
            else
                return false;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            buscado = BuscarNombre(txtNombreBuscar.Text);
            if (buscado == true)
            {
                try
                {
                    conexionSQL = new SqlConnection(conexion);
                    conexionSQL.Open();

                    comandoSQL = new SqlCommand();
                    comandoSQL.CommandType = CommandType.Text;
                    comandoSQL.CommandText = "SELECT * FROM usuarios WHERE id_user ='" +
                                      txtNombreBuscar.Text + "'";
                    comandoSQL.Connection = conexionSQL;

                    datos = new DataSet();
                    SqlDataAdapter adaptador = new SqlDataAdapter(comandoSQL);
                    adaptador.Fill(datos, "usuarios");

                    if (datos.Tables["usuarios"].Rows.Count > 0)
                    {
                        mensaje = "USUARIO ENCONTRADO";
                        mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
                        Response.Write(mostrarMsg);

                        id_user.Text = Convert.ToString(datos.Tables["usuarios"].Rows[0]["id_user"]);
                        nombre.Text = Convert.ToString(datos.Tables["usuarios"].Rows[0]["nombre"]);
                        email.Text = Convert.ToString(datos.Tables["usuarios"].Rows[0]["email"]);
                        edad.Text = Convert.ToString(datos.Tables["usuarios"].Rows[0]["edad"]);
                        nom_user.Text = Convert.ToString(datos.Tables["usuarios"].Rows[0]["nom_user"]);
                        pass.Text = Convert.ToString(datos.Tables["usuarios"].Rows[0]["pass"]);

                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    conexionSQL.Close();
                }
            }
            else
                //MessageBox.Show("El CLIENTE no existe en la base de datos");
                mensaje = "El USUARIO no existe en la base de datos";
            mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
            Response.Write(mostrarMsg);
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            string mensaje = " ";
            string mostrarMsg = " ";

            String strConexion; // Cadena de conexión
            String strSQL; // Cadena de instrucción de comando en SQL

            // Declaramos dos objetos, uno para la conexión y otro para el comando en SQL
            System.Data.SqlClient.SqlConnection conexionSQL; // objeto llamado conexionSQL
            System.Data.SqlClient.SqlCommand comandoSQL; // objeto para utilizar el comando en SQL

            // Cadena de caracteres a configurar para la conexión
            strConexion = "Data Source=(local);" + // Nombre del servidor
                          "Initial Catalog=bdprueba;" + // Nombre de la Base de Datos
                          "Integrated Security=True;" ; // Configuración para la seguridad integrada

            // Este es otro ejemplo para la configuración en cadena para la conexión 


            // Comando en SQL para dar de alta en la tabla
            strSQL = "exec Cambios_Usuarios '" + nombre.Text +
                "' , '" + email.Text + "' , '" + edad.Text +
                "' , '" + nom_user.Text + "' , '" + pass.Text +
                "' , '" + txtNombreBuscar.Text + "'";

            // Instanciamos el objeto conexionSQL para empezar la conexión de forma física
            conexionSQL = new System.Data.SqlClient.SqlConnection(strConexion);

            try
            {
                conexionSQL.Open(); // Abrir la conexion

                // Instanciamos el objeto comandoSQL para instroducir la cadena de comando acorde
                // a la cadena de conexión
                comandoSQL = new System.Data.SqlClient.SqlCommand(strSQL, conexionSQL);
                comandoSQL.ExecuteNonQuery();

                // Ejecuta el query sin hacer una consulta 
                mensaje = "Se Modifico el registro";
                mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
                Response.Write(mostrarMsg);


            }
            catch (Exception ex)
            {

                mensaje = "Error al Modificar: " + ex.Message;
                mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
                Response.Write(mostrarMsg);

            }
            finally
            {
                conexionSQL.Close();
                Response.Redirect(Request.RawUrl);



            }
            //limpia todos los campos despues de que agrega un nuevo registro

            id_user.Text = "";
            nombre.Text = "";
            email.Text = "";
            edad.Text = "";
            nom_user.Text = "";
            pass.Text = "";
            txtNombreBuscar.Text = "";
        }

        public Boolean ValidarCampos()
        {


            if (nombre.Text == "")
            {
                mensaje = "El nombre no debe de estar vacio";
                mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
                Response.Write(mostrarMsg);
                return false;
            }

            if (email.Text == "")
            {
                mensaje = "El correo no debe de estar vacio";
                mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
                Response.Write(mostrarMsg);
                return false;
            }
            if (edad.Text == "")
            {
                mensaje = "La edad no debe de estar vacio";
                mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
                Response.Write(mostrarMsg);
                return false;
            }
            if (nom_user.Text == "")
            {
                mensaje = "El usuario no debe de estar vacio";
                mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
                Response.Write(mostrarMsg);
                return false;


            }
            if (pass.Text == "")
            {
                mensaje = "la contraseña no debe de estar vacia";
                mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
                Response.Write(mostrarMsg);
                return false;


            }
            else
                return true;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Reg_Click(object sender, EventArgs e)
        {
            Boolean valido;

            valido = ValidarCampos();
            if (valido == true)
            {



                // Cadena de caracteres a configurar para la conexión
                strConexion = "Data Source= (local);" + // Nombre del servidor
                              "Initial Catalog=bdprueba;" + // Nombre de la Base de Datos
                              "Integrated Security=True;"; // Configuración para la seguridad integrada

                // Este es otro ejemplo para la configuración en cadena para la conexión
                /* 
                strConexion = "Data Source=TELMEX-VAIO;" + 
                              "Initial Catalog=EjemploABCC;" +
                              "User=sa;" +
                              "Password=;";
                 */

                // Comando en SQL para dar de alta en la tabla
                strSQL = "INSERT INTO usuarios " +
                        "VALUES('" + nombre.Text + "','" + email.Text + "','" +
                        edad.Text + "','" + nom_user.Text + "','" + pass.Text + "')";

                // Instanciamos el objeto conexionSQL para empezar la conexión de forma física
                conexionSQL = new System.Data.SqlClient.SqlConnection(strConexion);

                try
                {
                    conexionSQL.Open(); // Abrir la conexion

                    // Instanciamos el objeto comandoSQL para instroducir la cadena de comando acorde
                    // a la cadena de conexión
                    comandoSQL = new System.Data.SqlClient.SqlCommand(strSQL, conexionSQL);
                    comandoSQL.ExecuteNonQuery();
                    mensaje = "Registro Exitoso. ";
                    mostrarMsg = "<script language='javascript'>alert('" + mensaje + "');<" + "/script>";
                    Response.Write(mostrarMsg);


                }
                catch (Exception ex)
                {
                    mensaje = "Ocurrió un error. ";
                    mostrarMsg = "<script language='javascript'>alert('" + mensaje + ex + "');<" + "/script>";
                    Response.Write(mostrarMsg);
                }
                finally
                {
                    conexionSQL.Close();

                }
                //limpia todos los campos despues de que agrega un nuevo registro


                nombre.Text = "";
                email.Text = "";
                edad.Text = "";
                nom_user.Text = "";
                pass.Text = "";


            }
        }
    }
}
