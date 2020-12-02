using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal.Cliente
{
    public partial class ExitoServicioExtra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.Cookies["tour"] == null)
                {

                    Response.Redirect("../Cliente/Usuario.aspx");
                }
                if (Request.Cookies["PagoS"] == null)
                {

                    Response.Redirect("../Cliente/InterServicioExtra.aspx");
                }

            }

        }
    }
}