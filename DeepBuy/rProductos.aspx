<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="DeepBuy.UI.Registros.rProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container jumbotron">
        <h2 class="h2">Registro de Productos</h2>
        <hr />
        <div runat="server">

            <div class="row">
                <div class="form-group col-lg-3 col-sm-12">
                    <asp:Label runat="server">Producto ID</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="productoIdTextbox" TextMode="Number" Text="0" min="0"></asp:TextBox>
                </div>
                <div class="form-group col-lg-3 col-md-12">
                    <br />
                    <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-info col-lg-4 col-md-12" Text="Buscar" OnClick="BuscarButton_Click"/>
                </div>
            </div>

            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Descripcion</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="descripcionTextbox" placeholder="Descripcion"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="descripcionTextBox" ErrorMessage="Debe llenar este campo"></asp:RequiredFieldValidator>
            </div>

            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Precio</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="precioTextbox" TextMode="Number" min="0" Text="0"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="precioTextBox" ErrorMessage="Debe llenar este campo"></asp:RequiredFieldValidator>
            </div>

            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Inventario</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="inventarioTextbox" Text="0" min="0" ReadOnly="true"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="inventarioTextBox" ErrorMessage="Debe llenar este campo"></asp:RequiredFieldValidator>
            </div>

            <div class="row">
                <div class="col-lg-5 col-sm-12">
                    <asp:Button ID="NuevoButton" runat="server" CssClass="btn btn-success col-lg-3 col-md-12" Text="Nuevo" OnClick="NuevoButton_Click"/>
                    <asp:Button ID="GuardarButton" runat="server" ValidationGroup="Guardar" CssClass="btn btn-warning col-lg-3 col-md-12" Text="Guardar" OnClick="GuardarButton_Click"/>
                    <asp:Button ID="EliminarButton" runat="server" CssClass="btn btn-danger col-lg-3 col-md-12" Text="Eliminar" OnClick="EliminarButton_Click"/>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
