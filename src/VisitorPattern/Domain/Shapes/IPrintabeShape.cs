namespace VisitorPattern.Domain.Shapes;

/// <summary>
/// Represents a printable shape in the domain of geometric shapes.
/// </summary>
public interface IPrintabeShape
{
    /// <summary>
    /// Prints the current shape using the specified shape printer.
    /// </summary>
    /// <param name="printer">The <see cref="IShapePrinter"/> instance responsible for printing the shape. Cannot be null.</param>
    void Print(IShapePrinter printer);
}
