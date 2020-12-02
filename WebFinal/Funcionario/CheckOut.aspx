<%@ Page Title="" Language="C#" MasterPageFile="~/Funcionario/PrincipalFuncionario.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="WebFinal.Funcionario.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form method="post" name="serv_extra" runat="server"> 
      
      <div class="fondo">
           <div class="container mt-5 p-5">
            
                <h1 class="display-4 mt-2">Check Out</h1>

                <div class="row shadow mt-5 p-2 border bg-white">                
                                             
                         <!--COL1-->
                         <div class="col-sm-12 col-md-6">
                             
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
                                 <asp:Label ID="lblreserva" runat="server" Text="Label"></asp:Label>
                             </div>

                             <div class="my-4">
                                 <a class="font-weight-bold pr-1">Nro. de Arriendo:</a>
                                 <asp:Label ID="lblreg" runat="server" Text="Label"></asp:Label>  
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
                                 <a class="font-weight-bold">Multa ($):</a>
                                 <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control mt-2 col-4"></asp:TextBox>  
                             </div>

                         </div>
                         <!--FIN_COL2-->

                         <!--BOTONES-->
                         <div class="col-12 mt-4 mb-3 text-center">
                             <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Ingresar" OnClick="Button1_Click"/>
                             <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Text="Volver" OnClick="Button1_Click"/>  
                         </div>
                         <!--FIN_BOTONES-->

                                  
                     <asp:GridView ID="GridView1" runat="server" Visible="false"></asp:GridView>
                     <asp:Label ID="lblidpers" runat="server" Text="Label" Visible="false"></asp:Label> 


                </div>
       </div>      
      </div>
    
    </form>
</asp:Content>
