
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Approved.aspx.cs" Inherits="iHRM.WebPC.sHRM.Approved" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/sHRM/Styles/css/styles.css" rel="stylesheet" />
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.6.4.min.js"></script>
    <script src="/sHRM/Styles/js/UrlHelper.js"></script>

    <script type="text/javascript">

        var TopMenuRender_SelectionChanged = function (sender, idx, item, e) {
            //console.log(sender, idx, item, e);
            e.stopEvent();
            var fid = $(item).find('a').data('fid');
            window.history.pushState(null, "", "/Approved/" + fid);
            //refreshLMenu(fid);
            pContent.autoLoad.url = $(item).find('a').attr('href');
            pContent.reload();

            $('#topMenuNav li a').removeClass('active');
            $('#topMenuNav li a').eq(idx).addClass('active');
        };
        
        function showMenu(f) {
            if (f != undefined && f != '') {
                var a = $('#topMenuNav li a[data-fid=' + f + ']');
                setTimeout("$('#topMenuNav li a[data-fid=" + f + "]').addClass('active');", 1000);
                pContent.autoLoad.url = a.attr('href');
                pContent.reload();
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>


            <ext:ResourceManager runat="server" />

            <ext:Viewport runat="server" Layout="Border">
                <Items>
                    <ext:Panel runat="server" Border="False" Height="90" Region="North">
                        <Content>
                            <div class="BannerShrm">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <img id="idLogo" runat="server" style="height: 40px; width: 90px" src="/sHRM/Styles/img/Logo_129.png" />
                                        </td>
                                        <td>
                                            <p class="tenCty">Smart Shirt</p>
                                            <ext:Label ID="tenDoanhNghiep" runat="server" Text="Smart Shirt" Cls="tenCty2" />
                                        </td>
                                        <td style="width: 100%; text-align: center;">
                                            <img id="sHRM_logo" runat="server" src="/sHRM/Styles/img/Quantri.png" />
                                        </td>
                                        <td>
                                            <ext:CompositeField runat="server" Width="210">
                                                <Items>
                                                    <ext:Button runat="server" Icon="Note" Text="(3)" />
                                                    <ext:Button runat="server" Icon="Mail" Text="(1)" />

                                                    <ext:SplitButton ID="btnUser" runat="server" Text="Hi! Administrator" Icon="User">
                                                        <Menu>
                                                            <ext:Menu runat="server">
                                                                <Items>
                                                                    <ext:MenuItem runat="server" Text="Change password" Icon="KeyGo" />
                                                                    <ext:MenuSeparator />
                                                                    <ext:MenuItem ID="btnLogout" runat="server" Text="Logout" Icon="DoorOut">
                                                                        <DirectEvents>
                                                                            <Click OnEvent="btnLogout_Click" />
                                                                        </DirectEvents>
                                                                    </ext:MenuItem>
                                                                </Items>
                                                            </ext:Menu>
                                                        </Menu>
                                                    </ext:SplitButton>
                                                </Items>
                                            </ext:CompositeField>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="topMenu">
                                <ext:DataView ID="TopMenuRender" runat="server" AutoHeight="true" ItemSelector="li" EmptyText="<ul><li><a href='#'>No right...</a></li></ul>">
                                    <Store>
                                        <ext:Store runat="server" ID="stoTopMenu">
                                            <Reader>
                                                <ext:JsonReader IDProperty="name">
                                                    <Fields>
                                                        <ext:RecordField Name="name" />
                                                        <ext:RecordField Name="url" />
                                                        <ext:RecordField Name="fid" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Template runat="server">
                                        <Html>
                                            <ul id="topMenuNav">
                                                <tpl for=".">
                                                    <li><a href="{url}" data-fid="{fid}">{name}</a></li>
							                    </tpl>
                                            </ul>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Click Fn="TopMenuRender_SelectionChanged" />
                                    </Listeners>
                                </ext:DataView>
                            </div>
                        </Content>
                    </ext:Panel>

                    <ext:Panel ID="pContent" runat="server" Region="Center">
                        <AutoLoad ShowMask="true" Mode="IFrame" />
                    </ext:Panel>

                    <ext:Panel runat="server" Border="False" Height="24" Region="South">
                        <Items>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:HyperLink runat="server" Text="© 2015 S-HRM" NavigateUrl="#" Cls="footerLink"></ext:HyperLink>
                                    <ext:HyperLink ID="lblTerms" runat="server" Text="Điều khoản" NavigateUrl="#" Cls="footerLink"></ext:HyperLink>
                                    <ext:HyperLink ID="lblPrivacy" runat="server" Text="Quyền riêng tư" NavigateUrl="#" Cls="footerLink"></ext:HyperLink>
                                    <ext:ToolbarFill runat="server" />
                                    
                                    <ext:ToolbarSeparator runat="server" />
                                    <ext:Button ID="statusbar1_lng" runat="server" Icon="FlagVn" Text="Tiếng Việt" CtCls="lngCls">
                                        <Listeners>
                                            <Click Handler="if (wLng.el.visible) #{wLng}.hide(); else #{wLng}.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator runat="server" />
                                    <ext:Button runat="server" Icon="Lightbulb" Text="v3.02">
                                        <Listeners>
                                            <Click Handler="CreateWin('changelog', '/Cpanel/SYS/change-log.aspx', 'Change Log')" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Label ID="statusbar1_ip" runat="server" Icon="Computer" Text="KR-HOME" />
                                    <ext:Label ID="statusbar1_db" runat="server" Icon="Database" Text="Local" />
                                </Items>
                            </ext:Toolbar>
                        </Items>
                    </ext:Panel>

                </Items>
            </ext:Viewport>
            
            <ext:Window ID="wLng" runat="server" Width="225" Height="80" Hidden="true" ShowInTaskbar="false" Icon="World" Title="Ngôn ngữ" Layout="AbsoluteLayout" Maximizable="false" Minimizable="false" AnimateTarget="statusbar1_lng">
                <Items>
                    <ext:Button ID="wLng_btnVI" runat="server" CommandArgument="vi" Text="Tiếng việt" OnDirectClick="wLng_DirectClick" Icon="FlagVn" Width="90" Height="50" X="10" Y="10" />
                    <ext:Button ID="wLng_btnEN" runat="server" CommandArgument="en" Text="English" OnDirectClick="wLng_DirectClick" Icon="FlagUs" Width="90" Height="50" X="110" Y="10" />
                </Items>
            </ext:Window>
        </div>
    </form>
</body>
</html>
