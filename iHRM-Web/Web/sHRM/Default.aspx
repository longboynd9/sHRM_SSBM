
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iHRM.WebPC.sHRM.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/sHRM/Styles/css/styles.css" rel="stylesheet" />
    <link href="/sHRM/Styles/css/ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.6.4.min.js"></script>
    <script src="/sHRM/Styles/js/UrlHelper.js"></script>

    <style type="text/css">
        #pnlLeft-xsplit { background: url("/sHRM/Styles/img/ext.gif") center center no-repeat; }

        .funcClass { background: url("/sHRM/Styles/img/menu1.png") repeat-x bottom left;
            color: #345077; display: block; position: relative; width: auto; padding: 4px 0; padding-left: 10px; text-decoration: none;
            border: 1px solid #b9cade; border-top: none; border-right: none; height: 21px; line-height: 20px; 
        }
        .funcClass.x-tree-node-over,
        .funcClass.x-tree-selected { background: url("/sHRM/Styles/img/menu2.png"); }
        .funcClass .icon-blank { display:none; }
        .funcClass .x-tree-elbow, .funcClass .x-tree-elbow-end { display:none; }

        .hasChild {  }
        .hasChild .x-tree-ec-icon { float:right; background-position: center; }
        .hasChild .x-tree-elbow-plus, .hasChild .x-tree-elbow-end-plus { background-image:url('/sHRM/Styles/img/cham1.png'); }
        .hasChild .x-tree-elbow-minus, .hasChild .x-tree-elbow-end-minus { background-image:url('/sHRM/Styles/img/cham2.png');  }

        .treeSpacer { height: 3px; padding: 0; background-color:#D2E0F1; }

        .lngCls {  }

    </style>

    <script type="text/javascript">

        var TopMenuRender_SelectionChanged = function (sender, idx, item, e) {
            //console.log(sender, idx, item, e);
            e.stopEvent();
            var fid = $(item).find('a').attr('href').substr(1);
            UrlHelper_HashAdd('f', fid);
            refreshLMenu(fid);

            $('#topMenuNav li a').removeClass('active');
            $('#topMenuNav li a').eq(idx).addClass('active');
        };
        function refreshLMenu(fid) {
            TreePanel1.getEl().mask("Loading", 'x-mask-loading');
            Ext.net.DirectMethods.RefreshLeftMenu(fid, {
                success: function (result) {
                    var nodes = eval(result);
                    if (nodes.length > 0) {
                        TreePanel1.initChildren(nodes);
                    }
                    else {
                        TreePanel1.getRootNode().removeChildren();
                    }
                    setTimeout("TreePanel1.getEl().unmask()", 350);
                }
            });
        }

        var loadPage = function (tabPanel, node) {
            var tab = tabPanel.getItem(node.id);
            
            if (!tab) {
                if (node.attributes.href == '.') {
                    if (node.expanded)
                        node.collapse();
                    else
                        node.expand();
                    return;
                }

                if (node.attributes.href == '?') {
                    node.attributes.href = "/Cpanel/SYS/building-construction.aspx";
                }

                if (node.attributes.modal > 0) {
                    CreateWin("w__" + node.id, node.attributes.href, node.text);
                    return;
                }

                tab = tabPanel.add({
                    id: node.id,
                    title: node.text,
                    closable: true,
                    autoLoad: {
                        showMask: true,
                        url: node.attributes.href,
                        mode: "iframe",
                        maskMsg: "Loading..."
                    },
                    listeners: {
                        update: {
                            fn: function (tab, cfg) {
                                cfg.iframe.setHeight(cfg.iframe.getSize().height);
                            },
                            scope: this,
                            single: true
                        },
                        activate: {
                            fn: function (tab) {
                                UrlHelper_HashAdd('t', tab.id.substr(1));
                            }
                        }
                    }
                });
            }

            tabPanel.setActiveTab(tab);
            UrlHelper_HashAdd('t', tab.id);
        }

        $(document).ready(function () {
            Ext.onReady(function () {

                //var id = UrlHelper_HashGet('f');
                //if (id != '') {
                //    refreshLMenu(id);
                //    $('#topMenuNav li a[href=#' + id + ']').addClass('active');
                //}

                //id = UrlHelper_HashGet('t');
                //if (id != '') {
                //    var node = TreePanel1.getNodeById('f' + id)
                //    node.fireEvent('click', node);
                //}

                var tab = Pages.insert(0, {
                    id: "Home",
                    title: "Home",
                    closable: false,
                    autoLoad: {
                        showMask: true,
                        url: "/sHRM/Dashboard.aspx",
                        mode: "iframe",
                        maskMsg: "Loading..."
                    }
                });
                Pages.setActiveTab(tab);
            });
        });

    </script>

    <script type="text/javascript">

        function requestEx(req, ex) {
            var s = '';
            s += 'status: ' + req.status + "<hr />";
            s += 'statusText: ' + req.statusText + "<hr />";
            s += 'message: <pre style="white-space: pre-wrap;">' + (req.responseText || ex.errorMessage) + "</pre>";
            $('#wEx_msg').html(s);
            wEx.show();
        }

        function wEx_btn1_click(sender, e) {
            if (e.shiftKey) {
                $('#wEx_msg').show();
                wEx.maximize();
            }
            else
                wEx.hide();
        }

    </script>

    <script type="text/javascript">

        var __w_key, __w_title, __w_width, __w_height, __w_url;

        function CreateWin(key, url, title, width, height) {
            if (width == undefined) width = 800;
            if (height == undefined) height = 450;

            var w = Ext.getCmp('w__' + key);
            if (w == undefined) {
                __w_key = 'w__' + key;
                __w_title = title;
                __w_width = width;
                __w_height = height;
                __w_url = url;
                btnCreateWin.fireEvent('click');
            }
            else {
                var is_reload = false;
                if (w.autoLoad.url != url) {
                    w.autoLoad.url = url;
                    is_reload = true;
                }
                else {
                    if (w.hidden && !w.minimized) is_reload = true;
                }

                if (is_reload)
                    w.reload();

                w.setTitle(title);
                w.show();
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <ext:ResourceManager runat="server" />

            <div style="display:none">
                <ext:Button ID="btnCreateWin" runat="server">
                    <DirectEvents>
                        <Click OnEvent="btnCreateWin_DirectClick">
                            <ExtraParams>
                                <ext:Parameter Name="key" Value="__w_key" Mode="Raw" />
                                <ext:Parameter Name="title" Value="__w_title" Mode="Raw" />
                                <ext:Parameter Name="url" Value="__w_url" Mode="Raw" />
                                <ext:Parameter Name="width" Value="__w_width" Mode="Raw" />
                                <ext:Parameter Name="height" Value="__w_height" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </div>

            <ext:Viewport runat="server" Layout="Border">
                <Items>
                    <ext:Panel runat="server" Border="False" Height="90" Region="North">
                        <Content>
                            <div class="BannerShrm">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <img id="idLogo" alt="" runat="server" style="height: 40px; width: 90px" src="/sHRM/Styles/img/Logo_129.png" />
                                        </td>
                                        <td>
                                            <p class="tenCty">Smart Shirts</p>
                                            <ext:Label ID="tenDoanhNghiep" runat="server" Text="Smart Shirts" Cls="tenCty2" />
                                        </td>
                                        <td style="width: 100%; text-align: center;">
                                            <img id="sHRM_logo" alt="" runat="server" src="/sHRM/Styles/img/Quantri.png" />
                                        </td>
                                        <td>
                                            <ext:CompositeField runat="server" Width="310">
                                                <Items>
                                                    <ext:Button runat="server" Icon="Note" Text="Notes" />
                                                    <ext:Button runat="server" Icon="Mail" Text="Notices (1)" ID="btnNotices">
                                                        <Menu>
                                                            <ext:Menu ID="btnNotices_menu" runat="server" />
                                                        </Menu>
                                                    </ext:Button>

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
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Template runat="server">
                                        <Html>
                                            <ul id="topMenuNav">
                                                <tpl for=".">
                                                    <li><a href="{url}">{name}</a></li>
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

                    <ext:Panel ID="pnlLeft" runat="server" Title="Các chức năng" Icon="ChartOrganisation" Collapsible="true" Collapsed="false"
                        Width="200" MaxWidth="250" Layout="FitLayout" Split="True" Region="West" Padding="0">
                        <Items>
                            <ext:TreePanel ID="TreePanel1" runat="server" Border="false" RootVisible="false" NoLeafIcon="true" Lines="false" Selectable="true"
                                CollapsedCls="abb">
                                <Listeners>
                                    <Click Handler="if (node.attributes.href) { e.stopEvent(); loadPage(#{Pages}, node); }" />
                                </Listeners>
                            </ext:TreePanel>
                        </Items>
                    </ext:Panel>

                    <ext:Panel runat="server" Layout="FitLayout" Region="Center">
                        <Items>
                            <ext:TabPanel ID="Pages" runat="server" EnableTabScroll="true" Border="false" />
                        </Items>
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
                                    <ext:Button runat="server" Icon="Lightbulb" Text="v4.0">
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
            
            <ext:Window ID="wEx" runat="server" Width="320" Height="130" Hidden="true" ShowInTaskbar="false" Icon="Exclamation" Title="Cảnh báo" Modal="true" Maximizable="false">
                <Content>
                    <p style="padding:10px">
                        Bị mất kết nối tới máy chủ dữ liệu, xin vui lòng thử lại sau!<br />
                        Nếu thông báo này xảy ra thường xuyên xin vui lòng liên hệ với quản trị viên...
                    </p>
                    <div id="wEx_msg" style="display: none"></div>
                </Content>
                <Buttons>
                    <ext:Button ID="wEx_btn1" runat="server" Text="Đóng lại">
                        <Listeners>
                            <Click Fn="wEx_btn1_click" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>

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
