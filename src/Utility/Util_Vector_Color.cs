
namespace Utility;
internal static partial class VEC_Color {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] internal static float ByteToUnit(u8 Byte) =>       f32(Byte) / 255f;

    [In(line)] internal static float ByteToUnit(i1 Byte) => clamp(f32(Byte) / 255f);

    [In(line)] internal static vec3  ByteToUnit(u8 R, u8 G, u8 B)       => new vec3(ByteToUnit(R),ByteToUnit(G),ByteToUnit(B));
    [In(line)] internal static vec4  ByteToUnit(u8 R, u8 G, u8 B, u8 A) => new vec4(ByteToUnit(R),ByteToUnit(G),ByteToUnit(B), ByteToUnit(A));

    //==========================================================================================================================================================
    [In(line)] internal static u8 UnitToByte(float Unit) => (u8)round(Unit * 255f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/f270540546
    //  https://entropymine.com/imageworsener/srgbformula/
    //
    [In(line)] internal static v1 sRGB_to_Lin(v1 C) => (C <= 0.0404482362771082f) ? (C / 12.92f) : pow((C+0.055f)/1.055f, 2.4f);

    [In(line)] internal static v3 sRGB_to_Lin(v1 R, v1 G, v1 B)       => new v3(sRGB_to_Lin(  R),sRGB_to_Lin(  G),sRGB_to_Lin(  B));
    [In(line)] internal static v3 sRGB_to_Lin(v3 C)                   => new v3(sRGB_to_Lin(C.r),sRGB_to_Lin(C.g),sRGB_to_Lin(C.b));

    [In(line)] internal static v4 sRGB_to_Lin(v1 R, v1 G, v1 B, v1 A) => new v4(sRGB_to_Lin(  R),sRGB_to_Lin(  G),sRGB_to_Lin(  B),   A);
    [In(line)] internal static v4 sRGB_to_Lin(v4 C)                   => new v4(sRGB_to_Lin(C.r),sRGB_to_Lin(C.g),sRGB_to_Lin(C.b), C.a);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static v3 sRGB_to_Lin(i1 R, i1 G, i1 B)       => new v3(sRGB_to_Lin(ByteToUnit(R)),sRGB_to_Lin(ByteToUnit(G)),sRGB_to_Lin(ByteToUnit(B)));
    [In(line)] internal static v4 sRGB_to_Lin(i1 R, i1 G, i1 B, i1 A) => new v4(sRGB_to_Lin(ByteToUnit(R)),sRGB_to_Lin(ByteToUnit(G)),sRGB_to_Lin(ByteToUnit(B)),   ByteToUnit(A));

    //==========================================================================================================================================================
    [In(line)] internal static v1 Lin_to_sRGB(v1 C) => (C <= 0.00313066844250063f) ? (C * 12.92f) : pow(C, 1f/2.4f)*1.055f - 0.055f;

    [In(line)] internal static v3 Lin_to_sRGB(v1 R, v1 G, v1 B)       => new v3(Lin_to_sRGB(  R),Lin_to_sRGB(  G),Lin_to_sRGB(  B));
    [In(line)] internal static v3 Lin_to_sRGB(v3 C)                   => new v3(Lin_to_sRGB(C.r),Lin_to_sRGB(C.g),Lin_to_sRGB(C.b));

    [In(line)] internal static v4 Lin_to_sRGB(v1 R, v1 G, v1 B, v1 A) => new v4(Lin_to_sRGB(  R),Lin_to_sRGB(  G),Lin_to_sRGB(  B),   A);
    [In(line)] internal static v4 Lin_to_sRGB(v4 C)                   => new v4(Lin_to_sRGB(C.r),Lin_to_sRGB(C.g),Lin_to_sRGB(C.b), C.a);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static v3 Lin_to_sRGB(i1 R, i1 G, i1 B)       => new v3(Lin_to_sRGB(ByteToUnit(R)),Lin_to_sRGB(ByteToUnit(G)),Lin_to_sRGB(ByteToUnit(B)));
    [In(line)] internal static v4 Lin_to_sRGB(i1 R, i1 G, i1 B, i1 A) => new v4(Lin_to_sRGB(ByteToUnit(R)),Lin_to_sRGB(ByteToUnit(G)),Lin_to_sRGB(ByteToUnit(B)),   ByteToUnit(A));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "(Hue, Saturation, Value)  to  (Red, Green, Blue)"
    //
    //      H: 0..6,
    //      S: 0..1,
    //      V: 0..1
    //
    //             |-----------● C
    //             |-------● X .
    //    |--------● M     .   .
    //             .       .   .
    //    +-------------------------+
    //  R |=========       .   .    |
    //    |                .   .    |
    //  G |=================   .    |
    //    |                    .    |
    //  B |=====================    |
    //    +-------------------------+
    //
    //
    //       Red Ylw Grn Cyn Blu Vlt Red
    //  Hue:  0   1   2   3   4   5   6
    //            1       1       1
    //           / \     / \     / \
    //    X:    /   \   /   \   /   \
    //         /     \ /     \ /     \
    //        0       0       0       0
    //
    internal static vec3 HSV_to_RGB(float Hue, float Sat, float Val) {
        Hue = wrap(Hue, 0f, 6f);
        Sat = clamp(Sat);
        Val = clamp(Val);

        //  Is color Grey?
        if (Sat <= 0f)
            return new vec3(Val);

        float C = Val * Sat;
        float X = fract(Hue);
        float M = Val - C;

        return (Hue < 1f) ? new vec3(         Val,      C*X + M,            M)  //  Red
             : (Hue < 2f) ? new vec3(C*(1f-X) + M,          Val,            M)  //     Ylw
             : (Hue < 3f) ? new vec3(           M,          Val,      C*X + M)  //  Grn
             : (Hue < 4f) ? new vec3(           M, C*(1f-X) + M,          Val)  //     Cyn
             : (Hue < 5f) ? new vec3(     C*X + M,            M,          Val)  //  Blu
                          : new vec3(         Val,            M, C*(1f-X) + M); //     Vlt
    }

    [In(line)] internal static vec3 HSV_to_RGB(vec3 HSV) => HSV_to_RGB(HSV.x,HSV.y,HSV.z);

    //==========================================================================================================================================================
    internal static vec3 RGB_to_HSV(float Red, float Grn, float Blu) {
        Red = clamp(Red);
        Grn = clamp(Grn);
        Blu = clamp(Blu);

        //  Is color Grey?
        if (Red == Grn && Red == Blu)
            return new vec3(0f, 0f, Red);

        float Val = max(Red, Grn, Blu);

        float Dlt = Val - min(Red, Grn, Blu);

        float Hue = (Red == Val) ? (Grn - Blu)/Dlt
                  : (Grn == Val) ? (Blu - Red)/Dlt + 2f
                                 : (Red - Grn)/Dlt + 4f;
        Hue += (Hue < 0f) ? 6f : 0f; // Wrap.

        float Sat = Dlt / Val;

        return new vec3(Hue, Sat, Val);
    }

    [In(line)] internal static vec3 RGB_to_HSV(vec3 RGB) => HSV_to_RGB(RGB.r,RGB.g,RGB.b);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Input should be in LinearSpace.
    //
    [In(line)] internal static float ToBrightness(float R, float G, float B) => (
          R * 0.2126f
        + G * 0.7152f
        + B * 0.0722f
    );

    [In(line)] internal static float ToBrightness(vec3 C) => ToBrightness(C.r,C.g,C.b);

    //==========================================================================================================================================================
    //
    //  Based on OkLab ColorSpace.
    //
    //  Input should be in LinearSpace.
    //
    internal static float ToLightness(float R, float G, float B) => (
          0.2104542553f * cbrt(0.4122214708f*R + 0.5363325363f*G + 0.0514459929f*B)
        + 0.7936177850f * cbrt(0.2119034982f*R + 0.6806995451f*G + 0.1073969566f*B)
        - 0.0040720468f * cbrt(0.0883024619f*R + 0.2817188376f*G + 0.6299787005f*B)
    );

    [In(line)] internal static float ToLightness(vec3 C) => ToLightness(C.r,C.g,C.b);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Pseudo-ToneMapping:
    //      "Pseudo" because it operates on normalized-values instead of quantitative-values.
    //
    internal static float PseudoToneMap(float V, float A, float B) {
        float iB = 1f-B;
        float iV = 1f-V;
        float VV = V*V;
        return pow(V, A) + (VV*iV)/(VV*iB + B);
    }

    internal static vec3 PseudoToneMap(vec3 V, float A, float B) {
        float iB = 1f-B;
        vec3  iV = 1f-V;
        vec3  VV = V*V;
        return pow(V, A) + (VV*iV)/(VV*iB + B);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
