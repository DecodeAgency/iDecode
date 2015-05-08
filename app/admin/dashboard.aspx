<%@ Page Title="" Language="C#" MasterPageFile="~/app/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="app_admin_newdashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .list-group-item {
              padding: 29px 15px !Important;
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
                            Dashboard <small style="display:none">Summary of your App</small>
                        </h1>
                    </div>
                </div>
                <!-- /. ROW  -->
                <div class="row">
                    <a href="journalists.aspx">
                        <div class="col-md-3 col-sm-12 col-xs-12">
                            <div class="panel panel-primary text-center no-boder bg-color-green">
                                <div class="panel-body">
                                    <i class="fa fa-bar-chart-o fa-5x"></i>
                                    <h3><asp:literal runat="server" ID="litJournalistCount" /></h3>
                                </div>
                                <div class="panel-footer back-footer-green">
                                    Journalists
                                </div>
                            </div>
                        </div>
                    </a>
                    <a href="communicators.aspx">
                        <div class="col-md-3 col-sm-12 col-xs-12">
                            <div class="panel panel-primary text-center no-boder bg-color-blue">
                                <div class="panel-body">
                                    <i class="fa fa-shopping-cart fa-5x"></i>
                                    <h3><asp:literal runat="server" ID="litCommunicatorsCount" /></h3>
                                </div>
                                <div class="panel-footer back-footer-blue">
                                    Communicators
                                </div>
                            </div>
                        </div>
                    </a>
                    <a href="publications.aspx">
                        <div class="col-md-3 col-sm-12 col-xs-12">
                            <div class="panel panel-primary text-center no-boder bg-color-red">
                                <div class="panel-body">
                                    <i class="fa fa fa-comments fa-5x"></i>
                                    <h3><asp:Literal runat="server" ID="litPublicationsCount" /></h3>
                                </div>
                                <div class="panel-footer back-footer-red">
                                    Publications
                                </div>
                            </div>
                        </div>
                    </a>
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="panel panel-primary text-center no-boder bg-color-brown">
                            <div class="panel-body">
                                <i class="fa fa-users fa-5x"></i>
                                <h3><asp:Literal runat="server" ID="litUpdatedToday" /></h3>
                            </div>
                            <div class="panel-footer back-footer-brown">
                                Updated Past 24 Hours
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-9 col-sm-12 col-xs-12" style="display:none">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Bar Chart Example
                            </div>
                            <div class="panel-body">
                                <div id="morris-bar-chart"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-12 col-xs-12" style="display:none">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Donut Chart Example
                            </div>
                            <div class="panel-body">
                                <div id="morris-donut-chart"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /. ROW  -->
                <div class="row">
                    <div class="col-md-4 col-sm-12 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Control Panel Activity
                            </div>
                            <div class="panel-body">
                                <div class="list-group">
                                    <asp:Repeater runat="server" ID="rptRecentUpdates" DataSourceID="dsRecentUpdates" OnItemDataBound="rptRecentUpdates_ItemDataBound">
                                        <ItemTemplate>
                                            <a href="#" class="list-group-item">
                                               
                                                <i class="fa fa-fw fa-comment"></i> <asp:literal runat="server" ID="litUpdateStatus" />
                                                <span class="badge"><asp:literal runat="server" ID="litDatePosted" Text='<%# Eval ("DateTimeStamp") %>' /></span>
                                            </a>
                                            <asp:HiddenField runat="server" ID="hidUpdatedProfileID" Value='<%# Eval ("UpdatedProfileID") %>' />
                                            <asp:HiddenField runat="server" ID="hidActivityCreator" Value='<%# Eval ("UserID") %>' />                                              
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="text-right" style="display:none">
                                    <a href="#">More Tasks <i class="fa fa-arrow-circle-right"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8 col-sm-12 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Last 15 Updated Users
                            </div> 
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table class="table table-striped table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>F Name</th>
                                                <th>L Name</th>
                                                <th>Email</th>
                                                <th>Date</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptRecentlyUpdatedUser" DataSourceID="dsRecentlyUpdatedUsers">
                                                <ItemTemplate>                                                
                                                        <tr>
                                                            <td><%#Eval("FirstName")%></td>
                                                            <td><%#Eval("LastName")%></td>
                                                            <td><%#Eval("EmailAddress")%></td>
                                                            <td><%# Convert.ToDateTime(Eval("LastUpdatedDate")).ToString("dd MMM yyyy HH:MM") %></td>
                                                        </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <!-- /. ROW  -->
				<footer style="display:none"><p>All right reserved. Template by: <a href="http://webthemez.com">WebThemez</a></p></footer>
            </div>
            <asp:SqlDataSource ID="dsRecentlyUpdatedUsers" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
                SELECT TOP 15 UserID, 
                ISNULL(FirstName,'') AS FirstName, 
                ISNULL(LastName,'') AS LastName, 
                ISNULL(EmailAddress,'') AS EmailAddress,
                ISNULL(LastUpdatedDate,'') AS LastUpdatedDate
                FROM Users ORDER BY LastUpdatedDate DESC" >
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="dsRecentUpdates" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
                SELECT TOP 7 *, RIGHT(Trail,LEN(Trail) - CHARINDEX('=',Trail)) AS UpdatedProfileID FROM UserSessionTrails WHERE UserSessionTrailID IN (
	                SELECT MIN(UserSessionTrailID) FROM UserSessionTrails WHERE Trail LIKE '%edit%' GROUP BY Trail, DateTimeStamp  
                )
                ORDER BY DateTimeStamp DESC">
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

