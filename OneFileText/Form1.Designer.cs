namespace FileConcatenator
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを解放する場合は true、それ以外の場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.executeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileListBox
            // 
            this.fileListBox.AllowDrop = true;
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ItemHeight = 12;
            this.fileListBox.Location = new System.Drawing.Point(10, 10);
            this.fileListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(620, 232);
            this.fileListBox.TabIndex = 0;
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(469, 246);
            this.executeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(161, 43);
            this.executeButton.TabIndex = 1;
            this.executeButton.Text = "実行";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 300);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.fileListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "File Concatenator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Button executeButton;
    }
}
