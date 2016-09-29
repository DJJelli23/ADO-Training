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
         *
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * //Execute Reader Method Example.
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select ProductID, Name, UnitPrice, QtyAvailable from tblProduct";
                cmd.Connection = con;
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            *
            /*
            //Execute Scalar
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select COUNT(ProductId) from tblProduct";
                cmd.Connection = con;
                con.Open();
                int totalRows = (int)cmd.ExecuteScalar();
                Response.Write("Total Rows = " + totalRows);
            }
            *
            /*
            //Execute Non Query or Insert, Update, Delete statements.
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                int totalRowsAffected = 0;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                //Delete
                cmd.CommandText = "delete from tblProduct where ProductID = 4";
                totalRowsAffected = cmd.ExecuteNonQuery();
                Response.Write(totalRowsAffected.ToString() + " row has been Deleted. <br />");
                //Insert
                cmd.CommandText = "insert into tblProduct values (4, 'Calculators', 100, 230)";
                totalRowsAffected = cmd.ExecuteNonQuery();
                Response.Write(totalRowsAffected.ToString() + " row has been inserted. <br />");
                //Update
                cmd.CommandText = "update tblProduct set QtyAvailable = 200 where productId = 2";
                totalRowsAffected = cmd.ExecuteNonQuery();
                Response.Write(totalRowsAffected.ToString() + " row has been updated. <br />");
            }
            * End
        }
        */
        /* SQL Injection Attack Part 5
         * 
         * 
         */
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}