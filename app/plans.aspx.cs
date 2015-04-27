using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class app_plans : System.Web.UI.Page
{
    string URL = "https://dev-virtual.mygateglobal.com/PaymentPage.cfm";
    string TransactionMode = "0"; //0 = Test Mode. 1 = Live Mode

    string MerchantID = "4eb497c5-49c3-40eb-8060-d03a70899af9";
    string ApplicationID = "ac90de4-3469-40a5-b83d-de504600eb10";

    //Currency and price of transaction
    string Currency = "ZAR";
    string Amount = "0.01";

    //Redirect Details
    string RedirectSuccess = "http://localhost:8888/CodeSnippets/RCCBVirtual/processResults.aspx";
    string RedirectFailed = "http://localhost:8888/CodeSnippets/RCCBVirtual/processResults.aspx";

    //RCCB Variables
    //The frequency determines when the transaction will go off.
    string Frequency = "M|1";
    //This is the start date of the first reocurring transaction.
    string StartDate = "01-JUN-2015";
    string EndDate = "01-JUN-2015";

    //The amount that is to go ff after the initial amount specified above
    string RecurringAmount = "0.01";

    //Client details are used for reporting features in the MyGate web console
    string ClientName = "Mr J Soap";
    string ClientAccountNo = "Client12345";
    string ClientEmailAddress = "joe.soap@gmail.com";
    string ClientMobileNumber = "0821234567";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGetFreePackage_Click(object sender, EventArgs e)
    {

    }
    protected void btnGet99Package_Click(object sender, EventArgs e)
    {
//        @"<form name='Virtual Post' action='<% Response.Write(URL); %>' method='post'>
//            <input name='Mode' type='hidden' value='<% Response.Write(TransactionMode); %>' /> <br />
//            <input name='MerchantID' type='hidden' value='<% Response.Write(MerchantID); %>' /><br />
//            <input name='ApplicationID' type='hidden' value='<% Response.Write(ApplicationID); %>' /><br />
//            Amount: R<input name='Amount' type='text' value='<% Response.Write(Amount); %>' /><br />
//            <input name='Currency' type='hidden' value='<% Response.Write(Currency); %>' /><br />
//            <input name='RedirectSuccessfulURL' type='hidden' value='<% Response.Write(RedirectSuccess); %>' /><br />
//            <input name='RedirectFailedURL' type='hidden' value='<% Response.Write(RedirectFailed); %>' /><br />
//            <input type='hidden' name='ACCB_Frequency' value='<% Response.Write(Frequency); %>'><br />
//	        <input type='hidden' name='ACCB_StartDate' value='<% Response.Write(StartDate); %>'><br />
//	        <input type='hidden' name='ACCB_EndDate' value='<% Response.Write(EndDate); %>'><br />
//	        <input type='hidden' name='ACCB_Amount' value='<% Response.Write(RecurringAmount); %>'><br />
//	        <input type='hidden' name='ACCB_ClientName' value='<% Response.Write(ClientName); %>'><br />
//	        <input type='hidden' name='ACCB_ClientAccountNo' value='<% Response.Write(ClientAccountNo); %>'><br />
//	        <input type='hidden' name='ACCB_ClientEmailAddress' value='<% Response.Write(ClientEmailAddress); %>'><br />
//	        <input type='hidden' name='ACCB_ClientMobileNumber' value='<% Response.Write(ClientMobileNumber); %>'><br />
//	        <input type='hidden' name='ACCB_ClientSendSMS' value='<% Response.Write(SMSClient); %>'><br />
//	        <input type='hidden' name='ACCB_ClientSendEmail' value='<% Response.Write(EmailClient); %>'><br />
//            <input type='submit' name='submit' value='Process Transaction'>
//        </form>";
    }
}