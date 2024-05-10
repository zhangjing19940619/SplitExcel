using OfficeOpenXml;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SplitExcel
{
    public partial class SplitExcel : Form
    {
        /// <summary>
        /// Excel文件拆分
        /// </summary>
        public SplitExcel()
        {
            InitializeComponent();     
            //限制只能输入数字和退格键
            rowNum.KeyPress += new KeyPressEventHandler(rowNum_KeyPress);
            // 双击打开文件
            newExcelList.MouseDoubleClick += listNewExcel_DoubleClick;   
        }

        private void rowNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 允许输入数字和退格键
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                // 如果输入的不是数字，则取消输入
                e.Handled = true;
            }
        }

        /// <summary>
        /// 点击选择按钮，选择excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butUpload_Click(object sender, EventArgs e)
        {
            //显示对话框接返回值
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //显示所选文件路径
                string excelFilePath = openFileDialog.FileName;
                labelFilePath.Text = excelFilePath;                 
                SplitExcelFile(excelFilePath);
            }
        }

        /// <summary>
        /// 拆分Excel
        /// </summary>
        /// <param name="sourceFilePath">源excel文件路径</param>
        private void SplitExcelFile(string sourceFilePath)
        {
            try
            {
                newExcelList.Items.Clear();
                //拆分后的存放目录
                string targetDirectory = ConfigurationManager.AppSettings["TargetDirectory"];
                var fileName = Path.GetFileNameWithoutExtension(sourceFilePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var sourcePackage = new ExcelPackage(new FileInfo(sourceFilePath)))
                {
                    //默认第一个工作簿
                    var sourceWorksheet = sourcePackage.Workbook.Worksheets[0];
                    //是否复制表头
                    var isConcludeHeader = checkConcludeHeader.Checked;
                    // 从输入框获取指定拆分的行数,默认为10
                    int rowsPerFile = 10; 
                    int.TryParse(rowNum.Text, out rowsPerFile);
                    if (rowsPerFile < 1)
                    {
                        MessageBox.Show("输入的新表格的行数需要是大于0的正整数");
                        return;
                    }

                    int totalRows = sourceWorksheet.Dimension.End.Row;
                    int column = sourceWorksheet.Dimension.End.Column;                    
                    //假设表头在第一行                   
                    int headerRowCount = 1; 
                    for (int startRow = 1; startRow <= totalRows; startRow += rowsPerFile)
                    {
                        //复制A行-B行中B的值
                        int endRow = Math.Min(startRow + rowsPerFile - 1, totalRows);

                        // 创建一个新的ExcelPackage和工作表
                        using (var targetPackage = new ExcelPackage())
                        {
                            var newWorksheet = targetPackage.Workbook.Worksheets.Add("Sheet1");

                            //包含表头
                            if (isConcludeHeader)
                            {
                                // 复制表头
                                sourceWorksheet.Cells[1, 1, headerRowCount, sourceWorksheet.Dimension.End.Column]
                                       .Copy(newWorksheet.Cells[1, 1]);

                                // 复制数据
                                sourceWorksheet.Cells[startRow + 1, 1, startRow + rowsPerFile, sourceWorksheet.Dimension.End.Column]
                                    .Copy(newWorksheet.Cells[2, 1]);
                            }
                            else
                            {
                                // 复制数据
                                sourceWorksheet.Cells[startRow, 1, startRow + rowsPerFile - 1, sourceWorksheet.Dimension.End.Column]
                                    .Copy(newWorksheet.Cells[1, 1]);
                            }

                            // 保存新的Excel文件
                            string newFileName = $"{fileName}_{startRow}_{endRow}.xlsx";
                            string targetFilePath = Path.Combine(targetDirectory, newFileName);

                            // 确保目录存在
                            Directory.CreateDirectory(targetDirectory);
                            targetPackage.SaveAs(new FileInfo(targetFilePath));

                            // 添加到列表显示
                            newExcelList.Items.Add(targetFilePath);
                        }
                    }                    
                    MessageBox.Show("拆分完成！");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("表格拆分失败: " + e.Message);
            }
        }


        /// <summary>
        /// 查看拆分之后的excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listNewExcel_DoubleClick(object sender, EventArgs e)
        {
            if (newExcelList.SelectedItem != null)
            {
                string filePath = newExcelList.SelectedItem.ToString();
                if (File.Exists(filePath))
                {
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
            }
        }
    }
}
