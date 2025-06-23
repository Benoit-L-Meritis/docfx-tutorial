# Visitor Pattern

The **Visitor pattern** is a behavioral design pattern that lets you separate algorithms from the objects on which they operate. It allows you to add new operations to existing object structures without modifying those structures.

## When to Use

- When you need to perform operations across a set of objects with different types.
- When you want to add new operations without changing the classes of the elements on which it operates.

## Structure

- **Element**: The object structure being visited (e.g., shapes).
- **Visitor**: Defines a new operation to perform on elements.
- **Accept**: Method in the element that takes a visitor and calls its visit method.

## Example in "C#"

This example demonstrates how the Visitor pattern allows you to define new operations (like area calculation) without modifying the shape classes themselves.

```csharp
// Visitor interface
typedef interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Rectangle rectangle);
}

// Element interface
interface IShape
{
    void Accept(IShapeVisitor visitor);
}

// Concrete element
class Circle : IShape
{
    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}

class Rectangle : IShape
{
    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}

// Concrete visitor
class AreaCalculator : IShapeVisitor
{
    public void Visit(Circle circle) { /* calculate area */ }
    public void Visit(Rectangle rectangle) { /* calculate area */ }
}

// Usage
var shapes = new List<IShape> { new Circle(), new Rectangle() };
var areaCalculator = new AreaCalculator();
foreach (var shape in shapes)
{
    shape.Accept(areaCalculator);
}
```

## Concrete implementation

[!code-csharp[](../Program.cs?highlight=3,39-43)]
