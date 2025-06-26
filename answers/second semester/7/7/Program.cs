public interface IPaymentStrategy {
  void Pay(decimal amount);
}

public class PayPalStrategy : IPaymentStrategy {
  private string email;

  public PayPalStrategy(string email) {
    this.email = email;
  }

  public void Pay(decimal amount) {
    Console.WriteLine($"Paid {amount:C} using PayPal ({email})");
  }
}

public class CreditCardStrategy : IPaymentStrategy {
  private string cardNumber;

  public CreditCardStrategy(string cardNumber) {
    this.cardNumber = cardNumber;
  }

  public void Pay(decimal amount) {
    Console.WriteLine($"Paid {amount:C} using Credit Card ({cardNumber})");
  }
}

public class PaymentContext {
  private IPaymentStrategy _strategy;

  public void SetStrategy(IPaymentStrategy strategy) {
    _strategy = strategy;
  }

  public void ProcessPayment(decimal amount) {
    if (_strategy == null) {
      Console.WriteLine("Payment strategy is not set.");
      return;
    }

    _strategy.Pay(amount);
  }
}

class Program {
  static void Main() {
    var context = new PaymentContext();

    context.SetStrategy(new PayPalStrategy("user@example.com"));
    context.ProcessPayment(100.0m);

    context.SetStrategy(new CreditCardStrategy("1234-5678-9012-3456"));
    context.ProcessPayment(250.0m);
  }
}