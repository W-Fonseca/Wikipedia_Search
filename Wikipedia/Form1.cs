using System;
using System.Linq;
using System.Windows.Forms;
using HtmlAgilityPack;
using ScrapySharp.Extensions;


namespace Wikipedia {

    public partial class Form1 : Form {
          
        public Form1() {
            InitializeComponent();
           
        }
        private void button1_Click(object sender, EventArgs e) {

            textBox1.ResetText();
            var webGet = new HtmlWeb();
            if (webGet.Load("https://pt.wikipedia.org/w/index.php?search=" + Pesquisa.Text) is HtmlAgilityPack.HtmlDocument document) {
                var nodes = document.DocumentNode.CssSelect("body").ToList().CssSelect("div.mw-parser-output").Single().CssSelect("p").Count();
                for (int i = 0; i < nodes; i++) {
                    textBox1.Text += document.DocumentNode.CssSelect("body").ToList().CssSelect("div.mw-parser-output").Single().CssSelect("p").ElementAt(i).InnerText;
                    textBox1.Text += Environment.NewLine;
                    textBox1.Text += Environment.NewLine;
                    textBox1.Visible = true;
                    Form1.ActiveForm.Size = new System.Drawing.Size(445, 419);
                }
            }
        }

        private void Pesquisa_TextChanged(object sender, EventArgs e) {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {
            
        }
    }
}
