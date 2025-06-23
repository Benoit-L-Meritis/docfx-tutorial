namespace VisitorPattern.Domain.Shapes;

/// <summary>
/// Represents a rectangle shape with a specified height and width.
/// </summary>
/// <remarks>A rectangle is a quadrilateral with opposite sides of equal length. This class provides methods to 
/// calculate the area and perimeter of the rectangle, as well as functionality to print its details  using a specified
/// printer.</remarks>
/// <param name="heigth"></param>
/// <param name="width"></param>
public class Rectangle(double heigth, double width) : Shape, IPrintabeShape
{
    /// <summary>
    /// With of the rectangle.
    /// </summary>
    public double Width { get => width; }

    /// <inheritdoc/>
    public override sealed double Area() => heigth * width;

    /// <inheritdoc/>
    public override sealed double Perimeter() => (heigth + width) * 2;

    /// <inheritdoc/>
    public override string ShapeName() => nameof(Rectangle);

    /// <inheritdoc/>
    public void Print(IShapePrinter printer) => printer.Print(this);
}
