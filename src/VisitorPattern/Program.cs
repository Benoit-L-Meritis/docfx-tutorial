using VisitorPattern.Domain.Shapes;
using VisitorPattern.Samples;
using VisitorPattern.Visitor;

Console.WriteLine("Visitor Pattern Kata");

Console.WriteLine("STEP 1");

// Afficher la surface de chaque forme triée de la plus grande à la plus petite issues de Shapes.Samples

Shapes
.Samples
.Select(shape => shape.Area())
.OrderByDescending(area => area)
.ToList()
.ForEach(Console.WriteLine);

Console.WriteLine("------------------------");

Console.WriteLine("STEP 2");

// Ajouter le type de la forme dans le résultat

Shapes
.Samples
.SelectMany(shape => new[] { (Name: shape.ShapeName(), Area: shape.Area()) })
.OrderByDescending(shape => shape.Area)
.ToList()
.ForEach(shape => Console.WriteLine("La forme {0} a une surface de {1}", shape.Name, shape.Area));


Console.WriteLine("------------------------");

Console.WriteLine("STEP 3");

// Ajouter une mécanique permettant de mettre en place un afficheur de forme que je puisse modifier
// aisément sans modifier le contrat de départ des formes

ShapePrinter printer = new();
Shapes
.Samples
.ToList()
.ForEach(shape => ((IPrintabeShape)shape).Print(printer));
