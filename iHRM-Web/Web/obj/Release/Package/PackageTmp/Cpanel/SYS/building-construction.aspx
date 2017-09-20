<%@ Page Language="C#" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Cpanel/Skins/Style/style.css" rel="stylesheet" />
    <style type="text/css">
        html { 
            background: url('/Cpanel/Skins/Style/IMG/building-construction.jpg') no-repeat center center fixed; 
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }

        .div1 { position:absolute; right:30px; top:30px; }

        #unlicensed { display:none !important; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div1">
        <img src="/Cpanel/Skins/Style/IMG/under-construction-sign.png" width="200px" />
    </div>
    </form>
</body>
</html>
