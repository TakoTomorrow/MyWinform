using MyWinform.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinform
{
    public partial class UploadExcelPage : Form
    {
        private PreviewPage _subPage;
        
        /// <summary>
        /// Constructure
        /// </summary>
        public UploadExcelPage()
        {
            InitializeComponent();

            _subPage = new PreviewPage(this);
        }

        /// <summary>
        /// 按鈕ok的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (File.Exists(textBox1.Text))
                {      
                    // 設定Excel路徑
                    _subPage.SetExcelPath(textBox1.Text);

                    // 綁定資料
                    _subPage.BindDataSourceOfDataGridView();

                    /* 跳轉Page */
                    _subPage.Show();
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// 按鈕Upload的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpload_Click(object sender, EventArgs e)
        {
            /* 檔案上傳 */
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = false;            
            openFileDialog.Filter = "Excel Files(.xlsx)|*.xlsx| Excel Files(*.xlsm)|*.xlsm";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    textBox1.Text= fileName;
                }

                button3.Enabled = true;
            }
        }

        /// <summary>
        /// 按鈕Cancel的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            button3.Enabled = false;
            _subPage.SetExcelPath(string.Empty);
        }
    }
}
