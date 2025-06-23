# Domain: Shapes

This folder contains the core shape abstractions and implementations for the Visitor Pattern Kata.

## Classes & Interfaces

### `IShape`
Interface representing a geometric shape. Defines methods for:
- `Area()`: Returns the area of the shape.
- `Perimeter()`: Returns the perimeter of the shape.
- `ShapeName()`: Returns the name of the shape.

### `Shape`
Abstract base class implementing `IShape`. Provides the base for all geometric shapes, requiring derived classes to implement area, perimeter, and name.

### `Rectangle`
Represents a rectangle with a specified height and width. Inherits from `Shape` and implements `IPrintabeShape`.
- Properties: `Width`
- Methods: `Area()`, `Perimeter()`, `ShapeName()`, `Print(IShapePrinter)`

### `Square`
Represents a square, a specific type of rectangle where all sides are equal. Inherits from `Rectangle` and implements `IPrintabeShape`.
- Constructor takes a single `width` parameter (used for both height and width).
- Methods: `ShapeName()`, `Print(IShapePrinter)`

### `Circle`
Represents a circle with a specified radius. Inherits from `Shape` and implements `IPrintabeShape`.
- Methods: `Area()`, `Perimeter()`, `ShapeName()`, `Print(IShapePrinter)`

### `IPrintabeShape`
Interface for shapes that can be printed using a shape printer.
- Method: `Print(IShapePrinter printer)`

### `IShapePrinter`
Visitor interface for printing shapes. Defines overloaded `Print` methods for each shape type:
- `Print(Rectangle rectangle)`
- `Print(Square square)`
- `Print(Circle circle)`
