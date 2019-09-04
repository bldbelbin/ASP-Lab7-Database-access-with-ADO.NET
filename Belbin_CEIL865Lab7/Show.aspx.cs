using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Show : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.GetStudents();
        }

    }

    private int student
    {
        get
        {
            return !string.IsNullOrEmpty(Request.QueryString["student_id"]) ? int.Parse(Request.QueryString["student_id"]) : 0;
        }
    }

    protected void GetStudents()
    {
        string myConn = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(myConn))
        {
            SqlCommand sqlCom = new SqlCommand("SELECT StudentCourse.student_id, StudentCourse.course_code, Course.course_name FROM StudentCourse FULL OUTER JOIN Course ON StudentCourse.course_code = Course.course_code WHERE StudentCourse.student_id = @StudentId", conn);
            conn.Open();
            sqlCom.Parameters.AddWithValue("@StudentId", student);
            CourseGrid.DataSource = sqlCom.ExecuteReader();
            CourseGrid.DataBind();
            conn.Close();
        }
    }

    protected void OnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Student.aspx");
    }
}