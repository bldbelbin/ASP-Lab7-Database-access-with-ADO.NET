using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.GetStudents();
        }

    }
    protected void GetStudents()
    {
        string myConn = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(myConn))
        {
            SqlCommand sqlCom = new SqlCommand("Select * from Student", conn);
            conn.Open();
            Student_grid.DataSource = sqlCom.ExecuteReader();
            Student_grid.DataBind();
        }
    }

    protected void OnReg_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

}