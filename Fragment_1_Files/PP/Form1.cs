using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace PP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const string batName = "exFileForD.bat"; //Название bat файла
        const string txtName = "savePath.txt"; //Название txt файла

        private string location = System.Reflection.Assembly.GetExecutingAssembly().Location; //Путь к проекту
        internal string parsePath, batPath, jsonPath, txtPath; //Пути
        internal bool flag;

        private DateTime startTime, finishTime; //Начальное время, конечное
        private string difTime; //Время на загрузку
        internal List<string> idArr; //Массив с id

        internal List<Rootobject> changedAfter = new List<Rootobject>();
        internal List<Rootobject> changedBefore = new List<Rootobject>();
        internal List<string[]> actDoc = new List<string[]>();
        internal List<string[]> oldDoc = new List<string[]>();
        internal string addedFiles = "";
        internal string deletedFiles = "";
        internal string changedFiles = "";
        internal string[] idChangedFiles;

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPath = Path.GetDirectoryName(location) + "\\" + txtName; //Определяется путь к txt файлу
            if(File.Exists(txtPath)) //Если файл существует
            {
                //Чтение файла
                StreamReader sr = new StreamReader(txtPath);
                parsePath = sr.ReadLine();
                sr.Close();
                if (!Directory.Exists(parsePath)) //Если папки для парсинга нет
                {
                    parsePath = null;
                }
                textBox1.Text = parsePath;
            }
        }

        private void createFiles() //Создать необходимые файлы
        {
            string sriptsPath = parsePath + "\\Scripts";
            jsonPath = parsePath + "\\" + DateTime.Now.ToShortDateString();
            batPath = sriptsPath + "\\" + batName;
            if (!File.Exists(batPath)) //Если необходимых файлов не существует
            {
                Directory.CreateDirectory(sriptsPath);
                File.Create(sriptsPath + "\\" + batName).Close();
            }
            if(!Directory.Exists(jsonPath))
            {
                Directory.CreateDirectory(jsonPath);
            }
            using (StreamWriter sw = File.CreateText(txtPath))
            {
                sw.WriteLine(parsePath); //Записать путь к папке для парсинга
            }
        }

        private string getTime(DateTime st, DateTime fin) //Получить разницу во времени
        {
            TimeSpan dif = fin - st;
            int allSec = Convert.ToInt32(dif.TotalSeconds);
            int min = allSec / 60;
            int sec = allSec % 60;
            string time = min + "мин " + sec + "сек";
            return time;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                parsePath = folderBrowserDialog1.SelectedPath.ToString();
                textBox1.Text = parsePath;
            } catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkChange_Click(object sender, EventArgs e)
        {
            try
            {
                CompareForm compareForm = new CompareForm(this);
                compareForm.ShowDialog();

                if (flag == true)
                {
                    MessageBox.Show("Добавлены: " + addedFiles + "\nУдалены: " + deletedFiles + "\nИзменены: " + changedFiles, "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if(changedAfter.Count() > 0)
                {
                    getChangedText();
                    WindowsFormsApp1.Compare comp = new WindowsFormsApp1.Compare(this);
                    Hide();
                    comp.Show();
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Возможно при загрузке файлов был обнаружен поврежденный, советуем провести парсинг повторно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            addedFiles = ""; deletedFiles = ""; changedFiles = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                buttonStart.Enabled = false;
            } else
            {
                buttonStart.Enabled = true; ;
            }
        }

        private string clearImg(string txt)
        {
            string[] words = txt.Split(' ');
            string searchImg1 = "<p><img", searchImg2 = "<p><strong><img", searchImg3 = "valign=\"top\"><img";
            string clearedText = "";

            for(int i = 0; i < words.Count(); i++)
            {
                if (words[i] == searchImg1 || words[i] == searchImg2 || words[i] == searchImg3)
                {
                    words[i] = null;
                    words[i+1] = null;
                }
            }

            for (int i = 0; i < words.Count(); i++)
            {
                clearedText += words[i] + " ";
            }
            return clearedText;
        }

        private void getChangedText()
        {
            int docActCount = changedAfter.Count;
            int docOldCount = changedBefore.Count;

            //Собрать текст без картинок
            for (int i = 0; i < docActCount; i++)
            {
                int secCount = changedAfter[i].obj.sections.Count();
                string[] sections = new string[secCount];
                for (int j = 0; j < secCount; j++)
                {
                    string content = clearImg(changedAfter[i].obj.sections[j].content);
                    string title = changedAfter[i].obj.sections[j].title;
                    if (content == "")
                    {
                        sections[j] = title + "\n";
                    }
                    else
                        sections[j] = title + "\n" + content + "\n";
                }
                actDoc.Add(sections);
            }

            for (int i = 0; i < docOldCount; i++)
            {
                int secCount = changedBefore[i].obj.sections.Count();
                string[] sections = new string[secCount];
                for (int j = 0; j < secCount; j++)
                {
                    string content = clearImg(changedBefore[i].obj.sections[j].content);
                    string title = changedBefore[i].obj.sections[j].title;
                    if (content == "")
                    {
                        sections[j] = title + "\n";
                    }
                    else
                        sections[j] = title + "\n" + content + "\n";
                }
                oldDoc.Add(sections);
            }
            idChangedFiles = changedFiles.Split(',');
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                createFiles();

                SearchForm searchForm = new SearchForm(this);
                searchForm.ShowDialog();

                DownlFormcs downlForm = new DownlFormcs(idArr, jsonPath, batPath);
                startTime = DateTime.Now;
                downlForm.ShowDialog();
                finishTime = DateTime.Now;

                difTime = getTime(startTime, finishTime);
                MessageBox.Show("Файлы успешно созданы за " + difTime, "Парсинг завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      
        }
    }
}
