using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_admin_AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.RawUrl.Contains("dashboard"))
        {
            aDashboard.Attributes.Add("class", "active-menu");
        }
        else if (Request.RawUrl.Contains("journalists"))
        {
            aJournalist.Attributes.Add("class", "active-menu");
        }
        else if (Request.RawUrl.Contains("communicators"))
        {
            aCommunicators.Attributes.Add("class", "active-menu");
        }
        else if (Request.RawUrl.Contains("publications"))
        {
            aPublications.Attributes.Add("class", "active-menu");
        }
        else if (Request.RawUrl.Contains("beat"))
        {
            aBeats.Attributes.Add("class", "active-menu");
        }

        if (Session["iUserID"] == null) {
            divNavBarTopLinks.Visible = false;
        }

        //if (Request.RawUrl.Contains("journalistedit.aspx"))
        //{
        //    litJournalistsDropDown.Visible = true;
        //}

        //if (Request.RawUrl.Contains("communicatoredit.aspx"))
        //{
        //    liCommunicatorsDropdown.Visible = true;
        //}
    }
}
