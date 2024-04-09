using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Diagnostics;
using System.IO;
using System;
using System.Text.RegularExpressions;

namespace moduleApp
{
    public partial class SecondWindow : Window
    {
        public string? ProgramExecute { get; set; }

        public SecondWindow()
        {
            InitializeComponent();
            name_group = this.FindControl<TextBox>("name_group");
            count_MB = this.FindControl<TextBox>("count_MB");
            count_MB.TextChanged += CountMB_TextChanged;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void CountMB_TextChanged(object sender, EventArgs e)
        {
            // Удаляем все символы, которые не являются цифрами
            count_MB.Text = Regex.Replace(count_MB.Text, @"[^0-9]", "");
        }



        public async void MyButtonClickHandler(object sender, RoutedEventArgs e)
        {
            string programExec = ProgramExecute ?? "default-program";
            string nameGroup = name_group.Text;
            string countMB = count_MB.Text;

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "/home/ssofixd/Documents/moduleApp/Source/cshelper",
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
                this.Close();

                await process.WaitForExitAsync();

                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
            }
            
        }

        public void SetWindowTitle(string title)
        {
            this.Title = title;
        }
    }
}
