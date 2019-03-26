using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class addressbook : System.Web.UI.Page
    {
        SqlConnection con;
        public SqlConnection getconnection()
        {
            return (new SqlConnection(@"data source=LAPTOP-RPOKN7UD;initial catalog= addressbook; integrated security=true;"));
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            {
                using (con = getconnection())
                {

                    using (SqlCommand com = new SqlCommand("updateaddress", con))
                    {
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@addressid", addressid.Text);
                        com.Parameters.AddWithValue("@lastname", lastname.Text);
                        con.Open();
                        int flag = com.ExecuteNonQuery();
                        con.Close();
                        if (flag > 0)
                            TextBox1.Text = "record updated";
                        else
                            TextBox1.Text = "rocord not present";
                    }
                }

            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (con = getconnection())
            {

                using (SqlCommand com = new SqlCommand("deleterecord", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@addressid", addressid.Text);
                    con.Open();
                    int flag = com.ExecuteNonQuery();
                    con.Close();
                    if (flag > 0)
                        TextBox1.Text = "record delted";
                    else
                        TextBox1.Text = "rocord not present";
                }
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (con = getconnection())
            {

                using (SqlCommand com = new SqlCommand("insertaddress", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@addressid", addressid.Text);
                    com.Parameters.AddWithValue("@lastname", lname.Text);
                    com.Parameters.AddWithValue("@firstname", fname.Text);
                    com.Parameters.AddWithValue("@phoneno", phoneno.Text);
                    con.Open();
                    int flag = com.ExecuteNonQuery();
                    con.Close();
                    if (flag > 0)
                        TextBox1.Text = "record inserted";
                    else
                        TextBox1.Text = "rocord not inserted";
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (con = getconnection())
            {

                using (SqlCommand com = new SqlCommand("readaddress", con))
                {
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@lastname", lname.Text);
                    SqlParameter p1 = new SqlParameter("@fname", System.Data.SqlDbType.VarChar, 20);
                    SqlParameter p2 = new SqlParameter("@addressid", System.Data.SqlDbType.Int);
                    SqlParameter p3 = new SqlParameter("@phoneno", System.Data.SqlDbType.NChar, 30);
                    SqlParameter p4 = new SqlParameter("@flag", System.Data.SqlDbType.Int);

                    p1.Direction = System.Data.ParameterDirection.Output;
                    p2.Direction = System.Data.ParameterDirection.Output;
                    p3.Direction = System.Data.ParameterDirection.Output;
                    p4.Direction = System.Data.ParameterDirection.ReturnValue;
                    com.Parameters.Add(p1);
                    com.Parameters.Add(p2);
                    com.Parameters.Add(p3);
                    com.Parameters.Add(p4);



                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    fname.Text = com.Parameters["@firstname"].Value.ToString();
                    phnno.Text = com.Parameters["@phoneno"].Value.ToString();
                    addressid.Text = com.Parameters["@addressid"].Value.ToString();
                    int flag = (int)com.Parameters["@flag"].Value;

                    if (flag == 1)
                        TextBox1.Text = "record is searched";
                    else
                        TextBox1.Text = "record not present";

                }
            }
        }
    }
    }
