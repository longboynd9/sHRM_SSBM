<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editor.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Employee.Editor" %>

<%@ Register Src="~/Cpanel/UC/ImageUploader.ascx" TagName="ImageUploader" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="/Cpanel/Skins/Js/jquery-1.9.0.js"></script>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <style>
        .x-table-layout {
            width: 100% !important;
        }

        .col1 {
            width: 40% !important;
        }

        .col3 {
            width: 40% !important;
        }

        .col2 {
            width: 1% !important;
        }
    </style>


    <style type="text/css">
        .lbl1 {
            text-align: right;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript">

            function EmpTypeName_Rend(value) { var x = stoEmpType.getById(value); return x == undefined ? "-" : x.get("EmpTypeName"); }
            function EmpDepName_Rend(value) { var x = stoEmpDep.getById(value); return x == undefined ? "-" : x.get("DepName"); }
            //function EmpTitleName_Rend(value) { var x = stoTitle.getById(value); return x == undefined ? "-" : x.get("TitleName"); }
            function EmpPosName_Rend(value) { var x = stoPostion.getById(value); return x == undefined ? "-" : x.get("PosName"); }
            function EmpAllowanceName_Rend(value) { var x = stoAllowance.getById(value); return x == undefined ? "-" : x.get("AllowanceName"); }
            function EmpContractTypeName_Rend(value) { var x = stoContractType.getById(value); return x == undefined ? "-" : x.get("ContractTypeName"); }
            function ResetImg() {
                jQuery('#txtFileImage').value = null;
                document.getElementById('txtFileImage').value = null;
                jQuery('#imgProfile').attr('src', "");
                //jQuery('#txtFileImage').val() = "";'

            }
            function readURL(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) { jQuery('#imgProfile').attr('src', e.target.result); }, reader.readAsDataURL(input.files[0]);
                    var link = document.getElementById('<%=txtFileImage.ClientID%>').value;
                    jQuery('#txtimage').val(link);

                }
            }
            function validate() {
                var uploadcontrol = document.getElementById('<%=txtFileImage.ClientID%>').value;
                //Regular Expression for fileupload control.
                var reg = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpeg|.JPEG|.gif|.GIF| .png|.PNG)$/;
                if (uploadcontrol.length > 0) {
                    //Checks with the control value.
                    if (reg.test(uploadcontrol)) {
                        return true;
                    }
                    else {
                        //If the condition not satisfied shows error message.
                        alert("Only .doc, docx files are allowed!");
                        return false;
                    }
                }
            }
        </script>
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />

            <ext:Hidden ID="hId" runat="server" />

            <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
                <Items>

                    <ext:TabPanel runat="server" ID="tab1">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:ToolbarFill runat="server" />

                                    <ext:Button ID="btnOk" Icon="Disk" runat="server" Text="#Employee_Editor.save">
                                        <Listeners>
                                            <Click Handler="if (!#{frmTT}.getForm().isValid()){Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: '#Employee_Editor.msg_js2', buttons:Ext.Msg.OK}); return false;}" />
                                        </Listeners>
                                        <DirectEvents>
                                            <Click OnEvent="btnOk_DirectClick">
                                                <EventMask ShowMask="true" Target="Page" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:ToolbarSpacer Width="10" />

                                    <ext:Button runat="server" Icon="Outline" Text="#Employee_Editor.dong">
                                        <Listeners>
                                            <Click Handler="if (parent.w__Employee_Editor != null) parent.w__Employee_Editor.close(); if (parent.w__w__f190 != null) parent.w__w__f190.close();" />
                                        </Listeners>
                                    </ext:Button>

                                </Items>
                            </ext:Toolbar>
                        </TopBar>

                        <Items>

                            <ext:FormPanel ID="frmTT" runat="server" Border="false" Layout="FormLayout" Padding="10" Title="#Employee_Editor.title_thongtinchung" AutoScroll="true" LabelWidth="150">
                                <Items>

                                    <ext:Panel
                                        ID="pnlTableLayout"
                                        runat="server"
                                        Hidden="false"
                                        AutoWidth="true"
                                        Border="false"
                                        Padding="0">
                                        <Items>
                                            <ext:TableLayout runat="server" Columns="5" Cls=".tableimage">
                                                <Cells>
                                                    <ext:Cell ColSpan="2" CellCls="col1">
                                                        <ext:Panel
                                                            ID="Panel1"
                                                            runat="server" Border="false"
                                                            Header="false">
                                                            <Items>
                                                                <ext:TextField LabelWidth="80" Width="250" ID="txtCode" DataIndex="EmployeeCode" runat="server" FieldLabel="#Employee_Editor.maNV" MaxLength="15" MaskRe="[^<>&amp;*]"
                                                                    AllowBlank="false" IsRemoteValidation="true">
                                                                    <RemoteValidation OnValidation="EmployeeCode_Validation" InitValueValidation="Valid" />
                                                                </ext:TextField>

                                                                <ext:TextField Flex="1" LabelWidth="80" Width="250" runat="server" DataIndex="OldEmployeeID" FieldLabel="#Employee_Editor.maNVcu" />
                                                                <ext:TextField Flex="1" LabelWidth="80" Width="250" DataIndex="FirstName" runat="server" FieldLabel="#Employee_Editor.ho" MaxLength="20" MaskRe="[^<>&amp;*]" AllowBlank="false" />

                                                                <ext:TextField Flex="1" Width="250" LabelWidth="80" FieldLabel="#Employee_Editor.ten" DataIndex="LastName" runat="server" MaxLength="40" MaskRe="[^<>&amp;*]" AllowBlank="false" />
                                                                <ext:TextField LabelWidth="80" Width="250" AnchorHorizontal="-20" DataIndex="EmployeeName" runat="server" FieldLabel="#Employee_Editor.hoten" MaxLength="60" MaskRe="[^<>&amp;*]" AllowBlank="false" />

                                                                <ext:ComboBox LabelWidth="80" Width="250" Flex="1" FieldLabel="#Employee_Editor.tinhtrangGD" DataIndex="MaritalStatusID" runat="server" Editable="false" DisplayField="MaritalStatusName" ValueField="MaritalStatusID">
                                                                    <Store>
                                                                        <ext:Store ID="stoMaritalStatus" runat="server">
                                                                            <Reader>
                                                                                <ext:JsonReader IDProperty="MaritalStatusID">
                                                                                    <Fields>
                                                                                        <ext:RecordField Name="MaritalStatusID" />
                                                                                        <ext:RecordField Name="MaritalStatusName" />
                                                                                    </Fields>
                                                                                </ext:JsonReader>
                                                                            </Reader>
                                                                        </ext:Store>
                                                                    </Store>
                                                                </ext:ComboBox>
                                                            </Items>
                                                        </ext:Panel>
                                                    </ext:Cell>
                                                    <ext:Cell ColSpan="2" CellCls="col3">
                                                        <ext:Panel
                                                            ID="Panel2"
                                                            runat="server" Border="false"
                                                            Header="false">
                                                            <Items>
                                                                <ext:ComboBox Flex="1" LabelWidth="80" Width="250" DataIndex="SexID" runat="server" FieldLabel="#Employee_Editor.gioitinh" Editable="false">
                                                                    <Items>
                                                                        <ext:ListItem Text="..Chọn.." Value="" />
                                                                        <ext:ListItem Text="Nam" Value="Nam" />
                                                                        <ext:ListItem Text="Nữ" Value="Nữ" />
                                                                    </Items>
                                                                </ext:ComboBox>

                                                                <ext:TriggerField Flex="1" LabelWidth="80" Width="250" FieldLabel="#Employee_Editor.cardID" DataIndex="CardID" runat="server" MaxLength="14" MaskRe="[^<>&amp;*]">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Ellipsis" Qtip="Click to choose value" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <TriggerClick Fn="" />
                                                                    </Listeners>
                                                                </ext:TriggerField>
                                                                <ext:DateField Flex="1" LabelWidth="80" Width="250" DataIndex="AppliedDate" runat="server" FieldLabel="#Employee_Editor.ngayvaolam" Format="dd/MM/yyyy" />

                                                                <ext:ComboBox Flex="1" LabelWidth="80" FieldLabel="#Employee_Editor.tinhtrang" Width="250" DataIndex="StatusID" runat="server" Editable="false" DisplayField="StatusName" ValueField="StatusID">
                                                                    <Store>
                                                                        <ext:Store ID="stoEmpStatus" runat="server">
                                                                            <Reader>
                                                                                <ext:JsonReader IDProperty="StatusID">
                                                                                    <Fields>
                                                                                        <ext:RecordField Name="StatusID" />
                                                                                        <ext:RecordField Name="StatusName" />
                                                                                    </Fields>
                                                                                </ext:JsonReader>
                                                                            </Reader>
                                                                        </ext:Store>
                                                                    </Store>
                                                                </ext:ComboBox>
                                                                <ext:DateField Flex="1" LabelWidth="80" Width="250" DataIndex="Birthday" runat="server" FieldLabel="#Employee_Editor.ngaysinh" Format="dd/MM/yyyy" />
                                                                <ext:TextField LabelWidth="80" Width="250" AnchorHorizontal="-20" DataIndex="Phone" runat="server" FieldLabel="#Employee_Editor.dienthoai" MaxLength="50" MaskRe="[^<>&amp;*]" />
                                                            </Items>
                                                        </ext:Panel>
                                                    </ext:Cell>
                                                    <ext:Cell ColSpan="1" CellCls="col2">
                                                        <ext:Panel
                                                            ID="Panel5"
                                                            runat="server"
                                                            Header="false"
                                                            Padding="5" Width="113">
                                                            <Content>
                                                                <div class="imgLogo">
                                                                    <ext:Image runat="server" Width="100" Height="100" ID="imgProfile" ClientIDMode="Static" DataIndex="LinkImage" />
                                                                </div>
                                                                <div class="fileup">
                                                                    <div style="width: 70px; background-repeat: no-repeat; background-image: url('<%=ResolveUrl("~/Images/chonfile.png") %>'); cursor: pointer; border: none;">
                                                                        <input style="opacity: 0.0; cursor: pointer" runat="server" class="upload" clientidmode="Static"
                                                                            id="txtFileImage" type="file" onchange="readURL(this);" width="40px" size="1" />
                                                                    </div>
                                                                </div>
                                                                <ext:Hidden ID="txtimage" runat="server"></ext:Hidden>
                                                            </Content>
                                                        </ext:Panel>
                                                    </ext:Cell>
                                                </Cells>
                                            </ext:TableLayout>
                                        </Items>
                                    </ext:Panel>
                                    <ext:Panel AnchorHorizontal="-20" runat="server" AutoHeight="true" FormGroup="true" Title="#Employee_Editor.title_cmnd" Layout="FormLayout">
                                        <Items>
                                            <ext:CompositeField AnchorHorizontal="100%" runat="server">
                                                <Items>
                                                    <ext:TextField Flex="1" DataIndex="IDCard" runat="server" FieldLabel="#Employee_Editor.cmnd" MaxLength="20" MaskRe="[^<>&amp;*]"  IsRemoteValidation="true">
                                                         <RemoteValidation OnValidation="CheckField" />
                                                    </ext:TextField>
                                                    <ext:Label runat="server" Width="100" Text="#Employee_Editor.ngaycap" Cls="lbl1" />
                                                    <ext:DateField Flex="1" DataIndex="IssueDate" runat="server" FieldLabel="" Format="dd/MM/yyyy" />
                                                </Items>
                                            </ext:CompositeField>
                                            <ext:TextField AnchorHorizontal="100%" DataIndex="IssuePlace" runat="server" FieldLabel="#Employee_Editor.noicap" MaxLength="20" MaskRe="[^<>&amp;*]" />
                                        </Items>
                                    </ext:Panel>
                                    <ext:TextField AnchorHorizontal="-20" DataIndex="Address" runat="server" FieldLabel="#Employee_Editor.diachi" MaxLength="150" MaskRe="[^<>&amp;*]" />
                                    <ext:TextField AnchorHorizontal="-20" DataIndex="NativeCountry" runat="server" FieldLabel="Quê quán" MaxLength="150" MaskRe="[^<>&amp;*]" />
                                    <ext:TextField AnchorHorizontal="-20" DataIndex="PermanentAddress" runat="server" FieldLabel="Địa chỉ thường trú" MaxLength="150" MaskRe="[^<>&amp;*]" />
                                    <ext:CompositeField runat="server" AnchorHorizontal="-20">
                                        <Items>
                                            <ext:Checkbox DataIndex="TradeUnionMember" runat="server" FieldLabel="#Employee_Editor.ngay_tgCD" />
                                            <ext:DateField Flex="1" DataIndex="TradeUnionDate" runat="server" Format="dd/MM/yyyy" />
                                            <ext:Label runat="server" Width="100" Text="#Employee_Editor.phi_CD" Cls="lbl1" />
                                            <ext:NumberField runat="server" DataIndex="TradeUnionFee" Mask="0.00" />
                                        </Items>
                                    </ext:CompositeField>

                                    <ext:CompositeField AnchorHorizontal="-20" runat="server">
                                        <Items>
                                            <ext:TextField Flex="1" DataIndex="BankAccount" runat="server" FieldLabel="#Employee_Editor.soTK" />
                                            <ext:Label runat="server" Width="100" Text="Tại ngân hàng" Cls="lbl114" />
                                            <ext:ComboBox Flex="1" runat="server" FieldLabel="" Editable="false" DataIndex="BankName" DisplayField="BankName" ValueField="BankID">
                                                <Store>
                                                    <ext:Store ID="Store1" runat="server">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="BankID">
                                                                <Fields>
                                                                    <ext:RecordField Name="BankID" />
                                                                    <ext:RecordField Name="BankName" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                            </ext:ComboBox>

                                            <ext:Label runat="server" Width="100" Text="Tên tài khoản" Cls="lbl114" />
                                            <ext:TextField runat="server" DataIndex="BankNameAcount"></ext:TextField>

                                        </Items>
                                    </ext:CompositeField>
                                     <ext:CompositeField AnchorHorizontal="-20" runat="server">
                                        <Items>
                                            <ext:Label runat="server"  Width="100"   Text="#Employee_Editor.ngaynopHS" Cls="lbl1" />
                                            <ext:DateField Flex="1" FieldLabel="" DataIndex="SubmitDate" runat="server" Format="dd/MM/yyyy" />
                                            <ext:Label runat="server"  Width="100"  Text="#Employee_Editor.ngaykyHD" Cls="lbl1" />
                                            <ext:DateField Flex="1" DataIndex="ContractDate" runat="server" Format="dd/MM/yyyy" />
                                        </Items>
                                    </ext:CompositeField>
                                    <ext:Checkbox runat="server" DataIndex="IsNotOT" FieldLabel="#Employee_Editor.KoTinhTangCa" LabelStyle="color:red" />

                                    <ext:CompositeField AnchorHorizontal="-20" runat="server">
                                        <Items>
                                            <ext:NumberField Flex="1" runat="server" DataIndex="BasicSalary" FieldLabel="#Employee_Editor.luongcoban">
                                            </ext:NumberField>
                                            <ext:Label runat="server" Width="100" Text="#Employee_Editor.phucapTX" Cls="lbl1" />
                                            <ext:NumberField Flex="1" runat="server" DataIndex="RegularAllowance">
                                            </ext:NumberField>
                                        </Items>
                                    </ext:CompositeField>

                                    <ext:CompositeField AnchorHorizontal="-20" runat="server">
                                        <Items>
                                            <ext:ComboBox Flex="1" runat="server" FieldLabel="Gộp nhóm 1" Editable="false" DataIndex="InGroup1" DisplayField="gName" ValueField="id">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <Select Handler="this.triggers[0].show();" />
                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                </Listeners>
                                                <Store>
                                                    <ext:Store ID="StoInGroup1" runat="server">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="id">
                                                                <Fields>
                                                                    <ext:RecordField Name="id" />
                                                                    <ext:RecordField Name="gName" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                            </ext:ComboBox>
                                            <ext:Label runat="server" Width="100" Text="Số ngày nghỉ phép năm" Cls="lbl1" />
                                            <ext:TextField Flex="1" runat="server" FieldLabel="" DataIndex="AnnualLeave"></ext:TextField>
                                        </Items>
                                    </ext:CompositeField>
                                </Items>

                                <Listeners>
                                    <ClientValidation Handler="#{btnOk}.setDisabled(!valid);" />
                                </Listeners>
                            </ext:FormPanel>

                            <ext:FormPanel ID="frmBH" runat="server" Border="false" Layout="FormLayout" Padding="10" Title="#Employee_Editor.bhld" AutoScroll="true">
                                <Items>

                                    <ext:Panel AnchorHorizontal="-20" runat="server" Height="250" FormGroup="true" Title="#Employee_Editor.bhxh" Layout="FormLayout" Collapsed="true">
                                        <Items>

                                            <ext:Panel runat="server" Layout="ColumnLayout" Height="110" AnchorHorizontal="100%" Border="false">
                                                <Items>

                                                    <ext:Panel runat="server" ColumnWidth="0.5" Layout="FormLayout" Border="false" Padding="10">
                                                        <Items>
                                                            <ext:Checkbox AnchorHorizontal="100%" DataIndex="SI" runat="server" FieldLabel="#Employee_Editor.chuyenden" />
                                                            <ext:TextField AnchorHorizontal="100%" DataIndex="SINo_Old" runat="server" FieldLabel="#Employee_Editor.soBHXHcu" MaxLength="20" MaskRe="[^<>&amp;*]" />
                                                            <ext:TextField AnchorHorizontal="100%" DataIndex="SINo" runat="server" FieldLabel="#Employee_Editor.sosoBH" MaxLength="20" MaskRe="[^<>&amp;*]" />
                                                            <ext:DateField AnchorHorizontal="100%" DataIndex="SIFrom_MY" runat="server" FieldLabel="#Employee_Editor.daudongBH" Format="dd/MM/yyyy" />

                                                        </Items>
                                                    </ext:Panel>

                                                    <ext:Panel runat="server" ColumnWidth="0.5" Layout="FormLayout" Border="false" Padding="10">
                                                        <Items>
                                                            <ext:Checkbox runat="server" AnchorHorizontal="100%" FieldLabel="#Employee_Editor.dacapsoBH" />
                                                            <ext:DateField AnchorHorizontal="100%" DataIndex="SIDate" runat="server" FieldLabel="#Employee_Editor.ngaycap" Format="dd/MM/yyyy" />
                                                            <ext:DateField AnchorHorizontal="100%" DataIndex="SINo_DateChange" runat="server" FieldLabel="#Employee_Editor.ngaydoi" Format="dd/MM/yyyy" />
                                                            <ext:TextField AnchorHorizontal="100%" DataIndex="SIPlace" runat="server" FieldLabel="#Employee_Editor.noicap" MaxLength="150" MaskRe="[^<>&amp;*]" />
                                                        </Items>
                                                    </ext:Panel>

                                                </Items>
                                            </ext:Panel>

                                            <ext:Panel runat="server" AnchorHorizontal="100%" Layout="FormLayout" Border="false" Padding="10">
                                                <Items>

                                                    <ext:Checkbox runat="server" DataIndex="ReserveSIBook" AnchorHorizontal="100%" FieldLabel="#Employee_Editor.chuyendi" />
                                                    <ext:DateField Width="100" DataIndex="SITo_MY" runat="server" FieldLabel="#Employee_Editor.ngaychuyen" Format="dd/MM/yyyy" />
                                                    <ext:TextField AnchorHorizontal="100%" DataIndex="TransferToPlace" runat="server" FieldLabel="#Employee_Editor.chuyenden" MaxLength="100" MaskRe="[^<>&amp;*]" />
                                                    <ext:TextField AnchorHorizontal="100%" DataIndex="Reason_Reserve" runat="server" FieldLabel="#Employee_Editor.lydo" MaxLength="100" MaskRe="[^<>&amp;*]" />

                                                </Items>
                                            </ext:Panel>

                                        </Items>
                                    </ext:Panel>

                                    <ext:Panel ID="frmBHYT" AnchorHorizontal="-20" runat="server" AutoHeight="true" FormGroup="true" Title="#Employee_Editor.title_BHYT" Layout="FormLayout" Padding="10" Collapsed="true">
                                        <Items>

                                            <ext:Checkbox runat="server" DataIndex="HI" AnchorHorizontal="100%" FieldLabel="#Employee_Editor.dadangky" />
                                            <ext:DateField Width="100" DataIndex="HIDate" runat="server" FieldLabel="#Employee_Editor.ngaycap" Format="dd/MM/yyyy" />
                                            <ext:TextField AnchorHorizontal="100%" DataIndex="HINo" runat="server" FieldLabel="#Employee_Editor.soso" MaxLength="20" MaskRe="[^<>&amp;*]" />
                                            <ext:DateField Width="100" DataIndex="HIFrom_MY" runat="server" FieldLabel="#Employee_Editor.batdau" Format="dd/MM/yyyy" />
                                            <ext:TextField AnchorHorizontal="100%" DataIndex="HIPlace" runat="server" FieldLabel="#Employee_Editor.noicap" MaxLength="150" MaskRe="[^<>&amp;*]" />


                                            <ext:GridPanel ID="grdKCB" runat="server" Title="#Employee_Editor.title_DangKyKCB" Height="170">
                                                <Store>
                                                    <ext:Store ID="stoKCB" runat="server" DataMember="tblEmpHIPlace">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="id">
                                                                <Fields>
                                                                    <ext:RecordField Name="id" Type="String" />
                                                                    <ext:RecordField Name="DateChange" Type="Date" />
                                                                    <ext:RecordField Name="HIPlace" />
                                                                    <ext:RecordField Name="Notes" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>

                                                <TopBar>
                                                    <ext:Toolbar runat="server">
                                                        <Items>

                                                            <ext:ToolbarFill runat="server" />

                                                            <ext:Button runat="server" Text="Refresh" Icon="ArrowRefresh">
                                                                <Listeners>
                                                                    <Click Handler="#{stoKCB}.reload();" />
                                                                </Listeners>
                                                            </ext:Button>

                                                            <ext:ToolbarSeparator runat="server" />
                                                            <ext:Button runat="server" Text="AddNew" Icon="Add">
                                                                <Listeners>
                                                                    <Click Handler="#{grdKCB}.insertRecord(0, null);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button runat="server" Text="Delete" Icon="Delete">
                                                                <Listeners>
                                                                    <Click Handler="#{grdKCB}.deleteSelected();" />
                                                                </Listeners>
                                                            </ext:Button>

                                                            <ext:ToolbarSeparator runat="server" />
                                                            <ext:Button runat="server" Text="Save" Icon="Disk">
                                                                <Listeners>
                                                                    <Click Handler="#{grdKCB}.save();" />
                                                                </Listeners>
                                                            </ext:Button>

                                                        </Items>
                                                    </ext:Toolbar>
                                                </TopBar>

                                                <ColumnModel>
                                                    <Columns>
                                                        <ext:RowNumbererColumn Header="STT" Width="35" />

                                                        <ext:DateColumn Header="#Employee_Editor.ngay" DataIndex="DateChange" Format="dd/MM/yyyy">
                                                            <Editor>
                                                                <ext:DateField runat="server" Format="dd/MM/yyyy" />
                                                            </Editor>
                                                        </ext:DateColumn>
                                                        <ext:Column Header="#Employee_Editor.noidangky" DataIndex="HIPlace">
                                                            <Editor>
                                                                <ext:ComboBox runat="server" DisplayField="HIPlace" ValueField="HIPlace">
                                                                    <Store>
                                                                        <ext:Store ID="stoHIPlace" runat="server">
                                                                            <Reader>
                                                                                <ext:JsonReader IDProperty="HIPlaceID">
                                                                                    <Fields>
                                                                                        <ext:RecordField Name="HIPlaceID" />
                                                                                        <ext:RecordField Name="HIPlace" />
                                                                                    </Fields>
                                                                                </ext:JsonReader>
                                                                            </Reader>
                                                                        </ext:Store>
                                                                    </Store>
                                                                </ext:ComboBox>
                                                            </Editor>
                                                        </ext:Column>
                                                        <ext:Column Header="#Employee_Editor.ghichu" DataIndex="Notes">
                                                            <Editor>
                                                                <ext:TextField runat="server" />
                                                            </Editor>
                                                        </ext:Column>

                                                        <ext:CommandColumn Width="40">
                                                            <Commands>
                                                                <ext:GridCommand Text="Reject" ToolTip-Text="Reject row changes" CommandName="reject" Icon="ArrowUndo" />
                                                            </Commands>
                                                            <PrepareToolbar Handler="toolbar.items.get(0).setVisible(record.dirty);" />
                                                        </ext:CommandColumn>
                                                    </Columns>
                                                </ColumnModel>
                                                <Listeners>
                                                    <Command Handler="record.reject();" />
                                                </Listeners>
                                                <View>
                                                    <ext:GridView runat="server" ForceFit="true" />
                                                </View>
                                                <LoadMask ShowMask="true" />
                                                <SelectionModel>
                                                    <ext:RowSelectionModel runat="server" SingleSelect="true" />
                                                </SelectionModel>

                                            </ext:GridPanel>

                                        </Items>
                                    </ext:Panel>

                                    <ext:Panel ID="frm" AnchorHorizontal="-20" runat="server" AutoHeight="true" FormGroup="true" Title="#Employee_Editor.title_SoLaoDong" Layout="FormLayout" Padding="10" Collapsed="true">
                                        <Items>
                                            <ext:Checkbox runat="server" DataIndex="Labor" AnchorHorizontal="100%" FieldLabel="#Employee_Editor.dadangky" />
                                            <ext:TextField AnchorHorizontal="100%" DataIndex="LaborNo" runat="server" FieldLabel="#Employee_Editor.soso" MaxLength="20" MaskRe="[^<>&amp;*]" />
                                            <ext:DateField Width="100" DataIndex="LaborDate" runat="server" FieldLabel="#Employee_Editor.ngaycap" Format="dd/MM/yyyy" />
                                            <ext:TextField AnchorHorizontal="100%" DataIndex="LaborPlace" runat="server" FieldLabel="#Employee_Editor.noicap" MaxLength="100" MaskRe="[^<>&amp;*]" />

                                        </Items>
                                    </ext:Panel>

                                    <ext:Panel ID="frmThoiViec" AnchorHorizontal="-20" runat="server" AutoHeight="true" FormGroup="true" Title="#Employee_Editor.titleThoiviec" Layout="FormLayout" Padding="10" Collapsed="true">
                                        <Items>
                                            <%--<ext:Checkbox runat="server" AnchorHorizontal="100%" FieldLabel="#Employee_Editor.daThoiViec" />--%>
                                            <ext:DateField Width="100" DataIndex="LeftDateReg" runat="server" FieldLabel="#Employee_Editor.ngaynopdon" Format="dd/MM/yyyy" />
                                            <ext:DateField Width="100" DataIndex="LeftDate" runat="server" FieldLabel="#Employee_Editor.ngaythoiviec" Format="dd/MM/yyyy" />
                                            <ext:TextField AnchorHorizontal="100%" DataIndex="DecisionNo" runat="server" FieldLabel="#Employee_Editor.quyetdinhso" MaxLength="50" MaskRe="[^<>&amp;*]" />
                                            <ext:Checkbox runat="server" DataIndex="HasFinalPayment" AnchorHorizontal="100%" FieldLabel="#Employee_Editor.huongtrocap" />
                                            <ext:TextField AnchorHorizontal="100%" DataIndex="LastPayrollMonth" runat="server" FieldLabel="#Employee_Editor.thangtinhluongcuoi" MaxLength="150" MaskRe="/[0-9.]/" />
                                            <ext:TextField AnchorHorizontal="100%" DataIndex="LastPayrollYear" runat="server" FieldLabel="#Employee_Editor.namtraluongcuoi" MaxLength="150" MaskRe="/[0-9.]/" />

                                            <ext:ComboBox AnchorHorizontal="100%" DataIndex="LeftTypeID" runat="server" FieldLabel="#Employee_Editor.lydothoiviec" Editable="false" DisplayField="LeftTypeName" ValueField="LeftTypeID">
                                                <Store>
                                                    <ext:Store ID="stoLeftType" runat="server">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="LeftTypeID">
                                                                <Fields>
                                                                    <ext:RecordField Name="LeftTypeID" />
                                                                    <ext:RecordField Name="LeftTypeName" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                            </ext:ComboBox>

                                            <ext:DateField Width="100" DataIndex="FinalPaymentDate" runat="server" FieldLabel="#Employee_Editor.ngaytraluongcuoi" Format="dd/MM/yyyy" />

                                        </Items>
                                    </ext:Panel>

                                </Items>
                            </ext:FormPanel>

                            <ext:TabPanel ID="frmTTK" runat="server" Border="false" Title="#Employee_Editor.title_ThongTinKhac">
                                <Items>

                                    <ext:GridPanel ID="grdLoaiNV" runat="server" Title="#Employee_Editor.loaiNV">
                                        <Store>
                                            <ext:Store ID="stoLoaiNV" runat="server" DataMember="tblEmpType">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="id">
                                                        <Fields>
                                                            <ext:RecordField Name="id" Type="String" />
                                                            <ext:RecordField Name="DateChange" Type="Date" />
                                                            <ext:RecordField Name="EmpTypeID" />
                                                            <ext:RecordField Name="Notes" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>

                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>

                                                    <ext:ToolbarFill runat="server" />

                                                    <ext:Button runat="server" Text="Refresh" Icon="ArrowRefresh">
                                                        <Listeners>
                                                            <Click Handler="#{stoLoaiNV}.reload();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="AddNew" Icon="Add">
                                                        <Listeners>
                                                            <Click Handler="#{grdLoaiNV}.insertRecord(0, null);" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button runat="server" Text="Delete" Icon="Delete">
                                                        <Listeners>
                                                            <Click Handler="#{grdLoaiNV}.deleteSelected();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="Save" Icon="Disk">
                                                        <Listeners>
                                                            <Click Handler="#{grdLoaiNV}.save();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                </Items>
                                            </ext:Toolbar>
                                        </TopBar>

                                        <ColumnModel>
                                            <Columns>
                                                <ext:RowNumbererColumn Header="STT" Width="35" />

                                                <ext:DateColumn Header="#Employee_Editor.ngay" DataIndex="DateChange" Format="dd/MM/yyyy">
                                                    <Editor>
                                                        <ext:DateField runat="server" Format="dd/MM/yyyy" />
                                                    </Editor>
                                                </ext:DateColumn>
                                                <ext:Column Header="#Employee_Editor.loaiNV" DataIndex="EmpTypeID">
                                                    <Editor>
                                                        <ext:ComboBox runat="server" DisplayField="EmpTypeName" ValueField="EmpTypeID">
                                                            <Store>
                                                                <ext:Store ID="stoEmpType" runat="server">
                                                                    <Reader>
                                                                        <ext:JsonReader IDProperty="EmpTypeID">
                                                                            <Fields>
                                                                                <ext:RecordField Name="EmpTypeID" />
                                                                                <ext:RecordField Name="EmpTypeName" />
                                                                            </Fields>
                                                                        </ext:JsonReader>
                                                                    </Reader>
                                                                </ext:Store>
                                                            </Store>
                                                        </ext:ComboBox>
                                                    </Editor>
                                                    <Renderer Fn="EmpTypeName_Rend" />
                                                </ext:Column>
                                                <ext:Column Header="#Employee_Editor.ghichu" DataIndex="Notes">
                                                    <Editor>
                                                        <ext:TextField runat="server" />
                                                    </Editor>
                                                </ext:Column>

                                                <ext:CommandColumn Width="40">
                                                    <Commands>
                                                        <ext:GridCommand Text="Reject" ToolTip-Text="Reject row changes" CommandName="reject" Icon="ArrowUndo" />
                                                    </Commands>
                                                    <PrepareToolbar Handler="toolbar.items.get(0).setVisible(record.dirty);" />
                                                </ext:CommandColumn>
                                            </Columns>
                                        </ColumnModel>

                                        <Listeners>
                                            <Command Handler="record.reject();" />
                                        </Listeners>

                                        <View>
                                            <ext:GridView runat="server" ForceFit="true" />
                                        </View>

                                        <LoadMask ShowMask="true" />

                                        <SelectionModel>
                                            <ext:RowSelectionModel runat="server" SingleSelect="true" />
                                        </SelectionModel>

                                    </ext:GridPanel>

                                    <ext:GridPanel ID="grdPhongBan" runat="server" Title="#Employee_Editor.phongban">
                                        <Store>
                                            <ext:Store ID="stoPhongBan" runat="server" DataMember="tblEmpDep">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="id">
                                                        <Fields>
                                                            <ext:RecordField Name="id" Type="String" />
                                                            <ext:RecordField Name="DateChange" Type="Date" />
                                                            <ext:RecordField Name="DepID" />
                                                            <ext:RecordField Name="Notes" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>
                                                    <ext:ToolbarFill runat="server" />
                                                    <ext:Button runat="server" Text="Refresh" Icon="ArrowRefresh">
                                                        <Listeners>
                                                            <Click Handler="#{stoPhongBan}.reload();" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="AddNew" Icon="Add">
                                                        <Listeners>
                                                            <Click Handler="#{grdPhongBan}.insertRecord(0, null);" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button runat="server" Text="Delete" Icon="Delete">
                                                        <Listeners>
                                                            <Click Handler="#{grdPhongBan}.deleteSelected();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="Save" Icon="Disk">
                                                        <Listeners>
                                                            <Click Handler="#{grdPhongBan}.save();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                </Items>
                                            </ext:Toolbar>
                                        </TopBar>

                                        <ColumnModel>
                                            <Columns>
                                                <ext:RowNumbererColumn Header="STT" Width="35" />

                                                <ext:DateColumn Header="#Employee_Editor.ngay" DataIndex="DateChange" Format="dd/MM/yyyy">
                                                    <Editor>
                                                        <ext:DateField runat="server" Format="dd/MM/yyyy" />
                                                    </Editor>
                                                </ext:DateColumn>
                                                <ext:Column Header="#Employee_Editor.phongban" DataIndex="DepID">
                                                    <Editor>
                                                        <ext:ComboBox runat="server" DisplayField="DepName" ValueField="DepID">
                                                            <Store>
                                                                <ext:Store ID="stoEmpDep" runat="server">
                                                                    <Reader>
                                                                        <ext:JsonReader IDProperty="DepID">
                                                                            <Fields>
                                                                                <ext:RecordField Name="DepID" />
                                                                                <ext:RecordField Name="DepName" />
                                                                            </Fields>
                                                                        </ext:JsonReader>
                                                                    </Reader>
                                                                </ext:Store>
                                                            </Store>
                                                        </ext:ComboBox>
                                                    </Editor>
                                                    <Renderer Fn="EmpDepName_Rend" />
                                                </ext:Column>
                                                <ext:Column Header="#Employee_Editor.ghichu" DataIndex="Notes">
                                                    <Editor>
                                                        <ext:TextField runat="server" />
                                                    </Editor>
                                                </ext:Column>



                                                <ext:CommandColumn Width="40">
                                                    <Commands>
                                                        <ext:GridCommand Text="Reject" ToolTip-Text="Reject row changes" CommandName="reject" Icon="ArrowUndo" />
                                                    </Commands>
                                                    <PrepareToolbar Handler="toolbar.items.get(0).setVisible(record.dirty);" />
                                                </ext:CommandColumn>
                                            </Columns>
                                        </ColumnModel>

                                        <Listeners>
                                            <Command Handler="record.reject();" />
                                        </Listeners>

                                        <View>
                                            <ext:GridView runat="server" ForceFit="true" />
                                        </View>

                                        <LoadMask ShowMask="true" />

                                        <SelectionModel>
                                            <ext:RowSelectionModel runat="server" SingleSelect="true" />
                                        </SelectionModel>

                                    </ext:GridPanel>
                                    <ext:GridPanel ID="grdSalary" runat="server" Title="#Employee_Editor.luongcoban">
                                        <Store>
                                            <ext:Store ID="stoSalary" runat="server" DataMember="tblEmpSalary">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="id">
                                                        <Fields>
                                                            <ext:RecordField Name="id" Type="String" />
                                                            <ext:RecordField Name="DateChange" Type="Date" />
                                                            <ext:RecordField Name="PosID" />
                                                            <ext:RecordField Name="SalLevelID" />
                                                            <ext:RecordField Name="BasicSalary_Ins" Type="Float" />
                                                            <ext:RecordField Name="BasicSalary" Type="Float" />
                                                            <ext:RecordField Name="Notes" />
                                                            <ext:RecordField Name="BeginDate" />
                                                            <ext:RecordField Name="EndDate" />
                                                            <ext:RecordField Name="ContractCode" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>
                                                    <ext:ToolbarFill runat="server" />

                                                    <ext:Button runat="server" Text="Refresh" Icon="ArrowRefresh">
                                                        <Listeners>
                                                            <Click Handler="#{stoSalary}.reload();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="AddNew" Icon="Add">
                                                        <Listeners>
                                                            <Click Handler="#{grdSalary}.insertRecord(0, null);" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button runat="server" Text="Delete" Icon="Delete">
                                                        <Listeners>
                                                            <Click Handler="#{grdSalary}.deleteSelected();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="Save" Icon="Disk">
                                                        <Listeners>
                                                            <Click Handler="#{grdSalary}.save();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                </Items>
                                            </ext:Toolbar>
                                        </TopBar>

                                        <ColumnModel>
                                            <Columns>
                                                <ext:RowNumbererColumn Header="STT" Width="30" />

                                                <ext:DateColumn Header="#Employee_Editor.ngay" DataIndex="DateChange" Format="dd/MM/yyyy" Width="63">
                                                    <Editor>
                                                        <ext:DateField runat="server" Format="dd/MM/yyyy" />
                                                    </Editor>
                                                </ext:DateColumn>
                                                <ext:Column Header="#Employee_Editor.chucdanh" DataIndex="PosID" Width="110">
                                                    <Editor>
                                                        <ext:ComboBox runat="server" DisplayField="PosName" ValueField="PosID">
                                                            <Store>
                                                                <ext:Store ID="stoPostion" runat="server">
                                                                    <Reader>
                                                                        <ext:JsonReader IDProperty="PosID">
                                                                            <Fields>
                                                                                <ext:RecordField Name="PosID" />
                                                                                <ext:RecordField Name="PosName" />
                                                                            </Fields>
                                                                        </ext:JsonReader>
                                                                    </Reader>
                                                                </ext:Store>
                                                            </Store>
                                                        </ext:ComboBox>
                                                    </Editor>
                                                    <Renderer Fn="EmpPosName_Rend" />
                                                </ext:Column>
                                                <ext:Column Header="#Employee_Editor.mahopdong" DataIndex="ContractCode" Width="80">
                                                    <Editor>
                                                        <ext:TextField runat="server" DataIndex="ContractCode"></ext:TextField>
                                                    </Editor>

                                                </ext:Column>
                                                <ext:Column Header="#Employee_Editor.capbac" DataIndex="SalLevelID" Hidden="true">
                                                    <Editor>
                                                        <ext:ComboBox runat="server">
                                                        </ext:ComboBox>
                                                    </Editor>
                                                    <Renderer Fn="EmpPosName_Rend" />
                                                </ext:Column>
                                                <ext:NumberColumn Header="#Employee_Editor.luongcoban" DataIndex="BasicSalary" Format="0,0" Width="85">
                                                    <Editor>
                                                        <ext:NumberField runat="server" AllowDecimals="false" />
                                                    </Editor>
                                                </ext:NumberColumn>
                                                <ext:NumberColumn Header="#Employee_Editor.phucap" DataIndex="BasicSalary_Ins" Format="0.00" Width="85">
                                                    <Editor>
                                                        <ext:NumberField runat="server" />
                                                    </Editor>
                                                </ext:NumberColumn>
                                                <ext:DateColumn Header="#Employee_Editor.Begindate" DataIndex="BeginDate" Format="dd/MM/yyyy" Width="63">
                                                    <Editor>
                                                        <ext:DateField runat="server" Format="dd/MM/yyyy" />
                                                    </Editor>
                                                </ext:DateColumn>
                                                <ext:DateColumn Header="#Employee_Editor.Enddate" DataIndex="EndDate" Format="dd/MM/yyyy" Width="63">
                                                    <Editor>
                                                        <ext:DateField runat="server" Format="dd/MM/yyyy" />
                                                    </Editor>
                                                </ext:DateColumn>

                                                <ext:Column Header="#Employee_Editor.ghichu" DataIndex="Notes">
                                                    <Editor>
                                                        <ext:TextField runat="server" />
                                                    </Editor>
                                                </ext:Column>

                                                <ext:CommandColumn Width="40">
                                                    <Commands>
                                                        <ext:GridCommand Text="Reject" ToolTip-Text="Reject row changes" CommandName="reject" Icon="ArrowUndo" />
                                                    </Commands>
                                                    <PrepareToolbar Handler="toolbar.items.get(0).setVisible(record.dirty);" />
                                                </ext:CommandColumn>
                                            </Columns>
                                        </ColumnModel>

                                        <Listeners>
                                            <Command Handler="record.reject();" />
                                        </Listeners>

                                        <View>
                                            <ext:GridView runat="server" ForceFit="true" />
                                        </View>

                                        <LoadMask ShowMask="true" />

                                        <SelectionModel>
                                            <ext:RowSelectionModel runat="server" SingleSelect="true" />
                                        </SelectionModel>

                                    </ext:GridPanel>

                                    <ext:GridPanel ID="grdPhuCap" runat="server" Title="#Employee_Editor.phucaphangthang">
                                        <Store>
                                            <ext:Store ID="stoPhuCap" runat="server" DataMember="tblEmpAllowanceFix">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="id">
                                                        <Fields>
                                                            <ext:RecordField Name="id" Type="String" />
                                                            <ext:RecordField Name="DateChange" Type="Date" />
                                                            <ext:RecordField Name="AllowanceID" />
                                                            <ext:RecordField Name="Amount" Type="Int" />
                                                            <ext:RecordField Name="Notes" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>

                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>

                                                    <ext:ToolbarFill runat="server" />

                                                    <ext:Button runat="server" Text="Refresh" Icon="ArrowRefresh">
                                                        <Listeners>
                                                            <Click Handler="#{stoPhuCap}.reload();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="AddNew" Icon="Add">
                                                        <Listeners>
                                                            <Click Handler="#{grdPhuCap}.insertRecord(0, null);" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button runat="server" Text="Delete" Icon="Delete">
                                                        <Listeners>
                                                            <Click Handler="#{grdPhuCap}.deleteSelected();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="Save" Icon="Disk">
                                                        <Listeners>
                                                            <Click Handler="#{grdPhuCap}.save();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                </Items>
                                            </ext:Toolbar>
                                        </TopBar>
                                        <ColumnModel>
                                            <Columns>
                                                <ext:RowNumbererColumn Header="STT" Width="35" />

                                                <ext:DateColumn Header="#Employee_Editor.ngay" DataIndex="DateChange" Format="dd/MM/yyyy">
                                                    <Editor>
                                                        <ext:DateField runat="server" Format="dd/MM/yyyy" />
                                                    </Editor>
                                                </ext:DateColumn>
                                                <ext:Column Header="#Employee_Editor.phucap" DataIndex="AllowanceID">
                                                    <Editor>
                                                        <ext:ComboBox runat="server" DisplayField="AllowanceName" ValueField="AllowanceID">
                                                            <Store>
                                                                <ext:Store ID="stoAllowance" runat="server">
                                                                    <Reader>
                                                                        <ext:JsonReader IDProperty="AllowanceID">
                                                                            <Fields>
                                                                                <ext:RecordField Name="AllowanceID" />
                                                                                <ext:RecordField Name="AllowanceName" />
                                                                            </Fields>
                                                                        </ext:JsonReader>
                                                                    </Reader>
                                                                </ext:Store>
                                                            </Store>
                                                        </ext:ComboBox>
                                                    </Editor>
                                                    <Renderer Fn="EmpAllowanceName_Rend" />
                                                </ext:Column>
                                                <ext:NumberColumn Header="#Employee_Editor.sotien" DataIndex="Amount" Format="0,0">
                                                    <Editor>
                                                        <ext:NumberField runat="server" AllowDecimals="false" />
                                                    </Editor>
                                                </ext:NumberColumn>
                                                <ext:Column Header="#Employee_Editor.ghichu" DataIndex="Notes">
                                                    <Editor>
                                                        <ext:TextField runat="server" />
                                                    </Editor>
                                                </ext:Column>

                                                <ext:CommandColumn Width="40">
                                                    <Commands>
                                                        <ext:GridCommand Text="Reject" ToolTip-Text="Reject row changes" CommandName="reject" Icon="ArrowUndo" />
                                                    </Commands>
                                                    <PrepareToolbar Handler="toolbar.items.get(0).setVisible(record.dirty);" />
                                                </ext:CommandColumn>
                                            </Columns>
                                        </ColumnModel>

                                        <Listeners>
                                            <Command Handler="record.reject();" />
                                        </Listeners>

                                        <View>
                                            <ext:GridView runat="server" ForceFit="true" />
                                        </View>

                                        <LoadMask ShowMask="true" />

                                        <SelectionModel>
                                            <ext:RowSelectionModel runat="server" SingleSelect="true" />
                                        </SelectionModel>

                                    </ext:GridPanel>

                                    <ext:GridPanel ID="grdHopDong" runat="server" Title="#Employee_Editor.hopdong">
                                        <Store>
                                            <ext:Store ID="stoHopDong" runat="server" DataMember="tblEmpContract">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="id">
                                                        <Fields>
                                                            <ext:RecordField Name="id" Type="String" />
                                                            <ext:RecordField Name="BeginDate" Type="Date" />
                                                            <ext:RecordField Name="EndDate" Type="Date" />
                                                            <ext:RecordField Name="ContractID" />
                                                            <ext:RecordField Name="ContractTypeID" />
                                                            <%--<ext:RecordField Name="Amount" Type="Int" />--%>
                                                            <ext:RecordField Name="Notes" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>

                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>

                                                    <ext:ToolbarFill runat="server" />

                                                    <ext:Button runat="server" Text="Refresh" Icon="ArrowRefresh">
                                                        <Listeners>
                                                            <Click Handler="#{stoHopDong}.reload();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="AddNew" Icon="Add">
                                                        <Listeners>
                                                            <Click Handler="#{grdHopDong}.insertRecord(0, null);" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button runat="server" Text="Delete" Icon="Delete">
                                                        <Listeners>
                                                            <Click Handler="#{grdHopDong}.deleteSelected();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="Save" Icon="Disk">
                                                        <Listeners>
                                                            <Click Handler="#{grdHopDong}.save();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                </Items>
                                            </ext:Toolbar>
                                        </TopBar>

                                        <ColumnModel>
                                            <Columns>
                                                <ext:RowNumbererColumn Header="STT" Width="35" />

                                                <ext:Column Header="#Employee_Editor.mahopdong" DataIndex="ContractID">
                                                    <Editor>
                                                        <ext:TextField runat="server" />
                                                    </Editor>
                                                </ext:Column>
                                                <ext:Column Header="#Employee_Editor.loaihopdong" DataIndex="ContractTypeID">
                                                    <Editor>
                                                        <ext:ComboBox runat="server" DisplayField="ContractTypeName" ValueField="ContractTypeID">
                                                            <Store>
                                                                <ext:Store ID="stoContractType" runat="server">
                                                                    <Reader>
                                                                        <ext:JsonReader IDProperty="ContractTypeID">
                                                                            <Fields>
                                                                                <ext:RecordField Name="ContractTypeID" />
                                                                                <ext:RecordField Name="ContractTypeName" />
                                                                            </Fields>
                                                                        </ext:JsonReader>
                                                                    </Reader>
                                                                </ext:Store>
                                                            </Store>
                                                        </ext:ComboBox>
                                                    </Editor>
                                                    <Renderer Fn="EmpContractTypeName_Rend" />
                                                </ext:Column>
                                                <ext:DateColumn Header="#Employee_Editor.tungay" DataIndex="BeginDate" Format="dd/MM/yyyy">
                                                    <Editor>
                                                        <ext:DateField runat="server" Format="dd/MM/yyyy" />
                                                    </Editor>
                                                </ext:DateColumn>
                                                <ext:DateColumn Header="#Employee_Editor.denngay" DataIndex="EndDate" Format="dd/MM/yyyy">
                                                    <Editor>
                                                        <ext:DateField runat="server" Format="dd/MM/yyyy" />
                                                    </Editor>
                                                </ext:DateColumn>
                                                <ext:Column Header="#Employee_Editor.ghichu" DataIndex="Notes">
                                                    <Editor>
                                                        <ext:TextField runat="server" />
                                                    </Editor>
                                                </ext:Column>

                                                <ext:CommandColumn Width="40">
                                                    <Commands>
                                                        <ext:GridCommand Text="Reject" ToolTip-Text="Reject row changes" CommandName="reject" Icon="ArrowUndo" />
                                                    </Commands>
                                                    <PrepareToolbar Handler="toolbar.items.get(0).setVisible(record.dirty);" />
                                                </ext:CommandColumn>
                                            </Columns>
                                        </ColumnModel>

                                        <Listeners>
                                            <Command Handler="record.reject();" />
                                        </Listeners>

                                        <View>
                                            <ext:GridView runat="server" ForceFit="true" />
                                        </View>

                                        <LoadMask ShowMask="true" />

                                        <SelectionModel>
                                            <ext:RowSelectionModel runat="server" SingleSelect="true" />
                                        </SelectionModel>

                                    </ext:GridPanel>

                                    <%--Chức vụ --%>
                                    <%--<ext:GridPanel ID="grdChucVu" runat="server" Title="#Employee_Editor.chucvu" Hidden="true">
                                        <Store>
                                            <ext:Store ID="stoChucVu" runat="server" DataMember="tblEmpPos">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="id">
                                                        <Fields>
                                                            <ext:RecordField Name="id" Type="String" />
                                                            <ext:RecordField Name="DateChange" Type="Date" />
                                                            <ext:RecordField Name="PosID" />
                                                            <ext:RecordField Name="Notes" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>

                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>

                                                    <ext:ToolbarFill runat="server" />

                                                    <ext:Button runat="server" Text="Refresh" Icon="ArrowRefresh">
                                                        <Listeners>
                                                            <Click Handler="#{stoChucVu}.reload();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="AddNew" Icon="Add">
                                                        <Listeners>
                                                            <Click Handler="#{grdChucVu}.insertRecord(0, null);" />
                                                        </Listeners>
                                                    </ext:Button>
                                                    <ext:Button runat="server" Text="Delete" Icon="Delete">
                                                        <Listeners>
                                                            <Click Handler="#{grdChucVu}.deleteSelected();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                    <ext:ToolbarSeparator runat="server" />
                                                    <ext:Button runat="server" Text="Save" Icon="Disk">
                                                        <Listeners>
                                                            <Click Handler="#{grdChucVu}.save();" />
                                                        </Listeners>
                                                    </ext:Button>

                                                </Items>
                                            </ext:Toolbar>
                                        </TopBar>

                                        <ColumnModel>
                                            <Columns>
                                                <ext:RowNumbererColumn Header="STT" Width="35" />

                                                <ext:DateColumn Header="#Employee_Editor.ngay" DataIndex="DateChange" Format="dd/MM/yyyy">
                                                    <Editor>
                                                        <ext:DateField runat="server" Format="dd/MM/yyyy" />
                                                    </Editor>
                                                </ext:DateColumn>
                                                <ext:Column Header="#Employee_Editor.chucvu" DataIndex="PosID">
                                                    <Editor>
                                                        <ext:ComboBox runat="server" DisplayField="PosName" ValueField="PosID">
                                                            <Store>
                                                                <ext:Store ID="stoPostion" runat="server">
                                                                    <Reader>
                                                                        <ext:JsonReader IDProperty="PosID">
                                                                            <Fields>
                                                                                <ext:RecordField Name="PosID" />
                                                                                <ext:RecordField Name="PosName" />
                                                                            </Fields>
                                                                        </ext:JsonReader>
                                                                    </Reader>
                                                                </ext:Store>
                                                            </Store>
                                                        </ext:ComboBox>
                                                    </Editor>
                                                    <Renderer Fn="EmpPosName_Rend" />
                                                </ext:Column>
                                                <ext:Column Header="#Employee_Editor.ghichu" DataIndex="Notes">
                                                    <Editor>
                                                        <ext:TextField runat="server" />
                                                    </Editor>
                                                </ext:Column>

                                                <ext:CommandColumn Width="40">
                                                    <Commands>
                                                        <ext:GridCommand Text="Reject" ToolTip-Text="Reject row changes" CommandName="reject" Icon="ArrowUndo" />
                                                    </Commands>
                                                    <PrepareToolbar Handler="toolbar.items.get(0).setVisible(record.dirty);" />
                                                </ext:CommandColumn>
                                            </Columns>
                                        </ColumnModel>

                                        <Listeners>
                                            <Command Handler="record.reject();" />
                                        </Listeners>

                                        <View>
                                            <ext:GridView runat="server" ForceFit="true" />
                                        </View>

                                        <LoadMask ShowMask="true" />

                                        <SelectionModel>
                                            <ext:RowSelectionModel runat="server" SingleSelect="true" />
                                        </SelectionModel>

                                    </ext:GridPanel>--%>

                                </Items>
                            </ext:TabPanel>
                        </Items>
                    </ext:TabPanel>

                </Items>
            </ext:Viewport>
        </div>
    </form>
</body>
</html>
