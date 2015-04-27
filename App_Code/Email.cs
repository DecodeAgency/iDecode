using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
/// <summary>
/// Summary description for Emails
/// </summary>
public class Email
{
	public Email()
	{

	}

    public void InstitutionNoticationStudentRegistration(string sName, string sInstitutionName, string sToEmailAddress)
    {
        try {
            string ToAddress = sToEmailAddress;

            //(1) Create the MailMessage instance
            var mm = new MailMessage("info@cloudvarsity.co.za", ToAddress);
            mm.Bcc.Add("info@cloudvarsity.co.za");
            //(2) Assign the MailMessage's properties
            mm.Subject = "Student Registration: " + sName;
            mm.Body = "<html>";
            mm.Body += "<head>";
            mm.Body += "<title>";
            mm.Body += "</title>";
            mm.Body += "</head>";
            mm.Body += "<body>";
            mm.Body += "Hi " + sInstitutionName + ",<br/><br/>";
            mm.Body += sName + " has registered for your institution on CloudVarsity. Please log into the control panel to grant the student access to your institution's section.<br/><br/>";
            mm.Body += "</body>";
            mm.Body += "</html>";

            mm.IsBodyHtml = true;

            //(3) Create the SmtpClient object
            var smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("info@cloudvarsity.co.za", "Morongwa70@");
            //(4) Send the MailMessage (will use the Web.config settings)
            smtp.Send(mm);
        }
        catch { 
        }
        finally {
        }
    
    }

    public void InstitutionRegistered(string sInstitutitonName, string sEmailAddress, string sPassword, string sToEmailAddress)
    {
        try
        {
            string ToAddress = sToEmailAddress;

            //(1) Create the MailMessage instance
            var mm = new MailMessage("info@cloudvarsity.co.za", ToAddress);
            mm.Bcc.Add("info@cloudvarsity.co.za");
            //(2) Assign the MailMessage's properties
            mm.Subject = "Welcome to CloudVarsity: " + sInstitutitonName;
            mm.Body = "<html>";
            mm.Body += "<head>";
            mm.Body += "<title>";
            mm.Body += "</title>";
            mm.Body += "</head>";
            mm.Body += "<body>";
            mm.Body += "Hi " + sInstitutitonName + ",<br/><br/>";
            mm.Body += "You have successfully registered on CloudVarsity. Your account is pending approval from CloudVarsity, as soon as your account is approved and activated, you will be notified via email.<br/><br/>";
            mm.Body += "Your institution's administrator login details are:<br/><br/>";
            mm.Body += "<table>";
            mm.Body += "<tr>";
            mm.Body += "<td style=' width:250px '> <b>Username:</b> </td>";
            mm.Body += "<td>" + sEmailAddress + "</td>";
            mm.Body += "</tr>";
            mm.Body += "<tr>";
            mm.Body += "<td> <b>Password</b> </td>";
            mm.Body += "<td>" + sPassword + "</td>";
            mm.Body += "</tr>";
            mm.Body += "</table>";
            mm.Body += "</body>";
            mm.Body += "</html>";

            mm.IsBodyHtml = true;

            //(3) Create the SmtpClient object
            var smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("info@cloudvarsity.co.za", "Morongwa70@");
            //(4) Send the MailMessage (will use the Web.config settings)
            smtp.Send(mm);
        }
        catch { 
        }
        finally {
        }

    }

    public void StudentRegistered(string sName, string sInstitutionName, string sEmailAddress, string sPassword, string sToEmailAddress)
    {
        try
        {
            string ToAddress = sToEmailAddress;

            //(1) Create the MailMessage instance
            var mm = new MailMessage("info@cloudvarsity.co.za", ToAddress);
            mm.Bcc.Add("info@cloudvarsity.co.za");
            //(2) Assign the MailMessage's properties
            mm.Subject = "Welcome to CloudVarsity: " + sName;
            mm.Body = "<html>";
            mm.Body += "<head>";
            mm.Body += "<title>";
            mm.Body += "</title>";
            mm.Body += "</head>";
            mm.Body += "<body>";
            mm.Body += "Hi " + sName + ",<br/><br/>";
            mm.Body += "You have successfully registered on CloudVarsity. Your account is pending approval from " + sInstitutionName + ", as soon as your account is approved and activated, you will be notified via email.<br/><br/>";
            mm.Body += "After your account has been activated, you can use the following login details to access " + sInstitutionName + " on CloudVarsity:<br/><br/>";
            mm.Body += "<table>";
            mm.Body += "<tr>";
            mm.Body += "<td style=' width:250px '> <b>Username:</b> </td>";
            mm.Body += "<td>" + sEmailAddress + "</td>";
            mm.Body += "</tr>";
            mm.Body += "<tr>";
            mm.Body += "<td> <b>Password</b> </td>";
            mm.Body += "<td>" + sPassword + "</td>";
            mm.Body += "</tr>";
            mm.Body += "</table>";
            mm.Body += "</body>";
            mm.Body += "</html>";

            mm.IsBodyHtml = true;

            //(3) Create the SmtpClient object
            var smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("info@cloudvarsity.co.za", "Morongwa70@");
            //(4) Send the MailMessage (will use the Web.config settings)
            smtp.Send(mm);
        }
        catch
        {

        }
        finally { 
        
        }

    }


