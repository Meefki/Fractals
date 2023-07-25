namespace Fractals.Logic;

internal class CurveAlgorithm : IAlgorithm
{
    private readonly IDrawer _drawer;

    public CurveAlgorithm(IDrawer drawer)
    {
        _drawer = drawer;
    }

    public void Start(int depth, float dx, float dy)
    {
        Right(depth, dx, dy);
        _drawer.Draw(dx, dy);
        Down(depth, dx, dy);
        _drawer.Draw(-dx, dy);
        Left(depth, dx, dy);
        _drawer.Draw(-dx, -dy);
        Up(depth, dx, dy);
        _drawer.Draw(dx, -dy);
    }

    private void Right(int depth, float dx, float dy)
    {
        if (depth > 0)
        {
            depth--;

            Right(depth, dx, dy);
            _drawer.Draw(dx, dy);
            Down(depth, dx, dy);
            _drawer.Draw(2 * dx, 0);
            Up(depth, dx, dy);
            _drawer.Draw(dx, -dy);
            Right(depth, dx, dy);
        }
    }

    private void Left(int depth, float dx, float dy)
    {
        if (depth > 0)
        {
            depth--;

            Left(depth, dx, dy);
            _drawer.Draw(-dx, -dy);
            Up(depth, dx, dy);
            _drawer.Draw(-2 * dy, 0);
            Down(depth, dx, dy);
            _drawer.Draw(-dx, dy);
            Left(depth, dx, dy);
        }
    }

    private void Down(int depth, float dx, float dy)
    {
        if (depth > 0)
        {
            depth--;

            Down(depth, dx, dy);
            _drawer.Draw(-dx, dy);
            Left(depth, dx, dy);
            _drawer.Draw(0, 2 * dy);
            Right(depth, dx, dy);
            _drawer.Draw(dx, dy);
            Down(depth, dx, dy);
        }
    }

    private void Up(int depth, float dx, float dy)
    {
        if (depth > 0)
        {
            depth--;

            Up(depth, dx, dy);
            _drawer.Draw(dx, -dy);
            Right(depth, dx, dy);
            _drawer.Draw(0, -2 * dy);
            Left(depth, dx, dy);
            _drawer.Draw(-dx, -dy);
            Up(depth, dx, dy);
        }
    }
}
