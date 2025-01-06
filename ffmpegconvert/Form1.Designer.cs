namespace ffmpegconvert
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnInputFile = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbOutputFormat = new System.Windows.Forms.ComboBox();
            this.cmbSampleRate = new System.Windows.Forms.ComboBox();
            this.cmbBitrate = new System.Windows.Forms.ComboBox();
            this.lstInputFiles = new System.Windows.Forms.ListBox();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnOutputFile = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblFFmpegPath = new System.Windows.Forms.Label();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.cmbChannels = new System.Windows.Forms.ComboBox();
            this.cmbCodec = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBitDepth = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCompressionLevel = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbContainer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(97, 12);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(150, 35);
            this.btnInputFile.TabIndex = 1;
            this.btnInputFile.Text = "Select Input";
            this.btnInputFile.UseVisualStyleBackColor = true;
            this.btnInputFile.Click += new System.EventHandler(this.btnSelectInputFiles_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(626, 382);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(140, 50);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 392);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status: Ready";
            // 
            // cmbOutputFormat
            // 
            this.cmbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputFormat.FormattingEnabled = true;
            this.cmbOutputFormat.Location = new System.Drawing.Point(645, 8);
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.Size = new System.Drawing.Size(121, 28);
            this.cmbOutputFormat.TabIndex = 6;
            // 
            // cmbSampleRate
            // 
            this.cmbSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSampleRate.FormattingEnabled = true;
            this.cmbSampleRate.Location = new System.Drawing.Point(645, 42);
            this.cmbSampleRate.Name = "cmbSampleRate";
            this.cmbSampleRate.Size = new System.Drawing.Size(121, 28);
            this.cmbSampleRate.TabIndex = 7;
            // 
            // cmbBitrate
            // 
            this.cmbBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBitrate.FormattingEnabled = true;
            this.cmbBitrate.Location = new System.Drawing.Point(645, 76);
            this.cmbBitrate.Name = "cmbBitrate";
            this.cmbBitrate.Size = new System.Drawing.Size(121, 28);
            this.cmbBitrate.TabIndex = 8;
            // 
            // lstInputFiles
            // 
            this.lstInputFiles.FormattingEnabled = true;
            this.lstInputFiles.ItemHeight = 20;
            this.lstInputFiles.Location = new System.Drawing.Point(12, 53);
            this.lstInputFiles.Name = "lstInputFiles";
            this.lstInputFiles.Size = new System.Drawing.Size(326, 244);
            this.lstInputFiles.TabIndex = 9;
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Location = new System.Drawing.Point(344, 221);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(120, 35);
            this.btnRemoveFile.TabIndex = 10;
            this.btnRemoveFile.Text = "Remove File";
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(344, 262);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(120, 35);
            this.btnClearAll.TabIndex = 11;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.Location = new System.Drawing.Point(97, 303);
            this.btnOutputFile.Name = "btnOutputFile";
            this.btnOutputFile.Size = new System.Drawing.Size(150, 35);
            this.btnOutputFile.TabIndex = 3;
            this.btnOutputFile.Text = "Output Location";
            this.btnOutputFile.UseVisualStyleBackColor = true;
            this.btnOutputFile.Click += new System.EventHandler(this.btnSelectOutputFolder_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(370, 412);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(250, 20);
            this.progressBar.TabIndex = 12;
            // 
            // lblFFmpegPath
            // 
            this.lblFFmpegPath.AutoSize = true;
            this.lblFFmpegPath.Location = new System.Drawing.Point(12, 412);
            this.lblFFmpegPath.Name = "lblFFmpegPath";
            this.lblFFmpegPath.Size = new System.Drawing.Size(168, 20);
            this.lblFFmpegPath.TabIndex = 13;
            this.lblFFmpegPath.Text = "FFmpeg Path: Not Set";
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(93, 341);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(169, 20);
            this.lblOutputFolder.TabIndex = 14;
            this.lblOutputFolder.Text = "Output Folder: Not Set";
            // 
            // cmbChannels
            // 
            this.cmbChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannels.FormattingEnabled = true;
            this.cmbChannels.Location = new System.Drawing.Point(645, 110);
            this.cmbChannels.Name = "cmbChannels";
            this.cmbChannels.Size = new System.Drawing.Size(121, 28);
            this.cmbChannels.TabIndex = 15;
            // 
            // cmbCodec
            // 
            this.cmbCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodec.FormattingEnabled = true;
            this.cmbCodec.Location = new System.Drawing.Point(645, 144);
            this.cmbCodec.Name = "cmbCodec";
            this.cmbCodec.Size = new System.Drawing.Size(121, 28);
            this.cmbCodec.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(555, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "File format";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(537, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Sample Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(572, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Bit Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(563, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Channels";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(584, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Codec";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(563, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Bit Depth";
            // 
            // cmbBitDepth
            // 
            this.cmbBitDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBitDepth.FormattingEnabled = true;
            this.cmbBitDepth.Location = new System.Drawing.Point(645, 178);
            this.cmbBitDepth.Name = "cmbBitDepth";
            this.cmbBitDepth.Size = new System.Drawing.Size(121, 28);
            this.cmbBitDepth.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(496, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Compression Level";
            // 
            // cmbCompressionLevel
            // 
            this.cmbCompressionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompressionLevel.FormattingEnabled = true;
            this.cmbCompressionLevel.Location = new System.Drawing.Point(645, 212);
            this.cmbCompressionLevel.Name = "cmbCompressionLevel";
            this.cmbCompressionLevel.Size = new System.Drawing.Size(121, 28);
            this.cmbCompressionLevel.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(561, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "Container";
            // 
            // cmbContainer
            // 
            this.cmbContainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContainer.FormattingEnabled = true;
            this.cmbContainer.Location = new System.Drawing.Point(645, 246);
            this.cmbContainer.Name = "cmbContainer";
            this.cmbContainer.Size = new System.Drawing.Size(121, 28);
            this.cmbContainer.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 444);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbContainer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCompressionLevel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbBitDepth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCodec);
            this.Controls.Add(this.cmbChannels);
            this.Controls.Add(this.lblOutputFolder);
            this.Controls.Add(this.lblFFmpegPath);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.lstInputFiles);
            this.Controls.Add(this.cmbBitrate);
            this.Controls.Add(this.cmbSampleRate);
            this.Controls.Add(this.cmbOutputFormat);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnOutputFile);
            this.Controls.Add(this.btnInputFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FFmpeg Audio Converter - By Xyrel for Angiee the dorkie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbOutputFormat;
        private System.Windows.Forms.ComboBox cmbSampleRate;
        private System.Windows.Forms.ComboBox cmbBitrate;
        private System.Windows.Forms.ListBox lstInputFiles;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnOutputFile;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblFFmpegPath;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.ComboBox cmbChannels;
        private System.Windows.Forms.ComboBox cmbCodec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBitDepth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCompressionLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbContainer;
    }
}
