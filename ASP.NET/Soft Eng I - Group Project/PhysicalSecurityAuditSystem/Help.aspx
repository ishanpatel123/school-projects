<%@ Page Title="Help" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="PhysicalSecurityAuditSystem.Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>FAQ</h2>
            <p>
                Q: Here is a Common Question
                <br />
                A: Here is the answer
                <br />
                <br />
                Q: Here is another Common Question
                <br />
                A: Here is the answer
            </p>
    <h2>Still Having Trouble? Submit a Ticket:</h2>
            <p>
                &nbsp;<asp:Label ID="FullNameLBL" runat="server" Text="Full Name:"></asp:Label>
                <br />
                 &nbsp;<asp:TextBox ID="FullNameTxt" runat="server" Width="175px" CausesValidation="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FullNameTxt" ErrorMessage="*A Name is required before submitting.*" ForeColor="Red"></asp:RequiredFieldValidator>

                <br />
                <br />

                &nbsp;<asp:Label ID="EmailLBL" runat="server" Text="Email Address:"></asp:Label>
                <br />
                 &nbsp;<asp:TextBox ID="EmailTxt" runat="server" Width="175px" CausesValidation="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EmailTxt" ErrorMessage="*An Email is required before submitting.*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTxt" ErrorMessage="*Please enter a correct email address*" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                <br />
                <br />

                &nbsp;<asp:Label ID="ProblemLBL" runat="server" Text="Problem:"></asp:Label>
                <br />
                 &nbsp;<asp:TextBox ID="ProblemTxt" runat="server" Width="400px" CausesValidation="True" Height="200px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ProblemTxt" ErrorMessage="*Please describe your problem.*" ForeColor="Red"></asp:RequiredFieldValidator>

                <br />
                <br />

                &nbsp;<asp:Button ID="SubmitBTN" runat="server" Text="Submit" Width="100px" OnClick="SubmitBTN_Click" />

                <br />
                <br />

                &nbsp;<asp:Label ID="ConfirmationLBL" runat="server" Text="Label" Visible="False" Font-Bold="True" Font-Size="14pt"></asp:Label>
            </p>
</asp:Content>
