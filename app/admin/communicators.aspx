<%@ Page Title="" Language="C#" MasterPageFile="~/app/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="communicators.aspx.cs" Inherits="app_admin_communicators" %>

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
                            Communicators <small style="display:none">Summary of your App</small>
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
                                        <th>Last Name</th>
                                        <th>First Name</th>
                                        <th>Email Address</th>
                                        <th>Last Updated</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>                                       
                                        <asp:Repeater runat="server" ID="rptJournalists" DataSourceID="dsJournalists">
                                            <ItemTemplate>
                                                <tr class="odd gradeX">
                                                    <td><%# Eval("UserID") %></td>
                                                    <td><%# Eval("LastName") %></td>
                                                    <td><%# Eval("FirstName") %></td>
                                                    <td class="center"><%# Eval("EmailAddress") %></td>
                                                    <td class="center"><%# Convert.ToDateTime(Eval("LastUpdatedDate")).ToString("dd MMM yyyy HH:MM") %></td>
                                                    <td class="center"><a href='<%#"journalistedit.aspx?uid=" + Eval("UserID") %>'>edit</a></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                </tbody>
                            </table>
                        </div> 
                    </div>
                </div>
            </div>
            <asp:SqlDataSource ID="dsJournalists" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
                SELECT U.UserID, ISNULL(U.FirstName,'') AS FirstName,ISNULL(U.LastName,'') AS LastName, ISNULL(U.CurrentJobTitle,'') AS CurrentJobTitle, ISNULL(U.LastUpdatedDate,'1 Jan 1990') AS LastUpdatedDate, 
                    ISNULL(U.CurrentJobPublication,'') AS CurrentJobPublication, (CASE WHEN ISNULL(U.TwitterProfileImageURL,'') = '' AND ISNULL(U.ImageFormat,'') = '' THEN 'http://test.idecode.co.za/app/images/profileimages/0.png' ELSE U.TwitterProfileImageURL END) AS ProfileImage , 
                    ISNULL(U.BeatID,0) AS BeatID, ISNULL(U.CurrentCity,'') AS CurrentCity, ISNULL(U.ContactMobile,'') AS ContactMobile, ISNULL(U.ContactOffice,'') AS ContactOffice, ISNULL(U.FaxNumber,'') AS FaxNumber, ISNULL(U.EmailAddress,'') AS EmailAddress FROM Users U 
                    WHERE U.UserTypeID = 3 ORDER BY LastUpdatedDate DESC" >
            </asp:SqlDataSource>
            <div style="display:none; background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
                   <div class="Width960"><h1>Communicators</h1></div>
            </div>
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
    <div style="float:right;display:none">
        <asp:Button Width="130" CssClass="BackButton" runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" />
    </div>
</asp:Content>

