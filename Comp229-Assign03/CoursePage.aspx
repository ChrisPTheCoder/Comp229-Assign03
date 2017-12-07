<%@ Page Title="Course Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CoursePage.aspx.cs" Inherits="Comp229_Assign03.CoursePage" %>

<asp:Content ID = "BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container margin">
    <fieldset>
        <legend>✎ Student Enrolled In The Course ✎</legend>
    <center>
        <h3>Enrolled Student</h3>
        <table class="table align-center">
                <thead>
                    <tr>
                        <th class="col-md-3">Student ID</th>
                        <th class="col-md-3">First Name</th>
                        <th class="col-md-3">Last Name</th>
                        <th class="col-md-4">Enrollment Date</th>
                        <th class="col-md-3">Grade</th>
                        <th class="col-md-2"></th>
                    </tr>
                </thead>
             <tbody>
                    <asp:Repeater ID = "studentInfo" runat="server" OnItemCommand="studentInfo_ItemCommand">
                        <ItemTemplate>
                            <!-- repeat students data-->
                            <tr class="text-center">
                                <td>
                                    <asp:Label ID="stID" runat = "server" Text='<%# Eval("StudentID") %>' /></td>
                                <td>
                                    <asp:Label ID="firstName" runat = "server" Text='<%# Eval("FirstMidName") %>' /></td>
                                <td>
                                    <asp:Label ID="lastName" runat = "server" Text='<%# Eval("LastName") %>' /></td>
                                <td>
                                    <asp:Label ID="enrollmentDate" runat = "server" Text='<%# Eval("EnrollmentDate") %>' /></td>
                                <td>
                                    <asp:Label ID="stGrade" runat = "server" Text='<%# Eval("Grade") %>' /></td>
                                 <td>   <asp:Button runat = "server" CommandName="deleteStudent" CommandArgument='<%# Eval("StudentID") %>' CssClass="btn btn-primary" Text="Delete" /></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
            </table>
         <h3 style = "margin:2%" >✍ Enroll Student to a Course ✍ </h3>
                <div class="alert alert-warning">
                    You can only enroll a new student to this course.
                </div>
                <div class="row">
                    <div class="col-md-6">
                <asp:Label for = "fName" runat="server" Text="First Name: " AutoPostBack="True"/>
                   <asp:TextBox ID = "fName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID = "fNameRequiredVal" runat="server" ErrorMessage="Cannot Be Empty" ValidationGroup="InsertValidation" ControlToValidate="fName" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div>
                  <div class="col-md-6">
                <asp:Label for ="lName" runat="server" Text="Last Name: " AutoPostBack="True"/>
                   <asp:TextBox ID = "lName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID = "lNameRequiredVal" runat="server" ErrorMessage="Cannot Be Empty" ValidationGroup="InsertValidation" ControlToValidate="lName" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div>
         <div class="col-sm-13">
                <asp:Label ID = "GradeValue" runat="server" Text="Grade: " AutoPostBack="True"/>
                   <asp:TextBox ID = "grade" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID = "gradeRequiredVal" runat="server" ErrorMessage="Cannot Be Empty" ValidationGroup="InsertValidation" ControlToValidate="grade" ForeColor="Red"></asp:RequiredFieldValidator>
                  </div>
                </div>
                <div class="row " style="margin-top: 2%">
 
                    <div class="col-sm-14">
                        <asp:Button ID = "btnEnroll" runat="server" Text="Enroll Student" CssClass="btn btn-default btn-lg bg-2"  ValidationGroup="InsertValidation" OnClick="btn_Enroll_click" />

                    </div>
                    <div class="col-sm-14">
                         <asp:Label ID = "dbErrorMessage" ForeColor="Red" runat="server" />
                    </div>
                    </div>
        </center>
        </fieldset>
        </div>
    </asp:Content>

