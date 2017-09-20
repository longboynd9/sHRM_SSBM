<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="iHRM.WebPC.UserControl.Master.Header" %>

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="vi" version="XHTML+RDFa 1.0" dir="ltr" xmlns:content="http://purl.org/rss/1.0/modules/content/" xmlns:dc="http://purl.org/dc/terms/" xmlns:foaf="http://xmlns.com/foaf/0.1/" xmlns:og="http://ogp.me/ns#" xmlns:rdfs="http://www.w3.org/2000/01/rdf-schema#" xmlns:sioc="http://rdfs.org/sioc/ns#" xmlns:sioct="http://rdfs.org/sioc/types#" xmlns:skos="http://www.w3.org/2004/02/skos/core#" xmlns:xsd="http://www.w3.org/2001/XMLSchema#" class="js">
<head profile="http://www.w3.org/1999/xhtml/vocab">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

    <meta name="generator" content="minhducb6@gmail.com">
    <meta property="og:url" content="http://lawfirmelite.com/">
    <meta property="dcterms.type" content="Text">
    <meta property="dcterms.format" content="text/html">
    <link rel="shortcut icon" href="/old_file/Logo_0.gif" type="image/gif">
    <meta property="og:site_name" content="Elite Law Firm">
    <meta property="og:type" content="website">
    <meta property="og:title" content="Elite Law Firm">
    <meta name="keywords" content="Elite, So huu tri tue, tu van, law firm, cong ty luat, elite law">
    <meta name="description" content="Sở hữu trí tuệ, so huu tri tue, intellectual property, IP, Tư vấn luật, tu van luat, legal, law, Cục hữu trí tuệ, NOIP, Viện sở hữu trí tuệ, VIPRI, Bộ khoa học và công nghệ, Ministry of Sciences and Technologies">
    <link rel="canonical" href="http://lawfirmelite.com/">
    <link rel="shortlink" href="http://lawfirmelite.com/">
    <meta property="dcterms.title" content="Elite Law Firm">
    <meta property="dcterms.identifier" content="http://lawfirmelite.com/">
    <title>Elite Law Firm</title>
    <style type="text/css" media="all">
        @import url("/old_file/system.base.css");
        @import url("/old_file/system.menus.css");
        @import url("/old_file/system.messages.css");
        @import url("/old_file/system.theme.css");
    </style>
    <style type="text/css" media="all">
        @import url("/old_file/comment.css");
        @import url("/old_file/date.css");
        @import url("/old_file/datepicker.1.7.css");
        @import url("/old_file/field.css");
        @import url("/old_file/node.css");
        @import url("/old_file/search.css");
        @import url("/old_file/user.css");
        @import url("/old_file/views.css");
    </style>
    <style type="text/css" media="all">
        @import url("/old_file/ctools.css");
        @import url("/old_file/jquerymenu.css");
        @import url("/old_file/nice_menus.css");
        @import url("/old_file/nice_menus_default.css");
        @import url("/old_file/views_slideshow.css");
        @import url("/old_file/locale.css");
        @import url("/old_file/views_slideshow_cycle.css");
    </style>
    <style type="text/css" media="all">
        @import url("/old_file/styles.css");
        @import url("/old_file/layout.css");
        @import url("/old_file/style.css");
        @import url("/old_file/colors.css");
    </style>
    <style type="text/css" media="print">
        @import url("/old_file/print.css");
    </style>
    <!--[if lte IE 7]>
    <link type="text/css" rel="stylesheet" href="/old_file/ie.css" media="all" />
    <![endif]-->
    <!--[if IE 6]>
    <link type="text/css" rel="stylesheet" href="/old_file/ie6.css" media="all" />
    <![endif]-->

    <script type="text/javascript" src="/Elite Law Firm_files/jquery.js"></script>

    <script type="text/javascript">
        function activeMainMenu(id) {
            var m = $('#nice-menu-1 li[data-id=' + id + ']');
            m.find('> a').addClass('active');
            m.parents('li').find('> a').addClass('active');
        }
    </script>
