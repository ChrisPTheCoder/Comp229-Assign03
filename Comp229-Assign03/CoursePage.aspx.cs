using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03
{
    public partial class CoursePage : System.Web.UI.Page
    {
        private SqlConnection connection = new SqlConnection("Server=CHRIS;Initial Catalog=Comp229Assign03;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudentsForCourse();
            }
        }
        private void GetStudentsForCourse()
        {
            SqlCommand comm = new SqlCommand("Select  st.*, e.StudentID, e.Grade, e.CourseID, c.CourseID, " +
                "c.Title from Students st" +
                " join Enrollments e on st.StudentID = e.StudentID " +
                "join Courses c on e.CourseID = c.CourseID " +
                "where c.CourseID = @courseID;", connection);
            comm.Parameters.AddWithValue("@courseID", Int32.Parse(Session["courseID"].ToString()));

            try
            {
                connection.Open();
                SqlDataReader reader = comm.ExecuteReader();
                studentInfo.DataSource = reader;
                studentInfo.DataBind();
                reader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        protected void btn_Enroll_click(object sender, EventArgs e)
        {
            int courseID = -1;
            if (Session["CourseID"] != null)
                courseID = Convert.ToInt32(Session["CourseID"]);

            if (courseID > 4000) //All the course ID is > 4000
            {
                SqlConnection connection = new SqlConnection("Server=CHRIS;Initial Catalog=Comp229Assign03;Integrated Security=True");
                connection.Open();

                //insert a new student 
                SqlCommand insertStudent = new SqlCommand("INSERT INTO Students (FirstMidName, LastName, EnrollmentDate) " +
                                "VALUES (@FirstName, @LastName, @EnrollmentDate);", connection);

                insertStudent.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
                insertStudent.Parameters["@FirstName"].Value = fName.Text;

                insertStudent.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
                insertStudent.Parameters["@LastName"].Value = lName.Text;

                insertStudent.Parameters.Add("@EnrollmentDate", System.Data.SqlDbType.Date);
                insertStudent.Parameters["@EnrollmentDate"].Value = DateTime.Now;
                insertStudent.ExecuteNonQuery();

                //source:https://stackoverflow.com/questions/1555320/store-value-in-a-variable-after-using-select-statement
                SqlCommand findLastStudentIDComm = new SqlCommand(
                         "SELECT MAX(StudentID) AS StudentID FROM Students;", connection);
                int newStudentID = Convert.ToInt32(findLastStudentIDComm.ExecuteScalar().ToString());

                //insert a new student into the course
                SqlCommand enrollStudent = new SqlCommand("INSERT INTO Comp229Assign03.[dbo].Enrollments(CourseID, StudentID, Grade) VALUES(@CourseID, @StudentID, @Grade);", connection);

                enrollStudent.Parameters.Add("@CourseID", System.Data.SqlDbType.Int);
                enrollStudent.Parameters["@CourseID"].Value = Convert.ToInt32(courseID);
                enrollStudent.Parameters.AddWithValue("@StudentID", newStudentID);
                enrollStudent.Parameters.Add("@Grade", System.Data.SqlDbType.Int);
                enrollStudent.Parameters["@Grade"].Value = Convert.ToInt32(grade.Text);
                connection.Close();
                try
                {
                    connection.Open();
                    enrollStudent.ExecuteNonQuery();
                    dbErrorMessage.Text = "Enrolled a new student!";
                }
                catch (SqlException error)
                {
                    dbErrorMessage.Text += error.Message;
                }
                finally
                {
                    connection.Close();
                }
                GetStudentsForCourse();
            }
        }

        protected void studentInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "deleteStudent")
            {
                try
                {
                    // Delete an enrollment
                    SqlCommand deleteEnrollments = new SqlCommand("DELETE FROM Enrollments WHERE StudentID=@StudentID", connection);
                    deleteEnrollments.Parameters.AddWithValue("@StudentID", e.CommandArgument);
                    connection.Open();
                    deleteEnrollments.ExecuteNonQuery();
                    dbErrorMessage.Text = "Deleted a student from the course!";
                }
                catch (SqlException error)
                {
                    dbErrorMessage.Text += error.Message;
                }
                finally
                {
                    connection.Close();
                }
                GetStudentsForCourse();
            }
        }
    }
}