    public void ContactForm(string FullName, string ContactNumber, string EmailAddress, string Message) {
        try {

            string ToAddress = "lorato@decode.co.za";
            
            //(1) Create the MailMessage instance
            var mm = new MailMessage(EmailAddress, ToAddress);
            mm.Bcc.Add("obakeng@decode.co.za");
            mm.Bcc.Add("murerwa@decode.co.za");
            mm.Bcc.Add("sibabalo@decode.co.za");

            //(2) Assign the MailMessage's properties
            mm.Subject = "Contact Form: " + FullName;
            mm.Body = "<html style='font-family:Arial; font-size:11px'>";
            mm.Body += "<head>";
            mm.Body += "<title>";
            mm.Body += "</title>";
            mm.Body += "</head>";
            mm.Body += "<body>";
            mm.Body += "Hi Decoders,<br/><br/>";
            mm.Body += "Please see feedback from website contact form below and reply within 48 hours.<br/><br/>";
            mm.Body += "<table  style='font-family:Arial; font-size:11px'>";
            mm.Body += "<tr>";
            mm.Body += "<td style=' width:250px '> <b>Contact Person:</b> </td>";
            mm.Body += "<td>" + FullName + "</td>";
            mm.Body += "</tr>";
            mm.Body += "<tr>";
            mm.Body += "<td> <b>Contact Number</b> </td>";
            mm.Body += "<td>" + ContactNumber + "</td>";
            mm.Body += "</tr>";
            mm.Body += "<tr>";
            mm.Body += "<td> <b>Email Address:</b> </td>";
            mm.Body += "<td>" + EmailAddress + "</td>";
            mm.Body += "</tr>";
            mm.Body += "<tr>";
            mm.Body += "<td> <b>Message:</b> </td>";
            mm.Body += "<td>" + Message + "</td>";
            mm.Body += "</tr>";
            mm.Body += "</table>";
            mm.Body += "</body>";
            mm.Body += "</html>";

            mm.IsBodyHtml = true;

            //(3) Create the SmtpClient object
            var smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("obakeng@decode.co.za", "Morongwa70@");
            //(4) Send the MailMessage (will use the Web.config settings)
            smtp.Send(mm);    
        }
        catch { 
        }
        finally { 
        }

    }

    public void NewSubscriber(string FullName, string EmailAddress)
    {
        try
        {

            string ToAddress = "lorato@decode.co.za";

            //(1) Create the MailMessage instance
            var mm = new MailMessage(EmailAddress, ToAddress);
            mm.Bcc.Add("obakeng@decode.co.za");
            mm.Bcc.Add("murerwa@decode.co.za");
            mm.Bcc.Add("sibabalo@decode.co.za");

            //(2) Assign the MailMessage's properties
            mm.Subject = "New Mailing List Subscriber: " + FullName;
            mm.Body = "<html style='font-family:Arial; font-size:11px'>";
            mm.Body += "<head>";
            mm.Body += "<title>";
            mm.Body += "</title>";
            mm.Body += "</head>";
            mm.Body += "<body>";
            mm.Body += "Hi Decoders,<br/><br/>";
            mm.Body += "Please see subscriber details below:<br/><br/>";
            mm.Body += "<table  style='font-family:Arial; font-size:11px'>";
            mm.Body += "<tr>";
            mm.Body += "<td style=' width:250px '> <b>Name:</b> </td>";
            mm.Body += "<td>" + FullName + "</td>";
            mm.Body += "</tr>";
            mm.Body += "<tr>";
            mm.Body += "<td> <b>Email Address:</b> </td>";
            mm.Body += "<td>" + EmailAddress + "</td>";
            mm.Body += "</tr>";
            mm.Body += "</table>";
            mm.Body += "</body>";
            mm.Body += "</html>";

            mm.IsBodyHtml = true;

            //(3) Create the SmtpClient object
            var smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("obakeng@decode.co.za", "Morongwa70@");
            //(4) Send the MailMessage (will use the Web.config settings)
            smtp.Send(mm);
        }
        catch
        {
        }
        finally
        {
        }

    }

    public void SendError(string Error)
    {
        try
        {

            string ToAddress = "obakeng@decode.co.za";

            //(1) Create the MailMessage instance
            var mm = new MailMessage("hello@decode.co.za", ToAddress);
            //mm.Bcc.Add("obakeng@decode.co.za");
            //mm.Bcc.Add("murerwa@decode.co.za");
            //mm.Bcc.Add("sibabalo@decode.co.za");

            //(2) Assign the MailMessage's properties
            mm.Subject = "Error Email: " + DateTime.Now;
            mm.Body = "<html style='font-family:Arial; font-size:11px'>";
            mm.Body += "<head>";
            mm.Body += "<title>";
            mm.Body += "</title>";
            mm.Body += "</head>";
            mm.Body += "<body>";
            mm.Body += "Hi Decoders,<br/><br/>";
            mm.Body += "A system error has occured, please see error details below:<br/><br/>";
            mm.Body += "<table  style='font-family:Arial; font-size:11px'>";
            mm.Body += "<tr>";
            mm.Body += "<td style=' width:250px '> <b>Date:</b> </td>";
            mm.Body += "<td>" + DateTime.Now + "</td>";
            mm.Body += "</tr>";
            mm.Body += "<tr>";
            mm.Body += "<td> <b>Error Message:</b> </td>";
            mm.Body += "<td>" + Error + "</td>";
            mm.Body += "</tr>";
            mm.Body += "</table>";
            mm.Body += "</body>";
            mm.Body += "</html>";

            mm.IsBodyHtml = true;

            //(3) Create the SmtpClient object
            var smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("obakeng@decode.co.za", "Morongwa70@");
            //(4) Send the MailMessage (will use the Web.config settings)
            smtp.Send(mm);
        }
        catch
        {
        }
        finally
        {
        }

    }
}