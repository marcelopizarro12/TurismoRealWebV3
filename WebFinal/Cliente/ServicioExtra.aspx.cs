using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal.Cliente
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        OracleConnection ora = new OracleConnection("DATA SOURCE =localhost:1521/xe ; PASSWORD = 123 ; USER ID = admin2");

        protected void Page_Load(object sender, EventArgs e)
        {


        }



        protected void Button1_Click(object sender, EventArgs e)
        {


            GridView1.Visible = true;

            OracleCommand comando = new OracleCommand("SELECT * from tour where STD_TOUR_ID_STD_TOUR = 1 ", ora);
            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = comando;
            DataTable tb = new DataTable();
            da.Fill(tb);
            this.GridView1.DataSource = tb;
            GridView1.DataBind();

            // agregar los al httpcoockis


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int f = GridView1.SelectedIndex;
            string id = GridView1.Rows[f].Cells[1].Text;
            string lugar = GridView1.Rows[f].Cells[2].Text;
            string fecha = GridView1.Rows[f].Cells[3].Text;

            HttpCookie tour = new HttpCookie("tour");
            tour.Values["id"] = id;
            tour.Values["lugar"] = lugar;
            tour.Values["fecha"] = fecha;


            Response.Cookies.Add(tour);
            
        }

        protected void Button2_Click(object sender, EventArgs e)
            {
                
                
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label6.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                TextBox2.Visible = true;
                TextBox1.Visible = true;
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;

          }



        protected void Button3_Click(object sender, EventArgs e)
        {

            //guardar el transporte altiro    
            //aca se pasa a pestaña de pago donde se genra la reserva

            Server.Transfer("../Cliente/InterServicioExtra.aspx");

        }

        protected void Button4_Click(object sender, EventArgs e)
            {


                Server.Transfer("../Cliente/Usuario.aspx");


            }

     
    }
}