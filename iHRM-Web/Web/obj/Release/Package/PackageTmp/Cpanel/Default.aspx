<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>WEB ADMIN</title>

    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <style type="text/css">
        .start-button {
            background-image: url('/Cpanel/Skins/Style/IMG/w8button.png') !important;
        }

        .ux-startbutton-left, .ux-startbutton-right {
            background: url("/ux/extensions/desktop/images/taskbar/black/startbutton-gif/ext.axd") repeat-x 0 -60px !important;
        }

        .shortcut-icon {
            width: 48px;
            height: 48px;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="/Cpanel/Skins/Style/IMG/window.png", sizingMethod="scale");
        }

        .icon-grid48 {
            background-image: url('/Cpanel/Skins/Style/IMG/grid48x48.png') !important;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="/Cpanel/Skins/Style/IMG/grid48x48.png", sizingMethod="scale");
        }

        .icon-user48 {
            background-image: url('/Cpanel/Skins/Style/IMG/user48x48.png') !important;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="/Cpanel/Skins/Style/IMG/user48x48.png", sizingMethod="scale");
        }

        .icon-window48 {
            background-image: url('/Cpanel/Skins/Style/IMG/window48x48.png') !important;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="/Cpanel/Skins/Style/IMG/window48x48.png", sizingMethod="scale");
        }

        .icon-folder48, .isfolder2 {
            background-image: url('/Cpanel/Skins/Style/IMG/folder.png') !important;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="/Cpanel/Skins/Style/IMG/folder.png", sizingMethod="scale");
        }

        .icon-report48 {
            background-image: url('/Cpanel/Skins/Style/IMG/report.png') !important;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="/Cpanel/Skins/Style/IMG/report.png", sizingMethod="scale");
        }

        .icon-time48 {
            background-image: url('/Cpanel/Skins/Style/IMG/clock_blue.png') !important;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="/Cpanel/Skins/Style/IMG/clock_blue.png", sizingMethod="scale");
        }

        .icon-reportfolder {
            background-image: url('/Cpanel/Skins/Style/IMG/first_year_production.png') !important;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="/Cpanel/Skins/Style/IMG/first_year_production.png", sizingMethod="scale");
        }

        .icon-report2 {
            background: url('/Cpanel/Skins/Style/IMG/report-icon.png') center center no-repeat !important;
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="/Cpanel/Skins/Style/IMG/report-icon.png", sizingMethod="scale");
        }

        .desktopEl {
            position: absolute !important;
        }

        .logoutbtnclass {
            position: absolute;
            bottom: 3px;
            width: 110px;
        }

        .fview .x-panel-body {
            background: white;
            font: 11px Arial, Helvetica, sans-serif;
        }

        .fview .thumb-wrap {
            float: left;
            margin: 4px;
            margin-right: 0;
            padding: 5px 15px;
            text-align: center;
            cursor: pointer;
            width: 120px;
        }

            .fview .thumb-wrap .thumb {
                background: url('/Cpanel/Skins/Style/IMG/file48.png') no-repeat center;
                padding: 3px;
                min-width: 48px;
                height: 48px;
            }

            .fview .thumb-wrap span {
                display: block;
                overflow: hidden;
                text-align: center;
                height: 26px;
            }

        .fview .x-view-over {
            border: 1px solid #dddddd;
            background: #efefef url('/Cpanel/Skins/Style/IMG/fview_item-over.gif') repeat-x left top;
            padding: 4px 14px;
        }

        .fview .x-view-selected {
            background: #eff5fb url('/Cpanel/Skins/Style/IMG/fview_item-selected.gif') no-repeat right bottom;
            border: 1px solid #99bbe8;
            padding: 4px 14px;
        }

        .fview .loading-indicator {
            font-size: 11px;
            background-image: url('/Cpanel/Skins/Style/IMG/loading.gif');
            background-repeat: no-repeat;
            background-position: left;
            padding-left: 20px;
            margin: 10px;
        }

        body {
            -webkit-background-size: 100% 100%;
            -moz-background-size: 100% 100%;
            -o-background-size: 100% 100%;
            background-size: 100% 100%;
        }

        .allprogram {
            position: absolute;
            width: 186px;
            bottom: 2px;
        }
    </style>

    <style type="text/css">
        @keyframes animatedBg1 {
            0% {
                background-position-x: -860px;
            }

            100% {
                background-position-x: 1260px;
            }
        }

        @-webkit-keyframes animatedBg1 {
            0% {
                background-position-x: -860px;
            }

            100% {
                background-position-x: 1260px;
            }
        }

        html {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        body {
            -webkit-background-size: 100% 100%;
            -moz-background-size: 100% 100%;
            -o-background-size: 100% 100%;
            background-size: 100% 100%;
            /*background-image: url('1.jpg');*/
            background-repeat: no-repeat;
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #skya_div1, #skya_div2, #skya_div3 {
            height: 500px;
            background-repeat: no-repeat;
            position: absolute;
            left: 0;
            top: 0;
            right: 0;
        }

        #skya_div1 {
            -webkit-animation: animatedBg1 linear 15s infinite;
            animation: animatedBg1 linear 15s infinite;
            background-image: url('/Cpanel/Skins/sky_animation/2.png');
            background-position: -860px 70px;
        }

        #skya_div2 {
            -webkit-animation: animatedBg1 linear 25s infinite;
            animation: animatedBg1 linear 25s infinite;
            background-image: url('/Cpanel/Skins/sky_animation/4.png');
            background-position: -860px 0px;
        }

        #skya_div3 {
            -webkit-animation: animatedBg1 linear 20s infinite;
            animation: animatedBg1 linear 20s infinite;
            background-image: url('/Cpanel/Skins/sky_animation/5.png');
            background-position: -860px 70px;
        }

        #x-shortcuts {
            position: absolute;
            z-index: 7;
        }
        
        .ux-taskbuttons-strip { height:30px; }
        #statusbar1 { position: absolute; top: 3px; right: 0; height: 26px; line-height: 26px; font: normal 11px tahoma,verdana,helvetica; }
        #statusbar1 .g { display:inline-block; height:22px; margin-top: 2px; border-left: solid 1px #ccc; padding-left:5px; }
        #statusbar1 .it { margin-right: 5px; float: left; }
        #statusbar1 .it .i { display: inline-block; width: 20px; height: 22px; background: center center no-repeat; float: left; }
        #statusbar1 .it .i_db { background-image: url('/Cpanel/Skins/Style/IMG/i_db.png');}
        #statusbar1 .it .i_vs { background-image: url('/Cpanel/Skins/Style/IMG/i_vs.png');}
        #statusbar1 .it .i_cp { background-image: url('/Cpanel/Skins/Style/IMG/i_cp.png');}
        #statusbar1 .it .i_en { background-image: url('/Cpanel/Skins/Style/IMG/i_en.png');}
        #statusbar1 .it .i_vi { background-image: url('/Cpanel/Skins/Style/IMG/i_vi.png');}
        #statusbar1 .it .t { display: inline-block; height: 22px; float: left; padding-top: 5px; color: white; margin-left:3px; }

        #btnLng { cursor:pointer; }        
        .lng1 { height: 22px; display:block !important; }
        .lng1 img { margin-top: 6px; }
        .lng1 span span { color: white; margin-left: 3px; }
    </style>

    <script type="text/javascript">

        function CreateWin(key, url, title, width, height, ico) {
            if (width == undefined) width = 800;
            if (height == undefined) height = 450;

            var desk = MyDesktop.getDesktop();
            if (desk == undefined)
                return;

            var w = desk.getWindow('wDesk_' + key);
            if (w != undefined) {
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
                return;
            }

            w = desk.createWindow({
                id: "wDesk_" + key, title: title, width: width, height: height, maximizable: true, minimizable: true, icon: ico,
                autoLoad: { url: url, mode: "iframe", showMask: true },
                tools: [
                    { id: 'refresh', tooltip: 'Refresh', handler: function (event, toolEl, panel) { MyDesktop.getDesktop().getWindow("wDesk_" + key).reload(); } },
                    { id: 'help', tooltip: 'Help', handler: function (event, toolEl, panel) { } }
                ]
            });
            w.center();
            w.show();
        }

        function DesktopShortcut_laucher(id) {
            if (id.substring(0, 1) == "#") {
                switch (id.substring(1, id.indexOf('/'))) {
                    case "folder":
                        wFolderViewer_btnEnterFolder_folderid.setValue('');
                        wFolderViewer_btnEnterFolder_foldercode.setValue(id.substring(id.indexOf('/') + 1));
                        wFolderViewer_btnEnterFolder.fireEvent('click');
                        break;
                    case "func":
                        Ext.net.DirectMethods.GetFuncPath(id.substring(id.indexOf('/') + 1), {
                            success: function (result) {
                                var obj = eval('(' + result + ')');
                                CreateWin(obj.id, obj.path, obj.title);
                            },
                            complete: function () {
                            }
                        });
                }
            }
            else {
                switch (id) {
                    case "sys_change_log":
                        CreateWin(id, "/Cpanel/SYS/change-log.aspx", "Change log", 800, 500, "Time");
                        break;
                    case "banner":
                        CreateWin(id, "/Cpanel/Category/Banner.aspx", "WallPaper", 800, 500, "Cog");
                        break;

                    case "slide":
                        CreateWin(id, "/Cpanel/Slide/Default.aspx", "Slide Manager", 1100, 500);
                        break;
                    case "pageconfig":
                        CreateWin(id, "/Cpanel/HtmlModule/PageConfig.aspx", "Page Config", 800, 300);
                        break;
                    case "htmlmodule":
                        CreateWin(id, "/Cpanel/HtmlModule/Default.aspx", "HTML Module", 1200, 500);
                        break;
                    case "category":
                        CreateWin(id, "/Cpanel/Category/Default.aspx", "Category Manager", 800, 450);
                        break;
                    case "news":
                        CreateWin(id, "/Cpanel/News/Default.aspx", "News Manager", 1200, 450);
                        break;
                    case "syspa":
                        CreateWin(id, "/Cpanel/Category/sysPa.aspx", "System Parametter");
                        break;

                    default:
                        CreateWin(id, "/Cpanel/SYS/building-construction.aspx", "Under construction");
                        break;
                }
            }
        }

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

        function test(p1, p2, p3, p4) {
            console.log(p1);
            console.log(p2);
            console.log(p3);
            console.log(p4);
        }

        $(document).ready(function () {
            Ext.onReady(function () {
                Ext.getBody().on("contextmenu", Ext.emptyFn, null, { preventDefault: true });

                $('.ux-taskbuttons-strip').append($('#taskbar_right').html());
                $('#taskbar_right').remove();

                $('#btnLng').click(function () {
                    Ext.getCmp('wLng').show();
                });
            });

            $('#chkAnimation').change(function () {
                $('#divAnimation').html($(this).is(':checked') ? '<div id="skya_div1"></div><div id="skya_div2"></div><div id="skya_div3"></div>' : '');
            });
        });

        //http://www.sencha.com/forum/showthread.php?83224-Desktop-Icon-Manager
    </script>

    <script type="text/javascript">

        var wFolderViewer_btnEnterFolder_folderid = "";
        var wFolderViewer_btnEnterFolder_foldercode = "";

        function wFolderViewer_itemclick(item, idx, html, event) {
            var data = item.store.data.items[idx].data;
            //console.log(data);
            if (data.type == 1) { //item
                CreateWin(data.id, data.asemblyPath, data.caption);
            }
            else if (data.type == 2) { //folder
                wFolderViewer_btnEnterFolder_folderid.setValue(data.id);
                wFolderViewer_btnEnterFolder_foldercode.setValue('');
                wFolderViewer_btnEnterFolder.fireEvent('click');
            }
        }

        function wFolderViewer_address_keydown(sender, e) {
            if (e.keyCode == 13) {
                wFolderViewer_address.fireEvent("Change");
                e.stopEvent();
            }
        }

    </script>

