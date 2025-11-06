// See https://aka.ms/new-console-template for more information
using SolidPrinciples;

Console.WriteLine("Solid Principles!...........");


//---- open/closed
//----*using abstract*------


var pay=new PaymentClientClass();
pay.ClientPayment(new CreditCardPayment(), 100);
pay.ClientPayment(new PaymentMethod4(), 1500);
pay.ClientPayment(new PayPalPayment(), 2000);





//----*using interface*------

var pay2 = new ClientPayment();
pay2.Pay(new CreditCardPayment2(), 50);
pay2.Pay(new NewPayMentMethod(), 600);

//var processor2 =new PaymentProcessor2();
//processor2.ProcessPayment2(new CreditCardPayment2(), 350);


Console.WriteLine("----end--------");
