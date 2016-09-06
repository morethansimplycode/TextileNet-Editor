using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp;
using CommonMark;
using System.Timers;
using System.IO;

namespace TextileNet_Editor
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        const String URL_BLANK = "about:blank";

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public MainWindow()
        {
            InitializeComponent();
            browser.BrowserSettings = new BrowserSettings()
            {
                OffScreenTransparentBackground = false
            };
            browser.UpdateLayout();
            refreshTimer.Elapsed += RefreshTimer_Elapsed;
        }

        private void MetroWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point onBrowser = e.GetPosition(browser);
            Boolean isOnBrowser = onBrowser.X > 0 && onBrowser.Y > 0 && onBrowser.X < browser.ActualWidth && onBrowser.Y < browser.ActualHeight;
            if (!isOnBrowser && e.LeftButton == MouseButtonState.Pressed && this.WindowState != WindowState.Maximized)
            {
                ReleaseCapture();
                SendMessage(this.CriticalHandle, WM_NCLBUTTONDOWN, new IntPtr(HT_CAPTION), IntPtr.Zero);
            }
        }

        private Timer refreshTimer = new Timer(50) { AutoReset = false };

        private void textBox_TextChanged(Object sender, TextChangedEventArgs e)
        {
            refreshTimer.Stop();
            refreshTimer.Start();
        }

        private void RefreshTimer_Elapsed(Object sender, ElapsedEventArgs e)
        {
            StringWriter sw = new StringWriter();
            String textBoxText = textBox.Dispatcher.Invoke(new Func<string>(() => textBox.Text));

            sw.WriteLine(@"<html>
                                <head>
                                </head>
                                <body>");

            CommonMarkConverter.Convert(new StringReader(textBoxText), sw);
            sw.WriteLine("</body></html>");
            textBoxText = sw.ToString();

            Application.Current.Dispatcher.Invoke(() => browser.LoadHtml(textBoxText, "http://rendering/"));
        }
    }
}

