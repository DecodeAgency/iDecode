using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class UserCampaignGroup
{
    private int iUserCampaignGroupID;
    private int iUserID = 0;
    private string sCampaignGroupName = "";

    public int UserCampaignGroupID
    {
        get { return iUserCampaignGroupID; }
    }

    public int UserID
    {
        get { return iUserID; }
        set { iUserID = value; }
    }

    public string CampaignGroupName
    {
        get { return sCampaignGroupName; }
        set { sCampaignGroupName = value; }
    }

	public UserCampaignGroup()
	{

	}

    public void Load(int ID)
    {
        string sSQL;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {
            iUserCampaignGroupID = ID;

            sSQL = "SELECT UserID, ISNULL(CampaignGroupName,'') AS CampaignGroupName FROM UserCampaignGroups";
            sSQL += " WHERE UserCampaignGroupID = " + ID.ToString();

            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iUserID = Convert.ToInt32(dr["UserID"].ToString());
                sCampaignGroupName = dr["CampaignGroupName"].ToString();                
            }
            else
            {
                iUserCampaignGroupID = 0;
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
                nonqueryCommand.CommandText = "INSERT INTO UserCampaignGroups (UserID, CampaignGroupName) VALUES (@UserID, @CampaignGroupName) ";
            }
            else
            {
                nonqueryCommand.CommandText = "UPDATE UserCampaignGroups SET UserID = @UserID, CampaignGroupName = @CampaignGroupName WHERE UserCampaignGroupID = " + iUserCampaignGroupID.ToString();
            }

            nonqueryCommand.Parameters.Add("@UserID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@CampaignGroupName", SqlDbType.VarChar);

            nonqueryCommand.Parameters["@UserID"].Value = iUserID;
            nonqueryCommand.Parameters["@CampaignGroupName"].Value = sCampaignGroupName;           

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
            nonqueryCommand.CommandText = "DELETE FROM UserCampaignGroups WHERE UserCampaignGroupID = " + iUserCampaignGroupID.ToString();
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