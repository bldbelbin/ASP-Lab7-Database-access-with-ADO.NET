using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    string myConn = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

    }

    protected void OnSave_Click(object sender, EventArgs e)
    {
       string query = "Insert Into Student (student_id, firstname, lastname, address, city, province, postal_code, phone_number)" +
                "VALUES (@StudentId, @FirstName, @LastName, @Address, @City, @Province, @PostalCode, @Phone_Number)";

       using (SqlConnection conn = new SqlConnection(myConn))
       using (SqlCommand sqlCom = new SqlCommand(query, conn))
       using (SqlCommand sqlComC = new SqlCommand("Insert into StudentCourse(student_id, course_code) VALUES (@StudentId, @CourseCode)", conn))
       {

          conn.Open();

        sqlCom.Parameters.Add("@StudentId", System.Data.SqlDbType.VarChar, 20).Value = StudentId.Text;
        sqlCom.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar, 20).Value = FirstName.Text;
        sqlCom.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar, 20).Value = LastName.Text;
        sqlCom.Parameters.Add("@Address", System.Data.SqlDbType.VarChar, 30).Value = Address.Text;
        sqlCom.Parameters.Add("@City", System.Data.SqlDbType.VarChar, 20).Value = City.Text;
        sqlCom.Parameters.Add("@Province", System.Data.SqlDbType.NVarChar, 2).Value = Province.Text;
        sqlCom.Parameters.Add("@PostalCode", System.Data.SqlDbType.NVarChar, 6).Value = PostalCode.Text;
        sqlCom.Parameters.Add("@Phone_Number", System.Data.SqlDbType.NVarChar, 10).Value = Phone.Text;

            sqlCom.ExecuteNonQuery();

            try
            {
                if (CheckBoxList1.Items.Count > 0)
                {
                    foreach (ListItem li in CheckBoxList1.Items)
                    {
                        if (li.Selected)
                        {
                            sqlComC.Parameters.AddWithValue("@StudentId", StudentId.Text);
                            sqlComC.Parameters.AddWithValue("@CourseCode", li.Text);
                            sqlComC.ExecuteNonQuery();
                            sqlComC.Parameters.Clear();
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }


        conn.Close();
        }

        Response.Redirect("Student.aspx");

    }
}