using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace WebFinal.Base
{
    public partial class Registrarse : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE =localhost:1521/xe ; PASSWORD = 123 ; USER ID = admin2");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("REGISTRAR_CLIENTE", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                int rut = Convert.ToInt32(this.TextBox1.Text);
                int fono = Convert.ToInt32(this.TextBox4.Text);                               
                comando.Parameters.Add("c_rut", rut);
                comando.Parameters.Add("c_nombre", OracleDbType.Varchar2).Value = TextBox2.Text;
                comando.Parameters.Add("c_apellido", OracleDbType.Varchar2).Value = TextBox3.Text;
                comando.Parameters.Add("c_telefono", fono);
                comando.Parameters.Add("c_correo", OracleDbType.Varchar2).Value = TextBox5.Text;
                comando.Parameters.Add("c_contraseña", OracleDbType.Varchar2).Value = TextBox6.Text;

                comando.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El registro se guardó correctamente');", true);
                ora.Close();


                
                String body = "<body>" + "<h1>Bienvenido  a Turismo Real"+ TextBox2.Text +"  "+ TextBox3.Text +"</h1>" + "<span>Le Deseamos que pueda disfrutar de nuestros servicios</span>" + "<br/>"+ "<img src='https://scontent.fscl22-1.fna.fbcdn.net/v/t1.0-9/75349177_1177323289134059_6957283893472919552_o.jpg?_nc_cat=103&ccb=2&_nc_sid=09cbfe&_nc_ohc=usHS8wQ9nOcAX9ZpYo5&_nc_ht=scontent.fscl22-1.fna&oh=df2b5c2956a27d3d5db40947736822e5&oe=5FDD478F' style='width:200px; height:280px;'/> " + "<br/> <span>Saludos Cordiales </span>" + "<body>";

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("turismorealdepartamentos@gmail.com");
                msg.To.Add(TextBox5.Text);
                msg.Subject = "Turismo Real";
                msg.IsBodyHtml = true;
                msg.Body = body;

                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential("turismorealdepartamentos@gmail.com", "turismoreal123");
                sc.EnableSsl = true;
                sc.Send(msg);


                Server.Transfer("../Base/Iniciarsesion.aspx");


            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El registro no se guardó correctamente');", true);


            }
        }

     
    }
}