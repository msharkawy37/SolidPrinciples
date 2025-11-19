using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
	internal class DependencyInversionPrinciple
	{
	}


	// Low-level module (detail/implementation)
	public class EmailService_WithoutDIP
	{
		public void SendEmail(string to, string subject, string body)
		{
			Console.WriteLine($"Sending email to {to}: {subject}");
			// SMTP logic, connect to mail server, etc.
		}
	}

	// High-level module DIRECTLY depends on low-level module
	public class UserRegistration_WithoutDIP
	{
		private EmailService_WithoutDIP _emailService;  // ❌ Depends on concrete class!
		public UserRegistration_WithoutDIP()
		{
			_emailService = new EmailService_WithoutDIP();  // ❌ Creates dependency itself!
		}

		public void RegisterUser(string username, string email)
		{
			// Registration logic
			Console.WriteLine($"Registering user: {username}");

			// Send welcome email
			_emailService.SendEmail(email, "Welcome", "Welcome to our app!");
		}
	}

	//✅ With DIP(Loose Coupling)

	// Abstraction (interface)
	public interface INotificationService
	{
		void SendNotification(string to, string subject, string message);
	}

	// Low-level module (implementation detail)
	public class EmailService : INotificationService
	{
		public void SendNotification(string to, string subject, string message)
		{
			Console.WriteLine($"Sending EMAIL to {to}: {subject}");
			// SMTP logic
		}
	}

	public class SmsService : INotificationService
	{
		public void SendNotification(string to, string subject, string message)
		{
			Console.WriteLine($"send sms to {to}: {message}");
		}
	}

	public class MockNotifcationService : INotificationService
	{
		public void SendNotification(string to, string subject, string message)
		{
			Console.WriteLine($"test send notifcation...{to}");
		}
	}



	// High-level module depends on ABSTRACTION, not implementation
	public class UserRegistration
	{
		private readonly INotificationService _notificationService;  // ✅ Depends on interface!

		// Dependency is INJECTED through constructor
		public UserRegistration(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		public void RegisterUser(string username, string contact)
		{
			// Registration logic
			Console.WriteLine($"Registering user: {username}");

			// Send notification (doesn't know HOW, just that it will be sent)
			_notificationService.SendNotification(contact, "Welcome", "Welcome to our app!");
		}
	}


	public class UserRegisteration_MethodInjection
	{
		//public ILogger Logger { get; set; }
		public void displayUserName(string username) { 
		
		}
		public void RegisterUser(string username, string contact,ILogger logger) {
			//register login
			logger.LogInfo("user regisgered and logged");
		}
		public void RegisterUser2(string username, string contact\)
		{
			//register login
			//logger.LogInfo("user regisgered and logged");
		}
	}

	/*
	 **Benefits:**
- ✅ `UserRegistration` doesn't know about email specifics
- ✅ Can easily switch notification methods
- ✅ Easy to test with mock objects
- ✅ Loose coupling
- ✅ Follows Open/Closed Principle
	 */

}
