using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using CefSharp;
using CefSharp.WinForms;

namespace YouTubePronunciationFinder
{

    public partial class Form1 : Form
    {
        private ChromiumWebBrowser browser;

        public Form1()
        {
            InitializeComponent();

            // Initialize CefSharp
            Cef.Initialize(new CefSettings());

            // Create a new browser instance
            browser = new ChromiumWebBrowser("about:blank");
            browser.Dock = DockStyle.Fill;

            // Add the browser to the panel
            panelBrowser.Controls.Add(browser);
        }

        private async Task SearchYouTube(string query)
        {
            string apiKey = "YOUR_API_KEY"; // Replace with your API key
            string url = $"https://www.googleapis.com/youtube/v3/search?part=snippet&q={query} pronunciation&type=video&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var json = JObject.Parse(response);

                lstResults.Items.Clear();

                foreach (var item in json["items"])
                {
                    string title = item["snippet"]["title"].ToString();
                    string videoId = item["id"]["videoId"].ToString();
                    lstResults.Items.Add(new { Title = title, VideoId = videoId });
                }
            }
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string word = txtWord.Text;
            await SearchYouTube(word);
        }

        private void lstResults_DoubleClick(object sender, EventArgs e)
        {
            //if (lstResults.SelectedItem != null)
            //{
            //    dynamic selected = lstResults.SelectedItem;
            //    string videoId = selected.VideoId;
            //    // webBrowser.Navigate($"https://www.youtube.com/watch?v={videoId}");
            //    System.Diagnostics.Process.Start($"https://www.youtube.com/watch?v={videoId}");

            //}
            if (lstResults.SelectedItem != null)
            {
                dynamic selected = lstResults.SelectedItem;
                string videoId = selected.VideoId;
                string url = $"https://www.youtube.com/embed/{videoId}?autoplay=1";

                // Load the video in the embedded browser
                browser.Load(url);
                // Ensure the browser takes the full size of the panel
                browser.Dock = DockStyle.Fill;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Cef.Shutdown();
            base.OnFormClosing(e);
        }

    }
}
