<%@ Page Title ="Update Info" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Comp229_Assign03.Update" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container margin">
    <fieldset>
       <legend>✎ Update Student's Information ✎</legend>
        <div class="alert alert-warning text-center">
                   Student ID cannot be changed.
                </div>
     <asp:DetailsView ID="studentData" runat="server" AutoGenerateColumns="false"
        OnModeChanging="studentData_ModeChanging" OnItemUpdating="studentData_ItemUpdating"
        DataKeyNames="StudentID" OnItemCommand="DetailsViewExample_ItemCommand"
        OnPageIndexChanging="studentData_PageIndexChanging" BackColor="orangered" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="8" ForeColor="black" GridLines="Vertical" AutoGenerateRows="False" CellSpacing="2" Height="60px" HorizontalAlign="Center" Width="220px">
        <AlternatingRowStyle BackColor="black" ForeColor="White" />
        <EditRowStyle BackColor="orangered" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:TemplateField HeaderText="StudentID" Visible="True" InsertVisible="True">
                <ItemTemplate>
                    <asp:Label ID="lblStudentID" Text='<%# Eval("StudentID") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtStudentID" runat="server" Text='<%# Bind("StudentID") %>' MaxLength="10" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="First Name">
                <ItemTemplate>
                    <asp:Label ID="lblFirstName" runat="server"
                        Text='<%# Eval("FirstMidName")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFirstMidName" runat="server" Text='<%# Eval("FirstMidName")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Name">
                <ItemTemplate>
                    <asp:Label ID="lblLastName" runat="server"
                        Text='<%# Eval("LastName")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtLastName" runat="server" Text='<%# Eval("LastName")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Enrollment Date">
                <ItemTemplate>
                    <asp:Label ID="lblEnrDate" runat="server"
                        Text='<%# Eval("EnrollmentDate")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEnrollmentDate" runat="server" TextMode="DateTime" Placeholder="YYYY/MM/DD"
                        Text='<%# Eval("EnrollmentDate")%>'></asp:TextBox>
            <asp:RegularExpressionValidator ID="dateReg" runat="server"
                ControlToValidate="txtEnrollmentDate"
                ValidationExpression="^[0-9]{4}/[0-9]{2}/[0-9]{2}$"
                 ErrorMessage ="Please enter date in the following format YYYY/MM/DD"
                ForeColor="White"/>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Grade">
                <ItemTemplate>
                    <asp:Label ID="lblGrade" runat="server"
                        Text='<%# Eval("Grade")%>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtGrade" runat="server" Text='<%# Eval("Grade")%>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField Visible="true" ShowCancelButton="true" ShowEditButton="true" />   
        </Fields>
        
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

    </asp:DetailsView>
    <br />
         <center><asp:Label ForeColor="Red" ID="errorMsg" runat="server"></asp:Label></center>
 
       </fieldset>
        </div>
    </asp:Content>

