
namespace Utility;
internal static partial class VEC_Projection {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    "Projection"
    //  Get Nearest-Point-On-Line from Point.
    //
    //      project(  Point,  Line-Position,  Line-Normal  )
    //
    [In(line)] internal static vec2 Project(vec2 P, vec2 Lp, vec2 Ln) => Lp + Ln*dot(P-Lp, Ln);
    [In(line)] internal static vec3 Project(vec3 P, vec3 Lp, vec3 Ln) => Lp + Ln*dot(P-Lp, Ln);

    //==========================================================================================================================================================
    //
    //  Arbitrary-Line version.
    //
    //  NOTE:  Does not tell you if ProjectedPoint is inbetween A & B.
    //              SEE: PointVsLine()
    //
    //      projectAB(  Point,  Line-PointA,  Line-PointB  )
    //
    [In(line)] internal static vec2 ProjectAB(vec2 P, vec2 A, vec2 B) {vec2 dAB = B-A;  return A + dAB*( dot(P-A,dAB)/dot(dAB) );}
    [In(line)] internal static vec3 ProjectAB(vec3 P, vec3 A, vec3 B) {vec3 dAB = B-A;  return A + dAB*( dot(P-A,dAB)/dot(dAB) );}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Clamped version of ProjectAB()
    //
    //      NearestPointOnLine(  Point,  Line-PointA,  Line-PointB  )
    //
    [In(line)] internal static vec2 NearestPointOnLine(vec2 P, vec2 A, vec2 B) {vec2 dAB = B-A;  return A + dAB*clamp( dot(P-A,dAB)/dot(dAB) );}
    [In(line)] internal static vec3 NearestPointOnLine(vec3 P, vec3 A, vec3 B) {vec3 dAB = B-A;  return A + dAB*clamp( dot(P-A,dAB)/dot(dAB) );}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Project Point to a Line along an axis.
    //
    //  NOTE:  These assume the Point is already aligned with the Line on given axis.
    //         Otherwise, it's just projecting to the imaginary plane the Line exists along.
    //
    //      ProjectZ(  Point,  LinePointA, LinePointB  )
    //
    [In(line)] internal static vec3 ProjectOnX(vec3 P, vec3 A, vec3 B) {vec3 dAB = B-A;  float Dist = dot(P.yz-A.yz,dAB.yz)/dot(dAB.yz);  return A + dAB*Dist;}
    [In(line)] internal static vec3 ProjectOnY(vec3 P, vec3 A, vec3 B) {vec3 dAB = B-A;  float Dist = dot(P.xz-A.xz,dAB.xz)/dot(dAB.xz);  return A + dAB*Dist;}
    [In(line)] internal static vec3 ProjectOnZ(vec3 P, vec3 A, vec3 B) {vec3 dAB = B-A;  float Dist = dot(P.xy-A.xy,dAB.xy)/dot(dAB.xy);  return A + dAB*Dist;}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      NearestPointInBounds(  Point,  BoundsMin, BoundsMax  )
    //
    [In(line)] internal static  vec2 NearestPointInBounds( vec2 P,  vec2 b0,  vec2 b1) => clamp(P, b0, b1);
    [In(line)] internal static ivec2 NearestPointInBounds(ivec2 P, ivec2 b0, ivec2 b1) => clamp(P, b0, b1);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static  vec3 NearestPointInBounds( vec3 P,  vec3 b0,  vec3 b1) => clamp(P, b0, b1);
    [In(line)] internal static ivec3 NearestPointInBounds(ivec3 P, ivec3 b0, ivec3 b1) => clamp(P, b0, b1);

    //==========================================================================================================================================================
    //
    //  Furthest? Farthest? Farest?    FairestPointInBounds?
    //
    //      FarthestPointInBounds(  Point,  BoundsMin,               BoundsMax  )
    //      FarthestPointInBounds(  Point,  BoundsMin, BoundsCenter, BoundsMax  )
    //
    [In(line)] internal static  vec2 FarthestPointInBounds( vec2 P,  vec2 b0,            vec2 b1) => FarthestPointInBounds(P, b0, b0+(b1-b0)*0.5f, b1);
    [In(line)] internal static  vec2 FarthestPointInBounds( vec2 P,  vec2 b0,  vec2 bC,  vec2 b1) => new  vec2( (P.x > bC.x) ? b0.x : b1.x,
                                                                                                                (P.y > bC.y) ? b0.y : b1.y );

