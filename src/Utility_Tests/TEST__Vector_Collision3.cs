
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Collision3() {
        TESTOUT("\n[Utility.VEC -- Collision3]");

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("WhichSideOfPlane()",true
            && WhichSideOfPlane(( 1f, 0f, 0f), ( 0f, 0f, 0f), (1f,0f,0f)) ==  1f
            && WhichSideOfPlane(( 0f, 1f, 0f), ( 0f, 0f, 0f), (0f,1f,0f)) ==  1f
            && WhichSideOfPlane(( 0f, 0f, 1f), ( 0f, 0f, 0f), (0f,0f,1f)) ==  1f

            && WhichSideOfPlane(( 3f, 5f, 5f), ( 5f, 5f, 5f), (1f,0f,0f)) == -2f
            && WhichSideOfPlane(( 5f, 3f, 5f), ( 5f, 5f, 5f), (0f,1f,0f)) == -2f
            && WhichSideOfPlane(( 5f, 5f, 3f), ( 5f, 5f, 5f), (0f,0f,1f)) == -2f

            && WhichSideOfPlane((-4f,-5f,-5f), (-5f,-5f,-5f), (1f,0f,0f)) ==  1f
            && WhichSideOfPlane((-5f,-4f,-5f), (-5f,-5f,-5f), (0f,1f,0f)) ==  1f
            && WhichSideOfPlane((-5f,-5f,-4f), (-5f,-5f,-5f), (0f,0f,1f)) ==  1f
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("PointVsSphere()",true
            && PointVsSphere(         ( 1f, 1f, 1f), ( 1f, 1f, 1f), 1f) == true
            && PointVsSphere(         ( 1f, 1f, 2f), ( 1f, 1f, 1f), 1f) == true
            && PointVsSphere(         ( 1f, 2f, 1f), ( 1f, 1f, 1f), 1f) == true
            && PointVsSphere(         ( 2f, 1f, 1f), ( 1f, 1f, 1f), 1f) == true

            && PointVsSphere(         (-1f,-1f,-1f), (-1f,-1f,-1f), 1f) == true
            && PointVsSphere(         (-1f,-1f,-2f), (-1f,-1f,-1f), 1f) == true
            && PointVsSphere(         (-1f,-2f,-1f), (-1f,-1f,-1f), 1f) == true
            && PointVsSphere(         (-2f,-1f,-1f), (-1f,-1f,-1f), 1f) == true

            && PointVsSphere(( 1.70f, 1.00f, 1.70f), ( 1f, 1f, 1f), 1f) == true
            && PointVsSphere(( 1.71f, 1.00f, 1.71f), ( 1f, 1f, 1f), 1f) == false

            && PointVsSphere((-1.70f,-1.00f,-1.70f), (-1f,-1f,-1f), 1f) == true
            && PointVsSphere((-1.71f,-1.00f,-1.71f), (-1f,-1f,-1f), 1f) == false

            && PointVsSphere(( 3.57f, 3.57f, 3.57f), ( 3f, 3f, 3f), 1f) == true
            && PointVsSphere(( 3.58f, 3.58f, 3.58f), ( 3f, 3f, 3f), 1f) == false

            && PointVsSphere((-3.57f,-3.57f,-3.57f), (-3f,-3f,-3f), 1f) == true
            && PointVsSphere((-3.58f,-3.58f,-3.58f), (-3f,-3f,-3f), 1f) == false
        );

        //======================================================================================================================================================
        TEST("PointVsBox()",true
            && PointVsBox(( 1f, 1f, 1f), ( 1f, 1f, 1f), (1f,1f,1f)) == true
            && PointVsBox(( 2f, 2f, 2f), ( 1f, 1f, 1f), (1f,1f,1f)) == true

            && PointVsBox(( 2f, 1f, 1f), ( 1f, 1f, 1f), (1f,1f,1f)) == true
            && PointVsBox(( 1f, 2f, 1f), ( 1f, 1f, 1f), (1f,1f,1f)) == true
            && PointVsBox(( 1f, 1f, 2f), ( 1f, 1f, 1f), (1f,1f,1f)) == true
            && PointVsBox(( 2f, 2f, 1f), ( 1f, 1f, 1f), (1f,1f,1f)) == true
            && PointVsBox(( 1f, 2f, 2f), ( 1f, 1f, 1f), (1f,1f,1f)) == true
            && PointVsBox(( 2f, 1f, 2f), ( 1f, 1f, 1f), (1f,1f,1f)) == true

            && PointVsBox((-1f,-1f,-1f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-2f,-2f,-2f), (-2f,-2f,-2f), (1f,1f,1f)) == true

            && PointVsBox((-2f,-1f,-1f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1f,-2f,-1f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1f,-1f,-2f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-2f,-2f,-1f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1f,-2f,-2f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-2f,-1f,-2f), (-2f,-2f,-2f), (1f,1f,1f)) == true

            && PointVsBox((0.9999999f,0.9999999f,0.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((1.9999999f,1.9999999f,1.9999999f), (1f,1f,1f), (1f,1f,1f)) == true

            && PointVsBox((1.9999999f,0.9999999f,0.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((0.9999999f,1.9999999f,0.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((0.9999999f,0.9999999f,1.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((1.9999999f,1.9999999f,0.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((0.9999999f,1.9999999f,1.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((1.9999999f,0.9999999f,1.9999999f), (1f,1f,1f), (1f,1f,1f)) == false

            && PointVsBox((-0.9999999f,-0.9999999f,-0.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-1.9999999f,-1.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == true

            && PointVsBox((-1.9999999f,-0.9999999f,-0.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-0.9999999f,-1.9999999f,-0.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-0.9999999f,-0.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-1.9999999f,-1.9999999f,-0.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-0.9999999f,-1.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-1.9999999f,-0.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false

            && PointVsBox((-1.0000001f,-1.0000001f,-1.0000001f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.9999999f,-1.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == true

            && PointVsBox((-1.9999999f,-1.0000001f,-1.0000001f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.0000001f,-1.9999999f,-1.0000001f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.0000001f,-1.0000001f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.9999999f,-1.9999999f,-1.0000001f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.0000001f,-1.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.9999999f,-1.0000001f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == true

            //  Inverted-box == false   Always
            //      Impossible for a Point to be both:
            //          > Box_MinBounds
            //              AND
            //          < Box_MaxBounds
            && PointVsBox((2f,2f,2f), (3f,3f,3f), (-2f,-2f,-2f)) == false
            && PointVsBox((4f,4f,4f), (3f,3f,3f), (-2f,-2f,-2f)) == false
        );

        //======================================================================================================================================================
        TEST("PointVsCylinder()",true
        #if Z_UP
            && PointVsCylinder((1f   , 1f   , 1f),    (1f ,1f, 0f), 1f, 2f) == true
            && PointVsCylinder((1f   , 1f   , 2f),    (1f ,1f, 0f), 1f, 2f) == true
            && PointVsCylinder((1f   , 1f   , 0f),    (1f ,1f, 0f), 1f, 2f) == true

            && PointVsCylinder((1.70f, 1.70f, 0f),    (1f, 1f, 0f), 1f, 2f) == true
            && PointVsCylinder((1.71f, 1.71f, 0f),    (1f, 1f, 0f), 1f, 2f) == false

            && PointVsCylinder((0.30f, 0.30f, 0f),    (1f, 1f, 0f), 1f, 2f) == true
            && PointVsCylinder((0.29f, 0.29f, 0f),    (1f, 1f, 0f), 1f, 2f) == false
        #else
            && PointVsCylinder((1f,    1f, 1f   ),    (1f, 0f ,1f), 1f, 2f) == true
            && PointVsCylinder((1f,    2f, 1f   ),    (1f, 0f ,1f), 1f, 2f) == true
            && PointVsCylinder((1f,    0f, 1f   ),    (1f, 0f ,1f), 1f, 2f) == true

            && PointVsCylinder((1.70f, 0f, 1.70f),    (1f, 0f, 1f), 1f, 2f) == true
            && PointVsCylinder((1.71f, 0f, 1.71f),    (1f, 0f, 1f), 1f, 2f) == false

            && PointVsCylinder((0.30f, 0f, 0.30f),    (1f, 0f, 1f), 1f, 2f) == true
            && PointVsCylinder((0.29f, 0f, 0.29f),    (1f, 0f, 1f), 1f, 2f) == false
        #endif
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        //######################################################################################################################################################
        //######################################################################################################################################################
        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("RayVsPlaneX()",true
            && RayVsPlaneX((2f,2f,2f),( 1f, 0f, 0f),  1f) == -1f
            && RayVsPlaneX((2f,2f,2f),(-1f, 0f, 0f),  1f) ==  1f
            && RayVsPlaneX((2f,2f,2f),( 0f, 1f, 0f),  1f) == RAY_MISS
            && RayVsPlaneX((2f,2f,2f),( 0f,-1f, 0f),  1f) == RAY_MISS
            && RayVsPlaneX((2f,2f,2f),( 0f, 0f, 1f),  1f) == RAY_MISS
            && RayVsPlaneX((2f,2f,2f),( 0f, 0f,-1f),  1f) == RAY_MISS
        );

        TEST("RayVsPlaneY()",true
            && RayVsPlaneY((2f,2f,2f),( 1f, 0f, 0f),  1f) == RAY_MISS
            && RayVsPlaneY((2f,2f,2f),(-1f, 0f, 0f),  1f) == RAY_MISS
            && RayVsPlaneY((2f,2f,2f),( 0f, 1f, 0f),  1f) == -1f
            && RayVsPlaneY((2f,2f,2f),( 0f,-1f, 0f),  1f) ==  1f
            && RayVsPlaneY((2f,2f,2f),( 0f, 0f, 1f),  1f) == RAY_MISS
            && RayVsPlaneY((2f,2f,2f),( 0f, 0f,-1f),  1f) == RAY_MISS
        );

        TEST("RayVsPlaneZ()",true
            && RayVsPlaneZ((2f,2f,2f),( 1f, 0f, 0f),  1f) == RAY_MISS
            && RayVsPlaneZ((2f,2f,2f),(-1f, 0f, 0f),  1f) == RAY_MISS
            && RayVsPlaneZ((2f,2f,2f),( 0f, 1f, 0f),  1f) == RAY_MISS
            && RayVsPlaneZ((2f,2f,2f),( 0f,-1f, 0f),  1f) == RAY_MISS
            && RayVsPlaneZ((2f,2f,2f),( 0f, 0f, 1f),  1f) == -1f
            && RayVsPlaneZ((2f,2f,2f),( 0f, 0f,-1f),  1f) ==  1f
        );

        //======================================================================================================================================================
        TEST("RayVsPlane()",true
            && RayVsPlane((2f,2f,2f),normalize(-1f,-1f,-1f),    ( 1f, 1f, 1f),normalize( 1f, 1f, 1f)).IsApproximately( SQRT3)
            && RayVsPlane((2f,2f,2f),normalize( 1f, 1f, 1f),    ( 1f, 1f, 1f),normalize( 1f, 1f, 1f)).IsApproximately(-SQRT3)

            && RayVsPlane((2f,2f,2f),normalize(-1f,-1f,-1f),    (-1f,-1f,-1f),normalize(-1f,-1f,-1f)).IsApproximately( SQRT3 * 3f)
            && RayVsPlane((2f,2f,2f),normalize( 1f, 1f, 1f),    (-1f,-1f,-1f),normalize(-1f,-1f,-1f)).IsApproximately(-SQRT3 * 3f)
        );

        #if false
            TESTOUT($"""
                {RayVsPlane((2f,2f,2f),normalize(-1f,-1f,-1f),    ( 1f, 1f, 1f),normalize( 1f, 1f, 1f))}    { SQRT3}
                {RayVsPlane((2f,2f,2f),normalize( 1f, 1f, 1f),    ( 1f, 1f, 1f),normalize( 1f, 1f, 1f))}    {-SQRT3}
                {RayVsPlane((2f,2f,2f),normalize(-1f,-1f,-1f),    (-1f,-1f,-1f),normalize(-1f,-1f,-1f))}    { SQRT3 * 3f}
                {RayVsPlane((2f,2f,2f),normalize( 1f, 1f, 1f),    (-1f,-1f,-1f),normalize(-1f,-1f,-1f))}    {-SQRT3 * 3f}
            """);
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("RayVsQuadX()",true
            && RayVsQuadX((2f,2f,2f),( 1f, 0f, 0f),    (1f,1f,1f),(1f,1f)) == -1f
            && RayVsQuadX((2f,2f,2f),(-1f, 0f, 0f),    (1f,1f,1f),(1f,1f)) ==  1f
            && RayVsQuadX((2f,2f,2f),( 0f, 1f, 0f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
            && RayVsQuadX((2f,2f,2f),( 0f,-1f, 0f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
            && RayVsQuadX((2f,2f,2f),( 0f, 0f, 1f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
            && RayVsQuadX((2f,2f,2f),( 0f, 0f,-1f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
        );

        TEST("RayVsQuadY()",true
            && RayVsQuadY((2f,2f,2f),( 1f, 0f, 0f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
            && RayVsQuadY((2f,2f,2f),(-1f, 0f, 0f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
            && RayVsQuadY((2f,2f,2f),( 0f, 1f, 0f),    (1f,1f,1f),(1f,1f)) == -1f
            && RayVsQuadY((2f,2f,2f),( 0f,-1f, 0f),    (1f,1f,1f),(1f,1f)) ==  1f
            && RayVsQuadY((2f,2f,2f),( 0f, 0f, 1f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
            && RayVsQuadY((2f,2f,2f),( 0f, 0f,-1f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
        );

        TEST("RayVsQuadZ()",true
            && RayVsQuadZ((2f,2f,2f),( 1f, 0f, 0f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
            && RayVsQuadZ((2f,2f,2f),(-1f, 0f, 0f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
            && RayVsQuadZ((2f,2f,2f),( 0f, 1f, 0f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
            && RayVsQuadZ((2f,2f,2f),( 0f,-1f, 0f),    (1f,1f,1f),(1f,1f)) == RAY_MISS
            && RayVsQuadZ((2f,2f,2f),( 0f, 0f, 1f),    (1f,1f,1f),(1f,1f)) == -1f
            && RayVsQuadZ((2f,2f,2f),( 0f, 0f,-1f),    (1f,1f,1f),(1f,1f)) ==  1f
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            vec3 R_p = (1f, 1f, 1f), R_n = (0f, 0f,-1f),    T_a = (1f, 2f, 0f), T_b = (0f, 0f, 0f), T_c = (2f, 0f, 0f);
            vec3 R1p = R_p.xzy,      R1n = R_n.xzy,         T1a = T_a.xzy,      T1b = T_b.xzy,      T1c = T_c.xzy;
            vec3 R2p = R_p.zyx,      R2n = R_n.zyx,         T2a = T_a.zyx,      T2b = T_b.zyx,      T2c = T_c.zyx;

            TEST("RayVsTriangle()",true
                && RayVsTriangle(R_p, R_n, T_a, T_b, T_c, false) == 1f
                && RayVsTriangle(R_p, R_n, T_a, T_b, T_c, true)  == 1f

                && RayVsTriangle(R1p, R1n, T1a, T1b, T1c, false) == RAY_MISS
                && RayVsTriangle(R1p, R1n, T1a, T1b, T1c, true)  == 1f

                && RayVsTriangle(R2p, R2n, T2a, T2b, T2c, false) == RAY_MISS
                && RayVsTriangle(R2p, R2n, T2a, T2b, T2c, true)  == 1f
            );

            #if false
                TESTOUT($"""

                    RayVsTriangle({R_p:0},{R_n:0},    {T_a:0},{T_b:0},{T_c:0}, false) == {RayVsTriangle(R_p, R_n, T_a, T_b, T_c, false),2}
                    RayVsTriangle({R_p:0},{R_n:0},    {T_a:0},{T_b:0},{T_c:0}, true ) == {RayVsTriangle(R_p, R_n, T_a, T_b, T_c, true ),2}

                    RayVsTriangle({R1p:0},{R1n:0},    {T1a:0},{T1b:0},{T1c:0}, false) == {RayVsTriangle(R1p, R1n, T1a, T1b, T1c, false),2}
                    RayVsTriangle({R1p:0},{R1n:0},    {T1a:0},{T1b:0},{T1c:0}, true ) == {RayVsTriangle(R1p, R1n, T1a, T1b, T1c, true ),2}

                    RayVsTriangle({R2p:0},{R2n:0},    {T2a:0},{T2b:0},{T2c:0}, false) == {RayVsTriangle(R2p, R2n, T2a, T2b, T2c, false),2}
                    RayVsTriangle({R2p:0},{R2n:0},    {T2a:0},{T2b:0},{T2c:0}, true ) == {RayVsTriangle(R2p, R2n, T2a, T2b, T2c, true ),2}
                """);
            #endif
        }

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("RayVsBox()",true
            && RayVsBox((1.5f, 1.5f, 5.0f),(        0f,        0f,       -1f),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(3f)

            && RayVsBox((0.0f, 0.0f, 2.5f),( SQRT3_RCP, SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)
            && RayVsBox((0.0f, 0.0f, 3.0f),( SQRT3_RCP, SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)
            && RayVsBox((0.0f, 0.0f, 3.5f),( SQRT3_RCP, SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3 * 1.5f)

            && RayVsBox((0.0f, 0.0f,-0.5f),( SQRT3_RCP, SQRT3_RCP, SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3 * 1.5f)
            && RayVsBox((0.0f, 0.0f, 0.0f),( SQRT3_RCP, SQRT3_RCP, SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)
            && RayVsBox((0.0f, 0.0f, 0.5f),( SQRT3_RCP, SQRT3_RCP, SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)

            && RayVsBox((2.5f, 2.5f, 3.0f),(-SQRT3_RCP,-SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)
            && RayVsBox((3.0f, 3.0f, 3.0f),(-SQRT3_RCP,-SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)
            && RayVsBox((3.5f, 3.5f, 3.0f),(-SQRT3_RCP,-SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3 * 1.5f)
        );
        /*
        TESTOUT($"""

        RAYvsBOX    Rp: {Rp:0.000}    Rn: {Rn:0.000}    Rnr: {Rnr:0.000}    Bp: {Bp:0.000}    Bs: {Bs:0.000}

                                  Dist To Near: {DistNear:0.000}
                                   Dist To Far: {DistFar:0.000}

                             Dist To FrontFace: {DistToFrontFace:0.000}
                              Dist To BackFace: {DistToBackFace:0.000}

            (DistToFrontFace > DistToBackFace): {(DistToFrontFace > DistToBackFace)}
            (DistToBackFace  <             0f): {(DistToBackFace  <             0f)}
            (DistToFrontFace <=            0f): {(DistToFrontFace <=            0f)}

                                        RESULT: {((DistToFrontFace > DistToBackFace) ? RAY_MISS
                                                : (DistToBackFace  <             0f) ? new vec4(Rp + (Rn*DistToBackFace), DistToBackFace)
                                                : (DistToFrontFace <=            0f) ? new vec4(Rp, 0f)
                                                                                     : new vec4(Rp + (Rn*DistToFrontFace), DistToFrontFace))}
        """);
        */

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("RayVsSphere()",true
            && RayVsSphere((-1,-1,-1), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 1, 1, 1), 1) != RAY_MISS
            && RayVsSphere((-1,-1,-1), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 1, 1, 1), 1).IsApproximately(SQRT3 + SQRT3 - 1f)

            && RayVsSphere(( 4,-1, 4), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 6, 1, 6), 1) != RAY_MISS
            && RayVsSphere(( 4,-1, 4), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 6, 1, 6), 1).IsApproximately(SQRT3 + SQRT3 - 1f)
        );

        //TESTOUT($"{RayVsSphere((-1,-1,-1), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 1, 1, 1), 1)}");
        //TESTOUT($"{(1f-SQRT3_RCP, 1f-SQRT3_RCP, 1f-SQRT3_RCP, SQRT3+SQRT3-1f)}");

        //TESTOUT($"{RayVsSphere(( 4,-1, 4), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 6, 1, 6), 1)}");
        //TESTOUT($"{(4f-SQRT3_RCP, 1f-SQRT3_RCP, 6f-SQRT3_RCP, SQRT3+SQRT3-1f)}");

        //TESTOUT($"{SQRT3_RCP}");
        //TESTOUT($"{1f-SQRT3_RCP}");
        //TESTOUT($"{new vec3(SQRT3_RCP, SQRT3_RCP, SQRT3_RCP).Length}");
        //TESTOUT($"{distance((-1,-1,-1), (1,1,1))}");

        //for (int i = -13; i <= 13; ++i) {
        //    TESTOUT(
        //        $"  {RayVsSphere((i/12f,0f,1f), (0f,0f,-1f),   (0f,0f,0f), 1f),-11}" +
        //        $"  {RayVsSphere((i/12f,0f,2f), (0f,0f,-1f),   (0f,0f,0f), 1f),-11}" +
        //        $"  {RayVsSphere((i/ 6f,0f,5f), (0f,0f,-1f),   (0f,0f,0f), 2f),-11}" +
        //        $"  {RayVsSphere((i/12f,0f,9f), (0f,0f,-1f),   (0f,0f,0f), 1f),-11}"
        //    );
        //}

        //======================================================================================================================================================
        {
            uint[] A = [
                0xFF, 0xFF, 0x00, 0x00, // [x, 0, 0]
                0x00, 0x00, 0x00, 0x00, // [x, 1, 0]
                0x00, 0x00, 0x00, 0x00, // [x, 2, 0]
                0x00, 0x00, 0x00, 0x00, // [x, 3, 0]

                0xFF, 0xFF, 0x00, 0x00, // [x, 0, 1]
                0xFF, 0xFF, 0xFF, 0xFF, // [x, 1, 1]
                0x00, 0x00, 0x00, 0x00, // [x, 2, 1]
                0x00, 0x00, 0x00, 0x00, // [x, 3, 1]

                0xFF, 0xFF, 0x00, 0x00, // [x, 0, 2]
                0xFF, 0xFF, 0x00, 0x00, // [x, 1, 2]
                0xFF, 0xFF, 0xFF, 0xFF, // [x, 2, 2]
                0x00, 0x00, 0x00, 0x00, // [x, 3, 2]

                0xFF, 0xFF, 0x00, 0x00, // [x, 0, 3]
                0xFF, 0xFF, 0x00, 0x00, // [x, 1, 3]
                0xFF, 0xFF, 0x00, 0x00, // [x, 2, 3]
                0x00, 0x00, 0xFF, 0xFF, // [x, 3, 3]
            ];

            float[] HitDist = new float[16];
            int[]   HitSide = new int[16];

            (HitDist[ 0], HitSide[ 0]) = RayVsVoxelChunk(( 2.5f, 1.5f, 0.0f),          ( 0f, 0f, 1f),   (1,1,1), (4,4,4), A);
            (HitDist[ 1], HitSide[ 1]) = RayVsVoxelChunk(( 2.5f, 2.5f, 0.0f),          ( 0f, 0f, 1f),   (1,1,1), (4,4,4), A);
            (HitDist[ 2], HitSide[ 2]) = RayVsVoxelChunk(( 2.5f, 3.5f, 0.0f),          ( 0f, 0f, 1f),   (1,1,1), (4,4,4), A);
            (HitDist[ 3], HitSide[ 3]) = RayVsVoxelChunk(( 2.5f, 4.5f, 0.0f),          ( 0f, 0f, 1f),   (1,1,1), (4,4,4), A);

            (HitDist[ 4], HitSide[ 4]) = RayVsVoxelChunk(( 3.5f, 1.5f, 6.0f),          ( 0f, 0f,-1f),   (1,1,1), (4,4,4), A);
            (HitDist[ 5], HitSide[ 5]) = RayVsVoxelChunk(( 3.5f, 2.5f, 6.0f),          ( 0f, 0f,-1f),   (1,1,1), (4,4,4), A);
            (HitDist[ 6], HitSide[ 6]) = RayVsVoxelChunk(( 3.5f, 3.5f, 6.0f),          ( 0f, 0f,-1f),   (1,1,1), (4,4,4), A);
            (HitDist[ 7], HitSide[ 7]) = RayVsVoxelChunk(( 3.5f, 4.5f, 6.0f),          ( 0f, 0f,-1f),   (1,1,1), (4,4,4), A);

            (HitDist[ 8], HitSide[ 8]) = RayVsVoxelChunk(( 2.0f, 1.5f, 2.0f),          ( 0f, 0f, 1f),   (1,1,1), (4,4,4), A);
            (HitDist[ 9], HitSide[ 9]) = RayVsVoxelChunk(( 2.0f, 2.5f, 2.0f),          ( 0f, 0f, 1f),   (1,1,1), (4,4,4), A);
            (HitDist[10], HitSide[10]) = RayVsVoxelChunk(( 2.0f, 3.5f, 2.0f),          ( 0f, 0f, 1f),   (1,1,1), (4,4,4), A);
            (HitDist[11], HitSide[11]) = RayVsVoxelChunk(( 2.0f, 4.5f, 2.0f),          ( 0f, 0f, 1f),   (1,1,1), (4,4,4), A);

            (HitDist[12], HitSide[12]) = RayVsVoxelChunk(( 0.0f, 1.5f, 0.0f), normalize( 1f, 0f, 1f),   (1,1,1), (4,4,4), A);
            (HitDist[13], HitSide[13]) = RayVsVoxelChunk(( 0.0f, 0.5f, 0.0f), normalize( 1f, 1f, 1f),   (1,1,1), (4,4,4), A);
            (HitDist[14], HitSide[14]) = RayVsVoxelChunk(( 0.0f, 1.5f,-1.0f), normalize( 1f, 0f, 2f),   (1,1,1), (4,4,4), A);
            (HitDist[15], HitSide[15]) = RayVsVoxelChunk(( 0.5f, 1.5f, 0.0f), normalize( 1f, 0f, 2f),   (1,1,1), (4,4,4), A);

            bool d00 = HitDist[ 0] ==       1f;                 bool s00 = HitSide[ 0] == 4;
            bool d01 = HitDist[ 1] ==       2f;                 bool s01 = HitSide[ 1] == 4;
            bool d02 = HitDist[ 2] ==       3f;                 bool s02 = HitSide[ 2] == 4;
            bool d03 = HitDist[ 3] == RAY_MISS;                 bool s03 = HitSide[ 3] == 4;

            bool d04 = HitDist[ 4] == RAY_MISS;                 bool s04 = HitSide[ 4] == 6;
            bool d05 = HitDist[ 5] ==       3f;                 bool s05 = HitSide[ 5] == 6;
            bool d06 = HitDist[ 6] ==       2f;                 bool s06 = HitSide[ 6] == 6;
            bool d07 = HitDist[ 7] ==       1f;                 bool s07 = HitSide[ 7] == 6;

            bool d08 = HitDist[ 8] ==       0f;                 bool s08 = HitSide[ 8] == 4;
            bool d09 = HitDist[ 9] ==       0f;                 bool s09 = HitSide[ 9] == 4;
            bool d10 = HitDist[10] ==       1f;                 bool s10 = HitSide[10] == 4;
            bool d11 = HitDist[11] == RAY_MISS;                 bool s11 = HitSide[11] == 4;

            bool d12 = HitDist[12].IsApproximately(SQRT2     ); bool s12 = HitSide[12] == 4;
            bool d13 = HitDist[13].IsApproximately(SQRT3     ); bool s13 = HitSide[13] == 4;
            bool d14 = HitDist[14].IsApproximately(SQRT5     ); bool s14 = HitSide[14] == 4;
            bool d15 = HitDist[15].IsApproximately(SQRT5 / 2f); bool s15 = HitSide[15] == 4;

            TEST("RayVsVoxelChunk()",true
                && d00 && s00
                && d01 && s01
                && d02 && s02
                && d03 && s03
                && d04 && s04
                && d05 && s05
                && d06 && s06
                && d07 && s07
                && d08 && s08
                && d09 && s09
                && d10 && s10
                && d11 && s11
                && d12 && s12
                && d13 && s13
                && d14 && s14
                && d15 && s15
            );

            #if false
                string HitSideStr(int i) => (i==0?"-X" : i==2?"+X" : i==1?"-Y" : i==3?"+Y" : i==4?"-Z" : i==6?"+Z" : "?");
                TESTOUT($"""
                    [ 0]  Dist: {HitDist[ 0],26:N24}    Side[{HitSide[ 0]}] "{HitSideStr(HitSide[ 0])}"     {d00,5} && {s00,5}
                    [ 1]  Dist: {HitDist[ 1],26:N24}    Side[{HitSide[ 1]}] "{HitSideStr(HitSide[ 1])}"     {d01,5} && {s01,5}
                    [ 2]  Dist: {HitDist[ 2],26:N24}    Side[{HitSide[ 2]}] "{HitSideStr(HitSide[ 2])}"     {d02,5} && {s02,5}
                    [ 3]  Dist: {HitDist[ 3],26:N24}    Side[{HitSide[ 3]}] "{HitSideStr(HitSide[ 3])}"     {d03,5} && {s03,5}

                    [ 4]  Dist: {HitDist[ 4],26:N24}    Side[{HitSide[ 4]}] "{HitSideStr(HitSide[ 4])}"     {d04,5} && {s04,5}
                    [ 5]  Dist: {HitDist[ 5],26:N24}    Side[{HitSide[ 5]}] "{HitSideStr(HitSide[ 5])}"     {d05,5} && {s05,5}
                    [ 6]  Dist: {HitDist[ 6],26:N24}    Side[{HitSide[ 6]}] "{HitSideStr(HitSide[ 6])}"     {d06,5} && {s06,5}
                    [ 7]  Dist: {HitDist[ 7],26:N24}    Side[{HitSide[ 7]}] "{HitSideStr(HitSide[ 7])}"     {d07,5} && {s07,5}

                    [ 8]  Dist: {HitDist[ 8],26:N24}    Side[{HitSide[ 8]}] "{HitSideStr(HitSide[ 8])}"     {d08,5} && {s08,5}
                    [ 9]  Dist: {HitDist[ 9],26:N24}    Side[{HitSide[ 9]}] "{HitSideStr(HitSide[ 9])}"     {d09,5} && {s09,5}
                    [10]  Dist: {HitDist[10],26:N24}    Side[{HitSide[10]}] "{HitSideStr(HitSide[10])}"     {d10,5} && {s10,5}
                    [11]  Dist: {HitDist[11],26:N24}    Side[{HitSide[11]}] "{HitSideStr(HitSide[11])}"     {d11,5} && {s11,5}

                    [12]  Dist: {HitDist[12],26:N24}    Side[{HitSide[12]}] "{HitSideStr(HitSide[12])}"     {d12,5} && {s12,5}
                    [13]  Dist: {HitDist[13],26:N24}    Side[{HitSide[13]}] "{HitSideStr(HitSide[13])}"     {d13,5} && {s13,5}
                    [14]  Dist: {HitDist[14],26:N24}    Side[{HitSide[14]}] "{HitSideStr(HitSide[14])}"     {d14,5} && {s14,5}
                    [15]  Dist: {HitDist[15],26:N24}    Side[{HitSide[15]}] "{HitSideStr(HitSide[15])}"     {d15,5} && {s15,5}
                """);
            #endif
        }

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
