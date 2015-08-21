<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Docx2XML._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>Convert your document to XML in simple steps.</h3>
        <div>
        <asp:Label runat="server">Select the docx file</asp:Label><asp:FileUpload ID="FileUploader1" runat="server" CssClass ="panel panel-primary"/><asp:Button ID="BtnProcess" Text ="Process" runat="server"  OnClick="BtnProcess_Click"/>
        <asp:Label ID="LabelOutput" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
    </div>
    </div>

    

</asp:Content>
