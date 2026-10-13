
namespace Utility;
internal static partial class VEC_Geometry {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] internal static float Area(float Size_x, float Size_y) => (Size_x * Size_y);
    [In(line)] internal static float Area(vec2 Size)                  => (Size.x * Size.y);

    [In(line)] internal static  int  Area(int Size_x, int Size_y) => (Size_x * Size_y);
    [In(line)] internal static  int  Area(ivec2 Size)             => (Size.x * Size.y);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static float Volume(float Size_x, float Size_y, float Size_z) => (Size_x * Size_y * Size_z);
    [In(line)] internal static float Volume(vec3 Size)                                => (Size.x * Size.y * Size.z);

    [In(line)] internal static  int  Volume(int Size_x, int Size_y, int Size_z) => (Size_x * Size_y * Size_z);
    [In(line)] internal static  int  Volume(ivec3 Size)                         => (Size.x * Size.y * Size.z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] internal static float Circle_SurfaceArea(float Rds=1f) => PI * (Rds*Rds);

    //==========================================================================================================================================================
    [In(line)] internal static float Triangle_SurfaceArea(vec2 A, vec2 B, vec2 C) => abs(A.x*(B.y-C.y) + B.x*(C.y-A.y) + C.x*(A.y-B.y)) * 0.5f;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
  //[In(line)] internal static float Cylinder_SurfaceA__a(float Rds=1f, float Height=2f) => (PI2 * (Rds*Rds)) + (PI2 * Rds * Height);
    [In(line)] internal static float Cylinder_SurfaceArea(float Rds=1f, float Height=2f) => PI2 *  Rds      * (Rds + Height);
    [In(line)] internal static float Cylinder_Volume     (float Rds=1f, float Height=2f) => PI  * (Rds*Rds) *        Height;

    //==========================================================================================================================================================
    [In(line)] internal static float Sphere_SurfaceArea(float Rds=1f) => PI4   * (Rds*Rds);
    [In(line)] internal static float Sphere_Volume     (float Rds=1f) => PI_43 * (Rds*Rds*Rds);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
