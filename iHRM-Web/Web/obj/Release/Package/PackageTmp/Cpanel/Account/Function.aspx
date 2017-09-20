<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Function.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Account.Function" %>
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
    </style>
    
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script type="text/javascript">
        var refreshTree = function () {
            Ext.net.DirectMethods.RefreshTree({
                success: function (result) {
                    var nodes = eval(result);
                    console.log(nodes);
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

        function txtAsemblyPath_TriggerClick(sender, trigger, idx, tag) {
            if (tag == 'b1') {
                wAsemplyPathAdd.show();
            }
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
                <ext:MenuItem Text="#Account_Function.cm_Add" Icon="Add" ItemID="add" />
                <ext:MenuItem Text="#Account_Function.cm_Edit" Icon="Pencil" ItemID="edit" />
                <ext:MenuItem Text="#Account_Function.cm_Delete" Icon="Delete" ItemID="del" />
                <ext:MenuSeparator />
                <ext:MenuItem Text="#Account_Function.cm_Refresh" Icon="ArrowRefresh" ItemID="refresh" />
                <ext:MenuSeparator />
                <ext:MenuItem Text="#Account_Function.cm_Copy" Icon="PageCopy" ItemID="copy" />
                <ext:MenuItem Text="#Account_Function.cm_Cut" Icon="Cut" ItemID="cut" />
                <ext:MenuItem Text="#Account_Function.cm_Paste" Icon="PastePlain" ItemID="paste" />
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
                                            <Confirmation ConfirmRequest="true" 
                                                BeforeConfirm="if (TreeFunc.selModel.selNode == null) { return false; } return true;"
                                                Title="Xác nhận lại" 
                                                Message="Hành động này sẽ xóa vĩnh viễn chức năng và không thể hoàn tác.<br />Bạn chắc chắn muốn tiếp tục?" />
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
                        <ext:TreePanel ID="TreeFunc" runat="server" Border="false" ContextMenuID="cm1">
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

        <ext:Window
            ID="wEditor"
            runat="server"
            Title="#Account_Function.editor_Title"
            Icon="Cog"
            Height="270"
            Width="500"
            ButtonAlign="Left"
            Hidden="true"
            Resizable="false"
            Modal="true">
            <Content>
                <ext:Panel ID="Panel2" runat="server" ButtonAlign="Right" AutoWidth="true" Border="false"  Height="240">
                    <Content>

                        <table width="100%" cellpadding="5px">
                            <tr>
                                <td class="c1">
                                    <uc1:ImageUploader ID="ImageUploader1" runat="server" />
                                </td>
                                <td class="spacedoc"></td>
                                <td class="c2">
                                    <ext:Hidden ID="hId" runat="server" />
                                    <ext:Hidden ID="hParent" runat="server" />
                                    <ext:FormPanel ID="formCT" runat="server" Border="false">
                                        <Items>
                                            <ext:Label Width="180" ID="lblParent" runat="server" FieldLabel="#Account_Function.editor_lblParent" />
                                            <ext:TextField Width="180" ID="txtCode" runat="server" FieldLabel="#Account_Function.editor_txtCode" MaxLength="50" MaskRe="[^<>&amp;*]">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:TextField Width="180" ID="txtCaption" runat="server" FieldLabel="#Account_Function.editor_txtCaption" MaxLength="50" AllowBlank="false" MaskRe="[^<>&amp;*]">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:TextField Width="180" ID="txtCaption_EN" runat="server" FieldLabel="#Account_Function.editor_txtCaption_EN" MaxLength="50" MaskRe="[^<>&amp;*]">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:TriggerField Width="180" ID="txtAsemblyPath" runat="server" FieldLabel="#Account_Function.editor_txtAsemblyPath" MaxLength="255" AllowBlank="false" MaskRe="[^<>&amp;*]">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Ellipsis" Tag="b1" />
                                                </Triggers>
                                                <Listeners>
                                                    <TriggerClick Fn="txtAsemblyPath_TriggerClick" />
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TriggerField>
                                            <ext:TextField Width="180" ID="txtAsemblyInherits" runat="server" FieldLabel="#Account_Function.editor_txtAsemblyInherits" MaxLength="255" MaskRe="[^<>&amp;*]">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:NumberField Width="180" ID="txtOrder" runat="server" FieldLabel="#Account_Function.editor_txtOrder">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:NumberField>
                                        </Items>
                                    </ext:FormPanel>
                                </td>
                            </tr>
                        </table>

                    </Content>

                    <Buttons>
                        <ext:Button ID="btnOk" Icon="Disk" runat="server" Text="Lưu" OnDirectClick="btnOk_DirectClick" >
                            <Listeners>
                                <Click Handler="if (#{formCT}.getForm().isValid()==false){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: 'Xin vui lòng điền đủ dữ liệu', buttons:Ext.Msg.OK}); return false;}" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="btnClear" runat="server" Text="#common_btn.Clear" Icon="PageWhite">
                            <Listeners>
                                <Click Handler="#{formCT}.getForm().reset();
                                    #{txtMoTaNgan}.reset();
                                    " />
                            </Listeners>
                        </ext:Button>
                     <%--   <ext:Button ID="Button2" runat="server" Text="#common_btn.Close" Icon="Cancel">
                            <Listeners>
                                <Click Handler="#{wEditor}.hide();" />
                            </Listeners>
                        </ext:Button>--%>
                    </Buttons>
                </ext:Panel>
            </Content>
        </ext:Window>

        <ext:Window
            ID="wAsemplyPathAdd"
            runat="server"
            Title="#Account_Function.wAsemply_Title"
            Icon="Add"
            Height="420"
            Width="370"
            ButtonAlign="Right"
            Hidden="true"
            Resizable="false"
            Modal="true" Layout="FitLayout">
            <Items>
                <ext:TreePanel ID="treeAsemplyPath" runat="server" AutoScroll="true" Border="false">
                    <SelectionModel>
                        <ext:DefaultSelectionModel>
                        </ext:DefaultSelectionModel>
                    </SelectionModel>
                </ext:TreePanel>
            </Items>

            <Buttons>
                <ext:Button ID="btnSaveAsemply" Icon="Disk" runat="server" Text="#common_btn.Ok">
                    <Listeners>
                        <Click Handler="#{txtAsemblyPath}.setValue( #{treeAsemplyPath}.selModel.selNode.id); #{wAsemplyPathAdd}.hide(); " />
                    </Listeners>
                </ext:Button>

                <ext:Button runat="server" Text="#common_btn.Close" Icon="Cancel">
                    <Listeners>
                        <Click Handler="#{wAsemplyPathAdd}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </div>
    </form>
</body>
</html>

