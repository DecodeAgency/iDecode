using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for UserJob
/// </summary>
public class UserJob
{
    private int iUserJobID;
    private int iUserID = 0;
    private string sPublication = "";
    private DateTime dStartDate = DateTime.Now;
    private DateTime dEndDate = DateTime.Now;
    private string sURL = "";
    private string sPosition = "";
    private string sDepartment = "";
    private Boolean bCurrentJob = false;

    public int UserJobID {
        get { return iUserJobID; }
    }
    public int UserID {
        get { return iUserID; }
        set { iUserID = value; }
    }

    public string Publication
    {
        get { return sPublication; }
        set { sPublication = value; }
    }

    public DateTime StartDate
    {
        get { return dStartDate; }
        set { dStartDate = value; }
    }

    public DateTime EndDate
    {
        get { return dEndDate; }
        set { dEndDate = value; }
    }

    public string URL
    {
        get { return sURL; }
        set { sURL = value; }
    }

    public string Position
    {
        get { return sPosition; }
        set { sPosition = value; }
    }

    public string Department
    {
        get { return sDepartment; }
        set { sDepartment = value; }
    }

    public Boolean CurrentJob
    {
        get { return bCurrentJob; }
        set { bCurrentJob = value; }
    }

    public UserJob()
	{

	}

    public UserJob(int ID, int iUserID = 0)
    {
        Load(ID, iUserID);
    }

    public void Load(int ID, int UserID = 0)
    {
        string sSQL;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {
            iUserJobID = ID;
            iUserID = UserID;

            sSQL = "SELECT ISNULL(UserJobID,0) AS UserJobID, ISNULL(UserID,0) AS UserID, ISNULL(Publication,'') AS Publication, ISNULL(StartDate,GETDATE()) AS StartDate, ISNULL(EndDate,GETDATE()) AS EndDate, ISNULL(URL,'') AS URL, ISNULL(Position,'') AS Position, ISNULL(Department,'') AS Department, ISNULL(CurrentJob,'false') AS CurrentJob FROM UserJobs";
            if (ID != 0)
            {
                sSQL += " WHERE UserJobID = " + iUserJobID.ToString();
            }
            else
            {
                sSQL += " WHERE UserID = " + UserID.ToString();
            }


            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iUserJobID = Convert.ToInt32(dr["UserJobID"].ToString());
                iUserID = Convert.ToInt32(dr["UserID"].ToString());
                sPublication = dr["Publication"].ToString();
                dStartDate = Convert.ToDateTime(dr["StartDate"].ToString());
                dEndDate = Convert.ToDateTime(dr["EndDate"].ToString());
                sURL = dr["URL"].ToString();
                sPosition = dr["Position"].ToString();
                sDepartment = dr["Department"].ToString();
                bCurrentJob = Convert.ToBoolean(dr["CurrentJob"].ToString());
            }
            else
            {
                iUserJobID = 0;
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

    public Boolean Save(int TypeID)
    {
        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        try
        {
            thisConnection.Open();
            if (TypeID == 1)
            {
                nonqueryCommand.CommandText = "INSERT INTO UserJobs (UserID, Publication, StartDate, EndDate, URL, Position, Department, CurrentJob) VALUES (@UserID, @Publication, @StartDate, @EndDate, @URL, @Position, @Department, @CurrentJob)";
            }
            else
            {
                nonqueryCommand.CommandText = "UPDATE UserJobs SET UserID = @UserID, Publication = @Publication, StartDate = @StartDate, EndDate = @EndDate, URL = @URL, Position = @Position, Department = @Department, CurrentJob = @CurrentJob WHERE UserJobID = " + iUserJobID.ToString();
            }

            nonqueryCommand.Parameters.Add("@UserID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@Publication", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@StartDate", SqlDbType.DateTime);
            nonqueryCommand.Parameters.Add("@EndDate", SqlDbType.DateTime);
            nonqueryCommand.Parameters.Add("@URL", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Position", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Department", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@CurrentJob", SqlDbType.Bit);

            nonqueryCommand.Parameters["@UserID"].Value = iUserID;
            nonqueryCommand.Parameters["@Publication"].Value = sPublication;
            nonqueryCommand.Parameters["@StartDate"].Value = dStartDate;
            nonqueryCommand.Parameters["@EndDate"].Value = dEndDate;
            nonqueryCommand.Parameters["@URL"].Value = sURL;
            nonqueryCommand.Parameters["@Position"].Value = sPosition;
            nonqueryCommand.Parameters["@Department"].Value = sDepartment;
            nonqueryCommand.Parameters["@CurrentJob"].Value = bCurrentJob;

            nonqueryCommand.ExecuteNonQuery();
        }
        catch (InvalidCastException e)
        {
            throw (e);
        }
        thisConnection.Close();
        return true;
    }

    public Boolean Delete()
    {
        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        try
        {
            thisConnection.Open();
            nonqueryCommand.CommandText = "DELETE FROM UserJobs WHERE UserJobID = " + iUserJobID.ToString();
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