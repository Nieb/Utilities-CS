
namespace Utility;
internal static class VEC_Rotation {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                   "Rotate Left"
    //  Rotate 90 degrees Anti-Clockwise.
    //
    [Impl(AggressiveInlining)] internal static vec2 rotl(vec2 P) => new vec2(-P.y, P.x);

    [Impl(AggressiveInlining)] internal static vec3 rotXl(vec3 P) => new vec3( P.x,  P.z, -P.y);
    [Impl(AggressiveInlining)] internal static vec3 rotYl(vec3 P) => new vec3(-P.z,  P.y,  P.x);
    [Impl(AggressiveInlining)] internal static vec3 rotZl(vec3 P) => new vec3( P.y, -P.x,  P.z);

    //==========================================================================================================================================================
    //                                                                   "Rotate Right"
    //   Rotate 90 degrees Clockwise.
    //
    [Impl(AggressiveInlining)] internal static vec2 rotr(vec2 P) => new vec2(P.y, -P.x);

    [Impl(AggressiveInlining)] internal static vec3 rotXr(vec3 P) => new vec3( P.x, -P.z,  P.y);
    [Impl(AggressiveInlining)] internal static vec3 rotYr(vec3 P) => new vec3( P.z,  P.y, -P.x);
    [Impl(AggressiveInlining)] internal static vec3 rotZr(vec3 P) => new vec3(-P.y,  P.x,  P.z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static mat2 rot(float Theta) {
        if (Theta == 0.0f)
            return new();

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        return new mat2(
            CosT, -SinT,
            SinT,  CosT
        );
    }

    //==========================================================================================================================================================
    internal static vec2 rot(vec2 P, float Theta) {
        if (Theta == 0.0f)
            return P;

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        return new vec2(
            P.x*CosT - P.y*SinT,
            P.x*SinT + P.y*CosT
        );
    }

    //==========================================================================================================================================================
    internal static vec2 rot(vec2 P, vec2 Pivot, float Theta) {
        if (Theta == 0.0f)
            return P;

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        float d_x = P.x - Pivot.x;
        float d_y = P.y - Pivot.y;

        return new vec2(
            Pivot.x  +  d_x*CosT - d_y*SinT,
            Pivot.y  +  d_x*SinT + d_y*CosT
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Pitch"
    internal static mat4 pch(float Theta) {
        if (Theta == 0f)
            return new();

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        return new mat4(
            1f,   0f,   0f,   0f,
            0f, CosT,-SinT,   0f,
            0f, SinT, CosT,   0f,
            0f,   0f,   0f,   1f
        );
    }

    //==========================================================================================================================================================
    internal static vec3 pch(vec3 P, float Theta) {
        if (Theta == 0f)
            return P;

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        return new vec3(
                 P.x,
            CosT*P.y + -SinT*P.z,
            SinT*P.y +  CosT*P.z
        );
    }

    //==========================================================================================================================================================
    internal static vec3 pch(vec3 P, vec3 Pivot, float Theta) {
        if (Theta == 0f)
            return P;

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        float d_y = P.y - Pivot.y;
        float d_z = P.z - Pivot.z;

        return new vec3(
                P.x,
            Pivot.y  +  CosT*d_y + -SinT*d_z,
            Pivot.z  +  SinT*d_y +  CosT*d_z
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                       "Yaw"
#if Z_UP
    internal static mat4 rol(float Theta)
#else
    internal static mat4 yaw(float Theta)
#endif
    {
        if (Theta == 0f)
            return new();

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        return new mat4(
             CosT,   0f, SinT,   0f,
               0f,   1f,   0f,   0f,
            -SinT,   0f, CosT,   0f,
               0f,   0f,   0f,   1f
        );
    }

    //==========================================================================================================================================================
#if Z_UP
    internal static vec3 rol(vec3 P, float Theta)
#else
    internal static vec3 yaw(vec3 P, float Theta)
#endif
    {
        if (Theta == 0f)
            return P;

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        return new vec3(
             CosT*P.x + SinT*P.z,
                  P.y,
            -SinT*P.x + CosT*P.z
        );
    }

    //==========================================================================================================================================================
#if Z_UP
    internal static vec3 rol(vec3 P, vec3 Pivot, float Theta)
#else
    internal static vec3 yaw(vec3 P, vec3 Pivot, float Theta)
#endif
    {
        if (Theta == 0f)
            return P;

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        float d_x = P.x - Pivot.x;
        float d_z = P.z - Pivot.z;

        return new vec3(
            Pivot.x  +   CosT*d_x + SinT*d_z,
                P.y,
            Pivot.z  +  -SinT*d_x + CosT*d_z
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                       "Roll"
#if Z_UP
    internal static mat4 yaw(float Theta)
#else
    internal static mat4 rol(float Theta)
#endif
    {
        if (Theta == 0f)
            return new();

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        return new mat4(
            CosT,-SinT,   0f,   0f,
            SinT, CosT,   0f,   0f,
              0f,   0f,   1f,   0f,
              0f,   0f,   0f,   1f
        );
    }

    //==========================================================================================================================================================
#if Z_UP
    internal static vec3 yaw(vec3 P, float Theta)
#else
    internal static vec3 rol(vec3 P, float Theta)
#endif
    {
        if (Theta == 0f)
            return P;

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        return new vec3(
            CosT*P.x + -SinT*P.y,
            SinT*P.x +  CosT*P.y,
                 P.z
        );
    }

    //==========================================================================================================================================================
#if Z_UP
    internal static vec3 yaw(vec3 P, vec3 Pivot, float Theta)
#else
    internal static vec3 rol(vec3 P, vec3 Pivot, float Theta)
#endif
    {
        if (Theta == 0f)
            return P;

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.

        float d_x = P.x - Pivot.x;
        float d_y = P.y - Pivot.y;

        return new vec3(
            Pivot.x  +  CosT*d_x + -SinT*d_y,
            Pivot.y  +  SinT*d_x +  CosT*d_y,
                P.z
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static mat4 rot(vec3 Axis, float Theta) {
        if (Theta == 0f)
            return new();

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.
        float iCosT = 1f-CosT;

        float Ay_iCosT = Axis.y * iCosT;
        float Az_iCosT = Axis.z * iCosT;

        float Axx_iCosT = Axis.x * Axis.x*iCosT;
        float Axy_iCosT = Axis.x * Ay_iCosT;
        float Axz_iCosT = Axis.x * Az_iCosT;

        float Ayy_iCosT = Axis.y * Ay_iCosT;
        float Ayz_iCosT = Axis.y * Az_iCosT;

        float Azz_iCosT = Axis.z * Az_iCosT;

        float Ax_SinT = Axis.x * SinT;
        float Ay_SinT = Axis.y * SinT;
        float Az_SinT = Axis.z * SinT;

        return new mat4(
            (Axx_iCosT +    CosT), (Axy_iCosT - Az_SinT), (Axz_iCosT + Ay_SinT), 0f,
            (Axy_iCosT + Az_SinT), (Ayy_iCosT +    CosT), (Ayz_iCosT - Ax_SinT), 0f,
            (Axz_iCosT - Ay_SinT), (Ayz_iCosT + Ax_SinT), (Azz_iCosT +    CosT), 0f,
                               0f,                    0f,                    0f, 1f
        );
    }

    //==========================================================================================================================================================
    internal static vec3 rot(vec3 P, vec3 Axis, float Theta) {
        if (Theta == 0f)
            return P;

        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.
        float iCosT = 1f-CosT;

        float Ay_iCosT = Axis.y * iCosT;
        float Az_iCosT = Axis.z * iCosT;

        float Axx_iCosT = Axis.x * Axis.x*iCosT;
        float Axy_iCosT = Axis.x * Ay_iCosT;
        float Axz_iCosT = Axis.x * Az_iCosT;

        float Ayy_iCosT = Axis.y * Ay_iCosT;
        float Ayz_iCosT = Axis.y * Az_iCosT;

        float Azz_iCosT = Axis.z * Az_iCosT;

        float Ax_SinT = Axis.x * SinT;
        float Ay_SinT = Axis.y * SinT;
        float Az_SinT = Axis.z * SinT;

        return new vec3(
            P.x*(Axx_iCosT +    CosT)  +  P.y*(Axy_iCosT - Az_SinT)  +  P.z*(Axz_iCosT + Ay_SinT),
            P.x*(Axy_iCosT + Az_SinT)  +  P.y*(Ayy_iCosT +    CosT)  +  P.z*(Ayz_iCosT - Ax_SinT),
            P.x*(Axz_iCosT - Ay_SinT)  +  P.y*(Ayz_iCosT + Ax_SinT)  +  P.z*(Azz_iCosT +    CosT)
        );
    }

    //==========================================================================================================================================================
    internal static vec3 rot(vec3 P, vec3 Pivot, vec3 Axis, float Theta) {
        if (Theta == 0f)
            return P;

        //  'Point' localized to 'Pivot'.
        vec3 d = P - Pivot;

        //  DewIt:
        (float SinT, float CosT) = sincos(-Theta); //  Theta is clockwise.
        float iCosT = 1f-CosT;

        float Ay_iCosT = Axis.y * iCosT;
        float Az_iCosT = Axis.z * iCosT;

        float Axx_iCosT = Axis.x * Axis.x * iCosT;
        float Axy_iCosT = Axis.x * Ay_iCosT;

        float Ayy_iCosT = Axis.y * Ay_iCosT;
        float Ayz_iCosT = Axis.y * Az_iCosT;

        float Axz_iCosT = Axis.x * Az_iCosT;
        float Azz_iCosT = Axis.z * Az_iCosT;

        float Ax_SinT = Axis.x * SinT;
        float Ay_SinT = Axis.y * SinT;
        float Az_SinT = Axis.z * SinT;

        return Pivot + new vec3(
            d.x*(Axx_iCosT +    CosT)  +  d.y*(Axy_iCosT - Az_SinT)  +  d.z*(Axz_iCosT + Ay_SinT),
            d.x*(Axy_iCosT + Az_SinT)  +  d.y*(Ayy_iCosT +    CosT)  +  d.z*(Ayz_iCosT - Ax_SinT),
            d.x*(Axz_iCosT - Ay_SinT)  +  d.y*(Ayz_iCosT + Ax_SinT)  +  d.z*(Azz_iCosT +    CosT)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/3d/taev4ge4ks
    //
    //      ThetaV = (Pitch, Yaw, Roll)
    //
    internal static mat4 rot(vec3 ThetaV) {
        if (ThetaV == new vec3(0f))
            return new();

        ThetaV = -ThetaV; //  Theta is clockwise.

        //  Derive rotation 'Theta' (length of ThetaV):
        float Theta = sqrt(ThetaV.x*ThetaV.x + ThetaV.y*ThetaV.y + ThetaV.z*ThetaV.z);

        //  Derive rotation 'Axis' (ThetaV normalized):
        vec3 Axis = ThetaV * (1f / Theta);

        //  DewIt:
        (float SinT, float CosT) = sincos(Theta);
        float iCosT = 1f-CosT;

        float Ay_iCosT = Axis.y * iCosT;
        float Az_iCosT = Axis.z * iCosT;

        float Axx_iCosT = Axis.x * Axis.x*iCosT;
        float Axy_iCosT = Axis.x * Ay_iCosT;
        float Axz_iCosT = Axis.x * Az_iCosT;

        float Ayy_iCosT = Axis.y * Ay_iCosT;
        float Ayz_iCosT = Axis.y * Az_iCosT;

        float Azz_iCosT = Axis.z * Az_iCosT;

        float Ax_SinT = Axis.x * SinT;
        float Ay_SinT = Axis.y * SinT;
        float Az_SinT = Axis.z * SinT;

        return new mat4(
            (Axx_iCosT +    CosT), (Axy_iCosT - Az_SinT), (Axz_iCosT + Ay_SinT), 0f,
            (Axy_iCosT + Az_SinT), (Ayy_iCosT +    CosT), (Ayz_iCosT - Ax_SinT), 0f,
            (Axz_iCosT - Ay_SinT), (Ayz_iCosT + Ax_SinT), (Azz_iCosT +    CosT), 0f,
                               0f,                    0f,                    0f, 1f
        );
    }

    //==========================================================================================================================================================
    internal static vec3 rot(vec3 P, vec3 ThetaV) {
        if (ThetaV == 0f)
            return P;

        ThetaV = -ThetaV; //  Theta is clockwise.

        //  Derive rotation 'Theta' (length of ThetaV):
        float Theta = sqrt(ThetaV.x*ThetaV.x + ThetaV.y*ThetaV.y + ThetaV.z*ThetaV.z);

        //  Derive rotation 'Axis' (ThetaV normalized):
        vec3 Axis = ThetaV * (1f / Theta);

        //  DewIt:
        (float SinT, float CosT) = sincos(Theta);
        float iCosT = 1f-CosT;

        float Ay_iCosT = Axis.y * iCosT;
        float Az_iCosT = Axis.z * iCosT;

        float Axx_iCosT = Axis.x * Axis.x*iCosT;
        float Axy_iCosT = Axis.x * Ay_iCosT;
        float Axz_iCosT = Axis.x * Az_iCosT;

        float Ayy_iCosT = Axis.y * Ay_iCosT;
        float Ayz_iCosT = Axis.y * Az_iCosT;

        float Azz_iCosT = Axis.z * Az_iCosT;

        float Ax_SinT = Axis.x * SinT;
        float Ay_SinT = Axis.y * SinT;
        float Az_SinT = Axis.z * SinT;

        return new vec3(
            P.x*(Axx_iCosT +    CosT)  +  P.y*(Axy_iCosT - Az_SinT)  +  P.z*(Axz_iCosT + Ay_SinT),
            P.x*(Axy_iCosT + Az_SinT)  +  P.y*(Ayy_iCosT +    CosT)  +  P.z*(Ayz_iCosT - Ax_SinT),
            P.x*(Axz_iCosT - Ay_SinT)  +  P.y*(Ayz_iCosT + Ax_SinT)  +  P.z*(Azz_iCosT +    CosT)
        );
    }

    //==========================================================================================================================================================
    internal static vec3 rot(vec3 P, vec3 Pivot, vec3 ThetaV) {
        if (ThetaV == 0f)
            return P;

        //  'Point' localized to 'Pivot':
        vec3 d = P-Pivot;

        ThetaV = -ThetaV; //  Theta is clockwise.

        //  Derive rotation 'Theta' (length of ThetaV):
        float Theta = sqrt(ThetaV.x*ThetaV.x + ThetaV.y*ThetaV.y + ThetaV.z*ThetaV.z);

        //  Derive rotation 'Axis' (ThetaV normalized):
        vec3 Axis = ThetaV * (1f / Theta);

        //  DewIt:
        (float SinT, float CosT) = sincos(Theta);
        float iCosT = 1f-CosT;

        float Ay_iCosT = Axis.y * iCosT;
        float Az_iCosT = Axis.z * iCosT;

        float Axx_iCosT = Axis.x * Axis.x*iCosT;
        float Axy_iCosT = Axis.x * Ay_iCosT;
        float Axz_iCosT = Axis.x * Az_iCosT;

        float Ayy_iCosT = Axis.y * Ay_iCosT;
        float Ayz_iCosT = Axis.y * Az_iCosT;

        float Azz_iCosT = Axis.z * Az_iCosT;

        float Ax_SinT = Axis.x * SinT;
        float Ay_SinT = Axis.y * SinT;
        float Az_SinT = Axis.z * SinT;

        return Pivot + new vec3(
            d.x*(Axx_iCosT +    CosT)  +  d.y*(Axy_iCosT - Az_SinT)  +  d.z*(Axz_iCosT + Ay_SinT),
            d.x*(Axy_iCosT + Az_SinT)  +  d.y*(Ayy_iCosT +    CosT)  +  d.z*(Ayz_iCosT - Ax_SinT),
            d.x*(Axz_iCosT - Ay_SinT)  +  d.y*(Ayz_iCosT + Ax_SinT)  +  d.z*(Azz_iCosT +    CosT)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
