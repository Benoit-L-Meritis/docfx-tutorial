namespace VisitorPattern.Domain.Shapes;

/// <summary>
/// Interface representing a geometric shape.
/// </summary>
public interface IShape
{
    /// <summary>
    /// Area of the shape.
    /// </summary>
    /// <returns></returns>
    /// <value>Double value of the shape</value>
    double Area();

    /// <summary>
    /// Perimeter of the shape.
    /// </summary>
    /// <returns></returns>
    double Perimeter();

    /// <summary>
    /// Name of the shape.
    /// </summary>
    /// <returns></returns>
    string ShapeName();
}
