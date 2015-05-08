<%@ Page Title="" Language="C#" MasterPageFile="~/app/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="publicationedit.aspx.cs" Inherits="app_admin_publicationedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        input[type='submit'] {
          float: right;
          width: 200px !Important;
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
                    Manage Publication<small style="display:none">Summary of your App</small>
                </h1>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="table-responsive">
                    <label>Publication</label>
                    <asp:TextBox runat="server" ID="txtPublication" CssClass="form-control" />
                    <br />
                    <label>Website</label>
                    <asp:TextBox runat="server" ID="txtWebsite" CssClass="form-control" />
                    <br />
                    <label>Language</label>
                    <asp:DropDownList runat="server" ID="ddLanguage" DataSourceID="dsLanguages" DataTextField="Language" DataValueField="LanguageID" CssClass="form-control" />
                    <br />
                    <asp:Button runat="server" ID="btnSave" Text="Save Changes" OnClick="btnSave_Click" Width="200px" CssClass="form-control btn-danger" />
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="dsLanguages" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
        SELECT LanguageID, ISNULL(Language,'') AS Language FROM Languages" >
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div style="float:right">
        &nbsp;&nbsp;<asp:Button Width="130" CssClass="BackButton" runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" />&nbsp;&nbsp;<asp:Button Width="130" CssClass="BackButton" runat="server" ID="btnRemoveBrackets" Text="Remove Brackets" OnClick="btnRemoveBrackets_Click" />
    </div>
    <div style="clear:both; height:10px"></div>
    <div runat="server" id="divMessage" class="Message SuccessMessage" visible="false">
        <asp:Literal runat="server" ID="txtSuccessMessage" Text="Changes successfully saved." Visible="false" />
        <asp:Literal runat="server" ID="txtErrorMessage" Text ="An error occured. Changes not saved." Visible="false" />
    </div>
    <div class="SearchItemsContainer">
   
    </div> 
</asp:Content>

