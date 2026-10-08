
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Triangle() {
        TESTOUT("\n[Utility.VEC -- Triangle]");

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            vec2 Z = (0f, 0f);
            vec2 A = (0f, 1f);
            vec2 B = (-sin(PI2/3f),cos(PI2/3f));
            vec2 C = (-sin(PI4/3f),cos(PI4/3f));

            TEST("Barycentric()", true
                && Barycentric(Z,  A,B,C).IsApproximately((ONE_THIRD, ONE_THIRD, ONE_THIRD))
                && Barycentric(Z,  C,A,B).IsApproximately((ONE_THIRD, ONE_THIRD, ONE_THIRD))
                && Barycentric(Z,  B,C,A).IsApproximately((ONE_THIRD, ONE_THIRD, ONE_THIRD))

                && Barycentric(Z+3f,  A+3f,B+3f,C+3f).IsApproximately((ONE_THIRD, ONE_THIRD, ONE_THIRD))
                && Barycentric(Z-3f,  A-3f,B-3f,C-3f).IsApproximately((ONE_THIRD, ONE_THIRD, ONE_THIRD))

                && Barycentric(A,  A,B,C).IsApproximately((1f, 0f, 0f))
                && Barycentric(B,  A,B,C).IsApproximately((0f, 1f, 0f))
                && Barycentric(C,  A,B,C).IsApproximately((0f, 0f, 1f))

                && Barycentric(A/4f,  A,B,C).IsApproximately((2/4f, 1/4f, 1/4f))
                && Barycentric(B/4f,  A,B,C).IsApproximately((1/4f, 2/4f, 1/4f))
                && Barycentric(C/4f,  A,B,C).IsApproximately((1/4f, 1/4f, 2/4f))

                && Barycentric(A/3f,  A,B,C).IsApproximately((5/9f, 2/9f, 2/9f))
                && Barycentric(B/3f,  A,B,C).IsApproximately((2/9f, 5/9f, 2/9f))
                && Barycentric(C/3f,  A,B,C).IsApproximately((2/9f, 2/9f, 5/9f))

                && Barycentric(A/2f,  A,B,C).IsApproximately((4/6f, 1/6f, 1/6f))
                && Barycentric(B/2f,  A,B,C).IsApproximately((1/6f, 4/6f, 1/6f))
                && Barycentric(C/2f,  A,B,C).IsApproximately((1/6f, 1/6f, 4/6f))

                && Barycentric(A*0.75f,  A,B,C).IsApproximately((10/12f,  1/12f,  1/12f))
                && Barycentric(B*0.75f,  A,B,C).IsApproximately(( 1/12f, 10/12f,  1/12f))
                && Barycentric(C*0.75f,  A,B,C).IsApproximately(( 1/12f,  1/12f, 10/12f))
            );

            #if false
                TESTOUT("");
                TESTOUT($"    {Barycentric(Z,  A,B,C):0.000}");
                TESTOUT($"    {Barycentric(Z,  A,B,C):0.000}");
                TESTOUT("");
                TESTOUT($"    {Barycentric(A*0.25f,  A,B,C):0.000}");
                TESTOUT($"    {Barycentric(B*0.25f,  A,B,C):0.000}");
                TESTOUT($"    {Barycentric(C*0.25f,  A,B,C):0.000}");
                TESTOUT("");
                TESTOUT($"    {Barycentric(A*0.50f,  A,B,C):0.000}");
                TESTOUT($"    {Barycentric(B*0.50f,  A,B,C):0.000}");
                TESTOUT($"    {Barycentric(C*0.50f,  A,B,C):0.000}");
                TESTOUT("");
                TESTOUT($"    {Barycentric(A*0.75f,  A,B,C):0.000}");
                TESTOUT($"    {Barycentric(B*0.75f,  A,B,C):0.000}");
                TESTOUT($"    {Barycentric(C*0.75f,  A,B,C):0.000}");
                TESTOUT("");
                TESTOUT($"    {Barycentric(A*ONE_THIRD,  A,B,C):0.000}");
                TESTOUT($"    {Barycentric(B*ONE_THIRD,  A,B,C):0.000}");
                TESTOUT($"    {Barycentric(C*ONE_THIRD,  A,B,C):0.000}");
                TESTOUT("");
            #endif

        }

        //######################################################################################################################################################
        //######################################################################################################################################################
        //TESTOUT($"{Lanczos(0f)}");

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
