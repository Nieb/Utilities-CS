using MathF   = System.MathF;
using Math    = System.Math;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;
using Vector4 = System.Numerics.Vector4;

namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Absolute" Value
    [In(line)] internal static v1 abs(v1 A) => (A >= 0f) ? A : -A;
    [In(line)] internal static v2 abs(v2 A) => new v2(abs(A.x), abs(A.y));
    [In(line)] internal static v3 abs(v3 A) => new v3(abs(A.x), abs(A.y), abs(A.z));
    [In(line)] internal static v4 abs(v4 A) => new v4(abs(A.x), abs(A.y), abs(A.z), abs(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Average"
    [In(line)] internal static v1 avg(v1 A, v1 B) => (A+B) * 0.5f;
    [In(line)] internal static v2 avg(v2 A, v2 B) => (A+B) * 0.5f;
    [In(line)] internal static v3 avg(v3 A, v3 B) => (A+B) * 0.5f;
    [In(line)] internal static v4 avg(v4 A, v4 B) => (A+B) * 0.5f;

    [In(line)] internal static v1 avg(v1 A, v1 B, v1 C) => (A+B+C) * ONE_THIRD;
    [In(line)] internal static v2 avg(v2 A, v2 B, v2 C) => (A+B+C) * ONE_THIRD;
    [In(line)] internal static v3 avg(v3 A, v3 B, v3 C) => (A+B+C) * ONE_THIRD;
    [In(line)] internal static v4 avg(v4 A, v4 B, v4 C) => (A+B+C) * ONE_THIRD;

    [In(line)] internal static v1 avg(v1 A, v1 B, v1 C, v1 D) => (A+B+C+D) * 0.25f;
    [In(line)] internal static v2 avg(v2 A, v2 B, v2 C, v2 D) => (A+B+C+D) * 0.25f;
    [In(line)] internal static v3 avg(v3 A, v3 B, v3 C, v3 D) => (A+B+C+D) * 0.25f;
    [In(line)] internal static v4 avg(v4 A, v4 B, v4 C, v4 D) => (A+B+C+D) * 0.25f;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Clamp"
    //                *Inclusive*  *Inclusive*
    //      clamp( A, LowerBounds, UpperBounds )
    //
#if false
    [In(line)] internal static v1 clamp(v1 A, v1 L=0f, v1 U=1f) => (A < L) ? L : (A > U) ? U : A;
    [In(line)] internal static v2 clamp(v2 A, v1 L=0f, v1 U=1f) => new v2(clamp(A.x,L  ,U  ), clamp(A.y,L  ,U  ));
    [In(line)] internal static v2 clamp(v2 A, v2 L=0f, v2 U=1f) => new v2(clamp(A.x,L.x,U.x), clamp(A.y,L.y,U.y));
    [In(line)] internal static v3 clamp(v3 A, v1 L=0f, v1 U=1f) => new v3(clamp(A.x,L  ,U  ), clamp(A.y,L  ,U  ), clamp(A.z,L  ,U  ));
    [In(line)] internal static v3 clamp(v3 A, v3 L=0f, v3 U=1f) => new v3(clamp(A.x,L.x,U.x), clamp(A.y,L.y,U.y), clamp(A.z,L.z,U.z));
    [In(line)] internal static v4 clamp(v4 A, v1 L=0f, v1 U=1f) => new v4(clamp(A.x,L  ,U  ), clamp(A.y,L  ,U  ), clamp(A.z,L  ,U  ), clamp(A.w,L  ,U  ));
    [In(line)] internal static v4 clamp(v4 A, v4 L=0f, v4 U=1f) => new v4(clamp(A.x,L.x,U.x), clamp(A.y,L.y,U.y), clamp(A.z,L.z,U.z), clamp(A.w,L.w,U.w));
#else
    [In(line)] internal static v1 clamp(v1 A, v1 L=0f, v1 U=1f) =>    Math.Clamp(A,L,U);

    [In(line)] internal static v2 clamp(v2 A                  ) => Vector2.Clamp(A,new Vector2(0f),new Vector2(1f));
    [In(line)] internal static v2 clamp(v2 A, v1 L   , v1 U   ) => Vector2.Clamp(A,new Vector2( L),new Vector2( U));
    [In(line)] internal static v2 clamp(v2 A, v2 L   , v2 U   ) => Vector2.Clamp(A,             L ,             U );

    [In(line)] internal static v3 clamp(v3 A                  ) => Vector3.Clamp(A,new Vector3(0f),new Vector3(1f));
    [In(line)] internal static v3 clamp(v3 A, v1 L   , v1 U   ) => Vector3.Clamp(A,new Vector3( L),new Vector3( U));
    [In(line)] internal static v3 clamp(v3 A, v3 L   , v3 U   ) => Vector3.Clamp(A,             L ,             U );

    [In(line)] internal static v4 clamp(v4 A                  ) => Vector4.Clamp(A,new Vector4(0f),new Vector4(1f));
    [In(line)] internal static v4 clamp(v4 A, v1 L   , v1 U   ) => Vector4.Clamp(A,new Vector4( L),new Vector4( U));
    [In(line)] internal static v4 clamp(v4 A, v4 L   , v4 U   ) => Vector4.Clamp(A,             L ,             U );
#endif

    //==========================================================================================================================================================
    //                                                                       "Wrap"
    //               *Inclusive*  *Exclusive*
    //      wrap( A, LowerBounds, UpperBounds )
    //
    [In(line)] internal static v1 wrap(v1 A, v1 L, v1 U) {v1 Domain = U-L;  v1 R = (A-L)%Domain;  return R+L + ((R < 0f) ? Domain : 0f);} //=> L + (A-L) % (U-L);    if only "%" wasn't dumb...
    [In(line)] internal static v2 wrap(v2 A, v1 L, v1 U) => new v2(wrap(A.x, L, U), wrap(A.y, L, U));
    [In(line)] internal static v3 wrap(v3 A, v1 L, v1 U) => new v3(wrap(A.x, L, U), wrap(A.y, L, U), wrap(A.z, L, U));
    [In(line)] internal static v4 wrap(v4 A, v1 L, v1 U) => new v4(wrap(A.x, L, U), wrap(A.y, L, U), wrap(A.z, L, U), wrap(A.w, L, U));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Cross" Product
    [In(line)] internal static v1 cross(v2 A, v2 B) => (A.x*B.y - A.y*B.x);

#if true
    [In(line)] internal static v3 cross(v3 A, v3 B) => new v3((A.y*B.z - A.z*B.y),  (A.z*B.x - A.x*B.z),  (A.x*B.y - A.y*B.x));
#else
    [In(line)] internal static v3 cross(v3 A, v3 B) => System.Numerics.Vector3.Cross(A,B);
#endif

    //==========================================================================================================================================================
    //                                                                   "Dot" Product
    //  dot(A) == dot(A,A) == "Squared-Length of A."
    //
#if true
    [In(line)] internal static v1 dot(v2 A)       => (A.x*A.x + A.y*A.y);
    [In(line)] internal static v1 dot(v2 A, v2 B) => (A.x*B.x + A.y*B.y);

    [In(line)] internal static v1 dot(v3 A)       => (A.x*A.x + A.y*A.y + A.z*A.z);
    [In(line)] internal static v1 dot(v3 A, v3 B) => (A.x*B.x + A.y*B.y + A.z*B.z);

    [In(line)] internal static v1 dot(v4 A)       => (A.x*A.x + A.y*A.y + A.z*A.z + A.w*A.w);
    [In(line)] internal static v1 dot(v4 A, v4 B) => (A.x*B.x + A.y*B.y + A.z*B.z + A.w*B.w);
#else
    [In(line)] internal static v1 dot(v2 A)       => Vector2.Dot(A,A);
    [In(line)] internal static v1 dot(v2 A, v2 B) => Vector2.Dot(A,B);

    [In(line)] internal static v1 dot(v3 A)       => Vector3.Dot(A,A);
    [In(line)] internal static v1 dot(v3 A, v3 B) => Vector3.Dot(A,B);

    [In(line)] internal static v1 dot(v4 A)       => Vector4.Dot(A,A);
    [In(line)] internal static v1 dot(v4 A, v4 B) => Vector4.Dot(A,B);
#endif

    //==========================================================================================================================================================
    //                                                                      "Square"
    [In(line)] internal static v1 sq(v1 A) => (A*A);
    [In(line)] internal static v2 sq(v2 A) => (A*A);
    [In(line)] internal static v3 sq(v3 A) => (A*A);
    [In(line)] internal static v4 sq(v4 A) => (A*A);

    //==========================================================================================================================================================
    //                                                                   "Square Root"
    [In(line)] internal static v1 sqrt(v1 A) => MathF.Sqrt(A);
  //[In(line)] internal static v2 sqrt(v2 A) => new v2(sqrt(A.x), sqrt(A.y));
  //[In(line)] internal static v3 sqrt(v3 A) => new v3(sqrt(A.x), sqrt(A.y), sqrt(A.z));
  //[In(line)] internal static v4 sqrt(v4 A) => new v4(sqrt(A.x), sqrt(A.y), sqrt(A.z), sqrt(A.w));

    //==========================================================================================================================================================
    //                                                                    "Cube Root"
    [In(line)] internal static v1 cbrt(v1 A) => MathF.Cbrt(A);
  //[In(line)] internal static v2 cbrt(v2 A) => new v2(cbrt(A.x), cbrt(A.y));
  //[In(line)] internal static v3 cbrt(v3 A) => new v3(cbrt(A.x), cbrt(A.y), cbrt(A.z));
  //[In(line)] internal static v4 cbrt(v4 A) => new v4(cbrt(A.x), cbrt(A.y), cbrt(A.z), cbrt(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Distance"
    [In(line)] internal static v1 distance(v2 A, v2 B) => length(B-A);
    [In(line)] internal static v1 distance(v3 A, v3 B) => length(B-A);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //                                                                      "Length"
    [In(line)] internal static v1 length(v2 A) => sqrt(A.x*A.x + A.y*A.y);
    [In(line)] internal static v1 length(v3 A) => sqrt(A.x*A.x + A.y*A.y + A.z*A.z);
    [In(line)] internal static v1 length(v4 A) => sqrt(A.x*A.x + A.y*A.y + A.z*A.z + A.w*A.w);

    [In(line)] internal static v1 length(v1 X, v1 Y)             => sqrt(X*X + Y*Y);
    [In(line)] internal static v1 length(v1 X, v1 Y, v1 Z)       => sqrt(X*X + Y*Y + Z*Z);
    [In(line)] internal static v1 length(v1 X, v1 Y, v1 Z, v1 W) => sqrt(X*X + Y*Y + Z*Z + W*W);

    //==========================================================================================================================================================
    //                                                                     "Lengthen"
    //  Scale vector to "NewLength"
    //  Vector * (NewLength / OldLength)
    //
    [In(line)] internal static v2 length(v2 A, v1 NewLength) => (A == 0f) ? A : A*(NewLength / sqrt(A.x*A.x + A.y*A.y));
    [In(line)] internal static v3 length(v3 A, v1 NewLength) => (A == 0f) ? A : A*(NewLength / sqrt(A.x*A.x + A.y*A.y + A.z*A.z));
    [In(line)] internal static v4 length(v4 A, v1 NewLength) => (A == 0f) ? A : A*(NewLength / sqrt(A.x*A.x + A.y*A.y + A.z*A.z));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //                                                                    "Normalize"
    //  https://github.com/KhronosGroup/WebGL/issues/3697
    //      ...the GLSL normalize() operation is being called on 0-length vectors.
    //      This behavior isn't defined in GLSL, but it happens to return a zero-length vector on basically all other GPU hardware.
    //
    [In(line)] internal static v2 normalize(v2 A) => (A == 0f) ? A : A/sqrt(A.x*A.x + A.y*A.y);
    [In(line)] internal static v3 normalize(v3 A) => (A == 0f) ? A : A/sqrt(A.x*A.x + A.y*A.y + A.z*A.z);
    [In(line)] internal static v4 normalize(v4 A) => (A == 0f) ? A : A/sqrt(A.x*A.x + A.y*A.y + A.z*A.z + A.w*A.w);

    [In(line)] internal static v2 normalize(v1 X, v1 Y)             => normalize(new v2(X,Y));
    [In(line)] internal static v3 normalize(v1 X, v1 Y, v1 Z)       => normalize(new v3(X,Y,Z));
    [In(line)] internal static v4 normalize(v1 X, v1 Y, v1 Z, v1 W) => normalize(new v4(X,Y,Z,W));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                "Fused Multiply Add"
    //  A * B + C
    //
    //  NOTE:  Often not worth the bother.
    //         As it just gets in the way of compiler optimizations.
    //
    [In(line)] internal static v1 fma(v1 A, v1 B, v1 C) => MathF.FusedMultiplyAdd(A, B, C);
    [In(line)] internal static v2 fma(v2 A, v2 B, v2 C) => new v2(fma(A.x, B.x, C.x), fma(A.y, B.y, C.y));
    [In(line)] internal static v3 fma(v3 A, v3 B, v3 C) => new v3(fma(A.x, B.x, C.x), fma(A.y, B.y, C.y), fma(A.z, B.z, C.z));
    [In(line)] internal static v4 fma(v4 A, v4 B, v4 C) => new v4(fma(A.x, B.x, C.x), fma(A.y, B.y, C.y), fma(A.z, B.z, C.z), fma(A.w, B.w, C.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                 "Fractional" Part
    [In(line)] internal static v1 fract(v1 A) => (A - MathF.Floor(A));
    [In(line)] internal static v2 fract(v2 A) => new v2(fract(A.x), fract(A.y));
    [In(line)] internal static v3 fract(v3 A) => new v3(fract(A.x), fract(A.y), fract(A.z));
    [In(line)] internal static v4 fract(v4 A) => new v4(fract(A.x), fract(A.y), fract(A.z), fract(A.w));

    //==========================================================================================================================================================
    //                                                              "Truncate" or Integer Part
    [In(line)] internal static v1 trunc(v1 A) => MathF.Truncate(A);
    [In(line)] internal static v2 trunc(v2 A) => new v2(trunc(A.x), trunc(A.y));
    [In(line)] internal static v3 trunc(v3 A) => new v3(trunc(A.x), trunc(A.y), trunc(A.z));
    [In(line)] internal static v4 trunc(v4 A) => new v4(trunc(A.x), trunc(A.y), trunc(A.z), trunc(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Invert"                Additive Inverse    AKA: Negation
  //[In(line)] internal static v1 inv(v1 A) => -A;
  //[In(line)] internal static v2 inv(v2 A) => -A;
  //[In(line)] internal static v3 inv(v3 A) => -A;
  //[In(line)] internal static v4 inv(v4 A) => -A;

    //==========================================================================================================================================================
    //                                                                    "Complement"              Complimentary Inverse
  //[In(line)] internal static v1 cmp(v1 A) => 1f-A;
  //[In(line)] internal static v2 cmp(v2 A) => 1f-A;
  //[In(line)] internal static v3 cmp(v3 A) => 1f-A;
  //[In(line)] internal static v4 cmp(v4 A) => 1f-A;

    //==========================================================================================================================================================
    //                                                                    "Reciprocal"              Multiplicative Inverse
  //[In(line)] internal static v1 rcp(v1 A) => 1f/A;
  //[In(line)] internal static v2 rcp(v2 A) => 1f/A;
  //[In(line)] internal static v3 rcp(v3 A) => 1f/A;
  //[In(line)] internal static v4 rcp(v4 A) => 1f/A;

  //[In(line)] internal static v1 rcpz(v1 A) => (abs(A) < EPS6) ? 0f : 1f/A;
  //[In(line)] internal static v2 rcpz(v2 A) => new v2(rcp0(A.x), rcp0(A.y));
  //[In(line)] internal static v3 rcpz(v3 A) => new v3(rcp0(A.x), rcp0(A.y), rcp0(A.z));
  //[In(line)] internal static v4 rcpz(v4 A) => new v4(rcp0(A.x), rcp0(A.y), rcp0(A.z), rcp0(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Minimum" Value
    [In(line)] internal static v1 min(v1 A, v1 B)             => (A < B) ? A : B;

    [In(line)] internal static v1 min(v1 A, v1 B, v1 C)       => (A < B) ? ((A < C) ? A : C)
                                                                         : ((B < C) ? B : C);

    [In(line)] internal static v1 min(v1 A, v1 B, v1 C, v1 D) => (A < B) ? ((A < C) ? ((A < D) ? A : D)
                                                                                    : ((C < D) ? C : D))
                                                                         : ((B < C) ? ((B < D) ? B : D)
                                                                                    : ((C < D) ? C : D));

    [In(line)] internal static v2 min(v1 A, v2 B) => new v2(min(A  ,B.x), min(A  ,B.y));
    [In(line)] internal static v2 min(v2 A, v1 B) => new v2(min(A.x,B  ), min(A.y,B  ));
    [In(line)] internal static v3 min(v1 A, v3 B) => new v3(min(A  ,B.x), min(A  ,B.y), min(A  ,B.z));
    [In(line)] internal static v3 min(v3 A, v1 B) => new v3(min(A.x,B  ), min(A.y,B  ), min(A.z,B  ));
    [In(line)] internal static v4 min(v1 A, v4 B) => new v4(min(A  ,B.x), min(A  ,B.y), min(A  ,B.z), min(A  ,B.w));
    [In(line)] internal static v4 min(v4 A, v1 B) => new v4(min(A.x,B  ), min(A.y,B  ), min(A.z,B  ), min(A.w,B  ));

    [In(line)] internal static v2 min(v2 A, v2 B)             => new v2(min(A.x,B.x),         min(A.y,B.y));
    [In(line)] internal static v2 min(v2 A, v2 B, v2 C)       => new v2(min(A.x,B.x,C.x),     min(A.y,B.y,C.y));
    [In(line)] internal static v2 min(v2 A, v2 B, v2 C, v2 D) => new v2(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y));
    [In(line)] internal static v3 min(v3 A, v3 B)             => new v3(min(A.x,B.x),         min(A.y,B.y),         min(A.z,B.z));
    [In(line)] internal static v3 min(v3 A, v3 B, v3 C)       => new v3(min(A.x,B.x,C.x),     min(A.y,B.y,C.y),     min(A.z,B.z,C.z));
    [In(line)] internal static v3 min(v3 A, v3 B, v3 C, v3 D) => new v3(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z));
    [In(line)] internal static v4 min(v4 A, v4 B)             => new v4(min(A.x,B.x),         min(A.y,B.y),         min(A.z,B.z),         min(A.w,B.w));
    [In(line)] internal static v4 min(v4 A, v4 B, v4 C)       => new v4(min(A.x,B.x,C.x),     min(A.y,B.y,C.y),     min(A.z,B.z,C.z),     min(A.w,B.w,C.w));
    [In(line)] internal static v4 min(v4 A, v4 B, v4 C, v4 D) => new v4(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z), min(A.w,B.w,C.w,D.w));

    //==========================================================================================================================================================
    //                                                                  "Maximum" Value
    [In(line)] internal static v1 max(v1 A, v1 B)             => (A > B) ? A : B;

    [In(line)] internal static v1 max(v1 A, v1 B, v1 C)       => (A > B) ? ((A > C) ? A : C)
                                                                         : ((B > C) ? B : C);

    [In(line)] internal static v1 max(v1 A, v1 B, v1 C, v1 D) => (A > B) ? ((A > C) ? ((A > D) ? A : D)
                                                                                    : ((C > D) ? C : D))
                                                                         : ((B > C) ? ((B > D) ? B : D)
                                                                                    : ((C > D) ? C : D));

    [In(line)] internal static v2 max(v1 A, v2 B) => new v2(max(A  ,B.x), max(A  ,B.y));
    [In(line)] internal static v2 max(v2 A, v1 B) => new v2(max(A.x,B  ), max(A.y,B  ));
    [In(line)] internal static v3 max(v1 A, v3 B) => new v3(max(A  ,B.x), max(A  ,B.y), max(A  ,B.z));
    [In(line)] internal static v3 max(v3 A, v1 B) => new v3(max(A.x,B  ), max(A.y,B  ), max(A.z,B  ));
    [In(line)] internal static v4 max(v1 A, v4 B) => new v4(max(A  ,B.x), max(A  ,B.y), max(A  ,B.z), max(A  ,B.w));
    [In(line)] internal static v4 max(v4 A, v1 B) => new v4(max(A.x,B  ), max(A.y,B  ), max(A.z,B  ), max(A.w,B  ));

    [In(line)] internal static v2 max(v2 A, v2 B)             => new v2(max(A.x,B.x),         max(A.y,B.y));
    [In(line)] internal static v2 max(v2 A, v2 B, v2 C)       => new v2(max(A.x,B.x,C.x),     max(A.y,B.y,C.y));
    [In(line)] internal static v2 max(v2 A, v2 B, v2 C, v2 D) => new v2(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y));
    [In(line)] internal static v3 max(v3 A, v3 B)             => new v3(max(A.x,B.x),         max(A.y,B.y),         max(A.z,B.z));
    [In(line)] internal static v3 max(v3 A, v3 B, v3 C)       => new v3(max(A.x,B.x,C.x),     max(A.y,B.y,C.y),     max(A.z,B.z,C.z));
    [In(line)] internal static v3 max(v3 A, v3 B, v3 C, v3 D) => new v3(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z));
    [In(line)] internal static v4 max(v4 A, v4 B)             => new v4(max(A.x,B.x),         max(A.y,B.y),         max(A.z,B.z),         max(A.w,B.w));
    [In(line)] internal static v4 max(v4 A, v4 B, v4 C)       => new v4(max(A.x,B.x,C.x),     max(A.y,B.y,C.y),     max(A.z,B.z,C.z),     max(A.w,B.w,C.w));
    [In(line)] internal static v4 max(v4 A, v4 B, v4 C, v4 D) => new v4(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z), max(A.w,B.w,C.w,D.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                      "Minimum" Value of a Vector's Components
    [In(line)] internal static float minof(v2 A) => min(A.x,A.y);
    [In(line)] internal static float minof(v3 A) => min(A.x,A.y,A.z);
    [In(line)] internal static float minof(v4 A) => min(A.x,A.y,A.z,A.w);

    //==========================================================================================================================================================
    //                                                      "Maximum" Value of a Vector's Components
    [In(line)] internal static float maxof(v2 A) => max(A.x,A.y);
    [In(line)] internal static float maxof(v3 A) => max(A.x,A.y,A.z);
    [In(line)] internal static float maxof(v4 A) => max(A.x,A.y,A.z,A.w);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                 Euclidean "Modulo"
    //                                  2 _                                                         2 _
    //                                           /     /     /     /                                                     /     /
    //                                          /     /     /     /                                                     /     /
    //                                  1 _    /     /     /     /                                  1 _                /     /
    //              Euclidean Modulo          /     /     /     /               Remainder Modulo                      /     /
    //                                       /     /     /     /                                                     /     /
    //                 mod(x, 2f) ==    0 _ /     /     /     /     /                  x % 2f ==    0 _             /     /     /
    //                                                                                                       /     /
    //                                                                                                      /     /
    //                                 -1 _                                                        -1 _    /     /
    //                                                                                                    /     /
    //                                                                                                   /     /
    //                                 -2 _                                                        -2 _ /     /
    //                                     -4 -3 -2 -1  0  1  2  3  4                                  -4 -3 -2 -1  0  1  2  3  4
    //
    [In(line)] internal static v1 mod(v1 A, v1 B) {v1 R = A % B;  return R + (R < 0f ? abs(B) : 0f);}

    [In(line)] internal static v2 mod(v2 A, v1 B) => new v2(mod(A.x,B  ), mod(A.y,B  ));
    [In(line)] internal static v2 mod(v2 A, v2 B) => new v2(mod(A.x,B.x), mod(A.y,B.y));

    [In(line)] internal static v3 mod(v3 A, v1 B) => new v3(mod(A.x,B  ), mod(A.y,B  ), mod(A.z,B  ));
    [In(line)] internal static v3 mod(v3 A, v3 B) => new v3(mod(A.x,B.x), mod(A.y,B.y), mod(A.z,B.z));

    [In(line)] internal static v4 mod(v4 A, v1 B) => new v4(mod(A.x,B  ), mod(A.y,B  ), mod(A.z,B  ), mod(A.w,B  ));
    [In(line)] internal static v4 mod(v4 A, v4 B) => new v4(mod(A.x,B.x), mod(A.y,B.y), mod(A.z,B.z), mod(A.w,B.w));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //[In(line)] internal static v1 mod(v1 A, v1 B) => A - (B * floor(A/B));                            //  Not numerically stable.
    //[In(line)] internal static v1 mod(v1 A, v1 B) {v1 R = A % B; return (R < 0f) ? (R + B) : R;}      //  B !< 0

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Power"
    [In(line)] internal static v1 pow(v1 A, v1 P) => MathF.Pow(A,P);

    [In(line)] internal static v2 pow(v2 A, v1 P) => new v2(pow(A.x,P  ), pow(A.y,P  ));
    [In(line)] internal static v2 pow(v2 A, v2 P) => new v2(pow(A.x,P.x), pow(A.y,P.y));

    [In(line)] internal static v3 pow(v3 A, v1 P) => new v3(pow(A.x,P  ), pow(A.y,P  ), pow(A.z,P  ));
    [In(line)] internal static v3 pow(v3 A, v3 P) => new v3(pow(A.x,P.x), pow(A.y,P.y), pow(A.z,P.z));

    //==========================================================================================================================================================
    //                                                                   "Exponential"
    //      exp(X)  ==  pow(e, X)  ==  pow(2.718~, X)
    //
    [In(line)] internal static v1 exp(v1 A) => MathF.Exp(A);
    [In(line)] internal static v2 exp(v2 A) => new v2(exp(A.x), exp(A.y));
    [In(line)] internal static v3 exp(v3 A) => new v3(exp(A.x), exp(A.y), exp(A.z));
    [In(line)] internal static v4 exp(v4 A) => new v4(exp(A.x), exp(A.y), exp(A.z), exp(A.w));

    //==========================================================================================================================================================
    //                                                                    "Logarithm"
    //  Inverse of Exp() & Pow().
    //
    //        log(X) = Y   <-->   exp(    Y) = X
    //        log(X) = Y   <-->   pow( e, Y) = X
    //
    //       log2(X) = Y   <-->   pow( 2, Y) = X
    //
    //      log10(X) = Y   <-->   pow(10, Y) = X
    //
    //      log(X,b) = Y   <-->   pow( b, Y) = X
    //
    [In(line)] internal static float log  (float A) => MathF.Log(A);
    [In(line)] internal static float log2 (float A) => MathF.Log2(A);
    [In(line)] internal static float log10(float A) => MathF.Log10(A);

    [In(line)] internal static float log(float A, float InBase) => MathF.Log(A, InBase);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Reflect"
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/reflect.xhtml
    //
    //      reflect( Direction-Normal, Surface-Normal )
    //
    [In(line)] internal static v2 reflect(v2 Vn, v2 Sn) => Vn - Sn*(2f * dot(Vn, Sn));
    [In(line)] internal static v3 reflect(v3 Vn, v3 Sn) => Vn - Sn*(2f * dot(Vn, Sn));

    //==========================================================================================================================================================
    //                                                                     "Refract"
    //  https://www.desmos.com/calculator/eb0c0f77c7
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/refract.xhtml
    //
    //  IndexOfRefraction:  The ratio of the speed-of-light from one medium to another medium.
    //
    //                             Range:   0 <---> 1
    //                      Unsafe-Range:  -2 <---> 2   Becomes unstable as result approaches SurfaceNormal-Tangent.
    //
    //                          |               |       < 1.0  refracts inwards
    //                          |   /       \   |       > 1.0  refracts outwards
    //                          +--●----+----●--+
    //                              .   |   .
    //                               .     .
    //                                .   .
    //                                 \ /
    //                                  ●
    //
    //      refract( Direction-Normal, Surface-Normal, Index-of-Refraction )
    //
    internal static vec2 refract(vec2 Vn, vec2 Sn, float Ratio) {
        float Dot = dot(Vn, Sn);

        float K = 1f - Ratio*Ratio*(1f - Dot*Dot);

        return (K < 0f) ? default : Vn*Ratio  -  Sn*(Ratio*Dot + sqrt(K));
    }

    internal static vec3 refract(vec3 Vn, vec3 Sn, float Ratio) {
        float Dot = dot(Vn, Sn);

        float K = 1f - Ratio*Ratio*(1f - Dot*Dot);

        return (K < 0f) ? default : Vn*Ratio  -  Sn*(Ratio*Dot + sqrt(K));
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Round"
    [In(line)] internal static v1 round(v1 A) => MathF.Round(A);
    [In(line)] internal static v2 round(v2 A) => new v2(round(A.x), round(A.y));
    [In(line)] internal static v3 round(v3 A) => new v3(round(A.x), round(A.y), round(A.z));
    [In(line)] internal static v4 round(v4 A) => new v4(round(A.x), round(A.y), round(A.z), round(A.w));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //                                                                      "Floor"
    [In(line)] internal static v1 floor(v1 A) => MathF.Floor(A);
    [In(line)] internal static v2 floor(v2 A) => new v2(floor(A.x), floor(A.y));
    [In(line)] internal static v3 floor(v3 A) => new v3(floor(A.x), floor(A.y), floor(A.z));
    [In(line)] internal static v4 floor(v4 A) => new v4(floor(A.x), floor(A.y), floor(A.z), floor(A.w));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //                                                                      "Ceiling"
    [In(line)] internal static v1 ceil(v1 A) => MathF.Ceiling(A);
    [In(line)] internal static v2 ceil(v2 A) => new v2(ceil(A.x), ceil(A.y));
    [In(line)] internal static v3 ceil(v3 A) => new v3(ceil(A.x), ceil(A.y), ceil(A.z));
    [In(line)] internal static v4 ceil(v4 A) => new v4(ceil(A.x), ceil(A.y), ceil(A.z), ceil(A.w));

    //==========================================================================================================================================================
    //                                                                     "Round" To
    //  Each component rounded to the nearest 'RoundTo'.
    //
    [In(line)] internal static v1 round(v1 A, v1 RoundTo) => /*(RoundTo==0f || RoundTo==1f) ? round(A) :*/ RoundTo * round(A/RoundTo);
    [In(line)] internal static v2 round(v2 A, v1 RoundTo) => /*(RoundTo==0f || RoundTo==1f) ? round(A) :*/ RoundTo * round(A/RoundTo);
    [In(line)] internal static v3 round(v3 A, v1 RoundTo) => /*(RoundTo==0f || RoundTo==1f) ? round(A) :*/ RoundTo * round(A/RoundTo);
    [In(line)] internal static v4 round(v4 A, v1 RoundTo) => /*(RoundTo==0f || RoundTo==1f) ? round(A) :*/ RoundTo * round(A/RoundTo);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                       "Sign"
    [In(line)] internal static v1 sign(v1 A) => MathF.Sign(A);
    [In(line)] internal static v2 sign(v2 A) => new v2(sign(A.x), sign(A.y));
    [In(line)] internal static v3 sign(v3 A) => new v3(sign(A.x), sign(A.y), sign(A.z));
    [In(line)] internal static v4 sign(v4 A) => new v4(sign(A.x), sign(A.y), sign(A.z), sign(A.w));

    //==========================================================================================================================================================
    //                                                                     Copy "Sign"
    //
    //      sign( AbsoluteValueOfThis, WithTheSignOfThis )
    //
    [In(line)] internal static v1 sign(v1 A, v1 S) => MathF.CopySign(A,S);

    [In(line)] internal static v2 sign(v2 A, v1 S) => new v2(sign(A.x,S  ), sign(A.y,S  ));
    [In(line)] internal static v2 sign(v2 A, v2 S) => new v2(sign(A.x,S.x), sign(A.y,S.y));

    [In(line)] internal static v3 sign(v3 A, v1 S) => new v3(sign(A.x,S  ), sign(A.y,S  ), sign(A.z,S  ));
    [In(line)] internal static v3 sign(v3 A, v3 S) => new v3(sign(A.x,S.x), sign(A.y,S.y), sign(A.z,S.z));

    [In(line)] internal static v4 sign(v4 A, v1 S) => new v4(sign(A.x,S  ), sign(A.y,S  ), sign(A.z,S  ), sign(A.w,S  ));
    [In(line)] internal static v4 sign(v4 A, v4 S) => new v4(sign(A.x,S.x), sign(A.y,S.y), sign(A.z,S.z), sign(A.w,S.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                           "Sum of" a Vector's Components
    [In(line)] internal static v1 sumof(v2 A) => (A.x + A.y);
    [In(line)] internal static v1 sumof(v3 A) => (A.x + A.y + A.z);
    [In(line)] internal static v1 sumof(v4 A) => (A.x + A.y + A.z + A.w);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                   Trigonometric
    //==========================================================================================================================================================
    [In(line)] internal static v1  cos(v1 A) => MathF.Cos(A);
    [In(line)] internal static v2  cos(v2 A) => new v2(cos(A.x), cos(A.y));
    [In(line)] internal static v3  cos(v3 A) => new v3(cos(A.x), cos(A.y), cos(A.z));
    [In(line)] internal static v4  cos(v4 A) => new v4(cos(A.x), cos(A.y), cos(A.z), cos(A.w));

    [In(line)] internal static v1 acos(v1 A) => MathF.Acos(A);
    [In(line)] internal static v2 acos(v2 A) => new v2(acos(A.x), acos(A.y));
    [In(line)] internal static v3 acos(v3 A) => new v3(acos(A.x), acos(A.y), acos(A.z));
    [In(line)] internal static v4 acos(v4 A) => new v4(acos(A.x), acos(A.y), acos(A.z), acos(A.w));

    //==========================================================================================================================================================
    [In(line)] internal static v1  sin(v1 A) => MathF.Sin(A);
    [In(line)] internal static v2  sin(v2 A) => new v2(sin(A.x), sin(A.y));
    [In(line)] internal static v3  sin(v3 A) => new v3(sin(A.x), sin(A.y), sin(A.z));
    [In(line)] internal static v4  sin(v4 A) => new v4(sin(A.x), sin(A.y), sin(A.z), sin(A.w));

    [In(line)] internal static v1 asin(v1 A) => MathF.Asin(A);
    [In(line)] internal static v2 asin(v2 A) => new v2(asin(A.x), asin(A.y));
    [In(line)] internal static v3 asin(v3 A) => new v3(asin(A.x), asin(A.y), asin(A.z));
    [In(line)] internal static v4 asin(v4 A) => new v4(asin(A.x), asin(A.y), asin(A.z), asin(A.w));

    //==========================================================================================================================================================
    [In(line)] internal static (v1 Sin, v1 Cos) sincos(v1 A) => MathF.SinCos(A);

    //==========================================================================================================================================================
    [In(line)] internal static v1  tan(v1 A) => MathF.Tan(A);
    [In(line)] internal static v2  tan(v2 A) => new v2(tan(A.x), tan(A.y));
    [In(line)] internal static v3  tan(v3 A) => new v3(tan(A.x), tan(A.y), tan(A.z));
    [In(line)] internal static v4  tan(v4 A) => new v4(tan(A.x), tan(A.y), tan(A.z), tan(A.w));

    [In(line)] internal static v1 atan(v1 A) => MathF.Atan(A);
    [In(line)] internal static v2 atan(v2 A) => new v2(atan(A.x), atan(A.y));
    [In(line)] internal static v3 atan(v3 A) => new v3(atan(A.x), atan(A.y), atan(A.z));
    [In(line)] internal static v4 atan(v4 A) => new v4(atan(A.x), atan(A.y), atan(A.z), atan(A.w));

    //==========================================================================================================================================================
    [In(line)] internal static v1 atan2(v1 Y, v1 X) => MathF.Atan2(Y, X);

    [In(line)] internal static v1 atan2(v2 A) => MathF.Atan2(A.y, A.x);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     Hyperbolic
    [In(line)] internal static v1  cosh(v1 A) => MathF.Cosh(A);

    [In(line)] internal static v1 acosh(v1 A) => MathF.Acosh(A);

    //==========================================================================================================================================================
    [In(line)] internal static v1  sinh(v1 A) => MathF.Sinh(A);

    [In(line)] internal static v1 asinh(v1 A) => MathF.Asinh(A);

    //==========================================================================================================================================================
    [In(line)] internal static v1  tanh(v1 A) => MathF.Tanh(A);

    [In(line)] internal static v1 atanh(v1 A) => MathF.Atanh(A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  For a more precise conversion.
    //
    //  For a quick conversion:  Var * TO_DEG
    //                           Var * TO_RAD
    //
    [In(line)] internal static v1 ToDeg(v1 Radians) => (f32)((f64)Radians * (180d / 3.14159265358979323846264338327950288419716939937511d));
    [In(line)] internal static v2 ToDeg(v2 Rad) => new v2(ToDeg(Rad.x), ToDeg(Rad.y));
    [In(line)] internal static v3 ToDeg(v3 Rad) => new v3(ToDeg(Rad.x), ToDeg(Rad.y), ToDeg(Rad.z));
    [In(line)] internal static v4 ToDeg(v4 Rad) => new v4(ToDeg(Rad.x), ToDeg(Rad.y), ToDeg(Rad.z), ToDeg(Rad.w));

  //[In(line)] internal static v1 degrees(v1 Rad) => ToDeg(Rad);
  //[In(line)] internal static v2 degrees(v2 Rad) => ToDeg(Rad);
  //[In(line)] internal static v3 degrees(v3 Rad) => ToDeg(Rad);
  //[In(line)] internal static v4 degrees(v4 Rad) => ToDeg(Rad);

    //==========================================================================================================================================================
    [In(line)] internal static v1 ToRad(v1 Degrees) => (f32)((f64)Degrees * (3.14159265358979323846264338327950288419716939937511d / 180d));
    [In(line)] internal static v2 ToRad(v2 Deg) => new v2(ToRad(Deg.x), ToRad(Deg.y));
    [In(line)] internal static v3 ToRad(v3 Deg) => new v3(ToRad(Deg.x), ToRad(Deg.y), ToRad(Deg.z));
    [In(line)] internal static v4 ToRad(v4 Deg) => new v4(ToRad(Deg.x), ToRad(Deg.y), ToRad(Deg.z), ToRad(Deg.w));

  //[In(line)] internal static v1 radians(v1 Deg) => ToRad(Deg);
  //[In(line)] internal static v2 radians(v2 Deg) => ToRad(Deg);
  //[In(line)] internal static v3 radians(v3 Deg) => ToRad(Deg);
  //[In(line)] internal static v4 radians(v4 Deg) => ToRad(Deg);

    //==========================================================================================================================================================
    //
    //  Tau(0.125) ==  "45 degrees"  in radians
    //  Tau(0.25)  ==  "90 degrees"
    //  Tau(0.5)   == "180 degrees"
    //  Tau(0.75)  == "270 degrees"
    //  Tau(1.0)   == "360 degrees"
    //
    [In(line)] internal static f32 Tau(f64 u) => (f32)(u * 6.28318530717958647692528676655900576839433879875021);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
