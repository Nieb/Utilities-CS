
namespace Utility;
internal static partial class VEC_Generate {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Generate an array-of-points of a regular-polygon.
    //
    //  Point weinding is anti-clockwise.
    //  Though, using a negative radius will reverse the order.
    //
    //  https://www.desmos.com/calculator/ljqolw7ab1
    //
    internal static vec2[] Polygon(int Sides, float Radius=1f) {
        Sides = clamp(Sides, 3, 256);

        vec2[] Polygon = new vec2[Sides];

        float T = -PI2/Sides;

        for (int i = 0; i < Sides; ++i) {
            (float SinT, float CosT) = sincos(i * T);
            Polygon[i] = new vec2(SinT,CosT) * Radius;
        }

        return Polygon;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  SegmentCount is per-Quadrant.
    //
    //                        0            9
    //                    1 ,-+------------+-, 8
    //                     / \|            |/ \
    //                  2 +---a------------b---+ 7
    //                     \ /|            |\ /
    //                    3 *-+------------+-* 6
    //                        4            5
    //
    //      PolyLine(  A:(x,y), B:(x,y),    SegCount:2, Radius:1f  )
    //
    internal static vec2[] PolyLine(vec2 A, vec2 B, int SegCount, float Radius=1f) {
        SegCount = clamp(SegCount, 1, 64);
        int q1 =    SegCount;
        int q2 = q1+SegCount+1;
        int q3 = q2+SegCount;
        int q4 = q3+SegCount;

        vec2 AB = length(B-A, Radius);
        vec2 AZ = (-AB.y, AB.x); //  RotateLeft   a <---> 0

        vec2[] P = new vec2[4*SegCount + 2];

        P[ 0]   = A + AZ; //  a <---> 0
        P[q1]   = A - AB; //  a <---> 2
        P[q2-1] = A - AZ; //  a <---> 4

        P[q2]   = B - AZ; //  b <---> 5
        P[q3]   = B + AB; //  b <---> 7
        P[q4]   = B + AZ; //  b <---> 9

        if (SegCount > 1) {
            (float SinT, float CosT) = sincos(PIH/SegCount);
            for (int iSeg = 1; iSeg < SegCount; ++iSeg) {
                AZ = new vec2(
                    AZ.x*CosT - AZ.y*SinT, //  Rotate anti-clockwise.
                    AZ.x*SinT + AZ.y*CosT
                );
                P[   iSeg] = A +           AZ;
                P[q1+iSeg] = A + new vec2(-AZ.y,  AZ.x);
                P[q2+iSeg] = B + new vec2(-AZ.x, -AZ.y);
                P[q3+iSeg] = B + new vec2( AZ.y, -AZ.x);
            }
        }

        return P;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
