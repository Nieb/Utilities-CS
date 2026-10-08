
namespace Utility;
internal static partial class VEC_Triangle {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Returns 3 weights corresponding to a position relative to the 3 Points of a Triangle.
    //      Center == (1/3, 1/3, 1/3)
    //
    //     (0,1)
    //          C
    //          |`.
    //          |  `.
    //          |    `.
    //          A------B
    //     (0,0)        (1,0)
    //
    [In(line)] internal static vec3 Barycentric(vec2 P) => new vec3(1f-P.x-P.y, P.x, P.y);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Arbitrary Triangle version.
    //
    //  https://www.desmos.com/calculator/9d31eb577f
    //
    internal static vec3 Barycentric(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {
        vec2 dAB = Tb-Ta;
        vec2 dAC = Tc-Ta;
        vec2 dAP = P -Ta;

        float TheyCallMeTheNormalizer = 1f / cross(dAB, dAC);

        float wC = cross(dAB, dAP) * TheyCallMeTheNormalizer;
        float wB = cross(dAP, dAC) * TheyCallMeTheNormalizer;
        float wA = 1f - wB - wC;

        return new vec3(wA, wB, wC);
    }

    //==========================================================================================================================================================
    [In(line)] internal static vec3 NormalizeBary(vec3 W) => W / sumof(W);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/2uan3xr9qq
    //
    //  Test if a Point is inside of a Triangle's CircumCircle.
    //
    //      "Tolerance" is roughly a radian-angle threshold (less true as cross() value increases).
    //          EPS6 radians  ==  0.000_057~ degrees    1/17453~ of a degree
    //
    //      "Bias" is to prevent symmetrical triangles from getting stuck in an EdgeFlip loop.
    //          Value should be (B > 1.0) and (B < 1.1~)
    //
    internal static bool Delaunay(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc, /*float Tolerance=EPS6,*/ float Bias = 1.0001f) {
        vec2 dAB = Tb-Ta;
        vec2 dAC = Tc-Ta;

        float D = cross(normalize(dAB), normalize(dAC)); //  Epsilon check only works if this is normalized.

        vec2  Cp;   //  CircumCircle-Position
        float CrCr; //  CircumCircle-Radius   Squared

        if (abs(D) < EPS6) {
            //  Triangle points are Colinear, define CircumCircle by delta between furthest points.
            vec2 Tmin = min(Ta, Tb, Tc);
            vec2 Tmax = max(Ta, Tb, Tc);

            Cp = avg(Tmin, Tmax);

            CrCr = dot(Cp-Tmin);

        } else {
            D = cross(dAB, dAC);

            float AB_AB = dot(dAB, Ta+Tb);
            float AC_AC = dot(dAC, Ta+Tc);

            Cp = new vec2(
                (dAC.y*AB_AB - dAB.y*AC_AC),
                (dAB.x*AC_AC - dAC.x*AB_AB)
            );
            Cp /= (2f * D);

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
