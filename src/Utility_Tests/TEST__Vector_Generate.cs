
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Generate() {
        TESTOUT("\n[Utility.VEC -- Generation]");

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("FromAng()",true
            && FromAng(ToRad(-360)).IsApproximately((         0,         1))
            && FromAng(ToRad(-270)).IsApproximately((         1,         0))
            && FromAng(ToRad(-180)).IsApproximately((         0,        -1))
            && FromAng(ToRad(-135)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP))
            && FromAng(ToRad(- 90)).IsApproximately((        -1,         0))
            && FromAng(ToRad(- 45)).IsApproximately((-SQRT2_RCP, SQRT2_RCP))
            && FromAng(         0 ).IsApproximately((         0,         1))
            && FromAng(ToRad(  45)).IsApproximately(( SQRT2_RCP, SQRT2_RCP))
            && FromAng(ToRad(  90)).IsApproximately((         1,         0))
            && FromAng(ToRad( 135)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP))
            && FromAng(ToRad( 180)).IsApproximately((         0,        -1))
            && FromAng(ToRad( 270)).IsApproximately((        -1,         0))
            && FromAng(ToRad( 360)).IsApproximately((         0,         1))
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        #if Z_UP
            TEST("FromPch()",true
                && FromPch(ToRad(-360)).IsApproximately(( 0,         0,         1))
                && FromPch(ToRad(-270)).IsApproximately(( 0,        -1,         0))
                && FromPch(ToRad(-180)).IsApproximately(( 0,         0,        -1))
                && FromPch(ToRad(-135)).IsApproximately(( 0, SQRT2_RCP,-SQRT2_RCP))
                && FromPch(ToRad(- 90)).IsApproximately(( 0,         1,         0))
                && FromPch(ToRad(- 45)).IsApproximately(( 0, SQRT2_RCP, SQRT2_RCP))
                && FromPch(         0 ).IsApproximately(( 0,         0,         1))
                && FromPch(ToRad(  45)).IsApproximately(( 0,-SQRT2_RCP, SQRT2_RCP))
                && FromPch(ToRad(  90)).IsApproximately(( 0,        -1,         0))
                && FromPch(ToRad( 135)).IsApproximately(( 0,-SQRT2_RCP,-SQRT2_RCP))
                && FromPch(ToRad( 180)).IsApproximately(( 0,         0,        -1))
                && FromPch(ToRad( 270)).IsApproximately(( 0,         1,         0))
                && FromPch(ToRad( 360)).IsApproximately(( 0,         0,         1))
            );
        #else
            TEST("FromPch()",true
                && FromPch(ToRad(-360)).IsApproximately(( 0,         0,        -1))
                && FromPch(ToRad(-270)).IsApproximately(( 0,        -1,         0))
                && FromPch(ToRad(-180)).IsApproximately(( 0,         0,         1))
                && FromPch(ToRad(-135)).IsApproximately(( 0, SQRT2_RCP, SQRT2_RCP))
                && FromPch(ToRad(- 90)).IsApproximately(( 0,         1,         0))
                && FromPch(ToRad(- 45)).IsApproximately(( 0, SQRT2_RCP,-SQRT2_RCP))
                && FromPch(         0 ).IsApproximately(( 0,         0,        -1))
                && FromPch(ToRad(  45)).IsApproximately(( 0,-SQRT2_RCP,-SQRT2_RCP))
                && FromPch(ToRad(  90)).IsApproximately(( 0,        -1,         0))
                && FromPch(ToRad( 135)).IsApproximately(( 0,-SQRT2_RCP, SQRT2_RCP))
                && FromPch(ToRad( 180)).IsApproximately(( 0,         0,         1))
                && FromPch(ToRad( 270)).IsApproximately(( 0,         1,         0))
                && FromPch(ToRad( 360)).IsApproximately(( 0,         0,        -1))
            );
        #endif

        //======================================================================================================================================================
        #if Z_UP
            TEST("FromYaw()",true
                && FromYaw(ToRad(-360)).IsApproximately((         0,         1, 0))
                && FromYaw(ToRad(-270)).IsApproximately((         1,         0, 0))
                && FromYaw(ToRad(-180)).IsApproximately((         0,        -1, 0))
                && FromYaw(ToRad(-135)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP, 0))
                && FromYaw(ToRad(- 90)).IsApproximately((        -1,         0, 0))
                && FromYaw(ToRad(- 45)).IsApproximately((-SQRT2_RCP, SQRT2_RCP, 0))
                && FromYaw(         0 ).IsApproximately((         0,         1, 0))
                && FromYaw(ToRad(  45)).IsApproximately(( SQRT2_RCP, SQRT2_RCP, 0))
                && FromYaw(ToRad(  90)).IsApproximately((         1,         0, 0))
                && FromYaw(ToRad( 135)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP, 0))
                && FromYaw(ToRad( 180)).IsApproximately((         0,        -1, 0))
                && FromYaw(ToRad( 270)).IsApproximately((        -1,         0, 0))
                && FromYaw(ToRad( 360)).IsApproximately((         0,         1, 0))
            );
        #else
            TEST("FromYaw()",true
                && FromYaw(ToRad(-360)).IsApproximately((         0, 0,        -1))
                && FromYaw(ToRad(-270)).IsApproximately((         1, 0,         0))
                && FromYaw(ToRad(-180)).IsApproximately((         0, 0,         1))
                && FromYaw(ToRad(-135)).IsApproximately((-SQRT2_RCP, 0, SQRT2_RCP))
                && FromYaw(ToRad(- 90)).IsApproximately((        -1, 0,         0))
                && FromYaw(ToRad(- 45)).IsApproximately((-SQRT2_RCP, 0,-SQRT2_RCP))
                && FromYaw(         0 ).IsApproximately((         0, 0,        -1))
                && FromYaw(ToRad(  45)).IsApproximately(( SQRT2_RCP, 0,-SQRT2_RCP))
                && FromYaw(ToRad(  90)).IsApproximately((         1, 0,         0))
                && FromYaw(ToRad( 135)).IsApproximately(( SQRT2_RCP, 0, SQRT2_RCP))
                && FromYaw(ToRad( 180)).IsApproximately((         0, 0,         1))
                && FromYaw(ToRad( 270)).IsApproximately((        -1, 0,         0))
                && FromYaw(ToRad( 360)).IsApproximately((         0, 0,        -1))
            );
        #endif

        //======================================================================================================================================================
        #if Z_UP
            TEST("FromRol()",true
                && FromRol(ToRad(-360)).IsApproximately((         0,         1, 0))
                && FromRol(ToRad(-270)).IsApproximately((        -1,         0, 0))
                && FromRol(ToRad(-180)).IsApproximately((         0,        -1, 0))
                && FromRol(ToRad(-135)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP, 0))
                && FromRol(ToRad(- 90)).IsApproximately((         1,         0, 0))
                && FromRol(ToRad(- 45)).IsApproximately(( SQRT2_RCP, SQRT2_RCP, 0))
                && FromRol(         0 ).IsApproximately((         0,         1, 0))
                && FromRol(ToRad(  45)).IsApproximately((-SQRT2_RCP, SQRT2_RCP, 0))
                && FromRol(ToRad(  90)).IsApproximately((        -1,         0, 0))
                && FromRol(ToRad( 135)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP, 0))
                && FromRol(ToRad( 180)).IsApproximately((         0,        -1, 0))
                && FromRol(ToRad( 270)).IsApproximately((         1,         0, 0))
                && FromRol(ToRad( 360)).IsApproximately((         0,         1, 0))
            );
        #else
            TEST("FromRol()",true
                && FromRol(ToRad(-360)).IsApproximately((         0,         1, 0))
                && FromRol(ToRad(-270)).IsApproximately((         1,         0, 0))
                && FromRol(ToRad(-180)).IsApproximately((         0,        -1, 0))
                && FromRol(ToRad(-135)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP, 0))
                && FromRol(ToRad(- 90)).IsApproximately((        -1,         0, 0))
                && FromRol(ToRad(- 45)).IsApproximately((-SQRT2_RCP, SQRT2_RCP, 0))
                && FromRol(         0 ).IsApproximately((         0,         1, 0))
                && FromRol(ToRad(  45)).IsApproximately(( SQRT2_RCP, SQRT2_RCP, 0))
                && FromRol(ToRad(  90)).IsApproximately((         1,         0, 0))
                && FromRol(ToRad( 135)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP, 0))
                && FromRol(ToRad( 180)).IsApproximately((         0,        -1, 0))
                && FromRol(ToRad( 270)).IsApproximately((        -1,         0, 0))
                && FromRol(ToRad( 360)).IsApproximately((         0,         1, 0))
            );
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
        #if Z_UP
            TEST("FromPchYaw()",true
                && FromPchYaw(ToRad(-360), 0).IsApproximately(( 0, 1, 0))
                && FromPchYaw(ToRad(-270), 0).IsApproximately(( 0, 0,-1))
                && FromPchYaw(ToRad(-180), 0).IsApproximately(( 0,-1, 0))
                && FromPchYaw(ToRad( -90), 0).IsApproximately(( 0, 0, 1))
                && FromPchYaw(         0 , 0).IsApproximately(( 0, 1, 0))
                && FromPchYaw(ToRad(  90), 0).IsApproximately(( 0, 0,-1))
                && FromPchYaw(ToRad( 180), 0).IsApproximately(( 0,-1, 0))
                && FromPchYaw(ToRad( 270), 0).IsApproximately(( 0, 0, 1))
                && FromPchYaw(ToRad( 360), 0).IsApproximately(( 0, 1, 0))

                && FromPchYaw( 0,ToRad(-360)).IsApproximately(( 0, 1, 0))
                && FromPchYaw( 0,ToRad(-270)).IsApproximately(( 1, 0, 0))
                && FromPchYaw( 0,ToRad(-180)).IsApproximately(( 0,-1, 0))
                && FromPchYaw( 0,ToRad( -90)).IsApproximately((-1, 0, 0))
                && FromPchYaw( 0,         0 ).IsApproximately(( 0, 1, 0))
                && FromPchYaw( 0,ToRad(  90)).IsApproximately(( 1, 0, 0))
                && FromPchYaw( 0,ToRad( 180)).IsApproximately(( 0,-1, 0))
                && FromPchYaw( 0,ToRad( 270)).IsApproximately((-1, 0, 0))
                && FromPchYaw( 0,ToRad( 360)).IsApproximately(( 0, 1, 0))
            );
        #else
            TEST("FromPchYaw()",true
                && FromPchYaw(ToRad(-360), 0).IsApproximately(( 0, 0,-1))
                && FromPchYaw(ToRad(-270), 0).IsApproximately(( 0,-1, 0))
                && FromPchYaw(ToRad(-180), 0).IsApproximately(( 0, 0, 1))
                && FromPchYaw(ToRad( -90), 0).IsApproximately(( 0, 1, 0))
                && FromPchYaw(         0 , 0).IsApproximately(( 0, 0,-1))
                && FromPchYaw(ToRad(  90), 0).IsApproximately(( 0,-1, 0))
                && FromPchYaw(ToRad( 180), 0).IsApproximately(( 0, 0, 1))
                && FromPchYaw(ToRad( 270), 0).IsApproximately(( 0, 1, 0))
                && FromPchYaw(ToRad( 360), 0).IsApproximately(( 0, 0,-1))

                && FromPchYaw( 0,ToRad(-360)).IsApproximately(( 0, 0,-1))
                && FromPchYaw( 0,ToRad(-270)).IsApproximately(( 1, 0, 0))
                && FromPchYaw( 0,ToRad(-180)).IsApproximately(( 0, 0, 1))
                && FromPchYaw( 0,ToRad( -90)).IsApproximately((-1, 0, 0))
                && FromPchYaw( 0,         0 ).IsApproximately(( 0, 0,-1))
                && FromPchYaw( 0,ToRad(  90)).IsApproximately(( 1, 0, 0))
                && FromPchYaw( 0,ToRad( 180)).IsApproximately(( 0, 0, 1))
                && FromPchYaw( 0,ToRad( 270)).IsApproximately((-1, 0, 0))
                && FromPchYaw( 0,ToRad( 360)).IsApproximately(( 0, 0,-1))
            );
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("RotFromDir()",true
            && RotFromDir((-1, 0, 0))                .IsApproximately((        0 ,ToRad(- 90), 0))
            && RotFromDir(( 1, 0, 0))                .IsApproximately((        0 ,ToRad(  90), 0))

            && RotFromDir(( 0,-1, 0))                .IsApproximately((ToRad( 90),         0 , 0))
            && RotFromDir(( 0, 1, 0))                .IsApproximately((ToRad(-90),         0 , 0))

            && RotFromDir(( 0, 0,-1))                .IsApproximately((        0 ,         0 , 0))
            && RotFromDir(( 0, 0, 1))                .IsApproximately((        0 ,ToRad(-180), 0))

            && RotFromDir(( 0,-SQRT2_RCP,-SQRT2_RCP)).IsApproximately((ToRad( 45),         0 , 0))
            && RotFromDir(( 0, SQRT2_RCP,-SQRT2_RCP)).IsApproximately((ToRad(-45),         0 , 0))
            && RotFromDir(( 0,-SQRT2_RCP, SQRT2_RCP)).IsApproximately((ToRad( 45),ToRad(-180), 0))
            && RotFromDir(( 0, SQRT2_RCP, SQRT2_RCP)).IsApproximately((ToRad(-45),ToRad(-180), 0))

            && RotFromDir((-SQRT2_RCP, 0, SQRT2_RCP)).IsApproximately((        0 ,ToRad(-135), 0))
            && RotFromDir((-SQRT2_RCP, 0,-SQRT2_RCP)).IsApproximately((        0 ,ToRad(- 45), 0))
            && RotFromDir(( SQRT2_RCP, 0,-SQRT2_RCP)).IsApproximately((        0 ,ToRad(  45), 0))
            && RotFromDir(( SQRT2_RCP, 0, SQRT2_RCP)).IsApproximately((        0 ,ToRad( 135), 0))
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            vec2[] Poly5 = Polygon(5,96), Poly6  = Polygon( 6,96), Poly7  = Polygon( 7,96), Poly8  = Polygon( 8,96),
                   Poly9 = Polygon(9,96), Poly10 = Polygon(10,96), Poly11 = Polygon(11,96), Poly12 = Polygon(12,96);

            TEST("Polygon()",true
                &&  Poly5[ 0].IsRoughly((  0.0f       , 96.0f       )) &&  Poly5[ 1].IsRoughly((-91.30142556f, 29.66563145f))
                &&  Poly5[ 2].IsRoughly((-56.42738422f,-77.66563145f)) &&  Poly5[ 3].IsRoughly(( 56.42738422f,-77.66563145f))
                &&  Poly5[ 4].IsRoughly(( 91.30142556f, 29.66563145f))

                &&  Poly6[ 0].IsRoughly((  0f         , 96f         )) &&  Poly6[ 1].IsRoughly((-83.13843876f, 48f         ))
                &&  Poly6[ 2].IsRoughly((-83.13843876f,-48f         )) &&  Poly6[ 3].IsRoughly((  0f         ,-96f         ))
                &&  Poly6[ 4].IsRoughly(( 83.13843876f,-48f         )) &&  Poly6[ 5].IsRoughly(( 83.13843876f, 48f         ))

                &&  Poly7[ 0].IsRoughly((  0f         , 96f         )) &&  Poly7[ 1].IsRoughly((-75.05582231f, 59.85502097f))
                &&  Poly7[ 2].IsRoughly((-93.59307956f,-21.36200965f)) &&  Poly7[ 3].IsRoughly((-41.65283895f,-86.49301131f))
                &&  Poly7[ 4].IsRoughly(( 41.65283895f,-86.49301131f)) &&  Poly7[ 5].IsRoughly(( 93.59307956f,-21.36200965f))
                &&  Poly7[ 6].IsRoughly(( 75.05582231f, 59.85502097f))

                &&  Poly8[ 0].IsRoughly((  0f         , 96f         )) &&  Poly8[ 1].IsRoughly((-67.88225099f, 67.88225099f))
                &&  Poly8[ 2].IsRoughly((-96f         ,  0f         )) &&  Poly8[ 3].IsRoughly((-67.88225099f,-67.88225099f))
                &&  Poly8[ 4].IsRoughly((  0f         ,-96f         )) &&  Poly8[ 5].IsRoughly(( 67.88225099f,-67.88225099f))
                &&  Poly8[ 6].IsRoughly(( 96f         ,  0f         )) &&  Poly8[ 7].IsRoughly(( 67.88225099f, 67.88225099f))

                &&  Poly9[ 0].IsRoughly((  0f         , 96f         )) &&  Poly9[ 1].IsRoughly((-61.70761052f, 73.54026653f))
                &&  Poly9[ 2].IsRoughly((-94.54154428f, 16.67022505f)) &&  Poly9[ 3].IsRoughly((-83.13843876f,-48f         ))
                &&  Poly9[ 4].IsRoughly((-32.83393375f,-90.21049159f)) &&  Poly9[ 5].IsRoughly(( 32.83393375f,-90.21049159f))
                &&  Poly9[ 6].IsRoughly(( 83.13843876f,-48f         )) &&  Poly9[ 7].IsRoughly(( 94.54154428f, 16.67022505f))
                &&  Poly9[ 8].IsRoughly(( 61.70761052f, 73.54026653f))

                && Poly10[ 0].IsRoughly((  0f         , 96f         )) && Poly10[ 1].IsRoughly((-56.42738422f, 77.66563145f))
                && Poly10[ 2].IsRoughly((-91.30142556f, 29.66563145f)) && Poly10[ 3].IsRoughly((-91.30142556f,-29.66563145f))
                && Poly10[ 4].IsRoughly((-56.42738422f,-77.66563145f)) && Poly10[ 5].IsRoughly((  0f         ,-96f         ))
                && Poly10[ 6].IsRoughly(( 56.42738422f,-77.66563145f)) && Poly10[ 7].IsRoughly(( 91.30142556f,-29.66563145f))
                && Poly10[ 8].IsRoughly(( 91.30142556f, 29.66563145f)) && Poly10[ 9].IsRoughly(( 56.42738422f, 77.66563145f))

                && Poly11[ 0].IsRoughly((  0f         , 96f         )) && Poly11[ 1].IsRoughly((-51.90151847f, 80.76033915f))
                && Poly11[ 2].IsRoughly((-87.32467155f, 39.87984124f)) && Poly11[ 3].IsRoughly((-95.02285842f,-13.66222447f))
                && Poly11[ 4].IsRoughly((-72.55195913f,-62.86663045f)) && Poly11[ 5].IsRoughly((-27.04632545f,-92.11132546f))
                && Poly11[ 6].IsRoughly(( 27.04632545f,-92.11132546f)) && Poly11[ 7].IsRoughly(( 72.55195913f,-62.86663045f))
                && Poly11[ 8].IsRoughly(( 95.02285842f,-13.66222447f)) && Poly11[ 9].IsRoughly(( 87.32467155f, 39.87984124f))
                && Poly11[10].IsRoughly(( 51.90151847f, 80.76033915f))

                && Poly12[ 0].IsRoughly((  0f         , 96f         )) && Poly12[ 1].IsRoughly((-48f         , 83.13843876f))
                && Poly12[ 2].IsRoughly((-83.13843876f, 48f         )) && Poly12[ 3].IsRoughly((-96f         ,  0f         ))
                && Poly12[ 4].IsRoughly((-83.13843876f,-48f         )) && Poly12[ 5].IsRoughly((-48f         ,-83.13843876f))
                && Poly12[ 6].IsRoughly((  0f         ,-96f         )) && Poly12[ 7].IsRoughly(( 48f         ,-83.13843876f))
                && Poly12[ 8].IsRoughly(( 83.13843876f,-48f         )) && Poly12[ 9].IsRoughly(( 96f         ,  0f         ))
                && Poly12[10].IsRoughly(( 83.13843876f, 48f         )) && Poly12[11].IsRoughly(( 48f         , 83.13843876f))
            );
        }

        //======================================================================================================================================================
        {
            vec2 A = (-1, 0);
            vec2 B = ( 1, 0);
            vec2[] Poly = PolyLine(A, B, SegCount:2, Radius:1f);

            TEST("PolyLine()",true
                &&  Poly.Length == 10

                &&  Poly[0] == (-1, 1)
                &&  Poly[2] == (-2, 0)
                &&  Poly[4] == (-1,-1)
                &&  Poly[5] == ( 1,-1)
                &&  Poly[7] == ( 2, 0)
                &&  Poly[9] == ( 1, 1)

                &&  Poly[1] == (-1-SQRT2_RCP, SQRT2_RCP)
                &&  Poly[3] == (-1-SQRT2_RCP,-SQRT2_RCP)
                &&  Poly[6] == ( 1+SQRT2_RCP,-SQRT2_RCP)
                &&  Poly[8] == ( 1+SQRT2_RCP, SQRT2_RCP)
            );
        }

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
