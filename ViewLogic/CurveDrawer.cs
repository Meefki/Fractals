using Fractals.Logic;
using Fractals.Models;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals.ViewLogic;

internal class CurveDrawer : IDrawer
{
    public Panel Canvas { get; init; }

    public Point StartPoint { get; init; }

    public Point CurrentPoint { get; set; }

    public CurveDrawer(Panel canvas, Point startPoint)
    {
        Canvas = canvas;
        StartPoint = startPoint;
        CurrentPoint = startPoint;
    }

    public void Draw(float dx, float dy)
    {
        Line line = new()
        {
            X1 = CurrentPoint.X,
            Y1 = CurrentPoint.Y,

            X2 = CurrentPoint.X + dx,
            Y2 = CurrentPoint.Y + dy,

            StrokeThickness = 1,
            Stroke = Brushes.Black,
        };

        Canvas.Children.Add(line);

        CurrentPoint = new(CurrentPoint.X + dx, CurrentPoint.Y + dy);
    }
}
