<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="app_login" Async="true" MasterPageFile="~/app/admin/LoginAdminMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.RegisterContainer {
    margin: 0 auto;
    max-width: 450px;
    padding: 50px;
    min-height: 110px;
    margin-top: 50px;
    background-color: #fff;
    border-radius: 5px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
            <div id="page-inner">
                <div class="row">
                    <div class="col-md-12">
                        <h1 class="page-header">
                            Sign into iDecode Control Panel <small style="display:none">Summary of your App</small>
                        </h1>
                    </div>
                </div>
                <form role="form">
                    <div class="RegisterContainer">
                        <div class="form-group input-group">
                            <span class="input-group-addon">@</span>
                            <asp:TextBox runat="server" ID="txtEmail" placeholder="Email Address" CssClass="form-control" />
                        </div>
                        <div class="form-group input-group">
                            <span class="input-group-addon">#</span>
                            <asp:TextBox runat="server" ID="txtPassword" placeholder="Password" TextMode="Password" CssClass="form-control" />
                        </div>
                        <asp:Button runat="server" ID="btnSignIn" Text="Sign In" OnClick="btnSignIn_Click"  CssClass="form-control btn-danger" />
                    </div>
                </form>
            </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

<%--
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
                <td><asp:TextBox CssClass="LoginTextBoxes" runat="server" ID="txtEmail2" Text="Email Address" onfocus='if (this.value == "Email Address"){this.value = "";}' onblur='if (this.value == ""){this.value = "Email Address"}' /></td>
            </tr>
            <tr runat="server" id="trPassword" visible="true">
                <td><asp:TextBox CssClass="LoginTextBoxes" runat="server" ID="txtPassword2" Text="Password" onfocus='if (this.value == "Password"){this.value = ""; this.type="password"}' onblur='if (this.value == ""){this.value = "Password";this.type="text"}' /></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td><span style="display:block; float:right;color:#ccc; margin-top:10px; font-size:14px;"><a href="register.aspx">Don't have an account? Register here.</a></span></td>
            </tr>
        </table>
    </div>--%>
</asp:Content>
