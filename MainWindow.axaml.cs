using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Diagnostics;
using System.IO;
using System;

namespace moduleApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OpenManual_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManualWindow();

            newWindow.Show();
            
        }

        private void OpenTelegram_Click(object sender, RoutedEventArgs e)
        {
            OpenProgramWindow("TelegramGroup", "telegram-desktop", "Открыть Telegram", "300");
        }

        private void OpenChromium_Click(object sender, RoutedEventArgs e)
        {
            OpenProgramWindow("ChromeGroup", "chromium", "Открыть Chrome", "500");
        }

        private void OpenFirefox_Click(object sender, RoutedEventArgs e)
        {
            OpenProgramWindow("FirefoxGroup", "firefox", "Открыть Firefox", "500");
        }

        private void OpenAndroid_Click(object sender, RoutedEventArgs e)
        {
            OpenProgramWindow("AndroidStudioGroup", "android-studio", "Открыть Android Studio", "1000");
        }

        private void OpenVirtmng_Click(object sender, RoutedEventArgs e)
        {
            OpenProgramWindow("VirtGroup", "virt-manager", "Открыть Virtual Manager", "300");
        }

        private void OpenCode_Click(object sender, RoutedEventArgs e)
        {
            OpenProgramWindow("CodeGroup", "code", "Открыть Visual Studio Code", "300");
        }

        private void OpenNewWindow_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CustomWindow();
            newWindow.Show();
        }

        private void OpenGSM_Click(object sender, RoutedEventArgs e)
        {
            RunProcess("/home/ssofixd/Documents/C++/code/cshelper", "gnome-system-monitor", "monitorgroup", "200M");
        }

        private void OpenProgramWindow(string groupName, string programExec, string windowTitle, string countMB)
        {
            var newWindow = new SecondWindow()
            {
                ProgramExecute = programExec,
                Title = windowTitle
            };
            newWindow.FindControl<TextBox>("name_group").Text = groupName;
            newWindow.FindControl<TextBox>("count_MB").Text = countMB;
            newWindow.SetWindowTitle(windowTitle);
            newWindow.Show();
        }

        private void RunProcess(string filePath, string programExec, string nameGroup, string countMB)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                

                using (StreamWriter sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine(programExec);
                        sw.WriteLine(nameGroup);
                        sw.WriteLine(countMB);
                    }
                }

                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
            }
        }
    }
}
