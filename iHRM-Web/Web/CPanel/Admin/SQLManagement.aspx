<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SQLManagement.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Admin.SQLManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    
    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <script type="text/javascript" src="/Cpanel/Skins/Js/BitHelper.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script src="/Cpanel/Skins/Js/Ext/textarea_getSelection.js" type="text/javascript"></script>
    
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <style type="text/css">
        .x-window-body { padding: 5px 10px; }

        .msgdiv { margin-top: 5px; text-align: left; }
        .msgdiv .sttTrue { font-weight: bold; color:#00c419; }
        .msgdiv .sttFalse { font-weight: bold; color:#f00; }
        .mssgdiv .msg { color: rgb(100, 100, 100); padding-left: 15px; }
    </style>

    <script type="text/javascript">
        function cm_grdProcList_itemclick(item, e) {
            switch (item.itemId) {
                case 'new':
                    txtSql.setValue('CREATE PROCEDURE <Procedure_Name, sysname, ProcedureName>\n' +
'	<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>,\n' +
'	<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>\n' +
'AS\n' +
'BEGIN\n' +
'    -- SET NOCOUNT ON added to prevent extra result sets from\n' +
'    -- interfering with SELECT statements.\n' +
'    SET NOCOUNT ON;\n' +
'\n' +
'    -- Insert statements for procedure here\n' +
'    SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>\n' +
'END');
                    break;
                case 'edit':
                    if (grdProcList.selModel.getSelected() == undefined) {
                        Ext.Msg.alert('Thông báo', 'Bạn chưa chọn thủ tục nào!');
                        return;
                    }

                    stt.showBusy();
                    Ext.net.DirectMethods.generateProcDefine(grdProcList.selModel.getSelected().id, {
                        success: function (result) {
                            txtSql.setValue(result);
                        },
                        complete: function () {
                            stt.clearStatus();
                        }
                    });
                    break;
                case 'exec':
                    if (grdProcList.selModel.getSelected() == undefined) {
                        Ext.Msg.alert('Thông báo', 'Bạn chưa chọn thủ tục nào!');
                        return;
                    }

                    stt.showBusy();
                    Ext.net.DirectMethods.generateProcExec(grdProcList.selModel.getSelected().id, {
                        success: function (result) {
                            txtSql.setValue(result);
                        },
                        complete: function () {
                            stt.clearStatus();
                        }
                    });
                    break;
                case 'rename':
                    if (grdProcList.selModel.getSelected() == undefined) {
                        Ext.Msg.alert('Thông báo', 'Bạn chưa chọn thủ tục nào!');
                        return;
                    }

                    grdProcList.startEditing(grdProcList.store.indexOf(grdProcList.selModel.getSelected()), 0)
                    break;
                case 'delete':
                    if (grdProcList.selModel.getSelected() == undefined) {
                        Ext.Msg.alert('Thông báo', 'Bạn chưa chọn thủ tục nào!');
                        return;
                    }

                    txtSql.setValue('DROP PROC ' + grdProcList.selModel.getSelected().id);
                    break;
            }
        }

        function txtSql_KeyDown(sender, e, opts) {
            if (e.getKey() == e.F8) {
                btnExecute.fireEvent('click');
            }
        }

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
        
        
        <ext:Menu ID="cm_grdProcList" runat="server">
            <Items>
                <ext:MenuItem Text="Tạo mới thủ tục..." Icon="PageWhite" ItemID="new" />
                <ext:MenuItem Text="Chỉnh sửa" ItemID="edit" Icon="Pencil" />
                <ext:MenuItem Text="Thực hiện thủ tục..." ItemID="exec" Icon="PlayGreen" />
                <ext:MenuSeparator />
                <ext:MenuItem Text="Đổi tên" ItemID="rename" Icon="TextfieldRename" Visible="false" />
                <ext:MenuItem Text="Xóa bỏ" ItemID="delete" Icon="Delete" />
            </Items>
            <Listeners>
                <ItemClick Fn="cm_grdProcList_itemclick" />
            </Listeners>
        </ext:Menu>

        <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout" HideBorders="true" AutoScroll="true">
            <Items>

                <ext:Panel ID="Panel1" runat="server" Region="West" Width="220" Layout="FitLayout" Border="false" Title="Object Explorer" 
                    Split="true" Collapsible="true" Collapsed="true" ContextMenuID="cm_grdProcList">
                    <Tools>
                        <ext:Tool Type="Search" />
                        <ext:Tool Type="Refresh" Handler="#{grdProcList}.reload();" />
                    </Tools>
                    <Items>
                        <ext:GridPanel ID="grdProcList" runat="server" ColumnLines="true" AutoScroll="true" Border="false" AutoExpandColumn="name" HideHeaders="true">
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:Column Header="Procedure" DataIndex="name" Editable="false">
                                        <Editor>
                                            <ext:TextField ID="TextField1" runat="server" MaxLength="128" />
                                        </Editor>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <Store>
                                <ext:Store ID="stoProcName" runat="server" OnRefreshData="stoProcName_RefreshData" AutoSave="true"
                                    OnBeforeRecordUpdated="stoProcName_BeforeRecordUpdated">
                                    <Reader>
                                        <ext:JsonReader IDProperty="name">
                                            <Fields>
                                                <ext:RecordField Name="name" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>

                <ext:Panel ID="Panel2" runat="server" Region="Center" Layout="BorderLayout" Border="false">
                    <TopBar>
                        <ext:Toolbar ID="toolbarGrid" runat="server">
                            <Items>
                                <ext:Button ID="btnExecute" Icon="PlayBlue" runat="server" Text="Thực hiện (F8)">
                                    <DirectEvents>
                                        <Click OnEvent="btnExecute_DirectClick" Before="stt.showBusy('Đang thực hiện lệnh...'); btnExecute.setDisabled(true);" Complete="btnExecute.setDisabled(false);">
                                            <ExtraParams>
                                                <ext:Parameter Name="sql" Value="txtSql.getSelectedText()" Mode="Raw" />
                                            </ExtraParams>
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>

                    <Items>
                        
                        <ext:Panel ID="Panel3" runat="server" Region="Center" Layout="FitLayout" Border="false" Split="true" BodyBorder="false">
                            <Items>
                                <ext:TextArea ID="txtSql" runat="server" EnableKeyEvents="true">
                                    <Listeners>
                                        <KeyDown Fn="txtSql_KeyDown" />
                                    </Listeners>
                                </ext:TextArea>
                            </Items>
                        </ext:Panel>

                         
                        <ext:Panel ID="Panel4" runat="server" Region="South" Height="150" Layout="FitLayout" Border="false" Split="true">
                            <Items>
                                <ext:TabPanel ID="tabResult" runat="server" Border="false">
                                    <Items>
                                        <ext:Panel ID="Panel5" runat="server" Title="Kết quả" Icon="Table" Layout="FitLayout" Border="false" BodyBorder="false">
                                            <Items>
                                                <ext:GridPanel ID="grd_sqlResult" runat="server" AutoScroll="true" Border="false">
                                                    <Store>
                                                        <ext:Store ID="sto_sqlResult" runat="server">
                                                            <Reader>
                                                                <ext:JsonReader />
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                </ext:GridPanel>
                                            </Items>
                                        </ext:Panel>
                                        <ext:Panel ID="Panel6" runat="server" Title="Thông điệp" Icon="Comment" Layout="FitLayout" Border="false" BodyBorder="false">
                                            <Items>
                                                <ext:TextArea ID="txt_sqlMessage" runat="server" ReadOnly="true"></ext:TextArea>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:TabPanel>
                            </Items>
                        </ext:Panel>

                    </Items>

                    <BottomBar>
                        <ext:StatusBar ID="stt" runat="server">
                            <Items>
                                <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                                <ext:ToolbarTextItem ID="stt_lblRowAffect" runat="server" Text="0 dòng" />
                                <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                                <ext:ToolbarTextItem ID="stt_lblUser" runat="server" Text="Admin" />
                                <ext:ToolbarSeparator ID="ToolbarSeparator3" runat="server" />
                                <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="kyson_db" />
                            </Items>
                        </ext:StatusBar>
                    </BottomBar>
                </ext:Panel>
                
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
