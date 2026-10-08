
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Miscellaneous() {
        TESTOUT("\n[Utility.VEC -- Miscellaneous]");

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("Bisect(vec2, vec2)",true
            && Bisect(( 1f, 0f), ( 0f, 1f)).IsApproximately(( SQRT2_RCP, SQRT2_RCP))
            && Bisect(( 0f, 1f), (-1f, 0f)).IsApproximately((-SQRT2_RCP, SQRT2_RCP))
            && Bisect((-1f, 0f), ( 0f,-1f)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP))
            && Bisect(( 0f,-1f), ( 1f, 0f)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP))

            && Bisect(( 1f, 0f), (-1f, 0f)).IsApproximately(( 0f, 1f))
            && Bisect((-1f, 0f), ( 1f, 0f)).IsApproximately(( 0f,-1f))
            && Bisect(( 0f,-1f), ( 0f, 1f)).IsApproximately(( 1f, 0f))
            && Bisect(( 0f, 1f), ( 0f,-1f)).IsApproximately((-1f, 0f))

            && Bisect(( 0f, 1f), ( 1f, 0f)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP))
            && Bisect((-1f, 0f), ( 0f, 1f)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP))
            && Bisect(( 0f,-1f), (-1f, 0f)).IsApproximately(( SQRT2_RCP, SQRT2_RCP))
            && Bisect(( 1f, 0f), ( 0f,-1f)).IsApproximately((-SQRT2_RCP, SQRT2_RCP))

            && Bisect(( SQRT2_RCP,-SQRT2_RCP), ( SQRT2_RCP, SQRT2_RCP)).IsApproximately(( 1f, 0f))
            && Bisect((-SQRT2_RCP,-SQRT2_RCP), (-SQRT2_RCP, SQRT2_RCP)).IsApproximately(( 1f, 0f))

            && Bisect((-SQRT2_RCP, SQRT2_RCP), (-SQRT2_RCP,-SQRT2_RCP)).IsApproximately((-1f, 0f))
            && Bisect(( SQRT2_RCP, SQRT2_RCP), ( SQRT2_RCP,-SQRT2_RCP)).IsApproximately((-1f, 0f))

            && Bisect(( SQRT2_RCP, SQRT2_RCP), (-SQRT2_RCP, SQRT2_RCP)).IsApproximately(( 0f, 1f))
            && Bisect(( SQRT2_RCP,-SQRT2_RCP), (-SQRT2_RCP,-SQRT2_RCP)).IsApproximately(( 0f, 1f))

            && Bisect((-SQRT2_RCP, SQRT2_RCP), ( SQRT2_RCP, SQRT2_RCP)).IsApproximately(( 0f,-1f))
            && Bisect((-SQRT2_RCP,-SQRT2_RCP), ( SQRT2_RCP,-SQRT2_RCP)).IsApproximately(( 0f,-1f))
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            //vec2 A = PredictiveAim(
            //    (1f, 1f), (SQRT2_RCP, -SQRT2_RCP),
            //    (1f, 3f), (SQRT2_RCP, -SQRT2_RCP),
            //    1f
            //);
            //vec2 B = PredictiveAim(
            //    (1f, 3f), (SQRT2_RCP, -SQRT2_RCP),
            //    (1f, 1f), (0f, 0f),
            //    1f
            //);

            TEST("vec2 PredictiveAim()",true
                //&&
                //PredictiveAim(
                //    (1f, 3f), (SQRT2_RCP, -SQRT2_RCP),
                //    (1f, 1f), (0f, 0f),
                //    SQRT2_RCP
                //).IsApproximately((2f, 2f))
            );

            //TESTOUT("");
            //TESTOUT($"result  == {A:0}");
            //TESTOUT("");
            //TESTOUT($"result  == {B:0}");
            //TESTOUT("");
        }
        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("SphericalDistance(vec2, vec2)",true
            && SphericalDistance((  0f,  0f),( PIQ,  0f)).IsApproximately(PIQ)
            && SphericalDistance((  0f,  0f),( PIH,  0f)).IsApproximately(PIH)
            && SphericalDistance((  0f,  0f),( PI ,  0f)).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),( PI2,  0f)).IsApproximately(0f)
            && SphericalDistance((  0f,  0f),( PI3,  0f)).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),( PI4,  0f)).IsApproximately(0f)
            && SphericalDistance((  0f,  0f),( PI5,  0f)).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),( PI6,  0f)).IsApproximately(0f)

            && SphericalDistance((  0f,  0f),(  0f, PIQ)).IsApproximately(PIQ)
            && SphericalDistance((  0f,  0f),(  0f, PIH)).IsApproximately(PIH)
            && SphericalDistance((  0f,  0f),(  0f, PI )).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),(  0f, PI2)).IsApproximately(0f)
            && SphericalDistance((  0f,  0f),(  0f, PI3)).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),(  0f, PI4)).IsApproximately(0f)
            && SphericalDistance((  0f,  0f),(  0f, PI5)).IsApproximately(PI)
            && SphericalDistance((  0f,  0f),(  0f, PI6)).IsApproximately(0f)

            && SphericalDistance((-PIQ,  0f),( PIQ,  0f)).IsApproximately(PIH)
            && SphericalDistance((-PIH,  0f),( PIH,  0f)).IsApproximately(PI)

            && SphericalDistance(( PIH,  0f),(  0f, PIH)).IsApproximately(PIH)
            && SphericalDistance((  0f, PIH),( PIH,  0f)).IsApproximately(PIH)

            && SphericalDistance(( PIQ,  0f),( PIQ, PI )).IsApproximately(PIH)
            && SphericalDistance(( PIQ,  0f),(-PIQ, PI )).IsApproximately(PI)
            && SphericalDistance((-PIQ,  0f),( PIQ, PI )).IsApproximately(PI)
            && SphericalDistance((-PIQ,  0f),(-PIQ, PI )).IsApproximately(PIH)
        );

        //======================================================================================================================================================
        TEST("SphericalDistance(vec3, vec3)",true
            && SphericalDistance(( 1f, 0f, 0f),( 1f, 0f, 0f)).IsApproximately(0f)
            && SphericalDistance(( 0f, 1f, 0f),( 0f, 1f, 0f)).IsApproximately(0f)
            && SphericalDistance(( 0f, 0f, 1f),( 0f, 0f, 1f)).IsApproximately(0f)

            && SphericalDistance(( 1f, 0f, 0f),(-1f, 0f, 0f)).IsApproximately(PI)
            && SphericalDistance(( 0f, 1f, 0f),( 0f,-1f, 0f)).IsApproximately(PI)
            && SphericalDistance(( 0f, 0f, 1f),( 0f, 0f,-1f)).IsApproximately(PI)

            && SphericalDistance(( 1f, 0f, 0f),( 0f, 1f, 0f)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),( 0f, 0f, 1f)).IsApproximately(PIH)
            && SphericalDistance(( 0f, 1f, 0f),( 1f, 0f, 0f)).IsApproximately(PIH)
            && SphericalDistance(( 0f, 1f, 0f),( 0f, 0f, 1f)).IsApproximately(PIH)
            && SphericalDistance(( 0f, 0f, 1f),( 1f, 0f, 0f)).IsApproximately(PIH)
            && SphericalDistance(( 0f, 0f, 1f),( 0f, 1f, 0f)).IsApproximately(PIH)

            && SphericalDistance(( 1f, 0f, 0f),(        0f,        1f,        0f)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f, SQRT2_RCP, SQRT2_RCP)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f,        0f,        1f)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f,-SQRT2_RCP, SQRT2_RCP)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f,       -1f,        0f)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f,-SQRT2_RCP,-SQRT2_RCP)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f,        0f,       -1f)).IsApproximately(PIH)
            && SphericalDistance(( 1f, 0f, 0f),(        0f, SQRT2_RCP,-SQRT2_RCP)).IsApproximately(PIH)

            && SphericalDistance(( 1f, 0f, 0f),( SQRT2_RCP, SQRT2_RCP,        0f)).IsApproximately(PIQ)
            && SphericalDistance(( 1f, 0f, 0f),( SQRT2_RCP,-SQRT2_RCP,        0f)).IsApproximately(PIQ)
            && SphericalDistance(( 1f, 0f, 0f),(-SQRT2_RCP, SQRT2_RCP,        0f)).IsApproximately(PIH + PIQ)
            && SphericalDistance(( 1f, 0f, 0f),(-SQRT2_RCP,-SQRT2_RCP,        0f)).IsApproximately(PIH + PIQ)

            && SphericalDistance(( 1f, 0f, 0f),( SQRT2_RCP,        0f, SQRT2_RCP)).IsApproximately(PIQ)
            && SphericalDistance(( 1f, 0f, 0f),( SQRT2_RCP,        0f,-SQRT2_RCP)).IsApproximately(PIQ)
            && SphericalDistance(( 1f, 0f, 0f),(-SQRT2_RCP,        0f, SQRT2_RCP)).IsApproximately(PIH + PIQ)
            && SphericalDistance(( 1f, 0f, 0f),(-SQRT2_RCP,        0f,-SQRT2_RCP)).IsApproximately(PIH + PIQ)
        );

        #if false
            TESTOUT($"""

                PIH == {PIH:0.00000000}
                PI  == {PI:0.00000000}

              ( 1, 0, 0),( r, r, 0) == {SphericalDistance((1f,0f,0f),( SQRT2_RCP, SQRT2_RCP,        0f)):0.00000000}  {SphericalDistance_((1f,0f,0f),( SQRT2_RCP, SQRT2_RCP,        0f)):0.00000000}
              ( 1, 0, 0),( 0, r, r) == {SphericalDistance((1f,0f,0f),(        0f, SQRT2_RCP, SQRT2_RCP)):0.00000000}  {SphericalDistance_((1f,0f,0f),(        0f, SQRT2_RCP, SQRT2_RCP)):0.00000000}
              ( 1, 0, 0),( r, 0, r) == {SphericalDistance((1f,0f,0f),( SQRT2_RCP,        0f, SQRT2_RCP)):0.00000000}  {SphericalDistance_((1f,0f,0f),( SQRT2_RCP,        0f, SQRT2_RCP)):0.00000000}

              ( 1, 0, 0),( 0, 1, 0) == {SphericalDistance(( 1f, 0f, 0f),( 0f, 1f, 0f)):0.00000000}  {SphericalDistance_(( 1f, 0f, 0f),( 0f, 1f, 0f)):0.00000000}
              ( 1, 0, 0),( 0, 0, 1) == {SphericalDistance(( 1f, 0f, 0f),( 0f, 0f, 1f)):0.00000000}  {SphericalDistance_(( 1f, 0f, 0f),( 0f, 0f, 1f)):0.00000000}

              ( 0, 1, 0),( 1, 0, 0) == {SphericalDistance(( 0f, 1f, 0f),( 1f, 0f, 0f)):0.00000000}  {SphericalDistance_(( 0f, 1f, 0f),( 1f, 0f, 0f)):0.00000000}
              ( 0, 1, 0),( 0, 0, 1) == {SphericalDistance(( 0f, 1f, 0f),( 0f, 0f, 1f)):0.00000000}  {SphericalDistance_(( 0f, 1f, 0f),( 0f, 0f, 1f)):0.00000000}

              ( 0, 0, 1),( 1, 0, 0) == {SphericalDistance(( 0f, 0f, 1f),( 1f, 0f, 0f)):0.00000000}  {SphericalDistance_(( 0f, 0f, 1f),( 1f, 0f, 0f)):0.00000000}
              ( 0, 0, 1),( 0, 1, 0) == {SphericalDistance(( 0f, 0f, 1f),( 0f, 1f, 0f)):0.00000000}  {SphericalDistance_(( 0f, 0f, 1f),( 0f, 1f, 0f)):0.00000000}

              ( 1, 0, 0),(-1, 0, 0) == {SphericalDistance(( 1f, 0f, 0f),(-1f, 0f, 0f)):0.00000000}  {SphericalDistance_(( 1f, 0f, 0f),(-1f, 0f, 0f)):0.00000000}
              ( 0, 1, 0),( 0,-1, 0) == {SphericalDistance(( 0f, 1f, 0f),( 0f,-1f, 0f)):0.00000000}  {SphericalDistance_(( 0f, 1f, 0f),( 0f,-1f, 0f)):0.00000000}
              ( 0, 0, 1),( 0, 0,-1) == {SphericalDistance(( 0f, 0f, 1f),( 0f, 0f,-1f)):0.00000000}  {SphericalDistance_(( 0f, 0f, 1f),( 0f, 0f,-1f)):0.00000000}
            """);
        #endif

        #if false
            TESTOUT($"""

                PIH == {PIH:0.00000000}
                PI  == {PI:0.00000000}

              ( 1, 0, 0),( r, r, 0) == {SphericalDistance((1f,0f,0f),( SQRT2_RCP, SQRT2_RCP,        0f)):0.00000000}
              ( 1, 0, 0),( 0, r, r) == {SphericalDistance((1f,0f,0f),(        0f, SQRT2_RCP, SQRT2_RCP)):0.00000000}
              ( 1, 0, 0),( r, 0, r) == {SphericalDistance((1f,0f,0f),( SQRT2_RCP,        0f, SQRT2_RCP)):0.00000000}

              ( 1, 0, 0),( 0, 1, 0) == {SphericalDistance(( 1f, 0f, 0f),( 0f, 1f, 0f)):0.00000000}
              ( 1, 0, 0),( 0, 0, 1) == {SphericalDistance(( 1f, 0f, 0f),( 0f, 0f, 1f)):0.00000000}

              ( 0, 1, 0),( 1, 0, 0) == {SphericalDistance(( 0f, 1f, 0f),( 1f, 0f, 0f)):0.00000000}
              ( 0, 1, 0),( 0, 0, 1) == {SphericalDistance(( 0f, 1f, 0f),( 0f, 0f, 1f)):0.00000000}

              ( 0, 0, 1),( 0, 0, 0) == {SphericalDistance(( 0f, 0f, 1f),( 0f, 0f, 0f)):0.00000000}
              ( 0, 0, 1),( 0, 1, 0) == {SphericalDistance(( 0f, 0f, 1f),( 0f, 1f, 0f)):0.00000000}

              ( 1, 0, 0),(-1, 0, 0) == {SphericalDistance(( 1f, 0f, 0f),(-1f, 0f, 0f)):0.00000000}
              ( 0, 1, 0),( 0,-1, 0) == {SphericalDistance(( 0f, 1f, 0f),( 0f,-1f, 0f)):0.00000000}
              ( 0, 0, 1),( 0, 0,-1) == {SphericalDistance(( 0f, 0f, 1f),( 0f, 0f,-1f)):0.00000000}
            """);
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
        #if false
            const int Rds = 12;
            const int Pad =  1;
            int Dim = Pad + Rds + 1 + Rds + Pad+1;

            uint[] C = KC_Circle(Rds, Pad, Pad+1, CenterColor:2, CircleColor:1, BgColor:0);

            System.Text.StringBuilder SB = new();
            for (int i = 0; i < C.Length; ++i) {
                if (i % (Dim) == 0)
                    SB.AppendLine();

                uint c = C[i];
                SB.Append(
                    (c == 0) ? " " :
                    (c == 1) ? "•"
                             : "●"
                );
            }

            TESTOUT(SB.ToString());
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
