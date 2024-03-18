using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace testApplication1
{
    public partial class CRUD : System.Web.UI.Page
    {
        static string connection = "Data Source=DESKTOP-VDNE4A1;Initial Catalog=WebformsTask;Integrated Security=True;Encrypt=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load data into GridView on page load
                //DisplayData();
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    // Create table
        //    string tableName = TextBox1.Text.Trim();
        //    string columnName = TextBox2.Text.Trim();
        //    string dataType = TextBox3.Text.Trim();

        //    // Execute stored procedure for creating table
        //    ExecuteCRUDStoredProcedure(tableName, 1, columnName, dataType);
        //}

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Insert values into table
            string tableName = TextBox4.Text.Trim();
            string columnName = TextBox5.Text.Trim();
            string value = TextBox6.Text.Trim();

            // Execute stored procedure for inserting values
            ExecuteCRUDStoredProcedure(tableName, 0, columnName, value);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Update values in table
            string tableName = TextBox7.Text.Trim();
            string updateColumnName = TextBox8.Text.Trim();
            string existingValue = TextBox9.Text.Trim();
            string newValue = TextBox10.Text.Trim();

            // Execute stored procedure for updating values
            ExecuteCRUDStoredProcedure(tableName, 0, null, null, existingValue, newValue, updateColumnName);
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            // Delete values from table
            string tableName = TextBox11.Text.Trim();
            string deleteColumnName = TextBox12.Text.Trim();
            string deleteValue = TextBox13.Text.Trim();

            // Execute stored procedure for deleting values
            ExecuteCRUDStoredProcedure(tableName, 0, null, null, null, null, null, deleteColumnName, deleteValue);
        }

        protected void ExecuteCRUDStoredProcedure(string tableName, int selectQuery, string columnName, string insertvalue, string value = null, string updateValue = null, string updateColumnName = null, string deleteColumnName = null, string deleteValue = null)
        {
            string connectionString = connection;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("CRUD", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@TableName", tableName);
                        cmd.Parameters.AddWithValue("@SelectQuery", selectQuery);
                        cmd.Parameters.AddWithValue("@InsertColumns", columnName);
                        cmd.Parameters.AddWithValue("@InsertValues", insertvalue);
                        cmd.Parameters.AddWithValue("@UpdateColumnName", updateColumnName);
                        cmd.Parameters.AddWithValue("@UpdateNewValue", updateValue);
                        cmd.Parameters.AddWithValue("@UpdateExistingValue", value);
                        cmd.Parameters.AddWithValue("@DeleteColumnName", deleteColumnName);
                        cmd.Parameters.AddWithValue("@DeleteValue", deleteValue);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // If execution succeeds, set label text to success message
                StatusLabel.Text = "Operation performed successfully";
            }
            catch (Exception ex)
            {
                // If an error occurs, set label text to error message
                StatusLabel.Text = "An error occurred: " + ex.Message;
            }

            // Refresh GridView after performing the operation
            DisplayData(tableName);
        }


        protected void DisplayData(string tableName)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("CRUD", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", tableName);
                    cmd.Parameters.AddWithValue("@SelectQuery", 1);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }
}
