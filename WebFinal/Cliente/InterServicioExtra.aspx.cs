using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transbank.Webpay ;

namespace WebFinal.Cliente
{
    public partial class InterServicioExtra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.Cookies["rut"] == null)
                {

                    Response.Redirect("../Cliente/Usuraio.aspx");

                }
                else
                {

                    Label2.Text = new Random().Next(100000, 999999999).ToString();
                    var transaction = new Webpay(Configuration.ForTestingWebpayPlusNormal()).NormalTransaction;

                    Rellenar();

                    var amount = new Random().Next(100000, 999999999);
                    var sessionId = "sessionId";
                    var buyOrder = Label2.Text;
                    string returnUrl = "http://localhost:51077/Cliente/ExitoServicioExtra.aspx";
                    string finalUrl = "http://localhost:51077/Cliente/error.aspx";
                    var initReuslt = transaction.initTransaction(amount, buyOrder, sessionId, returnUrl, finalUrl);
                    var tokenWs = initReuslt.token;
                    token_ws.Text = tokenWs;
                    var formAction = initReuslt.url;
                    form1.Action = formAction;

                    Label1.Text = Convert.ToString(amount);
                    HttpCookie PagoS = new HttpCookie("PagoS");
                    PagoS.Values["buyorder"] = buyOrder;
                    Response.Cookies.Add(PagoS);
                }
            }
        }


        void Rellenar()
        {
            lbldesde.Text = Request.Cookies["tour"].Values["id"];
            lblhasta.Text = Request.Cookies["tour"].Values["lugar"];
            lblacomp.Text = Request.Cookies["tour"].Values["fecha"];
        
            lblBoleta.Text = Label2.Text;
            lblrut.Text = Request.Cookies["rut"].Values["rut"];
            lblReserva.Text = Request.Cookies["Resv"].Values["id"];


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}