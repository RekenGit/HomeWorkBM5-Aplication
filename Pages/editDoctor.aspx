<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editDoctor.aspx.cs" Inherits="HomeWorkBM5_Aplication.Pages.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../StyleSheets/StyleSheet1.css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://kit.fontawesome.com/ee33de17ff.js" crossorigin="anonymous"></script>
    <title>HomeWork</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="center">
            <div id="header">
                <div id="title">Lekarze</div>
                <div class="options">
                    <!-- Go back button -->
                    <asp:Button ID="Button3" runat="server" OnClick="Button_Back" Text="Cofnij" Height="58px" />
                </div>
            </div>
            <div id="content">
                <!-- Firstname -->
                <asp:Label ID="Label1" runat="server" Text="Imie: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="FirstName" ID="FirstName" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="FirstName_TextChanged"></asp:TextBox>
                <b runat="server" id="B1" class="wrong" visible="false">*</b>
                <br /><br />
                <!-- Lastname -->
                <asp:Label ID="Label2" runat="server" Text="Nazwisko: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="LastName" ID="LastName" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="LastName_TextChanged"></asp:TextBox>
                <b runat="server" id="B2" class="wrong" visible="false">*</b>
                <br /><br />
                <!-- Academic title -->
                <asp:Label ID="Label3" runat="server" Text="Tytuł naukowy: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="JobTitle" ID="TitleName" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="Title_TextChanged"></asp:TextBox>
                <b runat="server" id="B3" class="wrong" visible="false">*</b>
                <br /><br />
                <!-- Email -->
                <asp:Label ID="Label4" runat="server" Text="Email: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="Email" ID="Email" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="Email_TextChanged" TextMode="Email"></asp:TextBox>
                <b runat="server" id="B4" class="wrong" visible="false">*</b>
                <br /><br />
                <!-- Phone number -->
                <asp:Label ID="Label5" runat="server" Text="Numer telefonu: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="HomePhone" ID="PhoneNum" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="PhoneNum_TextChanged" TextMode="Number" CausesValidation="True" ValidateRequestMode="Enabled"></asp:TextBox>
                <b runat="server" id="B5" class="wrong" visible="false">*</b>
                <br /><br />
                <!-- Specialization -->
                <asp:Label ID="Label6" runat="server" Text="Specializacja: " Font-Size="30px"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="30px" Height="70px" Width="500px"></asp:DropDownList>
                <br /><br />
                <div class="options">
                    <!-- Error message label -->
                    <p runat="server" id="ErrorMessage" visible="false" class="wrong"></p>
                    <!-- Confirm the data button -->
                    <asp:Button ID="Button2" runat="server" OnClick="Button_Send" Text="Zatwierdz dane" Height="58px" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
