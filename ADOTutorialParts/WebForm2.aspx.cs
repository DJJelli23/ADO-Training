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
using System.Data;


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
         *
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                // Never dynamicly build sql queries as a hacker can inject any sql statement into the textbox.
                string command = "select * from tblProductInventory where ProductName like '" + TextBox1.Text + "%'";
                SqlCommand cmd = new SqlCommand(command, con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
        */
        /* SQL Injection Prevention - Part 6
         * 
         * 
         * 
         *
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                // Never dynamicly build sql queries as a hacker can inject any sql statement into the textbox.
                //
                // Using a parameter.
                /* 
                 * 
                 * 
                string command = "select * from tblProductInventory where ProductName like @ProductName";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@ProductName", TextBox1.Text + "%");
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                *
                // Using a Stored Proc
                *
                 * 
                 * 
                 *
                string command = "spGetProductsByName";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductName", TextBox1.Text);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
        */
        /* Calling a Stored Procedure with Output Parameters Part 7
         * 
         * 
         * 
         *

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", empText.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", salBox.Text);

                SqlParameter outPara = new SqlParameter("@EmployeeId", System.Data.SqlDbType.Int);
                outPara.Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(outPara);
                con.Open();
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Employee Id = " + outPara.Value.ToString();
            }
        }
        */
        /* SqlDataReader in ADO.NET Tutorial - Part 8
         * 
         * Read only and forward only. Most efficient choice to read data.
         * 
         * 
         *

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(cs))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("Select Id, ProductName, QuantityAvailable from tblProductInventory", con);
            //    using (SqlDataReader rdr = cmd.ExecuteReader())
            //    {
            //        GridView1.DataSource = rdr;
            //        GridView1.DataBind();
            //    }
            //}
            *
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Id, ProductName, QuantityAvailable from tblProductInventory", con);
                // The below code can be done in the database and does not have to be in the code. Just change the query.
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable tbl = new DataTable();
                    tbl.Columns.Add("ID");
                    tbl.Columns.Add("Name");
                    tbl.Columns.Add("Price");
                    tbl.Columns.Add("DiscountedPrice");

                    while (rdr.Read())
                    {
                        DataRow dataRow = tbl.NewRow();

                        int orinPrice = Convert.ToInt32(rdr["QuantityAvailable"]);
                        double discPrice = orinPrice * .9;

                        dataRow["ID"] = rdr["Id"];
                        dataRow["Name"] = rdr["ProductName"];
                        dataRow["Price"] = orinPrice;
                        dataRow["DiscountedPrice"] = discPrice;
                        tbl.Rows.Add(dataRow);
                    }

                    GridView1.DataSource = tbl;
                    GridView1.DataBind();
                }
            }
        }
        */
        /* SqlDataReader object's NextResult() method - Part 9
         * 
         * 
         * Multiple tables.
         * 
         * 
         *     
         *

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString; 
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblProductCategories; select * from tblProductInventory", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    ProductGridView.DataSource = rdr;
                    ProductGridView.DataBind();

                    while (rdr.NextResult())
                    {
                        CategoryGridView.DataSource = rdr;
                        CategoryGridView.DataBind();
                    }
                }
            }
        }
        */
        /* SqlDataAdapter in ADO.NET - Part 10
         * 
         * 
         * 
         *

        protected void Page_Load(object sender, EventArgs e)
        {
            //string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(cs))
            //{
            //    //SqlDataAdapter da = new SqlDataAdapter("Select * from tblProductInventory", con);
            //    SqlDataAdapter da = new SqlDataAdapter("spGetProductInventory", con);
            //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    DataSet ds = new DataSet();// in memory rep of my tables.

            //    da.Fill(ds);

            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Stored proc with parameters.
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                //SqlDataAdapter da = new SqlDataAdapter("Select * from tblProductInventory", con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("spGetProductInventoryById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ProductId", TextBox1.Text);

                DataSet ds = new DataSet();// in memory rep of my tables.
                da.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
        */
        /* DataSet in asp.net - Part 11.
         * 
         * 
         * 
         * 
         * 
         * 
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter sda = new SqlDataAdapter("spGetDate", con);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet dt = new DataSet();
                sda.Fill(dt);

                dt.Tables[0].TableName = "Products";
                dt.Tables[1].TableName = "Categories";

                GridView1.DataSource = dt.Tables["Products"];
                GridView1.DataBind();

                GridView2.DataSource = dt.Tables["Categories"];
                GridView2.DataBind();
            }
        }        
    }
}