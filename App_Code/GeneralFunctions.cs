using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for GeneralFunctions
/// </summary>
public class GeneralFunctions
{
	public GeneralFunctions()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void UserError(int UserID, string Error)
    {
        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        try
        {
            thisConnection.Open();
            nonqueryCommand.CommandText = "INSERT INTO UserErrors (UserID, Error, DateTimeStamp) VALUES (@UserID, @Error, @DateTimeStamp) ";

            nonqueryCommand.Parameters.Add("@UserID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@Error", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime);

            nonqueryCommand.Parameters["@UserID"].Value = UserID;
            nonqueryCommand.Parameters["@Error"].Value = Error;
            nonqueryCommand.Parameters["@DateTimeStamp"].Value = DateTime.Now;

            nonqueryCommand.ExecuteNonQuery();

            var oEmail = new Email();
            oEmail.SendError(Error);
        }
        catch (InvalidCastException e)
        {
            throw (e);
        }
        thisConnection.Close();
    }

    public void UserSessionTrail(int UserID, string SessionID, string Trail)
    {
        var thisConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        SqlCommand nonqueryCommand = thisConnection.CreateCommand();

        try
        {
            thisConnection.Open();
            nonqueryCommand.CommandText = "INSERT INTO UserSessionTrails (UserID, SessionID, Trail, DateTimeStamp) VALUES (@UserID, @SessionID, @Trail, @DateTimeStamp) ";

            nonqueryCommand.Parameters.Add("@UserID", SqlDbType.Int);
            nonqueryCommand.Parameters.Add("@SessionID", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@Trail", SqlDbType.VarChar);
            nonqueryCommand.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime);

            nonqueryCommand.Parameters["@UserID"].Value = UserID;
            nonqueryCommand.Parameters["@SessionID"].Value = SessionID;
            nonqueryCommand.Parameters["@Trail"].Value = Trail;
            nonqueryCommand.Parameters["@DateTimeStamp"].Value = DateTime.Now;

            nonqueryCommand.ExecuteNonQuery();
        }
        catch (InvalidCastException e)
        {
            throw (e);
        }
        thisConnection.Close();
    } 
}