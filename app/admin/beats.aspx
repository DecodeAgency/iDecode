<%@ Page Title="" Language="C#" MasterPageFile="~/app/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="beats.aspx.cs" Inherits="app_admin_beats" %>

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
                            Beats <small><asp:Button runat="server" ID="btnNewBeat" Text="Add New" PostBackUrl="~/app/admin/beatedit.aspx?uid=0" CssClass="form-control btn-danger" /></small>
                        </h1>
                    </div>
                
                <br />
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Beat</th>
                                        <td></td>
                                    </tr>
                                </thead>
                                <tbody>                                       
                                        <asp:Repeater runat="server" ID="rptBeats" DataSourceID="dsBeats">
                                            <ItemTemplate>
                                                <tr class="odd gradeX">
                                                    <td><%# Eval("BeatID") %></td>
                                                    <td><%# Eval("BeatName") %></td>
                                                    <td class="center"><a href='<%#"beatedit.aspx?uid=" + Eval("beatid") %>'>edit</a></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                </tbody>
                            </table>
                        </div> 
                    </div>
                </div>
            </div>
    <asp:SqlDataSource ID="dsBeats" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
        SELECT BeatID, ISNULL(BeatName,'') AS BeatName FROM Beats ORDER BY BeatName" >
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
</asp:Content>

