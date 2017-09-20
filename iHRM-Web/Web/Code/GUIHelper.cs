using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Ext.Net;

namespace iHRM.WebPC.Code
{
    public class GUIHelper
    {
        public static void messageEx(Exception ex, string msg = "Has exception while execute...")
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Buttons = MessageBox.Button.OK,
                Icon = MessageBox.Icon.ERROR,
                Title = "Lỗi",
                Message = string.Format("{2}<br /><b>Source</b>: {0}<br /><b>Message</b>: {1}", ex.Source, ex.Message, msg)
            });
        }

        /// <summary>
        /// Thông báo 
        /// </summary>
        /// <param name="message"></param>
        public static void message(string message, string title = "Thông báo", Icon ico = Icon.Comments, bool autoHide = true, int height = 80, int width = 220)
        {
            Notification.Show(new NotificationConfig
            {
                AlignCfg = new NotificationAlignConfig
                {
                    ElementAnchor = AnchorPoint.Center,
                    TargetAnchor = AnchorPoint.Center,
                    OffsetX = 0,
                    OffsetY = 0
                },
                HideFx = new FadeOut { Options = new FadeOutConfig { Duration = 3, EndOpacity = 0.25f } },
                PinEvent = "none",
                Height = height,
                Width = width,
                AutoHide = autoHide,
                Closable = !autoHide,
                CloseVisible = !autoHide,
                HideDelay = 1800,
                Html = message,
                Title = title,
                Icon = ico,
                Resizable = false,
                Shadow = true,
                AutoScroll = true
            });
        }

        public static void messageConfirmErr(string message)
        {
            X.Msg.Show(new MessageBoxConfig
            {
                Buttons = MessageBox.Button.OK,
                Icon = MessageBox.Icon.WARNING,
                Title = "Lỗi",
                Message = message
            });

            return;
        }

    }
}