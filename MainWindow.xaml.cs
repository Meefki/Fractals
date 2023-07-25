using Fractals.Factories;
using Fractals.Logic;
using Fractals.Models;
using System.Diagnostics;
using System.Windows;

namespace SerpCarpet;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        deltaLineLength.Text = "25";
        fractalDepth.Text = "2";
    }

    private void StartClick(object sender, RoutedEventArgs e)
    {
        try
        {
            float dx = float.Parse(deltaLineLength.Text);
            float dy = float.Parse(deltaLineLength.Text);
            int depth = int.Parse(fractalDepth.Text);

            Algorithms algorithmType;
            if (curveRb.IsChecked.HasValue && curveRb.IsChecked.Value)
                algorithmType = Algorithms.Curve;
            else if (triangleRb.IsChecked.HasValue && triangleRb.IsChecked.Value)
                algorithmType = Algorithms.Triangle;
            else if (squareRb.IsChecked.HasValue && squareRb.IsChecked.Value)
                algorithmType = Algorithms.Square;
            else
                return;

            contentGrid.Children.Clear();

            Fractals.Models.Point startPoint = new(0, 0);
            IDrawer drawer = DrawerFactory.Create(algorithmType, contentGrid, startPoint);
            IAlgorithm algorithm = AlgorithmFactory.Create(algorithmType, drawer);

            //Debug.WriteLine("---------------------------------------------------------------------------------------------");
            algorithm.Start(depth, dx, dy);
        }
        catch { }
    }

    private void ClearClick(object sender, RoutedEventArgs e)
    {
        contentGrid.Children.Clear();
    }
}
