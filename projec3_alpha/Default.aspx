<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="projec3_alpha._Default" %>


<head>
    <style type="text/css">
        #form1 {
            height: 466px;
        }
    </style>
</head>


<form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Simple"></asp:Label>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
        <asp:ListItem>add</asp:ListItem>
        <asp:ListItem>subtract</asp:ListItem>
        <asp:ListItem>multiply</asp:ListItem>
        <asp:ListItem>divide</asp:ListItem>
    </asp:CheckBoxList>
    <asp:Label ID="Label2" runat="server" Text="Complex"></asp:Label>
    <asp:CheckBoxList ID="CheckBoxList2" runat="server">
        <asp:ListItem>add</asp:ListItem>
        <asp:ListItem>subtract</asp:ListItem>
        <asp:ListItem>multiply</asp:ListItem>
        <asp:ListItem>divide</asp:ListItem>
    </asp:CheckBoxList>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
    <asp:Panel ID="Panel2" runat="server" Height="76px" style="margin-left: 820px" Width="754px">
        <asp:Label ID="Label3" runat="server" Text="Simple"></asp:Label>
        <asp:Button ID="Button2" runat="server" Height="16px" Text="+" Width="16px" OnClick="Button2_Click1" />
        <asp:Button ID="Button3" runat="server" Height="16px" Text="-" Width="16px" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Height="16px" Text="*" Width="16px" OnClick="Button4_Click" />
        <asp:Button ID="Button5" runat="server" Height="16px" Text="/" Width="16px" OnClick="Button5_Click" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Label ID="AnswerBox" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Height="100px" style="margin-left: 817px; margin-top: 59px">
        <asp:Label ID="Label4" runat="server" Text="Complex"></asp:Label>
        <asp:Button ID="Button6" runat="server" Height="16px" Text="+" Width="16px" OnClick="Button6_Click" />
        <asp:Button ID="Button7" runat="server" Height="16px" Text="-" Width="16px" OnClick="Button7_Click" />
        <asp:Button ID="Button8" runat="server" Height="16px" Text="*" Width="16px" OnClick="Button8_Click" />
        <asp:Button ID="Button9" runat="server" Height="16px" Text="/" Width="16px" OnClick="Button9_Click" />
        &nbsp;Real/Complex#1:<asp:TextBox ID="Real1" runat="server"></asp:TextBox>
        <asp:TextBox ID="Real2" runat="server"></asp:TextBox>
        <br />
        Real/Complex#2s<asp:TextBox ID="Complex1" runat="server"></asp:TextBox>
        <asp:TextBox ID="Complex2" runat="server"></asp:TextBox>
        <asp:Label ID="Result2" runat="server"></asp:Label>
        <asp:Label ID="Result3" runat="server"></asp:Label>
    </asp:Panel>
</form>



