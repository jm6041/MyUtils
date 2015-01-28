namespace ProtectConfig
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textFile = new System.Windows.Forms.TextBox();
            this.labelConfig = new System.Windows.Forms.Label();
            this.btnFindFile = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.textSection = new System.Windows.Forms.TextBox();
            this.labelSection = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cBProviderNames = new System.Windows.Forms.ComboBox();
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "config";
            this.openFileDialog.Filter = "配置文件|*.config|所有文件|*.*";
            // 
            // textFile
            // 
            this.textFile.Location = new System.Drawing.Point(71, 11);
            this.textFile.Name = "textFile";
            this.textFile.Size = new System.Drawing.Size(307, 21);
            this.textFile.TabIndex = 0;
            this.textFile.TextChanged += new System.EventHandler(this.textFile_TextChanged);
            // 
            // labelConfig
            // 
            this.labelConfig.AutoSize = true;
            this.labelConfig.Location = new System.Drawing.Point(12, 15);
            this.labelConfig.Name = "labelConfig";
            this.labelConfig.Size = new System.Drawing.Size(53, 12);
            this.labelConfig.TabIndex = 1;
            this.labelConfig.Text = "配置文件";
            // 
            // btnFindFile
            // 
            this.btnFindFile.Location = new System.Drawing.Point(389, 10);
            this.btnFindFile.Name = "btnFindFile";
            this.btnFindFile.Size = new System.Drawing.Size(60, 23);
            this.btnFindFile.TabIndex = 2;
            this.btnFindFile.Text = "浏览";
            this.btnFindFile.UseVisualStyleBackColor = true;
            this.btnFindFile.Click += new System.EventHandler(this.btnFindFile_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(349, 98);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(100, 23);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "加密";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(349, 127);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(100, 23);
            this.btnDecrypt.TabIndex = 5;
            this.btnDecrypt.Text = "解密";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // textSection
            // 
            this.textSection.Location = new System.Drawing.Point(71, 64);
            this.textSection.Name = "textSection";
            this.textSection.Size = new System.Drawing.Size(266, 21);
            this.textSection.TabIndex = 6;
            // 
            // labelSection
            // 
            this.labelSection.AutoSize = true;
            this.labelSection.Location = new System.Drawing.Point(12, 67);
            this.labelSection.Name = "labelSection";
            this.labelSection.Size = new System.Drawing.Size(47, 12);
            this.labelSection.TabIndex = 7;
            this.labelSection.Text = "Section";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "加密提供程序";
            // 
            // cBProviderNames
            // 
            this.cBProviderNames.FormattingEnabled = true;
            this.cBProviderNames.Location = new System.Drawing.Point(95, 38);
            this.cBProviderNames.Name = "cBProviderNames";
            this.cBProviderNames.Size = new System.Drawing.Size(242, 20);
            this.cBProviderNames.TabIndex = 9;
            // 
            // textBoxError
            // 
            this.textBoxError.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxError.Location = new System.Drawing.Point(14, 95);
            this.textBoxError.Multiline = true;
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.ReadOnly = true;
            this.textBoxError.Size = new System.Drawing.Size(323, 57);
            this.textBoxError.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 161);
            this.Controls.Add(this.textBoxError);
            this.Controls.Add(this.cBProviderNames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSection);
            this.Controls.Add(this.textSection);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnFindFile);
            this.Controls.Add(this.labelConfig);
            this.Controls.Add(this.textFile);
            this.Name = "MainForm";
            this.Text = "配置文件保护";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textFile;
        private System.Windows.Forms.Label labelConfig;
        private System.Windows.Forms.Button btnFindFile;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox textSection;
        private System.Windows.Forms.Label labelSection;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBProviderNames;
        private System.Windows.Forms.TextBox textBoxError;
    }
}

