﻿using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinal.Cliente
{
    public partial class Pagar : System.Web.UI.Page
    {
        OracleConnection ora = new OracleConnection("DATA SOURCE =localhost:1521/xe ; PASSWORD = 123 ; USER ID = admin2");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.Cookies["Pago"] == null)
                {

                    Response.Redirect("../Cliente/IniciarSesion.aspx");
                }
                else
                {
                    GuardarReserva();
                    

                }

            }



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

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El reserva no se guardó correctamente');", true);


            }






        }




        void guardarPago()
        {

            OracleCommand comando = new OracleCommand("select id_reservas from reservas where CLIENTE_RUT  =" + Request.Cookies["Pago"].Values["Rut_Cliente"] + "and DEPARTAMENTO_ID_DEPTO  =" + Request.Cookies["Pago"].Values["Depto_Id"] + " ", ora);

            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = comando;
            DataTable tb = new DataTable();
            da.Fill(tb);
            this.GridView1.DataSource = tb;
            GridView1.DataBind();
            string id_reserva = GridView1.Rows[0].Cells[0].Text;


            try
            {
                ora.Open();
                OracleCommand comando1 = new OracleCommand("REGISTRAR_PAGO_ID", ora);
                comando1.CommandType = System.Data.CommandType.StoredProcedure;

                comando1.Parameters.Add("C_DESCRIPCION", OracleDbType.Varchar2).Value = Request.Cookies["Pago1"].Values["buyorder"];
                comando1.Parameters.Add("C_PAGO", OracleDbType.Int32).Value = Request.Cookies["Pago"].Values["Pago_Reserva"];
                comando1.Parameters.Add("C_RESERVAS", OracleDbType.Int32).Value = id_reserva;
                comando1.Parameters.Add("C_MET_PAGO", OracleDbType.Int32).Value = Request.Cookies["Pago"].Values["Met_pago"];
                
                comando1.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La Reserva se realizo correctamente');", true);

                Server.Transfer("../Cliente/Usuario.aspx");
                ora.Close();

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El pago no se guardó correctamente');", true);


            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            guardarPago();
        }
    }
}