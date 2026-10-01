
namespace Utility;
internal static partial class GLSL {
public readonly static string Blend = $$$"""
#line {{{LINE_BLEND + LINE_NUMBER(1)}}}
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    float Blend_Overlay(float S, float D) {
        return mix(
                  2.0*(    S)*(    D),
            1.0 - 2.0*(1.0-S)*(1.0-D),
            step(0.5, D)
        );
        //return (D <= 0.5) ?       2.0*(    S)*(    D)
        //                  : 1.0 - 2.0*(1.0-S)*(1.0-D);
    }
    vec3 Blend_Overlay(float S, vec3  D) {return vec3(Blend_Overlay(S  ,D.r),Blend_Overlay(S  ,D.g),Blend_Overlay(S  ,D.b));}
    vec3 Blend_Overlay(vec3  S, float D) {return vec3(Blend_Overlay(S.r,D  ),Blend_Overlay(S.g,D  ),Blend_Overlay(S.b,D  ));}
    vec3 Blend_Overlay(vec3  S, vec3  D) {return vec3(Blend_Overlay(S.r,D.r),Blend_Overlay(S.g,D.g),Blend_Overlay(S.b,D.b));}

    //==========================================================================================================================================================
    float Blend_SoftLight(float S, float D) {
        return (S <= 0.5             ) ? D - (1.0-2.0*S    ) * D*(        1.0 - D      )
             : (S >  0.5 && D <= 0.25) ? D + (    2.0*S-1.0) * D*((16.0*D-12.0)*D + 3.0)
                                       : D + (    2.0*S-1.0) *   (    sqrt(D) - D      );
    }
    vec3 Blend_SoftLight(float S, vec3  D) {return vec3(Blend_SoftLight(S  ,D.r),Blend_SoftLight(S  ,D.g),Blend_SoftLight(S  ,D.b));}
    vec3 Blend_SoftLight(vec3  S, float D) {return vec3(Blend_SoftLight(S.r,D  ),Blend_SoftLight(S.g,D  ),Blend_SoftLight(S.b,D  ));}
    vec3 Blend_SoftLight(vec3  S, vec3  D) {return vec3(Blend_SoftLight(S.r,D.r),Blend_SoftLight(S.g,D.g),Blend_SoftLight(S.b,D.b));}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
""";}
