using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03
{
    public partial class Update : System.Web.UI.Page
    {
        private SqlConnection connection = new SqlConnection("Server=CHRIS;Initial Catalog=Comp229Assign03;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUpdate();
            }
        }
        private void GetUpdate()
        {
            //code from aspsnippets.com

            {
                int studentID = Int32.Parse(Session["currentStudentID"].ToString());
                using (SqlCommand comm = new SqlCommand("Select * from Students s join Enrollments e on e.StudentID = s.StudentID where s.StudentID = " + studentID + " ; ", connection))
                {
                    comm.Connection = connection;
                    SqlDataAdapter ad = new SqlDataAdapter(comm);
                    DataSet ds = new DataSet();
                    ad.Fill(ds, "xyz");
                    studentData.DataSource = ds.Tables[0];
                    studentData.DataBind();
                }
            }
        }
        protected void DetailsViewExample_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            switch (e.CommandName.ToString())
            {
                case "Edit":
                    studentData.ChangeMode(DetailsViewMode.Edit);
                    GetUpdate();
                    break;
                case "Cancel":
                    studentData.ChangeMode(DetailsViewMode.ReadOnly);
                    GetUpdate();
                    break;
            }
        }
        protected void studentData_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            int studentID = (int)studentData.DataKey.Value;
            TextBox newFirstMidNameTextBox =
            (TextBox)studentData.FindControl("txtFirstMidName");
            TextBox newLastNameTextBox =
            (TextBox)studentData.FindControl("txtLastName");
            TextBox newEnrollmentDateTextBox =
            (TextBox)studentData.FindControl("txtEnrollmentDate");
            TextBox newGradeTextBox =
            (TextBox)studentData.FindControl("txtGrade");

            string newFMName = newFirstMidNameTextBox.Text;
            string newLName = newLastNameTextBox.Text;
            string newEnrolDay = newEnrollmentDateTextBox.Text;
            int newGrade = Convert.ToInt32(newGradeTextBox.Text); ;

            {
                //update new info for the student
                SqlCommand comm = new SqlCommand("UPDATE Students SET FirstMidName=@fmname, LastName=@lname, EnrollmentDate=@newEnrollment WHERE StudentID=@studentID", connection);
                SqlCommand comm2 = new SqlCommand("UPDATE Enrollments SET Grade=@grade", connection);
                comm.Parameters.AddWithValue("@StatementType", "update");
                comm.Parameters.AddWithValue("@studentID", studentID);
                comm.Parameters.AddWithValue("@fmname", newFMName);
                comm.Parameters.AddWithValue("@lname", newLName);
                comm.Parameters.AddWithValue("@newEnrollment", newEnrolDay);
                comm2.Parameters.AddWithValue("@grade", newGrade);
                try
                {
                    connection.Open();
                    comm.ExecuteNonQuery();
                    comm2.ExecuteNonQuery();
                    errorMsg.Text = "Updated!";
                }
                catch (SqlException error)
                {
                    errorMsg.Text += error.Message;
                }
                finally
                {
                    connection.Close();
                }
                studentData.ChangeMode(DetailsViewMode.ReadOnly);
                GetUpdate();
            }
        }

        protected void studentData_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {

        }
        protected void studentData_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            //change page index
            studentData.PageIndex = e.NewPageIndex;
            GetUpdate();
        }

    }
}