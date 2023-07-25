using Fractals.Logic;
using Fractals.Models;
using Fractals.ViewLogic;
using System;
using System.Windows.Controls;

namespace Fractals.Factories;

internal static class DrawerFactory
{
    public static IDrawer Create(Algorithms algorithm, Panel canvas, Point startPoint)
    {
        if (canvas is null)
            throw new ArgumentException(null, nameof(canvas));
        if (startPoint.X < 0 || startPoint.Y < 0)
            throw new ArgumentException(null, nameof(startPoint));

        return algorithm switch
        {
            Algorithms.Curve => new CurveDrawer(canvas, startPoint),
            Algorithms.Triangle => new TriangleDrawer(canvas, startPoint),
            Algorithms.Square => new SquareDrawer(canvas, startPoint),
            Algorithms.None => throw new ArgumentException(null, nameof(algorithm)),
            _ => throw new ArgumentException(null, nameof(algorithm))
        };
    }
}
