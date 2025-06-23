namespace VisitorPattern.Domain.Shapes;

/// <summary>
/// Represents a geometric circle with a specified radius.
/// </summary>
/// <remarks>A circle is a two-dimensional shape defined by its radius. This class provides methods to calculate 
/// the area and perimeter of the circle, as well as a method to print its details using a specified  printer.</remarks>
/// <param name="radius"></param>
/// <inheritdoc cref="IShape"/>
public class Circle(double radius) : Shape, IPrintabeShape
{
    /// <inheritdoc/>
    public override double Area() => Math.PI * Math.Pow(radius, 2);
    
    /// <inheritdoc/>
    public override double Perimeter() => 2 * Math.PI * radius;

    /// <inheritdoc/>
    public override string ShapeName() => nameof(Circle);

    /// <inheritdoc/>
    public void Print(IShapePrinter printer) => printer.Print(this);
}
