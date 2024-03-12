using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace testApplication1
{
    public partial class SQLOps : System.Web.UI.Page
    {
        static string connection="Data Source=DESKTOP-VDNE4A1;Initial Catalog=WebformsTask;Integrated Security=True;Encrypt=False";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tableName = TextBox1.Text;
            string columnName = TextBox2.Text;
            string dataType = TextBox3.Text;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VDNE4A1;Initial Catalog=WebformsTask;Integrated Security=True;Encrypt=False");

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"CREATE TABLE {tableName}({tableName}{columnName} {dataType})", conn))
                {
                    cmd.ExecuteNonQuery();
                    Response.Write("Successfully created");
                }
            }
            catch (Exception ex)
            {
                Response.Write("error occured");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string tableName = TextBox4.Text;
            string columnName = TextBox5.Text;
            string value = TextBox6.Text;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VDNE4A1;Initial Catalog=WebformsTask;Integrated Security=True;Encrypt=False");

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"INSERT INTO {tableName}({columnName}) VALUES ('{value}')", conn))
                {
                    cmd.ExecuteNonQuery();
                    Response.Write("Successfully Inserted");
                    load_table(tableName);
                }
            }
            catch (Exception ex)
            {
                Response.Write("error occured");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void load_table(string tableName)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VDNE4A1;Initial Catalog=WebformsTask;Integrated Security=True;Encrypt=False");

            conn.Open();
            SqlCommand query = new SqlCommand($"Select * from {tableName}", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string tableName = TextBox7.Text;
            string columnName = TextBox8.Text;
            string value = TextBox9.Text;
            string newValue = TextBox10.Text;
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                string sqlQuery = $"UPDATE {tableName} SET {columnName} = '{newValue}' WHERE {columnName}='{value}'";
                conn.Open();
                using (SqlCommand query = new SqlCommand(sqlQuery, conn))
                {
                   
                    query.ExecuteNonQuery();
                    Response.Write("Updated successfully");
                    load_table(tableName);

                }
            }
            catch(Exception ex)
            {
                Response.Write("Updated failed"+ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string tableName = TextBox11.Text;
            string columnName = TextBox12.Text;
            string value = TextBox13.Text;
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                string sqlQuery = $"DELETE FROM {tableName} WHERE {columnName}='{value}'";
                conn.Open();
                using (SqlCommand query = new SqlCommand(sqlQuery, conn))
                {

                    query.ExecuteNonQuery();
                    Response.Write("Deleted successfully");
                    load_table(tableName);

                }
            }
            catch (Exception ex)
            {
                Response.Write("Delete failed" + ex.Message);

            }
            finally
            {
                conn.Close();
            }

        }
    }
}