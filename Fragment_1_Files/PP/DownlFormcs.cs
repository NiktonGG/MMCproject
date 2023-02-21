using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PP
{
    public partial class DownlFormcs : Form
    {
        private List<string> idArr;
        private string jsonPath, batPath;
        Process cmd = new Process();
        public DownlFormcs(List<string> id, string json, string bat)
        {
            InitializeComponent();
            idArr = id;
            jsonPath = json;
            batPath = bat;
        }

        private void doCmd() //Выполняет код bat файла
        {
            try
            {
                var deltePath = new DirectoryInfo(jsonPath);
                progressBar1.Maximum = idArr.Count;
                foreach (FileInfo file in deltePath.GetFiles())
                {
                    file.Delete();
                }
                for (int i = 0; i < idArr.Count; i++)
                {
                    int beforeFileAmount = new DirectoryInfo(jsonPath).GetFiles().Length;
                    string fileContent = "cd /d " + jsonPath + "\n" +
                        "curl \"https://apicr.minzdrav.gov.ru/api.ashx?op=GetClinrec&id=" + idArr[i] + "\" --output " + idArr[i] + ".json";
                    File.WriteAllText(batPath, fileContent);
                    cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cmd.StartInfo.FileName = batPath;
                    cmd.Start();
                    cmd.WaitForExit();
                    int afterFileAmount = new DirectoryInfo(jsonPath).GetFiles().Length;
                    progressBar1.Value++;
                    labelAmount.Text = "Выгрузили: " + progressBar1.Value + " из " + idArr.Count;
                    Application.DoEvents();
                    if (afterFileAmount == beforeFileAmount)
                    {
                        i--;
                        progressBar1.Value--;
                    }
                }
            } catch
            {
                MessageBox.Show("Произошла ошибка при выгрузке файлов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                Application.Exit();
            }
        }

        private void DownlFormcs_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            doCmd();
            //Thread.Sleep(5000);
            this.Close();
        }
    }
}
