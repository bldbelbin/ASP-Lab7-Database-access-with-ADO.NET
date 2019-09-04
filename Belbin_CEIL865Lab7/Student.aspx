<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:GridView ID="Student_grid" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="Student Id" />
                    <asp:BoundField DataField="firstname" HeaderText="First Name" />
                    <asp:BoundField DataField="lastname" HeaderText="Last Name" />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                    <asp:BoundField DataField="city" HeaderText="City" />
                    <asp:BoundField DataField="province" HeaderText="Province" />
                    <asp:BoundField DataField="postal_code" HeaderText="Postal Code" />
                    <asp:BoundField DataField="phone_number" HeaderText="Phone Number" />
                    <asp:HyperLinkField Text="Update" DataNavigateUrlFields="student_id" DataNavigateUrlFormatString="Update.aspx?student_id={0}" />
                    <asp:HyperLinkField Text="Show" DataNavigateUrlFields="student_id" DataNavigateUrlFormatString="Show.aspx?student_id={0}" />
                </Columns>
           </asp:GridView>
        <br />
        <asp:Button ID="RegButton" runat="server" Text="Register" OnClick="OnReg_Click" />
    </form>
</body>
</html>
