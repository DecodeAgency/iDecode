using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class _default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            var oEmail = new Email();
            oEmail.ContactForm(txtFullName.Text, txtContactNumber.Text, txtEmailAddress.Text, txtMessage.Text);
            litContactFormResult.Visible = true;
            txtFullName.Text = "";
            txtContactNumber.Text = "";
            txtEmailAddress.Text = "";
            txtMessage.Text = "";
        }
        catch (Exception ex) { 
        
        }
        
    }
    protected void btnSubscribe_Click(object sender, EventArgs e)
    {
        try
        {
            var oEmail = new Email();
            oEmail.NewSubscriber(txtSubFirstName.Text, txtSubEmailAddress.Text);
            litSubscriberResult.Visible = true;
            txtSubFirstName.Text = "";
            txtSubEmailAddress.Text = "";
        }
        catch (Exception ex) { 
        
        } 
    }
}