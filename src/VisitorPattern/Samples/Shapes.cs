using VisitorPattern.Domain.Shapes;

namespace VisitorPattern.Samples;

/// <summary>
/// Shapes sample collection.
/// </summary>
public static class Shapes
{
    /// <summary>
    /// Some sample shapes.
    /// </summary>
    public static IShape[] Samples
    {
        get
        {
            return
            [
                new Rectangle(2, 3),
                new Square(4),
                new Circle(15),
                new Square(13)
            ];
        }
    }
}
