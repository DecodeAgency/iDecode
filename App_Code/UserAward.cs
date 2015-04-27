using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class UserAward
{
    private int iUserAwardID = 0;
    private string sAwardName = "";
    private string sYear = "";
    private string sCategory = "";
    private string sDescription = "";
    private string sArticleURL = "";
    private int iUserID = 0;
    private bool bActive = false;

    public int UserAwardID {
        get { return iUserAwardID; }
    }

    public string AwardName {
        get { return sAwardName; }
        set { sAwardName = value; }
    }

    public string Year {
        get { return sYear; }
        set { sYear = value; }
    }

    public string Category{
        get { return Category; }
        set { sCategory = value; }
    }

    public string Description
    {
        get { return sDescription; }
        set { sDescription = value; }
    }

    public string ArticleURL
    {
        get { return sArticleURL; }
        set { sArticleURL = value; }
    }

    public int UserID
    {
        get { return iUserID; }
        set { iUserID = value; }
    }

    public bool Active {
        get { return bActive; }
        set { bActive = value; }
    }
	public UserAward()
	{

	}

    public void Load(int ID, int UserID = 0)
    {
        string sSQL;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {
            iUserAwardID = ID;
            iUserID = UserID;

            sSQL = "SELECT UserAwardID, ISNULL(AwardName,'') AS AwardName, ISNULL(Year,'') AS Year, ISNULL(Category,'') AS Category, ISNULL(Description,'') AS Description, ISNULL(ArticleURL,'') AS ArticleURL, ISNULL(UserID,0) AS UserID, ISNULL(Active,'false') AS Active FROM UserAwards";
            if (ID != 0)
            {
                sSQL += " WHERE UserAwardID = " + ID.ToString();
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
                iUserAwardID = Convert.ToInt32(dr["UserAwardID"].ToString());
                sAwardName = dr["AwardName"].ToString();
                sYear = dr["Year"].ToString();
                sCategory = dr["Category"].ToString();
                sDescription = dr["Description"].ToString();
                sArticleURL = dr["ArticleURL"].ToString();
                iUserID = Convert.ToInt32(dr["UserID"].ToString());
                bActive = Convert.ToBoolean(dr["Active"].ToString());
            }
            else
            {
                iUserAwardID = 0;
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
                nonqueryCommand.CommandText = "INSERT INTO UserAwards (AwardName, Year, Category, Description, ArticleURL, UserID, Active) VALUES (@AwardName, @Year, @Category, @Description, @ArticleURL, @UserID, @Active)";
            }
            else
            {
                nonqueryCommand.CommandText = "UPDATE Users SET AwardName = @AwardName, Year = @Year, Category = @Category, Description = @Description, ArticleURL = @ArticleURL, UserID = @UserID, Active = @Active WHERE UserAwardID = " + iUserAwardID.ToString();
            }

            nonqueryCommand.Parameters.Add("@AwardName", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Year", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Category", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@Description", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@ArticleURL", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@UserID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@Active", SqlDbType.Bit);

            nonqueryCommand.Parameters["@AwardName"].Value = sAwardName;
            nonqueryCommand.Parameters["@Year"].Value = sYear;
            nonqueryCommand.Parameters["@Category"].Value = sCategory;
            nonqueryCommand.Parameters["@Description"].Value = sDescription;
            nonqueryCommand.Parameters["@ArticleURL"].Value = sArticleURL;
            nonqueryCommand.Parameters["@UserID"].Value = iUserID;
            nonqueryCommand.Parameters["@Active"].Value = bActive;

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
            nonqueryCommand.CommandText = "DELETE FROM UserAwards WHERE UserAwardID = " + iUserAwardID.ToString();
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