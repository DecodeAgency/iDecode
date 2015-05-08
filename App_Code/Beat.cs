using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class Beat
{
    private int iBeatID;
    private string sBeatName = "";
    private Boolean bIsPublic = false;

    public int BeatID
    {
        get { return iBeatID; }
    }

    public string BeatName
    {
        get { return sBeatName; }
        set { sBeatName = value; }
    }

    public Boolean IsPublic
    {
        get { return bIsPublic; }
        set { bIsPublic = value; }
    }

	public Beat()
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
            iBeatID = ID;

            sSQL = "SELECT BeatID, INSNULL(BeatName,'') AS BeatName, ISNULL(IsPublic,'false') AS IsPublic FROM Beats ";
            sSQL += "WHERE BeatID = " + ID.ToString();

            cm = new SqlCommand(sSQL, new SqlConnection(sConStr));
            cm.Connection.Open();
            dr = cm.ExecuteReader();

            if (dr.Read())
            {
                iBeatID = Convert.ToInt32(dr["BeatID"].ToString());
                sBeatName = dr["BeatName"].ToString();
                bIsPublic = Convert.ToBoolean(dr["IsPublic"].ToString());

            }
            else
            {
                iBeatID = 0;
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
                nonqueryCommand.CommandText = "INSERT INTO Beats (BeatName, IsPublic) VALUES (@BeatName, @IsPublic); SELECT SCOPE_IDENTITY() ";
            }
            else
            {
                nonqueryCommand.CommandText = "UPDATE Beats SET BeatName = @BeatName, IsPublic = @IsPublic WHERE BeatID = " + iBeatID.ToString();
            }

            nonqueryCommand.Parameters.Add("@BeatName", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@IsPublic", SqlDbType.Bit);

            nonqueryCommand.Parameters["@BeatName"].Value = sBeatName;
            nonqueryCommand.Parameters["@IsPublic"].Value = bIsPublic;

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
    } 

    public Boolean Delete()
    {
        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        try
        {
            thisConnection.Open();
            nonqueryCommand.CommandText = "DELETE FROM Beats WHERE BeatID = " + iBeatID.ToString();
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