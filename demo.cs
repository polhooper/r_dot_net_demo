// code ape'd from https://rdotnet.codeplex.com/
using System;
using System.Linq;
using RDotNet;

namespace demo
{
   class Program
   {
      static void Main(string[] args)
      {
         REngine.SetEnvironmentVariables();
         // There are several options to initialize the engine, but by default the following suffice:
         REngine engine = REngine.GetInstance();

         //TODO (Kyle) -- Figure out what this looks like from the standpoint of passing in arrays from 
         //your SQL queries. Once C# is able to ingest the data passing it in becomes pretty easy
         // .NET Framework array to R vector.
         NumericVector vec = engine.CreateNumericVector(new double[] {1.0, 2.0, 2.0, 3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 5.0, 5.0});
         engine.SetSymbol("vec", vec);
        
         //TODO (Aaron/Kyle) -- This next line *should* (untested) source a script file that (1) install/loads
         //packages dependencies and (2) imports custom R scripts 
         engine.Evaluate("source('demo_functions.R')")
        
         // Execute some of the functions inside demo_functions.R
         double mean = engine.Evaluate("mean_function(vec)")
         double median = engine.Evaluate("median_function(vec)")
         

         Console.WriteLine("Mean: [{0}]", string.Join(", ", mean));
         Console.WriteLine("Median: [{0}]", string.Join(", ", median));

         // dispose of the R engine
         engine.Dispose();

      }
   }
}
