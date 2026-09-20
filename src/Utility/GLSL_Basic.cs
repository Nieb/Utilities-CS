
namespace Utility;
internal static partial class GLSL {
public readonly static string Basic = $$$"""
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    #line {{{LINE_BASIC + LINE_NUMBER(1)}}}

    const float ZERO  = 0.0;
    const vec2  ZERO2 = vec2(0.0);
    const vec3  ZERO3 = vec3(0.0);
    const vec4  ZERO4 = vec4(0.0);
    const float ONE   = 1.0;
    const vec2  ONE2  = vec2(1.0);
    const vec3  ONE3  = vec3(1.0);
    const vec4  ONE4  = vec4(1.0);

    //==========================================================================================================================================================
    const vec3 XN = vec3(-1.0, 0.0, 0.0);
    const vec3 XP = vec3( 1.0, 0.0, 0.0);
    const vec3 YN = vec3( 0.0,-1.0, 0.0);
    const vec3 YP = vec3( 0.0, 1.0, 0.0);
    const vec3 ZN = vec3( 0.0, 0.0,-1.0);
    const vec3 ZP = vec3( 0.0, 0.0, 1.0);

    //==========================================================================================================================================================
    const float EPS1 = 0.1;
    const float EPS2 = 0.01;
    const float EPS3 = 0.001;
    const float EPS4 = 0.0001;
    const float EPS5 = 0.00001;
    const float EPS6 = 0.000001;
    const float EPS7 = 0.0000001;
    const float EPS8 = 0.00000001;
    const float EPS9 = 0.000000001;

    const float EPSILON  = EPS6;
    const float EPS      = EPS6;

    //==========================================================================================================================================================
    const float ONE_TWELFTH =  0.08333333333333333333333333333333333333333333333333;
    const float ONE_NINTH   =  0.11111111111111111111111111111111111111111111111111;
    const float ONE_SIXTH   =  0.16666666666666666666666666666666666666666666666666;
    const float ONE_THIRD   =  0.33333333333333333333333333333333333333333333333333;
    const float TWO_THIRD   =  0.66666666666666666666666666666666666666666666666666;

    //==========================================================================================================================================================
    const float PIE         =  0.39269908169872415480783042290993786052464617492189;
    const float PIQ         =  0.78539816339744830961566084581987572104929234984378;
    const float PIH         =  1.57079632679489661923132169163975144209858469968755;
    const float PI          =  3.14159265358979323846264338327950288419716939937511;
    const float PI1H        =  4.71238898038468985769396507491925432629575409906266;
    const float PI2         =  6.28318530717958647692528676655900576839433879875021;
    const float PI3         =  9.42477796076937971538793014983850865259150819812532;
    const float PI4         = 12.56637061435917295385057353311801153678867759750042;
    const float PI5         = 15.70796326794896619231321691639751442098584699687553;
    const float PI6         = 18.84955592153875943077586029967701730518301639625063;
    const float PI7         = 21.99114857512855266923850368295652018938018579562574;
    const float PI8         = 25.13274122871834590770114706623602307357735519500085;

    const float PI_RCP      =  0.31830988618379067153776752674502872406891929148091;
    const float PI2_RCP     =  0.15915494309189533576888376337251436203445964574046;
    const float PI3_RCP     =  0.10610329539459689051258917558167624135630643049364;
    const float PI4_RCP     =  0.07957747154594766788444188168625718101722982287023;

    //==========================================================================================================================================================
    const float SQRT2       =  1.41421356237309504880168872420969807856967187537695;
    const float SQRT2_RCP   =  0.70710678118654752440084436210484903928483593768847;
    const float SQRT3       =  1.73205080756887729352744634150587236694280525381038;
    const float SQRT3_RCP   =  0.57735026918962576450914878050195745564760175127013;

    //==========================================================================================================================================================
  //const float TO_DEG      = 57.29577951308232087679815481410517033240547246656432;  degrees()
  //const float TO_RAD      =  0.01745329251994329576923690768488612713442871888542;  radians()

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    float cbrt(float A) {return sign(A) * pow(abs(A), 1.0/3.0);}

    float Clamp(float A) {return clamp(A,      0.0 ,      1.0 );}
    vec2  Clamp(vec2  A) {return clamp(A, vec2(0.0), vec2(1.0));}
    vec3  Clamp(vec3  A) {return clamp(A, vec3(0.0), vec3(1.0));}
    vec4  Clamp(vec4  A) {return clamp(A, vec4(0.0), vec4(1.0));}

    float Dot(float A) {return dot(A,A);}
    float Dot(vec2  A) {return dot(A,A);}
    float Dot(vec3  A) {return dot(A,A);}

    float Min(float A, float B, float C)          {return     min(min(A,B),C);   }
    vec2  Min(vec2  A, vec2  B, vec2  C)          {return     min(min(A,B),C);   }
    vec3  Min(vec3  A, vec3  B, vec3  C)          {return     min(min(A,B),C);   }
    vec4  Min(vec4  A, vec4  B, vec4  C)          {return     min(min(A,B),C);   }
    float Min(float A, float B, float C, float D) {return min(min(min(A,B),C),D);}
    vec2  Min(vec2  A, vec2  B, vec2  C, vec2  D) {return min(min(min(A,B),C),D);}
    vec3  Min(vec3  A, vec3  B, vec3  C, vec3  D) {return min(min(min(A,B),C),D);}
    vec4  Min(vec4  A, vec4  B, vec4  C, vec4  D) {return min(min(min(A,B),C),D);}

    float Max(float A, float B, float C)          {return     max(max(A,B),C);   }
    vec2  Max(vec2  A, vec2  B, vec2  C)          {return     max(max(A,B),C);   }
    vec3  Max(vec3  A, vec3  B, vec3  C)          {return     max(max(A,B),C);   }
    vec4  Max(vec4  A, vec4  B, vec4  C)          {return     max(max(A,B),C);   }
    float Max(float A, float B, float C, float D) {return max(max(max(A,B),C),D);}
    vec2  Max(vec2  A, vec2  B, vec2  C, vec2  D) {return max(max(max(A,B),C),D);}
    vec3  Max(vec3  A, vec3  B, vec3  C, vec3  D) {return max(max(max(A,B),C),D);}
    vec4  Max(vec4  A, vec4  B, vec4  C, vec4  D) {return max(max(max(A,B),C),D);}

    //==========================================================================================================================================================
    //
    //   A <--> B <--> C
    //  -1      0      1
    //
    vec3 Mix(vec3 A, vec3 B, vec3 C, float V) {return mix(mix(A,B,1.0+V),  mix(B,C,V), step(0.0,V));}
    //vec3 Mix(vec3 A, vec3 B, vec3 C, float V) {return (V < 0.0) ? mix(A,B,1.0+V) : mix(B,C,V);}

    //==========================================================================================================================================================
    float MinOf(vec2 A) {return         min(A.x,A.y);          }
    float MinOf(vec3 A) {return     min(min(A.x,A.y),A.z);     }
    float MinOf(vec4 A) {return min(min(min(A.x,A.y),A.z),A.w);}

    float MaxOf(vec2 A) {return         max(A.x,A.y);          }
    float MaxOf(vec3 A) {return     max(max(A.x,A.y),A.z);     }
    float MaxOf(vec4 A) {return max(max(max(A.x,A.y),A.z),A.w);}

    float SumOf(vec2 A) {return dot(A,vec2(1.0));}
    float SumOf(vec3 A) {return dot(A,vec3(1.0));}
    float SumOf(vec4 A) {return dot(A,vec4(1.0));}

    //==========================================================================================================================================================
    float WeightedSum(float A, float B, float C, vec3 W) {return (A*W.x + B*W.y + C*W.z);}
    vec2  WeightedSum(vec2  A, vec2  B, vec2  C, vec3 W) {return (A*W.x + B*W.y + C*W.z);}
    vec3  WeightedSum(vec3  A, vec3  B, vec3  C, vec3 W) {return (A*W.x + B*W.y + C*W.z);}
    vec4  WeightedSum(vec4  A, vec4  B, vec4  C, vec3 W) {return (A*W.x + B*W.y + C*W.z);}

    vec3 NormalizeBary(vec3 W) {return W / (W.x + W.y + W.z);}

    //==========================================================================================================================================================
    float SmoothStep(float V) {return smoothstep(     0.0 ,      1.0 , V);}
    vec2  SmoothStep(vec2  V) {return smoothstep(vec2(0.0), vec2(1.0), V);}
    vec3  SmoothStep(vec3  V) {return smoothstep(vec3(0.0), vec3(1.0), V);}
    vec4  SmoothStep(vec4  V) {return smoothstep(vec4(0.0), vec4(1.0), V);}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    float QuadStep(float V) {V = Clamp(V);return mix(    (2.0 * V*V),    (-1.0 + (4.0 - 2.0*V) * V),    step(     0.5 , V)    );}
    vec2  QuadStep(vec2  V) {V = Clamp(V);return mix(    (2.0 * V*V),    (-1.0 + (4.0 - 2.0*V) * V),    step(vec2(0.5), V)    );}
    vec3  QuadStep(vec3  V) {V = Clamp(V);return mix(    (2.0 * V*V),    (-1.0 + (4.0 - 2.0*V) * V),    step(vec3(0.5), V)    );}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    float PowerStep(float V, float P) {V = Clamp(V);return mix(    pow(2.0*V,P)/2.0,    1.0-pow(2.0-2.0*V,P)/2.0,    step(     0.5 ,V)    );}
    vec2  PowerStep(vec2  V, vec2  P) {V = Clamp(V);return mix(    pow(2.0*V,P)/2.0,    1.0-pow(2.0-2.0*V,P)/2.0,    step(vec2(0.5),V)    );}
    vec3  PowerStep(vec3  V, vec3  P) {V = Clamp(V);return mix(    pow(2.0*V,P)/2.0,    1.0-pow(2.0-2.0*V,P)/2.0,    step(vec3(0.5),V)    );}

    vec2  PowerStep(vec2  V, float P) {return PowerStep(V, vec2(P));}
    vec3  PowerStep(vec3  V, float P) {return PowerStep(V, vec3(P));}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
""";}
