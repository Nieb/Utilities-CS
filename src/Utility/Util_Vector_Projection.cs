
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
    [Impl(AggressiveInlining)] internal static vec2 project(vec2 P, vec2 Lp, vec2 Ln) => Lp + Ln*dot(P-Lp, Ln);
    [Impl(AggressiveInlining)] internal static vec3 project(vec3 P, vec3 Lp, vec3 Ln) => Lp + Ln*dot(P-Lp, Ln);

    //==========================================================================================================================================================
    //
    //  Arbitrary-Line version.
    //
    //  NOTE:   Does not tell you if ProjectedPoint is inbetween A & B.
    //              SEE: PointVsLine()
    //
    //      projectAB(  Point,  Line-PointA,  Line-PointB  )
    //
    [Impl(AggressiveInlining)] internal static vec2 projectAB(vec2 P, vec2 A, vec2 B) {vec2 dAB = B-A;  return A + dAB*( dot(P-A,dAB)/dot(dAB) );}
    [Impl(AggressiveInlining)] internal static vec3 projectAB(vec3 P, vec3 A, vec3 B) {vec3 dAB = B-A;  return A + dAB*( dot(P-A,dAB)/dot(dAB) );}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Clamped version of projectAB()
    //
    [Impl(AggressiveInlining)] internal static vec2 NearestPointOnLine(vec2 P, vec2 A, vec2 B) {vec2 dAB = B-A;  return A + dAB*clamp( dot(P-A,dAB)/dot(dAB) );}
    [Impl(AggressiveInlining)] internal static vec3 NearestPointOnLine(vec3 P, vec3 A, vec3 B) {vec3 dAB = B-A;  return A + dAB*clamp( dot(P-A,dAB)/dot(dAB) );}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Project Point to a Line along an axis.
    //
    //  These assume the Point is already aligned with the Line on given axis.
    //  Otherwise, it's just projecting to the imaginary plane the Line exists along.
    //
    //      ProjectZ(  Point,  LinePointA, LinePointB  )
    //
    internal static vec3 ProjectX(vec3 P, vec3 A, vec3 B) {
        vec2 dAB = B.yz - A.yz;
        float lenSq = dot(dAB);

        //  Is Line colinear with axis?
        if (lenSq < EPS7) return A;

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DeltaAB:
        float Dist = dot(P.yz-A.yz, dAB) / lenSq;

        return A + (B-A)*Dist;
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static vec3 ProjectY(vec3 P, vec3 A, vec3 B) {
        vec2 dAB = B.xz - A.xz;
        float lenSq = dot(dAB);

        //  Is Line colinear with axis?
        if (lenSq < EPS7) return A;

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DeltaAB:
        float Dist = dot(P.xz-A.xz, dAB) / lenSq;

        return A + (B-A)*Dist;
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static vec3 ProjectZ(vec3 P, vec3 A, vec3 B) {
        vec2 dAB = B.xy - A.xy;
        float lenSq = dot(dAB);

        //  Is Line colinear with axis?
        if (lenSq < EPS7) return A;

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DeltaAB:
        float Dist = dot(P.xy-A.xy, dAB) / lenSq;

        return A + (B-A)*Dist;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      NearestPointInBounds(  Point,  BoundsMin, BoundsMax  )
    //
    [Impl(AggressiveInlining)] internal static  vec2 NearestPointInBounds( vec2 P,  vec2 b0,  vec2 b1) => P - (min(0f,P-b0) + max(0f,P-b1));
    [Impl(AggressiveInlining)] internal static ivec2 NearestPointInBounds(ivec2 P, ivec2 b0, ivec2 b1) => P - (min(0, P-b0) + max(0, P-b1));

    [Impl(AggressiveInlining)] internal static  vec3 NearestPointInBounds( vec3 P,  vec3 b0,  vec3 b1) => P - (min(0f,P-b0) + max(0f,P-b1));
    [Impl(AggressiveInlining)] internal static ivec3 NearestPointInBounds(ivec3 P, ivec3 b0, ivec3 b1) => P - (min(0, P-b0) + max(0, P-b1));

    //==========================================================================================================================================================
    //
    //      FarthestPointInBounds(  Point,  BoundsMin,               BoundsMax  )
    //      FarthestPointInBounds(  Point,  BoundsMin, BoundsCenter, BoundsMax  )
    //
    [Impl(AggressiveInlining)] internal static  vec2 FarthestPointInBounds( vec2 P,  vec2 b0,            vec2 b1) => FarthestPointInBounds(P, b0, b0+(b1-b0)*0.5f, b1);
    [Impl(AggressiveInlining)] internal static  vec2 FarthestPointInBounds( vec2 P,  vec2 b0,  vec2 bC,  vec2 b1) => new  vec2( (P.x > bC.x) ? b0.x : b1.x,
                                                                                                                                (P.y > bC.y) ? b0.y : b1.y );

    [Impl(AggressiveInlining)] internal static ivec2 FarthestPointInBounds(ivec2 P, ivec2 b0,           ivec2 b1) => FarthestPointInBounds(P, b0, b0+(b1-b0)/2, b1);
    [Impl(AggressiveInlining)] internal static ivec2 FarthestPointInBounds(ivec2 P, ivec2 b0, ivec2 bC, ivec2 b1) => new ivec2( (P.x > bC.x) ? b0.x : b1.x,
                                                                                                                                (P.y > bC.y) ? b0.y : b1.y );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static  vec3 FarthestPointInBounds( vec3 P,  vec3 b0,            vec3 b1) => FarthestPointInBounds(P, b0, b0+(b1-b0)*0.5f, b1);
    [Impl(AggressiveInlining)] internal static  vec3 FarthestPointInBounds( vec3 P,  vec3 b0,  vec3 bC,  vec3 b1) => new  vec3( (P.x > bC.x) ? b0.x : b1.x,
                                                                                                                                (P.y > bC.y) ? b0.y : b1.y,
                                                                                                                                (P.z > bC.z) ? b0.z : b1.z );

    [Impl(AggressiveInlining)] internal static ivec3 FarthestPointInBounds(ivec3 P, ivec3 b0,           ivec3 b1) => FarthestPointInBounds(P, b0, b0+(b1-b0)/2, b1);
    [Impl(AggressiveInlining)] internal static ivec3 FarthestPointInBounds(ivec3 P, ivec3 b0, ivec3 bC, ivec3 b1) => new ivec3( (P.x > bC.x) ? b0.x : b1.x,
                                                                                                                                (P.y > bC.y) ? b0.y : b1.y,
                                                                                                                                (P.z > bC.z) ? b0.z : b1.z );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static vec3 ProjectRayToLine(vec3 Rp, vec3 Rn, vec3 A, vec3 B) {
        vec3 dAB =  B - A;
        vec3 dAP = Rp - A;

        float dotL  = dot(dAB);
        float dotRL = dot(Rn,dAB);

        float Determinant = dotL - dotRL*dotRL;

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DeltaAB:
        float Dist = (abs(Determinant) < EPS7) ?  dot(dAP,dAB)                        / dotL        //  If RayLine & Line are near parallel, project RayPos to Line.
                                               : (dot(dAB,dAP) - dotRL * dot(Rn,dAP)) / Determinant;
        return A + dAB*Dist;
    }

    //==========================================================================================================================================================
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
