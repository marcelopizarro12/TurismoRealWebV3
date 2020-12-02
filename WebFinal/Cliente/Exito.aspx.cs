using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace WebFinal.Cliente
{
    public partial class Exito : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE =localhost:1521/xe ; PASSWORD = 123 ; USER ID = admin2");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Request.Cookies["Pago"] == null)
                {

                    Response.Redirect("../Base/Iniciarsesion.aspx");
                }
                else
                {
                    correo();
                    GuardarReserva();
                    guardarPago();

                }

            }



        }

        void correo()
        {


            OracleCommand comando = new OracleCommand("select correo from cliente where RUT  =" + Request.Cookies["Pago"].Values["Rut_Cliente"] + "", ora);

            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = comando;
            DataTable tb = new DataTable();
            da.Fill(tb);
            this.GridView2.DataSource = tb;
            GridView2.DataBind();
            string correo = GridView2.Rows[0].Cells[0].Text;
            HttpCookie cor = new HttpCookie("cor");
            cor.Values["correo"] = correo;
            Response.Cookies.Add(cor);

            



        }




        void GuardarReserva()
        {
            try
            {
                ora.Open();
                OracleCommand comando = new OracleCommand("REGISTRAR_RESERVA", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.Add("c_pago_reservas", OracleDbType.Int32).Value = Request.Cookies["Pago"].Values["Pago_Reserva"];
                comando.Parameters.Add("c_acomp", OracleDbType.Int32).Value = Request.Cookies["Pago"].Values["Acomp"];
                comando.Parameters.Add("c_fecha_in", OracleDbType.Date).Value = Request.Cookies["Pago"].Values["Fecha_in"];
                comando.Parameters.Add("c_fecha_out", OracleDbType.Date).Value = Request.Cookies["Pago"].Values["Fecha_out"];
                comando.Parameters.Add("c_multa", OracleDbType.Int32).Value = Request.Cookies["Pago"].Values["Multa"];
                comando.Parameters.Add("c_subtotal", OracleDbType.Int32).Value = Request.Cookies["Pago"].Values["SubTotal"];
                comando.Parameters.Add("c_rut_clie", OracleDbType.Int32).Value = Request.Cookies["Pago"].Values["Rut_Cliente"];
                comando.Parameters.Add("c_depto_id", OracleDbType.Int32).Value = Request.Cookies["Pago"].Values["Depto_Id"];
                comando.Parameters.Add("c_met_pago", OracleDbType.Int32).Value = Request.Cookies["Pago"].Values["Met_pago"];
                comando.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La Reserva se realizo correctamente');", true);


                ora.Close();
                String body = "<body>" + "<h1>Bienvenido  a Turismo Real </h1>" + "<span>Le Deseamos que pueda disfrutar de nuestros servicios</span> <br/>"+"<span>se ha registrado una reserva con exito para  las fechas:  Desde </span>" + Request.Cookies["Pago"].Values["Fecha_in"] +" <span>hasta </span>"+ Request.Cookies["Pago"].Values["Fecha_out"] + "<br/><br/> <span>Saludos Cordiales </span>" + "<body>";

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("turismorealdepartamentos@gmail.com");
                msg.To.Add(Request.Cookies["cor"].Values["correo"]);
                msg.Subject = "Turismo Real";
                msg.IsBodyHtml = true;
                msg.Body = body;

                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential("turismorealdepartamentos@gmail.com", "turismoreal123");
                sc.EnableSsl = true;
                sc.Send(msg);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El reserva no se guardó correctamente');", true);


            }






        }




        void guardarPago()
        {
           

            OracleCommand comando = new OracleCommand("select id_reservas from reservas where CLIENTE_RUT  =" + Request.Cookies["Pago"].Values["Rut_Cliente"] + "and DEPARTAMENTO_ID_DEPTO  =" + Request.Cookies["Pago"].Values["Depto_Id"] + "and SUBTOTAL  = " + Request.Cookies["Pago"].Values["SubTotal"] + "and PAGO_RESERVA  = " + Request.Cookies["Pago"].Values["Pago_Reserva"] + "and NUM_ACOMP  = " + Request.Cookies["Pago"].Values["Acomp"] + " ", ora);

            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = comando;
            DataTable tb = new DataTable();
            da.Fill(tb);
            this.GridView1.DataSource = tb;
            GridView1.DataBind();
            string id_reserva = GridView1.Rows[0].Cells[0].Text;
            HttpCookie Reg = new HttpCookie("Reg");
            Reg.Values["id_Reg"] = id_reserva;       
            Response.Cookies.Add(Reg);

            Label1.Text = Request.Cookies["Reg"].Values["id_Reg"];


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                ora.Open();
                OracleCommand comando1 = new OracleCommand("REGISTRO_PAGO_ID", ora);
                comando1.CommandType = System.Data.CommandType.StoredProcedure;

                comando1.Parameters.Add("C_DESCRIPCION", OracleDbType.Varchar2).Value = Request.Cookies["Pago1"].Values["buyorder"];
                comando1.Parameters.Add("C_PAGO", OracleDbType.Int32).Value = Request.Cookies["Pago"].Values["Pago_Reserva"];
                comando1.Parameters.Add("C_RESERVAS", OracleDbType.Int32).Value = Request.Cookies["Reg"].Values["id_Reg"]; 
                comando1.Parameters.Add("C_MET_PAGO", OracleDbType.Int32).Value = Request.Cookies["Pago"].Values["Met_pago"];

                comando1.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La Reserva se realizo correctamente');", true);

                Server.Transfer("../Cliente/Usuario.aspx");
                ora.Close();

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El registro no se guardó correctamente');", true);


            }
        }
    }
}
