<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="workplace.aspx.cs" Inherits="HomeWorkBM5_Aplication.Pages.Workplace" %>

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
                <!-- Doctor Id -->
                <asp:Label ID="Label1" runat="server" Text="Id Doktora: " Font-Size="30px"></asp:Label>
                <asp:TextBox ID="DoctorId" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="DoctorId_TextChanged"></asp:TextBox>
                <b runat="server" id="B1" class="wrong" visible="false">*</b>
                <br />
                <!-- Job name -->
                <asp:Label ID="Label2" runat="server" Text="Nazwa: " Font-Size="30px"></asp:Label>
                <asp:TextBox ID="JobName" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="JobName_TextChanged"></asp:TextBox>
                <b runat="server" id="B2" class="wrong" visible="false">*</b>
                <br />
                <!-- City name -->
                <asp:Label ID="Label3" runat="server" Text="Miasto: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="BusinessCity" ID="CityName" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="CityName_TextChanged"></asp:TextBox>
                <b runat="server" id="B3" class="wrong" visible="false">*</b>
                <br />
                <!-- Street name -->
                <asp:Label ID="Label4" runat="server" Text="Ulica: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="BusinessStreetAddress" ID="StreetName" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="StreetName_TextChanged"></asp:TextBox>
                <b runat="server" id="B4" class="wrong" visible="false">*</b>
                <br />
                <!-- Street number -->
                <asp:Label ID="Label5" runat="server" Text="Numer: " Font-Size="30px"></asp:Label>
                <asp:TextBox ID="StreetNumber" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="StreetNumber_TextChanged"></asp:TextBox>
                <b runat="server" id="B5" class="wrong" visible="false">*</b>
                <br />
                <!-- Apartment -->
                <asp:Label ID="Label6" runat="server" Text="Lokal: " Font-Size="30px"></asp:Label>
                <asp:TextBox ID="Apartment" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px"></asp:TextBox>
                <br />
                <!-- Zip code -->
                <asp:Label ID="Label7" runat="server" Text="Kod pocztowy: " Font-Size="30px"></asp:Label>
                <asp:TextBox AutoCompleteType="BusinessZipCode" ID="ZipCode" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="ZipCode_TextChanged"></asp:TextBox>
                <b runat="server" id="B7" class="wrong" visible="false">*</b>
                <br />
                <!-- Province -->
                <asp:Label ID="Label8" runat="server" Text="Województwo: " Font-Size="30px"></asp:Label>
                <asp:TextBox ID="Province" runat="server" Rows="1" Font-Size="30px" Height="70px" Width="500px" OnTextChanged="Province_TextChanged"></asp:TextBox>
                <b runat="server" id="B8" class="wrong" visible="false">*</b>
                <br />
                <div class="options">
                    <!-- Error message label -->
                    <p runat="server" id="ErrorMessage" visible="false" class="wrong">
                        UWAGA: Nie uzupełniono wszystkich wymaganych pól.
                    </p>
                    <!-- Confirm the data button -->
                    <asp:Button ID="Button2" runat="server" OnClick="Button_Send" Height="58px" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
