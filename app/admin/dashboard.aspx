<%@ Page Title="" Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="app_admin_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .Block {
          width: 295px;
          float: left;
          min-height: 205px;
          background-color: #3668af;
          padding: 0 10px;
          border-radius: 5px;
          color: #fff;
        }
        .Block h3 {
          background-color: #1b4e95;
          margin: 0 !Important;
          padding: 0;
          /* margin-top: 0 !Important; */
          margin-left: -10px !important;
          text-align: center;
          padding: 15px 0 15px 0 !Important;
          width: 315px;
          border-top-left-radius: 5px;
          border-top-right-radius: 5px;
          border-bottom: none !Important;
        }
        h4 {
          font-size: 65px !Important;
          text-align: center;
          display: block;
          padding: 42px !Important;
          font-weight: normal;
        }
        .SignInButton {
            background-color:#4fc5f7 !Important;
            border:1px solid #4fc5f7 !Important;
            text-transform:uppercase;
            color: #fff;
            width: 198px !Important;
            float: none !Important;
            border-radius: 5px;
            margin-left: 56px !Important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Dashboard</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div class="Block">
        <h3>Journalists</h3>
        <h4><asp:literal runat="server" ID="litJournalistCount" /></h4>
        <asp:Button runat="server" ID="btnJournalists" Text="View" ValidationGroup="Submit" CssClass="SignInButton" OnClick="btnJournalists_Click" />
    </div>
    <div class="Block" style="margin:0 5px">
        <h3>Communicators</h3>
        <h4><asp:literal runat="server" ID="litCommunicatorsCount" /></h4>
        <asp:Button runat="server" ID="btnCommunicators" Text="View" ValidationGroup="Submit" CssClass="SignInButton" OnClick="btnCommunicators_Click" />
    </div>
    <div class="Block">
        <h3>Publications</h3>
        <h4><asp:Literal runat="server" ID="litPublicationsCount" /></h4>
        <asp:Button runat="server" ID="btnPublications" Text="View" ValidationGroup="Submit" CssClass="SignInButton" OnClick="btnPublications_Click" />
    </div>
</asp:Content>

