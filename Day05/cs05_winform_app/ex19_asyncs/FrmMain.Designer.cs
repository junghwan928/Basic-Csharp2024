﻿namespace ex19_asyncs
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            groupBox1 = new GroupBox();
            PrgCopy = new ProgressBar();
            BtnCancel = new Button();
            BtnAsyncCopy = new Button();
            BtnSyncCopy = new Button();
            BtnSetTarget = new Button();
            BtnGetSource = new Button();
            TxtTarget = new TextBox();
            TxtSource = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(PrgCopy);
            groupBox1.Controls.Add(BtnCancel);
            groupBox1.Controls.Add(BtnAsyncCopy);
            groupBox1.Controls.Add(BtnSyncCopy);
            groupBox1.Controls.Add(BtnSetTarget);
            groupBox1.Controls.Add(BtnGetSource);
            groupBox1.Controls.Add(TxtTarget);
            groupBox1.Controls.Add(TxtSource);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(423, 166);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "비동기 전송";
            // 
            // PrgCopy
            // 
            PrgCopy.Location = new Point(20, 127);
            PrgCopy.Name = "PrgCopy";
            PrgCopy.Size = new Size(383, 23);
            PrgCopy.TabIndex = 9;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(283, 81);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(120, 40);
            BtnCancel.TabIndex = 8;
            BtnCancel.Text = "취소";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnAsyncCopy
            // 
            BtnAsyncCopy.Location = new Point(153, 81);
            BtnAsyncCopy.Name = "BtnAsyncCopy";
            BtnAsyncCopy.Size = new Size(124, 40);
            BtnAsyncCopy.TabIndex = 7;
            BtnAsyncCopy.Text = "비동기화 복사";
            BtnAsyncCopy.UseVisualStyleBackColor = true;
            BtnAsyncCopy.Click += BtnAsyncCopy_Click;
            // 
            // BtnSyncCopy
            // 
            BtnSyncCopy.Location = new Point(20, 81);
            BtnSyncCopy.Name = "BtnSyncCopy";
            BtnSyncCopy.Size = new Size(127, 40);
            BtnSyncCopy.TabIndex = 6;
            BtnSyncCopy.Text = "동기화 복사";
            BtnSyncCopy.UseVisualStyleBackColor = true;
            BtnSyncCopy.Click += BtnSyncCopy_Click;
            // 
            // BtnSetTarget
            // 
            BtnSetTarget.Location = new Point(374, 52);
            BtnSetTarget.Name = "BtnSetTarget";
            BtnSetTarget.Size = new Size(29, 23);
            BtnSetTarget.TabIndex = 5;
            BtnSetTarget.Text = "...";
            BtnSetTarget.UseVisualStyleBackColor = true;
            BtnSetTarget.Click += BtnSetTarget_Click;
            // 
            // BtnGetSource
            // 
            BtnGetSource.Location = new Point(374, 23);
            BtnGetSource.Name = "BtnGetSource";
            BtnGetSource.Size = new Size(29, 23);
            BtnGetSource.TabIndex = 4;
            BtnGetSource.Text = "...";
            BtnGetSource.UseVisualStyleBackColor = true;
            BtnGetSource.Click += BtnGetSource_Click;
            // 
            // TxtTarget
            // 
            TxtTarget.Location = new Point(64, 52);
            TxtTarget.Name = "TxtTarget";
            TxtTarget.ReadOnly = true;
            TxtTarget.Size = new Size(304, 23);
            TxtTarget.TabIndex = 3;
            // 
            // TxtSource
            // 
            TxtSource.Location = new Point(64, 23);
            TxtSource.Name = "TxtSource";
            TxtSource.ReadOnly = true;
            TxtSource.Size = new Size(304, 23);
            TxtSource.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 55);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 1;
            label2.Text = "타겟 :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 26);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "소스 :";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 190);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMain";
            Text = "비동기 파일복사";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ProgressBar PrgCopy;
        private Button BtnCancel;
        private Button BtnAsyncCopy;
        private Button BtnSyncCopy;
        private Button BtnSetTarget;
        private Button BtnGetSource;
        private TextBox TxtTarget;
        private TextBox TxtSource;
        private Label label2;
        private Label label1;
    }
}
