using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MailChimp;
using MailChimp.Lists;

public partial class app_admin_beatedit : System.Web.UI.Page
{
    const string sAPIKey = "c71be3cd3f3421bbd16f7e06968b1a5c-us8";
    string sPostURL = "https://us8.api.mailchimp.com/2.0/";
    const string sListID = "a6e338b2b3"; //iDecode Press Releases List ID
    MailChimpManager mc = new MailChimpManager(sAPIKey);

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["iUserID"] == null) { Response.Redirect("~/app/admin/login.aspx", true); }
            this.Page.Title = "iDecode | Manage Beat";

            if (!IsPostBack)
            {
                int iBeatID = Convert.ToInt32(Request.QueryString["uid"].ToString());
                var oBeat = new Beat(iBeatID);
                txtBeat.Text = oBeat.BeatName;
                chkIsPublic.Checked = oBeat.IsPublic;
            }
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }
    }

    protected void btnSaveBeat_Click(object sender, EventArgs e)
    {
        try
        {
            int iBeatID = Convert.ToInt32(Request.QueryString["uid"].ToString());
            var oBeat = new Beat(iBeatID);
            

            
            //var oUserCampaignGroup = new UserCampaignGroup();
            //oUserCampaignGroup.UserID = Convert.ToInt32(Session["iUserID"].ToString());
            //oUserCampaignGroup.CampaignGroupName = txtCampaignGroupName.Text;
            //oUserCampaignGroup.Save(1);

            ///txtSuccessMessage.Visible = true;
            //divMessage.Visible = true;

            //txtCampaignGroupName.Text = "";

            if (iBeatID == 0)
            {
                oBeat.BeatName = txtBeat.Text;
                oBeat.IsPublic = chkIsPublic.Checked;

                List<InterestGrouping> results = mc.GetListInterestGroupings(sListID);
                mc.AddListInterestGroup(sListID, txtBeat.Text, results[0].Id);
                oBeat.Save(1);
                Response.Redirect("~/app/admin/beats.aspx");
            }
            else if (iBeatID != 0) {
                List<InterestGrouping> results = mc.GetListInterestGroupings(sListID);
                mc.UpdateListInterestGroup(sListID, oBeat.BeatName, txtBeat.Text, results[0].Id);
                oBeat.BeatName = txtBeat.Text;
                oBeat.IsPublic = chkIsPublic.Checked;
                oBeat.Save(2);
            }
            
        }
        catch (Exception ex)
        {
            var oGeneralFunctions = new GeneralFunctions();
            oGeneralFunctions.UserError(Convert.ToInt32(Session["iUserID"].ToString()), ex.ToString());
        }  
    }
}