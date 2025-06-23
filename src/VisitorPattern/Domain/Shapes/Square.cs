namespace VisitorPattern.Domain.Shapes;

/// <summary>
/// Represents a square shape wich is a specific type of rectangle where all sides are equal.
/// </summary>
/// <remarks>
/// <para>
/// Primary constructor has only one parameter <c>width</c>, which is the width of the square. The height is set to the same value, making it a square.
/// </para>
/// <para>
/// <see cref="Rectangle"/> is used as the base class to inherit common properties and methods for area and perimeter calculations.
/// </para>
/// </remarks>
/// <param name="width"></param>
public class Square(double width) : Rectangle(heigth: width, width: width), IPrintabeShape
{
    /// <inheritdoc/>
    public override string ShapeName() => nameof(Square);

    /// <inheritdoc/>
    public new void Print(IShapePrinter printer) => printer.Print(this);
}
