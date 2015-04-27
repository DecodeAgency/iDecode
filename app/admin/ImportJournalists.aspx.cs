using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

public partial class app_admin_ImportJournalists : System.Web.UI.Page
{
    string sexcelconnectionstring = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        litResult.Text = "";
        importdatafromexcel(@"DecodeConsolidatedMedia20March.xls");
    }

    public void importdatafromexcel(string excelfilepath)
    {
    //declare variables - edit these based on your particular situation
        string ssqltable = "Users";
        System.Data.SqlClient.SqlCommand cm;
    // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have different
    string myexceldataquery = "SELECT Publication, StaffPosition, Title, FirstName,Surname,Email, Telephone, Facsimile, Website FROM [Consolidated$]";
    try
    {
        //create our connection strings
        string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + excelfilepath + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
        string sConStr = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        //execute a query to erase any previous data from our destination table
        string sclearsql = "delete from " + ssqltable;
        SqlConnection sqlconn = new SqlConnection(sConStr);
        //sqlcommand sqlcmd = new sqlcommand(sclearsql, sqlconn);
        cm = new SqlCommand(sclearsql, new SqlConnection(sConStr));
        cm.Connection.Open();
        sqlconn.Open();
        cm.ExecuteNonQuery();
        sqlconn.Close();
        cm.Connection.Close();
        //series of commands to bulk copy data from the excel file into our sql table
        OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
        OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
        oledbconn.Open();
        OleDbDataReader dr = oledbcmd.ExecuteReader();
        SqlBulkCopy bulkcopy = new SqlBulkCopy(sConStr);
        bulkcopy.DestinationTableName = ssqltable;
        while (dr.Read())
        {
            bulkcopy.WriteToServer(dr);
        }
     
        oledbconn.Close();
    }
    catch (Exception ex)
    {
        litResult.Text = sexcelconnectionstring;
        //handle exception
    }
    litResult.Text = sexcelconnectionstring;
}
}