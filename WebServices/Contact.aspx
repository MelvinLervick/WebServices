<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebServices.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        Redmond, WA 98053<br />
        <abbr title="Phone">P:</abbr>
        425.999.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@rylinks.com">Support</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@rylinks.com">Marketing</a>
    </address>
</asp:Content>
