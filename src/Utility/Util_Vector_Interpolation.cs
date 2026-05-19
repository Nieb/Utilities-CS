
namespace Utility;
internal static class VEC_Interpolation {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      https://www.desmos.com/calculator/5fe71775ae
    //
    //  "Mix" functions use a Weight to return an interpolation of A and B.
    //
    //  "Step" functions return an interpolated-Weight reflecting V's position between A and B.
    //
    //  NOTE:  Order of parameters differs from GLSL.
    //         Also, TitleCase.
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                               "Linear Interpolation"
    //  Mix(
    //      w: 0..1     Weighted position between A and B.
    //      A: any      Values to be mixed.
    //      B: any      Values to be mixed.
    //  );
    //
    //  OUTPUT: A..B
    //
    //    GLSL: mix(X, Y, A)
    //              Linear interpolation between X & Y, using A to weight between them.
    //
    //          https://registry.khronos.org/OpenGL-Refpages/gl4/html/mix.xhtml
    //
    [Impl(AggressiveInlining)] internal static v1 Mix(v1 w, v1 A, v1 B) {w=clamp(w);  return A*(1f-w) + B*(w);}

    [Impl(AggressiveInlining)] internal static v2 Mix(v1 w, v2 A, v2 B) {w=clamp(w);  return A*(1f-w) + B*(w);}
    [Impl(AggressiveInlining)] internal static v2 Mix(v2 w, v2 A, v2 B) {w=clamp(w);  return A*(1f-w) + B*(w);}

    [Impl(AggressiveInlining)] internal static v3 Mix(v1 w, v3 A, v3 B) {w=clamp(w);  return A*(1f-w) + B*(w);}
    [Impl(AggressiveInlining)] internal static v3 Mix(v3 w, v3 A, v3 B) {w=clamp(w);  return A*(1f-w) + B*(w);}

