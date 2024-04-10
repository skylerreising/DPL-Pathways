var manager = new OrderManager();
manager.SendNotification(1);

class Factory
{
    public IOrderAccessor CreateOrderAccessor()
    {
        return new OrderAccessor();
    }
    public IEmailAccessor CreateEmailAccessor()
    {
        return new EmailAccessor();
    }
    public IEmailFormatEngine CreateEmailFormatEngine()
    {
        return new EmailFormatEngine();
    }
}
class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }
}

interface IOrderAccessor
{
    Order Find(int id);
}

class OrderAccessor : IOrderAccessor
{
    static Order[] Orders = new Order[]
    {
        new Order() { Id = 1, Total = 100},
        new Order() { Id = 2, Total = 200}
    };

    public Order Find(int id)
    {
        return Orders.First(o => o.Id == id);
    }
}

interface IEmailAccessor
{
    void SendEmail(string email);
}

class EmailAccessor : IEmailAccessor
{
    public void SendEmail(string email)
    {
        Console.WriteLine(email);
    }
}

interface IEmailFormatEngine
{
    string GenerateEmail(Order order);
}

class EmailFormatEngine : IEmailFormatEngine
{
    public string GenerateEmail(Order order)
    {
        return $"Email for {order.Id}";
    }
}

class OrderManager
{
    public void SendNotification(int id)
    {
        var factory = new Factory();
        var orderAccessor = factory.CreateOrderAccessor();
        var order = orderAccessor.Find(id);
        var emailFormatEngine = factory.CreateEmailFormatEngine();
        var email = emailFormatEngine.GenerateEmail(order);
        var emailAccessor = factory.CreateEmailAccessor();
        emailAccessor.SendEmail(email);
    }
}

