
namespace Utility;
internal static partial class VEC_Generate {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  The starting orientations are selected for being practical, not "correct".
    //
    //  Theta in Radians.  +Theta is Clockwise, from the perspective of +Axis looking towards Zero.
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                       Direction(X, Y)  FROM  Angle(in radians)
    [In(line)] internal static vec2 FromAng(float Theta) => sincos(Theta);

    //==========================================================================================================================================================
    //                                                    Direction(X, Y, Z)  FROM  Angle(in radians)
    [In(line)] internal static vec3 FromPch(float Theta) {
        (float SinT, float CosT) = sincos(Theta);
        #if Z_UP
            return new vec3(   0f,-SinT, CosT);
        #else
            return new vec3(   0f,-SinT,-CosT);
        #endif
    }

    [In(line)] internal static vec3 FromYaw(float Theta) {
        (float SinT, float CosT) = sincos(Theta);
        #if Z_UP
            return new vec3( SinT, CosT,   0f);
        #else
            return new vec3( SinT,   0f,-CosT);
        #endif
    }

    [In(line)] internal static vec3 FromRol(float Theta) {
        (float SinT, float CosT) = sincos(Theta);
        #if Z_UP
            return new vec3(-SinT, CosT,   0f);
        #else
            return new vec3( SinT, CosT,   0f);
        #endif
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                    Direction(X, Y, Z)  FROM  Rotation(Pitch, Yaw)
    [In(line)] internal static vec3 FromPchYaw(float Pch, float Yaw) {
        (float SinPch, float CosPch) = sincos(Pch);
        (float SinYaw, float CosYaw) = sincos(Yaw);
        #if Z_UP
            return new vec3(CosPch*SinYaw,  CosPch*CosYaw, -SinPch       );
        #else
            return new vec3(CosPch*SinYaw, -SinPch       , -CosPch*CosYaw);
        #endif
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                             Rotation(Pitch, Yaw, 0)    FROM    Direction(X, Y, Z)
    [In(line)] internal static vec3 RotFromDir(vec3 V) {
        float Pch, Yaw;

        //#if Z_UP
        //
        //#else
            V.z = -V.z;
            Pch = atan2(-V.y, sqrt(V.x*V.x + V.z*V.z));

            if (abs(Pch) >= (PIH-EPS6)) {
                Pch = sign(PIH, Pch);
                Yaw = 0f;
            } else {
                Yaw = wrap(atan2(V.x, V.z), -PI, PI);
            }
        //#endif

        return new vec3(Pch, Yaw, 0f);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
