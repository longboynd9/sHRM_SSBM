<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Category.Default" validateRequest="false" %>

<%@ Register src="~/Cpanel/UC/ImageUploader.ascx" tagname="ImageUploader" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <style type="text/css">
        .nodecode {
            font-weight:bold;
        }
        .nodecaption {
            color:#838383 !important;
        }

        .wpadding { padding:5px 10px; background-color:white; }
       
        .dmgocTrue { color:red !important; }

    </style>
    
    <script type="text/javascript">
        function bodau(str) {
            str = str.toLowerCase();
            str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
            str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
            str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
            str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
            str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
            str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
            str = str.replace(/đ/g, "d");
            str = str.replace(/!|@|\$|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\'| |\"|\&|\#|\[|\]|~/g, "-");
            str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1-
            str = str.replace(/^\-+|\-+$/g, "");//cắt bỏ ký tự - ở đầu và cuối chuỗi
            return str;
        }

        function OpenBvEditor(id, catid) {
            parent.CreateWin('danhmuc_BvEditor', '/CPanel/News/Editor.aspx?id=' + id + '&catid=' + catid, '#Category_Default.msg_js1', 800, 500);
        }
        function OpenSeoEditor(id, catid) {
            parent.CreateWin('danhmuc_SeoEditor', '/CPanel/Category/SEOData.aspx?id=' + id + '&catid=' + catid, '#Category_Default.msg_js2', 800, 500);
        }
    </script>

    <script type="text/javascript">
        var refreshTree = function () {
            Ext.net.DirectMethods.RefreshTree({
                success: function (result) {
                    var nodes = eval(result);
                    if (nodes.length > 0) {
                        TreeFunc.rootVisible = true;
                        TreeFunc.initChildren(nodes);
                        TreeFunc.expandAll();
                    }
                    else {
                        TreeFunc.getRootNode().removeChildren();
                    }
                }
            });
        }

        var searchTree = function () {
            Ext.net.DirectMethods.SearchTree($('#txtSearch').val(), {
                success: function (result) {
                    var nodes = eval(result);
                    if (nodes.length > 0) {
                        TreeFunc.initChildren(nodes);
                        TreeFunc.expandAll();
                    }
                    else {
                        TreeFunc.getRootNode().removeChildren();
                    }
                },
                eventMask: {
                    showMask: true,
                    minDelay: 500
                }
            });
        }

        var AddNode2SelectedNode = function (newNodeId) {
            Ext.net.DirectMethods.AddNode2SelectedNode(newNodeId, {
                success: function (result) {
                    var nodes = eval(result);
                    var n = TreeFunc.getSelectionModel().getSelectedNode();
                    if (n == null) {
                        Ext.Msg.show({ icon: Ext.MessageBox.ERROR, msg: 'SelectedNode not found, please refresh', buttons: Ext.Msg.OK });
                        return;
                    }

                    n.appendChild(nodes);
                    n.select();
                }
            });
        }

        var cm1_copyID = 0, cm1_cutID = 0;
        function cm1_itemclick(item, e) {
            switch (item.itemId) {
                case 'add':
                    btnAdd.fireEvent('click');
                    break;
                case 'edit':
                    btnEdit.fireEvent('click');
                    break;
                case 'del':
                    btnDel.fireEvent('click');
                    break;
                case 'refresh':
                    refreshTree();
                    break;
                case 'copy':
                    cm1_copyID = TreeFunc.selModel.getSelectedNode().id;
                    cm1_cutID = 0;
                    break;
                case 'cut':
                    cm1_copyID = 0;
                    cm1_cutID = TreeFunc.selModel.getSelectedNode().id;
                    break;
                case 'paste':
                    var toID = TreeFunc.selModel.getSelectedNode().id;
                    Ext.net.DirectMethods.PasteFunc(cm1_copyID, cm1_cutID, toID, {
                        success: function (result) {
                            var nodes = eval(result);
                            var n = TreeFunc.getSelectionModel().getSelectedNode();
                            if (n == null) {
                                Ext.Msg.show({ icon: Ext.MessageBox.ERROR, msg: 'SelectedNode not found, please refresh', buttons: Ext.Msg.OK });
                                return;
                            }

                            n.appendChild(nodes);
                            n.select();

                            if (cm1_cutID > 0)
                                TreeFunc.removeNode(TreeFunc.getNodeById(cm1_cutID));
                        }
                    });
                    break;
            }
        }

        function txtWE_speckey(sender, e) {
            if (e.getKey() == e.ENTER) {
                btnOk.fireEvent('click');
            }
        }

        function test(p1, p2, p3, p4) {
            console.log(p1);
            console.log(p2);
            console.log(p3);
            console.log(p4);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />

        <ext:Menu ID="cm1" runat="server">
            <Items>
                <ext:MenuItem Text="#Category_Default.themDMCon" Icon="Add" ItemID="add" />
                <ext:MenuItem Text="#Category_Default.sua" Icon="Pencil" ItemID="edit" />
                <ext:MenuItem Text="#Category_Default.xoa" Icon="Delete" ItemID="del" />
                <ext:MenuSeparator />
                <ext:MenuItem Text="#Category_Default.refresh" Icon="ArrowRefresh" ItemID="refresh" />
                <ext:MenuSeparator />
                <ext:MenuItem Text="#Category_Default.saochep" Icon="PageCopy" ItemID="copy" />
                <ext:MenuItem Text="#Category_Default.cat" Icon="Cut" ItemID="cut" />
                <ext:MenuItem Text="#Category_Default.dan" Icon="PastePlain" ItemID="paste" />
            </Items>
            <Listeners>
                <ItemClick Fn="cm1_itemclick" />
            </Listeners>
        </ext:Menu>
        
        <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
            <Items>

                <ext:Panel ID="Panel1" runat="server" Border="false" AutoScroll="true">
                    <TopBar>
                        <ext:Toolbar ID="toolbarGrid" runat="server">
                            <Items>
                                <ext:Button ID="btnAdd" Icon="Add" runat="server" Text="#Category_Default.them" OnDirectClick="btnAdd_DirectClick" />
                                <ext:Button ID="btnEdit" Icon="Pencil" runat="server" Text="#Category_Default.sua" OnDirectClick="btnEdit_DirectClick" />
                                <ext:Button ID="btnDel" Icon="Delete" runat="server" Text="#Category_Default.xoa">
                                    <DirectEvents>
                                        <Click OnEvent="btnDel_DirectClick">
                                            <Confirmation  BeforeConfirm="if (TreeFunc.selModel.selNode == null) { return false; } return true;" ConfirmRequest="true" Title="#Category_Default.title_msg" Message="#Category_Default.msg" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>

                                <ext:ToolbarSeparator Width="10" />
                                <ext:Button ID="Button1" Icon="ArrowRefresh" runat="server" Text="#Category_Default.refresh">
                                    <Listeners>
                                        <Click Fn="refreshTree" />
                                    </Listeners>
                                </ext:Button>

                                <ext:ToolbarSeparator Width="15" />
                                <ext:TextField ID="txtSearch" runat="server"></ext:TextField>
                                <ext:Button ID="btnSearch" Icon="Zoom" runat="server" Text="#common_btn.Find">
                                    <Listeners>
                                        <Click Fn="searchTree" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>

                    <Items>
                        <ext:TreePanel ID="TreeFunc" runat="server" Border="false" ContextMenuID="cm1" RootVisible="false">
                            <SelectionModel>
                                <ext:DefaultSelectionModel />
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                            <DirectEvents>
                                <DblClick OnEvent="btnEdit_DirectClick" />
                            </DirectEvents>
                        </ext:TreePanel>                
                    </Items>
                </ext:Panel>
                
            </Items>
        </ext:Viewport>

        <ext:Hidden ID="hId" runat="server" />
        <ext:Hidden ID="hParent" runat="server" />
        <ext:Window ID="wEditor" runat="server" Title="#Category_Default.title" Icon="Add" Height="340" Width="500" ButtonAlign="Right" Hidden="true" Resizable="false" Modal="true" Layout="FitLayout">
            <Items>
                <ext:FormPanel ID="formCT" runat="server" Border="false" Layout="FormLayout" PaddingSummary="10">
                    <Items>
                        <ext:Label ID="lblParent" runat="server" FieldLabel="#Category_Default.dmCha" AnchorHorizontal="100%" />
                        <ext:TextField ID="txtCaption" runat="server" FieldLabel="#Category_Default.tenDM" MaxLength="255" AllowBlank="false" MaskRe="[^<>&amp;*]" AnchorHorizontal="100%">
                            <Listeners>
                                <Change Handler="#{txtCode}.setValue(bodau(#{txtCaption}.getValue()));" />
                                <SpecialKey Fn="txtWE_speckey" />
                            </Listeners>
                        </ext:TextField>
                        <ext:TextField ID="txtCaption_EN" runat="server" FieldLabel="#Category_Default.tenEN" MaxLength="255" MaskRe="[^<>&amp;*]" AnchorHorizontal="100%">
                            <Listeners>
                                <SpecialKey Fn="txtWE_speckey" />
                            </Listeners>
                        </ext:TextField>
                        <ext:TextField ID="txtCaption_KR" runat="server" FieldLabel="#Category_Default.tenKR" MaxLength="255" MaskRe="[^<>&amp;*]" AnchorHorizontal="100%">
                            <Listeners>
                                <SpecialKey Fn="txtWE_speckey" />
                            </Listeners>
                        </ext:TextField>
                        <ext:TextField ID="txtCode" runat="server" FieldLabel="#Category_Default.maDM" MaxLength="50" AllowBlank="false" MaskRe="[^<>&amp;*]" AnchorHorizontal="100%" >
                            <Listeners>
                                <SpecialKey Fn="txtWE_speckey" />
                            </Listeners>
                        </ext:TextField>
                        <ext:TextField ID="txtlink" runat="server" FieldLabel="Link" MaxLength="255" AnchorHorizontal="100%">
                            <Listeners>
                                <SpecialKey Fn="txtWE_speckey" />
                            </Listeners>
                        </ext:TextField>
                        <ext:NumberField ID="txtOrder" runat="server" FieldLabel="#Category_Default.thutu" AnchorHorizontal="50%">
                            <Listeners>
                                <SpecialKey Fn="txtWE_speckey" />
                            </Listeners>
                        </ext:NumberField>
                        <ext:HyperLink ID="lnkSeoData" runat="server" FieldLabel="SEO data" />
                        <ext:HyperLink ID="lnkBaiViet" runat="server" FieldLabel="#Category_Default.baiviet" />
                        <ext:ComboBox runat="server" ID="cbostatus" FieldLabel="#Category_Default.trangthai" Editable="false" AnchorHorizontal="50%"></ext:ComboBox>
                    </Items>
                </ext:FormPanel>
            </Items>

            <Buttons>
                <ext:Button ID="btnOk" Icon="Disk" runat="server" Text="#Category_Default.luu" OnDirectClick="btnOk_DirectClick" >
                    <Listeners>
                        <Click Handler="if (#{formCT}.getForm().isValid()==false){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#Category_Default.msg_js3', buttons:Ext.Msg.OK}); return false;}" />
                    </Listeners>
                </ext:Button>
                <ext:Button ID="btnClear" runat="server" Text="#Category_Default.xoatrang" Icon="PageWhite">
                    <Listeners>
                        <Click Handler="#{formCT}.getForm().reset();
                            #{txtMoTaNgan}.reset();
                            " />
                    </Listeners>
                </ext:Button>
                <ext:Button ID="Button2" runat="server" Text="#Category_Default.dong" Icon="Cancel" OnDirectClick="Button2_DirectClick" />
            </Buttons>
        </ext:Window>

    </div>
    </form>
</body>
</html>
