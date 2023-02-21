namespace WindowsFormsApp1
{
    partial class Compare
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compare));
            this.Text1 = new System.Windows.Forms.RichTextBox();
            this.Text2 = new System.Windows.Forms.RichTextBox();
            this.labelText1 = new System.Windows.Forms.Label();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.buttonSendNotification = new System.Windows.Forms.Button();
            this.buttonShowAnalyze = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.openSingleDoc2 = new System.Windows.Forms.Button();
            this.labelText2 = new System.Windows.Forms.Label();
            this.comboBoxAct = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Text1
            // 
            this.Text1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Text1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Text1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Text1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.Location = new System.Drawing.Point(11, 58);
            this.Text1.Margin = new System.Windows.Forms.Padding(2);
            this.Text1.Name = "Text1";
            this.Text1.ReadOnly = true;
            this.Text1.Size = new System.Drawing.Size(653, 600);
            this.Text1.TabIndex = 0;
            this.Text1.Text = "";
            // 
            // Text2
            // 
            this.Text2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Text2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Text2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Text2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Text2.ForeColor = System.Drawing.Color.Black;
            this.Text2.Location = new System.Drawing.Point(686, 58);
            this.Text2.Margin = new System.Windows.Forms.Padding(2);
            this.Text2.Name = "Text2";
            this.Text2.ReadOnly = true;
            this.Text2.Size = new System.Drawing.Size(653, 600);
            this.Text2.TabIndex = 1;
            this.Text2.Text = "";
            // 
            // labelText1
            // 
            this.labelText1.AutoSize = true;
            this.labelText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelText1.ForeColor = System.Drawing.Color.Black;
            this.labelText1.Location = new System.Drawing.Point(7, 20);
            this.labelText1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelText1.Name = "labelText1";
            this.labelText1.Size = new System.Drawing.Size(114, 20);
            this.labelText1.TabIndex = 2;
            this.labelText1.Text = "Старый текст";
            // 
            // buttonCompare
            // 
            this.buttonCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(123)))));
            this.buttonCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCompare.ForeColor = System.Drawing.Color.White;
            this.buttonCompare.Location = new System.Drawing.Point(11, 683);
            this.buttonCompare.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(135, 32);
            this.buttonCompare.TabIndex = 4;
            this.buttonCompare.Text = "⚖ Сравнить";
            this.buttonCompare.UseVisualStyleBackColor = false;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // buttonSendNotification
            // 
            this.buttonSendNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(123)))));
            this.buttonSendNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSendNotification.ForeColor = System.Drawing.Color.White;
            this.buttonSendNotification.Location = new System.Drawing.Point(1064, 683);
            this.buttonSendNotification.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSendNotification.Name = "buttonSendNotification";
            this.buttonSendNotification.Size = new System.Drawing.Size(275, 32);
            this.buttonSendNotification.TabIndex = 7;
            this.buttonSendNotification.Text = "📩 Отправить уведомление";
            this.buttonSendNotification.UseVisualStyleBackColor = false;
            this.buttonSendNotification.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonShowAnalyze
            // 
            this.buttonShowAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShowAnalyze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(123)))));
            this.buttonShowAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowAnalyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShowAnalyze.ForeColor = System.Drawing.Color.White;
            this.buttonShowAnalyze.Location = new System.Drawing.Point(150, 683);
            this.buttonShowAnalyze.Margin = new System.Windows.Forms.Padding(2);
            this.buttonShowAnalyze.Name = "buttonShowAnalyze";
            this.buttonShowAnalyze.Size = new System.Drawing.Size(194, 32);
            this.buttonShowAnalyze.TabIndex = 8;
            this.buttonShowAnalyze.Text = "🖹 Показать анализ";
            this.buttonShowAnalyze.UseVisualStyleBackColor = false;
            this.buttonShowAnalyze.Click += new System.EventHandler(this.buttonShowAnalyze_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(123)))));
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReset.ForeColor = System.Drawing.Color.White;
            this.buttonReset.Location = new System.Drawing.Point(534, 683);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(130, 32);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "↻ Сбросить";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // openSingleDoc2
            // 
            this.openSingleDoc2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openSingleDoc2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(123)))));
            this.openSingleDoc2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openSingleDoc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openSingleDoc2.ForeColor = System.Drawing.Color.White;
            this.openSingleDoc2.Location = new System.Drawing.Point(1153, 11);
            this.openSingleDoc2.Margin = new System.Windows.Forms.Padding(2);
            this.openSingleDoc2.Name = "openSingleDoc2";
            this.openSingleDoc2.Size = new System.Drawing.Size(186, 32);
            this.openSingleDoc2.TabIndex = 11;
            this.openSingleDoc2.Text = "🗁 Открыть документ";
            this.openSingleDoc2.UseVisualStyleBackColor = false;
            this.openSingleDoc2.Click += new System.EventHandler(this.openSingleDoc2_Click);
            // 
            // labelText2
            // 
            this.labelText2.AutoSize = true;
            this.labelText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelText2.ForeColor = System.Drawing.Color.Black;
            this.labelText2.Location = new System.Drawing.Point(682, 20);
            this.labelText2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelText2.Name = "labelText2";
            this.labelText2.Size = new System.Drawing.Size(148, 20);
            this.labelText2.TabIndex = 13;
            this.labelText2.Text = "Актуальный текст";
            // 
            // comboBoxAct
            // 
            this.comboBoxAct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxAct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAct.FormattingEnabled = true;
            this.comboBoxAct.Location = new System.Drawing.Point(946, 16);
            this.comboBoxAct.Name = "comboBoxAct";
            this.comboBoxAct.Size = new System.Drawing.Size(72, 24);
            this.comboBoxAct.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(67)))), ((int)(((byte)(123)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1026, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "Копировать id";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Compare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxAct);
            this.Controls.Add(this.labelText2);
            this.Controls.Add(this.openSingleDoc2);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonShowAnalyze);
            this.Controls.Add(this.buttonSendNotification);
            this.Controls.Add(this.buttonCompare);
            this.Controls.Add(this.labelText1);
            this.Controls.Add(this.Text2);
            this.Controls.Add(this.Text1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "Compare";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ММЦ Сравнение документов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Compare_FormClosed);
            this.Load += new System.EventHandler(this.Compare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Text1;
        private System.Windows.Forms.RichTextBox Text2;
        private System.Windows.Forms.Label labelText1;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.Button buttonSendNotification;
        private System.Windows.Forms.Button buttonShowAnalyze;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button openSingleDoc2;
        private System.Windows.Forms.Label labelText2;
        private System.Windows.Forms.ComboBox comboBoxAct;
        private System.Windows.Forms.Button button1;
    }
}

