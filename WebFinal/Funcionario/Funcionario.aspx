<%@ Page Title="" Language="C#" MasterPageFile="~/Base/Principal.Master" AutoEventWireup="true" CodeBehind="Funcionario.aspx.cs" Inherits="WebFinal.Funcionario.Funcionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form method="post" name="check_in" runat="server"> 
      
      <div class="fondo">
        <div class="container mt-5 p-5">
          
            <h1 class="display-4 mt-2"><asp:Label ID="Label2" runat="server" ></asp:Label>, bienvenido/a</h1>
            
            <div class="row shadow mt-5 p-3 border bg-white">
                
                <p class="col-12 text-center font-weight-bold">¿Qué desea hacer?</p>
	            
                <!--BOTONES-->
                <div class="col-12 mt-4 mb-3 text-center">
                   <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Check In" OnClick="Button1_Click"/>
                   <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Check Out" OnClick="Button2_Click"/>
                   <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Text="Log Out" OnClick="Button3_Click"/>  
                </div>
                <!--FIN_BOTONES-->

                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Visible="False"></asp:GridView>

            </div>
        </div>      
      </div>
    
    </form>

</asp:Content>
