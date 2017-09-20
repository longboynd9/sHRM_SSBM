<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="iHRM.WebPC.WebPart.web.Master.Footer" %>

            </div>
            <div class="footer">
                <div class="region region-footer">
                    <div id="block-block-9" class="block block-block">
                        <h2>Follow us</h2>

                        <div class="content" id="FollowUs_Container">
                            <%= iHRM.WebPC.HtmlModule.HtmlModuleRender.Gen("FollowUs_Container", "FollowUs") %>
                        </div>
                    </div>
                    <div id="block-menu-menu-menu-footer" class="block block-menu">
                        <h2>Menu footer</h2>

                        <div class="content">
                            <ul class="menu clearfix">

                                <!-- BEGIN mainmenu -->
                                <li class="leaf"><a href="{{link}}">{{name}}</a></li>
                                <!-- END mainmenu -->

                            </ul>
                        </div>
                    </div>
                    <div id="block-block-2" class="block block-block">
                        <h2>Footer</h2>

                        <div class="content">
                            <div>© Copyright 2013.&nbsp;ELITE LAW FIRM.&nbsp;All Rights Reserved.</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#select_lng a').click(function () {

                $.ajax({
                    url: "{{AjaxUrl}}",
                    type: 'post',
                    data: {
                        a: 'ChangeLanguage',
                        lng: $(this).data('lng')
                    },
                    success: function (data) {
                        console.log(data);
                        var d = eval('(' + data + ')');
                        if (d.stt == 1) {
                            window.location.reload();
                        }
                    }
                });

                return false;
            });
        });
    </script>

</body>
</html>