    [In(line)] internal static ivec2 FarthestPointInBounds(ivec2 P, ivec2 b0,           ivec2 b1) => FarthestPointInBounds(P, b0, b0+(b1-b0)/2, b1);
    [In(line)] internal static ivec2 FarthestPointInBounds(ivec2 P, ivec2 b0, ivec2 bC, ivec2 b1) => new ivec2( (P.x > bC.x) ? b0.x : b1.x,
                                                                                                                (P.y > bC.y) ? b0.y : b1.y );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static  vec3 FarthestPointInBounds( vec3 P,  vec3 b0,            vec3 b1) => FarthestPointInBounds(P, b0, b0+(b1-b0)*0.5f, b1);
    [In(line)] internal static  vec3 FarthestPointInBounds( vec3 P,  vec3 b0,  vec3 bC,  vec3 b1) => new  vec3( (P.x > bC.x) ? b0.x : b1.x,
                                                                                                                (P.y > bC.y) ? b0.y : b1.y,
                                                                                                                (P.z > bC.z) ? b0.z : b1.z );

    [In(line)] internal static ivec3 FarthestPointInBounds(ivec3 P, ivec3 b0,           ivec3 b1) => FarthestPointInBounds(P, b0, b0+(b1-b0)/2, b1);
    [In(line)] internal static ivec3 FarthestPointInBounds(ivec3 P, ivec3 b0, ivec3 bC, ivec3 b1) => new ivec3( (P.x > bC.x) ? b0.x : b1.x,
                                                                                                                (P.y > bC.y) ? b0.y : b1.y,
                                                                                                                (P.z > bC.z) ? b0.z : b1.z );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  NOTE:  Untested...
    //
    public static vec2 NearestPointInPolygon(vec2 P, vec2[] Poly) {
        #if DEBUG
            if (Poly.Length < 3) throw new System.ArgumentException("Derp?");
        #endif

        if (PointVsPolygon_(P, Poly))
            return P;

        vec2  NearestPnt  = default;
        float NearestDist = MAX_FLOAT;
        vec2 A = Poly[Poly.Length-1];

        for (int iB = 0; iB < Poly.Length; iB++) {
            vec2 B = Poly[iB];

            vec2  ClosePnt  = NearestPointOnLine(P, A, B);
            float CloseDist = dot(ClosePnt - P);

            if (CloseDist < NearestDist) {
                NearestDist = CloseDist;
                NearestPnt  = ClosePnt;
            }

            A = B;
        }

        return NearestPnt;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  NOTE:  This is a bit half-baked.
    //
    internal static vec3 ProjectRayToLine(vec3 Rp, vec3 Rn, vec3 A, vec3 B) {
        vec3 dAB =  B - A;
        vec3 dAP = Rp - A;

        float dotL  = dot(dAB);
        float dotRL = dot(Rn,dAB);

        float Determinant = dotL - dotRL*dotRL;

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DeltaAB:
        float Dist = (abs(Determinant) < EPS7) ? clamp(dot(dAP,dAB)                        / dotL)       //  If RayLine & Line are near parallel, project RayPos to Line.
                                               :      (dot(dAB,dAP) - dotRL * dot(Rn,dAP)) / Determinant;

        return A + dAB*Dist;
    }

    //==========================================================================================================================================================
    //
    //  NOTE:  This is a bit half-baked.
    //
    internal static vec3 ProjectLineToLine(vec3 L1a, vec3 L1b, vec3 L2a, vec3 L2b) {
        vec3 dAB1 = L1b - L1a;
        vec3 dAB2 = L2b - L2a;
        vec3 dAA  = L1a - L2a;

        float dotL1 = dot(dAB1);
        float dotL2 = dot(dAB2);
        float dotLL = dot(dAB1, dAB2);

        float Determinant = dotL1*dotL2 - dotLL*dotLL;

        //  Are Line1 & Line2 near parallel?               return mid point?
        if (abs(Determinant) < EPS7)
            return L2a;

        //  Distance from Line2PointA to NearestPointOnLine, as multiple of DeltaAB2:
        float Dist = (dotL1*dot(dAB2,dAA) - dotLL*dot(dAB1,dAA)) / Determinant;

        return L2a + dAB2*Dist;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
