<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="app_default" Async="true"%>

<!DOCTYPE html>

<html>
    <head>
        <title></title>     
        <link href="styling/css/reset.css" rel="stylesheet"/> 
        <link href="styling/css/idecode.css" rel="stylesheet"/>
    </head>
    <body>
        <form id="frm1" runat="server">
            <div>
                <div style="background-color: #222;border-color: #090909;height:70px">
                    <div style="width:960px; margin:0 auto"><img src="styling/images/logo.png" style="width: 230px;margin-top: 10px;" /></div>
                </div>
                <div style="background-color: #f8f8f8;border-color: #e7e7e7;height:50px; margin-bottom:20px">

                </div>
            </div>
            <div class="RegisterContainer">
                <table>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name is required." ControlToValidate="txtFirstName" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trSignInWithTwitter" visible="true">
                        <td><asp:Button runat="server" ID="btnSignInWithTwitter" Text="Signup with Twitter" CssClass="SignupTwitterButton" OnClick="btnSignInWithTwitter_Click" /></td>                
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
                        <td><asp:TextBox Width="113" runat="server" ID="txtFirstName" Text="First Name" onfocus='if (this.value == "First Name"){this.value = "";}' onblur='if (this.value == ""){this.value = "First Name"}' /><asp:TextBox Width="113" runat="server" ID="txtLastName" Text="Last Name" onfocus='if (this.value == "Last Name"){this.value = "";}' onblur='if (this.value == ""){this.value = "Last Name"}' /></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox runat="server" ID="txtEmail" Text="Email Address" onfocus='if (this.value == "Email Address"){this.value = "";}' onblur='if (this.value == ""){this.value = "Email Address"}' /></td>
                    </tr>
                    <tr runat="server" id="trPassword" visible="true">
                        <td><asp:TextBox runat="server" ID="txtPassword" Text="Password" onfocus='if (this.value == "Password"){this.value = ""; this.type="password"}' onblur='if (this.value == ""){this.value = "Password";this.type="text"}' /></td>
                    </tr>
                    <tr>
                        <td><asp:Button runat="server" ID="btnRegister" Text="Get Started" OnClick="btnRegister_Click" ValidationGroup="Submit" /></td>
                    </tr>
                    <tr>
                        <td><span style="display:block; float:right;color:#ccc; margin-top:10px; font-size:14px;"><a href="login.aspx">Already have an account? Sign in.</a></span></td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</html>

