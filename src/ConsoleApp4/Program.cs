using System;
using System.Diagnostics.Tracing;

namespace ConsoleApp4
{
    public class Program
    {
        public void Main(string[] args)
        {
            try
            {
                string manifest = EventSource.GenerateManifest(typeof(SampleEventSource), "SomeAssembly.dll", EventManifestOptions.Strict);
                Console.WriteLine(manifest);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
    public sealed class SampleEventSource : EventSource
    {
        public bool ThrowingEtwExceptionIsEnabled()
        {
            return base.IsEnabled();
        }

        [Event(2, Level = EventLevel.Warning, Opcode = EventOpcode.Info,
            Message = "Throwing an exception. Source: {0}. Exception details: {1}")]
        public void ThrowingEtwException()
        {
            WriteEvent(2);
        }
    }
}
