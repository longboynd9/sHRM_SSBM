<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageConfig.aspx.cs" Inherits="iHRM.WebPC.Cpanel.HtmlModule.PageConfig" %>

<%@ Register Src="../UC/ImageUploader.ascx" TagName="ImageUploader" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />
            <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
                <Items>
                    <ext:Panel ID="Panel1" runat="server" PaddingSummary="10 10 10 10" Border="false" Layout="BorderLayout">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:Button ID="btnsave" Icon="Disk" runat="server" OnDirectClick="btnsave_DirectClick" Text="Lưu" />
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>
                            <ext:Panel runat="server" Border="false" Region="East" Title="Logo" Width="170" BodyStyle="padding:10px;">
                                <Content>
                                    <uc1:ImageUploader ID="ImageUploader1" runat="server" />
                                </Content>
                            </ext:Panel>
                            
                            <ext:Panel runat="server" Border="false" Region="Center" Title="Thông tin" Layout="AnchorLayout" BodyStyle="padding:10px;">
                                <Items>
                                    <ext:TextField ID="txttitle" runat="server" FieldLabel="Tiêu đề website" AnchorHorizontal="100%" MaxLength="250">
                                    </ext:TextField>
                                    <ext:TextArea ID="txtkeyword" runat="server" FieldLabel="Meta KeyWord" AnchorHorizontal="100%" Height="50" MaxLength="250">
                                    </ext:TextArea>
                                    <ext:TextArea ID="txtdescription" runat="server" FieldLabel="Meta Description" AnchorHorizontal="100%" Height="50" MaxLength="250">
                                    </ext:TextArea>
                                </Items>
                            </ext:Panel>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Viewport>
        </div>

    </form>
</body>
</html>
