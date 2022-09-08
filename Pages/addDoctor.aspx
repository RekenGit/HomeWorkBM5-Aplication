<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addDoctor.aspx.cs" Inherits="HomeWorkBM5_Aplication.Pages.WebForm2" %>

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
                <div id="title">Dodawanie Lekarza</div>
                <div id="options">
                    <asp:Button ID="Button3" runat="server" OnClick="Button_Back" Text="Cofnij" Height="58px" />
                </div>
            </div>
            <div id="content">
                <!-- Imie -->
                <asp:Label ID="Label1" runat="server" Text="Imie: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="FirstName" ID="FirstName" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="FirstName_TextChanged"></asp:TextBox>
                <b runat="server" id="B1" class="wrong" visible="false">*</b>
                <br /><br />
                <!-- Nazwisko -->
                <asp:Label ID="Label2" runat="server" Text="Nazwisko: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="LastName" ID="SecondName" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="SecondName_TextChanged"></asp:TextBox>
                <b runat="server" id="B2" class="wrong" visible="false">*</b>
                <br /><br />
                <!-- Tytuł naukowy -->
                <asp:Label ID="Label3" runat="server" Text="Tytuł naukowy: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="JobTitle" ID="Title" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="Title_TextChanged"></asp:TextBox>
                <b runat="server" id="B3" class="wrong" visible="false">*</b>
                <br /><br />
                <!-- Email -->
                <asp:Label ID="Label4" runat="server" Text="Email: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="Email" ID="Email" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="Email_TextChanged" TextMode="Email"></asp:TextBox>
                <b runat="server" id="B4" class="wrong" visible="false">*</b>
                <br /><br />
                <!-- Numer telefonu -->
                <asp:Label ID="Label5" runat="server" Text="Numer telefonu: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="HomePhone" ID="PhoneNum" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="PhoneNum_TextChanged" TextMode="Number" CausesValidation="True" ValidateRequestMode="Enabled"></asp:TextBox>
                <b runat="server" id="B5" class="wrong" visible="false">*</b>
                <br /><br />
                <!-- Specializacja -->
                <asp:Label ID="Label6" runat="server" Text="Specializacja: " Font-Size="30px"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="30px" Height="70px" Width="500px"></asp:DropDownList>
                <br /><br /><br /><br />
                <div id="options">
                    <p runat="server" id="B7" visible="false" class="wrong"></p>
                    <asp:Button ID="Button2" runat="server" OnClick="Button_Send" Text="Zatwierdz dane" Height="58px" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
