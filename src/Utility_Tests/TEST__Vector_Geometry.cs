
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Geometry() {
        TESTOUT("\n[Utility.VEC -- Geometry]");

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("Circle_SurfaceArea()",true
            && Circle_SurfaceArea(1f/4f).IsApproximately(PI/16f)
            && Circle_SurfaceArea(1f/2f).IsApproximately(PI/ 4f)
            && Circle_SurfaceArea(1f   ).IsApproximately(PI)
            && Circle_SurfaceArea(2f   ).IsApproximately(PI* 4f)
            && Circle_SurfaceArea(4f   ).IsApproximately(PI*16f)
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("Triangle_SurfaceArea()", true
            // Degenerate triangle (straight line, zero area)
            && Triangle_SurfaceArea(new(0f, 0f), new(1f, 1f), new(2f, 2f)).IsApproximately(0f)

            // Standard unit right triangle (Area = 0.5)
            && Triangle_SurfaceArea(new(0f, 0f), new(1f, 0f), new(0f, 1f)).IsApproximately(0.5f)

            // Counter-clockwise vs Clockwise ordering (verifies abs handles negative signed area)
            && Triangle_SurfaceArea(new(0f, 0f), new(0f, 2f), new(2f, 0f)).IsApproximately(2f)
            && Triangle_SurfaceArea(new(0f, 0f), new(2f, 0f), new(0f, 2f)).IsApproximately(2f)

            // Fractional grid triangle from Pick's Theorem discussion (Base 1, Height 3 -> Area = 1.5)
            && Triangle_SurfaceArea(new(0f, 0f), new(1f, 0f), new(0f, 3f)).IsApproximately(1.5f)

            // Floating-point coordinates (Base 2.5, Height 4.0 -> Area = 5.0)
            && Triangle_SurfaceArea(new(1.5f, 1.0f), new(4.0f, 1.0f), new(1.5f, 5.0f)).IsApproximately(5.0f)
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("Cylinder_SurfaceArea()",true
            && Cylinder_SurfaceArea(Rds: 1f/2f, Height: 1f).IsApproximately(PI* 1.5f)
            && Cylinder_SurfaceArea(Rds: 1f   , Height: 2f).IsApproximately(PI* 6f)
            && Cylinder_SurfaceArea(Rds: 2f   , Height: 4f).IsApproximately(PI*24f)
            && Cylinder_SurfaceArea(Rds: 4f   , Height: 8f).IsApproximately(PI*96f)

          //&& Cylinder_SurfaceArea_(Rds: 1f/2f, Height: 1f).IsApproximately(PI* 1.5f)
          //&& Cylinder_SurfaceArea_(Rds: 1f   , Height: 2f).IsApproximately(PI* 6f)
          //&& Cylinder_SurfaceArea_(Rds: 2f   , Height: 4f).IsApproximately(PI*24f)
          //&& Cylinder_SurfaceArea_(Rds: 4f   , Height: 8f).IsApproximately(PI*96f)
        );

        //======================================================================================================================================================
        TEST("Cylinder_Volume()",true
            && Cylinder_Volume(Rds: 1f/2f, Height: 1f).IsApproximately(PI/ 4f)
            && Cylinder_Volume(Rds: 1f   , Height: 2f).IsApproximately(PI* 2f)
            && Cylinder_Volume(Rds: 2f   , Height: 4f).IsApproximately(PI*16f)
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        TEST("Sphere_SurfaceArea()",true
            && Sphere_SurfaceArea(1f/8f).IsApproximately(PI/16f)
            && Sphere_SurfaceArea(1f/4f).IsApproximately(PI/ 4f)
            && Sphere_SurfaceArea(1f/2f).IsApproximately(PI)
            && Sphere_SurfaceArea(1f   ).IsApproximately(PI* 4f)
            && Sphere_SurfaceArea(2f   ).IsApproximately(PI*16f)
        );

        //======================================================================================================================================================
        TEST("Sphere_Volume()", true
            && Sphere_Volume(1f/2f).IsApproximately(PI_43 / 8f)  // (1/2)^3 = 1/8
            && Sphere_Volume(1f   ).IsApproximately(PI_43)       // 1^3 = 1
            && Sphere_Volume(2f   ).IsApproximately(PI_43 * 8f)  // 2^3 = 8
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
