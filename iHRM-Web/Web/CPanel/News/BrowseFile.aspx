<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrowseFile.aspx.cs" Inherits="iHRM.WebPC.Cpanel.News.BrowseFile" %>

<%@ Register src="../UC/BrowseFile.ascx" tagname="BrowseFile" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script src="../Skins/Js/jquery-1.9.0.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        
   <ext:ResourceManager runat="server" />

    <div>
    
        <uc1:BrowseFile ID="BrowseFile1" runat="server" />
    
    </div>
    </form>
</body>
</html>
