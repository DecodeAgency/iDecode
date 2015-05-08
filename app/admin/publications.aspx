<%@ Page Title="" Language="C#" MasterPageFile="~/app/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="publications.aspx.cs" Inherits="app_admin_publications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%--    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/css/custom-styles.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <link href="assets/js/dataTables/dataTables.bootstrap.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div id="page-inner">
        <div class="row">
            <div class="col-md-12">
                <h1 class="page-header">
                    Publications <small style="display:none">Summary of your App</small>
                </h1>
            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="table-responsive">
                    <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Publication</th>
                                <th>Website</th>
                                <th>Language</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>                                       
                                <asp:Repeater runat="server" ID="rptPublications" DataSourceID="dsPublications">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td><%# Eval("PublicationID") %></td>
                                            <td><%# Eval("Publication") %></td>
                                            <td><%# Eval("Website") %></td>
                                            <td class="center"><%# Eval("Language") %></td>
                                            <td class="center"><a href='<%#"publicationedit.aspx?pid=" + Eval("PublicationID") %>'>edit</a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                        </tbody>
                    </table>
                </div> 
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="dsPublications" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
        SELECT PublicationID, ISNULL(Publication,'') AS Publication, ISNULL(Website,'') AS Website, 
        ISNULL(L.Language,'') AS Language FROM Publications P
        INNER JOIN Languages L ON L.LanguageID = P.LanguageID" >
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <script src="assets/js/jquery-1.10.2.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/dataTables/jquery.dataTables.js"></script>
    <script src="assets/js/dataTables/dataTables.bootstrap.js"></script>
    <script>
        $('#dataTables-example').dataTable();
    </script>
    <script src="assets/js/custom-scripts.js"></script>
    <div style="float:right; display:none">
        <asp:Button Width="130" CssClass="BackButton" runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" />
    </div>
</asp:Content>

