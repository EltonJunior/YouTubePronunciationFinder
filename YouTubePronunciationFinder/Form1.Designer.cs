namespace YouTubePronunciationFinder
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.panelBrowser = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(413, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(175, 14);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(232, 20);
            this.txtWord.TabIndex = 1;
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(524, 39);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(363, 316);
            this.lstResults.TabIndex = 2;
            this.lstResults.DoubleClick += new System.EventHandler(this.lstResults_DoubleClick);
            // 
            // panelBrowser
            // 
            this.panelBrowser.Location = new System.Drawing.Point(12, 39);
            this.panelBrowser.Name = "panelBrowser";
            this.panelBrowser.Size = new System.Drawing.Size(506, 322);
            this.panelBrowser.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "How do I pronounce the word ->";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 377);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelBrowser);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.btnSearch);
            this.MaximumSize = new System.Drawing.Size(919, 416);
            this.MinimumSize = new System.Drawing.Size(919, 416);
            this.Name = "Form1";
            this.Text = "YouTubePronunciationFinder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Panel panelBrowser;
        private System.Windows.Forms.Label label1;
    }
}

