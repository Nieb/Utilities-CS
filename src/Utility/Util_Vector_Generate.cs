
namespace Utility;
internal static partial class VEC_Generate {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/ct29koavbu
    //
    internal static vec2[] Phyllotaxis2(int Count, float Radius=1f) {
        vec2[] P = new vec2[Count+1];

        for (int i = 1; i <= Count; ++i) {
            float Theta = i * PHI_RAD;
            float Rds = Radius * sqrt((float)i / (float)Count);

            (float SinT, float CosT) = sincos(Theta);

            P[i] = new vec2(CosT, SinT) * Rds;
        }

        return P;
    }

    //==========================================================================================================================================================
    //
    //  https://www.desmos.com/3d/nrzvi76avc
    //
    internal static vec3[] Phyllotaxis3(int Count, float Radius=1f, float SphereCoverage=1f) {
        SphereCoverage = 1f - cos(SphereCoverage*PI);

        vec3[] P = new vec3[Count+1];

        for (int i = 0; i <= Count; ++i) {
            float Pch = asin(1f - (SphereCoverage*i / Count));
            float Yaw = i * PI2_PHI;

            (float SinPch, float CosPch) = sincos(Pch);
            (float SinYaw, float CosYaw) = sincos(Yaw);

            #if Z_UP
                P[i] = (
                    CosPch * SinYaw,
                   -CosPch * CosYaw,
                    SinPch
                );
            #else
                P[i] = (
                    CosPch * SinYaw,
                    SinPch,
                   -CosPch * CosYaw
                );
            #endif

            //P[i] = normalize(P[i]);
            P[i] *= Radius;
        }

        return P;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
