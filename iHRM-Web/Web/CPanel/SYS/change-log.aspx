<%@ Page Language="C#" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <style type="text/css">
        #unlicensed { display:none !important; }

        .changelog { font-family: Consolas, 'Courier New', Verdana; padding:10px 5px; }
        .changelog hr { margin-top: 25px; }

        .changelog .title .v { color:#ff6a00; font-weight:bold; }
        .changelog .title .t { margin-left:10px; font-weight:bold; }
        .changelog .title .date { color:#808080; font-style:italic; float:right; }

        .changelog .content { }
    </style>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <ext:Viewport runat="server" Layout="FitLayout">
        <Items>
            <ext:TabPanel runat="server" Border="false">
                <Items>
                    <ext:Panel runat="server" Title="Changed log" Border="false" AutoScroll="true">
                        <Content>
                            <div class="changelog">
                                <p class="title">
                                    <span class="v">v4.0</span><span class="t">Hoàn thiện sHRM cơ bản</span>
                                    <span class="date">22/10/2015</span>
                                </p>
                                <p class="content">
                                    + Đã chạy ổn định theo 1 quy trình<br />
                                    + Thêm một vài yếu tố tính lương
                                </p>
                                <hr />
                            </div>

                            <div class="changelog">
                                <p class="title">
                                    <span class="v">v3.2</span><span class="t">Nâng cấp sHRM</span>
                                    <span class="date">15/09/2015</span>
                                </p>
                                <p class="content">
                                    + Báo cáo tình hình quẹt thẻ hàng ngày<br />
                                    + Fix đăng ký ca làm nhanh hơn<br />
                                </p>
                                <hr />
                            </div>

                            <div class="changelog">
                                <p class="title">
                                    <span class="v">v3.1</span><span class="t">Nâng cấp sHRM</span>
                                    <span class="date">14/09/2015</span>
                                </p>
                                <p class="content">
                                    + Đăng ký ca làm toàn cty<br />
                                    + Tổng hợp công<br />
                                </p>
                                <hr />
                            </div>

                            <div class="changelog">
                                <p class="title">
                                    <span class="v">v3.0</span><span class="t">Nâng cấp sHRM</span>
                                    <span class="date">13/09/2015</span>
                                </p>
                                <p class="content">
                                    + Hoàn thiện chấm công và thực hiện tính lương<br />
                                    + Đk làm thêm, vắng mặt, tính giờ tăng ca..
                                </p>
                                <hr />
                            </div>

                            <div class="changelog">
                                <p class="title">
                                    <span class="v">v2.0</span><span class="t">Chuyển sang giao diện sHRM</span>
                                    <span class="date">01/09/2015</span>
                                </p>
                                <p class="content">
                                    + Thực hiện các chức năng chấm công và nhân sự
                                </p>
                                <hr />
                            </div>

                            <div class="changelog">
                                <p class="title">
                                    <span class="v">v1.2</span><span class="t">Hoàn thành GĐ1</span>
                                    <span class="date">25/07/2015</span>
                                </p>
                                <p class="content">
                                    + Hoàn thiện các danh mục dùng chung<br />
                                    + Thay đường dẫn /iHrm<br />
                                    + Áp dụng ngôn ngữ vào giao diện<br />
                                    + Thêm trang <a href="/Cpanel/Category/Banner.aspx">cấu hình các ảnh nền trong hệ thống</a><br />
                                    + Chuyển đổi cấu trúc, dữ liệu nhân sự<br />
                                </p>
                                <hr />
                            </div>

                            <div class="changelog">
                                <p class="title">
                                    <span class="v">v1.1</span><span class="t">Thiết lập các danh mục</span>
                                    <span class="date">18/07/2015</span>
                                </p>
                                <p class="content">
                                    + Chuyển đổi cấu trúc, dữ liệu các danh mục<br />
                                    + Thiết kế các giao diện<br />
                                </p>
                                <hr />
                            </div>

                            <div class="changelog">
                                <p class="title">
                                    <span class="v">v1.0</span><span class="t">Khởi tạo môi trường</span>
                                    <span class="date">11/07/2015</span>
                                </p>
                                <p class="content">
                                    + Giao diện hệ thống<br />
                                    + Đăng nhập<br />
                                    + Phân quyền<br />
                                </p>
                                <hr />
                            </div>

                        </Content>
                    </ext:Panel>
                    
                    <ext:Panel runat="server" Title="coming soon" Border="false">
                        <Content>
                            <div class="changelog">
                                <p class="title">
                                    <span class="t">Nhân sự</span>
                                    <span class="date">02/08/2015</span>
                                </p>
                                <p class="content">
                                    + Hoàn thành giao diện cơ bản nhập liệu cho nhân sự<br />
                                </p>
                                <hr />
                            </div>
                        </Content>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</body>
</html>
