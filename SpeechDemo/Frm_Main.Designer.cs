namespace SpeechDemo
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Speek = new System.Windows.Forms.Button();
            this.tB_SpeekText = new System.Windows.Forms.TextBox();
            this.btn_Hear = new System.Windows.Forms.Button();
            this.btn_Pause = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.tBar_Volume = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tBar_Volume)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Speek
            // 
            this.btn_Speek.Location = new System.Drawing.Point(97, 239);
            this.btn_Speek.Name = "btn_Speek";
            this.btn_Speek.Size = new System.Drawing.Size(91, 29);
            this.btn_Speek.TabIndex = 0;
            this.btn_Speek.Text = "说";
            this.btn_Speek.UseVisualStyleBackColor = true;
            this.btn_Speek.Click += new System.EventHandler(this.btn_Speek_Click);
            // 
            // tB_SpeekText
            // 
            this.tB_SpeekText.Location = new System.Drawing.Point(97, 12);
            this.tB_SpeekText.Multiline = true;
            this.tB_SpeekText.Name = "tB_SpeekText";
            this.tB_SpeekText.Size = new System.Drawing.Size(605, 210);
            this.tB_SpeekText.TabIndex = 1;
            // 
            // btn_Hear
            // 
            this.btn_Hear.Location = new System.Drawing.Point(481, 239);
            this.btn_Hear.Name = "btn_Hear";
            this.btn_Hear.Size = new System.Drawing.Size(221, 67);
            this.btn_Hear.TabIndex = 2;
            this.btn_Hear.Text = "听";
            this.btn_Hear.UseVisualStyleBackColor = true;
            this.btn_Hear.Click += new System.EventHandler(this.btn_Hear_Click);
            // 
            // btn_Pause
            // 
            this.btn_Pause.Location = new System.Drawing.Point(302, 239);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(91, 29);
            this.btn_Pause.TabIndex = 3;
            this.btn_Pause.Text = "暂停";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(205, 239);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(91, 29);
            this.btn_Stop.TabIndex = 4;
            this.btn_Stop.Text = "停止";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // tBar_Volume
            // 
            this.tBar_Volume.Location = new System.Drawing.Point(157, 340);
            this.tBar_Volume.Maximum = 20;
            this.tBar_Volume.Name = "tBar_Volume";
            this.tBar_Volume.Size = new System.Drawing.Size(293, 45);
            this.tBar_Volume.TabIndex = 5;
            this.tBar_Volume.Value = 5;
            this.tBar_Volume.Scroll += new System.EventHandler(this.tBar_Volume_Scroll);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(83, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "音量：";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBar_Volume);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Pause);
            this.Controls.Add(this.btn_Hear);
            this.Controls.Add(this.tB_SpeekText);
            this.Controls.Add(this.btn_Speek);
            this.Name = "Frm_Main";
            this.Text = "SpeechDemo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Main_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tBar_Volume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Speek;
        private System.Windows.Forms.TextBox tB_SpeekText;
        private System.Windows.Forms.Button btn_Hear;
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.TrackBar tBar_Volume;
        private System.Windows.Forms.Label label1;
    }
}

