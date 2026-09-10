
namespace UtilityTest;
internal static partial class Program {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static void Main(string[] args) {
        _ = args;
        #if false
            Test__Float32_Comparison();

            //Test__Float32_Random1();

            //Test__Float32_BaseTenPrecision();
            Test__Float64_BaseTenPrecision();

            //Test__Intrinsics();

            //Gen__TurboColor();

        #else
            TESTOUTC($"                                 ~~~ START ~~~");
            PROFILE_Start();

            Test__Utility();

            Test__Integer();

            Test__String();

            Test__Matrix();
          //Test__MatrixOps();

            Test__Vector();
            Test__VectorArray();
            Test__VectorBasicOps();

            Test__Vector_Collision2();
            Test__Vector_Collision3();
            Test__Vector_Color();
            Test__Vector_Filter();
            Test__Vector_Generate();
            Test__Vector_Geometry();
            Test__Vector_Interpolation();
            Test__Vector_Miscellaneous();
            Test__Vector_Rotation();

            PROFILE_End();
            TESTOUT($"\n                                 ~~~ FINISH ~~~");
            TESTOUT($"\n                                   {PROFILE_Result():N12}\n");

            Test___();
        #endif

        #if RELEASE
            TESTOUTC("Press the 'any' key to close-window..."); System.Console.ReadKey();
            //TESTOUTC("Press 'enter' key to close-window..."); System.Console.ReadLine();
        #endif
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static void  TESTOUT()               => System.Console.WriteLine();
    internal static void  TESTOUT(string PrintMe) => System.Console.WriteLine(PrintMe);
    internal static void TESTOUTC(string PrintMe) => System.Console.Write    (PrintMe);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static bool IsApproximatelyZero(this v1 A)   => abs(A)   < EPS6;
    internal static bool IsApproximatelyZero(this v2 A)   => abs(A)   < EPS6;
    internal static bool IsApproximatelyZero(this v3 A)   => abs(A)   < EPS6;
    internal static bool IsApproximatelyZero(this v4 A)   => abs(A)   < EPS6;

    internal static bool IsApproximately(this v1 A, v1 B) => abs(B-A) < EPS6;
    internal static bool IsApproximately(this v2 A, v2 B) => abs(B-A) < EPS6;
    internal static bool IsApproximately(this v3 A, v3 B) => abs(B-A) < EPS6;
    internal static bool IsApproximately(this v4 A, v4 B) => abs(B-A) < EPS6;

    internal static bool IsRoughly(this v1 A, v1 B)       => abs(B-A) < EPS4;
    internal static bool IsRoughly(this v2 A, v2 B)       => abs(B-A) < EPS4;
    internal static bool IsRoughly(this v3 A, v3 B)       => abs(B-A) < EPS4;
    internal static bool IsRoughly(this v4 A, v4 B)       => abs(B-A) < EPS4;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
