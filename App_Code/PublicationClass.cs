using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Publication
/// </summary>
public class PublicationClass
{
    private int iPublicationID;
    private string sPublication = "";
    private string sWebsite = "";
    private int iLanguageID = 0;

    public int PublicationID {
        get { return iPublicationID; }
    }

    public string Publication {
        get { return sPublication; }
        set { sPublication = value; }
    }

    public string Website {
        get { return sWebsite; }
        set { sWebsite = value; }
    }

    public int LanguageID
    {
        get { return iLanguageID; }
        set { iLanguageID = value; }
    }

	public PublicationClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public PublicationClass(int ID)
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
            iPublicationID = ID;

            sSQL = "SELECT PublicationID, ISNULL(Publication,'') AS Publication, ISNULL(Website,'') AS Website, ISNULL(LanguageID,0) AS LanguageID FROM Publications WHERE PublicationID = " + iPublicationID.ToString();


            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iPublicationID = Convert.ToInt32(dr["PublicationID"].ToString());
                sPublication = dr["Publication"].ToString(); 
                sWebsite = dr["Website"].ToString();
                iLanguageID = Convert.ToInt32(dr["LanguageID"].ToString()); 
            }
            else
            {
                iPublicationID = 0;
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
                nonqueryCommand.CommandText = "INSERT INTO Publications (Publication, Website, LanguageID) VALUES (@Publication, @Website, @LanguageID)";
            }
            else
            {
                nonqueryCommand.CommandText = "UPDATE Publications SET Publication = @Publication, Website = @Website, LanguageID = @LanguageID WHERE PublicationID = " + iPublicationID.ToString();
            }

            nonqueryCommand.Parameters.Add("@Publication", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Website", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@LanguageID", SqlDbType.Int);

            nonqueryCommand.Parameters["@Publication"].Value = sPublication;
            nonqueryCommand.Parameters["@Website"].Value = sWebsite;
            nonqueryCommand.Parameters["@LanguageID"].Value = iLanguageID;

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
            nonqueryCommand.CommandText = "DELETE FROM Publications WHERE PublicationID = " + iPublicationID.ToString();
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