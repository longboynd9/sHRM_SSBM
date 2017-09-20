<%@ Page Language="C#" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="initial-scale=1, minimum-scale=1, width=device-width">
    <title>Error (Server Error)</title>
    <style>
        #unlicensed { display:none !important; }

        * {
            margin: 0;
            padding: 0;
        }

        html, code {
            font: 15px/22px arial,sans-serif;
        }

        html {
            background: #fff;
            color: #222;
            padding: 15px;
        }

        body {
            margin: 7% auto 0;
            max-width: 390px;
            min-height: 180px;
            padding: 30px 0 15px;
        }

        * > body {
            background: url(//www.google.com/images/errors/robot.png) 100% 5px no-repeat;
            padding-right: 205px;
        }

        p {
            margin: 11px 0 22px;
            overflow: hidden;
        }

        ins {
            color: #777;
            text-decoration: none;
        }

        a img {
            border: 0;
        }

        @media screen and (max-width:772px) {
            body {
                background: none;
                margin-top: 0;
                max-width: none;
                padding-right: 0;
            }
        }

        #logo {
            background: url(//www.google.com/images/errors/logo_sm_2.png) no-repeat;
        }

        @media only screen and (min-resolution:192dpi) {
            #logo {
                background: url(//www.google.com/images/errors/logo_sm_2_hr.png) no-repeat 0% 0%/100% 100%;
                -moz-border-image: url(//www.google.com/images/errors/logo_sm_2_hr.png) 0;
            }
        }

        @media only screen and (-webkit-min-device-pixel-ratio:2) {
            #logo {
                background: url(//www.google.com/images/errors/logo_sm_2_hr.png) no-repeat;
                -webkit-background-size: 100% 100%;
            }
        }

        #logo {
            display: inline-block;
            height: 55px;
            width: 150px;
        }

        h3 { color:yellow; }
    </style>
    <style type="text/css"></style>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
</head>
<body>
    <h3>PHÒNG GIÁO DỤC - ĐÀO TẠO H.KỲ SƠN</h3>
    <p>
        <b><%= Server.GetLastError() == null ? "<br />" : Server.GetLastError().Message %></b>
    </p>
    <p>Máy chủ tạm thời bị mất kết nối và không thể hoàn thành yêu cầu của bạn.</p>
    <p>
        Xin vui lòng thử lại sau 30 giây.
    </p>
</body>
</html>
