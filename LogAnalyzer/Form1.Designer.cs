namespace LogAnalyzer {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.clbFiles = new System.Windows.Forms.CheckedListBox();
            this.pPrefilter = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbPrefilter = new System.Windows.Forms.RichTextBox();
            this.cbPrefilter = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bDir = new System.Windows.Forms.Button();
            this.tbDir = new System.Windows.Forms.TextBox();
            this.rtb = new LogAnalyzer.LogRichTextBox();
            this.lLegend = new System.Windows.Forms.Label();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pPrefilter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.AllowDrop = true;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.clbFiles);
            this.splitContainer2.Panel1.Controls.Add(this.pPrefilter);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AllowDrop = true;
            this.splitContainer2.Panel2.Controls.Add(this.rtb);
            this.splitContainer2.Panel2.Controls.Add(this.lLegend);
            this.splitContainer2.Size = new System.Drawing.Size(1040, 538);
            this.splitContainer2.SplitterDistance = 170;
            this.splitContainer2.TabIndex = 0;
            // 
            // clbFiles
            // 
            this.clbFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbFiles.FormattingEnabled = true;
            this.clbFiles.Location = new System.Drawing.Point(0, 36);
            this.clbFiles.Name = "clbFiles";
            this.clbFiles.Size = new System.Drawing.Size(170, 218);
            this.clbFiles.TabIndex = 1;
            this.clbFiles.SelectedIndexChanged += new System.EventHandler(this.clbFiles_SelectedIndexChanged);
            // 
            // pPrefilter
            // 
            this.pPrefilter.Controls.Add(this.groupBox1);
            this.pPrefilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pPrefilter.Location = new System.Drawing.Point(0, 254);
            this.pPrefilter.Name = "pPrefilter";
            this.pPrefilter.Size = new System.Drawing.Size(170, 284);
            this.pPrefilter.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbPrefilter);
            this.groupBox1.Controls.Add(this.cbPrefilter);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 284);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prefilter";
            // 
            // rtbPrefilter
            // 
            this.rtbPrefilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPrefilter.Location = new System.Drawing.Point(3, 37);
            this.rtbPrefilter.Name = "rtbPrefilter";
            this.rtbPrefilter.Size = new System.Drawing.Size(164, 244);
            this.rtbPrefilter.TabIndex = 2;
            this.rtbPrefilter.Text = "";
            this.rtbPrefilter.WordWrap = false;
            this.rtbPrefilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbPrefilter_KeyDown);
            // 
            // cbPrefilter
            // 
            this.cbPrefilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbPrefilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrefilter.FormattingEnabled = true;
            this.cbPrefilter.Location = new System.Drawing.Point(3, 16);
            this.cbPrefilter.Name = "cbPrefilter";
            this.cbPrefilter.Size = new System.Drawing.Size(164, 21);
            this.cbPrefilter.TabIndex = 4;
            this.cbPrefilter.SelectedIndexChanged += new System.EventHandler(this.cbPrefilter_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bDir);
            this.panel1.Controls.Add(this.tbDir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 36);
            this.panel1.TabIndex = 0;
            // 
            // bDir
            // 
            this.bDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bDir.Location = new System.Drawing.Point(114, 8);
            this.bDir.Name = "bDir";
            this.bDir.Size = new System.Drawing.Size(49, 23);
            this.bDir.TabIndex = 1;
            this.bDir.Text = "...";
            this.bDir.UseVisualStyleBackColor = true;
            this.bDir.Click += new System.EventHandler(this.bDir_Click);
            // 
            // tbDir
            // 
            this.tbDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDir.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::LogAnalyzer.Properties.Settings.Default, "OpenDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbDir.Location = new System.Drawing.Point(12, 10);
            this.tbDir.Name = "tbDir";
            this.tbDir.Size = new System.Drawing.Size(96, 20);
            this.tbDir.TabIndex = 0;
            this.tbDir.Text = global::LogAnalyzer.Properties.Settings.Default.OpenDir;
            this.tbDir.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbDir_KeyUp);
            // 
            // rtb
            // 
            this.rtb.BackColor = System.Drawing.Color.White;
            this.rtb.CausesValidation = false;
            this.rtb.DetectUrls = false;
            this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtb.Location = new System.Drawing.Point(0, 0);
            this.rtb.Name = "rtb";
            this.rtb.ReadOnly = true;
            this.rtb.Size = new System.Drawing.Size(866, 524);
            this.rtb.TabIndex = 1;
            this.rtb.Text = "";
            this.rtb.WordWrap = false;
            // 
            // lLegend
            // 
            this.lLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lLegend.Location = new System.Drawing.Point(0, 524);
            this.lLegend.Name = "lLegend";
            this.lLegend.Size = new System.Drawing.Size(866, 14);
            this.lLegend.TabIndex = 0;
            this.lLegend.Text = "W=WordWrap O=OpenSelected I=OpenSelectedInverse D=Distinct S=BlockSplit Del=Block" +
    "Delete";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 538);
            this.Controls.Add(this.splitContainer2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogAnalyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pPrefilter.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LogRichTextBox rtb;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckedListBox clbFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bDir;
        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.Label lLegend;
        private System.Windows.Forms.RichTextBox rtbPrefilter;
        private System.Windows.Forms.Panel pPrefilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbPrefilter;
    }
}

