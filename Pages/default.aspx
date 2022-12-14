<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="HomeWorkBM5_Aplication.WebForm1" %>

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
                    <!-- Add new record, Table view buttons -->
                    <asp:Button ID="Button1" runat="server" OnClick="Button_Table" Text="Modyfikuj dane" Height="58px" />
                </div>
            </div>
            <div id="contentIndex">
                <!-- Data base content -->
                <div runat="server" id="contentBox"></div>
            </div>
        </div>
    </form>
</body>
</html>
