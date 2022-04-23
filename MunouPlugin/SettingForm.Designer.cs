namespace MunouPlugin
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.chk_SayName = new System.Windows.Forms.CheckBox();
            this.bt_Test = new System.Windows.Forms.Button();
            this.chk_SuperchatOnly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chk_SayName
            // 
            this.chk_SayName.AutoSize = true;
            this.chk_SayName.Location = new System.Drawing.Point(12, 12);
            this.chk_SayName.Name = "chk_SayName";
            this.chk_SayName.Size = new System.Drawing.Size(111, 16);
            this.chk_SayName.TabIndex = 0;
            this.chk_SayName.Text = "名前を読み上げる";
            this.chk_SayName.UseVisualStyleBackColor = true;
            this.chk_SayName.CheckedChanged += new System.EventHandler(this.chk_SayName_CheckedChanged);
            // 
            // bt_Test
            // 
            this.bt_Test.Location = new System.Drawing.Point(265, 12);
            this.bt_Test.Name = "bt_Test";
            this.bt_Test.Size = new System.Drawing.Size(75, 23);
            this.bt_Test.TabIndex = 1;
            this.bt_Test.Text = "テスト";
            this.bt_Test.UseVisualStyleBackColor = true;
            this.bt_Test.Click += new System.EventHandler(this.bt_Test_Click);
            // 
            // chk_SuperchatOnly
            // 
            this.chk_SuperchatOnly.AutoSize = true;
            this.chk_SuperchatOnly.Location = new System.Drawing.Point(12, 34);
            this.chk_SuperchatOnly.Name = "chk_SuperchatOnly";
            this.chk_SuperchatOnly.Size = new System.Drawing.Size(135, 16);
            this.chk_SuperchatOnly.TabIndex = 2;
            this.chk_SuperchatOnly.Text = "スパチャのみ読み上げる";
            this.chk_SuperchatOnly.UseVisualStyleBackColor = true;
            this.chk_SuperchatOnly.CheckedChanged += new System.EventHandler(this.chk_SuperchatOnly_CheckedChanged);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 60);
            this.Controls.Add(this.chk_SuperchatOnly);
            this.Controls.Add(this.bt_Test);
            this.Controls.Add(this.chk_SayName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.Text = "無能プラグイン - 設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_SayName;
        private System.Windows.Forms.Button bt_Test;
        private System.Windows.Forms.CheckBox chk_SuperchatOnly;
    }
}