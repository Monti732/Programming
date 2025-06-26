public interface IShape {
  void Accept(IShapeVisitor visitor);
}

public class Circle : IShape {
  public double Radius { get; }

  public Circle(double radius) {
    Radius = radius;
  }

  public void Accept(IShapeVisitor visitor) {
    visitor.VisitCircle(this);
  }
}

public class Rectangle : IShape {
  public double Width { get; }
  public double Height { get; }

  public Rectangle(double width, double height) {
    Width = width;
    Height = height;
  }

  public void Accept(IShapeVisitor visitor) {
    visitor.VisitRectangle(this);
  }
}

public interface IShapeVisitor {
  void VisitCircle(Circle circle);
  void VisitRectangle(Rectangle rectangle);
}

public class DrawVisitor : IShapeVisitor {
  public void VisitCircle(Circle circle) {
    Console.WriteLine($"Drawing a circle with radius {circle.Radius}");
  }

  public void VisitRectangle(Rectangle rectangle) {
    Console.WriteLine($"Drawing a rectangle {rectangle.Width} x {rectangle.Height}");
  }
}

public class AreaVisitor : IShapeVisitor {
  public void VisitCircle(Circle circle) {
    double area = Math.PI * circle.Radius * circle.Radius;
    Console.WriteLine($"Circle area: {area:F2}");
  }

  public void VisitRectangle(Rectangle rectangle) {
    double area = rectangle.Width * rectangle.Height;
    Console.WriteLine($"Rectangle area: {area:F2}");
  }
}

class Program {
  static void Main() {
    List<IShape> shapes = new List<IShape> {
      new Circle(5),
      new Rectangle(4, 6)
    };

    var drawVisitor = new DrawVisitor();
    var areaVisitor = new AreaVisitor();

    Console.WriteLine("== Drawing Shapes ==");
    foreach (var shape in shapes)
      shape.Accept(drawVisitor);

    Console.WriteLine("\n== Calculating Areas ==");
    foreach (var shape in shapes)
      shape.Accept(areaVisitor);
  }
}