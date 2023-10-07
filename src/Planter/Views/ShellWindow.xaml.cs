﻿using Planter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Planter.Views
{
    /// <summary>
    /// ShellWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ShellWindow : Window
    {
        public ShellWindow()
        {
            InitializeComponent();
            DataContext = App.Current.Services?.GetService(typeof(ShellViewModel));
        }

        private void OnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            var anim = new DoubleAnimation();
            anim.Duration = TimeSpan.FromSeconds(0.5);
            anim.DecelerationRatio = 0.2;
            anim.To = 1;
            anim.From = 0;

            (sender as Frame)?.BeginAnimation(OpacityProperty, anim);
        }
    }
}