</head>
<body>
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" ShowWarningOnAjaxFailure="false">
            <Listeners>
                <AjaxRequestException Fn="requestEx" />
            </Listeners>
        </ext:ResourceManager>

        <ext:Menu ID="cm_StartMenuAllItem" runat="server">
            <Items>
                <ext:MenuItem ID="cm_StartMenuAllItem_runAsAdmin" runat="server" Icon="Shield" Text="Run as administrator"></ext:MenuItem>
                <ext:MenuItem ID="cm_StartMenuAllItem_sendToDesktop" runat="server" Icon="MonitorGo" Text="Send to desktop"></ext:MenuItem>
            </Items>
        </ext:Menu>

        <ext:Menu ID="cm_Desktop" runat="server">
            <Items>
                <ext:MenuItem ID="cm_Desktop_view" runat="server" Icon="None" Text="#Desktop.cm_view" HideOnClick="false">
                    <Menu>
                        <ext:Menu runat="server">
                            <Items>
                                <ext:MenuItem ID="cm_Desktop_view_theoluoi" runat="server" Icon="None" Text="#Desktop.cm_view_theoluoi" />
                                <ext:MenuItem ID="cm_Desktop_view_tudo" runat="server" Icon="None" Text="#Desktop.cm_view_tudo" />
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:MenuItem>
                <ext:MenuItem ID="cm_Desktop_resfresh" runat="server" Icon="ArrowRefreshSmall" Text="#Desktop.cm_refresh"></ext:MenuItem>
                <ext:MenuSeparator />
                <ext:MenuItem ID="cm_Desktop_persional" runat="server" Icon="PhotoPaint" Text="#Desktop.cm_persional"></ext:MenuItem>
            </Items>
        </ext:Menu>

        <ext:Desktop ID="MyDesktop" runat="server" BackgroundColor="Black" ShortcutTextColor="White" Wallpaper="/Cpanel/Skins/Style/IMG/desktop_bg2.jpg"
            TextLengthToTruncate="35">

            <StartButton Text="iHRM" IconCls="start-button" />

            <Content>
                <div id="divAnimation"></div>

                <div style="right: 0; position: absolute; padding: 5px 10px 0 0;">
                    <span style="color: black; font-size: 20px; text-shadow: #fff 1px 2px; text-align: right;">iHRM - Smart Shirts</span><br />
                    <label>
                        <input type="checkbox" id="chkAnimation" />
                        Animation</label>
                </div>

                <div style="display: none">
                    <ext:Button ID="wFolderViewer_btnEnterFolder" runat="server" ClientIDMode="Static" OnDirectClick="wFolderViewer_btnEnterFolder_DirectClick" />
                    <ext:Hidden ID="wFolderViewer_backId" runat="server" ClientIDMode="Static" />
                    <ext:Hidden ID="wFolderViewer_btnEnterFolder_folderid" runat="server" ClientIDMode="Static" />
                    <ext:Hidden ID="wFolderViewer_btnEnterFolder_foldercode" runat="server" ClientIDMode="Static" />
                </div>

                <ul id="taskbar_right">
                    <li id="statusbar1">
                        <div class="g">
                            <span class="it" id="btnLng">
                                <ext:Label ID="statusbar1_lng" runat="server" Icon="FlagVn" Text="Tiếng việt" IconCls="i" ItemCls="t" CtCls="lng1" />
                            </span>
                        </div>
                        <div class="g">
                            <span class="it">
                                <i class="i i_vs"></i><span class="t">v1.2</span>
                            </span>
                            <span class="it">
                                <i class="i i_cp"></i><span class="t" id="statusbar1_ip" runat="server">IP</span>
                            </span>
                            <span class="it">
                                <i class="i i_db"></i><span class="t" id="statusbar1_db" runat="server">Database</span>
                            </span>
                        </div>
                    </li>
                </ul>
            </Content>

            <Shortcuts>
                <ext:DesktopShortcut ShortcutID="#folder/employee" Text="Employee" IconCls="shortcut-icon icon-grid48" />
                <ext:DesktopShortcut ShortcutID="#func/sal_approved" Text="Approved salary" IconCls="shortcut-icon icon-grid48" />
            </Shortcuts>

            <Listeners>
                <Ready Handler="Ext.get('x-desktop').on('contextmenu', function(e){e.stopEvent();e.preventDefault();#{cm_Desktop}.showAt(e.getPoint());});" />

                <ShortcutClick Handler="DesktopShortcut_laucher(id)" />
            </Listeners>

            <StartMenu Width="330" Height="400" ToolsWidth="127" Shadow="true" Title="Administrator" Icon="User">
                <ToolItems>
                    <ext:MenuItem Icon="Wrench" Text="#Desktop.startMenu_Wrench">
                        <Listeners>
                            <Click Handler="DesktopShortcut_laucher('banner')" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem Icon="Time" Text="#Desktop.startMenu_Update">
                        <Listeners>
                            <Click Handler="DesktopShortcut_laucher('sys_change_log')" />
                        </Listeners>
                    </ext:MenuItem>

                    <ext:MenuSeparator />

                    <ext:MenuItem Text="#Desktop.startMenu_Logout" Icon="Disconnect" CtCls="logoutbtnclass">
                        <DirectEvents>
                            <Click OnEvent="Logout_Click">
                                <EventMask ShowMask="true" Msg="Đang đăng xuất..." MinDelay="1000" />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                </ToolItems>

                <Items>

                    <ext:MenuItem ID="StartMenu_mAllitem" runat="server" Text="#Desktop.startMenu_AllPrograme" Icon="Folder" HideOnClick="false" CtCls="allprogram">
                    </ext:MenuItem>

                </Items>
            </StartMenu>

            <Plugins>
            </Plugins>
        </ext:Desktop>

        <ext:DesktopWindow ID="wFolderViewer" runat="server" Title="Report" Icon="Folder" Maximizable="false" Width="750" Height="400" Layout="BorderLayout">
            <TopBar>
                <ext:Toolbar runat="server" Layout="HBoxLayout">
                    <Items>
                        <ext:Button ID="wFolderViewer_btnBack" runat="server" Icon="ReverseGreen" Text="#common_btn.Back" OnDirectClick="wFolderViewer_btnBack_DirectClick" />
                        <ext:ToolbarSpacer runat="server" />
                        <ext:TriggerField ID="wFolderViewer_address" runat="server" Flex="1" EnableKeyEvents="true">
                            <Triggers>
                                <ext:FieldTrigger Icon="SimpleGo" />
                            </Triggers>
                            <Listeners>
                                <KeyDown Fn="wFolderViewer_address_keydown" />
                            </Listeners>
                            <DirectEvents>
                                <Change OnEvent="wFolderViewer_adressGo" />
                                <TriggerClick OnEvent="wFolderViewer_adressGo" />
                            </DirectEvents>
                        </ext:TriggerField>
                    </Items>
                </ext:Toolbar>
            </TopBar>

            <Items>

                <ext:TreePanel ID="wFolderViewer_treeF" runat="server" Animate="true" ContainerScroll="true" RootVisible="false" Width="200" 
                    AutoScroll="true" Region="West" Split="true" Border="false">
                    <DirectEvents>
                        <Click OnEvent="wFolderViewer_treeF_Click">
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="node.id" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:TreePanel>

                <ext:DataView ID="DataView1" runat="server" SingleSelect="true" OverClass="x-view-over" ItemSelector="div.thumb-wrap" Cls="fview" Region="Center">
                    <Template ID="Template1" runat="server">
                        <Html>
                            <tpl for=".">
								<div class="thumb-wrap">
								    <div class="thumb isfolder{type}"></div>
								    <span>{caption}</span>
								</div>
							</tpl>
                        </Html>
                    </Template>

                    <Listeners>
                        <Click Fn="wFolderViewer_itemclick" />
                    </Listeners>

                    <Store>
                        <ext:Store runat="server" ID="stoFolderViewer">
                            <Reader>
                                <ext:JsonReader IDProperty="id">
                                    <Fields>
                                        <ext:RecordField Name="id" />
                                        <ext:RecordField Name="caption" />
                                        <ext:RecordField Name="asemblyPath" />
                                        <ext:RecordField Name="type" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:DataView>
            </Items>
        </ext:DesktopWindow>

        <ext:DesktopWindow ID="wEx" runat="server" Width="320" Height="130" Hidden="true" ShowInTaskbar="false" Icon="Exclamation" Title="Cảnh báo" Modal="true" Maximizable="false">
            <Content>
                <p>
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
        </ext:DesktopWindow>

        <ext:DesktopWindow ID="wLng" runat="server" Width="225" Height="80" Hidden="true" ShowInTaskbar="false" Icon="World" Title="Ngôn ngữ" Layout="AbsoluteLayout" Maximizable="false" Minimizable="false">
            <Items>
                <ext:Button ID="wLng_btnVI" runat="server" CommandArgument="vi" Text="Tiếng việt" OnDirectClick="wLng_DirectClick" Icon="FlagVn" Width="90" Height="50" X="10" Y="10" />
                <ext:Button ID="wLng_btnEN" runat="server" CommandArgument="en" Text="English" OnDirectClick="wLng_DirectClick" Icon="FlagUs" Width="90" Height="50" X="110" Y="10" />
            </Items>
        </ext:DesktopWindow>
    </form>
</body>
</html>
