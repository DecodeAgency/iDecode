<%@ Page Title="" Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="app_register" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Create your iDecode Account</h1></div>
    </div>
    <style>
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="tabs">
        <ul class="tab-links">
            <li class="active"><a href="#tab1">REGISTER AS PR PROFESSIONAL</a></li>
            <li><a href="#tab2">REGISTER AS JOURNALIST</a></li>
        </ul>
 
        <div class="tab-content">
            <div id="tab1" class="tab active">
                <table style="margin: 0 auto;">
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name is required." ControlToValidate="txtPRFirstName" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="color:#bfbfbf">You are about to register as a PR Professional.</td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;</td>
                    </tr>
                    <tr runat="server" id="trSignInWithTwitter" visible="true">
                        <td><asp:Button  runat="server" ID="btnPRSignInWithTwitter" Text="Signup with Twitter" CssClass="SignupTwitterButton" OnClick="btnSignInWithTwitter_Click" /></td>                
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
                        <td><asp:TextBox CssClass="RegisterFNameLNameTextBoxes" Width="113" runat="server" ID="txtPRFirstName" Text="First Name" onfocus='if (this.value == "First Name"){this.value = "";}' onblur='if (this.value == ""){this.value = "First Name"}' /><asp:TextBox CssClass="RegisterFNameLNameTextBoxes" Width="113" runat="server" ID="txtPRLastName" Text="Last Name" onfocus='if (this.value == "Last Name"){this.value = "";}' onblur='if (this.value == ""){this.value = "Last Name"}' /></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox CssClass="LoginTextBoxes" runat="server" ID="txtPREmail" Text="Email Address" onfocus='if (this.value == "Email Address"){this.value = "";}' onblur='if (this.value == ""){this.value = "Email Address"}' /></td>
                    </tr>
                    <tr runat="server" id="trPassword" visible="true">
                        <td><asp:TextBox CssClass="LoginTextBoxes" runat="server" ID="txtPRPassword" Text="Password" onfocus='if (this.value == "Password"){this.value = ""; this.type="password"}' onblur='if (this.value == ""){this.value = "Password";this.type="text"}' /></td>
                    </tr>
                    <tr>
                        <td><asp:Button runat="server" ID="btnPRRegister" Text="Get Started" OnClick="btnPRRegister_Click" ValidationGroup="Submit" CssClass="SignInButton" /></td>
                    </tr>
                    <tr>
                        <td><span style="display:block; float:right;color:#ccc; margin-top:10px; font-size:14px;"><a href="login.aspx">Already have an account? Sign in.</a></span></td>
                    </tr>
                </table>
            </div>
 
            <div id="tab2" class="tab">
                <table style="margin: 0 auto;">
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="First name is required." ControlToValidate="txtPRFirstName" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="color:#bfbfbf">You are about to register as a Journalist.</td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;</td>
                    </tr>
                    <tr runat="server" id="tr1" visible="true">
                        <td><asp:Button runat="server" ID="btnJSignupWithTwitter" Text="Signup with Twitter" CssClass="SignupTwitterButton" OnClick="btnJSignupWithTwitter_Click" /></td>                
                    </tr>
                    <tr runat="server" id="tr2" visible="true">
                        <td>
                            <div class="separator"><div class="middle_separator">OR</div></div>
                        </td> 
                    </tr>
                    <tr runat="server" id="tr3" visible="false" style="text-align:center">
                        <td>
                            <img runat="server" id="imgJProImage" src="#" class="SignUpProfileImage" />
                        </td>
                    </tr>
                    <tr>
                        <td><asp:TextBox CssClass="RegisterFNameLNameTextBoxes" Width="113" runat="server" ID="txtJFirstName" Text="First Name" onfocus='if (this.value == "First Name"){this.value = "";}' onblur='if (this.value == ""){this.value = "First Name"}' /><asp:TextBox CssClass="RegisterFNameLNameTextBoxes" Width="113" runat="server" ID="txtJLastName" Text="Last Name" onfocus='if (this.value == "Last Name"){this.value = "";}' onblur='if (this.value == ""){this.value = "Last Name"}' /></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox CssClass="LoginTextBoxes" runat="server" ID="txtJEmail" Text="Email Address" onfocus='if (this.value == "Email Address"){this.value = "";}' onblur='if (this.value == ""){this.value = "Email Address"}' /></td>
                    </tr>
                    <tr runat="server" id="tr4" visible="true">
                        <td><asp:TextBox CssClass="LoginTextBoxes" runat="server" ID="txtJPassword" Text="Password" onfocus='if (this.value == "Password"){this.value = ""; this.type="password"}' onblur='if (this.value == ""){this.value = "Password";this.type="text"}' /></td>
                    </tr>
                    <tr>
                        <td><asp:Button runat="server" ID="btnJRegister" Text="Get Started" OnClick="btnJRegister_Click" ValidationGroup="Submit" CssClass="SignInButton" /></td>
                    </tr>
                    <tr>
                        <td><span style="display:block; float:right;color:#ccc; margin-top:10px; font-size:14px;"><a href="login.aspx">Already have an account? Sign in.</a></span></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    
    <script>
        jQuery(document).ready(function () {
            jQuery('.tabs .tab-links a').on('click', function (e) {
                var currentAttrValue = jQuery(this).attr('href');

                // Show/Hide Tabs
                jQuery('.tabs ' + currentAttrValue).show().siblings().hide();

                // Change/remove current tab to active
                jQuery(this).parent('li').addClass('active').siblings().removeClass('active');

                e.preventDefault();
            });
        });
    </script>
</asp:Content>

