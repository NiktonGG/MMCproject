using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP
{
    public partial class CompareForm : Form
    {
        Form1 formMain;
        public CompareForm(Form1 form)
        {
            InitializeComponent();
            formMain = form;
        }

        private void compareFiles() //Проверка файлов
        {
            formMain.flag = false;
            string dirDateAct = DateTime.Now.ToShortDateString();
            string dirDateOld = DateTime.Now.AddDays(-1).ToShortDateString();
            string dirPathAct = formMain.parsePath + "\\" + dirDateAct;
            string dirPathOld = formMain.parsePath + "\\" + dirDateOld;
            List<string> actualList = new List<string>();
            List<string> oldList = new List<string>();
            List<string> added;
            List<string> deleted;

            if (Directory.Exists(dirPathOld))
            {
                if(Directory.Exists(dirPathAct))
                {
                    formMain.flag = true;
                    DirectoryInfo dirInfAct = new DirectoryInfo(dirPathAct);
                    DirectoryInfo dirInfOLd = new DirectoryInfo(dirPathOld);
                    FileInfo[] filesAct = dirInfAct.GetFiles();
                    FileInfo[] filesOld = dirInfOLd.GetFiles();

                    foreach (var item in filesAct) //Добавление актуальных файлов в список
                    {
                        actualList.Add(item.Name.Trim('.', 'j', 's', 'o', 'n'));
                    }
                    foreach (var item in filesOld) //Добавление старых файлов в список
                    {
                        oldList.Add(item.Name.Trim('.', 'j', 's', 'o', 'n'));
                    }

                    void getAddedDeleted() //Получить удаленные и новые файлы
                    {
                        added = actualList.Except(oldList).ToList();
                        deleted = oldList.Except(actualList).ToList();
                        if (deleted.Count > 0)
                        {
                            string del = "";
                            foreach (var item in deleted)
                            {
                                del += item + ", ";
                            }
                            formMain.deletedFiles = del.Remove(del.Length - 2, 2);
                        }
                        else { formMain.deletedFiles = "без изменений"; }

                        if (added.Count > 0)
                        {
                            string add = "";
                            foreach (var item in added)
                            {
                                add += item + ", ";
                            }
                            formMain.addedFiles = add.Remove(add.Length - 2, 2);
                        }
                        else { formMain.addedFiles = "без изменений"; }
                    }

                    void getChanged() //Получить измененные файлы
                    {
                        List<string> allNameInTwoFolder = new List<string>();
                        foreach (var item in actualList)
                        {
                            if (oldList.Contains(item))
                            {
                                allNameInTwoFolder.Add(item);
                            }
                        }

                        List<Rootobject> rootobjectsOld = new List<Rootobject>();
                        List<Rootobject> rootobjectsAct = new List<Rootobject>();
                        progressBar1.Maximum = allNameInTwoFolder.Count;
                        for (int i = 0; i < allNameInTwoFolder.Count; i++)
                        {
                            string jsonTextOld = File.ReadAllText(dirPathOld + "\\" + allNameInTwoFolder[i] + ".json");
                            string jsonTextAct = File.ReadAllText(dirPathAct + "\\" + allNameInTwoFolder[i] + ".json");

                            rootobjectsOld.Add(JsonConvert.DeserializeObject<Rootobject>(jsonTextOld));
                            rootobjectsAct.Add(JsonConvert.DeserializeObject<Rootobject>(jsonTextAct));

                            if (rootobjectsOld[i].publish_date.ToShortDateString() != rootobjectsAct[i].publish_date.ToShortDateString())
                            {
                                formMain.changedAfter.Add(rootobjectsAct[i]);
                                formMain.changedBefore.Add(rootobjectsOld[i]);
                                formMain.changedFiles += allNameInTwoFolder[i] + ", ";
                            }

                            progressBar1.Value = i;
                            labelAmount.Text = "Сравнили " + i + " из " + actualList.Count;
                            Application.DoEvents();
                        }
                        if (formMain.changedFiles != "")
                        {
                            formMain.changedFiles = formMain.changedFiles.Remove(formMain.changedFiles.Length - 2, 2);
                        }
                        else
                        {
                            formMain.changedFiles = "без изменений";
                        }

                    }
                    getAddedDeleted();
                    getChanged();
                }
                else
                {
                    MessageBox.Show("Необходимо провести парсинг", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } else
            {
                MessageBox.Show("Отсутствует папка вчерашней даты, провести проверку можно будет только при следующем парсинге", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CompareForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            compareFiles();
            Close();
        }
    }
}
