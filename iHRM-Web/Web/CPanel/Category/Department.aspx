<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Category.Department" validateRequest="false" %>

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
                <ext:MenuItem Text="#Category_Department.tenPB" Icon="Add" ItemID="add" />
                <ext:MenuItem Text="Category_Department.sua" Icon="Pencil" ItemID="edit" />
                <ext:MenuItem Text="Category_Department.xoa" Icon="Delete" ItemID="del" />
                <ext:MenuSeparator />
                <ext:MenuItem Text="#Category_Department.refresh" Icon="ArrowRefresh" ItemID="refresh" />
                <ext:MenuSeparator />
                <ext:MenuItem Text="#Category_Department.saochep" Icon="PageCopy" ItemID="copy" />
                <ext:MenuItem Text="#Category_Department.cat" Icon="Cut" ItemID="cut" />
                <ext:MenuItem Text="#Category_Department.dan" Icon="PastePlain" ItemID="paste" />
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
                                <ext:Button ID="btnAdd" Icon="Add" runat="server" Text="#common_btn.AddNew" OnDirectClick="btnAdd_DirectClick" />
                                <ext:Button ID="btnEdit" Icon="Pencil" runat="server" Text="#common_btn.Edit" OnDirectClick="btnEdit_DirectClick" />
                                <ext:Button ID="btnDel" Icon="Delete" runat="server" Text="#common_btn.Delete">
                                    <DirectEvents>
                                        <Click OnEvent="btnDel_DirectClick">
                                            <Confirmation  BeforeConfirm="if (TreeFunc.selModel.selNode == null) { return false; } return true;" ConfirmRequest="true" Title="Xác nhận lại" Message="Hành động này sẽ xóa vĩnh viễn danh mục và không thể hoàn tác.<br />Bạn chắc chắn muốn tiếp tục?" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>

                                <ext:ToolbarSeparator Width="10" />
                                <ext:Button ID="Button1" Icon="ArrowRefresh" runat="server" Text="#common_btn.Refresh">
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
                        <ext:TreePanel ID="TreeFunc" runat="server" Border="false" ContextMenuID="cm1" RootVisible="true">
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
        <ext:Window ID="wEditor" runat="server" Title="#Category_Department.Editor_title" Icon="Add" Height="340" Width="500" ButtonAlign="Right" Hidden="true" Resizable="false" Modal="true" Layout="FitLayout">
            <Items>
                <ext:FormPanel ID="formCT" runat="server" Border="false" Layout="FormLayout" PaddingSummary="10">
                    <Items>
                        <ext:ComboBox ID="cmbParent" DataIndex="DepParent" runat="server" FieldLabel="#Category_Department.Editor_lblParent" AnchorHorizontal="100%" />

                        <ext:TextField ID="txtCaption" runat="server" DataIndex="DepName" FieldLabel="#Category_Department.Editor_txtCaption" MaxLength="255" AllowBlank="false" MaskRe="[^<>&amp;*]" AnchorHorizontal="100%">
                            <Listeners>
                                <SpecialKey Fn="txtWE_speckey" />
                            </Listeners>
                        </ext:TextField>
                        <ext:TextField ID="txtCaption_VN" runat="server" DataIndex="DepName_VN" FieldLabel="#Category_Department.Editor_txtCaption_VN" MaxLength="255" MaskRe="[^<>&amp;*]" AnchorHorizontal="100%">
                            <Listeners>
                                <SpecialKey Fn="txtWE_speckey" />
                            </Listeners>
                        </ext:TextField>
                        <ext:TextField ID="txtCode" runat="server" DataIndex="DepID" FieldLabel="#Category_Department.Editor_txtCode" MaxLength="50" AllowBlank="false" MaskRe="[^<>&amp;*]" AnchorHorizontal="100%" >
                            <Listeners>
                                <SpecialKey Fn="txtWE_speckey" />
                            </Listeners>
                        </ext:TextField>

                        <ext:NumberField ID="txtOrder" runat="server" DataIndex="OrderNo" FieldLabel="#Category_Department.Editor_txtOrder" AnchorHorizontal="50%">
                            <Listeners>
                                <SpecialKey Fn="txtWE_speckey" />
                            </Listeners>
                        </ext:NumberField>
                        <ext:TextArea ID="txtNote" runat="server" DataIndex="Notes" FieldLabel="#Category_Department.Editor_txtNote" AnchorHorizontal="100%">
                        </ext:TextArea>
                    </Items>
                </ext:FormPanel>
            </Items>

            <Buttons>
                <ext:Button ID="btnOk" Icon="Disk" runat="server" Text="#Category_Department.luu" OnDirectClick="btnOk_DirectClick" >
                    <Listeners>
                        <Click Handler="if (#{formCT}.getForm().isValid()==false){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#Category_Department.msg_js', buttons:Ext.Msg.OK}); return false;}" />
                    </Listeners>
                </ext:Button>
                <ext:Button ID="btnClear" runat="server" Text="#Category_Department.xoatrang" Icon="PageWhite">
                    <Listeners>
                        <Click Handler="#{formCT}.getForm().reset();
                            #{txtMoTaNgan}.reset();
                            " />
                    </Listeners>
                </ext:Button>
                <ext:Button ID="Button2" runat="server" Text="#Category_Department.dong" Icon="Cancel" OnDirectClick="Button2_DirectClick" />
            </Buttons>
        </ext:Window>

    </div>
    </form>
</body>
</html>
