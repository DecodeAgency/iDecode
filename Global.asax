<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("LoginRoute", "app/login", "~/app/login.aspx");
        routes.MapPageRoute("RegisterRoute", "app/register", "~/app/register.aspx");
        routes.MapPageRoute("LogOutRoute", "app/logout", "~/app/login.aspx?logout=true");
        routes.MapPageRoute("DashboardRoute", "app/journalists/dashboard", "~/app/journalists/dashboard.aspx");
        routes.MapPageRoute("JournalistSearchRoute", "app/journalists/search", "~/app/journalists/search.aspx");
        routes.MapPageRoute("CommunicatorSearchRoute", "app/communicators/search", "~/app/communicators/search.aspx");
        routes.MapPageRoute("ProfileRouteEdit", "app/edit/journalist", "~/app/journalists/profileedit.aspx");

        routes.MapPageRoute("JournalistProfileRoute", "app/journalist/{userid}/{username}", "~/app/journalists/profile.aspx");
        routes.MapPageRoute("CommunicatorProfileRoute", "app/communicator/{userid}/{username}", "~/app/journalists/profile.aspx");
        //routes.MapPageRoute("journalists", "journalists", "~/profile.aspx");
        //routes.MapPageRoute("", "eish", "~/Default.aspx");
    }
       
</script>
