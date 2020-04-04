using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Trabajo_Final_Francia.Clases
{

    //Clase que maneja la coneccion con la base de datos
    class ConeccionBD
    {
        string cadena = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = Prueba; Integrated Security = true";
        public SqlConnection con = new SqlConnection();

        public ConeccionBD()
        {
            con.ConnectionString = cadena;
        }
        //Metodo que abre la coneccion con la base de datos y valida los usuaios que se loguean
        public void abrirBD(string user, string pass)
        {
            try
            {
                con.Open();
                Console.WriteLine("Conexcion abierta");
                SqlCommand cmd = new SqlCommand("Select Nombre, TipoUsr FROM loginBD WHERE  Usr = @user and Pass = @pass", con);
                cmd.Parameters.AddWithValue("user", user);
                cmd.Parameters.AddWithValue("pass", pass);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][1].ToString() == "admin")
                    {
                        MessageBox.Show("Logeo Admin Exitoso");
                    }

                    else if (dt.Rows[0][1].ToString() == "usuario")
                    {
                        MessageBox.Show("Logeo Usuario exitoso Exitoso");
                    }

                    else
                    {
                        MessageBox.Show("Ocurrio un error");
                    }
                }

                else
                {
                    MessageBox.Show("Usurio y/o Contraseña Incorrecta");
                }
            }

            catch (Exception e)
            {
               MessageBox.Show("Error al abrir la conexion" + e.Message);
            }
        }
        //Metodo que cierra la coneccion con la base de datos
        public void cerrarBD() 
        {
            con.Close();
            Console.WriteLine("Coneccion cerrada");
        }

    }
}
