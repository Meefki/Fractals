using Fractals.Models;
using System.Windows.Controls;

namespace Fractals.Logic;

internal interface IDrawer
{
    Panel Canvas { get; }
    Point StartPoint { get; }
    Point CurrentPoint { get; set; }
    void Draw(float dx, float dy);
}
