
namespace Utility;
internal static partial class VEC_Triangle {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/9d31eb577f
    //
    //  Returns 3 weights corresponding to a position relative to the 3 Points of a Triangle.
    //      Center == (1/3, 1/3, 1/3)
    //
    internal static vec3 Barycentric(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {
        vec2 dAB = Tb-Ta;
        vec2 dAC = Tc-Ta;
        vec2 dAP = P -Ta;

        float Scaler = 1f / cross(dAB, dAC);

        float wC = cross(dAB, dAP) * Scaler;
        float wB = cross(dAP, dAC) * Scaler;
        float wA = 1f - wB - wC;

        return new vec3(wA, wB, wC);
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //     (0,1)
    //          C
    //          |`.
    //          |  `.
    //          |    `.
    //          A------B
    //     (0,0)        (1,0)
    //
    [Impl(AggressiveInlining)] internal static vec3 Barycentric(vec2 P) => new vec3(1f-P.x-P.y, P.x, P.y);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] internal static vec3 NormalizeBary(vec3 W) => W / (W.x + W.y + W.z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] internal static v1 WeightedSum(v1 A,v1 B,            v2 W) => (A*W.x + B*W.y);
    [Impl(AggressiveInlining)] internal static v2 WeightedSum(v2 A,v2 B,            v2 W) => (A*W.x + B*W.y);
    [Impl(AggressiveInlining)] internal static v3 WeightedSum(v3 A,v3 B,            v2 W) => (A*W.x + B*W.y);
    [Impl(AggressiveInlining)] internal static v4 WeightedSum(v4 A,v4 B,            v2 W) => (A*W.x + B*W.y);

    [Impl(AggressiveInlining)] internal static v1 WeightedSum(v1 A,v1 B,v1 C,       v3 W) => (A*W.x + B*W.y + C*W.z);
    [Impl(AggressiveInlining)] internal static v2 WeightedSum(v2 A,v2 B,v2 C,       v3 W) => (A*W.x + B*W.y + C*W.z);
    [Impl(AggressiveInlining)] internal static v3 WeightedSum(v3 A,v3 B,v3 C,       v3 W) => (A*W.x + B*W.y + C*W.z);
    [Impl(AggressiveInlining)] internal static v4 WeightedSum(v4 A,v4 B,v4 C,       v3 W) => (A*W.x + B*W.y + C*W.z);

    [Impl(AggressiveInlining)] internal static v1 WeightedSum(v1 A,v1 B,v1 C,v1 D,  v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);
    [Impl(AggressiveInlining)] internal static v2 WeightedSum(v2 A,v2 B,v2 C,v2 D,  v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);
    [Impl(AggressiveInlining)] internal static v3 WeightedSum(v3 A,v3 B,v3 C,v3 D,  v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);
    [Impl(AggressiveInlining)] internal static v4 WeightedSum(v4 A,v4 B,v4 C,v4 D,  v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v1 BaryLinear(v1 A,v1 B,v1 C,  v2 P)                    => WeightedSum(A,B,C,  Barycentric(P));
    [Impl(AggressiveInlining)] internal static v2 BaryLinear(v2 A,v2 B,v2 C,  v2 P)                    => WeightedSum(A,B,C,  Barycentric(P));
    [Impl(AggressiveInlining)] internal static v3 BaryLinear(v3 A,v3 B,v3 C,  v2 P)                    => WeightedSum(A,B,C,  Barycentric(P));
    [Impl(AggressiveInlining)] internal static v4 BaryLinear(v4 A,v4 B,v4 C,  v2 P)                    => WeightedSum(A,B,C,  Barycentric(P));

    [Impl(AggressiveInlining)] internal static v1 BaryLinear(v1 A,v1 B,v1 C,  v2 P, v2 Ta,v2 Tb,v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));
    [Impl(AggressiveInlining)] internal static v2 BaryLinear(v2 A,v2 B,v2 C,  v2 P, v2 Ta,v2 Tb,v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));
    [Impl(AggressiveInlining)] internal static v3 BaryLinear(v3 A,v3 B,v3 C,  v2 P, v2 Ta,v2 Tb,v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));
    [Impl(AggressiveInlining)] internal static v4 BaryLinear(v4 A,v4 B,v4 C,  v2 P, v2 Ta,v2 Tb,v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/2uan3xr9qq
    //
    //  Test if a Point is inside of a Triangle's CircumCircle.
    //
    //      "Bias" is to prevent symmetrical triangles from getting stuck in an EdgeFlip loop.
    //          Value should be (B > 1.0) and (B < 1.1~)
    //
    internal static bool Delaunay(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc, float Bias = 1.0001f) {
        vec2 dAB = Tb-Ta;
        vec2 dAC = Tc-Ta;

        float Determinant = cross(normalize(dAB), normalize(dAC)); //  Epsilon check only works if this is normalized.

        vec2  Cp;   //  CircumCircle-Position
        float CrCr; //  CircumCircle-Radius   Squared

        if (abs(Determinant) < 0.001f) {
            //  Triangle points are Colinear, define CircumCircle by delta between furthest points.
            vec2 Tmin = min(Ta, Tb, Tc);
            vec2 Tmax = max(Ta, Tb, Tc);

            Cp = avg(Tmin, Tmax);

            CrCr = dot(Cp-Tmin);

        } else {
            Determinant = cross(dAB, dAC);

            float AB_AB = dot(dAB, Ta+Tb);
            float AC_AC = dot(dAC, Ta+Tc);

            Cp = new vec2(
                (dAC.y*AB_AB - dAB.y*AC_AC),
                (dAB.x*AC_AC - dAC.x*AB_AB)
            );
            Cp /= (2f * Determinant);

            CrCr = dot(Cp-Ta);
        }

        //  Scale Delta by Bias, because precision-error scales with magnitude.
        //  Do so before squaring, because a linear value doesn't work in "squared-space".
        //  All of this to avoid a couple of pesky sqrts.  :P
        return dot((Cp-P) * Bias) < CrCr;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
