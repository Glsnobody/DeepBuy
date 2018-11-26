<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rOrdenes.aspx.cs" Inherits="DeepBuy.UI.Registros.rOrdenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container jumbotron">
        <h2 class="h2">Registro de Ordenes</h2>
        <hr />
        <div runat="server">

            <div class="row">
                <div class="form-group col-lg-3 col-sm-12">
                    <asp:Label runat="server">Orden ID</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="ordenIdTextbox" TextMode="Number" Text="0" min="0"></asp:TextBox>
                </div>
                <div class="form-group col-lg-3 col-md-12">
                    <br />
                    <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-info col-lg-4 col-md-12" Text="Buscar" OnClick="BuscarButton_Click"/>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Fecha</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="fechaTextbox" TextMode="Date"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Usuario ID</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" TextMode="Number" ID="usuarioIdTextbox" Text="1" min="1"></asp:TextBox>
                </div>
            </div>

            <%--GRID--%>
            <div class="col-md-12">
                <asp:GridView ID="DataGridView"
                    runat="server"
                    class="table table-condensed table-bordered table-responsive"
                    CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">

                    <Columns>
                        <asp:HyperLinkField ControlStyle-ForeColor="Black"
                            DataNavigateUrlFields="ProductoId"
                            DataNavigateUrlFormatString="rProductos.aspx?Id={0}">
                            <ControlStyle ForeColor="Black"></ControlStyle>
                        </asp:HyperLinkField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </div>

            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Total</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="totalTextbox" Text="0" min="0"></asp:TextBox>
                </div>
            </div>

            <%--GRID--%>
            <div class="row">
                <div class="col-md-6 offset-3">
                <br />
                <asp:GridView ID="DatosGridView" runat="server" AllowPaging="true" PageSize="12" CssClass="table" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Capital" HeaderText="Capital" />
                        <asp:BoundField DataField="Interes" HeaderText="Interes" />
                        <asp:BoundField DataField="Valor" HeaderText="Valor" />
                        <asp:BoundField DataField="Balance" HeaderText="Balance" />
                    </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:GridView>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-5 col-sm-12">
                    <asp:Button ID="NuevoButton" runat="server" CssClass="btn btn-success col-lg-3 col-md-12" Text="Nuevo" OnClick="NuevoButton_Click"/>
                    <asp:Button ID="GuardarButton" runat="server" CssClass="btn btn-warning col-lg-3 col-md-12" Text="Guardar" OnClick="GuardarButton_Click"/>
                    <asp:Button ID="EliminarButton" runat="server" CssClass="btn btn-danger col-lg-3 col-md-12" Text="Eliminar" OnClick="EliminarButton_Click"/>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
