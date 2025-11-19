using SolidPrinciples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
	public class LiskovSubstitutionPrinciple
	{
	}

	public interface ILogger
	{
		void LogInfo(string message);
		void LogError(string message, Exception ex);
	}

	//-----------❌ INCORRECT Implementations (Violates LSP)

	//Violation 1: Silent Logger (Does Nothing)
	public class SilentLogger : ILogger
	{
		public void LogError(string message, Exception ex)
		{
			//throw new NotImplementedException();
		}

		public void LogInfo(string message)
		{
			//throw new NotImplementedException();
		}
	}
	//Violation 2: Exception Throwing Logger
	public class BrokenLogger : ILogger
	{
		public void LogInfo(string message)
		{
			// ❌ VIOLATES LSP: Throws exception!
			// Contract doesn't say logging can fail
			//throw new NotImplementedException("Logging not available");
		}

		public void LogError(string error, Exception ex)
		{
			// ❌ VIOLATES LSP: Throws exception when trying to log an error!
			// This creates a cascading failure
			//throw new InvalidOperationException("Cannot log errors");
		}
	}

	
	
	
	
	//-----------✅ CORRECT Implementations (Respects LSP)

	//1. Console Logger - Logs to Console
	public class ConsoleLogger : ILogger
	{
		public void LogInfo(string message)
		{
			// Different implementation: writes to console
			// ✅ Contract fulfilled: message is logged
			Console.WriteLine($"[INFO {DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
		}

		public void LogError(string error, Exception ex)
		{
			// ✅ Contract fulfilled: error is logged with details
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"[ERROR {DateTime.Now:yyyy-MM-dd HH:mm:ss}] {error}");
			Console.WriteLine($"Exception: {ex.Message}");
			Console.WriteLine($"Stack Trace: {ex.StackTrace}");
			Console.ResetColor();
		}
	}
	//2. File Logger - Logs to File
	public class FileLogger : ILogger
	{
		private readonly string _filePath;

		public FileLogger(string filePath)
		{
			_filePath = filePath;
		}

		public void LogInfo(string message)
		{
			// Different implementation: writes to file
			// ✅ Contract fulfilled: message is logged
			string logEntry = $"[INFO {DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
			File.AppendAllText(_filePath, logEntry + Environment.NewLine);
		}

		public void LogError(string error, Exception ex)
		{
			// ✅ Contract fulfilled: error is logged with details
			string logEntry = $"[ERROR {DateTime.Now:yyyy-MM-dd HH:mm:ss}] {error}\n" +
							 $"Exception: {ex.Message}\n" +
							 $"Stack Trace: {ex.StackTrace}\n";
			File.AppendAllText(_filePath, logEntry + Environment.NewLine);
		}
	}
	//3. Database Logger - Logs to Database --> do the implementation.
}





//------------ Client*
public class OrderService //NO modification / open to extend throgh other clasess
{
	private readonly ILogger _logger;

	public OrderService(ILogger logger)
	{
		_logger = logger;
	}

	public void ProcessOrder(string orderId)
	{
		try
		{
			//Business logic
			int numerator = 100;
			int divisor = 0;
			int result = numerator / divisor;
			Console.WriteLine($@"result: {result}");
			// Expects: This will log success
			_logger.LogInfo($"Order {orderId} completed successfully");
		}
		catch (Exception ex)
		{
			// Expects: This will log the error with details
			// MUST NOT throw another exception!
			_logger.LogError($"Failed to process order {orderId}", ex);
		}
	}

}
