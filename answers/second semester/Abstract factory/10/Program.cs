public interface IVehicle {
  void Drive();
}

public interface IEngine {
  void Start();
}

public class Car : IVehicle {
  public void Drive() {
    Console.WriteLine("Driving a car");
  }
}

public class CarEngine : IEngine {
  public void Start() {
    Console.WriteLine("Starting car engine");
  }
}

public class Bike : IVehicle {
  public void Drive() {
    Console.WriteLine("Riding a bike");
  }
}

public class BikeEngine : IEngine {
  public void Start() {
    Console.WriteLine("Starting bike engine");
  }
}

public interface IVehicleFactory {
  IVehicle CreateVehicle();
  IEngine CreateEngine();
}

public class CarFactory : IVehicleFactory {
  public IVehicle CreateVehicle() {
    return new Car();
  }

  public IEngine CreateEngine() {
    return new CarEngine();
  }
}

public class BikeFactory : IVehicleFactory {
  public IVehicle CreateVehicle() {
    return new Bike();
  }

  public IEngine CreateEngine() {
    return new BikeEngine();
  }
}

class Program {
  static void Main() {
    IVehicleFactory factory;

    factory = new CarFactory();
    IVehicle car = factory.CreateVehicle();
    IEngine carEngine = factory.CreateEngine();

    carEngine.Start();
    car.Drive();

    Console.WriteLine();

    factory = new BikeFactory();
    IVehicle bike = factory.CreateVehicle();
    IEngine bikeEngine = factory.CreateEngine();

    bikeEngine.Start();
    bike.Drive();
  }
}