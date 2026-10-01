
namespace Utility;
internal static partial class GLSL {
public readonly static string Gamma = $$$"""
#line {{{LINE_GAMMA + LINE_NUMBER(1)}}}
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    float sRGB_to_Lin(float C) {return (C <= 0.04044823627710820) ? (C / 12.92) : pow((C+0.055) / 1.055, 2.4);}
    float Lin_to_sRGB(float C) {return (C <= 0.00313066844250063) ? (C * 12.92) : pow(C, 1.0/2.4)*1.055 - 0.055;}

    vec3  sRGB_to_Lin(vec3  C)                            {return vec3(sRGB_to_Lin(C.r),sRGB_to_Lin(C.g),sRGB_to_Lin(C.b));}
    vec3  Lin_to_sRGB(vec3  C)                            {return vec3(Lin_to_sRGB(C.r),Lin_to_sRGB(C.g),Lin_to_sRGB(C.b));}

    vec4  sRGB_to_Lin(vec4  C)                            {return vec4(sRGB_to_Lin(C.r),sRGB_to_Lin(C.g),sRGB_to_Lin(C.b),C.a);}
    vec4  Lin_to_sRGB(vec4  C)                            {return vec4(Lin_to_sRGB(C.r),Lin_to_sRGB(C.g),Lin_to_sRGB(C.b),C.a);}

    //==========================================================================================================================================================
    vec3  sRGB_to_Lin(float R, float G, float B)          {return vec3(sRGB_to_Lin(  R),sRGB_to_Lin(  G),sRGB_to_Lin(  B));}
    vec3  Lin_to_sRGB(float R, float G, float B)          {return vec3(Lin_to_sRGB(  R),Lin_to_sRGB(  G),Lin_to_sRGB(  B));}

    vec4  sRGB_to_Lin(float R, float G, float B, float A) {return vec4(sRGB_to_Lin(  R),sRGB_to_Lin(  G),sRGB_to_Lin(  B),  A);}
    vec4  Lin_to_sRGB(float R, float G, float B, float A) {return vec4(Lin_to_sRGB(  R),Lin_to_sRGB(  G),Lin_to_sRGB(  B),  A);}

    vec4  sRGB_to_Lin(vec2 V,           float B, float A) {return vec4(sRGB_to_Lin(V.r),sRGB_to_Lin(V.g),sRGB_to_Lin(  B),  A);}
    vec4  Lin_to_sRGB(vec2 V,           float B, float A) {return vec4(Lin_to_sRGB(V.r),Lin_to_sRGB(V.g),Lin_to_sRGB(  B),  A);}

    vec4  sRGB_to_Lin(vec3 V,                    float A) {return vec4(sRGB_to_Lin(V.r),sRGB_to_Lin(V.g),sRGB_to_Lin(V.b),  A);}
    vec4  Lin_to_sRGB(vec3 V,                    float A) {return vec4(Lin_to_sRGB(V.r),Lin_to_sRGB(V.g),Lin_to_sRGB(V.b),  A);}

    //==========================================================================================================================================================
    //vec3 GammaTest(float C) {return (C > 0.495 && C < 0.505) ? vec3(1.0, 0.0, 0.0) : vec3(C);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
""";}
