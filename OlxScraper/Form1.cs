using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace OlxScraper
{
    //https://mydataprovider.com/csharp
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetHtmlPage_Click(object sender, EventArgs e)
        {
            GetResults();
        }
        public async Task<string> GetHtmlAsync(string url)
        {
            var httpclient = new HttpClient();
            var html = await httpclient.GetStringAsync(url);
            return html;
        }
        public async void GetResults()
        {
            string html = await GetHtmlAsync("https://allegro.pl/");

           var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);



            var ProductsHtml = htmlDocument.DocumentNode.Descendants("td")
                 .Where(node => node.GetAttributeValue("class", "").Equals("title-cell")).ToList();
            foreach (var a in ProductsHtml)
                Console.WriteLine(a.EndNode);

        }
    }
}
