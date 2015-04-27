using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Net;

public partial class app_MailChimpTests : System.Web.UI.Page
{
    const string sAPIKey = "c71be3cd3f3421bbd16f7e06968b1a5c-us8";
    string sPostURL = "https://us8.api.mailchimp.com/2.0/";
    const string sID = "a6e338b2b3"; //iDecode Press Releases List ID
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCreateListGroup_Click(object sender, EventArgs e)
    {
        CreateListGroup("");
    }

    protected void btnUpdateListGroup_Click(object sender, EventArgs e)
    {
        UpdateListGroup("getting it right","getting it right updated");
    }
    
    protected void btnDeleteListGroup_Click(object sender, EventArgs e)
    {
        DeleteListGroup("i make stuff happen");
    }

    public bool CreateListGroup(string sListGroupName) {
        try 
        {
            sPostURL += "/lists/interest-group-add.format?apikey=" + sAPIKey + "&id=" + sID + "&group_name=" + sListGroupName;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(sPostURL);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "GET";


            WebResponse response = httpWebRequest.GetResponse();
            String responseString = "";
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            litResul.Text = responseString.ToString();

            return true;
        }catch(Exception ex)
        {
            return false;
        }
    }

    public bool UpdateListGroup(string sListGroupNameOld, string sListGroupNameNew)
    {
        try
        {
            sPostURL += "/lists/interest-grouping-update.format?apikey=" + sAPIKey + "&name=" + sListGroupNameOld + "&value=" + sListGroupNameNew;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(sPostURL);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "GET";


            WebResponse response = httpWebRequest.GetResponse();
            String responseString = "";
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            litResul.Text = responseString.ToString();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool DeleteListGroup(string sListGroupName) {
        try
        {
            sPostURL += "/lists/interest-group-del.format?apikey=" + sAPIKey + "&id=" + sID + "&group_name=" + sListGroupName;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(sPostURL);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "GET";


            WebResponse response = httpWebRequest.GetResponse();
            String responseString = "";
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            litResul.Text = responseString.ToString();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }    
    }

    public bool AddSubscriber()
    {
        return false;
    }
}