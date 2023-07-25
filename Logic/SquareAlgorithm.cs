using System;

namespace Fractals.Logic;

internal class SquareAlgorithm : IAlgorithm
{
    private readonly IDrawer _drawer;

    public SquareAlgorithm(IDrawer drawer)
    {
        _drawer = drawer;
    }

    public void Start(int depth, float dx, float dy)
    {
        if (depth > 0)
        {
            depth--;

            Start(depth, dx, dy);
            JumpToNextColumn(depth, dx, dy);
            Start(depth, dx, dy);
            JumpToNextColumn(depth, dx, dy);
            Start(depth, dx, dy);
            JumpToNextColumn(depth, dx, dy);

            JumpToNextRow(depth, dx, dy);

            Start(depth, dx, dy);
            JumpToNextColumn(depth, dx, dy);
            JumpToNextColumn(depth, dx, dy);
            Start(depth, dx, dy);
            JumpToNextColumn(depth, dx, dy);

            JumpToNextRow(depth, dx, dy);

            Start(depth, dx, dy);
            JumpToNextColumn(depth, dx, dy);
            Start(depth, dx, dy);
            JumpToNextColumn(depth, dx, dy);
            Start(depth, dx, dy);

            JumpToStart(depth, dx, dy);
        }
        else
        {
            _drawer.Draw(dx, dy);
        }
    }

    private void JumpToNextColumn(int depth, float dx, float dy)
    {
        _drawer.CurrentPoint = new()
        {
            X = _drawer.CurrentPoint.X + (dx * Math.Pow(3, depth)),
            Y = _drawer.CurrentPoint.Y
        };
    }

    private void JumpToNextRow(int depth, float dx, float dy)
    {
        _drawer.CurrentPoint = new()
        {
            X = _drawer.CurrentPoint.X - (3 * dx * Math.Pow(3, depth)),
            Y = _drawer.CurrentPoint.Y + (dy * Math.Pow(3, depth))
        };
    }

    private void JumpToStart(int depth, float dx, float dy)
    {
        _drawer.CurrentPoint = new()
        {
            X = _drawer.CurrentPoint.X - (2 * dx * Math.Pow(3, depth)),
            Y = _drawer.CurrentPoint.Y - (2 * dy * Math.Pow(3, depth))
        };
    }
}
