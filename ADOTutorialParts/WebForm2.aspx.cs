using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Configuration;

namespace ADOTutorialParts
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        /* What is ADO.NET - Part 1

        protected void Page_Load(object sender, EventArgs e)
        {



          //  *Same setup but different Classes for SqlClient, Odbc, OleDb, and OracleClient.

          // *
          // *
          // *
          // *
          // *SQL Connection Way
          // *
          //SqlConnection con = new SqlConnection("data source=.; database=Sample; integrated security=SSPI");
          //SqlCommand cmd = new SqlCommand("select * from tblProduct", con);
          //  con.Open();
          //  SqlDataReader rdr = cmd.ExecuteReader();
          //  GridView1.DataSource = rdr;
          //  GridView1.DataBind();
          //  con.Close();
          //  *
          //  /* 
          //   * 
          //   * Oracle Connection Way. Has been deprecated and is obsolete.
          //   *
          //  OracleConnection con = new OracleConnection("data source=.; database=Sample; integrated security=SSPI");
          //  OracleCommand cmd = new OracleCommand("select * from tblProduct", con);
          //  con.Open();
          //  OracleDataReader rdr = cmd.ExecuteReader();
          //  GridView1.DataSource = rdr;
          //  GridView1.DataBind();
          //  con.Close();
            

        }*/
        /*SqlConnection in ASP.NET - Part 2*
        protected void Page_Load(object sender, EventArgs e)
        {
            //initial catalog or database will work for connecting the database.
            //windows or server authentication. Windows - integrated security. Server - User id =something ; password = something.
            string CS = "data source=.; database=Sample; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(CS))//Interview question: How are using statements used.
                                                            //When using a namespace or closing a connection properly.
            {
                SqlCommand cmd = new SqlCommand("Select * from tblProduct", con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }

            //try
            //{
            //    SqlCommand cmd = new SqlCommand("Select * from tblProduct", con);
            //    con.Open();
            //    GridView1.DataSource = cmd.ExecuteReader();
            //    GridView1.DataBind();
            //}
            //catch
            //{

            //}
            //finally
            //{
            //    con.Close();
            //}
            }
            */
        /* ConnectionStrings in web.config configuration file - Part 3
         * 
         * 
         * Don't put connection strings into the code, hard coded style.
         * Causing rebuild and redeploy and it will take too much time.
         * 
         *
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))//Interview question: How are using statements used.
                                                             //When using a namespace or closing a connection properly.
            {
                SqlCommand cmd = new SqlCommand("Select * from tblProduct", con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
        */
        /* SqlCommand in ADO.NET Part 4
         * 
         * 
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblProduct", con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }
}