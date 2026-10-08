
namespace Utility;
internal static class VEC_Collision2 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                   Point VS ***
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //             ●           > 0
    //
    //      A------●------B    = 0
    //
    //             ●           < 0
    //
    [In(line)] internal static float WhichSideOfLine(vec2 P, vec2 La, vec2 Lb) => cross(Lb-La, P-La);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] internal static bool PointVsPoint(vec2 Pa, vec2 Pb, float Tolerance) => PointVsCircle(Pa, Pb, Tolerance);

    //==========================================================================================================================================================
    //
    //      PointVsCircle(  Point,  CirclePosition,  CircleRadius  )
    //
    [In(line)] internal static bool PointVsCircle(vec2 P, vec2 Cp, float Cr) => dot(P-Cp) <= (Cr*Cr);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      PointVsLine(  Point,  Line-PointA,  Line-PointB,  Tolerance  )
    //
    [In(line)] internal static bool PointVsLine(vec2 P, vec2 La, vec2 Lb, float Tolerance) => CircleVsLine(P, Tolerance, La, Lb);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //       +Y           RectSize
    //          +--------●
    //          |        |
    //          |        |
    //          |        |
    //          ●--------+
    //   RectPos            +X
    //
    //        PointVsRect(  Point,  RectanglePosition,  RectangleSize  )
    //      PointVsBounds(  Point,  LowerBounds,  UpperBounds  )
    //
    [In(line)] internal static bool PointVsRect( vec2 P,  vec2 Rp,  vec2 Rs) => (P >= Rp && P <= Rp+Rs);
    [In(line)] internal static bool PointVsRect(ivec2 P, ivec2 Rp, ivec2 Rs) => (P >= Rp && P <  Rp+Rs);

    //==========================================================================================================================================================
    [In(line)] internal static bool PointVsBounds( vec2 P,  vec2 b0,  vec2 b1) => (P >= b0 && P <= b1);
    [In(line)] internal static bool PointVsBounds(ivec2 P, ivec2 b0, ivec2 b1) => (P >= b0 && P <  b1);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Weinding is Anti-Clockwise.
    //
    //         +Y   A
    //              ●
    //             / \
    //            /   \
    //           /     \
    //          ●-------●   +X
    //         B         C
    //
    // https://www.desmos.com/calculator/9d31eb577f
    //
    //      PointVsTriangle(  Point,  TrianglePointA,  TrianglePointB,  TrianglePointC  )
    //
    [In(line)] internal static bool PointVsTriangle(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {
        vec2 dPA = Ta - P;
        vec2 dPB = Tb - P;
        vec2 dPC = Tc - P;

        return (dPA.x*dPB.y >= dPA.y*dPB.x)
            && (dPB.x*dPC.y >= dPB.y*dPC.x)
            && (dPC.x*dPA.y >= dPC.y*dPA.x);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "Irregular Convex Quadrilateral"
    //  Weinding is Anti-Clockwise.
    //
    //      B
    //       ●---___
    //    +Y  \     `--___
    //         \          `--___    A
    //          \               `--●
    //           \                /
    //            \              /
    //             \            /
    //              \     __---●
    //               ●--``      D
    //              C              +X
    //
    //  https://www.desmos.com/calculator/eyeuk0o9oj
    //
    //      PointVsQuad(  Point,  QuadPointA,  QuadPointB,  QuadPointC,  QuadPointD  )
    //
    [In(line)] internal static bool PointVsQuad(vec2 P, vec2 Qa, vec2 Qb, vec2 Qc, vec2 Qd) {
        vec2 dPA = Qa - P;
        vec2 dPB = Qb - P;
        vec2 dPC = Qc - P;
        vec2 dPD = Qd - P;

        return (dPA.x*dPB.y >= dPA.y*dPB.x)
            && (dPB.x*dPC.y >= dPB.y*dPC.x)
            && (dPC.x*dPD.y >= dPC.y*dPD.x)
            && (dPD.x*dPA.y >= dPD.y*dPA.x);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "Irregular Convex Polygon"
    //  Weinding is Anti-Clockwise.
    //
    internal static bool PointVsPolygon(vec2 P, vec2[] Poly) {
        #if DEBUG
            if (Poly.Length < 3) throw new System.ArgumentException("Derp?");
        #endif

        vec2 dPA = Poly[0] - P;
        vec2 dPB;
        for (int i = 1; i <= Poly.Length; ++i) {
            dPB = Poly[(i >= Poly.Length) ? 0 : i] - P;

            if (dPA.x*dPB.y < dPA.y*dPB.x)
                return false;

            dPA = dPB;
        }

        return true;
    }

    //==========================================================================================================================================================
    //
    //  "Irregular Convex|Concave Polygon"
    //
    internal static bool PointVsPolygon_(vec2 P, vec2[] Poly) {
        #if DEBUG
            if (Poly.Length < 3) throw new System.ArgumentException("Derp?");
        #endif

        bool Inside = false;
        int iA = Poly.Length-1;

        for (int iB = 0; iB < Poly.Length; iB++) {
            bool DewIt = (
                (Poly[iA].y > P.y)  !=  (Poly[iB].y > P.y)
                &&
                (P.x   <   (Poly[iA].x-Poly[iB].x) * (P.y-Poly[iB].y) / (Poly[iA].y-Poly[iB].y)  +  Poly[iB].x)
            );

            if (DewIt)
                Inside = !Inside;

            iA = iB;
        }

        return Inside;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  Bounds VS ***
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      RectVsRect(  Rectangle1-Position,  Rectangle1-Size,  Rectangle2-Position,  Rectangle2-Size)
    //
    [In(line)] internal static bool RectVsRect( vec2 Rp1,  vec2 Rs1,  vec2 Rp2,  vec2 Rs2) => (Rp1+Rs1 >= Rp2  &&  Rp1 <= Rp2+Rs2);
    [In(line)] internal static bool RectVsRect(ivec2 Rp1, ivec2 Rs1, ivec2 Rp2, ivec2 Rs2) => (Rp1+Rs1 >= Rp2  &&  Rp1 <  Rp2+Rs2);

    //==========================================================================================================================================================
    [In(line)] internal static bool BoundsVsBounds( vec2 a0,  vec2 a1,  vec2 b0,  vec2 b1) => (a1 >= b0  &&  a0 <= b1);
    [In(line)] internal static bool BoundsVsBounds(ivec2 a0, ivec2 a1, ivec2 b0, ivec2 b1) => (a1 >= b0  &&  a0 <  b1);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      RectVsCircle(  Rectangle-Position,  Rectangle-Size,  Circle-Position,  Circle-Radius  )
    //
    [In(line)] internal static bool RectVsCircle(vec2 Rp, vec2 Rs, vec2 Cp, float Cr) => CircleVsRect(Cp, Cr, Rp, Rs);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  Circle VS ***
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      CircleVsCircle(  Circle1-Position,  Circle1-Radius,  Circle2-Position,  Circle2-Radius  )
    //
    [In(line)] internal static bool CircleVsCircle(vec2 Cp1, float Cr1, vec2 Cp2, float Cr2) => dot(Cp1-Cp2) <= (Cr1*Cr1 + Cr2*Cr2);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      CircleVsRect(  Circle-Position,  Circle-Radius,  Rectangle-Position,  Rectangle-Size  )
    //
    [In(line)] internal static bool CircleVsRect(vec2 Cp, float Cr, vec2 Rp, vec2 Rs)   => dot(min(0f,Cp-Rp) + max(0f,Cp-(Rp+Rs))) <= Cr*Cr;

    [In(line)] internal static bool CircleVsBounds(vec2 Cp, float Cr, vec2 b0, vec2 b1) => dot(min(0f,Cp-b0) + max(0f,Cp-b1)) <= Cr*Cr;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] internal static bool CircleVsLine(vec2 Cp, float Cr, vec2 La, vec2 Lb) {
        vec2 dAP = Cp - La;
        vec2 dAB = Lb - La;

        return dot(dAP - dAB*clamp(dot(dAP,dAB) / dot(dAB))) <= (Cr*Cr);
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static vec2 CircleVsLine(vec2 Cp, float Cr, vec2 La, vec2 Lb, bool ReturnHitPos) {
        vec2 dAP = Cp - La;
        vec2 dAB = Lb - La;

        float Dist = clamp(dot(dAP,dAB) / dot(dAB));
        vec2 HitPos = La + dAB*Dist;

        return (dot(Cp - HitPos) <= Cr*Cr) ? HitPos
                                           : new vec2(MISS);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] internal static bool CircleVsTriangle(vec2 Cp, float Cr, vec2 Ta, vec2 Tb, vec2 Tc) => (
            PointVsTriangle(Cp, Ta, Tb, Tc)  //  Is the CirclePos inside the Triangle?
        ||  CircleVsLine(Cp, Cr, Ta, Tb)     //  Is the Circle overlapping with any of the Triangle Edges?
        ||  CircleVsLine(Cp, Cr, Tb, Tc)
        ||  CircleVsLine(Cp, Cr, Tc, Ta)
    );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static vec2 CircleVsTriangle(vec2 Cp, float Cr, vec2 Ta, vec2 Tb, vec2 Tc, bool ReturnHitPos) {
        if (PointVsTriangle(Cp, Ta, Tb, Tc))
            return Cp;

        // CircleVsLine AB:
        vec2 dAB = Tb - Ta;
        vec2  HitPosA  = Ta + dAB*clamp(dot(Cp - Ta, dAB) / dot(dAB));
        float HitDistA = dot(Cp - HitPosA);

        // CircleVsLine BC:
        vec2 dBC = Tc - Tb;
        vec2  HitPosB  = Tb + dBC*clamp(dot(Cp - Tb, dBC) / dot(dBC));
        float HitDistB = dot(Cp - HitPosB);

        // CircleVsLine CA:
        vec2 dCA = Ta - Tc;
        vec2  HitPosC  = Tc + dCA*clamp(dot(Cp - Tc, dCA) / dot(dCA));
        float HitDistC = dot(Cp - HitPosC);

        float NearestDist = HitDistA;
        vec2  NearestPos  = HitPosA;
        if (HitDistB < NearestDist) {NearestDist = HitDistB; NearestPos = HitPosB;}
        if (HitDistC < NearestDist) {NearestDist = HitDistC; NearestPos = HitPosC;}

        if (NearestDist <= Cr*Cr)
            return NearestPos;

        return new vec2(MISS);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    Line VS ***
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  NOTE:  Parallel overlapping Lines will not test positive as a collision.
    //
    //      LineVsLine(  Line1-PointA,  Line1-PointB,  Line2-PointA,  Line2-PointB  )
    //
    internal static bool LineVsLine(vec2 L1a, vec2 L1b, vec2 L2a, vec2 L2b) {
        vec2 dL1 = L1b - L1a;
        vec2 dL2 = L2b - L2a;
        vec2 dAA = L1a - L2a;

        float d = cross(dL1, dL2);
        float r = cross(dL1, dAA) / d;
        float s = cross(dL2, dAA) / d;

        return (r >= 0f && r <= 1f)
            && (s >= 0f && s <= 1f);
    }

    //==========================================================================================================================================================
    //
    //  NOTE:  This is a bit half-baked.
    //
    internal static vec2 LineVsLine(vec2 L1a, vec2 L1b, vec2 L2a, vec2 L2b, float Tolerance) {
        vec2 dL1 = L1b - L1a;
        vec2 dL2 = L2b - L2a;
        vec2 dAA = L1a - L2a;

        float Denom = cross(dL1, dL2);

        //  Are the Lines parallel?
    ////if (abs(Denom) < EPS6)
    ////    return new vec2(MISS); //  Lines are Parallel.   Test if colinear ???

        float Dist1 = cross(dL2, dAA) / Denom;
        float Dist2 = cross(dL1, dAA) / Denom;

        //  Are nearest points between A & B?
    ////if (Dist1 < 0f || Dist1 > 1f || Dist2 < 0f || Dist2 > 1f)
    ////    return new vec2(MISS);

        vec2  P1 = L1a + (dL1 * Dist1);
        vec2  P2 = L2a + (dL2 * Dist2);

        return (dot(P1-P2) <= Tolerance*Tolerance) ? avg(P1, P2)
                                                   : new vec2(MISS);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
