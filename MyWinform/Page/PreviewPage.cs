using MyWinform.WelfareforExternalDBContext;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MyWinform.Page
{
    public partial class PreviewPage : Form
    {
        private readonly UploadExcelPage _parentPage;

        private string _excelFilePath;

        /// <summary>
        /// Constructure
        /// </summary>
        public PreviewPage(UploadExcelPage page)
        {
            _parentPage = page;

            // 元件初始化
            InitializeComponent();
        }

        /// <summary>
        /// 設定Excel路徑
        /// </summary>
        /// <param name="excelFilePath"></param>
        public void SetExcelPath(string excelFilePath)
        {
            _excelFilePath = excelFilePath;
        }

        /// <summary>
        /// 綁定DataGridView的DataSource資料
        /// </summary>
        public void BindDataSourceOfDataGridView()
        {
            /* 從Excel的WorkSheet[0]取得資料 */
            var fileInfo = new FileInfo(_excelFilePath);
            var excelPackage = new ExcelPackage(fileInfo);
            var ws = excelPackage.Workbook.Worksheets[0];

            // 將ws的資料映射到dt
            var dt = ExcelWork.WorksheetMapToDataTable(ws);

            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 按鈕Return的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            _parentPage.Show();
            this.Hide();
        }

        // <summary>
        /// 按鈕Save的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var dt = dataGridView1.DataSource as DataTable;

            var db = new WelfareforExternalContext();

            foreach (DataRow t in dt.Rows)
            {
                _= t.Field<string>("");
            }
        }
    }
}
