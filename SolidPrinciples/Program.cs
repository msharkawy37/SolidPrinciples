// See https://aka.ms/new-console-template for more information
using SolidPrinciples;
using System.Reflection.Metadata;

Console.WriteLine("-----------* Solid Principles! *-------------");

//================================open/closed
Console.WriteLine("Start --------------------------------------------------------------- open/closed!");
//----*using abstract*------
//var pay=new PaymentClientClass();
//pay.ClientPayment(new CreditCardPayment(), 100);
//pay.ClientPayment(new PaymentMethod4(), 1500);
//pay.ClientPayment(new PayPalPayment(), 2000);

//----*using interface*------
//var pay2 = new ClientPayment();
//pay2.Pay(new CreditCardPayment2(), 50);
//pay2.Pay(new NewPayMentMethod(), 600);

//var processor2 =new PaymentProcessor2();
//processor2.ProcessPayment2(new CreditCardPayment2(), 350);
Console.WriteLine();
Console.WriteLine("End --------------------------------------------------------------- open/closed!");
Console.WriteLine();

//================================Liskov Substitution
Console.WriteLine("Start --------------------------------------------------------------- Liskov Substitution Principle!");
//------------Testing with Violating Loggers ❌
//var service1 = new OrderService(new FileLogger(@"c:\temp\ff.log"));
//service1.ProcessOrder("12");
// ❌ Appears to work but nothing is logged
// When something goes wrong, no way to debug!

//var service2 = new OrderService(new BrokenLogger());
//service2.ProcessOrder("13");
// ❌ CRASHES! Throws NotImplementedException



//-----------Testing with Correct Loggers ✅
//var service1 = new OrderService(new ConsoleLogger());
//service1.ProcessOrder("14");

//var service2 = new OrderService(new FileLogger(@"C:\Temp\file.log"));
//service2.ProcessOrder("199");


Console.WriteLine();
Console.WriteLine("End --------------------------------------------------------------- Liskov Substitution Principle!");
Console.WriteLine();

//================================ Interface Segregation Principle
Console.WriteLine("Start --------------------------------------------------------------- Interface Segregation Principle!");
//var processor = new DocumentProcessor();
//processor.ProcessDocument("document 1",new SimplePrinter_ISP());
//processor.ArchiveDocument("document 1", new StandaloneScanner());

Console.WriteLine();
Console.WriteLine("End --------------------------------------------------------------- Interface Segregation Principle!");
Console.WriteLine();


//================================ Dependency Inversion Principle 
Console.WriteLine("Start --------------------------------------------------------------- Dependency Inversion Principle !");
//var registration = new UserRegistration_WithoutDIP();
//registration.RegisterUser("Mohammed", "mohammed@example.com");

//var registration = new UserRegistration(new EmailService());
//registration.RegisterUser("Mohammed", "mohammed@example.com");


var customUserRegisteration = new UserRegisteration_MethodInjection();
customUserRegisteration.RegisterUser("mohamed", "m", new ConsoleLogger());

Console.WriteLine();
Console.WriteLine("End --------------------------------------------------------------- Dependency Inversion Principle !");
Console.WriteLine();