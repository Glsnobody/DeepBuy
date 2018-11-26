<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DeepBuy.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Deep Buy</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/toastr.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/toastr.min.js"></script>
    <style>
        body{
            padding-top: 90px;
            padding-bottom: 60px;
            align-content:center;
            margin:0 auto;
        }

        footer{
            height: 10%;
            margin:0;
        }
    </style>

</head>
<body background="Images/wallhaven-176368.jpg">
    <div class="container jumbotron">
        <h2 class="h2">Deep Buy</h2>
        <form runat="server">
            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Username</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="userTextbox" placeholder="Username"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ValidationGroup="LogIn" runat="server" CssClass="ErrorMessage" ControlToValidate="userTextBox" ErrorMessage="Debe llenar este campo"></asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <div class="form-group col-lg-4 col-sm-12">
                    <asp:Label runat="server">Password</asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="passTextbox" TextMode="Password" placeholder="Password"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ValidationGroup="LogIn" runat="server" CssClass="ErrorMessage" ControlToValidate="userTextBox" ErrorMessage="Debe llenar este campo"></asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <div class="col-lg-5 col-sm-12">
                    <asp:Button ID="LoginButton" runat="server" ValidationGroup="LogIn" CssClass="btn btn-warning col-lg-3 col-md-12" Text="Log In" OnClick="LoginButton_Click"/>
                </div>
            </div>
        </form>
    </div>

    <div class="container">
        <footer class="bg-dark fixed-bottom modal-footer text-light">
            <p>&copy; <%: DateTime.Now.Year %> - Gianluis González</p>
        </footer>
    </div>
</body>
</html>