    [Impl(AggressiveInlining)] internal static v4 Mix(v1 w, v4 A, v4 B) {w=clamp(w);  return A*(1f-w) + B*(w);}
    [Impl(AggressiveInlining)] internal static v4 Mix(v4 w, v4 A, v4 B) {w=clamp(w);  return A*(1f-w) + B*(w);}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] internal static v1 Lerp(v1 w, v1 A, v1 B) => A*(1f-w) + B*(w);

    [Impl(AggressiveInlining)] internal static v2 Lerp(v1 w, v2 A, v2 B) => A*(1f-w) + B*(w);
    [Impl(AggressiveInlining)] internal static v2 Lerp(v2 w, v2 A, v2 B) => A*(1f-w) + B*(w);

    [Impl(AggressiveInlining)] internal static v3 Lerp(v1 w, v3 A, v3 B) => A*(1f-w) + B*(w);
    [Impl(AggressiveInlining)] internal static v3 Lerp(v3 w, v3 A, v3 B) => A*(1f-w) + B*(w);

    [Impl(AggressiveInlining)] internal static v4 Lerp(v1 w, v4 A, v4 B) => A*(1f-w) + B*(w);
    [Impl(AggressiveInlining)] internal static v4 Lerp(v4 w, v4 A, v4 B) => A*(1f-w) + B*(w);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                              "Bilinear Interpolation"
    //  BiMix(
    //      w: (0..1, 0..1)     Weighted position for X & Y axis.
    //      A: any              Values to be mixed.
    //      B: any              Values to be mixed.
    //      C: any              Values to be mixed.
    //      D: any              Values to be mixed.
    //  );
    //              (1,1)
    //  OUTPUT: C..D
    //          :  :
    //          A..B
    //     (0,0)
    //
    internal static v1 BiMix(v2 w,  v1 A, v1 B, v1 C, v1 D) {w=clamp(w);  v2 iw=(1f-w);  return A*(iw.x*iw.y) + B*(w.x*iw.y)   +   C*(iw.x* w.y) + D*(w.x* w.y);}
    internal static v2 BiMix(v2 w,  v2 A, v2 B, v2 C, v2 D) {w=clamp(w);  v2 iw=(1f-w);  return A*(iw.x*iw.y) + B*(w.x*iw.y)   +   C*(iw.x* w.y) + D*(w.x* w.y);}
    internal static v3 BiMix(v2 w,  v3 A, v3 B, v3 C, v3 D) {w=clamp(w);  v2 iw=(1f-w);  return A*(iw.x*iw.y) + B*(w.x*iw.y)   +   C*(iw.x* w.y) + D*(w.x* w.y);}
    internal static v4 BiMix(v2 w,  v4 A, v4 B, v4 C, v4 D) {w=clamp(w);  v2 iw=(1f-w);  return A*(iw.x*iw.y) + B*(w.x*iw.y)   +   C*(iw.x* w.y) + D*(w.x* w.y);}

    [Impl(AggressiveInlining)] internal static v1 Bilinear(v2 w,  v1 A, v1 B, v1 C, v1 D) => BiMix(w, A,B,C,D);
    [Impl(AggressiveInlining)] internal static v2 Bilinear(v2 w,  v2 A, v2 B, v2 C, v2 D) => BiMix(w, A,B,C,D);
    [Impl(AggressiveInlining)] internal static v3 Bilinear(v2 w,  v3 A, v3 B, v3 C, v3 D) => BiMix(w, A,B,C,D);
    [Impl(AggressiveInlining)] internal static v4 Bilinear(v2 w,  v4 A, v4 B, v4 C, v4 D) => BiMix(w, A,B,C,D);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    internal static v1 Blerp(v2 w,  v1 A, v1 B, v1 C, v1 D) {             v2 iw=(1f-w);  return A*(iw.x*iw.y) + B*(w.x*iw.y)   +   C*(iw.x* w.y) + D*(w.x* w.y);}
    internal static v2 Blerp(v2 w,  v2 A, v2 B, v2 C, v2 D) {             v2 iw=(1f-w);  return A*(iw.x*iw.y) + B*(w.x*iw.y)   +   C*(iw.x* w.y) + D*(w.x* w.y);}
    internal static v3 Blerp(v2 w,  v3 A, v3 B, v3 C, v3 D) {             v2 iw=(1f-w);  return A*(iw.x*iw.y) + B*(w.x*iw.y)   +   C*(iw.x* w.y) + D*(w.x* w.y);}
    internal static v4 Blerp(v2 w,  v4 A, v4 B, v4 C, v4 D) {             v2 iw=(1f-w);  return A*(iw.x*iw.y) + B*(w.x*iw.y)   +   C*(iw.x* w.y) + D*(w.x* w.y);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            "Cubic/Hermite Interpolation"
    //  SmoothMix(
    //      w: 0..1     Weighted position between A and B.
    //      A: any      Values to be mixed.
    //      B: any      Values to be mixed.
    //  );
    //
    //  OUTPUT: A..B
    //
    [Impl(AggressiveInlining)] internal static v1 SmoothMix(v1 w, v1 A, v1 B) => Lerp(SmoothStep(w), A, B);
    [Impl(AggressiveInlining)] internal static v2 SmoothMix(v1 w, v2 A, v2 B) => Lerp(SmoothStep(w), A, B);
    [Impl(AggressiveInlining)] internal static v3 SmoothMix(v1 w, v3 A, v3 B) => Lerp(SmoothStep(w), A, B);
    [Impl(AggressiveInlining)] internal static v4 SmoothMix(v1 w, v4 A, v4 B) => Lerp(SmoothStep(w), A, B);

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
  //internal static v2 Slerp(v1 w, v2 A, v2 B) {v1 tAB = acos(dot(A,B));  v1 SinT = sin(tAB);  return A*(sin(tAB*(1f-w))/SinT)  +  B*(sin(tAB*w)/SinT);}
    internal static v3 Slerp(v1 w, v3 A, v3 B) {v1 tAB = acos(dot(A,B));  v1 SinT = sin(tAB);  return A*(sin(tAB*(1f-w))/SinT)  +  B*(sin(tAB*w)/SinT);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    "Threshold"
    //  GLSL: step(Edge, X)
    //
    //  Step(
    //      V: any      Value
    //      T: any      Threshold
    //  );
    //
    //  OUTPUT: 0|1
    //
    [Impl(AggressiveInlining)] internal static v1 Step(v1 V, v1 T) => (V < T) ? 0f : 1f;

    [Impl(AggressiveInlining)] internal static v2 Step(v2 V, v1 T) => new v2(Step(V.x,T  ), Step(V.y,T  ));
    [Impl(AggressiveInlining)] internal static v2 Step(v2 V, v2 T) => new v2(Step(V.x,T.x), Step(V.y,T.y));

    [Impl(AggressiveInlining)] internal static v3 Step(v3 V, v1 T) => new v3(Step(V.x,T  ), Step(V.y,T  ), Step(V.z,T  ));
    [Impl(AggressiveInlining)] internal static v3 Step(v3 V, v3 T) => new v3(Step(V.x,T.x), Step(V.y,T.y), Step(V.z,T.z));

    [Impl(AggressiveInlining)] internal static v4 Step(v4 V, v1 T) => new v4(Step(V.x,T  ), Step(V.y,T  ), Step(V.z,T  ), Step(V.w,T  ));
    [Impl(AggressiveInlining)] internal static v4 Step(v4 V, v4 T) => new v4(Step(V.x,T.x), Step(V.y,T.y), Step(V.z,T.z), Step(V.w,T.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                               "Linear Interpolation"
    //  LinearStep(
    //      V: any      Value to weigh between L and U.
    //      L: any      LowerBounds
    //      U: any      UpperBounds
    //  );
    //
    //  OUTPUT: 0..1
    //
    [Impl(AggressiveInlining)] internal static v1 LinearStep(v1 V, v1 L, v1 U) => clamp((V-L)/(U-L));

    [Impl(AggressiveInlining)] internal static v2 LinearStep(v1 V, v2 L, v2 U) => clamp((V-L)/(U-L));
    [Impl(AggressiveInlining)] internal static v2 LinearStep(v2 V, v2 L, v2 U) => clamp((V-L)/(U-L));

    [Impl(AggressiveInlining)] internal static v3 LinearStep(v1 V, v3 L, v3 U) => clamp((V-L)/(U-L));
    [Impl(AggressiveInlining)] internal static v3 LinearStep(v3 V, v3 L, v3 U) => clamp((V-L)/(U-L));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                               "Quadratic Interpolation"
    //  QuadStep(
    //      V: any      Value to weigh between L and U.
    //      L: any      LowerBounds
    //      U: any      UpperBounds
    //  );
    //
    //  OUTPUT: 0..1
    //
    [Impl(AggressiveInlining)] internal static v1 QuadStep(v1 V)             {V = clamp(V);            return (V < 0.5f)  ?  (2f * V*V)  :  (-1f + (4f - 2f*V) * V);}
    [Impl(AggressiveInlining)] internal static v1 QuadStep(v1 V, v1 L, v1 U) {V = clamp((V-L)/(U-L));  return (V < 0.5f)  ?  (2f * V*V)  :  (-1f + (4f - 2f*V) * V);}

    //==========================================================================================================================================================
    //
    //      "PowerStep(x,2f)" is equivalent to "QuadStep(x)"
    //
    [Impl(AggressiveInlining)] internal static v1 PowerStep(v1 V, v1 P)             {V = clamp(V);            return (V < 0.5f)  ?  pow(2f*V, P)/2f  :  1f-pow(2f-2f*V, P)/2f;}
    [Impl(AggressiveInlining)] internal static v1 PowerStep(v1 V, v1 P, v1 L, v1 U) {V = clamp((V-L)/(U-L));  return (V < 0.5f)  ?  pow(2f*V, P)/2f  :  1f-pow(2f-2f*V, P)/2f;}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            "Cubic/Hermite Interpolation"
    //
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/smoothstep.xhtml
    //  GLSL: smoothstep(Edge0, Edge1, X)
    //          Smooth Hermite-interpolation between 0 & 1 when Edge0 < X < Edge1.
    //
    //                         -2*(x^3) + 3*(x^2)
    //
    //                          x*x * (-2*x + 3)
    //
    //  SmoothStep(
    //      V: any      Value to weigh between L and U.
    //      L: any      LowerBounds
    //      U: any      UpperBounds
    //  );
    //
    //  OUTPUT: 0..1
    //
    [Impl(AggressiveInlining)] internal static v1 SmoothStep(v1 V)             {V = clamp(V);            return V*V * (3f - 2f*V);}
    [Impl(AggressiveInlining)] internal static v1 SmoothStep(v1 V, v1 L, v1 U) {V = clamp((V-L)/(U-L));  return V*V * (3f - 2f*V);}

    [Impl(AggressiveInlining)] internal static v2 SmoothStep(v2 V)             {V = clamp(V);            return V*V * (3f - 2f*V);}
    [Impl(AggressiveInlining)] internal static v2 SmoothStep(v2 V, v1 L, v1 U) {V = clamp((V-L)/(U-L));  return V*V * (3f - 2f*V);}
    [Impl(AggressiveInlining)] internal static v2 SmoothStep(v2 V, v2 L, v2 U) {V = clamp((V-L)/(U-L));  return V*V * (3f - 2f*V);}

    [Impl(AggressiveInlining)] internal static v3 SmoothStep(v3 V)             {V = clamp(V);            return V*V * (3f - 2f*V);}
    [Impl(AggressiveInlining)] internal static v3 SmoothStep(v3 V, v1 L, v1 U) {V = clamp((V-L)/(U-L));  return V*V * (3f - 2f*V);}
    [Impl(AggressiveInlining)] internal static v3 SmoothStep(v3 V, v3 L, v3 U) {V = clamp((V-L)/(U-L));  return V*V * (3f - 2f*V);}

    //==========================================================================================================================================================
    //
    //  If applied over the same bounds as SmoothStep, this has a sharper transition.
    //  The extra smoothness comes from correcting a discontinuity at the bounds,
    //  by smoothing the "rate-of-change of the rate-of-change".  AKA: the second derivative
    //  This can correct an illusory-line that can be perceived at the bounds of SmoothStep.
    //
    //                    6*(x^5) - 15*(x^4) + 10*(x^3)
    //
    //                     x*x*x * ((6*x - 15)*x + 10)
    //
    //  SmootherStep(
    //      V: any      Value to weigh between L and U.
    //      L: any      LowerBounds
    //      U: any      UpperBounds
    //  );
    //
    //  OUTPUT: 0..1
    //
    internal static v1 SmootherStep(v1 V)             {V = clamp(V);            return V*V*V * ((6f*V - 15f)*V + 10f);}
    internal static v1 SmootherStep(v1 V, v1 L, v1 U) {V = clamp((V-L)/(U-L));  return V*V*V * ((6f*V - 15f)*V + 10f);}

    internal static v2 SmootherStep(v2 V)             {V = clamp(V);            return V*V*V * ((6f*V - 15f)*V + 10f);}
    internal static v2 SmootherStep(v2 V, v2 L, v2 U) {V = clamp((V-L)/(U-L));  return V*V*V * ((6f*V - 15f)*V + 10f);}
    internal static v2 SmootherStep(v2 V, v1 L, v1 U) {V = clamp((V-L)/(U-L));  return V*V*V * ((6f*V - 15f)*V + 10f);}

    internal static v3 SmootherStep(v3 V)             {V = clamp(V);            return V*V*V * ((6f*V - 15f)*V + 10f);}
    internal static v3 SmootherStep(v3 V, v3 L, v3 U) {V = clamp((V-L)/(U-L));  return V*V*V * ((6f*V - 15f)*V + 10f);}
    internal static v3 SmootherStep(v3 V, v1 L, v1 U) {V = clamp((V-L)/(U-L));  return V*V*V * ((6f*V - 15f)*V + 10f);}

    //==========================================================================================================================================================
    //
    //  The same idea extended to smoothing out the third derivative.
    //
    //  SmoothestStep(
    //      V: any      Value to weigh between L and U.
    //      L: any      LowerBounds
    //      U: any      UpperBounds
    //  );
    //
    //  OUTPUT: 0..1
    //
    internal static v1 SmoothestStep(v1 V)             {V=clamp(V);            v1 VV=V*V;  v1 VVV=VV*V;  v1 VVVV=VV*VV;  return VVVV * (-20f*VVV + 70f*VV - 84f*V + 35f);}
    internal static v1 SmoothestStep(v1 V, v1 L, v1 U) {V=clamp((V-L)/(U-L));  v1 VV=V*V;  v1 VVV=VV*V;  v1 VVVV=VV*VV;  return VVVV * (-20f*VVV + 70f*VV - 84f*V + 35f);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
