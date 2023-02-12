// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="OxyPlot">
//   Copyright (c) 2014 OxyPlot contributors
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AvaloniaExamples.Examples.FlyoutDemo
{
    using System;
    using Avalonia.Controls;

    using AvaloniaExamples;
    using OxyPlot;
    using OxyPlot.Series;
    using OxyPlot.Avalonia;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Example("Flyouts and other temporary visual elements.")]
    public partial class MainWindow : Avalonia.Controls.Window
    {
        public PlotModel Plot1 { get; }
        public PlotModel Plot2 { get; }

        public MainWindow()
        {
            this.InitializeComponent();

            this.Plot1 = CreatePlot("Plot1");
            this.Plot2 = CreatePlot("Plot2");

            this.DataContext = this;
        }

        private void InitializeComponent()
        {
            Avalonia.Markup.Xaml.AvaloniaXamlLoader.Load(this);
        }

        private static PlotModel CreatePlot(string title)
        {
            var plot = new PlotModel() { Title = title };

            var sinc = new FunctionSeries(x => Math.Sin(x * Math.PI) / (x * Math.PI), -5, +5, 0.01, "Sinc");
            plot.Series.Add(sinc);

            return plot;
        }

        public void SwapPlot()
        {
            var plot = this.FindControl<PlotView>("SwappyPlot");
            var left = this.FindControl<Grid>("Left");
            var right = this.FindControl<Grid>("Right");

            if (plot.Parent == left)
            {
                left.Children.Remove(plot);
                right.Children.Add(plot);
            }
            else
            {
                right.Children.Remove(plot);
                left.Children.Add(plot);
            }
        }
    }
}