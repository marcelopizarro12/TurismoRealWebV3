<%@ Page Title="" Language="C#" MasterPageFile="~/Funcionario/PrincipalFuncionario.Master" AutoEventWireup="true" CodeBehind="CheckIn.aspx.cs" Inherits="WebFinal.Funcionario.CheckIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form method="post" name="check_in" runat="server"> 
      
      <div class="fondo">
           <div class="container mt-5 p-5">
            
                <h1 class="display-4 mt-2">Check In</h1>

                <div class="row shadow mt-5 p-2 border bg-white">                
                                         
                         <!--COL1-->
                         <div class="col-sm-12 col-md-5">
                             
                             <div class="my-4">
                                 <a class="font-weight-bold pr-1">Rut Cliente:</a>
                                 <asp:Label ID="lblrut" runat="server" Text="Label"></asp:Label> 
                             </div>
                                                                
                             <div class="my-4">
                                 <a class="font-weight-bold pr-1">Personal a cargo:</a>
                                 <asp:Label ID="lblrutp" runat="server" Text="Label"></asp:Label>
                             </div>

                             <div class="my-4">
                                 <a class="font-weight-bold pr-1">Nro. Departamento:</a>
                                 <asp:Label ID="lbldpto" runat="server" Text="Label"></asp:Label>
                             </div>

                             <div class="my-4">
                                 <a class="font-weight-bold pr-1">Nro. Reserva:</a>
                                 <asp:Label ID="lblresv" runat="server" Text="Label"></asp:Label>
                             </div>


                         </div>
                         <!--FIN_COL1-->
        
                         <!--COL2-->
                         <div class="col-sm-12 col-md-6">                      

                             <div class="mt-md-4">
                                 <a class="font-weight-bold">Descripción:</a>
                                 <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control mt-2 col-10 py-5"></asp:TextBox>                              
                             </div>
                             <div class="mt-4 mb-sm-4 mb-md-0">
                                 <a class="text-justify">Según registros en el sistema, se efectuó un pago de la reserva
                                     <span class="font-weight-bold"><asp:Label ID="lblresv1" runat="server" Text="Label"></asp:Label></span> de 
                                     <span class="font-weight-bold">$<asp:Label ID="lblres" runat="server" Text="Label"></asp:Label></span>
                                      del Total de de <span class="font-weight-bold">$<asp:Label ID="lbltt" runat="server" Text="Label"></asp:Label></span>
                                      por lo cual el monto restante a pagar es de:
                                     <span class="font-weight-bold">$<asp:Label ID="lblResto" runat="server" Text="Label"></asp:Label></span>
                                 </a>
                             </div>

                         </div>
                         <!--FIN_COL2-->

                         <!--BOTONES-->
                         <div class="col-12 mt-4 mb-3 text-center">
                             <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Ingresar"/>
                             <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Text="Volver"/>  
                         </div>
                         <!--FIN_BOTONES-->

                                  
                        <asp:GridView ID="GridView1" runat="server" Visible="false" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="pago_reserva" HeaderText="reseva" />
                                <asp:BoundField DataField="subtotal" HeaderText="total" />
                                <asp:BoundField DataField="pgresto" HeaderText="resto" />
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView2" runat="server" Visible="false"></asp:GridView>
                        <asp:GridView ID="GridView3" runat="server" Visible="false"></asp:GridView>


                </div>
       </div>      
      </div>
    
    </form>

    

</asp:Content>
