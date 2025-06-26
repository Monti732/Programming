public interface IDevice {
  void TurnOn();
  void TurnOff();
  void SetVolume(int percent);
  bool IsEnabled { get; }
}

public class TV : IDevice {
  public bool IsEnabled { get; private set; } = false;
  private int volume = 50;

  public void TurnOn() {
    IsEnabled = true;
    Console.WriteLine("TV is turned ON");
  }

  public void TurnOff() {
    IsEnabled = false;
    Console.WriteLine("TV is turned OFF");
  }

  public void SetVolume(int percent) {
    volume = Math.Clamp(percent, 0, 100);
    Console.WriteLine($"TV volume set to {volume}%");
  }
}

public class Radio : IDevice {
  public bool IsEnabled { get; private set; } = false;
  private int volume = 50;

  public void TurnOn() {
    IsEnabled = true;
    Console.WriteLine("Radio is turned ON");
  }

  public void TurnOff() {
    IsEnabled = false;
    Console.WriteLine("Radio is turned OFF");
  }

  public void SetVolume(int percent) {
    volume = Math.Clamp(percent, 0, 100);
    Console.WriteLine($"Radio volume set to {volume}%");
  }
}

public class Remote {
  protected IDevice device;

  public Remote(IDevice device) {
    this.device = device;
  }

  public void TogglePower() {
    if (device.IsEnabled)
      device.TurnOff();
    else
      device.TurnOn();
  }

  public void SetVolume(int percent) {
    device.SetVolume(percent);
  }
}

public class AdvancedRemote : Remote {
  public AdvancedRemote(IDevice device) : base(device) { }

  public void Mute() {
    device.SetVolume(0);
    Console.WriteLine("Muted the device");
  }
}

class Program {
  static void Main(string[] args) {
    IDevice tv = new TV();
    Remote tvRemote = new Remote(tv);
    tvRemote.TogglePower();
    tvRemote.SetVolume(30);

    IDevice radio = new Radio();
    AdvancedRemote radioRemote = new AdvancedRemote(radio);
    radioRemote.TogglePower();
    radioRemote.Mute();
  }
}