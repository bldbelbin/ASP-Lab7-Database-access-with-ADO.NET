<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Show.aspx.cs" Inherits="Show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="CourseGrid" runat="server" CellPadding="4" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="Student Id" />
                    <asp:BoundField DataField="course_code" HeaderText="Course Code" />
                    <asp:BoundField DataField="course_name" HeaderText="Course Name" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="BackButton" runat="server" Text="Back" OnClick="OnBack_Click"/>
        </div>
    </form>
</body>
</html>
