<%@ Page Title="" Language="C#" MasterPageFile="~/app/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="beatedit.aspx.cs" Inherits="app_admin_beatedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        input[type='submit'] {
          float: right;
          width: 200px !Important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div id="page-inner">
        <div class="row">
            <div class="col-md-12">
                <h1 class="page-header">
                    Manage Beat <small style="display:none">Summary of your App</small>
                </h1>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="table-responsive">                        
                    <div class="form-group" id="divBio">
                        <label>Beat</label>
                        <asp:TextBox runat="server" ID="txtBeat" CssClass="SearchTextBoxes form-control" />
                        <br />
                        <label>Public Group</label>
                        <asp:CheckBox runat="server" ID="chkIsPublic" CssClass="form-control" />
                        <br />
                        <asp:Button runat="server" ID="btnSaveBeat" Text="Save Changes" OnClick="btnSaveBeat_Click" CssClass="form-control btn-danger" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

