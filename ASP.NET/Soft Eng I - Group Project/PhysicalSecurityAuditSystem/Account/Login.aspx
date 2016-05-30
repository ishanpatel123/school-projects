<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PhysicalSecurityAuditSystem.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <br />
    <br />
    <br />
    <br />
    <section id="loginForm">
    <div class="row">
        <div class="col-md-1">
        </div>
        <div class="col-md-1">
        </div>
        <div class="col-md-8">
            <div style="text-align: center">
                <asp:Image ID="LogoLIMG" runat="server" Height="300px" ImageUrl="~/Images/LogoL.png" Width="600px" />
                <br />
                <br />
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>
             </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label ">Email</asp:Label>
            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The email field is required." />
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Width="1500px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
            
        </div>
    </div>

            <div class="checkbox" style="text-align: center">
                <asp:CheckBox runat="server" ID="RememberMe" />
                <asp:Label ID="Label3" runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
            </div>


        

    <br />
    <div class="row">
        <div class="col-md-3">
        </div>
        <div class="col-md-3">
            <div>
                <asp:Button ID="Button1" runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" Width="500px" />
            </div>
        </div>
    </div>

    <br />
    <br />
    <div class="row">
        <div class="col-md-2">
        </div>
        <div class="col-md-3">
        </div>
            <div style="text-align:left">
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>
            </div>
     </div>



    </section>
</asp:Content>
