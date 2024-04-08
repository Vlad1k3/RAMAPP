using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Diagnostics;
using System.IO;
using System;

namespace moduleApp
{
    public partial class ManualWindow : Window
    {


        public ManualWindow()
        {
            InitializeComponent();  
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
