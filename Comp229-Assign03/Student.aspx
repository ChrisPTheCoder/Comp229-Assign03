<%@ Page Title="Student Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Comp229_Assign03.Student" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container margin">
    <fieldset>
        <legend>✎ Information About The Student ✎</legend>
   
    <center>
            <table style="width: 700px;">
                <tr>

                    <th>Student ID     </th>
                    <th>Full Name      </th>
                    <th>Enrollment Date</th>
                    <th>Course(s)      </th>
                </tr>
        
            <tr>
                <td>
                    <asp:Label ID="stID" runat="server" Text='<%#Eval("StudentID")%>' /></td>
                <td>
                    <asp:Label ID="stName" runat="server" Text='<%#Eval("FirstMidName") + " " + Eval("LastName") %>' /></td>
                <td>
                    <asp:Label ID="stDate" runat="server" Text='<%#Eval("EnrollmentDate")%>' /></td>
                <td>
                    
                        <asp:DataList runat="server" ID="CourseList" OnItemCommand="Course_ItemCommand">
                            <ItemTemplate>
                                
                                    <asp:LinkButton ID="LinkButton1" runat="server"
                                        Text='<%#Eval("Title") +" - Grade: " + Eval("Grade")%>'
                                        CommandName="MoreDetail"
                                        CommandArgument='<%#Eval("CourseID")%>' OnClick="Change"/>
                                
                            </ItemTemplate>
                        </asp:DataList>
                    
                </td>
            </tr>
        
            </table>
         
        
    <asp:LinkButton ID="updateInfo" OnClick="Change" CommandName="Update" CommandArgument="Update" Text="Update Info" runat="server" />
    <br />
    <asp:LinkButton ID="deleteSt" OnClick="Change" CommandName="Delete" Text="Delete this Student" runat="server"  OnClientClick="return confirm('Do you want to delete?')" CommandArgument='<%#Eval("StudentID")%>' />

    </center>
        </fieldset>
        </div>
</asp:Content>
