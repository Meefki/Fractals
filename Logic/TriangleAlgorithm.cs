using System;
using System.Diagnostics;

namespace Fractals.Logic;

internal class TriangleAlgorithm : IAlgorithm
{
    private readonly IDrawer _drawer;

    public TriangleAlgorithm(IDrawer drawer)
    {
        _drawer = drawer;
    }

    public void Start(int depth, float dx, float dy)
    {
        //Debug.WriteLine($"\tDepth: {depth} \tX: {(_drawer.CurrentPoint.X - _drawer.StartPoint.X) / dx * 10} \tY: {(_drawer.CurrentPoint.Y - _drawer.StartPoint.Y) / dy * 10}");

        if (depth > 0)
        {
            depth--;

            Start(depth, dx, dy);

            _drawer.CurrentPoint = new()
            {
                X = _drawer.CurrentPoint.X + (dx * Math.Pow(2, depth)),
                Y = _drawer.CurrentPoint.Y
            };

            Start(depth, dx, dy);

            _drawer.CurrentPoint = new()
            {
                X = _drawer.CurrentPoint.X - (dx / 2 * Math.Pow(2, depth)),
                Y = _drawer.CurrentPoint.Y + (dy * Math.Pow(2, depth)),
            };

            Start(depth, dx, dy);

            _drawer.CurrentPoint = new()
            {
                X = _drawer.CurrentPoint.X - (dx / 2 * Math.Pow(2, depth)),
                Y = _drawer.CurrentPoint.Y - (dy * Math.Pow(2, depth)),
            };
        }
        else
        {
            _drawer.Draw(dx, dy);
        }
    }
}
