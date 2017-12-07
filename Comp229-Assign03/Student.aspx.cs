using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03
{
    public partial class Student : System.Web.UI.Page
    {
        private SqlConnection connection = new SqlConnection("Server=CHRIS;Initial Catalog=Comp229Assign03;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudentInfo();
            }
        }
        private void GetStudentInfo()
        {
            string studentID = Session["currentStudentID"] as string;
            int sID;
            int.TryParse(studentID, out sID);

            //get student info from the database
            SqlCommand comm = new SqlCommand("Select * from Students " +
                "where Students.StudentID = @sID;", connection);
            comm.Parameters.Add("@sID", System.Data.SqlDbType.Int);
            comm.Parameters["@sID"].Value = sID;
            try
            {
                connection.Open();
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    //setName
                    stName.Text = reader["FirstMidName"] + " " + reader["LastName"];
                    //setID
                    stID.Text = reader["StudentID"] + "";
                    //setDate
                    stDate.Text = reader["EnrollmentDate"] + "";
                }

                reader.Close();
                //setCourse
                SqlCommand comm2 = new SqlCommand("SELECT * FROM dbo.Courses " +
                    "INNER JOIN dbo.Enrollments ON dbo.Courses.CourseID = dbo.Enrollments.CourseID " +
                    "WHERE dbo.Enrollments.StudentID = @sID;", connection);
                comm2.Parameters.Add("@sID", System.Data.SqlDbType.Int);
                comm2.Parameters["@sID"].Value = sID;

                reader = comm2.ExecuteReader();
                CourseList.DataSource = reader;
                CourseList.DataBind();

                reader.Close();
            }
            catch
            {
                Response.Write("Error");
            }
        }

        protected void Change(object source, EventArgs e)
        {
            LinkButton btn = (LinkButton)(source);
            string value = btn.CommandName;
            if (value == "Update")
            {
                Response.Redirect("Update.aspx");
            }
            else if (value == "Delete") //delete selected student 
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    SqlConnection connection = new SqlConnection("Server=CHRIS;Initial Catalog=Comp229Assign03;Integrated Security=True");
                    SqlCommand comm = new SqlCommand("DELETE FROM Enrollments WHERE StudentID='" + stID.Text + "'", connection);
                    SqlCommand comm1 = new SqlCommand("DELETE FROM Students WHERE StudentID='" + stID.Text + "'", connection);

                    try
                    {
                        connection.Open();
                        comm.ExecuteNonQuery();
                        comm1.ExecuteNonQuery();

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;

                    }
                    finally
                    {
                        Response.Redirect("~/Home.aspx");
                    }
                }
            }
        }

        protected void Course_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "MoreDetail")
            {
                Session["courseID"] = e.CommandArgument.ToString();
                Response.Redirect("CoursePage.aspx");
            }
        }
    }
}