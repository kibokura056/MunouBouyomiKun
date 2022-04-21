using VoiceTextWebAPIClient;
using NAudio.Wave;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Drawing;
using SuperSimpleTcp;
using System.Text;

namespace 無能棒読み君
{
    public partial class MainForm : Form
    {
        int vErrorCount = 0;

        bool isPlaying = false;

        SimpleTcpServer server = new SimpleTcpServer("127.0.0.1:1919");
        VoiceTextClient VoiceText;
        Queue<string> MessageQ = new Queue<string>();
        WaveOut waveout = new WaveOut();

        public MainForm()
        {
            InitializeComponent();
            VoiceText = new VoiceTextClient()
            {
                APIKey = "90mrd1sy3g7hy36m",
                Speaker = Speaker.Show,
                Volume = 100,
                Speed = 90,
                Pitch = 150,
                Format = Format.WAV,
                AltText = "以下略"
            };

            server.Start();
            server.Events.DataReceived += DataReceived;
            server.Events.ClientConnected += ClientConnected;
            server.Events.ClientDisconnected += ClientDisconnected;
        }

        void ClientConnected(object sender, ConnectionEventArgs e)
        {
            lb_Connected.Text = "コメビュ: 接続";
        }

        void ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            lb_Connected.Text = "コメビュ: 切断";
        }

        //クライアントから受信した情報を受信
        void DataReceived(object sender, DataReceivedEventArgs e)
        {
            MessageQ.Enqueue(Encoding.UTF8.GetString(e.Data));
            UpdateStatus();
            PlayVoice();
        }

        private void PlayVoice()
        {
            if (!isPlaying)
            {
                isPlaying = true;
                Task task = Task.Run(() =>
                {
                    byte[] bytes = VoiceText.GetVoice(MessageQ.Dequeue());
                    this.Invoke((MethodInvoker)(() =>
                    {
                        UpdateStatus();
                    }));
                    if (bytes != null)
                    {
                        MemoryStream SoundData = new MemoryStream(bytes, false);
                        WaveStream pcm = new WaveFileReader(SoundData);
                        if (pcm.Length > 0)
                        {
                            pcm.Position = 0;
                            waveout.Dispose();
                            waveout = new WaveOut();
                            waveout.Init(pcm);
                            waveout.PlaybackStopped += new EventHandler<StoppedEventArgs>(PlayNextEvent);
                            waveout.Play();

                        }
                        else
                        {
                            vErrorCount++;
                            PlayNextEvent(null, null);
                        }
                    }
                    else
                    {
                        vErrorCount++;
                        PlayNextEvent(null, null);
                    }
                });
            }
        }
        private void PlayNextEvent(object sender, StoppedEventArgs e)
        {
            isPlaying = false;
            UpdateStatus();
            if (MessageQ.Count > 0)
            {
                PlayVoice();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lb_QCount.Text = "残: 0";
            lb_ErrorCount.Text = "エラー: 0";
            lb_Connected.Text = "コメビュ: 切断";
            ll_karasawa_LinkClicked(null,null);
        }

        private void b_play_Click(object sender, EventArgs e)
        {
            MessageQ.Enqueue(tb_voicetext.Text);
            UpdateStatus();
            PlayVoice();
        }

        private void b_clear_Click(object sender, EventArgs e)
        {
            tb_voicetext.Text = "";
            l_TextLength.Text = "0/200";
            l_TextLength.ForeColor = Color.Black;
        }

        private void tb_voicetext_TextChanged(object sender, EventArgs e)
        {
            int textLen = tb_voicetext.Text.Length;
            l_TextLength.Text = textLen + "/200";
            if (textLen > 200)
                l_TextLength.ForeColor = Color.Red;
            else
                l_TextLength.ForeColor = Color.Black;
        }


        private void b_download_Click(object sender, EventArgs e)
        {
            Task task = Task.Run(() => {
                byte[] bytes = VoiceText.GetVoice(tb_voicetext.Text);
                if (bytes == null) return;
                var dlg = new SaveFileDialog();
                dlg.FileName = tb_voicetext.Text;
                dlg.AddExtension = true;
                dlg.Filter = "WAVファイル(*.wav)|*.wav";
                DialogResult result = DialogResult.Cancel;

                this.Invoke((MethodInvoker)(() =>
                {
                    result = dlg.ShowDialog();
                }));

                if (result == DialogResult.OK)
                {
                    File.WriteAllBytes(dlg.FileName, bytes);
                }
            });
        }

        private void b_Skip_Click(object sender, EventArgs e)
        {
            waveout.Stop();
        }

        private void b_ClearAll_Click(object sender, EventArgs e)
        {
            MessageQ.Clear();
            waveout.Stop();
        }
        private void UpdateStatus()
        {
            lb_QCount.Text = "残: " + MessageQ.Count;
            lb_ErrorCount.Text = "エラー: " + vErrorCount;
        }

        private void cb_sample_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_voicetext.Text = cb_sample.SelectedItem.ToString();
        }


        #region 音質変更
        private void cb_speaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            VoiceText.Speaker = (Speaker)cb_speaker.SelectedIndex;
        }

        private void ll_karasawa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cb_speaker.SelectedIndex = (int)Speaker.Show;
            bar_Pitch.Value = 150;
            bar_Speed.Value = 90;
        }

        private void bar_Volume_ValueChanged(object sender, EventArgs e)
        {
            VoiceText.Volume = bar_Volume.Value;
            lb_Volume.Text = bar_Volume.Value.ToString();
        }

        private void bar_Speed_ValueChanged(object sender, EventArgs e)
        {
            VoiceText.Speed = bar_Speed.Value;
            lb_Speed.Text = bar_Speed.Value.ToString();
        }

        private void bar_Pitch_ValueChanged(object sender, EventArgs e)
        {
            VoiceText.Pitch = bar_Pitch.Value;
            lb_Pitch.Text = bar_Pitch.Value.ToString();
        }

        #endregion
    }
}