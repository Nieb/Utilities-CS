
namespace Utility;
internal static partial class GLSL {
public readonly static string Interpolation = $$$"""
#line {{{LINE_INTERPOLATION + LINE_NUMBER(1)}}}
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    float Gaussian(float x, float y)          {return exp(  -pow(x  ,2.0) - pow(y  ,2.0)  );}
    float Gaussian(float x, float y, float R) {return exp(  -pow(x/R,2.0) - pow(y/R,2.0)  );}

    //==========================================================================================================================================================
    float Lanczos(float x) {                      return (2.0*sin(x)*sin(x/2.0)) / (x*x);}
    float Lanczos(vec2  V) {float x = length(V);  return (2.0*sin(x)*sin(x/2.0)) / (x*x);}

    //float Lanczos(float x) {      x =        x*PI;   return (2.0*sin(x)*sin(x/2.0)) / (x*x);}
    //float Lanczos(vec2  V) {float x = length(V*PI);  return (2.0*sin(x)*sin(x/2.0)) / (x*x);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    float WeightedSum(float A, float B, float C, vec3 W) {return (A*W.x + B*W.y + C*W.z);}
    vec2  WeightedSum(vec2  A, vec2  B, vec2  C, vec3 W) {return (A*W.x + B*W.y + C*W.z);}
    vec3  WeightedSum(vec3  A, vec3  B, vec3  C, vec3 W) {return (A*W.x + B*W.y + C*W.z);}
    vec4  WeightedSum(vec4  A, vec4  B, vec4  C, vec3 W) {return (A*W.x + B*W.y + C*W.z);}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    vec3 NormalizeBary(vec3 W) {return W / (W.x + W.y + W.z);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //       A <---> B <---> C
    //      -1       0       1
    //
    vec3 Mix(vec3 A, vec3 B, vec3 C, float V) {return mix(mix(A,B,1.0+V),  mix(B,C,V), step(0.0,V));}
    //vec3 Mix(vec3 A, vec3 B, vec3 C, float V) {return (V < 0.0) ? mix(A,B,1.0+V) : mix(B,C,V);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    float SmoothStep(float V)                   {return smoothstep(     0.0 ,      1.0 , V);}
    vec2  SmoothStep(vec2  V)                   {return smoothstep(vec2(0.0), vec2(1.0), V);}
    vec3  SmoothStep(vec3  V)                   {return smoothstep(vec3(0.0), vec3(1.0), V);}
    vec4  SmoothStep(vec4  V)                   {return smoothstep(vec4(0.0), vec4(1.0), V);}

    float SmoothStep(float V, float L, float U) {return smoothstep(      L  ,       U  , V);}
    vec2  SmoothStep(vec2  V, float L, float U) {return smoothstep(vec2( L ), vec2( U ), V);}
    vec3  SmoothStep(vec3  V, float L, float U) {return smoothstep(vec3( L ), vec3( U ), V);}
    vec4  SmoothStep(vec4  V, float L, float U) {return smoothstep(vec4( L ), vec4( U ), V);}

    //==========================================================================================================================================================
    float SmootherStep(float V)                   {V=Clamp(V);            return V*V*V * ((6.0*V - 15.0)*V + 10.0);}
    vec2  SmootherStep(vec2  V)                   {V=Clamp(V);            return V*V*V * ((6.0*V - 15.0)*V + 10.0);}
    vec3  SmootherStep(vec3  V)                   {V=Clamp(V);            return V*V*V * ((6.0*V - 15.0)*V + 10.0);}
    vec4  SmootherStep(vec4  V)                   {V=Clamp(V);            return V*V*V * ((6.0*V - 15.0)*V + 10.0);}

    float SmootherStep(float V, float L, float U) {V=Clamp((V-L)/(U-L));  return V*V*V * ((6.0*V - 15.0)*V + 10.0);}
    vec2  SmootherStep(vec2  V, float L, float U) {V=Clamp((V-L)/(U-L));  return V*V*V * ((6.0*V - 15.0)*V + 10.0);}
    vec3  SmootherStep(vec3  V, float L, float U) {V=Clamp((V-L)/(U-L));  return V*V*V * ((6.0*V - 15.0)*V + 10.0);}
    vec4  SmootherStep(vec4  V, float L, float U) {V=Clamp((V-L)/(U-L));  return V*V*V * ((6.0*V - 15.0)*V + 10.0);}

    //==========================================================================================================================================================
    float SmoothestStep(float V)                   {V=Clamp(V);            float VV=V*V;  float VVV=VV*V;  float VVVV=VV*VV;  return VVVV * (-20.0*VVV + 70.0*VV - 84.0*V + 35.0);}
    vec2  SmoothestStep(vec2  V)                   {V=Clamp(V);            vec2  VV=V*V;  vec2  VVV=VV*V;  vec2  VVVV=VV*VV;  return VVVV * (-20.0*VVV + 70.0*VV - 84.0*V + 35.0);}
    vec3  SmoothestStep(vec3  V)                   {V=Clamp(V);            vec3  VV=V*V;  vec3  VVV=VV*V;  vec3  VVVV=VV*VV;  return VVVV * (-20.0*VVV + 70.0*VV - 84.0*V + 35.0);}
    vec4  SmoothestStep(vec4  V)                   {V=Clamp(V);            vec4  VV=V*V;  vec4  VVV=VV*V;  vec4  VVVV=VV*VV;  return VVVV * (-20.0*VVV + 70.0*VV - 84.0*V + 35.0);}

    float SmoothestStep(float V, float L, float U) {V=Clamp((V-L)/(U-L));  float VV=V*V;  float VVV=VV*V;  float VVVV=VV*VV;  return VVVV * (-20.0*VVV + 70.0*VV - 84.0*V + 35.0);}
    vec2  SmoothestStep(vec2  V, float L, float U) {V=Clamp((V-L)/(U-L));  vec2  VV=V*V;  vec2  VVV=VV*V;  vec2  VVVV=VV*VV;  return VVVV * (-20.0*VVV + 70.0*VV - 84.0*V + 35.0);}
    vec3  SmoothestStep(vec3  V, float L, float U) {V=Clamp((V-L)/(U-L));  vec3  VV=V*V;  vec3  VVV=VV*V;  vec3  VVVV=VV*VV;  return VVVV * (-20.0*VVV + 70.0*VV - 84.0*V + 35.0);}
    vec4  SmoothestStep(vec4  V, float L, float U) {V=Clamp((V-L)/(U-L));  vec4  VV=V*V;  vec4  VVV=VV*V;  vec4  VVVV=VV*VV;  return VVVV * (-20.0*VVV + 70.0*VV - 84.0*V + 35.0);}

    //==========================================================================================================================================================
    float QuadStep(float V) {V = Clamp(V);return mix(    (2.0 * V*V),    (-1.0 + (4.0 - 2.0*V) * V),    step(     0.5 , V)    );}
    vec2  QuadStep(vec2  V) {V = Clamp(V);return mix(    (2.0 * V*V),    (-1.0 + (4.0 - 2.0*V) * V),    step(vec2(0.5), V)    );}
    vec3  QuadStep(vec3  V) {V = Clamp(V);return mix(    (2.0 * V*V),    (-1.0 + (4.0 - 2.0*V) * V),    step(vec3(0.5), V)    );}

    //==========================================================================================================================================================
    float PowerStep(float V, float P) {V = Clamp(V);return mix(    pow(2.0*V,P)/2.0,    1.0-pow(2.0-2.0*V,P)/2.0,    step(     0.5 ,V)    );}
    vec2  PowerStep(vec2  V, vec2  P) {V = Clamp(V);return mix(    pow(2.0*V,P)/2.0,    1.0-pow(2.0-2.0*V,P)/2.0,    step(vec2(0.5),V)    );}
    vec3  PowerStep(vec3  V, vec3  P) {V = Clamp(V);return mix(    pow(2.0*V,P)/2.0,    1.0-pow(2.0-2.0*V,P)/2.0,    step(vec3(0.5),V)    );}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    vec2  PowerStep(vec2  V, float P) {return PowerStep(V, vec2(P));}
    vec3  PowerStep(vec3  V, float P) {return PowerStep(V, vec3(P));}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
""";}
