
namespace Utility;
internal static class VEC_Interpolation2 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] internal static v1 BaryLinear(v1 A,v1 B,v1 C,  v2 P)                    => WeightedSum(A,B,C,  Barycentric(P));
    [In(line)] internal static v2 BaryLinear(v2 A,v2 B,v2 C,  v2 P)                    => WeightedSum(A,B,C,  Barycentric(P));
    [In(line)] internal static v3 BaryLinear(v3 A,v3 B,v3 C,  v2 P)                    => WeightedSum(A,B,C,  Barycentric(P));
    [In(line)] internal static v4 BaryLinear(v4 A,v4 B,v4 C,  v2 P)                    => WeightedSum(A,B,C,  Barycentric(P));

    //==========================================================================================================================================================
    [In(line)] internal static v1 BaryLinear(v1 A,v1 B,v1 C,  v2 P, v2 Ta,v2 Tb,v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));
    [In(line)] internal static v2 BaryLinear(v2 A,v2 B,v2 C,  v2 P, v2 Ta,v2 Tb,v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));
    [In(line)] internal static v3 BaryLinear(v3 A,v3 B,v3 C,  v2 P, v2 Ta,v2 Tb,v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));
    [In(line)] internal static v4 BaryLinear(v4 A,v4 B,v4 C,  v2 P, v2 Ta,v2 Tb,v2 Tc) => WeightedSum(A,B,C,  Barycentric(P, Ta,Tb,Tc));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                Asymptotic Catch Up
    //  CatchUpFactor:  0 to 1
    //    CloseEnough:  Absolute distance from the target at which to snap.
    //                  A lower-bounds on "DeltaPos" to prevent infinite interpolation.
    //
    internal static float CatchUp(float Pos, float PosTarget,
                                  float CatchUpFactor=0.2f, float CloseEnough=0.001f) {
        float dPos = (PosTarget - Pos);

        return (abs(dPos) <= CloseEnough) ? PosTarget
                                          : Pos + dPos*CatchUpFactor;
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static vec2 CatchUp(vec2 P, vec2 Pt, float F=0.2f, float C=0.001f) => new vec2(CatchUp(P.x,Pt.x, F,C), CatchUp(P.y,Pt.y, F,C));
    internal static vec3 CatchUp(vec3 P, vec3 Pt, float F=0.2f, float C=0.001f) => new vec3(CatchUp(P.x,Pt.x, F,C), CatchUp(P.y,Pt.y, F,C), CatchUp(P.z,Pt.z, F,C));
    internal static vec4 CatchUp(vec4 P, vec4 Pt, float F=0.2f, float C=0.001f) => new vec4(CatchUp(P.x,Pt.x, F,C), CatchUp(P.y,Pt.y, F,C), CatchUp(P.z,Pt.z, F,C), CatchUp(P.w,Pt.w, F,C));

    //==========================================================================================================================================================
    //
    //  Version that works with "DeltaTime".
    //
    internal static float KatchUp(float Pos, float PosTarget, float dTime,
                                  float CatchUpRate=12f, float CloseEnough=0.001f) {
        float dPos = PosTarget - Pos;

        return (abs(dPos) <= CloseEnough) ? PosTarget
                                          : Pos + dPos*(1f - exp(-CatchUpRate * dTime));
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static vec2 KatchUp(vec2 P, vec2 Pt, float dT, float R=12f, float C=0.001f) => new vec2(KatchUp(P.x,Pt.x,dT,R,C), KatchUp(P.y,Pt.y,dT,R,C));
    internal static vec3 KatchUp(vec3 P, vec3 Pt, float dT, float R=12f, float C=0.001f) => new vec3(KatchUp(P.x,Pt.x,dT,R,C), KatchUp(P.y,Pt.y,dT,R,C), KatchUp(P.z,Pt.z,dT,R,C));
    internal static vec4 KatchUp(vec4 P, vec4 Pt, float dT, float R=12f, float C=0.001f) => new vec4(KatchUp(P.x,Pt.x,dT,R,C), KatchUp(P.y,Pt.y,dT,R,C), KatchUp(P.z,Pt.z,dT,R,C), KatchUp(P.w,Pt.w,dT,R,C));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  ...
    //
    internal static vec3      Drag(vec3 Vel, float dTime, float Rate) => Vel * (1f - exp(-Rate * dTime));
    internal static vec3 ApplyDrag(vec3 Vel, float dTime, float Rate) => Vel * exp(-Rate * dTime);

    internal static vec3      Drag_(vec3 Vel, float dTime, float K) {float Amount = K * length(Vel) * dTime;  return Vel * (Amount / (1f + Amount));}
    internal static vec3 ApplyDrag_(vec3 Vel, float dTime, float K) => Vel / (1f + K * length(Vel) * dTime);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      Gaussian
    //  https://www.desmos.com/calculator/mqajs8tfgd
    //  https://www.desmos.com/3d/p8hvpd8xwz
    //
    //  Asymptotic  AKA: "Falloff infinitely approaches zero."
    //      Result < 0.1           at radius: 1.51742712939~
    //      Result < 0.01          at radius: 2.14596602629~
    //      Result < 0.001         at radius: 2.62826088488~
    //      Result < 0.000_1       at radius: 3.03485425877~
    //      Result < 0.000_01      at radius: 3.39307021221~
    //      Result < 0.000_001     at radius: 3.71692218885~
    //      Result < 0.000_000_1   at radius: 4.01473481702~
    //      Result < 0.000_000_01  at radius: 4.29193205258~
    //      Result < 0.000_000_001 at radius: 4.55228138816~
    //
    [In(line)] internal static v1  Gaussian(v1 x)       => exp(-(x*x));
    [In(line)] internal static v1 iGaussian(v1 y)       => sqrt(-log(y));

    [In(line)] internal static v1  Gaussian(v1 x, v1 y) => exp(-(x*x) - (y*y));
    [In(line)] internal static v1  Gaussian(v2 V)       => Gaussian(V.x, V.y);

    //==========================================================================================================================================================
    //                                                                      Lanczos
    //  https://www.desmos.com/calculator/ku1ahcyzyw
    //  https://www.desmos.com/3d/gohoq8tutz
    //
    //  "Lanczos(x * PI)"  gives a period of 1, instead of PI.
    //
    //  NOTE:  Formula undefined at Zero.
    //            Lanczos(0.0) == NaN
    //
    [In(line)] internal static float Lanczos(float x) => (2f * sin(x) * sin(x/2f)) / (x*x);

    //==========================================================================================================================================================
    //                                                                      Sigmoid
    [In(line)] internal static float Sigmoid(float x) => 1f / (1f + exp(-x));

    //==========================================================================================================================================================
    //
    //  https://www.desmos.com/calculator/7c7d5564b0
    //
    //  Sigmoid centered at (Px,Py)
    //
    //      Sigmoidish(  X,  PositionXY,  ScaleXY  )
    //
    internal static float Sigmoidish(float x, float Px, float Py, float Sx, float Sy) => Py - Sy*0.5f + (  Sy / (1f + exp(-x/Sx) * exp(Px/Sx))  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/sqgwxotdgy
    //
    [In(line)] internal static float        InverseLinear(float X, float D=1f) =>        (D / (X + D));
    [In(line)] internal static float InverseInverseLinear(float X, float D=1f) =>        (X / (X + D));

    //==========================================================================================================================================================
    [In(line)] internal static float        InverseSquare(float X, float D=1f) =>      sq(D / (X + D));
    [In(line)] internal static float InverseInverseSquare(float X, float D=1f) => 1f - sq(D / (X + D));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static float LerpX(vec2 P, vec3 A, vec3 B) => Lerp(LineCoord(P,A.xy,B.xy), A.x,B.x); //{vec2 dAB = B.yz-A.yz;  float W = dot(P-A.yz,dAB)/dot(dAB);  return Lerp(W, A.x, B.x);}
    internal static float LerpY(vec2 P, vec3 A, vec3 B) => Lerp(LineCoord(P,A.xy,B.xy), A.y,B.y); //{vec2 dAB = B.xz-A.xz;  float W = dot(P-A.xz,dAB)/dot(dAB);  return Lerp(W, A.y, B.y);}
    internal static float LerpZ(vec2 P, vec3 A, vec3 B) => Lerp(LineCoord(P,A.xy,B.xy), A.z,B.z); //{vec2 dAB = B.xy-A.xy;  float W = dot(P-A.xy,dAB)/dot(dAB);  return Lerp(W, A.z, B.z);}

    internal static float  MixX(vec2 P, vec3 A, vec3 B) =>  Mix(LineCoord(P,A.xy,B.xy), A.x,B.x); //{vec2 dAB = B.yz-A.yz;  float W = dot(P-A.yz,dAB)/dot(dAB);  return  Mix(W, A.x, B.x);}
    internal static float  MixY(vec2 P, vec3 A, vec3 B) =>  Mix(LineCoord(P,A.xy,B.xy), A.y,B.y); //{vec2 dAB = B.xz-A.xz;  float W = dot(P-A.xz,dAB)/dot(dAB);  return  Mix(W, A.y, B.y);}
    internal static float  MixZ(vec2 P, vec3 A, vec3 B) =>  Mix(LineCoord(P,A.xy,B.xy), A.z,B.z); //{vec2 dAB = B.xy-A.xy;  float W = dot(P-A.xy,dAB)/dot(dAB);  return  Mix(W, A.z, B.z);}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static float LerpX(vec2 P, vec3 A, vec3 B, vec3 C) => BaryLinear(A.x,B.x,C.x,  P,A.yz,B.yz,C.yz);
    internal static float LerpY(vec2 P, vec3 A, vec3 B, vec3 C) => BaryLinear(A.y,B.y,C.y,  P,A.xz,B.xz,C.xz);
    internal static float LerpZ(vec2 P, vec3 A, vec3 B, vec3 C) => BaryLinear(A.z,B.z,C.z,  P,A.xy,B.xy,C.xy);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                          "Spherical Linear Interpolation"
    //  https://www.desmos.com/calculator/0faaf03695
    //
    //  Slerp(
    //      w: 0..1     Weighted position between A and B.
    //      A: any      Position on Schircle/Sphere (normalized).
    //      B: any      Position on Schircle/Sphere (normalized).
    //  );
    //
    //  OUTPUT: A..B
    //
    internal static v2 Slerp(v1 w, v2 A, v2 B) {v1 tAB = acos(dot(A,B));  v1 SinT = sin(tAB);  return A*(sin(tAB*(1f-w))/SinT)  +  B*(sin(tAB*w)/SinT);}
    internal static v3 Slerp(v1 w, v3 A, v3 B) {v1 tAB = acos(dot(A,B));  v1 SinT = sin(tAB);  return A*(sin(tAB*(1f-w))/SinT)  +  B*(sin(tAB*w)/SinT);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
