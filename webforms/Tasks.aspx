<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="SampleTasks.Web.Tasks" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Task Tracker</title>
</head>
<body>
    <form id="TaskForm" runat="server">
        <h1>Task Tracker</h1>

        <asp:TextBox ID="TitleTextBox" runat="server" placeholder="New task title" />
        <asp:DropDownList ID="PriorityList" runat="server">
            <asp:ListItem Text="Low" Value="Low" />
            <asp:ListItem Text="Medium" Value="Medium" Selected="True" />
            <asp:ListItem Text="High" Value="High" />
        </asp:DropDownList>
        <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" />

        <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" />

        <asp:GridView ID="TasksGrid" runat="server" AutoGenerateColumns="false"
                      OnRowCommand="TasksGrid_RowCommand" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="#" />
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Priority" HeaderText="Priority" />
                <asp:ButtonField CommandName="Complete" Text="Done" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
