using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Update : System.Web.UI.Page
{
    string myConn = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        if (!this.IsPostBack)
        {
            this.GetStudent();
        }
    }

    private int student
    {
        get
        {
            return !string.IsNullOrEmpty(Request.QueryString["student_id"]) ? int.Parse(Request.QueryString["student_id"]) : 0;
        }
    }

    protected void OnUpdate_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(myConn))
        {
            using (SqlCommand sqlCom = new SqlCommand("Update Student Set student_id=@StudentId, firstname=@FirstName, lastname=@LastName, address=@Address, city=@City, province=@Province, postal_code=@PostalCode, phone_number=@Phone_Number Where student_id=@StudentId", conn))
            using (SqlCommand sqlComC = new SqlCommand("Insert into StudentCourse (student_id, course_code) SELECT @StudentId, @CourseCode WHERE NOT EXISTS (SELECT course_code FROM StudentCourse WHERE student_id = @StudentId AND course_code = @CourseCode)", conn))
            using (SqlCommand sqlDel = new SqlCommand("DELETE from StudentCourse WHERE student_id = @StudentId AND course_code = @CourseCode", conn))
            {
                conn.Open();
                sqlCom.Parameters.Add("@StudentId", System.Data.SqlDbType.VarChar, 20).Value = student;
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
                                sqlComC.Parameters.AddWithValue("@StudentId", student);
                                sqlComC.Parameters.AddWithValue("@CourseCode", li.Text);
                                sqlComC.ExecuteNonQuery();
                                sqlComC.Parameters.Clear();
                            }
                            else
                            {
                                sqlDel.Parameters.AddWithValue("@StudentId", student);
                                sqlDel.Parameters.AddWithValue("@CourseCode", li.Text);
                                sqlDel.ExecuteNonQuery();
                                sqlDel.Parameters.Clear();
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

    private void GetStudent()
    {
        DataTable studentDataTable = new DataTable();
        SqlConnection conn = new SqlConnection(myConn);
        conn.Open();
        using (SqlCommand sqlCmd = new SqlCommand("Select * From Student Where student_id = @StudentId", conn))
        using (SqlCommand sqlComC = new SqlCommand("Select course_code FROM StudentCourse WHERE student_id = @StudentId", conn))
        {
            sqlCmd.Parameters.AddWithValue("@StudentId", student);
            using (SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd))
            {
                sqlDa.Fill(studentDataTable);
            }

            foreach (DataRow dr in studentDataTable.Rows)
            {
                this.FirstName.Text = dr["firstname"].ToString();
                this.LastName.Text = dr["lastname"].ToString();
                this.Address.Text = dr["address"].ToString();
                this.City.Text = dr["city"].ToString();
                this.Province.Text = dr["province"].ToString();
                this.PostalCode.Text = dr["postal_code"].ToString();
                this.Phone.Text = dr["phone_number"].ToString();
            }

        }

        conn.Close();
    }

}