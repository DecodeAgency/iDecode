using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class UserCampaign
{

    private int iUserCampaignID;
    private int iUserID = 0;
    private string sMailChimpListID = "";
    private string sSubject = "";
    private string sFromEmail = "";
    private string sFromName = "";
    private string sToName = "";
    private int iTemplateID = 0;
    private string sTitle = "";
    private string sCampaignContent = "";
    private DateTime dDateTimeStamp = DateTime.Now;
    private DateTime dLastUpdatedDate = DateTime.Now;
    private string sMailChimpCampaignID = "";

    public int UserCampaignID
    {
        get { return iUserCampaignID; }
    }

    public int UserID
    {
        get { return iUserID; }
        set { iUserID = value; }
    }

    public string MailChimpListID
    {
        get { return sMailChimpListID; }
        set { sMailChimpListID = value; }
    }

    public string Subject
    {
        get { return sSubject; }
        set { sSubject = value; }
    }

    public string FromEmail
    {
        get { return sFromEmail; }
        set { sFromEmail = value; }
    }

    public string FromName
    {
        get { return sFromName; }
        set { sFromName = value; }
    }

    public string ToName
    {
        get { return sToName; }
        set { sToName = value; }
    }

    public int TemplateID
    {
        get { return iTemplateID; }
        set { iTemplateID = value; }
    }

    public string Title
    {
        get { return sTitle; }
        set { sTitle = value; }
    }

    public string CampaignContent
    {
        get { return sCampaignContent; }
        set { sCampaignContent = value; }
    }

    public DateTime DateTimeStamp
    {
        get { return dDateTimeStamp; }
        set { dDateTimeStamp = value; }
    }

    public DateTime LastUpdatedDate
    {
        get { return dLastUpdatedDate; }
        set { dLastUpdatedDate = value; }
    }

    public string MailChimpCampaignID
    {
        get { return sMailChimpCampaignID; }
        set { sMailChimpCampaignID = value; }
    }

	public UserCampaign()
	{

	}

    public UserCampaign(int ID)
    {
        Load(ID);
    }

    public void Load(int ID)
    {
        string sSQL;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {
            iUserCampaignID = ID;

            sSQL = "SELECT UserCampaignID, ISNULL(UserID,0) AS UserID, ISNULL(MailChimpListID,'') AS MailChimpListID,ISNULL(Subject,'') AS Subject, ";
            sSQL += "ISNULL(FromEmail,'') AS FromEmail, ISNULL(FromName,'') AS FromName, ISNULL(ToName,'') AS ToName, ";
            sSQL += "ISNULL(TemplateID,0) AS TemplateID, ISNULL(Title,'') AS Title, ISNULL(CampaignContent,'') AS CampaignContent, ";
            sSQL += "ISNULL(DateTimeStamp,GETDATE()) AS DateTimeStamp, ISNULL(LastUpdatedDate,GETDATE()) AS LastUpdatedDate, ISNULL(MailChimpCampaignID,'') AS MailChimpCampaignID ";
            sSQL += "FROM UserCampaigns ";
            sSQL += "WHERE UserCampaignID = " + ID.ToString();

            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iUserCampaignID = Convert.ToInt32(dr["UserCampaignID"].ToString());
                iUserID = Convert.ToInt32(dr["UserID"].ToString());
                sMailChimpListID = dr["MailChimpListID"].ToString();
                sSubject = dr["Subject"].ToString();
                sFromEmail = dr["FromEmail"].ToString();
                sFromName = dr["FromName"].ToString();
                sToName = dr["ToName"].ToString();
                iTemplateID = Convert.ToInt32(dr["TemplateID"].ToString());
                sTitle = dr["Title"].ToString();
                sCampaignContent = dr["CampaignContent"].ToString();
                dDateTimeStamp = Convert.ToDateTime(dr["DateTimeStamp"].ToString()); ;
                dLastUpdatedDate = Convert.ToDateTime(dr["LastUpdatedDate"].ToString());
                sMailChimpCampaignID = dr["MailChimpCampaignID"].ToString(); ;
            }
            else
            {
                iUserCampaignID = 0;
            }

            dr.Close();
            cm.Connection.Close();
            cm.Dispose();
        }
        catch (InvalidCastException e)
        {
            throw (e);
        }
        dr = null;
        cm.Connection = null;
        cm = null;

    }/*End Load Sub*/

    public int Save(int TypeID)
    {
        int newId = 0;
        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        try
        {
            thisConnection.Open();
            if (TypeID == 1)
            {
                nonqueryCommand.CommandText = "INSERT INTO UserCampaigns (UserID, MailChimpListID, Subject, FromEmail, FromName, ToName, TemplateID, Title, CampaignContent, DateTimeStamp, LastUpdatedDate, MailChimpCampaignID) VALUES (@UserID, @MailChimpListID, @Subject, @FromEmail, @FromName, @ToName, @TemplateID, @Title, @CampaignContent, @DateTimeStamp, @LastUpdatedDate, @MailChimpCampaignID); SELECT SCOPE_IDENTITY() ";
            }
            else
            {
                nonqueryCommand.CommandText = "UPDATE UserCampaigns SET UserID = @UserID, MailChimpListID = @MailChimpListID, Subject = @Subject, FromEmail = @FromEmail, FromName = @FromName, ToName = @ToName, TemplateID = @TemplateID, Title = @Title, CampaignContent = @CampaignContent, DateTimeStamp = @DateTimeStamp, LastUpdatedDate = @LastUpdatedDate, MailChimpCampaignID = @MailChimpCampaignID WHERE UserCampaignID = " + iUserCampaignID.ToString();
            }

            nonqueryCommand.Parameters.Add("@UserID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@MailChimpListID", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Subject", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@FromEmail", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@FromName", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@ToName", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@TemplateID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@Title", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@CampaignContent", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime);
            nonqueryCommand.Parameters.Add("@LastUpdatedDate", SqlDbType.DateTime);
            nonqueryCommand.Parameters.Add("@MailChimpCampaignID", SqlDbType.VarChar);

            nonqueryCommand.Parameters["@UserID"].Value = iUserID;
            nonqueryCommand.Parameters["@MailChimpListID"].Value = sMailChimpListID;
            nonqueryCommand.Parameters["@Subject"].Value = sSubject;
            nonqueryCommand.Parameters["@FromEmail"].Value = sFromEmail;
            nonqueryCommand.Parameters["@FromName"].Value = sFromName;
            nonqueryCommand.Parameters["@ToName"].Value = sToName;
            nonqueryCommand.Parameters["@TemplateID"].Value = iTemplateID;
            nonqueryCommand.Parameters["@Title"].Value = sTitle;
            nonqueryCommand.Parameters["@CampaignContent"].Value = sCampaignContent;
            nonqueryCommand.Parameters["@DateTimeStamp"].Value = dDateTimeStamp;
            nonqueryCommand.Parameters["@LastUpdatedDate"].Value = dLastUpdatedDate;
            nonqueryCommand.Parameters["@MailChimpCampaignID"].Value = sMailChimpCampaignID;

            
            if (TypeID == 1)
            {
                newId = Convert.ToInt32(nonqueryCommand.ExecuteScalar());
            }
            else 
            {
                nonqueryCommand.ExecuteNonQuery();
            }
 
        }
        catch (InvalidCastException e)
        {
            throw (e);
        }
        thisConnection.Close();
        return newId;
    } /*End Save*/

    public Boolean Delete()
    {
        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        try
        {
            thisConnection.Open();
            nonqueryCommand.CommandText = "DELETE FROM UserCampaigns WHERE UserCampaignID = " + iUserCampaignID.ToString();
            nonqueryCommand.ExecuteNonQuery();
        }
        catch (InvalidCastException e)
        {
            throw (e);
        }
        thisConnection.Close();
        return true;
    }
}