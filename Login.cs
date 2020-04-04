using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace Trabajo_Final_Francia
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
       

        //Codigo para hacer el drag a la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //textbox de usuario
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(txtUser.Text == "USERNAME")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USERNAME";
                txtUser.ForeColor = Color.DimGray;
            }
        }
        //textbox de contraseña
        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "PASSWORD")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "PASSWORD";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }
        //Boton para cerrar
        private void btnMin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Boton para minimizar
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Codigo para hacer el drag a la ventana
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        Clases.ConeccionBD logear = new Clases.ConeccionBD();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            logear.abrirBD(this.txtUser.Text, this.txtPass.Text);
            logear.cerrarBD();
            
        }
    }
}
