using System.Collections.Generic;
using System.Text;
using VisitorPattern.Domain.Shapes;

namespace VisitorPattern.Visitor;

/// <summary>
/// Concrete visitor implementation for printing shapes.
/// </summary>
/// <remarks>
/// <para>
/// Each methods permits printing the details of a specific shape without giving the responsibility of how to print the shape to the shape itself.
/// </para>
/// <para>
/// As is, we can add new shapes without modifying this class, adhering to the Open/Closed Principle.
/// </para>
/// <para>
/// <example>
/// This is an example of how to use the ShapePrinter class:
/// <code>
/// IPrintabeShape mySquare = new Square(5);
/// ShapePrinter shapePrinter = new();
/// mySquare.Print(shapePrinter);
/// </code>
/// </example>
/// </para>
/// <para>
/// Supported shapes include:
///     <list type="bullet">
///         <item>
///             <term>Rectangle</term>
///             <description>Rectangle printer with area and perimeter</description>
///         </item>
///         <item>
///             <term>Circle</term>
///             <description>Circle printer with area and perimeter</description>
///         </item>
///         <item>
///             <term>Square</term>
///             <description>Square printer with area and perimeter and a representation of the square in ASCII Art</description>
///         </item>
///     </list>
/// </para>
/// <para>
/// For more details about XML documentation, see <see href="https://learn.microsoft.com/dotnet/csharp/programming-guide/xmldoc/"/>.
/// </para>
/// </remarks>
/// <inheritdoc cref="IShapePrinter" />
public class ShapePrinter : IShapePrinter
{
    /// <inheritdoc/>
    public void Print(Rectangle rectangle)
    {
        Console.WriteLine($"La forme {rectangle.ShapeName()} a une surface de {rectangle.Area()} et un périmètre de {rectangle.Perimeter()}");
    }

    /// <inheritdoc/>
    public void Print(Square square)
    {
        Console.WriteLine($"La forme {square.ShapeName()} a une surface de {square.Area()} et un périmètre de {square.Perimeter()}");

        int width = (int)square.Width;

        string GenerateLine(Func<int, bool> condition)
        {
            return string.Join("", Enumerable.Range(1, width).Select(x => condition(x) ? "* " : "  "));
        }

        StringBuilder builder = new();
        builder.AppendLine(GenerateLine(x => true));
        builder.Append(string.Join(Environment.NewLine, Enumerable.Repeat(GenerateLine(x => x == 1 || x == width), width - 2)));
        builder.AppendLine();
        builder.AppendLine(GenerateLine(x => true));
        Console.WriteLine(builder.ToString());
    }

    /// <inheritdoc/>
    public void Print(Circle circle)
    {
        Console.WriteLine($"La forme {circle.ShapeName()} a une surface de {circle.Area()} et un périmètre de {circle.Perimeter()}");
    }

    /// <summary>
    /// Prints the specified triangle to the output.
    /// </summary>
    /// <param name="triangle">The triangle object to be printed. Must not be null.</param>
    /// <exception cref="NotImplementedException">Thrown when the method is not yet implemented.</exception>
    public void Print(object triangle)
    {
        throw new NotImplementedException("Printing triangles is not implemented yet.");
    }
}
