<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="WebFinal.Base.Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
  <main id="main">
          <form runat="server">
            <div class="container m-5">
     
            <div class="row m-5">

                <!-- InicioFiltro -->
                <div class="col-12 p-3">

                    <h5 class="mt-3">Filtros</h5>
                
                    <div class="border shadow p-3">
                        
                        <p class="auto-style1">Buscador Por Zona</p> 
                        
                        <asp:DropDownList ID="DropDownList1" runat="server" OnTextChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                          <asp:ListItem Selected="True" Enabled="true">Elija zona de Busqueda</asp:ListItem>
                          <asp:ListItem>VIÑA DEL MAR</asp:ListItem>
                          <asp:ListItem>PUCÓN</asp:ListItem>
                          <asp:ListItem>PUERTO VARAS</asp:ListItem>
                          <asp:ListItem>LA SERENA</asp:ListItem>
                        </asp:DropDownList>
    
                    </div>
            
                </div>
                <!-- TerminoFiltro -->

                <!-- Inicio recuadro reserva-->
                <div class="col-12">
                
                    <h5>Resultados</h5>
                
                    <div class="border">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Height="208px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="1032px">
                      <AlternatingRowStyle BackColor="#F7F7F7" />
                     <Columns>
                           <asp:CommandField ShowSelectButton="True"/>
                           <asp:ImageField DataImageUrlField="id_depto" DataImageUrlFormatString="~/ImgDpto/{0}.jpg"></asp:ImageField>
                           <asp:TemplateField HeaderText="Departamentos">
                            <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                    Nro Departamento:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("id_depto") %>'></asp:Label>
                                   &nbsp;&nbsp;&nbsp;
                                   <br />
                             Ubicacion Departamento:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Label ID="lblubi" runat="server" Text='<%# Eval("direccion") %>'></asp:Label>
                                   <br />
                                   Descripcion del Departamento:
                                        <asp:Label ID="lbldesc" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                    <br />
                                 Precio por Noche:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Label ID="lblprice" runat="server" Text='<%# Eval("precio") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>

                      
                       <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                       <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                       <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                       <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                       <SortedAscendingCellStyle BackColor="#F4F4FD" />
                       <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                       <SortedDescendingCellStyle BackColor="#D8D8F0" />
                       <SortedDescendingHeaderStyle BackColor="#3E3277" />
                     
                      
                    </asp:GridView>
    
                    </div>
            
                </div>
                <!-- Termino recuadro reserva-->
            
            </div>
    
       </div>

         </form>
  </main><!-- End #main -->

</body>
</html>
