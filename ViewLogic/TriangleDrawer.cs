using Fractals.Logic;
using Fractals.Models;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals.ViewLogic;

internal class TriangleDrawer : IDrawer
{
    private int _counter = 0;

    public Panel Canvas { get; init; }

    public Point StartPoint { get; init; }

    public Point CurrentPoint { get; set; }

    public TriangleDrawer(Panel canvas, Point startPoint)
    {
        Canvas = canvas;
        StartPoint = startPoint;
        CurrentPoint = startPoint;
    }

    public void Draw(float dx, float dy)
    {
        SolidColorBrush brush = new(Color.FromRgb(0, 0, 0));
        Shape triangle = GetTriangle(brush, CurrentPoint, dx, dy);

        Canvas.Children.Add(triangle);
    }

    private Polygon GetTriangle(Brush brush, Point startPoint, double dx, double dy)
    {
        Polygon polygon = new()
        {
            Fill = brush,
            Stroke = brush,
            StrokeThickness = 1,

            Points = new PointCollection()
            {
                new System.Windows.Point { X = startPoint.X, Y = startPoint.Y },
                new System.Windows.Point { X = startPoint.X + dx, Y = startPoint.Y },
                new System.Windows.Point { X = startPoint.X + dx/2, Y = startPoint.Y + dy },
            }
        };

        return polygon;
    }
}
