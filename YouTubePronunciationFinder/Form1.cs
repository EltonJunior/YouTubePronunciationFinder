using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using CefSharp;
using CefSharp.WinForms;
using System.IO;

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

        private string LoadApiKey()
        {
            string filePath = "apiKey.txt";

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("API key file not found. Please create 'apiKey.txt' with your API key.");
            }

            string apiKey = File.ReadAllText(filePath).Trim();

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("API key is empty. Please ensure 'apiKey.txt' contains a valid key.");
            }

            return apiKey;
        }

        private async Task SearchYouTube(string query)
        {
            string apiKey;

            try
            {
                apiKey = LoadApiKey(); // Load API key
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if the API key is not valid
            }

            string url = $"https://www.googleapis.com/youtube/v3/search?part=snippet&q={query} pronunciation&type=video&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                try
                {

                    var response = await client.GetStringAsync(url);
                    var json = JObject.Parse(response);

                    lstResults.Items.Clear();

                    foreach (var item in json["items"])
                    {
                        string title = item["snippet"]["title"].ToString();
                        string videoId = item["id"]["videoId"].ToString();
                        string description = item["snippet"]["description"].ToString();

                        // Check if the description contains the query word
                        if (description.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            lstResults.Items.Add(new { Title = title, VideoId = videoId });
                        }
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    MessageBox.Show($"HTTP Request failed: {httpEx.Message} \n it may be caused by missing apiKey", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message} \n it may be caused by missing apiKey", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
