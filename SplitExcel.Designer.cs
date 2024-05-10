using System.Configuration;

namespace SplitExcel
{
    partial class SplitExcel
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();                     
            this.butUpload = new System.Windows.Forms.Button();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.labelRowNum = new System.Windows.Forms.Label();
            this.rowNum = new System.Windows.Forms.TextBox();
            this.newExcelList = new System.Windows.Forms.ListBox();
            this.checkConcludeHeader = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|Excel Files (*.xls)|*.xls|All Files (*.*)|*.*";
            this.openFileDialog.InitialDirectory = ConfigurationManager.AppSettings["InitialDirectory"];
            // 
            // butUpload
            // 
            this.butUpload.Location = new System.Drawing.Point(186, 37);
            this.butUpload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butUpload.Name = "butUpload";
            this.butUpload.Size = new System.Drawing.Size(81, 37);
            this.butUpload.TabIndex = 1;
            this.butUpload.Text = "选择文件";
            this.butUpload.UseVisualStyleBackColor = true;
            this.butUpload.Click += new System.EventHandler(this.butUpload_Click);
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(273, 48);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(0, 15);
            this.labelFilePath.TabIndex = 2;
            // 
            // labelRowNum
            // 
            this.labelRowNum.AutoSize = true;
            this.labelRowNum.Location = new System.Drawing.Point(183, 17);
            this.labelRowNum.Name = "labelRowNum";
            this.labelRowNum.Size = new System.Drawing.Size(82, 15);
            this.labelRowNum.TabIndex = 3;
            this.labelRowNum.Text = "新表格行数";
            // 
            // rowNum
            // 
            this.rowNum.Location = new System.Drawing.Point(276, 10);
            this.rowNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rowNum.Name = "rowNum";
            this.rowNum.Size = new System.Drawing.Size(147, 25);
            this.rowNum.TabIndex = 4;
            this.rowNum.Text = "10";
            // 
            // newExcelList
            // 
            this.newExcelList.FormattingEnabled = true;
            this.newExcelList.ItemHeight = 15;
            this.newExcelList.Location = new System.Drawing.Point(186, 79);
            this.newExcelList.Name = "newExcelList";
            this.newExcelList.Size = new System.Drawing.Size(477, 289);
            this.newExcelList.TabIndex = 6;
            // 
            // checkConcludeHeader
            // 
            this.checkConcludeHeader.AutoSize = true;
            this.checkConcludeHeader.Checked = true;
            this.checkConcludeHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkConcludeHeader.Location = new System.Drawing.Point(454, 17);
            this.checkConcludeHeader.Name = "checkConcludeHeader";
            this.checkConcludeHeader.Size = new System.Drawing.Size(119, 19);
            this.checkConcludeHeader.TabIndex = 7;
            this.checkConcludeHeader.Text = "是否复制表头";
            this.checkConcludeHeader.UseVisualStyleBackColor = true;
            // 
            // SplitExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 375);
            this.Controls.Add(this.checkConcludeHeader);
            this.Controls.Add(this.newExcelList);
            this.Controls.Add(this.rowNum);
            this.Controls.Add(this.labelRowNum);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.butUpload);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SplitExcel";
            this.Text = "Excel表格拆分";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button butUpload;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Label labelRowNum;
        private System.Windows.Forms.TextBox rowNum;
        private System.Windows.Forms.ListBox newExcelList;
        private System.Windows.Forms.CheckBox checkConcludeHeader;
    }
}