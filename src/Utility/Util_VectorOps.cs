
namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Absolute" Value
    [Impl(AggressiveInlining)] internal static v1 abs(v1 A) => (A >= 0f) ? A : -A;
    [Impl(AggressiveInlining)] internal static v2 abs(v2 A) => new v2(abs(A.x), abs(A.y));
    [Impl(AggressiveInlining)] internal static v3 abs(v3 A) => new v3(abs(A.x), abs(A.y), abs(A.z));
    [Impl(AggressiveInlining)] internal static v4 abs(v4 A) => new v4(abs(A.x), abs(A.y), abs(A.z), abs(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Average"
    [Impl(AggressiveInlining)] internal static v1 avg(v1 A, v1 B) => (A+B) * 0.5f;
    [Impl(AggressiveInlining)] internal static v2 avg(v2 A, v2 B) => (A+B) * 0.5f;
    [Impl(AggressiveInlining)] internal static v3 avg(v3 A, v3 B) => (A+B) * 0.5f;
    [Impl(AggressiveInlining)] internal static v4 avg(v4 A, v4 B) => (A+B) * 0.5f;

    [Impl(AggressiveInlining)] internal static v1 avg(v1 A, v1 B, v1 C) => (A+B+C) * ONE_THIRD;
    [Impl(AggressiveInlining)] internal static v2 avg(v2 A, v2 B, v2 C) => (A+B+C) * ONE_THIRD;
    [Impl(AggressiveInlining)] internal static v3 avg(v3 A, v3 B, v3 C) => (A+B+C) * ONE_THIRD;
    [Impl(AggressiveInlining)] internal static v4 avg(v4 A, v4 B, v4 C) => (A+B+C) * ONE_THIRD;

    [Impl(AggressiveInlining)] internal static v1 avg(v1 A, v1 B, v1 C, v1 D) => (A+B+C+D) * 0.25f;
    [Impl(AggressiveInlining)] internal static v2 avg(v2 A, v2 B, v2 C, v2 D) => (A+B+C+D) * 0.25f;
    [Impl(AggressiveInlining)] internal static v3 avg(v3 A, v3 B, v3 C, v3 D) => (A+B+C+D) * 0.25f;
    [Impl(AggressiveInlining)] internal static v4 avg(v4 A, v4 B, v4 C, v4 D) => (A+B+C+D) * 0.25f;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Clamp"
    //                *Inclusive*  *Inclusive*
    //      clamp( A, LowerBounds, UpperBounds )
    //
    [Impl(AggressiveInlining)] internal static v1 clamp(v1 A, v1 L = 0f, v1 U = 1f) => (A <= L) ? L : (A >= U) ? U : A;
    [Impl(AggressiveInlining)] internal static v2 clamp(v2 A, v1 L = 0f, v1 U = 1f) => new v2(clamp(A.x, L, U), clamp(A.y, L, U));
    [Impl(AggressiveInlining)] internal static v3 clamp(v3 A, v1 L = 0f, v1 U = 1f) => new v3(clamp(A.x, L, U), clamp(A.y, L, U), clamp(A.z, L, U));
    [Impl(AggressiveInlining)] internal static v4 clamp(v4 A, v1 L = 0f, v1 U = 1f) => new v4(clamp(A.x, L, U), clamp(A.y, L, U), clamp(A.z, L, U), clamp(A.w, L, U));

    //==========================================================================================================================================================
    //                                                                       "Wrap"
    //               *Inclusive*  *Exclusive*
    //      wrap( A, LowerBounds, UpperBounds )
    //
    [Impl(AggressiveInlining)] internal static v1 wrap(v1 A, v1 L, v1 U) {v1 Domain = U-L;  A = (A-L) % Domain;  return A+L + ((A < 0f) ? Domain : 0f);}        // => L + (A-L) % (U-L);
    [Impl(AggressiveInlining)] internal static v2 wrap(v2 A, v1 L, v1 U) => new v2(wrap(A.x, L, U), wrap(A.y, L, U));
    [Impl(AggressiveInlining)] internal static v3 wrap(v3 A, v1 L, v1 U) => new v3(wrap(A.x, L, U), wrap(A.y, L, U), wrap(A.z, L, U));
    [Impl(AggressiveInlining)] internal static v4 wrap(v4 A, v1 L, v1 U) => new v4(wrap(A.x, L, U), wrap(A.y, L, U), wrap(A.z, L, U), wrap(A.w, L, U));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Cross" Product
    [Impl(AggressiveInlining)] internal static v1 cross(v2 A, v2 B) => (A.x*B.y - A.y*B.x);

    [Impl(AggressiveInlining)] internal static v3 cross(v3 A, v3 B) => new v3((A.y*B.z - A.z*B.y),  (A.z*B.x - A.x*B.z),  (A.x*B.y - A.y*B.x));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static v1 crozz(v3 A, v3 B) => length(cross(A,B));

    //==========================================================================================================================================================
    //                                                                   "Dot" Product
    //  dot(A) == dot(A,A) == "Squared-Length of A."
    //
    [Impl(AggressiveInlining)] internal static v1 dot(v2 A)       => (A.x*A.x + A.y*A.y);
    [Impl(AggressiveInlining)] internal static v1 dot(v2 A, v2 B) => (A.x*B.x + A.y*B.y);

    [Impl(AggressiveInlining)] internal static v1 dot(v3 A)       => (A.x*A.x + A.y*A.y + A.z*A.z);
    [Impl(AggressiveInlining)] internal static v1 dot(v3 A, v3 B) => (A.x*B.x + A.y*B.y + A.z*B.z);

    [Impl(AggressiveInlining)] internal static v1 dot(v4 A)       => (A.x*A.x + A.y*A.y + A.z*A.z + A.w*A.w);
    [Impl(AggressiveInlining)] internal static v1 dot(v4 A, v4 B) => (A.x*B.x + A.y*B.y + A.z*B.z + A.w*B.w);

    //==========================================================================================================================================================
    //                                                                      "Square"
    [Impl(AggressiveInlining)] internal static v1 sq(v1 A) => (A*A);
    [Impl(AggressiveInlining)] internal static v2 sq(v2 A) => (A*A);
    [Impl(AggressiveInlining)] internal static v3 sq(v3 A) => (A*A);
    [Impl(AggressiveInlining)] internal static v4 sq(v4 A) => (A*A);

    //==========================================================================================================================================================
    //                                                                   "Square Root"
    [Impl(AggressiveInlining)] internal static v1 sqrt(v1 A) => System.MathF.Sqrt(A);
  //[Impl(AggressiveInlining)] internal static v2 sqrt(v2 A) => new v2(sqrt(A.x), sqrt(A.y));
  //[Impl(AggressiveInlining)] internal static v3 sqrt(v3 A) => new v3(sqrt(A.x), sqrt(A.y), sqrt(A.z));
  //[Impl(AggressiveInlining)] internal static v4 sqrt(v4 A) => new v4(sqrt(A.x), sqrt(A.y), sqrt(A.z), sqrt(A.w));

    //==========================================================================================================================================================
    //                                                                    "Cube Root"
    [Impl(AggressiveInlining)] internal static v1 cbrt(v1 A) => System.MathF.Cbrt(A);
  //[Impl(AggressiveInlining)] internal static v2 cbrt(v2 A) => new v2(cbrt(A.x), cbrt(A.y));
  //[Impl(AggressiveInlining)] internal static v3 cbrt(v3 A) => new v3(cbrt(A.x), cbrt(A.y), cbrt(A.z));
  //[Impl(AggressiveInlining)] internal static v4 cbrt(v4 A) => new v4(cbrt(A.x), cbrt(A.y), cbrt(A.z), cbrt(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Distance"
    [Impl(AggressiveInlining)] internal static v1 distance(v2 A, v2 B) => length(B-A);
    [Impl(AggressiveInlining)] internal static v1 distance(v3 A, v3 B) => length(B-A);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //                                                                      "Length"
    [Impl(AggressiveInlining)] internal static v1 length(v2 A) => sqrt(A.x*A.x + A.y*A.y);
    [Impl(AggressiveInlining)] internal static v1 length(v3 A) => sqrt(A.x*A.x + A.y*A.y + A.z*A.z);

    [Impl(AggressiveInlining)] internal static v1 length(v1 X, v1 Y)       => sqrt(X*X + Y*Y);
    [Impl(AggressiveInlining)] internal static v1 length(v1 X, v1 Y, v1 Z) => sqrt(X*X + Y*Y + Z*Z);

    //==========================================================================================================================================================
    //                                                                     "Lengthen"
    //  Scale vector to "NewLength"
    //  Vector * (NewLength / OldLength)
    //
    [Impl(AggressiveInlining)] internal static v2 length(v2 A, v1 NewLength) => (A == 0f) ? A : A * (NewLength / sqrt(A.x*A.x + A.y*A.y));
    [Impl(AggressiveInlining)] internal static v3 length(v3 A, v1 NewLength) => (A == 0f) ? A : A * (NewLength / sqrt(A.x*A.x + A.y*A.y + A.z*A.z));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //                                                                    "Normalize"
    //  https://github.com/KhronosGroup/WebGL/issues/3697
    //      ...the GLSL normalize() operation is being called on 0-length vectors.
    //      This behavior isn't defined in GLSL, but it happens to return a zero-length vector on basically all other GPU hardware.
    //
    [Impl(AggressiveInlining)] internal static v2 normalize(v2 A) => (A == 0f) ? A : A/sqrt(A.x*A.x + A.y*A.y);
    [Impl(AggressiveInlining)] internal static v3 normalize(v3 A) => (A == 0f) ? A : A/sqrt(A.x*A.x + A.y*A.y + A.z*A.z);

    [Impl(AggressiveInlining)] internal static v2 normalize(v1 X, v1 Y)       => normalize(new v2(X,Y));
    [Impl(AggressiveInlining)] internal static v3 normalize(v1 X, v1 Y, v1 Z) => normalize(new v3(X,Y,Z));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                "Fused Multiply Add"
    //  A * B + C
    //
    [Impl(AggressiveInlining)] internal static v1 fma(v1 A, v1 B, v1 C) => System.MathF.FusedMultiplyAdd(A, B, C);
    [Impl(AggressiveInlining)] internal static v2 fma(v2 A, v2 B, v2 C) => new v2(fma(A.x, B.x, C.x), fma(A.y, B.y, C.y));
    [Impl(AggressiveInlining)] internal static v3 fma(v3 A, v3 B, v3 C) => new v3(fma(A.x, B.x, C.x), fma(A.y, B.y, C.y), fma(A.z, B.z, C.z));
    [Impl(AggressiveInlining)] internal static v4 fma(v4 A, v4 B, v4 C) => new v4(fma(A.x, B.x, C.x), fma(A.y, B.y, C.y), fma(A.z, B.z, C.z), fma(A.w, B.w, C.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                 "Fractional" Part
    [Impl(AggressiveInlining)] internal static v1 fract(v1 A) => (A - System.MathF.Floor(A));
    [Impl(AggressiveInlining)] internal static v2 fract(v2 A) => new v2(fract(A.x), fract(A.y));
    [Impl(AggressiveInlining)] internal static v3 fract(v3 A) => new v3(fract(A.x), fract(A.y), fract(A.z));
    [Impl(AggressiveInlining)] internal static v4 fract(v4 A) => new v4(fract(A.x), fract(A.y), fract(A.z), fract(A.w));

    //==========================================================================================================================================================
    //                                                              "Truncate" or Integer Part
    [Impl(AggressiveInlining)] internal static v1 trunc(v1 A) => System.MathF.Truncate(A);
    [Impl(AggressiveInlining)] internal static v2 trunc(v2 A) => new v2(trunc(A.x), trunc(A.y));
    [Impl(AggressiveInlining)] internal static v3 trunc(v3 A) => new v3(trunc(A.x), trunc(A.y), trunc(A.z));
    [Impl(AggressiveInlining)] internal static v4 trunc(v4 A) => new v4(trunc(A.x), trunc(A.y), trunc(A.z), trunc(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Invert"                Additive Inverse    AKA: Negation
  //[Impl(AggressiveInlining)] internal static v1 inv(v1 A) => -A;
  //[Impl(AggressiveInlining)] internal static v2 inv(v2 A) => -A;
  //[Impl(AggressiveInlining)] internal static v3 inv(v3 A) => -A;
  //[Impl(AggressiveInlining)] internal static v4 inv(v4 A) => -A;

    //==========================================================================================================================================================
    //                                                                    "Complement"              Complimentary Inverse
  //[Impl(AggressiveInlining)] internal static v1 cmp(v1 A) => 1f-A;
  //[Impl(AggressiveInlining)] internal static v2 cmp(v2 A) => 1f-A;
  //[Impl(AggressiveInlining)] internal static v3 cmp(v3 A) => 1f-A;
  //[Impl(AggressiveInlining)] internal static v4 cmp(v4 A) => 1f-A;

    //==========================================================================================================================================================
    //                                                                    "Reciprocal"              Multiplicative Inverse
  //[Impl(AggressiveInlining)] internal static v1 rcp(v1 A) => 1f/A;
  //[Impl(AggressiveInlining)] internal static v2 rcp(v2 A) => 1f/A;
  //[Impl(AggressiveInlining)] internal static v3 rcp(v3 A) => 1f/A;
  //[Impl(AggressiveInlining)] internal static v4 rcp(v4 A) => 1f/A;

  //[Impl(AggressiveInlining)] internal static v1 rcpz(v1 A) => (abs(A) < EPS6) ? 0f : 1f/A;
  //[Impl(AggressiveInlining)] internal static v2 rcpz(v2 A) => new v2(rcp0(A.x), rcp0(A.y));
  //[Impl(AggressiveInlining)] internal static v3 rcpz(v3 A) => new v3(rcp0(A.x), rcp0(A.y), rcp0(A.z));
  //[Impl(AggressiveInlining)] internal static v4 rcpz(v4 A) => new v4(rcp0(A.x), rcp0(A.y), rcp0(A.z), rcp0(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Minimum" Value
    [Impl(AggressiveInlining)] internal static v1 min(v1 A, v1 B)             => (A < B) ? A : B;

    [Impl(AggressiveInlining)] internal static v1 min(v1 A, v1 B, v1 C)       => (A < B) ? ((A < C) ? A : C)
                                                                                         : ((B < C) ? B : C);

    [Impl(AggressiveInlining)] internal static v1 min(v1 A, v1 B, v1 C, v1 D) => (A < B) ? ((A < C) ? ((A < D) ? A : D)
                                                                                                    : ((C < D) ? C : D))
                                                                                         : ((B < C) ? ((B < D) ? B : D)
                                                                                                    : ((C < D) ? C : D));

    [Impl(AggressiveInlining)] internal static v2 min(v1 A, v2 B) => new v2(min(A  ,B.x), min(A  ,B.y));
    [Impl(AggressiveInlining)] internal static v2 min(v2 A, v1 B) => new v2(min(A.x,B  ), min(A.y,B  ));
    [Impl(AggressiveInlining)] internal static v3 min(v1 A, v3 B) => new v3(min(A  ,B.x), min(A  ,B.y), min(A  ,B.z));
    [Impl(AggressiveInlining)] internal static v3 min(v3 A, v1 B) => new v3(min(A.x,B  ), min(A.y,B  ), min(A.z,B  ));
    [Impl(AggressiveInlining)] internal static v4 min(v1 A, v4 B) => new v4(min(A  ,B.x), min(A  ,B.y), min(A  ,B.z), min(A  ,B.w));
    [Impl(AggressiveInlining)] internal static v4 min(v4 A, v1 B) => new v4(min(A.x,B  ), min(A.y,B  ), min(A.z,B  ), min(A.w,B  ));

    [Impl(AggressiveInlining)] internal static v2 min(v2 A, v2 B)             => new v2(min(A.x,B.x),         min(A.y,B.y));
    [Impl(AggressiveInlining)] internal static v2 min(v2 A, v2 B, v2 C)       => new v2(min(A.x,B.x,C.x),     min(A.y,B.y,C.y));
    [Impl(AggressiveInlining)] internal static v2 min(v2 A, v2 B, v2 C, v2 D) => new v2(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y));
    [Impl(AggressiveInlining)] internal static v3 min(v3 A, v3 B)             => new v3(min(A.x,B.x),         min(A.y,B.y),         min(A.z,B.z));
    [Impl(AggressiveInlining)] internal static v3 min(v3 A, v3 B, v3 C)       => new v3(min(A.x,B.x,C.x),     min(A.y,B.y,C.y),     min(A.z,B.z,C.z));
    [Impl(AggressiveInlining)] internal static v3 min(v3 A, v3 B, v3 C, v3 D) => new v3(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z));
    [Impl(AggressiveInlining)] internal static v4 min(v4 A, v4 B)             => new v4(min(A.x,B.x),         min(A.y,B.y),         min(A.z,B.z),         min(A.w,B.w));
    [Impl(AggressiveInlining)] internal static v4 min(v4 A, v4 B, v4 C)       => new v4(min(A.x,B.x,C.x),     min(A.y,B.y,C.y),     min(A.z,B.z,C.z),     min(A.w,B.w,C.w));
    [Impl(AggressiveInlining)] internal static v4 min(v4 A, v4 B, v4 C, v4 D) => new v4(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z), min(A.w,B.w,C.w,D.w));

    //==========================================================================================================================================================
    //                                                                  "Maximum" Value
    [Impl(AggressiveInlining)] internal static v1 max(v1 A, v1 B)             => (A > B) ? A : B;

    [Impl(AggressiveInlining)] internal static v1 max(v1 A, v1 B, v1 C)       => (A > B) ? ((A > C) ? A : C)
                                                                                         : ((B > C) ? B : C);

    [Impl(AggressiveInlining)] internal static v1 max(v1 A, v1 B, v1 C, v1 D) => (A > B) ? ((A > C) ? ((A > D) ? A : D)
                                                                                                    : ((C > D) ? C : D))
                                                                                         : ((B > C) ? ((B > D) ? B : D)
                                                                                                    : ((C > D) ? C : D));

    [Impl(AggressiveInlining)] internal static v2 max(v1 A, v2 B) => new v2(max(A  ,B.x), max(A  ,B.y));
    [Impl(AggressiveInlining)] internal static v2 max(v2 A, v1 B) => new v2(max(A.x,B  ), max(A.y,B  ));
    [Impl(AggressiveInlining)] internal static v3 max(v1 A, v3 B) => new v3(max(A  ,B.x), max(A  ,B.y), max(A  ,B.z));
    [Impl(AggressiveInlining)] internal static v3 max(v3 A, v1 B) => new v3(max(A.x,B  ), max(A.y,B  ), max(A.z,B  ));
    [Impl(AggressiveInlining)] internal static v4 max(v1 A, v4 B) => new v4(max(A  ,B.x), max(A  ,B.y), max(A  ,B.z), max(A  ,B.w));
    [Impl(AggressiveInlining)] internal static v4 max(v4 A, v1 B) => new v4(max(A.x,B  ), max(A.y,B  ), max(A.z,B  ), max(A.w,B  ));

    [Impl(AggressiveInlining)] internal static v2 max(v2 A, v2 B)             => new v2(max(A.x,B.x),         max(A.y,B.y));
    [Impl(AggressiveInlining)] internal static v2 max(v2 A, v2 B, v2 C)       => new v2(max(A.x,B.x,C.x),     max(A.y,B.y,C.y));
    [Impl(AggressiveInlining)] internal static v2 max(v2 A, v2 B, v2 C, v2 D) => new v2(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y));
    [Impl(AggressiveInlining)] internal static v3 max(v3 A, v3 B)             => new v3(max(A.x,B.x),         max(A.y,B.y),         max(A.z,B.z));
    [Impl(AggressiveInlining)] internal static v3 max(v3 A, v3 B, v3 C)       => new v3(max(A.x,B.x,C.x),     max(A.y,B.y,C.y),     max(A.z,B.z,C.z));
    [Impl(AggressiveInlining)] internal static v3 max(v3 A, v3 B, v3 C, v3 D) => new v3(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z));
    [Impl(AggressiveInlining)] internal static v4 max(v4 A, v4 B)             => new v4(max(A.x,B.x),         max(A.y,B.y),         max(A.z,B.z),         max(A.w,B.w));
    [Impl(AggressiveInlining)] internal static v4 max(v4 A, v4 B, v4 C)       => new v4(max(A.x,B.x,C.x),     max(A.y,B.y,C.y),     max(A.z,B.z,C.z),     max(A.w,B.w,C.w));
    [Impl(AggressiveInlining)] internal static v4 max(v4 A, v4 B, v4 C, v4 D) => new v4(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z), max(A.w,B.w,C.w,D.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                      "Minimum" Value of a Vector's Components
    [Impl(AggressiveInlining)] internal static float minof(v2 A) => min(A.x,A.y);
    [Impl(AggressiveInlining)] internal static float minof(v3 A) => min(A.x,A.y,A.z);
    [Impl(AggressiveInlining)] internal static float minof(v4 A) => min(A.x,A.y,A.z,A.w);

    //==========================================================================================================================================================
    //                                                      "Maximum" Value of a Vector's Components
    [Impl(AggressiveInlining)] internal static float maxof(v2 A) => max(A.x,A.y);
    [Impl(AggressiveInlining)] internal static float maxof(v3 A) => max(A.x,A.y,A.z);
    [Impl(AggressiveInlining)] internal static float maxof(v4 A) => max(A.x,A.y,A.z,A.w);

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
    [Impl(AggressiveInlining)] internal static v1 mod(v1 A, v1 B) {v1 R = A % B;  return R + (R < 0f ? abs(B) : 0f);}

    [Impl(AggressiveInlining)] internal static v2 mod(v2 A, v1 B) => new v2(mod(A.x,B  ), mod(A.y,B  ));
    [Impl(AggressiveInlining)] internal static v2 mod(v2 A, v2 B) => new v2(mod(A.x,B.x), mod(A.y,B.y));

    [Impl(AggressiveInlining)] internal static v3 mod(v3 A, v1 B) => new v3(mod(A.x,B  ), mod(A.y,B  ), mod(A.z,B  ));
    [Impl(AggressiveInlining)] internal static v3 mod(v3 A, v3 B) => new v3(mod(A.x,B.x), mod(A.y,B.y), mod(A.z,B.z));

    [Impl(AggressiveInlining)] internal static v4 mod(v4 A, v1 B) => new v4(mod(A.x,B  ), mod(A.y,B  ), mod(A.z,B  ), mod(A.w,B  ));
    [Impl(AggressiveInlining)] internal static v4 mod(v4 A, v4 B) => new v4(mod(A.x,B.x), mod(A.y,B.y), mod(A.z,B.z), mod(A.w,B.w));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //[Impl(AggressiveInlining)] internal static v1 mod(v1 A, v1 B) => A - (B * floor(A/B));                            //  Not numerically stable.
    //[Impl(AggressiveInlining)] internal static v1 mod(v1 A, v1 B) {v1 R = A % B; return (R < 0f) ? (R + B) : R;}      //  B !< 0

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Power"
    [Impl(AggressiveInlining)] internal static v1 pow(v1 A, v1 P) => System.MathF.Pow(A, P);

    [Impl(AggressiveInlining)] internal static v2 pow(v2 A, v1 P) => new v2(pow(A.x, P  ), pow(A.y, P  ));
    [Impl(AggressiveInlining)] internal static v2 pow(v2 A, v2 P) => new v2(pow(A.x, P.x), pow(A.y, P.y));

    [Impl(AggressiveInlining)] internal static v3 pow(v3 A, v1 P) => new v3(pow(A.x, P  ), pow(A.y, P  ), pow(A.z, P  ));
    [Impl(AggressiveInlining)] internal static v3 pow(v3 A, v3 P) => new v3(pow(A.x, P.x), pow(A.y, P.y), pow(A.z, P.z));

    //==========================================================================================================================================================
    //                                                                   "Exponential"
    //      exp(X)  ==  pow(e, X)  ==  pow(2.718~, X)
    //
    [Impl(AggressiveInlining)] internal static v1 exp(v1 A) => System.MathF.Exp(A);
    [Impl(AggressiveInlining)] internal static v2 exp(v2 A) => new v2(exp(A.x), exp(A.y));
    [Impl(AggressiveInlining)] internal static v3 exp(v3 A) => new v3(exp(A.x), exp(A.y), exp(A.z));
    [Impl(AggressiveInlining)] internal static v4 exp(v4 A) => new v4(exp(A.x), exp(A.y), exp(A.z), exp(A.w));

    //==========================================================================================================================================================
    //                                                                    "Logarithm"
    //  Inverse of Exp() and Pow().
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
    [Impl(AggressiveInlining)] internal static float log  (float A) => System.MathF.Log(A);
    [Impl(AggressiveInlining)] internal static float log2 (float A) => System.MathF.Log2(A);
    [Impl(AggressiveInlining)] internal static float log10(float A) => System.MathF.Log10(A);

    [Impl(AggressiveInlining)] internal static float log(float A, float InBase) => System.MathF.Log(A, InBase);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Reflect"
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/reflect.xhtml
    //
    //      reflect( Direction-Normal, Surface-Normal )
    //
    [Impl(AggressiveInlining)] internal static v2 reflect(v2 Vn, v2 Sn) => Vn - Sn*(2f * dot(Vn, Sn));
    [Impl(AggressiveInlining)] internal static v3 reflect(v3 Vn, v3 Sn) => Vn - Sn*(2f * dot(Vn, Sn));

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
    //                          |    /     \    |       > 1.0  refracts outwards
    //                          +---●---+---●---+
    //                               .  |  .
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
    [Impl(AggressiveInlining)] internal static v1 round(v1 A) => System.MathF.Round(A);
    [Impl(AggressiveInlining)] internal static v2 round(v2 A) => new v2(round(A.x), round(A.y));
    [Impl(AggressiveInlining)] internal static v3 round(v3 A) => new v3(round(A.x), round(A.y), round(A.z));
    [Impl(AggressiveInlining)] internal static v4 round(v4 A) => new v4(round(A.x), round(A.y), round(A.z), round(A.w));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //                                                                      "Floor"
    [Impl(AggressiveInlining)] internal static v1 floor(v1 A) => System.MathF.Floor(A);
    [Impl(AggressiveInlining)] internal static v2 floor(v2 A) => new v2(floor(A.x), floor(A.y));
    [Impl(AggressiveInlining)] internal static v3 floor(v3 A) => new v3(floor(A.x), floor(A.y), floor(A.z));
    [Impl(AggressiveInlining)] internal static v4 floor(v4 A) => new v4(floor(A.x), floor(A.y), floor(A.z), floor(A.w));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //                                                                      "Ceiling"
    [Impl(AggressiveInlining)] internal static v1 ceil(v1 A) => System.MathF.Ceiling(A);
    [Impl(AggressiveInlining)] internal static v2 ceil(v2 A) => new v2(ceil(A.x), ceil(A.y));
    [Impl(AggressiveInlining)] internal static v3 ceil(v3 A) => new v3(ceil(A.x), ceil(A.y), ceil(A.z));
    [Impl(AggressiveInlining)] internal static v4 ceil(v4 A) => new v4(ceil(A.x), ceil(A.y), ceil(A.z), ceil(A.w));

    //==========================================================================================================================================================
    //                                                                     "Round" To
    //  Each component rounded to the nearest 'RoundTo'.
    //
    [Impl(AggressiveInlining)] internal static v1 round(v1 A, v1 RoundTo) => /*(RoundTo==0f || RoundTo==1f) ? round(A) :*/ RoundTo * round(A/RoundTo);
    [Impl(AggressiveInlining)] internal static v2 round(v2 A, v1 RoundTo) => /*(RoundTo==0f || RoundTo==1f) ? round(A) :*/ RoundTo * round(A/RoundTo);
    [Impl(AggressiveInlining)] internal static v3 round(v3 A, v1 RoundTo) => /*(RoundTo==0f || RoundTo==1f) ? round(A) :*/ RoundTo * round(A/RoundTo);
    [Impl(AggressiveInlining)] internal static v4 round(v4 A, v1 RoundTo) => /*(RoundTo==0f || RoundTo==1f) ? round(A) :*/ RoundTo * round(A/RoundTo);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                       "Sign"
    [Impl(AggressiveInlining)] internal static v1 sign(v1 A) => System.MathF.Sign(A);
    [Impl(AggressiveInlining)] internal static v2 sign(v2 A) => new v2(sign(A.x), sign(A.y));
    [Impl(AggressiveInlining)] internal static v3 sign(v3 A) => new v3(sign(A.x), sign(A.y), sign(A.z));
    [Impl(AggressiveInlining)] internal static v4 sign(v4 A) => new v4(sign(A.x), sign(A.y), sign(A.z), sign(A.w));

    //==========================================================================================================================================================
    //                                                                     Copy "Sign"
    //
    //      sign( AbsoluteValueOfThis, WithTheSignOfThis )
    //
    [Impl(AggressiveInlining)] internal static v1 sign(v1 A, v1 S) => System.MathF.CopySign(A, S);

    [Impl(AggressiveInlining)] internal static v2 sign(v2 A, v1 S) => new v2(sign(A.x, S  ), sign(A.y, S  ));
    [Impl(AggressiveInlining)] internal static v2 sign(v2 A, v2 S) => new v2(sign(A.x, S.x), sign(A.y, S.y));

    [Impl(AggressiveInlining)] internal static v3 sign(v3 A, v1 S) => new v3(sign(A.x, S  ), sign(A.y, S  ), sign(A.z, S  ));
    [Impl(AggressiveInlining)] internal static v3 sign(v3 A, v3 S) => new v3(sign(A.x, S.x), sign(A.y, S.y), sign(A.z, S.z));

    [Impl(AggressiveInlining)] internal static v4 sign(v4 A, v1 S) => new v4(sign(A.x, S  ), sign(A.y, S  ), sign(A.z, S  ), sign(A.w, S  ));
    [Impl(AggressiveInlining)] internal static v4 sign(v4 A, v4 S) => new v4(sign(A.x, S.x), sign(A.y, S.y), sign(A.z, S.z), sign(A.w, S.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                           "Sum of" a Vector's Components
    [Impl(AggressiveInlining)] internal static v1 sumof(v2 A) => (A.x + A.y);
    [Impl(AggressiveInlining)] internal static v1 sumof(v3 A) => (A.x + A.y + A.z);
    [Impl(AggressiveInlining)] internal static v1 sumof(v4 A) => (A.x + A.y + A.z + A.w);

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
    [Impl(AggressiveInlining)] internal static v1  cos(v1 A) => System.MathF.Cos(A);
    [Impl(AggressiveInlining)] internal static v2  cos(v2 A) => new v2(cos(A.x), cos(A.y));
    [Impl(AggressiveInlining)] internal static v3  cos(v3 A) => new v3(cos(A.x), cos(A.y), cos(A.z));
    [Impl(AggressiveInlining)] internal static v4  cos(v4 A) => new v4(cos(A.x), cos(A.y), cos(A.z), cos(A.w));

    [Impl(AggressiveInlining)] internal static v1 acos(v1 A) => System.MathF.Acos(A);
    [Impl(AggressiveInlining)] internal static v2 acos(v2 A) => new v2(acos(A.x), acos(A.y));
    [Impl(AggressiveInlining)] internal static v3 acos(v3 A) => new v3(acos(A.x), acos(A.y), acos(A.z));
    [Impl(AggressiveInlining)] internal static v4 acos(v4 A) => new v4(acos(A.x), acos(A.y), acos(A.z), acos(A.w));

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v1  sin(v1 A) => System.MathF.Sin(A);
    [Impl(AggressiveInlining)] internal static v2  sin(v2 A) => new v2(sin(A.x), sin(A.y));
    [Impl(AggressiveInlining)] internal static v3  sin(v3 A) => new v3(sin(A.x), sin(A.y), sin(A.z));
    [Impl(AggressiveInlining)] internal static v4  sin(v4 A) => new v4(sin(A.x), sin(A.y), sin(A.z), sin(A.w));

    [Impl(AggressiveInlining)] internal static v1 asin(v1 A) => System.MathF.Asin(A);
    [Impl(AggressiveInlining)] internal static v2 asin(v2 A) => new v2(asin(A.x), asin(A.y));
    [Impl(AggressiveInlining)] internal static v3 asin(v3 A) => new v3(asin(A.x), asin(A.y), asin(A.z));
    [Impl(AggressiveInlining)] internal static v4 asin(v4 A) => new v4(asin(A.x), asin(A.y), asin(A.z), asin(A.w));

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static (v1 Sin, v1 Cos) sincos(v1 A) => System.MathF.SinCos(A);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v1  tan(v1 A) => System.MathF.Tan(A);
    [Impl(AggressiveInlining)] internal static v2  tan(v2 A) => new v2(tan(A.x), tan(A.y));
    [Impl(AggressiveInlining)] internal static v3  tan(v3 A) => new v3(tan(A.x), tan(A.y), tan(A.z));
    [Impl(AggressiveInlining)] internal static v4  tan(v4 A) => new v4(tan(A.x), tan(A.y), tan(A.z), tan(A.w));

    [Impl(AggressiveInlining)] internal static v1 atan(v1 A) => System.MathF.Atan(A);
    [Impl(AggressiveInlining)] internal static v2 atan(v2 A) => new v2(atan(A.x), atan(A.y));
    [Impl(AggressiveInlining)] internal static v3 atan(v3 A) => new v3(atan(A.x), atan(A.y), atan(A.z));
    [Impl(AggressiveInlining)] internal static v4 atan(v4 A) => new v4(atan(A.x), atan(A.y), atan(A.z), atan(A.w));

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v1 atan2(v1 Y, v1 X) => System.MathF.Atan2(Y, X);

    [Impl(AggressiveInlining)] internal static v1 atan2(v2 A) => System.MathF.Atan2(A.y, A.x);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     Hyperbolic
    [Impl(AggressiveInlining)] internal static v1  cosh(v1 A) => System.MathF.Cosh(A);

    [Impl(AggressiveInlining)] internal static v1 acosh(v1 A) => System.MathF.Acosh(A);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v1  sinh(v1 A) => System.MathF.Sinh(A);

    [Impl(AggressiveInlining)] internal static v1 asinh(v1 A) => System.MathF.Asinh(A);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v1  tanh(v1 A) => System.MathF.Tanh(A);

    [Impl(AggressiveInlining)] internal static v1 atanh(v1 A) => System.MathF.Atanh(A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  For a more precise conversion.
    //
    //  For a quick conversion:  Var * TO_DEG
    //                           Var * TO_RAD
    //
    [Impl(AggressiveInlining)] internal static v1 ToDeg(v1 Radians) => (f32)((f64)Radians * (180d / 3.14159265358979323846264338327950288419716939937511d));
    [Impl(AggressiveInlining)] internal static v2 ToDeg(v2 Rad) => new v2(ToDeg(Rad.x), ToDeg(Rad.y));
    [Impl(AggressiveInlining)] internal static v3 ToDeg(v3 Rad) => new v3(ToDeg(Rad.x), ToDeg(Rad.y), ToDeg(Rad.z));
    [Impl(AggressiveInlining)] internal static v4 ToDeg(v4 Rad) => new v4(ToDeg(Rad.x), ToDeg(Rad.y), ToDeg(Rad.z), ToDeg(Rad.w));

  //[Impl(AggressiveInlining)] internal static v1 degrees(v1 Rad) => ToDeg(Rad);
  //[Impl(AggressiveInlining)] internal static v2 degrees(v2 Rad) => ToDeg(Rad);
  //[Impl(AggressiveInlining)] internal static v3 degrees(v3 Rad) => ToDeg(Rad);
  //[Impl(AggressiveInlining)] internal static v4 degrees(v4 Rad) => ToDeg(Rad);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining)] internal static v1 ToRad(v1 Degrees) => (f32)((f64)Degrees * (3.14159265358979323846264338327950288419716939937511d / 180d));
    [Impl(AggressiveInlining)] internal static v2 ToRad(v2 Deg) => new v2(ToRad(Deg.x), ToRad(Deg.y));
    [Impl(AggressiveInlining)] internal static v3 ToRad(v3 Deg) => new v3(ToRad(Deg.x), ToRad(Deg.y), ToRad(Deg.z));
    [Impl(AggressiveInlining)] internal static v4 ToRad(v4 Deg) => new v4(ToRad(Deg.x), ToRad(Deg.y), ToRad(Deg.z), ToRad(Deg.w));

  //[Impl(AggressiveInlining)] internal static v1 radians(v1 Deg) => ToRad(Deg);
  //[Impl(AggressiveInlining)] internal static v2 radians(v2 Deg) => ToRad(Deg);
  //[Impl(AggressiveInlining)] internal static v3 radians(v3 Deg) => ToRad(Deg);
  //[Impl(AggressiveInlining)] internal static v4 radians(v4 Deg) => ToRad(Deg);

    //==========================================================================================================================================================
    //
    //  Tau(0.125) ==  "45 degrees"  in radians
    //  Tau(0.25)  ==  "90 degrees"
    //  Tau(0.5)   == "180 degrees"
    //  Tau(0.75)  == "270 degrees"
    //  Tau(1.0)   == "360 degrees"
    //
    [Impl(AggressiveInlining)] internal static f32 Tau(f64 u) => (f32)(u * 6.28318530717958647692528676655900576839433879875021);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
