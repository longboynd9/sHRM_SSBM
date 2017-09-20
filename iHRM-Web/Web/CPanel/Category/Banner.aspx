<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Banner.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Category.Banner" %>

<%@ Register Src="../UC/ImageUploader.ascx" TagName="ImageUploader" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />

            <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
                <Items>
                    <ext:Panel runat="server" Border="false" Layout="FormLayout" AutoScroll="true">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:Button ID="btnSave" runat="server" Icon="Disk" Text="#Category_Banner.luulai" AutoPostBack="true" OnClick="btnSave_Click" />
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>

                            <ext:Panel runat="server" Border="false" AnchorHorizontal="100%" Height="220" Title="#Category_Banner.anhnenLogin">
                                <Content>
                                    <uc1:ImageUploader ID="ImageUploader1" imgUrl="/Cpanel/Skins/Style/IMG/login.jpg" runat="server" />
                                </Content>
                            </ext:Panel>

                            <ext:Panel runat="server" Border="false" AnchorHorizontal="100%" Height="220" Title="#Category_Banner.anhnenBLV">
                                <Content>
                                    <uc1:ImageUploader ID="ImageUploader2" imgUrl="/Cpanel/Skins/Style/IMG/desktop_bg2.jpg" runat="server" />
                                </Content>
                            </ext:Panel>

                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Viewport>
        </div>

    </form>
</body>
</html>
