<%@ Page Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="PressReleaseReports.aspx.cs" Inherits="app_journalists_pressreleases_PressReleaseReports"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .Block {
              margin: 10px 8px !Important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Press Release Reports</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <asp:Literal runat="server" ID="litReport"></asp:Literal>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>


