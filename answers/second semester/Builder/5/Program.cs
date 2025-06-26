public class House {
  public string Foundation { get; set; }
  public string Walls { get; set; }
  public string Roof { get; set; }

  public override string ToString() {
    return $"House with Foundation: {Foundation}, Walls: {Walls}, Roof: {Roof}";
  }
}

public interface IHouseBuilder {
  void BuildFoundation();
  void BuildWalls();
  void BuildRoof();
  House GetResult();
}

public class WoodHouseBuilder : IHouseBuilder {
  private House _house = new House();

  public void BuildFoundation() {
    _house.Foundation = "Wooden poles";
  }

  public void BuildWalls() {
    _house.Walls = "Wooden walls";
  }

  public void BuildRoof() {
    _house.Roof = "Wooden roof";
  }

  public House GetResult() {
    return _house;
  }
}

public class HouseDirector {
  private IHouseBuilder _builder;

  public HouseDirector(IHouseBuilder builder) {
    _builder = builder;
  }

  public void ConstructHouse() {
    _builder.BuildFoundation();
    _builder.BuildWalls();
    _builder.BuildRoof();
  }
}

class Program {
  static void Main() {
    IHouseBuilder builder = new WoodHouseBuilder();
    HouseDirector director = new HouseDirector(builder);

    director.ConstructHouse();
    House house = builder.GetResult();

    Console.WriteLine(house);
  }
}