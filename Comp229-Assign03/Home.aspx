<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Comp229_Assign03._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--insert audio file that plays automatically--%>
    <audio autoplay controls hidden>
  <source src="../images/InMyHeart.mp3" type="audio/ogg">
  <source src="../images/InMyHeart.mp3" type="audio/mpeg">
</audio>
    <div class="container-fluid bg-1 text-center">
        <h2 id="title" class="margin">♫ TZM Music School ♫ </h2>
        
                <img src="../images/music_cover.jpg" style="display: inline" class="img-responsive img-circle margin" alt="TZM" width="400" height="400" />
            
         <h1 id="intro">🎤 Let the music take you there! 🎤</h1>
    </div>
    <center><img src="../images/beat.gif" /><img src="../images/beat.gif" /><img src="../images/beat.gif" /><img src="../images/beat.gif" /><img src="../images/beat.gif" /></center>

   <div class="container-fluid bg-2 text-center">
        <h3 id="intro2" class="margin">🎸 Who are we? 🎸
        </h3>
        <h4 class="margin" id="intro3">🏩
            We are a music school located in Scarborough. 🏩
            <br />🎧
           Our music school prides itself on selecting the top talent in Toronto to work with our students. 🎧 <br />
          🎼 Many of our teachers are well-known musicians in the Toronto music scene and come with extensive musical backgrounds. 🎼<br />
          👪 Our staff is like family – and we treat each of our students the same. 👪
        </h4>
       </div>
    
    <center><img src="../images/musical.png" /></center>
    <div class="container margin ">
        <fieldset>
    <legend>✎ TZM Students' List ✎ </legend>
        <p style="text-align:center">You can find more information about the student by clicking on the name</p>
     <center>
            <asp:Datalist ID="StudentName" runat="server" OnItemCommand="stList_ItemCommand">
        <ItemTemplate>
            <table id="studentTable" runat="server">
                <tr>
                    <td><h5>♪ Name:</h5></td>
                    <td><h5><asp:LinkButton ID="stName" runat="server"
                      Text=' <%#Eval("FirstMidName") + " " + Eval("LastName")%>'
                      CommandName="MoreDetail"
                      CommandArgument='<%#Eval("StudentID")%>' />
               ♪</h5></td> </tr>
            </table>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Datalist>
           </center>
            </fieldset>
        
           <br />
   
    <fieldset>
        <legend>✍ Add a new student ✍ </legend>
        
    <div class="row">
                <div class="col-sm-3"></div>
                <div class="col-sm-2">
                <asp:Label for="insertStudentFirstMidName" runat="server" Text="First Name: " AutoPostBack="True"/>
                   <asp:TextBox ID="insertStudentFirstMidName" runat="server"></asp:TextBox>
    </div>
    
        <div class="col-sm-3"></div>
       <div class="col-sm-2">
                <asp:Label for="insertStudentLastName" runat="server" Text="Last Name: " AutoPostBack="True" />
            <asp:TextBox ID="insertStudentLastName" runat="server"></asp:TextBox></div>
       </div>
       
         <div class="col-sm-6"></div>
                <div class="col-sm-6">
    <asp:Button ID="addStudent" runat="server" Text="Save" CssClass="btn btn-primary" CommandName="addStudent" OnClick="addStudent_Click" />
    <br />
   <asp:Label ForeColor="Red" ID="errorMsg" runat="server" />
          </div>
        
   </fieldset>
        </div>
</asp:Content>
