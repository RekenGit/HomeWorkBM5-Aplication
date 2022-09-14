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
                    <!-- Normal view button -->
                    <asp:Button ID="Button1" runat="server" OnClick="Button_Normal" Text="Podgląd" Height="58px" />
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
                                <asp:LinkButton ID="Button_Remove1" runat="server" OnClick="Remove_Record" CommandArgument='<%# "D"+Eval("id") %>' Text="Usuń"/>
                                <asp:LinkButton ID="Button_Change1" runat="server" OnClick="Change_Record" CommandArgument='<%# "D"+Eval("id") %>' Text="Edytuj"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Button_Add" CommandArgument="doctor" Text="Dodaj Lekarza"/>
            <div id="header">
                <div id="title">Miejsca Pracy</div>
            </div>
            <!-- Data base created table -->
            <div style="overflow-y: scroll;height: 479px; width:100%;">
                <asp:GridView ID="GridView2" runat="server" Height="679px" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Id" />
                        <asp:BoundField DataField="doctorId" HeaderText="Id Doktora" />
                        <asp:BoundField DataField="jobName" HeaderText="Nazwa" />
                        <asp:BoundField DataField="cityName" HeaderText="Miasto" />
                        <asp:BoundField DataField="streetName" HeaderText="Ulica" />
                        <asp:BoundField DataField="streetNumber" HeaderText="Numer" />
                        <asp:BoundField DataField="apartment" HeaderText="Lokal" />
                        <asp:BoundField DataField="zipCode" HeaderText="Kod pocztowy" />
                        <asp:BoundField DataField="province" HeaderText="Województwo" />
                        <asp:TemplateField HeaderText="Opcje">
                            <ItemTemplate>
                                <!-- Rmove, Edit buttons -->
                                <asp:LinkButton ID="Button_Remove2" runat="server" OnClick="Remove_Record" CommandArgument='<%# "W"+Eval("id") %>' Text="Usuń"/>
                                <asp:LinkButton ID="Button_Change2" runat="server" OnClick="Change_Record" CommandArgument='<%# "W"+Eval("id") %>' Text="Edytuj"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br /><asp:LinkButton ID="LinkButton2" runat="server" OnClick="Button_Add" CommandArgument="workplace" Text="Dodaj Miejsce pracy"/>
        </div>
    </form>
</body>
</html>