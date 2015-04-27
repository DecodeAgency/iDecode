<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="app_login" Async="true" MasterPageFile="~/app/AppMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Sign into your iDecode Account</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="RegisterContainer">
        <table>
            <tr runat="server" id="trSignInWithTwitter" visible="true">
                <td><asp:Button runat="server" ID="btnSignInWithTwitter" Text="Login with Twitter" CssClass="SignupTwitterButton" OnClick="btnSignInWithTwitter_Click"/></td>                
            </tr>
            <tr runat="server" id="trSeparator" visible="true">
                <td>
                    <div class="separator"><div class="middle_separator">OR</div></div>
                </td> 
            </tr>
            <tr runat="server" id="trProfileImage" visible="false" style="text-align:center">
                <td>
                    <img runat="server" id="imgProImage" src="#" class="SignUpProfileImage" />
                </td>
            </tr>
            <tr>
                <td><asp:TextBox CssClass="LoginTextBoxes" runat="server" ID="txtEmail" Text="Email Address" onfocus='if (this.value == "Email Address"){this.value = "";}' onblur='if (this.value == ""){this.value = "Email Address"}' /></td>
            </tr>
            <tr runat="server" id="trPassword" visible="true">
                <td><asp:TextBox CssClass="LoginTextBoxes" runat="server" ID="txtPassword" Text="Password" onfocus='if (this.value == "Password"){this.value = ""; this.type="password"}' onblur='if (this.value == ""){this.value = "Password";this.type="text"}' /></td>
            </tr>
            <tr>
                <td><asp:Button runat="server" ID="btnSignIn" Text="Sign In" OnClick="btnSignIn_Click"  CssClass="SignInButton" /></td>
            </tr>
            <tr>
                <td><span style="display:block; float:right;color:#ccc; margin-top:10px; font-size:14px;"><a href="register.aspx">Don't have an account? Register here.</a></span></td>
            </tr>
        </table>
    </div>
</asp:Content>
