using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Compare : Form
    {
        Info info = new Info();
        Email email = new Email();
        public Compare()
        {
            InitializeComponent();
            WinResize();
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
            email.Show();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            WinResize();
        }

        void WinResize()
        {
            Text1.Size = new Size(this.Width / 2 - 30, Text1.Height);
            Text2.Size = new Size(this.Width / 2 - 30, Text2.Height);
            Text2.Location = new Point(Text1.Width + Text1.Location.X + 15, Text2.Location.Y);
            buttonReset.Location = new Point(Text2.Location.X, buttonReset.Location.Y);
            openSingleDoc2.Location = new Point(Text2.Location.X, openSingleDoc2.Location.Y);
            labelText1.Location = new Point(openSingleDoc1.Location.X + openSingleDoc1.Width, labelText1.Location.Y);
            labelText2.Location = new Point(openSingleDoc2.Location.X + openSingleDoc2.Width, labelText2.Location.Y);
        }

        private void openSingleDoc2_Click(object sender, EventArgs e)
        {
            string fileContent = "";
            string filePath;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            Text2.Text = fileContent;
        }

        private void openSingleDoc1_Click(object sender, EventArgs e)
        {
            string fileContent = "";
            string filePath;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            Text1.Text = fileContent;
        }

        private void buttonMatch_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonShowAnalyze_Click(object sender, EventArgs e)
        {
            info.Show();
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
            Text1.Text = "Предложение 1, предложение 1. Предложение 2. Предложение 3, текст текст текст.\r\nПредложение 4.\r\nПредложение 5.\r\nПредложение 6, текст.";
            Text2.Text = "Предложение 1, предложение 1. Предложение 2. Предложение 3, текст текст.\r\nПредложение 4.";
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
                info.AddText("Документ изменился\n", Color.Yellow);
                info.AddText("=====================================\n", Color.Cyan);
                //Списки параграфов текста 1 и всех предложений этих абзацев
                List<SentencesClass> sentences1 = new List<SentencesClass>();
                List<string> paragraphs1 = new List<string>();
                //Заполнение списка абзацев
                for (int i = 0; i < Text1.Text.Split('\n').Length; i++)
                    paragraphs1.Add(Text1.Text.Split('\n')[i]);
                info.AddText("• Количество абзацев в старом документе: " + paragraphs1.Count + "\n", Color.White);
                if (Text1.Text.Split('\n').Length < Text2.Text.Split('\n').Length)
                    for (int i = 0; i < Math.Abs(Text1.Text.Split('\n').Length - Text2.Text.Split('\n').Length); i++)
                        paragraphs1.Add("[Абзац отсутствует]");

                //Списки параграфов текста 2 и всех предложений этих абзацев
                List<SentencesClass> sentences2 = new List<SentencesClass>();
                List<string> paragraphs2 = new List<string>();
                //Заполнение списка абзацев
                for (int i = 0; i < Text2.Text.Split('\n').Length; i++)
                    paragraphs2.Add(Text2.Text.Split('\n')[i]);
                info.AddText("• Количество абзацев в новом документе: " + paragraphs2.Count + "\n", Color.White);
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


                info.AddText("• Количество предложений в старом документе: " + sentences1.Count + "\n", Color.White);
                info.AddText("• Количество предложений в новом документе: " + sentences2.Count + "\n", Color.White);
                info.AddText("=====================================\n", Color.Cyan);

                Text1.Text = "";
                Text2.Text = "";
                //Проверка второго уровня: Абзацы целиком
                for (int i = 0; i < paragraphs1.Count; i++)
                {

                    if (paragraphs1[i] == paragraphs2[i])
                    {
                        info.AddText("• Абзац №" + (i + 1) + " не изменился\n", Color.White);
                        AddText(Text1, paragraphs1[i] + "\n", Color.White);
                        AddText(Text2, paragraphs2[i] + "\n", Color.White);

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
                        info.AddText("• Абзац №" + (i + 1) + " изменился:\n", Color.Yellow);
                        //Проверка третьего уровня: Предложения целиком
                        for (int k = 0; k < sentences1.Count; k++)
                        {
                            if (sentences1[k].paragraphID == i && sentences2[k].paragraphID == i)
                            {
                                if (sentences1[k].text == sentences2[k].text)
                                {
                                    info.AddText("||     Предложение №" + (k + 1) + " без изменений\n", Color.White);
                                    AddText(Text1, sentences1[k].text, Color.White);
                                    AddText(Text2, sentences2[k].text, Color.White);
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
                                    info.AddText("||     Предложение №" + (k + 1) + " изменилось\n", Color.Yellow);
                                    AddText(Text1, sentences1[k].text, Color.Yellow);
                                    AddText(Text2, sentences2[k].text, Color.Yellow);
                                }
                            }
                        }
                    }
                }
            }
            info.Focus();
        }
    }
}