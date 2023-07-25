using Fractals.Logic;
using Fractals.Models;
using System;

namespace Fractals.Factories;

internal static class AlgorithmFactory
{
    public static IAlgorithm Create(Algorithms algorithm, IDrawer drawer)
    {
        return algorithm switch
        {
            Algorithms.Curve => new CurveAlgorithm(drawer),
            Algorithms.Triangle => new TriangleAlgorithm(drawer),
            Algorithms.Square => new SquareAlgorithm(drawer),
            Algorithms.None => throw new ArgumentException(null, nameof(algorithm)),
            _ => throw new ArgumentException(null, nameof(algorithm))
        };
    }
}
