namespace VisitorPattern.Domain.Shapes;

/// <summary>
/// Abstract base class representing a geometric shape.
/// </summary>
/// <inheritdoc cref="IShape" />
public abstract class Shape : IShape
{
    /// <inheritdoc/>
    public abstract double Area();
    
    /// <inheritdoc/>
    public abstract double Perimeter();

    /// <inheritdoc/>
    public abstract string ShapeName();
}
