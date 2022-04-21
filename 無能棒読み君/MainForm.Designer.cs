using System.Windows.Forms;

namespace 無能棒読み君
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.b_play = new System.Windows.Forms.Button();
            this.tb_voicetext = new System.Windows.Forms.TextBox();
            this.b_clear = new System.Windows.Forms.Button();
            this.l_TextLength = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lb_QCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_ErrorCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_Connected = new System.Windows.Forms.ToolStripStatusLabel();
            this.b_Skip = new System.Windows.Forms.Button();
            this.b_ClearAll = new System.Windows.Forms.Button();
            this.b_download = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ll_karasawa = new System.Windows.Forms.LinkLabel();
            this.bar_Speed = new System.Windows.Forms.TrackBar();
            this.lb_Speed = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bar_Pitch = new System.Windows.Forms.TrackBar();
            this.lb_Pitch = new System.Windows.Forms.Label();
            this.bar_Volume = new System.Windows.Forms.TrackBar();
            this.lb_Volume = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_speaker = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_sample = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar_Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar_Pitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar_Volume)).BeginInit();
            this.SuspendLayout();
            // 
            // b_play
            // 
            this.b_play.Location = new System.Drawing.Point(290, 110);
            this.b_play.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_play.Name = "b_play";
            this.b_play.Size = new System.Drawing.Size(64, 23);
            this.b_play.TabIndex = 0;
            this.b_play.Text = "読み上げ";
            this.b_play.UseVisualStyleBackColor = true;
            this.b_play.Click += new System.EventHandler(this.b_play_Click);
            // 
            // tb_voicetext
            // 
            this.tb_voicetext.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tb_voicetext.Location = new System.Drawing.Point(10, 31);
            this.tb_voicetext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_voicetext.MaxLength = 210;
            this.tb_voicetext.Multiline = true;
            this.tb_voicetext.Name = "tb_voicetext";
            this.tb_voicetext.Size = new System.Drawing.Size(416, 75);
            this.tb_voicetext.TabIndex = 1;
            this.tb_voicetext.TextChanged += new System.EventHandler(this.tb_voicetext_TextChanged);
            // 
            // b_clear
            // 
            this.b_clear.Location = new System.Drawing.Point(360, 110);
            this.b_clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_clear.Name = "b_clear";
            this.b_clear.Size = new System.Drawing.Size(66, 23);
            this.b_clear.TabIndex = 2;
            this.b_clear.Text = "入力クリア";
            this.b_clear.UseVisualStyleBackColor = true;
            this.b_clear.Click += new System.EventHandler(this.b_clear_Click);
            // 
            // l_TextLength
            // 
            this.l_TextLength.Location = new System.Drawing.Point(379, 16);
            this.l_TextLength.Name = "l_TextLength";
            this.l_TextLength.Size = new System.Drawing.Size(47, 13);
            this.l_TextLength.TabIndex = 3;
            this.l_TextLength.Text = "0/200";
            this.l_TextLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_QCount,
            this.lb_ErrorCount,
            this.lb_Connected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 272);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(438, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lb_QCount
            // 
            this.lb_QCount.AutoSize = false;
            this.lb_QCount.Name = "lb_QCount";
            this.lb_QCount.Size = new System.Drawing.Size(70, 17);
            this.lb_QCount.Text = "残: 00000";
            this.lb_QCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_ErrorCount
            // 
            this.lb_ErrorCount.AutoSize = false;
            this.lb_ErrorCount.Name = "lb_ErrorCount";
            this.lb_ErrorCount.Size = new System.Drawing.Size(80, 17);
            this.lb_ErrorCount.Text = "エラー: 00000";
            this.lb_ErrorCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_Connected
            // 
            this.lb_Connected.AutoSize = false;
            this.lb_Connected.Name = "lb_Connected";
            this.lb_Connected.Size = new System.Drawing.Size(80, 17);
            this.lb_Connected.Text = "コメビュ: 切断";
            this.lb_Connected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // b_Skip
            // 
            this.b_Skip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_Skip.Location = new System.Drawing.Point(10, 110);
            this.b_Skip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_Skip.Name = "b_Skip";
            this.b_Skip.Size = new System.Drawing.Size(75, 23);
            this.b_Skip.TabIndex = 5;
            this.b_Skip.Text = "スキップ";
            this.b_Skip.UseVisualStyleBackColor = true;
            this.b_Skip.Click += new System.EventHandler(this.b_Skip_Click);
            // 
            // b_ClearAll
            // 
            this.b_ClearAll.Location = new System.Drawing.Point(91, 110);
            this.b_ClearAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_ClearAll.Name = "b_ClearAll";
            this.b_ClearAll.Size = new System.Drawing.Size(84, 23);
            this.b_ClearAll.TabIndex = 6;
            this.b_ClearAll.Text = "全コメスキップ";
            this.b_ClearAll.UseVisualStyleBackColor = true;
            this.b_ClearAll.Click += new System.EventHandler(this.b_ClearAll_Click);
            // 
            // b_download
            // 
            this.b_download.Location = new System.Drawing.Point(220, 110);
            this.b_download.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_download.Name = "b_download";
            this.b_download.Size = new System.Drawing.Size(64, 23);
            this.b_download.TabIndex = 7;
            this.b_download.Text = "保存";
            this.b_download.UseVisualStyleBackColor = true;
            this.b_download.Click += new System.EventHandler(this.b_download_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ll_karasawa);
            this.groupBox1.Controls.Add(this.bar_Speed);
            this.groupBox1.Controls.Add(this.lb_Speed);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.bar_Pitch);
            this.groupBox1.Controls.Add(this.lb_Pitch);
            this.groupBox1.Controls.Add(this.bar_Volume);
            this.groupBox1.Controls.Add(this.lb_Volume);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_speaker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 131);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "音質変更";
            // 
            // ll_karasawa
            // 
            this.ll_karasawa.AutoSize = true;
            this.ll_karasawa.Location = new System.Drawing.Point(189, 24);
            this.ll_karasawa.Name = "ll_karasawa";
            this.ll_karasawa.Size = new System.Drawing.Size(57, 12);
            this.ll_karasawa.TabIndex = 19;
            this.ll_karasawa.TabStop = true;
            this.ll_karasawa.Text = "無能ボイス";
            this.ll_karasawa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_karasawa_LinkClicked);
            // 
            // bar_Speed
            // 
            this.bar_Speed.AutoSize = false;
            this.bar_Speed.LargeChange = 20;
            this.bar_Speed.Location = new System.Drawing.Point(248, 57);
            this.bar_Speed.Maximum = 400;
            this.bar_Speed.Minimum = 50;
            this.bar_Speed.Name = "bar_Speed";
            this.bar_Speed.Size = new System.Drawing.Size(130, 32);
            this.bar_Speed.SmallChange = 10;
            this.bar_Speed.TabIndex = 18;
            this.bar_Speed.TickFrequency = 10;
            this.bar_Speed.Value = 90;
            this.bar_Speed.ValueChanged += new System.EventHandler(this.bar_Speed_ValueChanged);
            // 
            // lb_Speed
            // 
            this.lb_Speed.AutoSize = true;
            this.lb_Speed.Location = new System.Drawing.Point(379, 61);
            this.lb_Speed.Name = "lb_Speed";
            this.lb_Speed.Size = new System.Drawing.Size(17, 12);
            this.lb_Speed.TabIndex = 17;
            this.lb_Speed.Text = "90";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "速度";
            // 
            // bar_Pitch
            // 
            this.bar_Pitch.AutoSize = false;
            this.bar_Pitch.LargeChange = 20;
            this.bar_Pitch.Location = new System.Drawing.Point(45, 93);
            this.bar_Pitch.Maximum = 200;
            this.bar_Pitch.Minimum = 50;
            this.bar_Pitch.Name = "bar_Pitch";
            this.bar_Pitch.Size = new System.Drawing.Size(130, 32);
            this.bar_Pitch.SmallChange = 10;
            this.bar_Pitch.TabIndex = 15;
            this.bar_Pitch.TickFrequency = 10;
            this.bar_Pitch.Value = 150;
            this.bar_Pitch.ValueChanged += new System.EventHandler(this.bar_Pitch_ValueChanged);
            // 
            // lb_Pitch
            // 
            this.lb_Pitch.AutoSize = true;
            this.lb_Pitch.Location = new System.Drawing.Point(175, 97);
            this.lb_Pitch.Name = "lb_Pitch";
            this.lb_Pitch.Size = new System.Drawing.Size(23, 12);
            this.lb_Pitch.TabIndex = 14;
            this.lb_Pitch.Text = "150";
            // 
            // bar_Volume
            // 
            this.bar_Volume.AutoSize = false;
            this.bar_Volume.LargeChange = 20;
            this.bar_Volume.Location = new System.Drawing.Point(44, 57);
            this.bar_Volume.Maximum = 200;
            this.bar_Volume.Minimum = 50;
            this.bar_Volume.Name = "bar_Volume";
            this.bar_Volume.Size = new System.Drawing.Size(130, 32);
            this.bar_Volume.SmallChange = 10;
            this.bar_Volume.TabIndex = 13;
            this.bar_Volume.TickFrequency = 10;
            this.bar_Volume.Value = 200;
            this.bar_Volume.ValueChanged += new System.EventHandler(this.bar_Volume_ValueChanged);
            // 
            // lb_Volume
            // 
            this.lb_Volume.AutoSize = true;
            this.lb_Volume.Location = new System.Drawing.Point(175, 61);
            this.lb_Volume.Name = "lb_Volume";
            this.lb_Volume.Size = new System.Drawing.Size(23, 12);
            this.lb_Volume.TabIndex = 12;
            this.lb_Volume.Text = "200";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "ピッチ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "音量";
            // 
            // cb_speaker
            // 
            this.cb_speaker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_speaker.FormattingEnabled = true;
            this.cb_speaker.Items.AddRange(new object[] {
            "show",
            "haruka",
            "hikaru",
            "takeru",
            "santa",
            "bear"});
            this.cb_speaker.Location = new System.Drawing.Point(54, 21);
            this.cb_speaker.Name = "cb_speaker";
            this.cb_speaker.Size = new System.Drawing.Size(121, 20);
            this.cb_speaker.TabIndex = 9;
            this.cb_speaker.SelectedIndexChanged += new System.EventHandler(this.cb_speaker_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "スピーカ";
            // 
            // cb_sample
            // 
            this.cb_sample.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sample.FormattingEnabled = true;
            this.cb_sample.Items.AddRange(new object[] {
            "ﾌﾞﾘﾌﾞﾘﾌﾞﾘﾌﾞﾘｭﾘｭﾘｭﾘｭﾘｭﾘｭ！！！！！！ﾌﾞﾂﾁﾁﾌﾞﾌﾞﾌﾞﾁﾁﾁﾁﾌﾞﾘﾘｲﾘﾌﾞﾌﾞﾌﾞﾌﾞｩｩｩｩｯｯｯ！！！！！！！",
            "駄目です"});
            this.cb_sample.Location = new System.Drawing.Point(56, 6);
            this.cb_sample.Name = "cb_sample";
            this.cb_sample.Size = new System.Drawing.Size(121, 20);
            this.cb_sample.TabIndex = 9;
            this.cb_sample.SelectedIndexChanged += new System.EventHandler(this.cb_sample_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "サンプル";
            // 
            // MainForm
            // 
            this.AcceptButton = this.b_play;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_Skip;
            this.ClientSize = new System.Drawing.Size(438, 294);
            this.Controls.Add(this.cb_sample);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.b_download);
            this.Controls.Add(this.b_ClearAll);
            this.Controls.Add(this.b_Skip);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.l_TextLength);
            this.Controls.Add(this.b_clear);
            this.Controls.Add(this.tb_voicetext);
            this.Controls.Add(this.b_play);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "無能棒読み君";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar_Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar_Pitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar_Volume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button b_play;
        private TextBox tb_voicetext;
        private Button b_clear;
        private Label l_TextLength;
        private StatusStrip statusStrip1;
        private Button b_Skip;
        private Button b_ClearAll;
        private Button b_download;
        private ToolStripStatusLabel lb_QCount;
        private ToolStripStatusLabel lb_ErrorCount;
        private ToolStripStatusLabel lb_Connected;
        private GroupBox groupBox1;
        private TrackBar bar_Speed;
        private Label lb_Speed;
        private Label label7;
        private TrackBar bar_Pitch;
        private Label lb_Pitch;
        private TrackBar bar_Volume;
        private Label lb_Volume;
        private Label label3;
        private Label label2;
        private ComboBox cb_speaker;
        private Label label1;
        private LinkLabel ll_karasawa;
        private ComboBox cb_sample;
        private Label label4;
    }
}

