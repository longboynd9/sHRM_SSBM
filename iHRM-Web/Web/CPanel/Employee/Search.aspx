<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Employee.Search" %>

<%@ Register Src="../UC/ImageUploader.ascx" TagName="ImageUploader" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <script type="text/javascript">

        function OpenEditor(id, title) {
            parent.CreateWin('Employee_Editor', "/Cpanel/Employee/Editor.aspx" + (id == '' ? '' : ('?id=' + id)), title, 800, 500);
        }
        function grd_cmd(cmdName, record, rowIdx, colIdx) {
            if (cmdName == 'Edit') {
                OpenEditor(record.id, '#Employee_Search.msg_js' + record.json.EmployeeName);
            }
            else if (cmdName == 'Delete') {
                //Ext.Msg.show({
                //    icon: Ext.MessageBox.QUESTION,
                //    msg: 'Bạn chắc chắn muốn xóa?',
                //    buttons: Ext.Msg.OKCANCEL
                //});
                return confirm("");
            }
        }

        var template = '<span>{0}</span>';
        var convertSex = function (value) {

            if (value == 0) {
                return String.format(template, "Nữ");
            }
            if (value == 1) {
                return String.format(template, "Nam");
            }
        };
        var getTasks = function (tree) {
            var msg = [],
                selNodes = tree.getChecked();
            msg.push("[");

            Ext.each(selNodes, function (node) {
                if (msg.length > 1) {
                    msg.push(",");
                }

                msg.push(node.text);
            });
            msg.push("]");

            return msg.join("");
        };
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
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />

            <ext:Store ID="Store1" runat="server" AutoLoad="true" RemotePaging="true" OnRefreshData="Store1_RefreshData" OnSubmitData="sto1_SubmitData">
                <Proxy>
                    <ext:PageProxy />
                </Proxy>
                <DirectEventConfig IsUpload="true" />
                <Reader>
                    <ext:JsonReader IDProperty="EmployeeID">
                        <Fields>
                            <ext:RecordField Name="EmployeeID" />
                            <ext:RecordField Name="EmployeeCode" />
                            <ext:RecordField Name="EmployeeName" />
                            <ext:RecordField Name="AppliedDate" />
                            <ext:RecordField Name="EmpTypeName" />
                            <ext:RecordField Name="DepName" />
                            <ext:RecordField Name="PosName" />
                            <ext:RecordField Name="Birthday" />
                            <ext:RecordField Name="SexID" />
                            <ext:RecordField Name="Phone" />
                            <ext:RecordField Name="IDCard" />
                            <ext:RecordField Name="Address" />
                            <ext:RecordField Name="NativeCountry" />
                            <ext:RecordField Name="leftdate" />
                            <ext:RecordField Name="FirstName" />
                            <ext:RecordField Name="LastName" />
                            <ext:RecordField Name="gName" />
                            <ext:RecordField Name="IssueDate" />
                            <ext:RecordField Name="PermanentAddress" />
                            <ext:RecordField Name="NativeCountry" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
                <AutoLoadParams>
                    <ext:Parameter Name="start" Value="0" Mode="Raw" />
                    <ext:Parameter Name="limit" Value="100" Mode="Raw" />
                </AutoLoadParams>
            </ext:Store>
            <ext:Hidden runat="server" ID="hdhidde"></ext:Hidden>
            <ext:Viewport ID="Viewport1" runat="server" Layout="BorderLayout" HideBorders="true" AutoScroll="true">
                <Items>
                    <ext:Panel runat="server" Region="West" Border="false" Collapsible="true" Split="true" Width="170" Layout="FormLayout" Padding="10">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ToolbarFill runat="server" />
                                    <ext:Button ID="btnSearch" runat="server" Icon="ArrowRefreshSmall" Text="#common_btn.Find">
                                        <Listeners>
                                            <Click Handler="Store1.reload()" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>
                            <ext:TextField ID="txtSearchKey" runat="server" Note="#common_btn.lbTuKhoa" NoteAlign="Top" HideLabel="true" AnchorHorizontal="100%">
                                <Listeners>
                                    <Blur Handler="Store1.reload()" />
                                </Listeners>
                            </ext:TextField>
                            <ext:DropDownField EmptyText="#Employee_Search.chonPB" ID="cbophong" runat="server" Editable="false" Width="300" TriggerIcon="SimpleArrowDown" HideLabel="true" AnchorHorizontal="100%" NoteAlign="Top">
                                <Component>
                                    <ext:TreePanel
                                        ID="TreeFunc"
                                        runat="server"
                                        Title="#Employee_Search.dsPB"
                                        Icon="Accept"
                                        Height="300"
                                        Shadow="None"
                                        UseArrows="true"
                                        AutoScroll="true"
                                        Animate="true"
                                        EnableDD="true"
                                        ContainerScroll="true"
                                        RootVisible="false">
                                        <SelectionModel>
                                            <ext:DefaultSelectionModel />
                                        </SelectionModel>
                                        <LoadMask ShowMask="true" />
                                        <DirectEvents>
                                            <DblClick OnEvent="btnEdit_DirectClick" />
                                        </DirectEvents>

                                    </ext:TreePanel>
                                </Component>
                                <Listeners>
                                    <Expand Handler="this.component.getRootNode().expand(true);" Single="true" Delay="10" />
                                </Listeners>
                            </ext:DropDownField>
                        </Items>
                    </ext:Panel>

                    <ext:GridPanel ID="GridPanel1" runat="server" Border="false" StoreID="Store1" Region="Center">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>

                                    <ext:Button runat="server" Text="#Employee_Search.themmoiNV" Icon="Add">
                                        <Listeners>
                                            <Click Handler="OpenEditor('', '#Employee_Search.taomoiNV')" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <%--<ext:ToolbarFill runat="server" />--%>
                                    <ext:Button runat="server" Text="Export" Icon="PageExcel">
                                        <Listeners>
                                            <Click Handler="#{Store1}.submitData();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:ToolbarSeparator />
                                    <ext:Button runat="server" Text="Export All" Icon="PageExcel">
                                        <DirectEvents>
                                            <Click OnEvent="SearchNhanVien" IsUpload="true" Timeout="120000">
                                                <EventMask ShowMask="false" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="#Employee_Search.maNV" DataIndex="EmployeeID" Width="65" />
                               <%-- <ext:Column Header="FirstName" DataIndex="FirstName" Width="125" />
                                <ext:Column Header="LastName" DataIndex="LastName" Width="125" />--%>
                                <ext:Column Header="#Employee_Search.hoten" DataIndex="EmployeeName" Width="125" />
                                <ext:DateColumn Header="#Employee_Search.ngaysinh" DataIndex="Birthday" Format="dd/MM/yyyy" Width="65" />
                                <ext:Column Header="#Employee_Search.gioitinh" DataIndex="SexID" Width="65" />
                                <%--  <ext:Column Header="Giới tính" DataIndex="SexID"  Width="65" >
                                      <Renderer Fn="convertSex"></Renderer>
                                 </ext:Column>--%>
                                <ext:Column Header="#Employee_Search.sdt" DataIndex="Phone" Width="65" />
                                <ext:Column Header="Địa chỉ" DataIndex="Address" />
                                <ext:Column Header="#Employee_Search.quequan" DataIndex="NativeCountry" />
                                <ext:Column Header="Hộ khẩu thường trú" DataIndex="PermanentAddress" />
                                <ext:Column Header="#Employee_Search.cmnd" DataIndex="IDCard" Width="70" />
                                <ext:DateColumn Header="#Employee_Search.ngayvao" DataIndex="AppliedDate" Format="dd/MM/yyyy" Width="65" />
                                <%--<ext:Column Header="Loại NV" DataIndex="EmpTypeName" />--%>
                                <ext:Column Header="#Employee_Search.bophan" DataIndex="DepName" />
                                <ext:Column Header="#Employee_Search.vitri" DataIndex="PosName" />
                                <ext:Column Header="Nhóm" DataIndex="gName" />
                                <ext:DateColumn Header="Ngày nghỉ" DataIndex="leftdate" Format="dd/MM/yyyy"/>
                                <ext:ImageCommandColumn Width="60" Align="Center" Header="#">
                                    <Commands>
                                        <ext:ImageCommand CommandName="Edit" Icon="BulletEdit" Style="margin-left: 7px !important;" />
                                        <ext:ImageCommand CommandName="Delete" Icon="Delete" Style="margin-left: 7px !important;" />
                                    </Commands>
                                </ext:ImageCommandColumn>
                            </Columns>
                        </ColumnModel>

                        <SelectionModel>
                            <ext:RowSelectionModel runat="server" SingleSelect="true" />
                        </SelectionModel>

                        <Listeners>
                            <Command Fn="grd_cmd" />
                        </Listeners>

                        <DirectEvents>
                            <Command OnEvent="grd_OnCommand">
                                <ExtraParams>
                                    <ext:Parameter Name="id" Value="record.id" Mode="Raw" />
                                    <ext:Parameter Name="command" Value="command" Mode="Raw" />
                                </ExtraParams>
                            </Command>
                        </DirectEvents>
                        <DirectEvents>
                            <RowDblClick OnEvent="SwitchToUserDetail">
                                <ExtraParams>
                                    <ext:Parameter Name="id" Value="this.selModel.getSelected().id" Mode="Raw">
                                    </ext:Parameter>
                                </ExtraParams>
                            </RowDblClick>
                        </DirectEvents>
                        <BottomBar>
                            <ext:PagingToolbar ID="pgToolbar" StoreID="Store1"
                                runat="server"
                                PageSize="100"
                                DisplayInfo="true"
                                FirstText="#common_btn.Pagging_FirstText"
                                PrevText="#common_btn.Pagging_PrevText"
                                NextText="#common_btn.Pagging_NextText"
                                LastText="#common_btn.Pagging_LastText"
                                RefreshText="#common_btn.Pagging_RefreshText"
                                HideRefresh="true"
                                DisplayMsg="#common_btn.Pagging_DisplayMsg"
                                EmptyMsg="#common_btn.Pagging_EmptyMsg">
                                <Items>
                                    <ext:Label ID="Label2" runat="server" Text="#common_btn.Pagging_PageSize" />
                                    <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                    <ext:ComboBox runat="server" Width="80" Editable="false">
                                        <Items>
                                            <ext:ListItem Text="10" />
                                            <ext:ListItem Text="50" />
                                            <ext:ListItem Text="100" />
                                            <ext:ListItem Text="500" />
                                        </Items>
                                        <SelectedItem Value="100" />
                                        <Listeners>
                                            <Select Handler="#{pgToolbar}.pageSize = parseInt(this.getValue()); #{pgToolbar}.doLoad();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:PagingToolbar>
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
            </ext:Viewport>
        </div>

    </form>
</body>
</html>
