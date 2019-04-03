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
                        com.Parameters.AddWithValue("@phone", phnno.Text);
                        com.Parameters.AddWithValue("@email", Textemail.Text);
                        com.Parameters.AddWithValue("@Firstname",fname.Text );
                        com.Parameters.AddWithValue("@Lastname",lname.Text);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                        
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
                    com.Parameters.AddWithValue("@phone", phnno.Text);
                    com.Parameters.AddWithValue("@email", Textemail.Text);

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (con = getconnection())
            {

                using (SqlCommand com = new SqlCommand("select * from address where addressid = @id", con))
                {
                    //com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", Convert.ToByte(addressid.Text));
                   
                    con.Open();

                    SqlDataReader read = com.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {



                            fname.Text = Convert.ToString(read["Firstname"]);
                            phnno.Text = Convert.ToString(read["phone"]);
                            lname.Text = Convert.ToString(read["lastname"]);
                            
                        

                            //phnno.Text = com.Parameters["@phoneno"].Value.ToString();
                            //lname.Text = com.Parameters["@addressid"].Value.ToString();



                        }
                    }
                    con.Close();
                   
                  
                   

                }
            }
        }

        protected void phnno_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
