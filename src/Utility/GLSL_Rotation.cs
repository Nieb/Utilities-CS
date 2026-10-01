
namespace Utility;
internal static partial class GLSL {
public readonly static string Rotation = $$$"""
#line {{{LINE_ROTATION + LINE_NUMBER(1)}}}
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    vec2  rotl(vec2 P) {return vec2(-P.y,  P.x);}
    vec3 rotXl(vec3 P) {return vec3( P.x,  P.z, -P.y);}
    vec3 rotYl(vec3 P) {return vec3(-P.z,  P.y,  P.x);}
    vec3 rotZl(vec3 P) {return vec3( P.y, -P.x,  P.z);}

    //==========================================================================================================================================================
    vec2  rotr(vec2 P) {return vec2( P.y, -P.x);}
    vec3 rotXr(vec3 P) {return vec3( P.x, -P.z,  P.y);}
    vec3 rotYr(vec3 P) {return vec3( P.z,  P.y, -P.x);}
    vec3 rotZr(vec3 P) {return vec3(-P.y,  P.x,  P.z);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    vec3 pch(vec3 P, float Theta) {
        //if (Theta == 0.0) return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = cos(Theta);
        float SinT = sin(Theta);

        return vec3(
                P.x,
            dot(P.yz, vec2( CosT,-SinT)), //CosT*P.y + -SinT*P.z,
            dot(P.yz, vec2( SinT, CosT))  //SinT*P.y +  CosT*P.z
        );
    }

    //==========================================================================================================================================================
    vec3 yaw(vec3 P, float Theta) {
        //if (Theta == 0.0) return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = cos(Theta);
        float SinT = sin(Theta);

        return vec3(
            dot(P.xz, vec2( CosT, SinT)), // CosT*P.x + SinT*P.z,
                P.y,
            dot(P.xz, vec2(-SinT, CosT))  //-SinT*P.x + CosT*P.z
        );
    }

    //==========================================================================================================================================================
    vec3 rol(vec3 P, float Theta) {
        //if (Theta == 0.0) return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = cos(Theta);
        float SinT = sin(Theta);

        return vec3(
            dot(P.xy, vec2(CosT,-SinT)), //CosT*P.x + -SinT*P.y,
            dot(P.xy, vec2(SinT, CosT)), //SinT*P.x +  CosT*P.y,
                P.z
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    vec3 rot(vec3 P, vec3 Axis, float Theta) {
        if (Theta == 0.0) return P;

        Theta = -Theta; //  Theta is clockwise.
        float  CosT = cos(Theta);
        float iCosT = 1.0-CosT;
        float  SinT = sin(Theta);

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

        return vec3(
            dot(P, vec3((Axx_iCosT +    CosT), (Axy_iCosT - Az_SinT), (Axz_iCosT + Ay_SinT))), //P.x*(Axx_iCosT +    CosT)  +  P.y*(Axy_iCosT - Az_SinT)  +  P.z*(Axz_iCosT + Ay_SinT),
            dot(P, vec3((Axy_iCosT + Az_SinT), (Ayy_iCosT +    CosT), (Ayz_iCosT - Ax_SinT))), //P.x*(Axy_iCosT + Az_SinT)  +  P.y*(Ayy_iCosT +    CosT)  +  P.z*(Ayz_iCosT - Ax_SinT),
            dot(P, vec3((Axz_iCosT - Ay_SinT), (Ayz_iCosT + Ax_SinT), (Azz_iCosT +    CosT)))  //P.x*(Axz_iCosT - Ay_SinT)  +  P.y*(Ayz_iCosT + Ax_SinT)  +  P.z*(Azz_iCosT +    CosT)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    vec2 RotFromVec(vec3 V) {
        V.z = -V.z;
        float Pch = atan(-V.y, sqrt(V.x*V.x + V.z*V.z));
        float Yaw = mix(
            wrap(atan(V.x, V.z), 0.0, PI2),
            0.0,
            step(PIH-0.000001, abs(Pch))
        );
        return vec2(Pch, Yaw);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
""";}
