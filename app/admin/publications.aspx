<%@ Page Title="" Language="C#" MasterPageFile="~/app/AppMasterPage.master" AutoEventWireup="true" CodeFile="publications.aspx.cs" Inherits="app_admin_publications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div style="background-color: #394165;border-color: #343a5c;height: 50px;margin-bottom: 10px;color: #fff;">
           <div class="Width960"><h1>Publications</h1></div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <div style="float:right">
        <asp:Button Width="130" CssClass="BackButton" runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" />
    </div>
    <div style="clear:both; height:5px"></div>
    <asp:GridView runat="server" ID="grvPublications" DataSourceID="dsPublications" AutoGenerateColumns="false" AllowPaging="true" PageSize="30" CssClass="GridViewTable" AlternatingRowStyle-CssClass="GridViewAlternatingRow">
        <Columns>
            <asp:TemplateField HeaderText="Publication" ItemStyle-Width="510px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:HiddenField runat="server" ID="hidPublicationID" Value='<%# Eval("PublicationID") %>' />
                    <asp:Literal ID="litPubliaction" runat="server" Text='<%# Eval("Publication") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Web Address" ItemStyle-Width="310px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Literal ID="litFirstName" runat="server" Text='<%# Eval("Website") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Language" ItemStyle-Width="310px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Literal ID="litEmailAddress" runat="server" Text='<%# Eval("Language") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="hypEdit" Text="edit" NavigateUrl='<%#"publicationedit.aspx?pid=" + Eval("publicationid") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="dsPublications" runat="server" ConnectionString="<%$ ConnectionStrings:CS %>" SelectCommand="
        SELECT PublicationID, ISNULL(Publication,'') AS Publication, ISNULL(Website,'') AS Website, 
        ISNULL(L.Language,'') AS Language FROM Publications P
        INNER JOIN Languages L ON L.LanguageID = P.LanguageID" >
    </asp:SqlDataSource>
</asp:Content>

