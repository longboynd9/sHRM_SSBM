<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iHRM.WebPC.Cpanel.HtmlModule.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    
    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script type="text/javascript">
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
                
        <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
            <Items>
                <ext:Panel ID="pnl1" runat="server" Border="false" Layout="FitLayout">
                    <TopBar>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:ComboBox ID="cmbChoose" runat="server" FieldLabel="Module" LabelWidth="55" Editable="false" Width="270" OnDirectSelect="btnLoad_DirectClick" />
                                <ext:ToolbarFill />
                                <ext:Button ID="btnSave" runat="server" Icon="Disk" Text="lưu lại">
                                    <DirectEvents>
                                        <Click OnEvent="btnSave_DirectClick">
                                            <EventMask Target="Page" MinDelay="1000" Msg="Đang lưu dữ liệu..." ShowMask="true" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:HtmlEditor ID="txtDesign" runat="server">                            
                        </ext:HtmlEditor>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
    </div>
        
    </form>
</body>
</html>
