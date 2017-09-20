<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeptChoicer.aspx.cs" Inherits="iHRM.WebPC.Cpanel.i_Report.DeptChoicer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        function ok_choice() {
            var n = TreeFunc.getSelectedNodes();
            if (n == undefined || n == null)
            {
                Ext.Msg.show({ icon: Ext.MessageBox.ERROR, msg: 'Xin vui lòng chọn phòng ban', buttons: Ext.Msg.OK });
                return;
            }

            if (parent.DeptChoicer_OnChoice != undefined)
                parent.DeptChoicer_OnChoice(n);
            else
                Ext.Msg.show({ icon: Ext.MessageBox.INFO, msg: n.text, buttons: Ext.Msg.OK });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" />

        <ext:Viewport runat="server" Layout="FitLayout">
            <Items>
                <ext:TreePanel ID="TreeFunc" runat="server" Border="false">
                    <Buttons>
                        <ext:Button ID="btnChoice" runat="server" Icon="Tick" Text="Chọn" OnClientClick="ok_choice()" />
                    </Buttons>
                    <Listeners>
                        <DblClick Handler="ok_choice()" />
                    </Listeners>
                </ext:TreePanel>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
