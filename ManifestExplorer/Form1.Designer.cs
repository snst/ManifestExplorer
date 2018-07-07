namespace ManifestExplorer
{
    partial class Form1
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnLoadDir = new System.Windows.Forms.Button();
            this.cbRecursive = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbClearOnLoad = new System.Windows.Forms.CheckBox();
            this.cbHideBla = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(12, 49);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(1198, 483);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(15, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 34);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(96, 9);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(75, 34);
            this.btnLoadFile.TabIndex = 3;
            this.btnLoadFile.Text = "Load file";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnLoadDir
            // 
            this.btnLoadDir.Location = new System.Drawing.Point(177, 9);
            this.btnLoadDir.Name = "btnLoadDir";
            this.btnLoadDir.Size = new System.Drawing.Size(75, 34);
            this.btnLoadDir.TabIndex = 4;
            this.btnLoadDir.Text = "Load dir";
            this.btnLoadDir.UseVisualStyleBackColor = true;
            this.btnLoadDir.Click += new System.EventHandler(this.btnLoadDir_Click);
            // 
            // cbRecursive
            // 
            this.cbRecursive.AutoSize = true;
            this.cbRecursive.Location = new System.Drawing.Point(258, 17);
            this.cbRecursive.Name = "cbRecursive";
            this.cbRecursive.Size = new System.Drawing.Size(88, 21);
            this.cbRecursive.TabIndex = 5;
            this.cbRecursive.Text = "recursive";
            this.cbRecursive.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(379, 11);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 31);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbClearOnLoad
            // 
            this.cbClearOnLoad.AutoSize = true;
            this.cbClearOnLoad.Location = new System.Drawing.Point(468, 17);
            this.cbClearOnLoad.Name = "cbClearOnLoad";
            this.cbClearOnLoad.Size = new System.Drawing.Size(112, 21);
            this.cbClearOnLoad.TabIndex = 7;
            this.cbClearOnLoad.Text = "clear on load";
            this.cbClearOnLoad.UseVisualStyleBackColor = true;
            // 
            // cbHideBla
            // 
            this.cbHideBla.AutoSize = true;
            this.cbHideBla.Location = new System.Drawing.Point(619, 17);
            this.cbHideBla.Name = "cbHideBla";
            this.cbHideBla.Size = new System.Drawing.Size(99, 21);
            this.cbHideBla.TabIndex = 8;
            this.cbHideBla.Text = "hide blabla";
            this.cbHideBla.UseVisualStyleBackColor = true;
            this.cbHideBla.CheckedChanged += new System.EventHandler(this.cbHideBla_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 544);
            this.Controls.Add(this.cbHideBla);
            this.Controls.Add(this.cbClearOnLoad);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbRecursive);
            this.Controls.Add(this.btnLoadDir);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "ManifestExplorer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnLoadDir;
        private System.Windows.Forms.CheckBox cbRecursive;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox cbClearOnLoad;
        private System.Windows.Forms.CheckBox cbHideBla;
    }
}

