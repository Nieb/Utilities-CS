
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
    //    CloseEnough:  An epsilon value, relative to the magnitude of "Pos" values.
    //                  A lower-bounds on "DeltaPos" to prevent infinite interpolation.
    //
    //  NOTE:  This may not be capable of working properly with "Time.Delta"......
    //
    internal static float CatchUp(float Pos, float PosTarget,
                                  float CatchUpFactor=0.2f, float CloseEnough=0.001f) {
        float dPos = (PosTarget - Pos /*   "* Time_Delta" here?   */) * CatchUpFactor; //   "* Time_Delta" here?

        return (abs(dPos) <= CloseEnough) ? PosTarget
                                          : Pos + dPos;
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static vec2 CatchUp(vec2 P, vec2 Pt, float F=0.2f, float C=0.001f) => new vec2(CatchUp(P.x,Pt.x, F,C), CatchUp(P.y,Pt.y, F,C));
    internal static vec3 CatchUp(vec3 P, vec3 Pt, float F=0.2f, float C=0.001f) => new vec3(CatchUp(P.x,Pt.x, F,C), CatchUp(P.y,Pt.y, F,C), CatchUp(P.z,Pt.z, F,C));
    internal static vec4 CatchUp(vec4 P, vec4 Pt, float F=0.2f, float C=0.001f) => new vec4(CatchUp(P.x,Pt.x, F,C), CatchUp(P.y,Pt.y, F,C), CatchUp(P.z,Pt.z, F,C), CatchUp(P.w,Pt.w, F,C));

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
    //  Sigmoid centered at (0,0)
    //
    //  https://www.desmos.com/calculator/b6f0ca1hhh
    //
    //      Sigmoidish(  X,  PositionXY,  ScaleXY  )
    //
    internal static float Sigmoidish(float x, float Px, float Py, float Sx, float Sy) => Py-1f + (  Sy / (1f + (exp(-x * Sx)) * (exp(Px * Sx)))  );

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
    [In(line)] internal static float LerpX(vec2 P, vec3 A, vec3 B) {vec2 dAB = B.yz-A.yz;  float W = dot(P-A.yz,dAB)/dot(dAB);  return Lerp(W, A.x, B.x);}
    [In(line)] internal static float LerpY(vec2 P, vec3 A, vec3 B) {vec2 dAB = B.xz-A.xz;  float W = dot(P-A.xz,dAB)/dot(dAB);  return Lerp(W, A.y, B.y);}
    [In(line)] internal static float LerpZ(vec2 P, vec3 A, vec3 B) {vec2 dAB = B.xy-A.xy;  float W = dot(P-A.xy,dAB)/dot(dAB);  return Lerp(W, A.z, B.z);}

    [In(line)] internal static float  MixX(vec2 P, vec3 A, vec3 B) {vec2 dAB = B.yz-A.yz;  float W = dot(P-A.yz,dAB)/dot(dAB);  return  Mix(W, A.x, B.x);}
    [In(line)] internal static float  MixY(vec2 P, vec3 A, vec3 B) {vec2 dAB = B.xz-A.xz;  float W = dot(P-A.xz,dAB)/dot(dAB);  return  Mix(W, A.y, B.y);}
    [In(line)] internal static float  MixZ(vec2 P, vec3 A, vec3 B) {vec2 dAB = B.xy-A.xy;  float W = dot(P-A.xy,dAB)/dot(dAB);  return  Mix(W, A.z, B.z);}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static float LerpX(vec2 P, vec3 A, vec3 B, vec3 C) => BaryLinear(A.x,B.x,C.x,  P,A.yz,B.yz,C.yz);
    [In(line)] internal static float LerpY(vec2 P, vec3 A, vec3 B, vec3 C) => BaryLinear(A.y,B.y,C.y,  P,A.xz,B.xz,C.xz);
    [In(line)] internal static float LerpZ(vec2 P, vec3 A, vec3 B, vec3 C) => BaryLinear(A.z,B.z,C.z,  P,A.xy,B.xy,C.xy);

  //[In(line)] internal static float  MixX(vec2 P, vec3 A, vec3 B, vec3 C) => BaryLinear(A.x,B.x,C.x,  P, A.yz,B.yz,C.yz);
  //[In(line)] internal static float  MixY(vec2 P, vec3 A, vec3 B, vec3 C) => BaryLinear(A.y,B.y,C.y,  P, A.xz,B.xz,C.xz);
  //[In(line)] internal static float  MixZ(vec2 P, vec3 A, vec3 B, vec3 C) => BaryLinear(A.z,B.z,C.z,  P, A.xy,B.xy,C.xy);

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
