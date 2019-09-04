<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update</title>
</head>
<body>
    <form id="form1" runat="server">
          <div align="Center" style="background-color: #011627; height: 1000px;">
              <header style="color:aliceblue; font-size: 50px">Update</header>
            <div>
            <br />
                 <table align="Center" class="auto-style4" style="font-family: Arial; color: #2EC4B6; background-color: #011627; border: 2px solid #FDFFFC;">       
                    <tr>
                    <td>
                        First Name<span style="color:#E71D36">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="FirstName" runat="server" Width="200px" TextMode="SingleLine" MaxLength="15"></asp:TextBox>
                    </td>
                    <td class="auto-style1"> 
                        <asp:RequiredFieldValidator ID="FNameValidator" runat="server" ErrorMessage="Please Enter a First Name" ControlToValidate="FirstName" Text="Please enter a first name" ForeColor="#E71D36"></asp:RequiredFieldValidator>
                    </td>
                    </tr>
                    <tr>
                    <td>
                        Last Name<span style="color:#E71D36">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" Width="200px" TextMode="SingleLine"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:RequiredFieldValidator ID="LNameValidator" runat="server" ErrorMessage="Please Enter a Last Name" ControlToValidate="LastName" Text="Please enter a last name" ForeColor="#E71D36"></asp:RequiredFieldValidator>
                    </td>
                    </tr>
                    <tr>
                    <td>
                        Address<span style="color:#E71D36">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="Address" runat="server" Width="300px" TextMode="SingleLine"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                         <asp:RequiredFieldValidator ID="AddressValidator" runat="server" ErrorMessage="Please Enter an Address" ControlToValidate="Address" Text="Please enter an address" ForeColor="#E71D36"></asp:RequiredFieldValidator>
                    </td>
                    </tr>              
          
                    <tr>
                    <td>
                        City<span style="color:#E71D36">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="City" runat="server" width="200px" TextMode="SingleLine"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                         <asp:RequiredFieldValidator ID="CityValidator" runat="server" ErrorMessage="Please Enter a City" ControlToValidate="City" Text="Please enter a city" ForeColor="#E71D36"></asp:RequiredFieldValidator>
                    </td>
                    </tr>
                    <tr>
                    <td>
                        Province<span style="color:#E71D36">*</span>
                    </td>
                      <td>
                        <asp:TextBox ID="Province" runat="server" width="200px" TextMode="SingleLine"></asp:TextBox>
                    </td>
                     <td class="auto-style1">
                         <asp:RequiredFieldValidator ID="ProvinceFieldValidator" runat="server" ErrorMessage="Please Enter a Province" ControlToValidate="City" Text="Please enter a city" ForeColor="#E71D36"></asp:RequiredFieldValidator>
                    </td>
                    </tr>
             
                    <tr>
                    <td>
                        Postal Code<span style="color:#E71D36">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="PostalCode" runat="server" width="100px" TextMode="SingleLine"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:RequiredFieldValidator ID="PostalFieldValidator" runat="server" ErrorMessage="Please Enter a Postal Code" ControlToValidate="PostalCode" Text="Please enter a postal code" ForeColor="#E71D36"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="PostalValidator" runat="server" ErrorMessage="Please Enter a Valid Postal Code" ControlToValidate="PostalCode" Text="Please enter a valid postal code" ValidationExpression="^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVX])[ \-]{0,1}(\d[ABCEGHJKLMNPRSTVX]\d)$" ForeColor="#E71D36"></asp:RegularExpressionValidator>
                    </td>
                    </tr>
             
                    <tr>
                    <td>
                        Phone<span style="color:#E71D36">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="Phone" runat="server" width="200px" TextMode="SingleLine"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:RequiredFieldValidator ID="PhoneFieldValidator" runat="server" ErrorMessage="Please Enter a phone number" ControlToValidate="Phone" Text="Please enter a phone number" ForeColor="#E71D36"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="PhoneValidator" runat="server" ErrorMessage="Please Enter a valid phone number" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" Text="Please enter a valid phone number" ControlToValidate="Phone" ForeColor="#E71D36"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <br />
            <asp:CheckBoxList ID="CheckBoxList1" AutoPostBack="true" CellPadding="5" CellSpacing="5" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow" TextAlign="Right" runat="server" ForeColor="White">
                <asp:ListItem>CEIL-864</asp:ListItem>
                <asp:ListItem>CEIL-865</asp:ListItem>
                <asp:ListItem>CEIL-875</asp:ListItem>
            </asp:CheckBoxList>
            <br />
            <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="OnUpdate_Click" />
        </div>
        </div>
    </form>
</body>
</html>
