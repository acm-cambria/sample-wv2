using Microsoft.Web.WebView2.Core;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private const string Url = "https://www.racingandsports.com.au/form-guide/thoroughbred/australia/ascot/2024-12-07qweq=1231";
        public Form1()
        {
            
            try
            {
                InitializeComponent();
                _ = InitializeAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async Task InitializeAsync()
        {
            CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions("--allow-insecure-localhost,--disable-web-security, --allow-insecure-localhost");//--disable-web-security, --allow-insecure-localhost
            CoreWebView2Environment environment = await CoreWebView2Environment.CreateAsync(null, null, options);
            try
            {
                await webView21.EnsureCoreWebView2Async(environment);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            webView21.CoreWebView2.CookieManager.DeleteAllCookies();
            var x = await webView21.CoreWebView2.CallDevToolsProtocolMethodAsync("Network.clearBrowserCookies", "{}");
            Thread.Sleep(8000);

            webView21.CoreWebView2.Navigate(Url);

        }

    }
}
