﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_admin_beats : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["iUserID"] == null) { Response.Redirect("~/app/admin/login.aspx", true); }
        this.Page.Title = "iDecode | Beats";
    }

}