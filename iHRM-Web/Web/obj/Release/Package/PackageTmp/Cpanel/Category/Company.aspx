<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="iHRM.WebPC.Cpanel.Category.Company" %>

<%@ Register Src="../UC/ImageUploader.ascx" TagName="ImageUploader" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="ResourceManager1" runat="server" />

            <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" HideBorders="true" AutoScroll="true">
                <Items>
                    <ext:FormPanel ID="frm1" runat="server" Border="false" Layout="FormLayout" AutoScroll="true" Padding="10">
                        <TopBar>
                            <ext:Toolbar runat="server">
                                <Items>
                                    <ext:Button ID="btnSave" runat="server" Icon="Disk" Text="Lưu lại" OnDirectClick="btnSave_DirectClick" />
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Items>

                            <ext:TextField runat="server" DataIndex="CompanyCode" FieldLabel="#Category_Company.CompanyCode" AnchorHorizontal="50%"></ext:TextField>
                            <ext:TextField runat="server" DataIndex="CompanyName" FieldLabel="#Category_Company.CompanyName" AnchorHorizontal="100%"></ext:TextField>
                            <ext:TextField runat="server" DataIndex="Address" FieldLabel="#Category_Company.Address" AnchorHorizontal="100%"></ext:TextField>
                            <ext:TextField runat="server" DataIndex="Phone" FieldLabel="#Category_Company.Phone" AnchorHorizontal="100%"></ext:TextField>
                            <ext:TextField runat="server" DataIndex="Fax" FieldLabel="Fax" AnchorHorizontal="100%"></ext:TextField>
                            <ext:TextField runat="server" DataIndex="VATCode" FieldLabel="#Category_Company.VATCode" AnchorHorizontal="100%"></ext:TextField>

                            <ext:TextField runat="server" DataIndex="BankAccount" FieldLabel="#Category_Company.BankAccount" AnchorHorizontal="100%"></ext:TextField>
                            <ext:TextField runat="server" DataIndex="BankAccount_USD" FieldLabel="#Category_Company.BankAccount_USD" AnchorHorizontal="100%"></ext:TextField>
                            <ext:TextField runat="server" DataIndex="BankName" FieldLabel="#Category_Company.BankName" AnchorHorizontal="100%"></ext:TextField>


                        </Items>
                    </ext:FormPanel>
                </Items>
            </ext:Viewport>
        </div>

    </form>
</body>
</html>
