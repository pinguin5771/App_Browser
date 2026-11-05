using Microsoft.VisualBasic.Devices;
using System.Drawing.Printing;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App_Browser
{
    // select all text(only for the first click) in textBoxAddress
    public partial class Form1 : Form
    {
        private const string startupUrl = "https://developer.microsoft.com/en-us/microsoft-edge/webview2/?form=MA13LH";
        private const string googleBaseSearchUrl = "https://google.com/search?q=";

        private HistoryBag historyBag = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // about:blank

            // 1. Init WebView2 component (event subscribtion, error handling).
            InitializeWebView();

            // 2. Start WebView2 component.
            webView2Control.EnsureCoreWebView2Async();

        }

        private void InitializeWebView()
        {
            if (webView2Control != null)
            {
                webView2Control
                    .CoreWebView2InitializationCompleted
                    += (sender, e) =>
                {
                    if (e.IsSuccess)
                    {
                        webView2Control.CoreWebView2.NewWindowRequested += (sender, e3) =>
                        {
                            e3.Handled = true;
                            MakeNavigation(e3.Uri);
                        };


                        webView2Control.CoreWebView2
                            .NavigationCompleted += (sender, e2) =>
                        {
                            if (e2.IsSuccess)
                            {
                                string host = webView2Control.Source.Host;
                                string url = webView2Control.Source.AbsoluteUri;
                                string time = DateTime.Now.ToShortTimeString();

                                AddHistoryItem(host, url, time);

                                UpdateNavigationButtons();
                                UpdateNavigationUrl();
                            }
                            else
                            {
                                MessageBox.Show(
                                $"Page loading error " +
                                $"{e2.WebErrorStatus}");
                            }
                        };
                        //Load startup page
                        MakeNavigation(startupUrl);
                    }
                    else
                    {
                        MessageBox.Show($"WebView2 initialization error: {e.InitializationException.Message}");
                    }
                };
            }
        }

        private void AddHistoryItem(string host, string url, string time)
        {
            var item = new HistoryItem()
            {
                Url = url,
                FriendlyName = host,
                AccessTime = time
            };
            historyBag.Add(item);
            listBoxHistoryItems.Items.Add(item);
        }

        private void MakeNavigation(string url)
        {
            if(!url.Contains("https://") && !url.Contains("http://"))
            {
                // by direct link(https://dfdfgdf)
                // Do nothing
                // by search query("red car") -> "https://google.com/search?q=red car"
                url = googleBaseSearchUrl + url;
            }
            
            // if https OR http exists -> url start = url finish
            // https://dfdfgdf

            
            // active
            webView2Control.Source = new Uri(url);
        }

        private string GetCurrentUrl() =>
            webView2Control?.Source?.AbsoluteUri ?? string.Empty;

        private void UpdateNavigationButtons()
        {
            buttonPrev.Enabled = webView2Control.CanGoBack;
            buttonNext.Enabled = webView2Control.CanGoForward;
            buttonReload.Enabled = !string.IsNullOrEmpty(GetCurrentUrl());
        }

        private void UpdateNavigationUrl()
        {
            textBoxAddress.Text = GetCurrentUrl();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            webView2Control.GoBack();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            webView2Control.GoForward();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            webView2Control.Reload();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            MakeNavigation(textBoxAddress.Text);
        }

        private void textBoxAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                MakeNavigation(textBoxAddress.Text);
                e.SuppressKeyPress = true;
            }
        }
    }
}

//subscribe to event 
//NewWindowRequested

//and forbid to create the new Window
