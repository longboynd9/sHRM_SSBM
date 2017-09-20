<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN IN</title>
    <script src="Skins/Js/jquery-1.9.0.js" type="text/javascript"></script>
    <script src="Skins/Js/cookie.js" type="text/javascript"></script>
    <link href="Skins/Style/style.css" rel="stylesheet" />
    
    <script type="text/javascript">
        function txtPW_speckey(sender, e) {
            if (e.getKey() == e.ENTER) {
                if (checkForm()) {
                    btnLogin.fireEvent('click');
                }
            }
        }

        function checkForm() {
            
            if (txtUsername.getValue() == '') {
                txtUsername.focus();
                return false;
            }
            
            if (txtPassword.getValue() == '') {
                txtPassword.focus();
                return false;
            }
            
            //if (txtCode.getValue() == '') {
            //    txtCode.focus();
            //    return false;
            //}
            
            if (!cmbDb.isValid()){
                cmbDb.focus();
                return false;
            }

            return true;
        }

        function preLogin() {
            setCookie('login_saveUser', txtUsername.getValue(), 30);
            setCookie('login_saveDb', cmbDb.getValue(), 30);

            setCookie('login_saveRemember', chkRememberMe.getValue(), 30);
            if (chkRememberMe.getValue()) {
                setCookie('login_savePW', txtPassword.getValue(), 30);
            }
            else {
                setCookie('login_savePW', '', 0);
            }
        }

        $(document).ready(function () {
            Ext.onReady(function () {
                txtUsername.setValue(getCookie('login_saveUser'));
                cmbDb.setValue(getCookie('login_saveDb'));
                txtPassword.setValue(getCookie('login_savePW'));

                chkRememberMe.setValue(getCookie('login_saveRemember'));
                if (chkRememberMe.getValue() && h_autoLog.value != "0")
                    btnLogin.fireEvent('click');
            });
        });
    </script>

    <style type="text/css">
        body.hasBg {
            background: url('/Cpanel/Skins/Style/IMG/login.jpg') center center no-repeat fixed; 
            -webkit-background-size: 100% 100%;
            -moz-background-size: 100% 100%;
            -o-background-size: 100% 100%;
            background-size: 100% 100%;
        }

        .c1 .x-window-mc { padding: 5px 15px; }
        .c1 .x-panel-btns { width:auto !important; }
        .c1 .x-window-mc { background-color:white !important; }
        .btnQuenMK { position: absolute; left: 0; margin-top: 3px; }

         .icon-combo-item {
            background-repeat: no-repeat !important;
            background-position: 3px 50% !important;
            padding-left: 24px ! important;
        }

        .c2 > div > .x-box-item { position: absolute !important; }
    </style>
</head>

<body id="body1" runat="server">

    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <asp:HiddenField ID="h_autoLog" runat="server" Value="1" />
        <ext:Window ID="Window1" runat="server" Closable="false" Resizable="false" Height="290" Width="370" Icon="Lock" Title="#Login.Title" cls="c1" Layout="FormLayout" ButtonAlign="Right">
            <Tools>
                <ext:Tool Type="Help" />
            </Tools>
            <Items>
                <ext:Image runat="server" ImageUrl="/Cpanel/Skins/Style/IMG/LogoLogin.png" HideLabel="true" AnchorHorizontal="100%" Height="100" />

                <ext:TextField ID="txtUsername" Icon="User" runat="server" AllowBlank="false" BlankText="#Login.txtUsername" FieldLabel="#Login.txtUsername" AnchorHorizontal="100%">
                    <Listeners>
                        <SpecialKey Fn="txtPW_speckey" />
                    </Listeners>
                </ext:TextField>
                
                <ext:TextField ID="txtPassword" Icon="Key" runat="server" InputType="Password" AllowBlank="false" BlankText="#Login.txtPassword" FieldLabel="#Login.txtPassword" AnchorHorizontal="100%">
                    <Listeners>
                        <SpecialKey Fn="txtPW_speckey" />
                    </Listeners>
                </ext:TextField>
                
                <ext:CompositeField runat="server" AnchorHorizontal="100%" Cls="c2">
                    <Items>

                        <ext:ComboBox ID="cmbDb" Icon="DatabaseConnect" runat="server" AllowBlank="false" BlankText="#Login.cmbDb" FieldLabel="#Login.cmbDb" 
                            DisplayField="code" ValueField="code" Editable="false" Flex="1">
                            <Store>
                                <ext:Store ID="stoDb" runat="server">
                                    <Reader>
                                        <ext:JsonReader IDProperty="code">
                                            <Fields>
                                                <ext:RecordField Name="code" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>

                        <ext:ComboBox ID="cmbLng" runat="server" Editable="false" DisplayField="name" ValueField="value" Mode="Local" TriggerAction="All" Flex="1">
                            <Store>
                                <ext:Store ID="Store1" runat="server">
                                    <Reader>
                                        <ext:JsonReader IDProperty="value">
                                            <Fields>
                                                <ext:RecordField Name="iconCls" />
                                                <ext:RecordField Name="name" />
                                                <ext:RecordField Name="value" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>            
                                </ext:Store>
                            </Store>
                            <Template runat="server">
                                <Html>
					                <tpl for=".">
                                        <div class="x-combo-list-item icon-combo-item {iconCls}">
                                            {name}
                                        </div>
                                    </tpl>
				                </Html>
                            </Template>  
                            <Listeners>
                                <Select Handler="this.setIconCls(record.get('iconCls'));" />
                            </Listeners>  
                        </ext:ComboBox>
                        
                    </Items>
                </ext:CompositeField>

                <ext:CompositeField runat="server" AnchorHorizontal="100%" Cls="c2">
                    <Items>

                        <ext:Checkbox ID="chkRememberMe" runat="server" FieldLabel="Ghi nhớ"/>
                        <ext:Label runat="server" Text="Tự động đăng nhập" />

                    </Items>
                </ext:CompositeField>

            </Items>
            <Buttons>
                <%--<ext:LinkButton ID="btnQuenMK" runat="server" Text="#Login.btnQuenMK" Icon="AsteriskOrange" CtCls="btnQuenMK"></ext:LinkButton>--%>
                
                <ext:Button ID="btnLogin" runat="server" Text="#Login.btnLogin" Icon="Accept">
                    <Listeners>
                        <Click Fn="checkForm" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnLogin_Click" Before="preLogin()">
                            <EventMask ShowMask="true" Msg="Đang xác nhận..." MinDelay="1000" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Window>

    </form>
</body>
</html>