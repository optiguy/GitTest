<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiFileUpload.aspx.cs" Inherits="MultiFileUpload.MultiFileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Upload more than one file</h1>
        <asp:FileUpload ID="Fileupload_multi" AllowMultiple="true" runat="server" accepts="image/jpeg|image/png" />
        <asp:Button Text="Upload" runat="server" OnClick="Button_upload_Click" />
        <asp:Literal ID="Literal_message" runat="server"></asp:Literal>
    </form>
</body>
</html>