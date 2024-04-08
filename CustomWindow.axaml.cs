using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Diagnostics;
using System.IO;
using System;

namespace moduleApp
{
    public partial class CustomWindow : Window
    {


        public CustomWindow()
        {
            InitializeComponent();

            program_execute = this.FindControl<TextBox>("program_execute");
            name_group = this.FindControl<TextBox>("name_group");
            count_MB = this.FindControl<TextBox>("count_MB");
            

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public async void MyButtonClickHandler(object sender, RoutedEventArgs e)
        {
            string programExec = program_execute.Text;
            string nameGroup = name_group.Text;
            string countMB = count_MB.Text;

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
