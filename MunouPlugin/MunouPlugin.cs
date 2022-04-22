using System;
using Plugin;
using SitePlugin;
using System.ComponentModel.Composition;
using SuperSimpleTcp;
using System.Diagnostics;
using System.IO;

using PluginCommon;
using YouTubeLiveSitePlugin;
using System.Collections.Generic;

namespace MunouPlugin
{
    [Export(typeof(IPlugin))]
    public class MunouPlugin : IPlugin, IDisposable
    {
        public string Name { get { return "無能プラグイン"; } }
        public string Description { get { return "無能棒読み君と連携するためのプラグインナリ"; } }
        public IPluginHost Host { get; set; }

        public bool readName = false;  //名前を読み上げ対象にするかどうか
        Process proc;           //無能棒読み君を立ち上げ・終了させるためのプロセス
        SimpleTcpClient client = new SimpleTcpClient("127.0.0.1:1919");

        public virtual void OnLoaded()
        {
            //無能棒読み君が同階層にいるか判断し、あるなら起動、ないならプラグイン終了
            if (Process.GetProcessesByName("無能棒読み君").Length <= 0)
            {
                if (File.Exists(@"plugins\MunouPlugin\無能棒読み君.exe"))
                {
                    proc = Process.Start(@"plugins\MunouPlugin\無能棒読み君.exe");
                    client.Connect();
                }
                    
                else
                    Dispose();
            }
        }

        public void OnClosing()
        {
            if (!proc.HasExited)
            {
                //無能棒読み君を終了する
                proc.Kill();
            }
            proc.Close();
        }

        public void OnMessageReceived(ISiteMessage message, IMessageMetadata messageMetadata)
        {
            //var (name, comment) = Tools.GetData(message);
            var (name, comment) = MCVPlugin.GetData(message);
            SendMsg(name, comment);
        }
        public void SendMsg(string msg)
        {
            SendMsg(null, msg);
        }

        public void SendMsg(string name, string msg)
        {
            if (client.IsConnected)
            {
                if (name != null && readName)
                {
                    client.SendAsync(name + "さん、" + msg);
                }
                else
                {
                    client.SendAsync(msg);
                }
            }
        }

        public void OnTopmostChanged(bool isTopmost)
        {

        }

        public void ShowSettingView()
        {
            SettingForm f = new SettingForm(this);
            f.ShowDialog();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {

        }
    }

    //MCVのPluginがまともに動作しないので、手動で定義
    static class MCVPlugin
    {
        internal static (string name, string comment) GetData(ISiteMessage message)
        {
            string name = "（名前なし）";
            string comment = "（本文なし）";

            // Youtube Live
            if (message is IYouTubeLiveMessage youTubeLiveMessage)
            {
                name = "（運営）";
                switch (youTubeLiveMessage.YouTubeLiveMessageType)
                {
                    case YouTubeLiveMessageType.Connected:
                        comment = (youTubeLiveMessage as IYouTubeLiveConnected).Text;
                        break;
                    case YouTubeLiveMessageType.Disconnected:
                        comment = (youTubeLiveMessage as IYouTubeLiveDisconnected).Text;
                        break;
                    case YouTubeLiveMessageType.Comment:
                        name = (youTubeLiveMessage as IYouTubeLiveComment).NameItems.ToText();
                        comment = (youTubeLiveMessage as IYouTubeLiveComment).CommentItems.ToTextWithImageAlt();
                        break;
                    case YouTubeLiveMessageType.Superchat:
                        name = (youTubeLiveMessage as IYouTubeLiveSuperchat).NameItems.ToText();
                        comment = (youTubeLiveMessage as IYouTubeLiveSuperchat).PurchaseAmount + " " + (youTubeLiveMessage as IYouTubeLiveSuperchat).CommentItems.ToTextWithImageAlt();
                        break;
                }
            }


            // YouTube Live SC 等改行が入ることがある \r 置換が有効
            // コメント中の「'」に要注意　's など英語コメントでよく入る
            comment = comment.Replace("\n", "　").Replace("\r", "　").Replace("\'", "’").Replace("\"", "”").Replace("\\", "＼");
            comment = comment.Replace("$", "＄").Replace("/", "／").Replace(",", "，");
            name = name.Replace("\n", "　").Replace("\r", "　").Replace("\'", "’").Replace("\"", "”").Replace("\\", "＼");
            name = name.Replace("$", "＄").Replace("/", "／").Replace(",", "，");

            // 念のため
            if (name == null)
            {
                name = "（名前なし）";
            }
            if (comment == null)
            {
                comment = "（本文なし）";
            }

            return (name, comment);
        }

        private static string ToTextWithImageAlt(this IEnumerable<IMessagePart> parts)
        {
            string s = "";
            if (parts != null)
            {
                foreach (var part in parts)
                {
                    if (part is IMessageText text)
                    {
                        s += text;
                    }
                    else if (part is IMessageImage image)
                    {
                        s += image.Alt;
                    }
                }
            }
            return s;
        }
    }
}
