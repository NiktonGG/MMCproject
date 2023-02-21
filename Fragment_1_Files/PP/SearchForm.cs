using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Edge;

namespace PP
{
    public partial class SearchForm : Form
    {
        Form1 formMain;
        IWebDriver driver = new EdgeDriver();
        public SearchForm(Form1 form)
        {
            InitializeComponent();
            formMain = form;
        }

        private List<string> getID()
        {
            driver.Navigate().GoToUrl("https://cr.minzdrav.gov.ru/clin_recomend");
            Thread.Sleep(1000);
            List<string> id = new List<string>();
            List<IWebElement> lostOfId = driver.FindElements(By.XPath("//div[@class='tab-content-block__tab-pane-item-cell tab-content-block__tab-pane-item-cell_id']/a[@class='tab-content-block__tab-pane-title-link redstyle']")).ToList();
            int i = 0;
            progressBar1.Maximum = lostOfId.Count;
            foreach (IWebElement ele in lostOfId)
            {

                id.Add(ele.Text.TrimStart('К', 'Р'));
                i++;
                progressBar1.Value = i;
                labelAmount.Text = "Нашли: " + i + " из " + lostOfId.Count;
                Application.DoEvents();
            }
            driver.Close();
            driver.Quit();
            return id;
        }

        private void SearchForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            try
            {
                formMain.idArr = getID();
            } catch
            {
                driver.Close();
                driver.Quit();
            }
            this.Close();
        }
    }
}
