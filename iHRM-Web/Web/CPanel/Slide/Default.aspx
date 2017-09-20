<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Slide.Default" %>

<%@ Register src="~/Cpanel/UC/ImageUploader.ascx" tagname="ImageUploader" tagprefix="uc1" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    
    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />

    <style type="text/css">
        .imgAvatar { max-width:150px; vertical-align:middle; }
        .p10 { padding: 10px; }
        .pl10 { padding-left:10px; }
    </style>
    
    <script type="text/javascript">
        function Store1_UpdateRecord(id, record) {
            record = JSON.parse(record);
            var r = Store1.getById(id);
            if (r == undefined) {
                alert("Can't find record [" + id + "]");
                return;
            }

            r.set('caption', record.caption);
            r.set('avata', record.avata);
            r.set('nOrder', record.nOrder);
            r.set('link', record.link);

            Store1.commitChanges();
        }

        function grp_category(value) {
            var x = stoCategory.getById(value);
            return x == undefined ? "-" : x.get("catName");
        }

        function txtWE_speckey(sender, e) {
            if (e.getKey() == e.ENTER) {
                btnOk.fireEvent('click');
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <ext:Store ID="stoCategory" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="category">
                    <Fields>
                        <ext:RecordField Name="category" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>

        <ext:Store ID="Store1" runat="server" OnRefreshData="Store1_OnRefresh">
            <Reader>
                <ext:JsonReader IDProperty="id">
                    <Fields>
                        <ext:RecordField Name="id" />
                        <ext:RecordField Name="title" />
                        <ext:RecordField Name="link" />
                        <ext:RecordField Name="image" />
                        <ext:RecordField Name="category" />
                        <ext:RecordField Name="displayOrder" Type="Int" />
                        <ext:RecordField Name="status" Type="Int" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        
        <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
            <Items>
                
                <%-- Danh sách --%>
                <ext:GridPanel ID="grp" runat="server" Icon="User" StripeRows="true" ColumnLines="true" TrackMouseOver="true" StoreID="Store1" AutoExpandColumn="title">
                    <TopBar>
                        <ext:Toolbar ID="toolbarGrid" runat="server">
                            <Items>
                                <ext:Button ID="btnAdd" Icon="Add" runat="server" Text="Thêm" OnDirectClick="btnAdd_DirectClick" />
                                <ext:ToolbarSpacer Width="20" />
                                <ext:TriggerField ID="txtSearch" runat="server" MinChars="1" Width="200" EmptyText="Tìm kiếm theo tên quảng cáo">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Change Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.setValue(''); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:TriggerField>
                                <ext:ComboBox runat="server" ID="cboFilterCategory" FieldLabel="Vị trí" Editable="false" LabelWidth="35"
                                    StoreID="stoCategory" DisplayField="category" ValueField="category">
                                </ext:ComboBox>
                                <ext:Button ID="btnSearch" ClientIDMode="Static" Icon="Zoom" runat="server" Text="Tìm kiếm" OnDirectClick="btnSearch_DirectClick" />
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="40" />
                            <ext:TemplateColumn Header="" Width="150">
                                <Template ID="Template1" runat="server">
                                    <Html>
                                        <img class="imgAvatar" src="/Images/Upload{image}" />
                                    </Html>
                                </Template>
                            </ext:TemplateColumn>

                            <ext:Column Header="Tiêu đề" DataIndex="title" />
                            <ext:Column Header="link" DataIndex="link" />
                            <ext:Column Header="category" DataIndex="category" />
                            <ext:Column Header="Sắp xếp" DataIndex="stt">
                                <Editor>
                                    <ext:NumberField ID="NumberField1" runat="server" AllowDecimals="false" />
                                </Editor>
                            </ext:Column>
                            <ext:Column Header="Trạng thái" DataIndex="status" />

                            <ext:ImageCommandColumn Width="60" Align="Center" Header="#">
                                <Commands>
                                    <ext:ImageCommand CommandName="Edit" Icon="BulletEdit" Style="margin-left:7px !important;" />
                                    <ext:ImageCommand CommandName="Delete" Icon="Delete" Style="margin-left:7px !important;" />
                                </Commands>
                            </ext:ImageCommandColumn>
                        </Columns>
                    </ColumnModel>

                    <DirectEvents>
                        <Command OnEvent="OnCommand">
                            <EventMask ShowMask="true"></EventMask>
                            <Confirmation BeforeConfirm="if(!(command == 'Delete')) return false;" ConfirmRequest="true"
                                Message="Bạn chắc chắn muốn xóa?" Title="Xác nhận xóa" />
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="record.id" Mode="Raw" />
                                <ext:Parameter Name="command" Value="command" Mode="Raw" />
                            </ExtraParams>
                        </Command>
                        <RowDblClick OnEvent="OnDblClick" >
                            <ExtraParams>
                                <ext:Parameter Name="id" Value="this.selModel.getSelected().id" Mode="Raw" />
                            </ExtraParams>
                        </RowDblClick>
                    </DirectEvents>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" />
                    </SelectionModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="pgToolbar"
                            runat="server"
                            PageSize="20"
                            DisplayInfo="true"
                            FirstText="Trang đầu"
                            PrevText="Trang trước"
                            NextText="Trang sau"
                            LastText="Trang cuối"
                            RefreshText="Nạp lại"
                            HideRefresh="true"
                            DisplayMsg="Hiển thị {0} - {1} / {2}"
                            EmptyMsg="Không có bản ghi nào để hiển thị">
                            <Items>
                                <ext:Label ID="Label1" runat="server" Text="Kích thước trang:" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox1" runat="server" Width="80" Editable="false">
                                    <Items>
                                        <ext:ListItem Text="10" />
                                        <ext:ListItem Text="20" />
                                        <ext:ListItem Text="50" />
                                        <ext:ListItem Text="100" />
                                    </Items>
                                    <SelectedItem Value="20" />
                                    <Listeners>
                                        <Select Handler="#{pgToolbar}.pageSize = parseInt(this.getValue()); #{pgToolbar}.doLoad();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:PagingToolbar>
                    </BottomBar>
                    <LoadMask ShowMask="true" />
                </ext:GridPanel>
                
            </Items>
        </ext:Viewport>
        
        <ext:Window ID="wEditor" runat="server"
            Title="Slide Editor"
            Icon="Add"
            Height="320"
            Width="600"
            ButtonAlign="Left"
            Hidden="true"
            Modal="true">
            <Items>
                <ext:Panel ID="Panel2" runat="server" ButtonAlign="Right" Height="280" AutoWidth="true" Border="false" AutoScroll="true">
                    <Content>

                        <table width="100%" cellpadding="5px">
                            <tr>
                                <td class="c1">
                                    <uc1:ImageUploader ID="ImageUploader1" runat="server" />
                                </td>
                                <td class="spacedoc"></td>
                                <td class="c2">
                                    <ext:Hidden ID="hId" runat="server" />

                                    <ext:FormPanel ID="formCT" runat="server" Border="false">
                                        <Items>
                                            <ext:TextField Width="280" ID="txtcaption" DataIndex="ten" runat="server" FieldLabel="Tên <span class='red'>*</span>" MaxLength="255" AllowBlank="false" MaskRe="[^<>&amp;*]">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:TextField Width="280" ID="txtcaption_EN" DataIndex="ten" runat="server" FieldLabel="Tên EN" MaxLength="255" MaskRe="[^<>&amp;*]">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:TextField Width="280" ID="txtcaption_KR" DataIndex="ten" runat="server" FieldLabel="Tên KR" MaxLength="255" MaskRe="[^<>&amp;*]">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:TextArea Width="280" ID="txtghichu" DataIndex="ghichu" runat="server" FieldLabel="Ghi chú" MaxLength="1000" MaskRe="[^<>&amp;*]" Height="45">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TextArea>
                                            <ext:TextArea Width="280" ID="txtghichu_EN" DataIndex="ghichu" runat="server" FieldLabel="Ghi chú EN" MaxLength="1000" MaskRe="[^<>&amp;*]" Height="45">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TextArea>
                                            <ext:TextArea Width="280" ID="txtghichu_KR" DataIndex="ghichu" runat="server" FieldLabel="Ghi chú KR" MaxLength="1000" MaskRe="[^<>&amp;*]" Height="45">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TextArea>
                                            <ext:TextField Width="280" ID="txtlink" DataIndex="LienKet" runat="server" FieldLabel="Liên kết" MaxLength="1000" >
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:NumberField Width="280" ID="txtOrder" runat="server" FieldLabel="Thứ tự">
                                                <Listeners>
                                                    <SpecialKey Fn="txtWE_speckey" />
                                                </Listeners>
                                            </ext:NumberField>
                                            <ext:ComboBox runat="server" ID="cbovitri" FieldLabel="Vị trí" Editable="false"
                                                StoreID="stoCategory" DisplayField="category" ValueField="category">
                                            </ext:ComboBox>
                                            <ext:ComboBox runat="server" ID="cbostatus" FieldLabel="Trạng thái" Editable="false"></ext:ComboBox>
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
                        <ext:Button ID="btnClear" runat="server" Text="Xóa trắng" Icon="PageWhite">
                            <Listeners>
                                <Click Handler="#{formCT}.getForm().reset();
                                    #{txtMoTaNgan}.reset();
                                    " />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="Button2" runat="server" Text="Đóng" Icon="Cancel">
                            <Listeners>
                                <Click Handler="#{wEditor}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Panel>
            </Items>
        </ext:Window>

    </div>
        
    </form>
</body>
</html>
