<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HomeWorkBM5_Aplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://kit.fontawesome.com/ee33de17ff.js" crossorigin="anonymous"></script>
    <title>HomeWork</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="title">Lekarze</div>
    <div id="header">
        <div id="options">
            <asp:Button ID="Button1" runat="server" Height="26px" OnClick="Button1_Click" Text="Dodaj Lekarza" />
            <asp:Button ID="Button2" runat="server" Text="Usuń Lekarza" />
        </div>
    </div>
    <div id="content">
        <div class="doctor">
            <div class="normal">
                <h3>Imie Nazwisko</h3>
                <button><i class="fa-solid fa-arrows-up-down"></i></button>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
