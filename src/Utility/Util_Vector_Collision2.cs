
namespace Utility;
internal static class VEC_Collision2 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
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
    [Impl(AggressiveInlining)] internal static float WhichSideOfLine(vec2 P, vec2 La, vec2 Lb) => cross(Lb-La, P-La);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] internal static bool PointVsPoint(vec2 Pa, vec2 Pb, float Tolerance) => PointVsCircle(Pa, Pb, Tolerance);

    //==========================================================================================================================================================
    //
    //      PointVsCircle(  Point,  CirclePosition,  CircleRadius  )
    //
    [Impl(AggressiveInlining)] internal static bool PointVsCircle(vec2 P, vec2 Cp, float Cr) => dot(P-Cp) <= (Cr*Cr);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      PointVsLine(  Point,  Line-PointA,  Line-PointB,  Tolerance  )
    //
    [Impl(AggressiveInlining)] internal static bool PointVsLine(vec2 P, vec2 La, vec2 Lb, float Tolerance) {
        vec2 dAP = P  - La;
        vec2 dAB = Lb - La;

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DeltaAB:
        float Dist = dot(dAP, dAB) / dot(dAB);

        return (Dist >= 0f && Dist <= 1f)
            && dot(dAP - dAB*Dist) <= (Tolerance*Tolerance);
    }

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
    //      PointVsRect(  Point,  RectanglePosition,  RectangleSize  )
    //
    [Impl(AggressiveInlining)] internal static bool PointVsRect( vec2 P,  vec2 Rp,  vec2 Rs) => (P >= Rp && P <= Rp+Rs);
    [Impl(AggressiveInlining)] internal static bool PointVsRect(ivec2 P, ivec2 Rp, ivec2 Rs) => (P >= Rp && P <  Rp+Rs);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static bool PointVsBounds( vec2 P,  vec2 b0,  vec2 b1) => (P >= b0 && P <= b1);
    [Impl(AggressiveInlining)] internal static bool PointVsBounds(ivec2 P, ivec2 b0, ivec2 b1) => (P >= b0 && P <  b1);

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
    [Impl(AggressiveInlining)] internal static bool PointVsTriangle(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {
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
    //  "Irregular Quadrilateral"
    //  Weinding is Anti-Clockwise.
    //  Quad must be convex.
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
    [Impl(AggressiveInlining)] internal static bool PointVsQuad(vec2 P, vec2 Qa, vec2 Qb, vec2 Qc, vec2 Qd) {
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
    //  "Irregular Polygon"
    //  Weinding is Anti-Clockwise.
    //  Polygon must be convex.
    //
    internal static bool PointVsPolygon(vec2 P, vec2[] Poly) {
        #if DEBUG
            if (Poly.Length < 3) throw new System.ArgumentException("Derp?");
            if (Poly.Length < 5) throw new System.ArgumentException("Use PointVsTri() or PointVsQuad() for polygons with sides fewer than 5.");
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

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      RectVsRect(  Rectangle1-Position,  Rectangle1-Size,  Rectangle2-Position,  Rectangle2-Size)
    //
    [Impl(AggressiveInlining)] internal static bool RectVsRect( vec2 Rp1,  vec2 Rs1,  vec2 Rp2,  vec2 Rs2) => (Rp1+Rs1 >= Rp2  &&  Rp1 <= Rp2+Rs2);
    [Impl(AggressiveInlining)] internal static bool RectVsRect(ivec2 Rp1, ivec2 Rs1, ivec2 Rp2, ivec2 Rs2) => (Rp1+Rs1 >= Rp2  &&  Rp1 <  Rp2+Rs2);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static bool BoundsVsBounds( vec2 a0,  vec2 a1,  vec2 b0,  vec2 b1) => (a1 >= b0  &&  a0 <= b1);
    [Impl(AggressiveInlining)] internal static bool BoundsVsBounds(ivec2 a0, ivec2 a1, ivec2 b0, ivec2 b1) => (a1 >= b0  &&  a0 <  b1);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      RectVsCircle(  Rectangle-Position,  Rectangle-Size,  Circle-Position,  Circle-Radius  )
    //
    [Impl(AggressiveInlining)] internal static bool RectVsCircle(vec2 Rp, vec2 Rs, vec2 Cp, float Cr) => CircleVsRect(Cp, Cr, Rp, Rs);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      CircleVsCircle(  Circle1-Position,  Circle1-Radius,  Circle2-Position,  Circle2-Radius  )
    //
    [Impl(AggressiveInlining)] internal static bool CircleVsCircle(vec2 Cp1, float Cr1, vec2 Cp2, float Cr2) => dot(Cp1-Cp2) <= (Cr1*Cr1 + Cr2*Cr2);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned.
    //
    //      CircleVsRect(  Circle-Position,  Circle-Radius,  Rectangle-Position,  Rectangle-Size  )
    //
    [Impl(AggressiveInlining)] internal static bool CircleVsRect(vec2 Cp, float Cr, vec2 Rp, vec2 Rs)   => dot(min(0f,Cp-Rp) + max(0f,Cp-(Rp+Rs))) <= Cr*Cr;

    [Impl(AggressiveInlining)] internal static bool CircleVsBounds(vec2 Cp, float Cr, vec2 b0, vec2 b1) => dot(min(0f,Cp-b0) + max(0f,Cp-b1)) <= Cr*Cr;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  NOTE:  Parallel overlapping Lines will not test positive as a collision.
    //
    //      LineVsLine(  Line1-PointA,  Line1-PointB,  Line2-PointA,  Line2-PointB  )
    //
    internal static bool LineVsLine(vec2 L1a, vec2 L1b, vec2 L2a, vec2 L2b) {
        //throw new System.Exception("This is gross, don't use it.");

        vec2 dL1 = L1b - L1a;
        vec2 dL2 = L2b - L2a;
        vec2 dAA = L1a - L2a;

        float d = cross(dL1, dL2);
        float r = cross(dL1, dAA) / d;
        float s = cross(dL2, dAA) / d;

        return (r >= 0f && r <= 1f)
            && (s >= 0f && s <= 1f);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      LineVsRect(  Line-PointA,  Line-PointB,  Rectangle-Position,  Rectangle-Size  )
    //
    internal static bool LineVsRect(vec2 La, vec2 Lb, vec2 Rp, vec2 Rs) {
        throw new System.Exception("This is gross, don't use it.");
        /*
        vec2 dL1 = Lb - La;
        vec2 L0 = ((dL1.x < 0f ? Lb.x    :   La.x),  (dL1.y < 0f) ? Lb.y : La.y);
        vec2 L1 = ((dL1.x < 0f ? La.x    :   Lb.x),  (dL1.y < 0f) ? La.y : Lb.y);

        vec2 R0 = ((Rs.x  < 0f ? Rp.x+Rs.x : Rp.x),  (Rs.y  < 0f) ? Rp.y+Rs.y : Rp.y);
        vec2 R1 = ((Rs.x  < 0f ? Rp.x : Rp.x+Rs.x),  (Rs.y  < 0f) ? Rp.y : Rp.y+Rs.y);
        Rs = R1 - R0;

        //  Is Area-of-Line over Area-of-Rectangle?
        if (L0 > R1 || L1 < R0) return false;

        //  Is PointB inside Rectangle?
        if (Lb >= R0 && Lb <= R1) return true;

        //  Is PointA inside Rectangle?
        if (La >= R0 && La <= R1) return true;

        vec2 dL2, dAA;
        float d, r, s;

        //  Are any of the 4 Rectangle-Lines colliding with the Line?
        dL2 = (Rs.x, 0f);
        d = cross(dL1, dL2);
        if (d != 0f) {
            dAA = La - R0;
            r = cross(dL1, dAA) / d;
            s = cross(dL2, dAA) / d;
            if ((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f)) return true;
        }

        dL2 = (0f, Rs.y);
        d = cross(dL1, dL2);
        if (d != 0f) {
            dAA = La - (R1.x, R0.y);
            r = cross(dL1, dAA) / d;
            s = cross(dL2, dAA) / d;
            if ((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f)) return true;
        }

        dL2 = (-Rs.x, 0f);
        d = cross(dL1, dL2);
        if (d != 0f) {
            dAA = La - R1;
            r = cross(dL1, dAA) / d;
            s = cross(dL2, dAA) / d;
            if ((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f)) return true;
        }

        //  The function will never make it here...
        dL2 = (0f, -Rs.y);
        d = cross(dL1, dL2);
        if (d != 0f) {
            dAA = La - (R0.x, R1.y);
            r = cross(dL1, dAA) / d;
            s = cross(dL2, dAA) / d;
            if ((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f)) return true;
        }

        return false;
        */
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      LineVsCircle(  Line-Point-A,  Line-Point-B,  Circle-Position,  Circle-Radius  )
    //
    internal static bool LineVsCircle(vec2 La, vec2 Lb, vec2 Cp, float Cr) {
        throw new System.Exception("This is gross, don't use it.");
        /*
        vec2 dBC = Cp - Lb;
        float CrCr = Cr*Cr;

        //  Is Line-PointB inside Circle?
        if (dot(dBC, dBC) <= CrCr)
            return true;

        //  Is Line-PointA inside Circle?
        vec2 dAC = Cp - La;
        if (dot(dAC, dAC) <= CrCr)
            return true;

        //  Get distance to NearestPointOnLine from Line-PointA as multiple of DeltaAB:
        vec2 dAB = Lb - La;
        float Scaler = dot(dAC, dAB) / dot(dAB, dAB);

        //  Is ProjectedPoint going to be between Line-PointA and Line-PointB:
        if (Scaler < 0f || Scaler > 1f)
            return false;

        //  CirclePos projected on to Line:
        vec2 Pp = La + dAB*Scaler;

        //  Is ProjectedPoint inside Circle?
        vec2 dPC = Pp - Cp;
        if (dot(dPC, dPC) <= CrCr)
            return true;

        return false;
        */
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
