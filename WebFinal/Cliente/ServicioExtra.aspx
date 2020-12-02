<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente/PrincipalUsuario.Master" AutoEventWireup="true" CodeBehind="ServicioExtra.aspx.cs" Inherits="WebFinal.Cliente.WebForm1"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




     <form id="form1" runat="server">

                <div class="container my-5">
                    <div class="row">
                            
                            <div class="col-12">
                                <h1 class="display-4 my-5">Servicios Extra</h1>
                                <h5 class="mb-5">Contratacion de Servicios Extra</h5>                              

                                <div class="d-inline mr-4">
                                    <asp:Button ID="Button1" runat="server" Text="Tour" CssClass="btn btn-outline-primary" OnClick="Button1_Click"/>
                                </div>
                            
                                <div class="d-inline mx-4">
                                    <asp:Button ID="Button2" runat="server" Text="Transporte" CssClass="btn btn-outline-primary" OnClick="Button2_Click" />
                                </div>
                            
                                <div class="d-inline mx-4">
                                    <asp:Button ID="Button3" runat="server" Text="Pagar" CssClass="btn btn-outline-primary" OnClick="Button3_Click" />
                                </div>
                            
                                <div class="d-inline mx-4">
                                    <asp:Button ID="Button4" runat="server" Text="Volver" CssClass="btn btn-outline-primary" OnClick="Button4_Click" />
                                </div>
                            </div>
                              
                                
                            <div class="col-12 my-5">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped shadow" Visible="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                     <Columns>
                                         <asp:CommandField ShowSelectButton="True" />
                                         <asp:BoundField HeaderText="Nro Tour" DataField="id_tour" />
                                         <asp:BoundField HeaderText="Lugar" DataField="lugar" />
                                         <asp:BoundField HeaderText="Fecha" DataField="fecha" />
                                         <asp:BoundField DataField="STD_TOUR_ID_STD_TOUR" Visible="False" />
                                     </Columns>
                                </asp:GridView>
                            </div>
                             

                            <div id="divTransporte" visible="false" class="shadow p-3 col-sm-12 col-md-6">

                                <asp:Label ID="Label3" runat="server" Text="Label" Visible="false" CssClass="my-4"><h5>Coordinacion de Transporte</h5></asp:Label>

                                <div class="m-3">
                                    <asp:Label ID="Label6" runat="server" Text="Label" Visible="false">Direccion de Recogida:</asp:Label>
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                </div>

                                <div class="m-3">
                                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="false" >Comuna:</asp:Label>                                
                                    <asp:DropDownList ID="DropDownList2" runat="server" Visible="false">
                                         <asp:ListItem Selected="True" Enabled="true">Elija una comuna</asp:ListItem>
                                         <asp:ListItem>Cerrillos</asp:ListItem>
                                         <asp:ListItem>Maipú</asp:ListItem>
                                         <asp:ListItem>Lo Espejo</asp:ListItem>
                                         <asp:ListItem>Santiago</asp:ListItem>   
                                    </asp:DropDownList>
                                </div>

                                <div class="m-3">
                                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"> Destino: </asp:Label>
                                    <asp:DropDownList ID="DropDownList1" runat="server" Visible="false">
                                         <asp:ListItem Selected="True" Enabled="true">Elija un destino</asp:ListItem>
                                         <asp:ListItem>Terminal</asp:ListItem>
                                         <asp:ListItem>Plaza Central</asp:ListItem>
                                         <asp:ListItem>Departamento</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="m-3">
                                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" >Fecha:</asp:Label>
                                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" Visible="false"></asp:TextBox>
                                    <asp:Label ID="Label5" runat="server" Text="Label" Visible="false" CssClass="ml-1">
                                        <p>
                                            Se contactaran contigo para la coordinacion del horario.
                                        </p>
                                    </asp:Label>
                                </div>
                                
                            </div>  
                            
                           

                    </div>                   
                </div> 
        
    </form>





</asp:Content>
