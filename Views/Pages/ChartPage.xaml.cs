using PointProject.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace PointProject.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChartPage.xaml
    /// </summary>
    public partial class ChartPage : Page
    {
        public List<GraphPoint> points = new List<GraphPoint>();
        public ChartPage()
        {
            InitializeComponent();
            loader();

            chart.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Default"));
            chart.Series.Add(new System.Windows.Forms.DataVisualization.Charting.Series("serias"));

            chart.Series["serias"].ChartArea = "Default";
            chart.Series["serias"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            for (int i = 0; i < points.Count; i++)
            {
                chart.Series["serias"].Points.AddXY(points[i].Date, points[i].Point);
            }
        }


        void loader()
        {
            var Path = Environment.CurrentDirectory + @"/" + "data.txt";
            var file = File.ReadAllLines(Path);


            foreach (var item in file)
            {

                var separator = item.Split(';');
                points.Add(new GraphPoint
                {
                    Date = Convert.ToDateTime(separator[0]),
                    Point = Convert.ToInt32(separator[1])
                });

            }
        }

    }
}