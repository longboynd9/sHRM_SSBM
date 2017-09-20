<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemTools.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Admin.SystemTools" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    
    <script type="text/javascript" src="/Skins/Scripts/jquery-1.6.1.js"></script>
    <script type="text/javascript" src="/Cpanel/Skins/Js/BitHelper.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script src="/Cpanel/Skins/Js/Ext/textarea_getSelection.js" type="text/javascript"></script>
    
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <style type="text/css">
        .x-window-body { padding: 5px 10px; }
    </style>

    <script type="text/javascript">

        function test(p1, p2, p3) {
            console.log(p1);
            console.log(p2);
            console.log(p3);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
            <Items>

                <ext:Panel runat="server" PaddingSummary="30px 50px 0">
                    <Items>
                        <ext:Button ID="btnSaveLng" Icon="PageSave" runat="server" Text="Save language" OnDirectClick="btnSaveLng_DirectClick" />
                        <ext:Button ID="btnGenLngJs" Icon="ScriptCode" runat="server" Text="Gen Language Js" OnDirectClick="btnGenLngJs_DirectClick" />
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
