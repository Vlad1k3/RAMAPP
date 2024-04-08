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

        private async void OpenManual_Click(object sender, RoutedEventArgs e){
            var newWindow = new ManualWindow();
            newWindow.Show();
        
        }

        private async void OpenTelegram_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new SecondWindow()
            {
                ProgramExecute = "telegram-desktop"
            };
            newWindow.FindControl<TextBox>("name_group").Text = "TelegramGroup";
            newWindow.FindControl<TextBox>("count_MB").Text = "300M";
            newWindow.SetWindowTitle("Открыть Telegram");
            newWindow.Show();
        }

        private async void OpenChromium_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new SecondWindow()
            {
                ProgramExecute = "chromium",
                Title = "Открыть Chrome" // Pass the title to SecondWindow
            };
            newWindow.FindControl<TextBox>("name_group").Text = "ChromeGroup";
            newWindow.FindControl<TextBox>("count_MB").Text = "500M";
            newWindow.SetWindowTitle("Открыть Chrome");
            newWindow.Show();
        }



        private async void OpenFirefox_Click(object sender, RoutedEventArgs e)
        {
            // Создаём новое окно
            var newWindow = new SecondWindow()
            {
                // Устанавливаем необходимое значение свойства
                ProgramExecute = "firefox",
                
            };
            newWindow.FindControl<TextBox>("name_group").Text = "FirefoxGroup";
            newWindow.FindControl<TextBox>("count_MB").Text = "500M";
            newWindow.SetWindowTitle("Открыть Firefox");
            newWindow.Show();
        }

        private async void OpenAndroid_Click(object sender, RoutedEventArgs e)
        {
            // Создаём новое окно
            var newWindow = new SecondWindow()
            {
                // Устанавливаем необходимое значение свойства
                ProgramExecute = "android-studio"
            };
            newWindow.FindControl<TextBox>("name_group").Text = "AndroidStudioGroup";
            newWindow.FindControl<TextBox>("count_MB").Text = "1000M";
            newWindow.SetWindowTitle("Открыть Android Studio");
            newWindow.Show();
        }


        private async void OpenCode_Click(object sender, RoutedEventArgs e)
        {
            // Создаём новое окно
            var newWindow = new SecondWindow()
            {
                // Устанавливаем необходимое значение свойства
                ProgramExecute = "code"
            };
            newWindow.FindControl<TextBox>("name_group").Text = "CodeGroup";
            newWindow.FindControl<TextBox>("count_MB").Text = "300M";
            newWindow.SetWindowTitle("Открыть Visual Studio Code");
            newWindow.Show();
        }

        private async void OpenNewWindow_Click(object sender, RoutedEventArgs e)
        {
            // Создаём новое окно
            var newWindow = new CustomWindow();

            newWindow.Show();
        }
        
        private async void OpenGSM_Click(object sender, RoutedEventArgs e)
        {
            // Создаём новое окно
            string programExec = "gnome-system-monitor";
            string nameGroup = "monitorgroup";
            string countMB = "200M";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "/home/ssofixd/Documents/C++/code/cshelper",
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

                await process.WaitForExitAsync();

                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
            }
        }
        
    }
}
