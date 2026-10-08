
namespace Utility;
internal static partial class VEC_Collision3 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    Ray  VS  Surface
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      RayVsPlaneX(  Ray-Position,  Ray-Normal,    Plane-Position_X  )      Plane spans ZY.
    //      RayVsPlaneY(  Ray-Position,  Ray-Normal,    Plane-Position_Y  )      Plane spans XZ.
    //      RayVsPlaneZ(  Ray-Position,  Ray-Normal,    Plane-Position_Z  )      Plane spans XY.
    //
    [In(line)] internal static float RayVsPlaneX(vec3 Rp, vec3 Rn, float Pp_x) => (Pp_x - Rp.x) / Rn.x;
    [In(line)] internal static float RayVsPlaneY(vec3 Rp, vec3 Rn, float Pp_y) => (Pp_y - Rp.y) / Rn.y;
    [In(line)] internal static float RayVsPlaneZ(vec3 Rp, vec3 Rn, float Pp_z) => (Pp_z - Rp.z) / Rn.z;

    //==========================================================================================================================================================
    //
    //      RayVsPlane(  Ray-Position,  Ray-Normal,    Plane-Position,  Plane-Normal  )
    //
    [In(line)] internal static float RayVsPlane(vec3 Rp, vec3 Rn, vec3 Pp, vec3 Pn) => dot(Pn, Rp-Pp) / -dot(Rn, Pn);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      RayVsQuadX(  Ray-Position,  Ray-Normal,    Quad-Position,  Quad-Size  )     Quad spans ZY.
    //      RayVsQuadY(  Ray-Position,  Ray-Normal,    Quad-Position,  Quad-Size  )     Quad spans XZ.
    //      RayVsQuadZ(  Ray-Position,  Ray-Normal,    Quad-Position,  Quad-Size  )     Quad spans XY.
    //
    internal static float RayVsQuadX(vec3 Rp, vec3 Rn, vec3 Qp, vec2 Qs) {
        float HitDist = (Qp.x - Rp.x) / Rn.x;
        vec2 Hp2 = (Rp + (Rn*HitDist)).zy;
        vec2 Qp2 = Qp.zy;
        return (Hp2 >= Qp2 && Hp2 <= Qp2+Qs) ? HitDist : RAY_MISS;
    }

    internal static float RayVsQuadY(vec3 Rp, vec3 Rn, vec3 Qp, vec2 Qs) {
        float HitDist = (Qp.y - Rp.y) / Rn.y;
        vec2 Hp2 = (Rp + (Rn*HitDist)).xz;
        vec2 Qp2 = Qp.xz;
        return (Hp2 >= Qp2 && Hp2 <= Qp2+Qs) ? HitDist : RAY_MISS;
    }

    internal static float RayVsQuadZ(vec3 Rp, vec3 Rn, vec3 Qp, vec2 Qs) {
        float HitDist = (Qp.z - Rp.z) / Rn.z;
        vec2 Hp2 = (Rp + (Rn*HitDist)).xy;
        vec2 Qp2 = Qp.xy;
        return (Hp2 >= Qp2 && Hp2 <= Qp2+Qs) ? HitDist : RAY_MISS;
    }

    //==========================================================================================================================================================
    //
    //  Vertically Aligned Quad.
    //
    //       b1 ●_
    //          | `--__
    //          |      `--● a1
    //          |         |
    //          |         |
    //          |         |
    //          |         |
    //          |    __---● a0
    //       b0 ●--``
    //
#if Z_UP
    internal static float RayVsQuad(vec3 Rp, vec3 Rn,    vec3 a0, float a1_z, vec3 b0, float b1_z,  vec3 Wn) {
        //  RayVsPlane:
        float denom = dot(Wn, Rn);
        if (abs(denom) < EPS6) return RAY_MISS; //  Are Ray & Plane co-planar?

        float HitDist = dot(Wn, (a0 - Rp)) / denom;
        if (HitDist < 0f) return RAY_MISS; //  Is Plane in front of us?

        vec3 HitPos = Rp + (Rn * HitDist);

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //  Signed XY projection along wall:
        vec2  dAB    = b0.xy - a0.xy;
        float dAB_LL = dot(dAB, dAB);
      //if (dAB_LL < EPS6) return RAY_MISS; //  Does Quad exist!?

        //  Distance from LinePointA to HitPos, as multiple of DeltaAB.Length:
        float Dist = dot(HitPos.xy - a0.xy, dAB) / dAB_LL;
        if (Dist < 0f || Dist > 1f) return RAY_MISS; //  Is HitPos laterally on Quad?

        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        //  Z bounds at this XY position:
        float zBtm = Lerp(Dist, a0.z, b0.z);
        float zTop = Lerp(Dist, a1_z, b1_z);

        if (HitPos.z < zBtm || HitPos.z > zTop) return RAY_MISS;  //  Is HitPos vertically on Quad?

        return HitDist;
    }