</head>
<body class="html front not-logged-in two-sidebars page-node i18n-vi featured">
    <div class="wrapper">
        <div class="main_elite">
            <div class="header">
                <div class="region region-header">
                    <div id="block-locale-language" class="block block-locale">
                        <h2 class="element-invisible">Languages</h2>

                        <div class="content">
                            <ul class="language-switcher-locale-url" id="select_lng">
                                <li class="vi first active"><a href="#lng-vi" data-lng="VN" class="language-link">
                                    <img class="language-icon" typeof="foaf:Image" src="/Elite Law Firm_files/vi.png" width="16" height="12" alt="Tiếng Việt" title="Tiếng Việt">
                                    Tiếng Việt</a></li>
                                <li class="en last"><a href="#lng-en" data-lng="EN" class="language-link">
                                    <img class="language-icon" typeof="foaf:Image" src="/Elite Law Firm_files/en.png" width="16" height="12" alt="English" title="English">
                                    English</a></li>
                                <li class="en last"><a href="#lng-kr" data-lng="KR" class="language-link">
                                    <img class="language-icon" typeof="foaf:Image" src="/Elite Law Firm_files/kr.gif" width="16" height="12" alt="Korea" title="Korea">
                                    Korea</a></li>
                            </ul>
                        </div>
                    </div>
                </div>

                <a href="/">
                    <img src="/Elite Law Firm_files/web-banner-13.jpg"></a>
            </div>
            <div class="container">
                <div class="col_1">
                    <div class="region region-sidebar-left">
                        <div id="block-nice-menus-1" class="block block-nice-menus">
                            <h2><span class="nice-menu-show-title">Main menu</span></h2>

                            <div class="content">
                                <ul class="nice-menu nice-menu-right sf-js-enabled" id="nice-menu-1">
                                    {{mainmenu}}

                                </ul>
                            </div>
                        </div>

                        <div id="block-search-form" class="block block-search">

                            <div class="content">
                                <form action="/search.html" method="post" id="search-block-form--2" accept-charset="UTF-8">
                                    <div>
                                        <div class="container-inline">
                                            <h2 class="element-invisible">Search form</h2>
                                            <div class="form-item form-type-textfield form-item-search-block-form">
                                                <label class="element-invisible" for="edit-search-block-form--4">Search </label>
                                                <input title="Enter the terms you wish to search for." type="text" id="edit-search-block-form--4" name="search_block_form" value="" size="15" maxlength="128" class="form-text1" style="height: 24px !important">
                                            </div>
                                            <div class="form-actions form-wrapper" id="edit-actions--3">
                                                <input type="submit" id="edit-submit--3" name="op" value="Search" class="form-submit"></div>
                                            <input type="hidden" name="form_build_id" value="form-_-B2xo7fbFeMb7VaiDSBCiWV-9En6Wcr7mgmXy820hg">
                                            <input type="hidden" name="form_id" value="search_block_form">
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>

                        <div id="block-block-3" class="block block-block">
                            <h2>Links</h2>

                            <div class="content">
                                <p><a href="http://www.linkedin.com/" target="_blank">
                                    <img src="/Elite Law Firm_files/linked-in.jpg" width="163" height="34"></a></p>
                            </div>
                        </div>

                        <div class="ja-inner" id="local_time_clock">
                            <h3><span>Local time</span></h3>
                            <div class="ja-box-ct clearfix">
                                <div class="localtime">
                                    <%= DateTime.Today.ToLongDateString() %>     
                                    <script language="javascript" type="text/javascript">
                                        /*
                                        Drop Down World Clock- By JavaScript Kit (http://www.javascriptkit.com)
                                        Portions of code by Kurt @ http://www.btinternet.com/~kurt.grigg/javascript
                                        This credit notice must stay intact
                                        */

                                        if (document.all || document.getElementById)
                                            document.write(" <span id='worldclock'></span>")

                                        zone = 0;
                                        isitlocal = true;
                                        ampm = '';

                                        function updateclock(z) {
                                            zone = z.options[z.selectedIndex].value;
                                            isitlocal = (z.options[0].selected) ? true : false;
                                        }

                                        function WorldClock() {
                                            now = new Date();
                                            ofst = now.getTimezoneOffset() / 60;
                                            secs = now.getSeconds();
                                            sec = -1.57 + Math.PI * secs / 30;
                                            mins = now.getMinutes();
                                            min = -1.57 + Math.PI * mins / 30;
                                            hr = (isitlocal) ? now.getHours() : (now.getHours() + parseInt(ofst)) + parseInt(zone);
                                            hrs = -1.575 + Math.PI * hr / 6 + Math.PI * parseInt(now.getMinutes()) / 360;
                                            if (hr < 0) hr += 24;
                                            if (hr > 23) hr -= 24;
                                            ampm = (hr > 11) ? "" : "";
                                            statusampm = ampm.toLowerCase();

                                            hr2 = hr;
                                            if (hr2 == 0) hr2 = 24;//24 or 12
                                            (hr2 < 13) ? hr2 : hr2 %= 24;// 24 or 12
                                            if (hr2 < 10) hr2 = "0" + hr2

                                            var finaltime = hr2 + ':' + ((mins < 10) ? "0" + mins : mins) + ':' + ((secs < 10) ? "0" + secs : secs) + ' ' + statusampm;

                                            if (document.all)
                                                worldclock.innerHTML = finaltime
                                            else if (document.getElementById)
                                                document.getElementById("worldclock").innerHTML = finaltime
                                            else if (document.divs) {
                                                document.worldclockns.document.worldclockns2.document.write(finaltime)
                                                document.worldclockns.document.worldclockns2.document.close()
                                            }

                                            setTimeout('WorldClock()', 1000);
                                        }

                                        window.onload = WorldClock
                                        //-->
                                    </script>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="col_2">
