<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeFile="Lector_Man.aspx.cs" Inherits="Mantenimientos_Lector_Man" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <%--Aqui va el diseño del formulario--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >
            <%--Aqui va el estilo para el temporizador--%>
            <style type="text/css">
        .overlay  
        {
          position: fixed;
          z-index: 98;
          top: 0px;
          left: 0px;
          right: 0px;
          bottom: 0px;
            background-color: #aaa; 
            filter: alpha(opacity=80); 
            opacity: 0.8; 
        }
        .overlayContent
        {
          z-index: 99;
          margin: 250px auto;
          width: 80px;
          height: 80px;
        }
        .overlayContent h2
        {
            font-size: 18px;
            font-weight: bold;
            color: #000;
        }
        .overlayContent img
        {
          width: 20px;
          height: 20px;
        }

        </style>
            <%--Aqui va el diseño del formulario--%>
            MANTENIMIENTO DE LECTORES<br />
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" Width="88px" OnClick="btnNuevo_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblMensaje" runat="server" CssClass="labelErrores"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grvLectores" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="757px" OnRowCommand="grvLectores_RowCommand" style="margin-top: 0px">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/Images/Editar.png" Text="Botón" />
                                <asp:BoundField DataField="CODIGO" HeaderText="Codigo" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombres" />
                                <asp:BoundField DataField="PATERNO" HeaderText="APE PATERNO" />
                                <asp:BoundField DataField="MATERNO" HeaderText="APE MATERNO" />
                                <asp:BoundField DataField="DNI" HeaderText="DNI" />
                                <asp:BoundField DataField="DIRECCION" HeaderText="DIRECCION" />
                                <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" />
                                <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" />
                                <asp:BoundField DataField="DISTRITO" HeaderText="DISTRITO" />
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            &nbsp;<%-- Aqui va el popup con su codigo--%><%--el link button o cualquiero otro control para el manejo del modal--%><asp:LinkButton ID="btnPopup" runat="server" Text="" /><%--El modalpoput extender : vease el TargetControl que apunta al linkbutton y el popuconttol ID que apunhta al panel--%>
            
            <cc1:ModalPopupExtender ID="PopMant" runat="server" BackgroundCssClass="FondoAplicacion" PopupControlID="Panel1" TargetControlID="btnPopup">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1" align="center" Style="display:table" Width="701px" BorderColor="#FFFFCC">
            <table style="border: Solid 3px #D55500; "
                cellpadding="0" cellspacing="0" class="CajaDialogo" >
                <tr style="background-color: darkred">
                    <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                        align="center">
                        Datos del Vendedor
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 45%" class="labelContenido">
                        &nbsp;</td>
                      <td align="left" class="auto-style5">
                          &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido" style="width: 45%">
                        <asp:Label ID="lblId2" runat="server" Text="Id:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style5">
                        <asp:Label ID="lblID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Nombre:
                    </td>
                    <td align="left" class="auto-style5">
                        <asp:TextBox ID="txtNombres" runat="server" Width="250px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Apellido Paterno:
                    </td>
                    <td align="left" class="auto-style5">
                        <asp:TextBox ID="txtApePaterno" runat="server" Width="253px" Height="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Apellido Materno:
                    </td>
                    <td align="left" class="auto-style5">
                        <asp:TextBox ID="txtApeMaterno" runat="server" Height="20px" Width="253px" />
                        
                    </td>
                </tr>
               
                     <tr>
                         <td align="right" class="labelContenido">DNI: </td>
                         <td align="left" class="auto-style5">
                             <asp:TextBox ID="txtDni" runat="server" Width="150px" />
                         </td>
                     </tr>
                     <tr>
                         <td align="right" class="labelContenido">Direccion:</td>
                         <td align="left" class="auto-style5">
                             <asp:TextBox ID="txtDireccion" runat="server" Height="20px" Width="253px" />
                         </td>
                </tr>
                     <tr>
                         <td align="right" class="labelContenido">Telefono:</td>
                         <td align="left" class="auto-style2">
                             <asp:TextBox ID="txtTelefono" runat="server" Width="150px" />
                         </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">Email:</td>
                    <td align="left" class="auto-style5">
                        <asp:TextBox ID="txtEmail" runat="server" Height="20px" Width="253px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">Distrito</td>
                    <td align="left" class="auto-style5">
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="143px">
                        </asp:DropDownList>
                    </td>
                </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="lblMensaje2" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td>
                             <asp:HiddenField ID="hdfAccion" runat="server" />
                         </td>
                         <td class="auto-style5">
                             <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="100px" OnClick="btnGrabar_Click" />
                             <asp:Button ID="btnEliminar" runat="server" Height="26px" OnClick="btnEliminar_Click" Text="Eliminar" Width="88px" />
                              <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" BehaviorID="btnEliminar_ConfirmButtonExtender" ConfirmText="Seguro de eliminar registro?" TargetControlID="btnEliminar" />
                             <br />
                             <asp:Button ID="btnCerrar" runat="server"  Text="Cancelar" Width="100px" />
                         </td>
                     </tr>
              
            </table>
                        
        </asp:Panel>
        </ContentTemplate>

    </asp:UpdatePanel>
    <%--Aqui va el temporizador--%>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
        <%--<ProgressTemplate >
            <div class="overlay"  />
            <div class ="overlayContent" >
            <h2>  Procesando....</h2> 
                <p>
                    &nbsp;</p>
                <img src ="../Images/indicator.gif" alt ="Loading" border="0"/>
                </div> 
        </ProgressTemplate>--%>
    </asp:UpdateProgress>
</asp:Content>

