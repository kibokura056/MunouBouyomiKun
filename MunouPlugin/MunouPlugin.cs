using System;
using Plugin;
using SitePlugin;
using System.ComponentModel.Composition;
using SuperSimpleTcp;
using System.Diagnostics;
using System.IO;

using PluginCommon;
using YouTubeLiveSitePlugin;

namespace MunouPlugin
{
    [Export(typeof(IPlugin))]
    public class MunouPlugin : IPlugin, IDisposable
    {
        public string Name { get { return "無能プラグイン"; } }
        public string Description { get { return "無能棒読み君と連携するためのプラグインナリ"; } }
        public IPluginHost Host { get; set; }

        public bool readName = false;                       //名前を読み上げ対象にするかどうか
        public bool superchatOnly = false;  //スパチャのみ読み上げる
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

            //----------------------------------------------------
            //MCVのPluginがまともに動作しないので、手動で定義
            //----------------------------------------------------
            string name = null;
            string comment = null;

            //YoutubeLive
            if (message is IYouTubeLiveComment ytComment && !superchatOnly)
            {
                comment = ytComment.CommentItems.ToText();
                name = ytComment.NameItems.ToText();
            }
            //YoutubeLive SuperChat
            else if (message is IYouTubeLiveSuperchat superchat)
            {
                comment = superchat.NameItems.ToText() + "さん。" + superchat.PurchaseAmount + "ありがとうございます！";
                var text = superchat.CommentItems.ToText();
                if (!string.IsNullOrEmpty(text))
                {
                    comment += text;
                }
                name = null;
            }


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
}
