using System;
using Plugin;
using SitePlugin;
using PluginCommon;
using System.ComponentModel.Composition;
using SuperSimpleTcp;
using System.Diagnostics;
using System.IO;

namespace MunouPlugin
{
    [Export(typeof(IPlugin))]
    public class MunouPlugin : IPlugin, IDisposable
    {
        public string Name { get { return "無能プラグイン"; } }
        public string Description { get { return "無能棒読み君と連携するためのプラグインナリ"; } }
        public IPluginHost Host { get; set; }

        bool readName = false;  //名前を読み上げ対象にするかどうか
        Process proc;           //無能棒読み君を立ち上げ・終了させるためのプロセス
        SimpleTcpClient client = new SimpleTcpClient("127.0.0.1:1919");

        public virtual void OnLoaded()
        {
            //無能棒読み君が同階層にいるか判断し、あるなら起動、ないならプラグイン終了
            if (Process.GetProcessesByName("無能棒読み君").Length <= 0)
            {
                if (File.Exists(@"plugins\Munou\無能棒読み君.exe"))
                    proc = Process.Start(@"plugins\Munou\無能棒読み君.exe");
                else
                    Dispose();
            }

            client.Connect();
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
            var (name, comment) = Tools.GetData(message);
        }

        public void OnTopmostChanged(bool isTopmost)
        {

        }

        public void ShowSettingView()
        {

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
