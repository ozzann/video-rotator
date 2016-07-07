namespace VideoRotate
{
    partial class Form1
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
            this.clockwiseBtn = new System.Windows.Forms.Button();
            this.videoFileLabel = new System.Windows.Forms.Label();
            this.videoTextBox = new System.Windows.Forms.TextBox();
            this.videoBrowseBtn = new System.Windows.Forms.Button();
            this.openVideoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.firstFrameBox = new System.Windows.Forms.PictureBox();
            this.rotateBtn = new System.Windows.Forms.Button();
            this.outputVideoFileLabel = new System.Windows.Forms.Label();
            this.outputVideoFileTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.antiClockwiseBtn = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.firstFrameBox)).BeginInit();
            this.SuspendLayout();
            // 
            // clockwiseBtn
            // 
            this.clockwiseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clockwiseBtn.Location = new System.Drawing.Point(330, 124);
            this.clockwiseBtn.Name = "clockwiseBtn";
            this.clockwiseBtn.Size = new System.Drawing.Size(168, 45);
            this.clockwiseBtn.TabIndex = 0;
            this.clockwiseBtn.Text = "90 degree clockwise";
            this.clockwiseBtn.UseVisualStyleBackColor = true;
            this.clockwiseBtn.Click += new System.EventHandler(this.clockwiseBtn_Click);
            // 
            // videoFileLabel
            // 
            this.videoFileLabel.AutoSize = true;
            this.videoFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.videoFileLabel.Location = new System.Drawing.Point(27, 25);
            this.videoFileLabel.Name = "videoFileLabel";
            this.videoFileLabel.Size = new System.Drawing.Size(100, 15);
            this.videoFileLabel.TabIndex = 3;
            this.videoFileLabel.Text = "Choose video file";
            // 
            // videoTextBox
            // 
            this.videoTextBox.Location = new System.Drawing.Point(145, 25);
            this.videoTextBox.Name = "videoTextBox";
            this.videoTextBox.Size = new System.Drawing.Size(436, 20);
            this.videoTextBox.TabIndex = 4;
            this.videoTextBox.TextChanged += new System.EventHandler(this.videoTextBox_TextChanged);
            // 
            // videoBrowseBtn
            // 
            this.videoBrowseBtn.Location = new System.Drawing.Point(587, 19);
            this.videoBrowseBtn.Name = "videoBrowseBtn";
            this.videoBrowseBtn.Size = new System.Drawing.Size(34, 31);
            this.videoBrowseBtn.TabIndex = 5;
            this.videoBrowseBtn.Text = "...";
            this.videoBrowseBtn.UseVisualStyleBackColor = true;
            this.videoBrowseBtn.Click += new System.EventHandler(this.videoBrowseBtn_Click);
            // 
            // firstFrameBox
            // 
            this.firstFrameBox.Location = new System.Drawing.Point(64, 184);
            this.firstFrameBox.Name = "firstFrameBox";
            this.firstFrameBox.Size = new System.Drawing.Size(517, 307);
            this.firstFrameBox.TabIndex = 6;
            this.firstFrameBox.TabStop = false;
            this.firstFrameBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // rotateBtn
            // 
            this.rotateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotateBtn.Location = new System.Drawing.Point(526, 506);
            this.rotateBtn.Name = "rotateBtn";
            this.rotateBtn.Size = new System.Drawing.Size(108, 49);
            this.rotateBtn.TabIndex = 8;
            this.rotateBtn.Text = "Rotate";
            this.rotateBtn.UseVisualStyleBackColor = true;
            this.rotateBtn.Click += new System.EventHandler(this.rotateBtn_Click);
            // 
            // outputVideoFileLabel
            // 
            this.outputVideoFileLabel.AutoSize = true;
            this.outputVideoFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputVideoFileLabel.Location = new System.Drawing.Point(33, 68);
            this.outputVideoFileLabel.Name = "outputVideoFileLabel";
            this.outputVideoFileLabel.Size = new System.Drawing.Size(94, 15);
            this.outputVideoFileLabel.TabIndex = 9;
            this.outputVideoFileLabel.Text = "Output video file";
            // 
            // outputVideoFileTextBox
            // 
            this.outputVideoFileTextBox.Location = new System.Drawing.Point(145, 68);
            this.outputVideoFileTextBox.Name = "outputVideoFileTextBox";
            this.outputVideoFileTextBox.Size = new System.Drawing.Size(436, 20);
            this.outputVideoFileTextBox.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(587, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 32);
            this.button2.TabIndex = 11;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // antiClockwiseBtn
            // 
            this.antiClockwiseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.antiClockwiseBtn.Location = new System.Drawing.Point(145, 124);
            this.antiClockwiseBtn.Name = "antiClockwiseBtn";
            this.antiClockwiseBtn.Size = new System.Drawing.Size(168, 45);
            this.antiClockwiseBtn.TabIndex = 12;
            this.antiClockwiseBtn.Text = "90 degree anticlockwise";
            this.antiClockwiseBtn.UseVisualStyleBackColor = true;
            this.antiClockwiseBtn.Click += new System.EventHandler(this.antiClockwiseBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(36, 525);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(436, 23);
            this.progressBar.TabIndex = 13;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressLabel.Location = new System.Drawing.Point(36, 506);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(25, 15);
            this.progressLabel.TabIndex = 14;
            this.progressLabel.Text = "0%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 579);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.antiClockwiseBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.outputVideoFileTextBox);
            this.Controls.Add(this.outputVideoFileLabel);
            this.Controls.Add(this.rotateBtn);
            this.Controls.Add(this.firstFrameBox);
            this.Controls.Add(this.videoBrowseBtn);
            this.Controls.Add(this.videoTextBox);
            this.Controls.Add(this.videoFileLabel);
            this.Controls.Add(this.clockwiseBtn);
            this.Name = "Form1";
            this.Text = "Video Rotator";
            ((System.ComponentModel.ISupportInitialize)(this.firstFrameBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clockwiseBtn;
        private System.Windows.Forms.Label videoFileLabel;
        private System.Windows.Forms.TextBox videoTextBox;
        private System.Windows.Forms.Button videoBrowseBtn;
        private System.Windows.Forms.OpenFileDialog openVideoFileDialog;
        private System.Windows.Forms.PictureBox firstFrameBox;
        private System.Windows.Forms.Button rotateBtn;
        private System.Windows.Forms.Label outputVideoFileLabel;
        private System.Windows.Forms.TextBox outputVideoFileTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button antiClockwiseBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
    }
}

