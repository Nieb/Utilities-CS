
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
        TEST("Cylinder_SurfaceArea()",true
            && Cylinder_SurfaceArea(Rds: 1f/2f, Height: 1f).IsApproximately(PI* 1.5f)
            && Cylinder_SurfaceArea(Rds: 1f   , Height: 2f).IsApproximately(PI* 6f)
            && Cylinder_SurfaceArea(Rds: 2f   , Height: 4f).IsApproximately(PI*24f)
            && Cylinder_SurfaceArea(Rds: 4f   , Height: 8f).IsApproximately(PI*96f)

          //&& Cylinder_SurfaceAre_(Rds: 1f/2f, Height: 1f).IsApproximately(PI* 1.5f)
          //&& Cylinder_SurfaceAre_(Rds: 1f   , Height: 2f).IsApproximately(PI* 6f)
          //&& Cylinder_SurfaceAre_(Rds: 2f   , Height: 4f).IsApproximately(PI*24f)
          //&& Cylinder_SurfaceAre_(Rds: 4f   , Height: 8f).IsApproximately(PI*96f)
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
        TEST("Sphere_Volume()",true
            && Sphere_Volume(1f/2f).IsApproximately(PI*4f/3f / 4f)
            && Sphere_Volume(1f   ).IsApproximately(PI*4f/3f)
            && Sphere_Volume(2f   ).IsApproximately(PI*4f/3f * 4f)
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
