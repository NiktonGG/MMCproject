using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class Compare : Form
    {
        PP.Form1 formMain;
        Info info = new Info();
        public Compare(PP.Form1 form)
        {
            InitializeComponent();
            formMain = form;
        }
        void AddText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Email email = new Email(comboBoxAct.Text.Trim(' '), formMain.changedAfter);
            email.ShowDialog();
        }

        private string replaceTags(string fileContent)
        {
            fileContent = fileContent.Replace("</p>", "\n");
            fileContent = fileContent.Replace("<p>", "\n");
            fileContent = fileContent.Replace("</td>", "\n");
            fileContent = fileContent.Replace("<td>", "\n");
            fileContent = fileContent.Replace("</div>", "\n");
            fileContent = fileContent.Replace("<div>", "\n");
            fileContent = fileContent.Replace("</strong>", "\n");
            fileContent = fileContent.Replace("<strong>", "\n");
            fileContent = fileContent.Replace("</h3>", "\n");
            fileContent = fileContent.Replace("<h3>", "\n");
            fileContent = fileContent.Replace("</li>", "\n");
            fileContent = fileContent.Replace("<li>", "\n");
            fileContent = fileContent.Replace("</h1>", "\n");
            fileContent = fileContent.Replace("<h1>", "\n");
            fileContent = fileContent.Replace("</sub>", "\n");
            fileContent = fileContent.Replace("<sub>", "\n");
            fileContent = fileContent.Replace("</em>", "\n");
            fileContent = fileContent.Replace("<em>", "\n");
            fileContent = fileContent.Replace("</ul>", "\n");
            fileContent = fileContent.Replace("<ul>", "\n");
            fileContent = fileContent.Replace("<\n\n", "\n");
            fileContent = fileContent.Replace("<\n\n", "\n");
            fileContent = fileContent.Replace("<\n\n", "\n");
            fileContent = fileContent.Replace("<\n\n", "\n");
            fileContent = fileContent.Replace("<\n\n", "\n");
            fileContent = fileContent.Replace("<\n\n", "\n");
            fileContent = fileContent.Replace("<\n\n", "\n");

            return fileContent;
        }

        private void openSingleDoc2_Click(object sender, EventArgs e)
        {
            if (comboBoxAct.Text == "")
            {
                MessageBox.Show("Выберете файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string fileContent2 = "";
                string[] needFile2 = formMain.actDoc[comboBoxAct.SelectedIndex];
                for (int i = 0; i < needFile2.Count(); i++)
                {
                    fileContent2 += needFile2[i];
                }
                fileContent2 = replaceTags(fileContent2);
                Text2.Text = fileContent2;

                string fileContent1 = "";
                string[] needFile1 = formMain.oldDoc[comboBoxAct.SelectedIndex];
                for (int i = 0; i < needFile1.Count(); i++)
                {
                    fileContent1 += needFile1[i];
                }
                fileContent1 = replaceTags(fileContent1);
                Text1.Text = fileContent1;
            }
        }

        private void openSingleDoc1_Click(object sender, EventArgs e)
        {
        }

        private void buttonMatch_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowAnalyze_Click(object sender, EventArgs e)
        {
            info.ShowDialog();
            info.Focus();
        }

        private void buttonLoadFiles_Click(object sender, EventArgs e)
        {
            //string fileContent = "";
            //string filePath;

            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    openFileDialog.InitialDirectory = "c:\\";
            //    openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            //    openFileDialog.FilterIndex = 2;
            //    openFileDialog.RestoreDirectory = true;

            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        //Get the path of specified file
            //        filePath = openFileDialog.FileName;

            //        //Read the contents of the file into a stream
            //        var fileStream = openFileDialog.OpenFile();

            //        using (StreamReader reader = new StreamReader(fileStream))
            //        {
            //            fileContent = reader.ReadToEnd();
            //        }
            //    }
            //}
            //Text1.Text = fileContent;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Text1.Text = "";
            Text2.Text = "";
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            info.Show();
            info.Clear();
            //Проверка первого уровня: тексты целиком
            if (Text1.Text == Text2.Text)
            {
                info.AddText("Документ без изменений\n", Color.LightGreen);
                string text = Text1.Text;
                Text1.Text = "";
                AddText(Text1, text, Color.LightGreen);
                text = Text2.Text;
                Text2.Text = "";
                AddText(Text2, text, Color.LightGreen);
            }
            else
            {
                info.AddText("Документ изменился\n", Color.Orange);
                info.AddText("=====================================\n", Color.Cyan);
                //Списки параграфов текста 1 и всех предложений этих абзацев
                List<SentencesClass> sentences1 = new List<SentencesClass>();
                List<string> paragraphs1 = new List<string>();
                //Заполнение списка абзацев
                for (int i = 0; i < Text1.Text.Split('\n').Length; i++)
                    paragraphs1.Add(Text1.Text.Split('\n')[i]);
                info.AddText("• Количество абзацев в старом документе: " + paragraphs1.Count + "\n", Color.Black);
                if (Text1.Text.Split('\n').Length < Text2.Text.Split('\n').Length)
                    for (int i = 0; i < Math.Abs(Text1.Text.Split('\n').Length - Text2.Text.Split('\n').Length); i++)
                        paragraphs1.Add("[Абзац отсутствует]");

                //Списки параграфов текста 2 и всех предложений этих абзацев
                List<SentencesClass> sentences2 = new List<SentencesClass>();
                List<string> paragraphs2 = new List<string>();
                //Заполнение списка абзацев
                for (int i = 0; i < Text2.Text.Split('\n').Length; i++)
                    paragraphs2.Add(Text2.Text.Split('\n')[i]);
                info.AddText("• Количество абзацев в новом документе: " + paragraphs2.Count + "\n", Color.Black);
                if (Text1.Text.Split('\n').Length > Text2.Text.Split('\n').Length)
                    for (int i = 0; i < Math.Abs(Text1.Text.Split('\n').Length - Text2.Text.Split('\n').Length); i++)
                        paragraphs2.Add("[Абзац удален]");

                //Заполнение списка предложений
                for (int i = 0; i < paragraphs1.Count; i++)
                {
                    for (int j = 0; j < paragraphs1[i].Split('.').Length; j++)
                        if (paragraphs1[i].Split('.')[j].Length > 0 && paragraphs1[i].Split('.')[j] != "[Абзац отсутствует]")
                            sentences1.Add(new SentencesClass(i, paragraphs1[i].Split('.')[j] + "."));
                    try
                    {
                        if (paragraphs1[i].Split('.').Length < paragraphs2[i].Split('.').Length)
                            for (int j = 0; j < Math.Abs(paragraphs1[i].Split('.').Length - paragraphs2[i].Split('.').Length); j++)
                                sentences1.Add(new SentencesClass(i, " [Предложение отсутствует]. "));
                    }
                    catch { }
                    if (sentences1.Count > 0)
                        sentences1[sentences1.Count - 1].text += "\n";
                }
                //Заполнение списка предложений
                for (int i = 0; i < paragraphs2.Count; i++)
                {
                    for (int j = 0; j < paragraphs2[i].Split('.').Length; j++)
                        if (paragraphs2[i].Split('.')[j].Length > 0 && paragraphs2[i].Split('.')[j] != "[Абзац удален]")
                            sentences2.Add(new SentencesClass(i, paragraphs2[i].Split('.')[j] + "."));
                    try
                    {
                        if (paragraphs1[i].Split('.').Length > paragraphs2[i].Split('.').Length)
                            for (int j = 0; j < Math.Abs(paragraphs1[i].Split('.').Length - paragraphs2[i].Split('.').Length); j++)
                                sentences2.Add(new SentencesClass(i, " [Предложение удалено]. "));
                    }
                    catch { }
                    if (sentences2.Count > 0)
                        sentences2[sentences2.Count - 1].text += "\n";
                }


                info.AddText("• Количество предложений в старом документе: " + sentences1.Count + "\n", Color.Black);
                info.AddText("• Количество предложений в новом документе: " + sentences2.Count + "\n", Color.Black);
                info.AddText("=====================================\n", Color.Cyan);

                Text1.Text = "";
                Text2.Text = "";
                //Проверка второго уровня: Абзацы целиком
                for (int i = 0; i < paragraphs1.Count; i++)
                {

                    if (paragraphs1[i] == paragraphs2[i])
                    {
                        AddText(Text1, paragraphs1[i] + "\n", Color.Black);
                        AddText(Text2, paragraphs2[i] + "\n", Color.Black);
                    }
                    else if (paragraphs1[i] == "[Абзац отсутствует]")
                    {
                        info.AddText("• Абзац №" + (i + 1) + " добавлен в новом документе\n", Color.LimeGreen);
                        AddText(Text1, paragraphs1[i] + "\n", Color.Red);
                        AddText(Text2, paragraphs2[i] + "\n", Color.LimeGreen);
                    }
                    else if (paragraphs2[i] == "[Абзац удален]")
                    {
                        info.AddText("• Абзац №" + (i + 1) + " отсутствует в новом документе\n", Color.Red);
                        AddText(Text2, paragraphs2[i] + "\n", Color.Red);
                        AddText(Text1, paragraphs1[i] + "\n", Color.LimeGreen);
                    }
                    else
                    {
                        info.AddText("• Абзац №" + (i + 1) + " изменился:\n", Color.Orange);
                        //Проверка третьего уровня: Предложения целиком
                        for (int k = 0; k < sentences1.Count; k++)
                        {
                            if (sentences1[k].paragraphID == i && sentences2[k].paragraphID == i)
                            {
                                if (sentences1[k].text == sentences2[k].text)
                                {
                                    info.AddText("||     Предложение №" + (k + 1) + " без изменений\n", Color.Black);
                                    AddText(Text1, sentences1[k].text, Color.Black);
                                    AddText(Text2, sentences2[k].text, Color.Black);
                                }
                                else if (sentences1[k].text.Replace("\n", "") == " [Предложение отсутствует]. ")
                                {
                                    info.AddText("||     Предложение №" + (k + 1) + " добавлено в новый документ\n", Color.LimeGreen);
                                    AddText(Text1, sentences1[k].text, Color.Red);
                                    AddText(Text2, sentences2[k].text, Color.LimeGreen);
                                }
                                else if (sentences2[k].text.Replace("\n", "") == " [Предложение удалено]. ")
                                {
                                    info.AddText("||     Предложение №" + (k + 1) + " отсутствует в новом документе\n", Color.Red);
                                    AddText(Text2, sentences2[k].text, Color.Red);
                                    AddText(Text1, sentences1[k].text, Color.LimeGreen);
                                }
                                else
                                {
                                    info.AddText("||     Предложение №" + (k + 1) + " изменилось\n", Color.Orange);
                                    AddText(Text1, sentences1[k].text, Color.Orange);
                                    AddText(Text2, sentences2[k].text, Color.Orange);
                                }
                            }
                        }
                    }
                }
            }
            info.Focus();
        }

        private void Compare_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < formMain.idChangedFiles.Count(); i++)
            {
                comboBoxAct.Items.Add(formMain.idChangedFiles[i]);
            }
        }

        private void Compare_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMain.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxAct.Text == "")
            {
                MessageBox.Show("Выберете файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Clipboard.SetText("КР" + comboBoxAct.Text);
            }
        }
    }
}