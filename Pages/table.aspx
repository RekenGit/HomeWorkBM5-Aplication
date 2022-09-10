<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="table.aspx.cs" Inherits="HomeWorkBM5_Aplication.Pages.WebForm3" %>

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
                    <!-- Add new record, Normal view buttons -->
                    <asp:Button ID="Button1" runat="server" OnClick="Button_Add" Text="Dodaj Lekarza" Height="58px" />
                    <asp:Button ID="Button3" runat="server" OnClick="Button_Normal" Text="Normalny widok" Height="58px" />
                </div>
            </div>
            <!-- Data base created table -->
            <div style="overflow-y: scroll;height: 479px; width:100%;">
                <asp:GridView ID="GridView1" runat="server" Height="679px" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Id" />
                        <asp:BoundField DataField="firstName" HeaderText="Imię" />
                        <asp:BoundField DataField="lastName" HeaderText="Nazwisko" />
                        <asp:BoundField DataField="academicTitle" HeaderText="Tytuł naukowy" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:BoundField DataField="phoneNumber" HeaderText="Numer telefonu" />
                        <asp:BoundField DataField="specialization" HeaderText="Specializacja" />
                        <asp:TemplateField HeaderText="Opcje">
                            <ItemTemplate>
                                <!-- Rmove, Edit buttons -->
                                <asp:LinkButton ID="Button_Remove1" runat="server" OnClick="Button_Remove" CommandArgument='<%# Eval("id") %>' Text="Usuń"/>
                                <asp:LinkButton ID="Button_Change1" runat="server" OnClick="Button_Change" CommandArgument='<%# Eval("id") %>' Text="Edytuj"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>