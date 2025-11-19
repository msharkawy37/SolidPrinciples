using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
	internal class InterfaceSegregationPrinciple
	{
	}

	//❌ Fat Interface(Violates ISP)
	public interface IMultiFunctionDevice
	{
		void Print(string document);
		void Scan(string document);
		void Fax(string document);
		void SendEmail(string document);
	}
	// All-in-one office printer - uses everything
	public class OfficeMultiFunctionPrinter : IMultiFunctionDevice
	{
		public void Print(string doc) => Console.WriteLine("Printing...");
		public void Scan(string doc) => Console.WriteLine("Scanning...");
		public void Fax(string doc) => Console.WriteLine("Faxing...");
		public void SendEmail(string doc) => Console.WriteLine("Emailing...");
	}
	// Simple home printer - FORCED to implement things it can't do!
	public class SimplePrinter : IMultiFunctionDevice
	{
		public void Print(string doc) => Console.WriteLine("Printing...");
		public void Scan(string doc) => throw new NotSupportedException();// ❌ Simple printer can't scan!
		public void Fax(string doc) => throw new NotSupportedException();// ❌ Simple printer can't fax!
		public void SendEmail(string doc) => throw new NotSupportedException();// ❌ Simple printer can't email!
	}
	// Old fax machine - only faxes
	public class OldFaxMachine : IMultiFunctionDevice
	{
		public void Print(string doc) => throw new NotSupportedException();// ❌ Can't print
		public void Scan(string doc) => throw new NotSupportedException();// ❌ Can't scan
		public void Fax(string doc) => Console.WriteLine("Faxing...");
		public void SendEmail(string doc) => throw new NotSupportedException();// ❌ Can't email
	}

	//✅ Segregated Interfaces (Respects ISP)
	// Small, focused interfaces
	public interface IPrinter
	{
		void Print(string document);
	}

	public interface IScanner
	{
		void Scan(string document);
	}
	public interface IFax
	{
		void Fax(string document);
	}

	public interface IEmailSender
	{
		void SendEmail(string document);
	}


	// Simple printer implements ONLY printing
	public class SimplePrinter_ISP : IPrinter
	{
		public void Print(string doc) => Console.WriteLine("Printing...simple printer"); // ✅ No need to implement scan, fax, staple, email!
	}
	// Scanner implements ONLY scanning
	public class StandaloneScanner : IScanner
	{
		public void Scan(string doc) => Console.WriteLine("Scanning...");// ✅ Clean and focused!
	}
	// Old fax machine implements ONLY fax
	public class OldFaxMachine_ISP : IFax
	{
		public void Fax(string doc) => Console.WriteLine("Faxing...");// ✅ Perfect! Only what it needs!
	}
	// Modern printer with print and scan
	public class PrinterScanner : IPrinter, IScanner
	{
		public void Print(string doc) => Console.WriteLine("Printing...printer scanner");
		public void Scan(string doc) => Console.WriteLine("Scanning...");
		// ✅ Mix and match capabilities!
	}
	// All-in-one printer implements ALL interfaces
	public class OfficeMultiFunctionPrinter_ISP : IPrinter, IScanner, IFax, IEmailSender
	{
		public void Print(string doc) => Console.WriteLine("Printing...office mutlifunction printer");
		public void Scan(string doc) => Console.WriteLine("Scanning...");
		public void Fax(string doc) => Console.WriteLine("Faxing...");
		public void Staple(string doc) => Console.WriteLine("Stapling...");
		public void SendEmail(string doc) => Console.WriteLine("Emailing...");
	}
	
	
	public class DocumentProcessor
	{

		// Accept specific interfaces based on needs
		public void ProcessDocument(string doc, IPrinter printer)
		{
			printer.Print(doc);
			// ✅ Only needs printing capability
		}
		public void ArchiveDocument(string doc, IScanner scanner)
		{
			scanner.Scan(doc);
			// ✅ Only needs scanning capability
		}
		public void SendToClient(string doc, IFax fax)
		{
			fax.Fax(doc);
			// ✅ Only needs fax capability
		}
	}
}
