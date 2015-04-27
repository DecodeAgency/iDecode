using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for UserJournalistSearch
/// </summary>
public class UserJournalistSearch
{
    private int iUserJournalistSearchID;
    private int iUserID = 0;
    private string sKeywords = "";
    private string sJournalist = "";
    private string sLocation = "";
    private int iMediaOutletID = 0;
    private DateTime dDateTimeStamp = DateTime.Now;
    private string sDepartment = "";

    public int UserJournalistSearchID{
        get { return iUserJournalistSearchID; }
    }

    public int UserID{
        set {iUserID = value;}
        get { return iUserID; }        
    }

    public string Keywords{
        set {sKeywords = value;}
        get { return sKeywords; }        
    }

    public string Journalist{
        set{sJournalist = value;}
        get {return sJournalist;}
    }

    public string Location{
        set { sLocation = value; }
        get { return sLocation; }
    }

    public int MediaOutletID{
        set { iMediaOutletID = value; }
        get { return iMediaOutletID; }
    }

    public DateTime DateTimeStamp {
        set { dDateTimeStamp = value; }
        get { return dDateTimeStamp; }
    }

    public string Department
    {
        set { sDepartment = value; }
        get { return sDepartment; }
    }

    public UserJournalistSearch()
    {
        
    }

	public UserJournalistSearch(int ID)
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
            iUserJournalistSearchID = ID;

            sSQL = "SELECT UserJournalistSearchID, ISNULL(UserID,0) AS UserID, ISNULL(Keywords,'') AS Keywords, ISNULL(Journalist,'') AS Journalist, ISNULL(Location,'') AS Location, ISNULL(MediaOutletID,0) AS MediaOutletID, ISNULL(DateTimeStamp,GETDATE()) AS DateTimeStamp, ISNULL(Department,'') AS Department FROM UserJournalistSearches";

            if (ID != 0)
            {
                sSQL += " WHERE UserJournalistSearchID = " + ID.ToString();
            }
            
            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iUserJournalistSearchID = Convert.ToInt32(dr["UserJournalistSearchID"].ToString());
                iUserID = Convert.ToInt32(dr["UserID"].ToString());
                sKeywords = dr["Keywords"].ToString();
                sJournalist = dr["Journalist"].ToString();                
                sLocation = dr["Location"].ToString();
                iMediaOutletID = Convert.ToInt32(dr["MediaOutletID"].ToString());
                dDateTimeStamp = Convert.ToDateTime(dr["DateTimeStamp"].ToString());
                sDepartment = dr["Department"].ToString();
            }
            else
            {
                iUserJournalistSearchID = 0;
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
    }


    public Boolean Save(int TypeID)
    {
        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        try
        {
            thisConnection.Open();
            if (TypeID == 1)
            {
                nonqueryCommand.CommandText = "INSERT INTO UserJournalistSearches (UserID, Keywords, Journalist, Location, MediaOutletID, DateTimeStamp, Department) VALUES (@UserID, @Keywords, @Journalist, @Location, @MediaOutletID, @DateTimeStamp, @Department) ";
            }
            else
            {
                nonqueryCommand.CommandText = "UPDATE UserJournalistSearches SET UserID = @UserID, Keywords = @Keywords, Journalist = @Journalist, Location = @Location, MediaOutletID = @MediaOutletID, DateTimeStamp = @DateTimeStamp, Department = @Department WHERE UserJournalistSearchID = " + iUserJournalistSearchID.ToString();
            }

            nonqueryCommand.Parameters.Add("@UserID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@Keywords", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Journalist", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Location", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@MediaOutletID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime);
            nonqueryCommand.Parameters.Add("@Department", SqlDbType.VarChar);

            nonqueryCommand.Parameters["@UserID"].Value = iUserID;
            nonqueryCommand.Parameters["@Keywords"].Value = sKeywords;
            nonqueryCommand.Parameters["@Journalist"].Value = sJournalist;
            nonqueryCommand.Parameters["@Location"].Value = sLocation;
            nonqueryCommand.Parameters["@MediaOutletID"].Value = iMediaOutletID;
            nonqueryCommand.Parameters["@DateTimeStamp"].Value = dDateTimeStamp;
            nonqueryCommand.Parameters["@Department"].Value = sLocation;

            nonqueryCommand.ExecuteNonQuery();
        }
        catch (InvalidCastException e)
        {
            throw (e);
        }
        thisConnection.Close();
        return true;
    } /*End Save*/

    public Boolean Delete()
    {
        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        try
        {
            thisConnection.Open();
            nonqueryCommand.CommandText = "DELETE FROM UserJournalistSearches WHERE UserJournalistSearchID = " + iUserJournalistSearchID.ToString();
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