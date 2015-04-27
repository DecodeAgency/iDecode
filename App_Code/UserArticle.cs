using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class UserArticle
{
    private int iUserArticleID;
    private int iUserID = 0;
    private string sTitle = "";
    private string sMediaOutlet = "";
    private string sDescription = "";
    private string sURL = "";
    private DateTime dDatePublished = DateTime.Now;
    private string sImageFormat = "";
    private string sDocumentFormat = "";
    private bool bActive = false;
    private string sImageURL = "";

    public int UserArticleID
    {
        get { return iUserArticleID; }
    }

    public int UserID
    {
        get { return iUserID; }
        set { iUserID = value; }
    }

    public string Title
    {
        get { return sTitle; }
        set { sTitle = value; }
    }

    public string MediaOutlet
    {
        get { return sMediaOutlet; }
        set { sMediaOutlet = value; }
    }

    public string Description
    {
        get { return sDescription; }
        set { sDescription = value; }
    }
    public string URL
    {
        get { return sURL; }
        set { sURL = value; }
    }

    public DateTime DatePublished
    {
        get { return dDatePublished; }
        set { dDatePublished = value; }
    }

    public string ImageFormat
    {
        get { return sImageFormat; }
        set { sImageFormat = value; }
    }

    public string DocumentFormat
    {
        get { return sDocumentFormat; }
        set { sDocumentFormat = value; }
    }

    public bool Active
    {
        get { return bActive; }
        set { bActive = value; }
    }

    public string ImageURL
    {
        get { return sImageURL; }
        set { sImageURL = value; }
    }

    public UserArticle()
    {
        
    }

	public UserArticle(int ID, int UserID = 0)
	{
        Load(ID, UserID);
	}

    public void Load(int ID, int UserID = 0)
    {
        string sSQL;
        System.Data.SqlClient.SqlCommand cm;
        System.Data.SqlClient.SqlDataReader dr;
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        try
        {
            iUserArticleID = ID;
            iUserID = UserID;

            sSQL = "SELECT UserArticleID, ISNULL(UserID,0) AS UserID, ISNULL(Title,'') AS Title, ISNULL(MediaOutlet,'') AS MediaOutlet, ISNULL(Description,'') AS Description, ISNULL(URL,'') AS URL, ISNULL(DatePublished,GETDATE()) AS DatePublished, ISNULL(ImageFormat,'') AS ImageFormat, ISNULL(DocumentFormat,'') AS DocumentFormat, ISNULL(Active,'false') AS Active, ISNULL(ImageURL,'') AS ImageURL FROM UserArticles";
            if (ID != 0)
            {
                sSQL += " WHERE UserArticleID = " + ID.ToString();
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
                iUserArticleID = Convert.ToInt32(dr["UserArticleID"].ToString());
                iUserID = Convert.ToInt32(dr["UserID"].ToString());
                sTitle = dr["Title"].ToString();
                sMediaOutlet = dr["MediaOutlet"].ToString();
                sDescription = dr["Description"].ToString();
                sURL = dr["URL"].ToString();
                dDatePublished = Convert.ToDateTime(dr["DatePublished"].ToString());
                sImageFormat = dr["ImageFormat"].ToString();
                sDocumentFormat = dr["DocumentFormat"].ToString();
                bActive = Convert.ToBoolean(dr["Active"].ToString());
                sImageURL = dr["ImageURL"].ToString();
            }
            else
            {
                iUserArticleID = 0;
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
                nonqueryCommand.CommandText = "INSERT INTO UserArticles (UserID, Title, MediaOutlet, Description, URL, DatePublished, ImageFormat, DocumentFormat, Active, ImageURL) VALUES (@UserID, @Title, @MediaOutlet, @Description, @URL, @DatePublished, @ImageFormat, @DocumentFormat, @Active, @ImageURL)";
            }
            else
            {
                nonqueryCommand.CommandText = "UPDATE UserArticles SET UserID = @UserID, Title = @Title, MediaOutlet = @MediaOutlet, Description = @Description, URL = @URL, DatePublished = @DatePublished, ImageFormat = @ImageFormat, DocumentFormat = @DocumentFormat, Active = @Active, ImageURL = @ImageURL WHERE UserArticleID = " + iUserArticleID.ToString();
            }

            nonqueryCommand.Parameters.Add("@UserID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@Title", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@MediaOutlet", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Description", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@URL", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@DatePublished", SqlDbType.DateTime);
            nonqueryCommand.Parameters.Add("@ImageFormat", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@DocumentFormat", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Active", SqlDbType.Bit);
            nonqueryCommand.Parameters.Add("@ImageURL", SqlDbType.VarChar);

            nonqueryCommand.Parameters["@UserID"].Value = iUserID;
            nonqueryCommand.Parameters["@Title"].Value = sTitle;
            nonqueryCommand.Parameters["@MediaOutlet"].Value = sMediaOutlet;
            nonqueryCommand.Parameters["@Description"].Value = sDescription;
            nonqueryCommand.Parameters["@URL"].Value = sURL;
            nonqueryCommand.Parameters["@DatePublished"].Value = dDatePublished;
            nonqueryCommand.Parameters["@ImageFormat"].Value = sImageFormat;
            nonqueryCommand.Parameters["@DocumentFormat"].Value = sDocumentFormat;
            nonqueryCommand.Parameters["@Active"].Value = bActive;
            nonqueryCommand.Parameters["@ImageURL"].Value = sImageURL;

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
            nonqueryCommand.CommandText = "DELETE FROM UserArticles WHERE UserArticleID = " + iUserArticleID.ToString();
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