using Conditional = System.Diagnostics.ConditionalAttribute;
using ConOut      = System.Console;

using CallerLineNumber         = System.Runtime.CompilerServices.CallerLineNumberAttribute;
using CallerArgumentExpression = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;

namespace DEBUG;
internal static partial class PRINTOUT {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    #if DEBUG
        //private static System.IO.StreamWriter LogOut = new System.IO.StreamWriter("log.txt"){AutoFlush = true};
        private static System.IO.StreamWriter LogOut = new System.IO.StreamWriter("log.txt", append: true){AutoFlush = true}; //  Append existing file.
    #else
        //private static System.IO.StreamWriter LogOut = null;
        private static System.IO.StreamWriter LogOut = new System.IO.StreamWriter("log.txt", append: true){AutoFlush = true}; //  Append existing file.
    #endif

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Conditional("DEBUG")] internal static void  CONOUT()               => ConOut.WriteLine();
    [Conditional("DEBUG")] internal static void  CONOUT(string PrintMe) => ConOut.WriteLine(PrintMe);
    [Conditional("DEBUG")] internal static void CONOUTC(string PrintMe) => ConOut.Write    (PrintMe);

    //==========================================================================================================================================================
    [Conditional("DEBUG")] internal static void  CONOUT<T>(T PrintMe, [CallerArgumentExpression("PrintMe")] string Expr="") =>
        ConOut.WriteLine($"{Expr,24}: {PrintMe.ToString()}");

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //[Conditional("DEBUG")] internal static void CONOUTd<T>(T PrintMe, [CallerArgumentExpression("PrintMe")] string Expr="") where T : System.Numerics.IBinaryInteger<T> =>
    //    ConOut.WriteLine($"{Expr,24}: "+CommaDelimit(PrintMe));

    //[Conditional("DEBUG")] internal static void CONOUTb<T>(T PrintMe, [CallerArgumentExpression("PrintMe")] string Expr="") where T : System.Numerics.IBinaryInteger<T> =>
    //    ConOut.WriteLine($"{Expr,24}: "+IntToBinaryString(PrintMe));

    //[Conditional("DEBUG")] internal static void CONOUTx<T>(T PrintMe, [CallerArgumentExpression("PrintMe")] string Expr="") where T : System.Numerics.IBinaryInteger<T> =>
    //    ConOut.WriteLine($"{Expr,24}: "+IntToHexString(PrintMe));

    //==========================================================================================================================================================
    [Conditional("DEBUG")] internal static void CONOUT(byte[] PrintMe, [CallerArgumentExpression("PrintMe")] string Expr="") =>
        ConOut.WriteLine($"{Expr,24}: \n"+ByteArrayToString(PrintMe));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Conditional("DEBUG")] internal static void CONOUT<T>(T[] PrintMe, int ItemsPerLine=8, [CallerArgumentExpression("PrintMe")] string Expr="") =>
        ConOut.WriteLine($"{Expr,24}: \n"+EnumerableToString(PrintMe,ItemsPerLine));

    //==========================================================================================================================================================
    [Conditional("DEBUG")] internal static void HERE([CallerLineNumber] int LineNumber=0) => ConOut.WriteLine($"*** HERE! {LineNumber} ***");

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static void  LOGOUT()               => LogOut.WriteLine();
    internal static void  LOGOUT(string PrintMe) => LogOut.WriteLine(PrintMe);
    internal static void LOGOUTC(string PrintMe) => LogOut.Write    (PrintMe);  //, bool WithTimeStamp=false)   DateTime("yyyy-MM-dd  HH:mm:ss.fff")

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static void CONLOGOUT() {
        #if DEBUG
            ConOut.WriteLine();
        #endif
        LogOut.WriteLine();
    }
    internal static void CONLOGOUT(string PrintMe) {
        #if DEBUG
            ConOut.WriteLine(PrintMe);
        #endif
        LogOut.WriteLine(PrintMe);
    }
    internal static void CONLOGOUTC(string PrintMe) {
        #if DEBUG
            ConOut.Write(PrintMe);
        #endif
        LogOut.Write(PrintMe);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
