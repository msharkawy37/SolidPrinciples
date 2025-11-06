using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
	//Open/Closed Principle (OCP)
	//----------------using abstract
	public abstract class PaymentMethod
	{
		public double amount { get; set; }

		public abstract void ProcessPayment();
		public void PaymentAfterVat()
		{
			Console.WriteLine($"payment after vat: {amount + amount * 0.15}");
		}
	}
	public class CreditCardPayment : PaymentMethod
	{
		public override void ProcessPayment()
		{
			Console.WriteLine("----- using CreditCardPayment ------------");
			Console.WriteLine($"process credit card payment: {amount}");
		}
	}
	public class CryptoPayment : PaymentMethod
	{
		public override void ProcessPayment()
		{
			Console.WriteLine("----- using CryptoPayment ------------");
			Console.WriteLine($"Processing crypto payment: {amount}");
		}
	}

	public class PayPalPayment : PaymentMethod
	{
		public override void ProcessPayment()
		{
			Console.WriteLine($"payment using paypal method, the amount: {amount}");
		}
	}

	public class PaymentMethod4 : PaymentMethod
	{
		public override void ProcessPayment()
		{
			Console.WriteLine($"payment using PaymentMethod4 method, the amount: {amount + 20 }");
		}
	}

	//Payment Processor is closed for modification, open for extension
	public class PaymentClientClass()
	{
		public void ClientPayment(PaymentMethod paymentMethod, double amount)
		{
			paymentMethod.amount = amount;
			paymentMethod.ProcessPayment();
			paymentMethod.PaymentAfterVat();
		}
	}




	//----------------using interface
	public interface PaymentMethod2
	{
		public void ProcessPayment2(decimal amount);
	}

	public class CreditCardPayment2 : PaymentMethod2
	{
		public void ProcessPayment2(decimal amount)
		{
			Console.WriteLine($"process credit card payment (using interface): {amount}");
		}

	}
	public class CryptoPayment2 : PaymentMethod2
	{
		public void ProcessPayment2(decimal amount)
		{
			Console.WriteLine($"Processing crypto payment (using interface): {amount}");
		}
	}
	public class NewPayMentMethod : PaymentMethod2
	{
		public void ProcessPayment2(decimal amount)
		{
			Console.WriteLine($"New payment method added: {amount}");
		}
	}
	public class ClientPayment()
	{
		public void Pay(PaymentMethod2 paymentMethod, decimal amount)
		{
			paymentMethod.ProcessPayment2(amount);
		}
	}

}
