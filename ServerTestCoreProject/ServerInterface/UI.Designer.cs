namespace ServerTest
{
    partial class UI
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Button();
            this.ConnectionProgress = new System.Windows.Forms.ProgressBar();
            MessangerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Start.Location = new System.Drawing.Point(857, 413);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // ConnectionProgress
            // 
            this.ConnectionProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionProgress.Location = new System.Drawing.Point(12, 456);
            this.ConnectionProgress.Name = "ConnectionProgress";
            this.ConnectionProgress.Size = new System.Drawing.Size(920, 23);
            this.ConnectionProgress.TabIndex = 1;
            this.ConnectionProgress.UseWaitCursor = true;
            // 
            // MessangerPanel
            // 
            MessangerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            MessangerPanel.AutoScroll = true;
            MessangerPanel.BackColor = System.Drawing.Color.White;
            MessangerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            MessangerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            MessangerPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            MessangerPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            MessangerPanel.Location = new System.Drawing.Point(12, 12);
            MessangerPanel.Name = "MessangerPanel";
            MessangerPanel.Padding = new System.Windows.Forms.Padding(1);
            MessangerPanel.Size = new System.Drawing.Size(920, 218);
            MessangerPanel.TabIndex = 3;
            MessangerPanel.WrapContents = false;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 491);
            this.Controls.Add(MessangerPanel);
            this.Controls.Add(this.ConnectionProgress);
            this.Controls.Add(this.Start);
            this.Name = "UI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.ProgressBar ConnectionProgress;
        public static System.Windows.Forms.FlowLayoutPanel MessangerPanel;
    }
}

