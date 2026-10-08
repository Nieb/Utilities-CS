//using System;
//using System.Diagnostics;
//using System.Linq;

using CallerLineNumber         = System.Runtime.CompilerServices.CallerLineNumberAttribute;
using CallerArgumentExpression = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace Utility;
internal static class Miscellaneous {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Returns the line-number at the callsite.
    //
    //      LINE_NUMBER()
    //
    internal static int LINE_NUMBER(int Offset=0, [CallerLineNumber] int LineNumber=0) => LineNumber + Offset;

    //==========================================================================================================================================================
    //
    //  Returns verbatim string of Expr expression.
    //
    //      EXPRESSION(1.0 + PI * x)  ==  "1.0 + PI * x"
    //
    internal static string EXPRESSION(float Expr, [CallerArgumentExpression("Expr")] string ExprStr="") => ExprStr;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  'FilePath' can include a file name, it doesn't need to be stripped from string.
    //
    [In(line)] public static void IfNotExist_CreateDirectory(string FilePath) =>
        System.IO.Directory.CreateDirectory(
            System.IO.Path.GetDirectoryName(FilePath)
        );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Returns usage in Bytes.
    //
  //public static long GetProcessVramUsage() {
  //    int pid = Process.GetCurrentProcess().Id;
  //    var category = new PerformanceCounterCategory("GPU Process Memory");
  //
  //    // Find instances belonging to the current Process ID
  //    string[] instanceNames = category.GetInstanceNames().Where(name => name.Contains($"pid_{pid}")).ToArray();
  //
  //    long TotalBytes = 0;
  //
  //    foreach (string instance in instanceNames) {
  //        using (var counter = new PerformanceCounter("GPU Process Memory", "Local Usage", instance, true)) {
  //            TotalBytes += counter.RawValue;
  //        }
  //    }
  //
  //    return TotalBytes;
  //}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
