using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03
{
    public partial class _Default : Page
    {
        private SqlConnection connection = new SqlConnection("Server=CHRIS;Initial Catalog=Comp229Assign03;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudents();
            }
        }
        private void GetStudents()
        {
            SqlCommand comm = new SqlCommand("Select * from Students;", connection);
            connection.Open();
            SqlDataReader reader = comm.ExecuteReader();

            StudentName.DataSource = reader;
            StudentName.DataBind();

            connection.Close();
        }
        protected void stList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "MoreDetail")
            {
                Session["currentStudentID"] = e.CommandArgument.ToString();
                Response.Redirect("Student.aspx");
            }
        }
        protected void addStudent_Click(object sender, EventArgs e)
        {
            //add a new Student
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Comp229Assign03.[dbo].Students ( FirstMidName, LastName, EnrollmentDate) VALUES(@FirstName, @LastName, @EnrollmentDate); ", connection);

            cmdInsert.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
            cmdInsert.Parameters["@FirstName"].Value = insertStudentFirstMidName.Text;

            cmdInsert.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
            cmdInsert.Parameters["@LastName"].Value = insertStudentLastName.Text;

            cmdInsert.Parameters.Add("@EnrollmentDate", System.Data.SqlDbType.Date);
            cmdInsert.Parameters["@EnrollmentDate"].Value = DateTime.Now;

            try
            {
                connection.Open();
                cmdInsert.ExecuteNonQuery();
                errorMsg.Text = "Added a new student!";

            }
            finally
            {
                connection.Close();
            }
            GetStudents();
        }
    }
}