#endif

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Weinding is Anti-Clockwise.
    //
    //      RayVsTriangle(  Ray-Position,  Ray-Normal,    Triangle-PointA,  Triangle-PointB,  Triangle-PointC,    BackFaceTest  )
    //
    internal static float RayVsTriangle(vec3 Rp, vec3 Rn,   vec3 Ta, vec3 Tb, vec3 Tc,   bool BackFaceTest=false) {
        vec3 dAB = Tb - Ta;
        vec3 dAC = Tc - Ta;

        vec3 H = cross(Rn, dAC);
        float Determinant = dot(dAB, H);

        //  Is Ray pointing in the same direction as SurfaceNormal?
        if (Determinant < 0f && !BackFaceTest)
            return RAY_MISS;

        //  Is Ray coplanar with Triangle Surface?
        //if (abs(Determinant) < EPS6)
        if (Determinant == 0f)
            return RAY_MISS;

        vec3 dAP = Rp - Ta;
        float DtrRcp = 1f/Determinant;
        float U = dot(dAP, H) * DtrRcp;

        //  Will intersection be inside of triangle?
        if (U < 0f || U > 1f)
            return RAY_MISS;

        vec3 Q = cross(dAP, dAB);
        float V = dot(Rn, Q) * DtrRcp;

        //  Will intersection be inside of triangle?
        if (V < 0f || U+V > 1f)
            return RAY_MISS;

        return dot(dAC, Q) * DtrRcp;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    Ray  VS  Volume
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      RayVsPoint(  Ray-Position,  Ray-Normal,  Point-Position,  Radius  )
    //
    [In(line)] internal static float RayVsPoint(vec3 Rp, vec3 Rn,    vec3 P, float Radius) => RayVsSphere(Rp,Rn, P,Radius);

    //==========================================================================================================================================================
    //
    //  https://www.desmos.com/calculator/zigiqzj8dm
    //
    //      RayVsSphere(  Ray-Position,  Ray-Normal,    Sphere-Position,  Sphere-Radius  )
    //
    internal static float RayVsSphere(vec3 Rp, vec3 Rn, vec3 Sp, float Sr) {
        vec3 dRS = Sp - Rp;

        float DistRP = dot(dRS, Rn); //  Distance         from  RayPos  to  ProjectedPoint.
        float DistRS = dot(dRS);     //  Distance-Squared from  RayPos  to  SpherePos.
        float dDist = DistRS - DistRP*DistRP;

        float SrSr  = Sr * Sr; //  SphereRadius squared.

        //  Is ProjectedPoint inside Sphere?
        return (dDist > SrSr) ? RAY_MISS
                              : DistRP - sqrt(SrSr - dDist);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  NOTE:   This function finds a Plane perpendicular to the RayNormal
    //          that has the shortest distance between the 2 points where the RayLine & Line intersect that Plane.
    //          With that said, the radius-test part of this function behaves in a 2D fashion.
    //          So, while it is similar, this is NOT a RayVsCapsule test.  As it does not give you a HitPos on the capsule's surface.
    //
    //                                      RadiusB
    //                 RadiusA       ___---+-.._
    //                      ,-+---```      '    `.
    //                    .`  '            '      ,
    //                   /    ' A          ' B    |
    //                   + - -●------------● - - -+
    //                   \    '            '      |
    //                    +_  '            '      '
    //                      `-+---___      '   _.`
    //                               ```---+-``
    //
    //      RayVsLine(  Ray-Position,  Ray-Normal,    LinePointA, RadiusA,  LinePointB, RadiusB  )
    //
    [In(line)] internal static float RayVsLine(vec3 Rp, vec3 Rn,    vec3 A, float Ar, vec3 B, float Br,    bool OffsetResult=true) {
        vec3 dAB =  B - A;
        vec3 dAP = Rp - A;

        float dotRL = dot(Rn,dAB);

        float Denom = dot(dAB) - dotRL*dotRL;

        if (abs(Denom) < EPS7) // this should probably branch to a RayVsPoint( nearest of A or B )...
            return RAY_MISS;

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DeltaAB:
        float DistA = clamp((dot(dAB,dAP) - dot(Rn,dAP)*dotRL) / Denom);
        vec3 NearestPointOnLine = A + dAB*DistA;

        //  Find the ClosestPointOnRay from NearestPointOnLine
        float DistR = max(0f, dot(NearestPointOnLine - Rp, Rn)); //  Clamp to infront-of-Ray.
        vec3 ClosestPointOnRay = Rp + Rn*DistR;

        float LineRadius = Lerp(DistA, Ar, Br);

        float DistToLine = dot(ClosestPointOnRay - NearestPointOnLine);

//if (DistToLine <= LineRadius*LineRadius)
//    PRINT($"  {DistR,8:####0.00}  -  {LineRadius,8:####0.00} * {dot(Rn,normalize(dAB)),8:####0.00} ");

        return (DistToLine > LineRadius*LineRadius) ? RAY_MISS
                                     : OffsetResult ? DistR - LineRadius //  Offset towards RayPos.
                                                    : DistR;
    }

    //==========================================================================================================================================================
    //
    //  Axis-Aligned.
    //
    //      RayVsLine(  Ray-Position,  Ray-Normal,    LinePointA, RadiusA,  LinePointB, RadiusB  )
    //
    [In(line)] internal static float RayVsLineX(vec3 Rp, vec3 Rn,    vec3 A, float Ar, float B_x, float Br,    bool OffsetResult=true) => RAY_MISS;

    [In(line)] internal static float RayVsLineY(vec3 Rp, vec3 Rn,    vec3 A, float Ar, float B_y, float Br,    bool OffsetResult=true) => RAY_MISS;

    [In(line)] internal static float RayVsLineZ(vec3 Rp, vec3 Rn,    vec3 A, float Ar, float B_z, float Br,    bool OffsetResult=true) => RAY_MISS;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      RayVsCapsule(  Ray-Position,  Ray-Normal,       Capsule-Position, Capsule-Radius, Capsule-Length  )
    //
    [In(line)] internal static float RayVsCapsuleX(vec3 Rp, vec3 Rn,    vec3 Cp, float Cr, float Cl) => RAY_MISS;

    [In(line)] internal static float RayVsCapsuleY(vec3 Rp, vec3 Rn,    vec3 Cp, float Cr, float Cl) => RAY_MISS;

    [In(line)] internal static float RayVsCapsuleZ(vec3 Rp, vec3 Rn,    vec3 Cp, float Cr, float Cl) => RAY_MISS;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      RayVsBox(  Ray-Position,  Ray-Normal,  Box-Position,  Box-Size  )
    //
    [In(line)] internal static float RayVsBox(vec3 Rp, vec3 Rn,    vec3 Bp, vec3 Bs) => RayVsBounds(Rp,Rn, Bp,Bp+Bs);

    //==========================================================================================================================================================
    //
    //      RayVsBounds(  Ray-Position,  Ray-Normal,  LowerBounds,  UpperBounds  )
    //
    internal static float RayVsBounds(vec3 Rp, vec3 Rn, vec3 b0, vec3 b1) {
        //  Distance to bounding-planes from RayPos along RayNrm, for 3 Axes, Near & Far, 6 total.
        //
        //                        Near X     Far X
        //                           |         |
        //                           v         v
        //                        +Y '         '
        //           Far Y ->  - - - +---------+
        //                          /|        /|
        //                         / |       / |
        //                        /  |      /  |
        //                       +---------+   | +X
        //          Near Y ->  - | - ●-----|---+ - -   <- Near Z
        //                       |  /      |  /
        //                       | /       | /
        //                       |/        |/
        //                       +---------+ - -   <- Far Z
        //                    +Z
        //
        vec3 DistNear = (b0 - Rp) / Rn; //  NOTE: DivByZero == -∞|∞
        vec3 DistFar  = (b1 - Rp) / Rn; //        is desired in cases where ray is coplanar with an axis-plane.

        //  Reorient (swap) relative to RayPos:
        (DistNear.x,DistFar.x) = (DistNear.x > DistFar.x) ? (DistFar.x,DistNear.x) : (DistNear.x,DistFar.x);
        (DistNear.y,DistFar.y) = (DistNear.y > DistFar.y) ? (DistFar.y,DistNear.y) : (DistNear.y,DistFar.y);
        (DistNear.z,DistFar.z) = (DistNear.z > DistFar.z) ? (DistFar.z,DistNear.z) : (DistNear.z,DistFar.z);

        //  Select PlaneHits in Quadrant/Octant of Box:
        float DistToBackFace  = minof(DistFar);
        float DistToFrontFace = maxof(DistNear);

        return (DistToFrontFace > DistToBackFace) ? RAY_MISS          //  Miss.
             : (DistToBackFace  <             0f) ? DistToBackFace    //  Box is behind RayPos.  Though, Ray-Line does intersect.
             : (DistToFrontFace <             0f) ? 0f                //  RayPos is inside Box.
                                                  : DistToFrontFace;  //  Hit.
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  3D Grid Traversal
    //
    //  This is a very precarious function. :(
    //
    //                   X    Y              Z
    //              -    1    2    -    -    5    6    -
    //                  / \  / \            / \  / \
    //                 /   \/   \          /   \/   \
    //                /    /\    \        /    /\    \
    //               /    /  \    \      /    /  \    \
    //    HitSide:  0    1    2    3    4    5    6    7
    //             -x   -Y   +x   +Y   -z        +z
    //
    //      (float HitDist, int HitSide) = RayVsVoxelChunk(  Ray-Position,  Ray-Normal,  VoxelChunk-Position,  VoxelChunk-Size,  Voxels  )
    //
    internal static float RayVsGrid(vec3 Rp, vec3 Rn,    vec3 Gp, ivec3 Gs, uint[] Grid) => RayVsVoxelChunk(Rp,Rn,  Gp,Gs,Grid).Item1;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static (float, int) RayVsVoxelChunk(vec3 Rp, vec3 Rn,    vec3 Vp, ivec3 Vs, uint[] Voxel) {
        #if DEBUG
            if      (Volume(Vs)-Voxel.Length < 0) throw new System.ArgumentException("  Volume(Voxel-Size) < Voxel.Length\n");
            else if (Volume(Vs)-Voxel.Length > 0) throw new System.ArgumentException("  Volume(Voxel-Size) > Voxel.Length\n");
        #endif

        vec3 Rnr = 1f / Rn;

        ivec3 RayStep_Dir = new ivec3(
            (Rn.x < 0f) ? -1 : 1,
            (Rn.y < 0f) ? -1 : 1,
            (Rn.z < 0f) ? -1 : 1
        );

        float PreHitDist = 0f;
        float    HitDist = 0f;
        int      HitSide = -1;

        /*  Have we not yet entered the bounds?  */{
            vec3 DistNear = ((Vp   ) - Rp) * Rnr;
            vec3 DistFar  = ((Vp+Vs) - Rp) * Rnr;

            (DistNear.x,DistFar.x) = (DistNear.x > DistFar.x) ? (DistFar.x,DistNear.x) : (DistNear.x,DistFar.x);
            (DistNear.y,DistFar.y) = (DistNear.y > DistFar.y) ? (DistFar.y,DistNear.y) : (DistNear.y,DistFar.y);
            (DistNear.z,DistFar.z) = (DistNear.z > DistFar.z) ? (DistFar.z,DistNear.z) : (DistNear.z,DistFar.z);

            float DistToBackFace = minof(DistFar);
            float DistToFrontFace;
            if      (DistNear.x > DistNear.y && DistNear.x > DistNear.z) {DistToFrontFace = DistNear.x;  HitSide = 1-RayStep_Dir.x;}
            else if (DistNear.y > DistNear.x && DistNear.y > DistNear.z) {DistToFrontFace = DistNear.y;  HitSide = 2-RayStep_Dir.y;}
            else                                                         {DistToFrontFace = DistNear.z;  HitSide = 5-RayStep_Dir.z;}

            if ((DistToFrontFace > DistToBackFace) || (DistToBackFace < 0f))
                return (RAY_MISS, -1);

            PreHitDist = max(0f, DistToFrontFace);

            Rp = (Rp-Vp) + (Rn*PreHitDist);
        }

        //======================================================================================================================================================
        vec3 RayStep_Dist = abs(Rnr);

        ivec3 RayCoord = SnapToInt(Rp);
        #if DEBUG
            if (RayCoord.x < 0 || RayCoord.x >  Vs.x) throw new System.IndexOutOfRangeException($"    (RayCoord.x < 0 || RayCoord.x >  Vs.x)  Rc:{RayCoord}  Vs:{Vs}");
            if (RayCoord.y < 0 || RayCoord.y >  Vs.y) throw new System.IndexOutOfRangeException($"    (RayCoord.y < 0 || RayCoord.y >  Vs.y)  Rc:{RayCoord}  Vs:{Vs}");
            if (RayCoord.z < 0 || RayCoord.z >  Vs.z) throw new System.IndexOutOfRangeException($"    (RayCoord.z < 0 || RayCoord.z >  Vs.z)  Rc:{RayCoord}  Vs:{Vs}");
        #endif

        if (RayCoord.x == Vs.x) RayCoord.x -= 1;
        if (RayCoord.y == Vs.y) RayCoord.y -= 1;
        if (RayCoord.z == Vs.z) RayCoord.z -= 1;
        #if DEBUG
            if (RayCoord.x < 0 || RayCoord.x >= Vs.x) throw new System.IndexOutOfRangeException($"    (RayCoord.x < 0 || RayCoord.x >= Vs.x)  Rc:{RayCoord}  Vs:{Vs}");
            if (RayCoord.y < 0 || RayCoord.y >= Vs.y) throw new System.IndexOutOfRangeException($"    (RayCoord.y < 0 || RayCoord.y >= Vs.y)  Rc:{RayCoord}  Vs:{Vs}");
            if (RayCoord.z < 0 || RayCoord.z >= Vs.z) throw new System.IndexOutOfRangeException($"    (RayCoord.z < 0 || RayCoord.z >= Vs.z)  Rc:{RayCoord}  Vs:{Vs}");
        #endif

        vec3 NextDist = RayStep_Dist * new vec3(
            (Rn.x < 0f) ? (Rp.x - RayCoord.x) : (RayCoord.x+1 - Rp.x),
            (Rn.y < 0f) ? (Rp.y - RayCoord.y) : (RayCoord.y+1 - Rp.y),
            (Rn.z < 0f) ? (Rp.z - RayCoord.z) : (RayCoord.z+1 - Rp.z)
        );

        //======================================================================================================================================================
        while (true) {
            //bool TieXY = abs(NextDist.x - NextDist.y) < EPS6;   //  The GridStep section should use these ???    Instead of just falling through to Step-on-Z.
            //bool TieXZ = abs(NextDist.x - NextDist.z) < EPS6;   //      Properly select an axis when tied?    Just cycle axis priority?
            //bool TieYZ = abs(NextDist.y - NextDist.z) < EPS6;   //      Or:  If an edge is hit 3 voxels should be checked.  If a corner is hit 7 voxels should be checked.

            if (RayCoord >= 0  &&  RayCoord < Vs) {
                if ((Voxel[idx(RayCoord,Vs)] & 0x000000FFu) != 0u) { //  if (Alpha != 0)      Assuming: RrGgBbAa (Red,Green,Blue,Alpha)
                    return (PreHitDist + HitDist, HitSide);
                }
            } else {
                //  We have exited the bounds of the VoxelChunk:
                return (RAY_MISS, HitSide);
            }

            //  Which Axis has a closer GridStep along Ray?
            if      (NextDist.x < NextDist.y && NextDist.x < NextDist.z) {RayCoord.x += RayStep_Dir.x;  HitSide = 1-RayStep_Dir.x;  HitDist = NextDist.x;  NextDist.x += RayStep_Dist.x;}
            else if (NextDist.y < NextDist.x && NextDist.y < NextDist.z) {RayCoord.y += RayStep_Dir.y;  HitSide = 2-RayStep_Dir.y;  HitDist = NextDist.y;  NextDist.y += RayStep_Dist.y;}
            else                                                         {RayCoord.z += RayStep_Dir.z;  HitSide = 5-RayStep_Dir.z;  HitDist = NextDist.z;  NextDist.z += RayStep_Dist.z;}
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
