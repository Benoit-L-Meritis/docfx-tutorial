namespace VisitorPattern.Domain.Shapes;

/// <summary>
/// Visitor interface for printing shapes.
/// </summary>
/// <remarks>
/// Provides a methods to print the details of various geometric shapes.
/// </remarks>
public interface IShapePrinter
{
    /// <summary>
    /// Prints the details of a rectangle.
    /// </summary>
    /// <param name="rectangle"></param>
    void Print(Rectangle rectangle);

    /// <summary>
    /// Prints the details of a square.
    /// </summary>
    /// <param name="square"></param>
    void Print(Square square);

    /// <summary>
    /// Prints the details of a circle.
    /// </summary>
    /// <param name="circle"></param>
    void Print(Circle circle);
}
