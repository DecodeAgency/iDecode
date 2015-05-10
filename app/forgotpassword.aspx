<%@ Page Title="" Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="forgotpassword.aspx.cs" Inherits="app_forgotpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Forgot Password</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="RegisterContainer">
        <table>
            <tr>
                <td><asp:TextBox CssClass="LoginTextBoxes" runat="server" ID="txtEmail" Text="Email Address" onfocus='if (this.value == "Email Address"){this.value = "";}' onblur='if (this.value == ""){this.value = "Email Address"}' /></td>
            </tr>
           <tr>
                <td>
                    <center>
                       <asp:Button runat="server" ID="btnSendMyPassword" Text="Email My Password" OnClick="btnSendMyPassword_Click"  CssClass="SignInButton" />     
                    </center>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

