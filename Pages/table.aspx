<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="table.aspx.cs" Inherits="HomeWorkBM5_Aplication.Pages.WebForm1" %>

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
                <div id="options">
                    <asp:Button ID="Button1" runat="server" OnClick="Button_Add" Text="Dodaj Lekarza" Height="58px" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button_Remove" Text="Usuń Lekarza" Height="58px" />
                    <asp:Button ID="Button3" runat="server" OnClick="Button_Normal" Text="Normalny widok" Height="58px" />
                </div>
            </div>
            <asp:GridView ID="GridView1" runat="server" Height="679px" Width="100%"></asp:GridView>
        </div>
    </form>
</body>
</html>