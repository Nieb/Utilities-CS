
namespace Utility;
internal static partial class GLSL {
//
//  TextureGrad:
//      https://www.shadertoy.com/view/tttGzj       "Having fun with textureGrad"
//      https://registry.khronos.org/OpenGL-Refpages/gl4/html/textureGrad.xhtml
//
//  TextureQueryLod:
//      https://registry.khronos.org/OpenGL-Refpages/gl4/html/textureQueryLod.xhtml
//
//  TextureGather:
//      https://registry.khronos.org/OpenGL-Refpages/gl4/html/textureGather.xhtml
//      https://registry.khronos.org/OpenGL-Refpages/gl4/html/textureGatherOffset.xhtml
//      https://registry.khronos.org/OpenGL-Refpages/gl4/html/textureGatherOffsets.xhtml
//
//      vec4 R = textureGather(Tex0, TexUV, 0);
//      vec4 G = textureGather(Tex0, TexUV, 1);
//      vec4 B = textureGather(Tex0, TexUV, 2);
//      vec4 A = textureGather(Tex0, TexUV, 3);
//
//                            X--Y
//          Sample Locations: |  |
//                            W--Z
//
public readonly static string Texture = $$$"""
#line {{{LINE_TEXTURE + LINE_NUMBER(1)}}}
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                   Smooth Nearest
    //  "Smooth Nearest"  "Smooth PixelArt"
    //      https://www.shadertoy.com/view/csX3RH
    //
    vec4 TextureAA(sampler2D Tex, vec2 TexUV) {
        vec2 TexSize = vec2(textureSize(Tex, 0));

        TexUV *= TexSize;

        vec2 Seam = floor(TexUV+0.5);

        TexUV = (TexUV - Seam)/fwidth(TexUV) + Seam;

        TexUV = clamp(TexUV, Seam-0.5, Seam+0.5);

        return texture(Tex, TexUV/TexSize);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                    Sharper (than bilinear) Pixel Interpolation
    vec4 TextureSharp(sampler2D Tex, vec2 TexUV) {
        int MipLevel = int(textureQueryLod(Tex, TexUV).x);
        vec2 TexSize = vec2(textureSize(Tex, MipLevel));

        TexUV *= TexSize;
        TexUV = floor(TexUV-0.5)+0.5 + smoothstep(0.0,1.0,fract(TexUV-0.5));
        //TexUV = floor(TexUV-0.5)+0.5 + smoothstep(0.0,1.0,smoothstep(0.0,1.0,fract(TexUV-0.5)));
        //TexUV = floor(TexUV-0.5)+0.5 + SmoothestStep(fract(TexUV-0.5));

        return texture(Tex, TexUV/TexSize);
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    vec4 TextureSharper(sampler2D Tex, vec2 TexUV) {
        int MipLevel = int(textureQueryLod(Tex, TexUV).x);
        vec2 TexSize = vec2(textureSize(Tex, MipLevel));

        TexUV *= TexSize;
        TexUV = floor(TexUV-0.5)+0.5 + QuadStep(fract(TexUV-0.5));

        return texture(Tex, TexUV/TexSize);
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    vec4 TextureSharper(sampler2D Tex, vec2 TexUV, float Sharpness) {
        int MipLevel = int(textureQueryLod(Tex, TexUV).x);
        vec2 TexSize = vec2(textureSize(Tex, MipLevel));

        TexUV *= TexSize;
        TexUV = floor(TexUV-0.5)+0.5 + PowerStep(fract(TexUV-0.5), vec2(Sharpness));

        return texture(Tex, TexUV/TexSize);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     Barylinear
    //                          +Y
    //                            C---B
    //                            |  /|
    //                            | / |
    //                            |/  |
    //                            A---C
    //                                 +X
    vec4 Texture_Barylinear(sampler2D Tex, vec2 TexUV, int MipLevel) {
        MipLevel = min(MipLevel, textureQueryLevels(Tex)-1);

        vec2 TexSize = vec2(textureSize(Tex, MipLevel));

        //  "TexCoord"  "PixelUV"  "BlendWeights"
        ivec2 Tc0,Tc1,TcC; vec2 P; vec3 W;

        #if 0
            P = vec2(
                fract(TexUV.x) * TexSize.x - 0.5,
                      TexUV.y  * TexSize.y - 0.5  // clamp Y
            );
            Tc0 = ivec2(  mod(floor(P.x), TexSize.x-1.0),  clamp(floor(P.y), 0.0, TexSize.y-1.0)); //  texelFetch() doesn't do wrapping|clamping.
            Tc1 = ivec2(  mod( ceil(P.x), TexSize.x-1.0),  clamp( ceil(P.y), 0.0, TexSize.y-1.0));
        #else
            P = fract(TexUV) * TexSize - 0.5;
            Tc0 = ivec2(mod(floor(P), TexSize)); //  texelFetch() doesn't do wrapping.
            Tc1 = ivec2(mod( ceil(P), TexSize));
        #endif

        P = fract(P);

        if ((W.z = (P.x-P.y)) < 0.0) {W = vec3(1.0-P.y, P.x, abs(W.z));  TcC = ivec2(Tc0.x,Tc1.y);}
        else                         {W = vec3(1.0-P.x, P.y, abs(W.z));  TcC = ivec2(Tc1.x,Tc0.y);}

        vec4 A = texelFetch(Tex, Tc0, MipLevel);
        vec4 B = texelFetch(Tex, Tc1, MipLevel);
        vec4 C = texelFetch(Tex, TcC, MipLevel);

        return (A*W.x  +  B*W.y  +  C*W.z);
    }
    /*
    vec4 Texture_Barylinear(sampler2D Tex, vec2 TexUV, int MipLevel) {
        MipLevel = min(MipLevel, textureQueryLevels(Tex)-1);

        vec2 TexSize = vec2(textureSize(Tex, MipLevel));

        //  "TexCoord"  "PixelUV"  "BlendWeights"
        vec2 Tc0,Tc1,TcC, P; vec3 W;

        P = TexUV * TexSize - 0.5;
        Tc0 = floor(P+0.001) / TexSize;
        Tc1 =  ceil(P-0.001) / TexSize;
        P = clamp(fract(fract(TexUV) * TexSize - 0.5), 0.05, 0.95);

        if ((W.z = (P.x-P.y)) < 0.0) {W = vec3(1.0-P.y, P.x, abs(W.z));  TcC = vec2(Tc0.x,Tc1.y);}
        else                         {W = vec3(1.0-P.x, P.y, abs(W.z));  TcC = vec2(Tc1.x,Tc0.y);}

        vec4 A = texture(Tex, Tc0, MipLevel);
        vec4 B = texture(Tex, Tc1, MipLevel);
        vec4 C = texture(Tex, TcC, MipLevel);

        return (A*W.x  +  B*W.y  +  C*W.z);
    }
    */

    vec4 Texture_Barylinear(sampler2D Tex, vec2 TexUV) {return Texture_Barylinear(Tex, TexUV, int(textureQueryLod(Tex,TexUV).x) );} //  Optional Parameter Hack.

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //                          +Y
    //                            C---A
    //                            |\  |
    //                            | \ |
    //                            |  \|
    //                            A---B
    //                                 +X
    vec4 Texture_Barylinear_(sampler2D Tex, vec2 TexUV, int MipLevel) {
        MipLevel = min(MipLevel, textureQueryLevels(Tex)-1);

        vec2 TexSize = vec2(textureSize(Tex, MipLevel));

        //  "TexCoord"  "Pixel UV"  "Weights"
        ivec2 TcA,Tc0,Tc1; vec2 P; vec3 W;

        P = fract(TexUV) * TexSize - 0.5;
        Tc0 = ivec2(mod(floor(P), TexSize)); //  texelFetch() doesn't do wrapping.
        Tc1 = ivec2(mod( ceil(P), TexSize)); //  also, integer modulo is annoying.  :P
        //Tc0 = (tc0 % TexSize + TexSize) % TexSize; //Tc0 &= (TexSize - 1);
        //Tc1 = (tc1 % TexSize + TexSize) % TexSize; //Tc1 &= (TexSize - 1);
        P = fract(P);

        if ((W.x = (1.0-P.x-P.y)) < 0.0) {W = vec3(abs(W.x), 1.0-P.yx);  TcA = Tc1;}
        else                             {W = vec3(abs(W.x),     P.xy);  TcA = Tc0;}

        vec4 A = texelFetch(Tex,       TcA         , MipLevel);
        vec4 B = texelFetch(Tex, ivec2(Tc1.x,Tc0.y), MipLevel);
        vec4 C = texelFetch(Tex, ivec2(Tc0.x,Tc1.y), MipLevel);

        return (A*W.x  +  B*W.y  +  C*W.z);
    }

    vec4 Texture_Barylinear_(sampler2D Tex, vec2 TexUV) {return Texture_Barylinear_(Tex, TexUV, int(textureQueryLod(Tex,TexUV).x) );} //  Optional Parameter Hack.

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      TriPlanar
    vec4 Texture_TriPlanar(sampler2D TEX, vec3 Pos, vec3 Nrm, float BiasExp, bool TEST) {
        vec3 Select = step(0.0, Nrm);

        vec2 TexCoordX = mix(vec2(-Pos.z, Pos.y),       Pos.zy       , Select.x);
        vec2 TexCoordY = mix(vec2( Pos.x,-Pos.z),       Pos.xz       , Select.y);
        vec2 TexCoordZ = mix(      Pos.xy       , vec2(-Pos.x, Pos.y), Select.z);

        vec2 TexScale = 1.0 / vec2(textureSize(TEX,0));

        vec4 TexSmplX = texture(TEX, TexCoordX * TexScale);
        vec4 TexSmplY = texture(TEX, TexCoordY * TexScale);
        vec4 TexSmplZ = texture(TEX, TexCoordZ * TexScale);

        vec3 BlendMask = vec3( ToLightness(TexSmplX.rgb), ToLightness(TexSmplY.rgb), ToLightness(TexSmplZ.rgb) );
      //vec3 BlendMask = vec3(TexSmplX.a, TexSmplY.a, TexSmplZ.a);
        //
        //  Alpha will be Opacity, BlendMask will be a separate sampler2D ?
        //      Opacity & BlendMask could use same slot.
        //      any texture intended for Triplanar won't use Transparency...?
        //

        vec3 Blend = pow(Clamp(Blend_Overlay(BlendMask, abs(Nrm))), vec3(BiasExp));

        if (TEST) {
            //return vec4(Blend.rrr, 1.0);
            //return vec4(Blend.ggg, 1.0);
            //return vec4(Blend.bbb, 1.0);
            //return vec4(Blend, 1.0);

            //TexSmplX.rgb = vec3(ToBrightness(TexSmplX.rgb), 0.0, 0.0);
            //TexSmplY.rgb = vec3(0.0, ToBrightness(TexSmplY.rgb), 0.0);
            //TexSmplZ.rgb = vec3(0.0, 0.0, ToBrightness(TexSmplZ.rgb));

            TexSmplX.rgb = ToBrightness(TexSmplX.rgb) * vec3(1.00, 0.16, 0.16);
            TexSmplY.rgb = ToBrightness(TexSmplY.rgb) * vec3(0.05, 0.93, 0.05);
            TexSmplZ.rgb = ToBrightness(TexSmplZ.rgb) * vec3(0.12, 0.36, 1.00);
        }

        return (TexSmplX*Blend.x  +  TexSmplY*Blend.y  +  TexSmplZ*Blend.z) / SumOf(Blend);
    }
    vec4 Texture_TriPlanar(sampler2D TEX, vec3 Pos, vec3 Nrm, float BiasExp) {return Texture_TriPlanar(TEX, Pos, Nrm, BiasExp, false);} //  Optional Parameter Hack.

    //==========================================================================================================================================================
    vec4 Texture_TriPlanar(sampler2D TexX, sampler2D TexY, sampler2D TexZ,  vec3 Pos, vec3 Nrm, float BiasExp) {
        vec3 Select = step(0.0, Nrm);

        vec2 TexCoordX = mix(vec2(-Pos.z, Pos.y),       Pos.zy       , Select.x);
        vec2 TexCoordY = mix(vec2( Pos.x,-Pos.z),       Pos.xz       , Select.y);
        vec2 TexCoordZ = mix(      Pos.xy       , vec2(-Pos.x, Pos.y), Select.z);

        vec4 TexSmplX = texture(TexX, TexCoordX/textureSize(TexX,0));
        vec4 TexSmplY = texture(TexY, TexCoordY/textureSize(TexY,0));
        vec4 TexSmplZ = texture(TexZ, TexCoordZ/textureSize(TexZ,0));

        vec3 BlendMask = vec3(TexSmplX.a, TexSmplY.a, TexSmplZ.a);

        vec3 Blend = pow(Clamp(Blend_Overlay(BlendMask, abs(Nrm))), vec3(BiasExp)); //  Does this need clamp() ???

        return (TexSmplX*Blend.x  +  TexSmplY*Blend.y  +  TexSmplZ*Blend.z) / SumOf(Blend);
    }

    //==========================================================================================================================================================
    vec4 Texture_TriPlanar(sampler2D TexXn, sampler2D TexXp, sampler2D TexYn, sampler2D TexYp, sampler2D TexZn, sampler2D TexZp,  vec3 Pos, vec3 Nrm, float BiasExp) {
        vec3 Select = step(0.0, Nrm);

        vec2 TexCoordX = mix(vec2(-Pos.z, Pos.y),       Pos.zy       , Select.x);
        vec2 TexCoordY = mix(vec2( Pos.x,-Pos.z),       Pos.xz       , Select.y);
        vec2 TexCoordZ = mix(      Pos.xy       , vec2(-Pos.x, Pos.y), Select.z);

        vec4 TexSmplX = (Select.x < 0.5)  ?  texture(TexXn, TexCoordX/textureSize(TexXn,0))  :  texture(TexXp, TexCoordX/textureSize(TexXp,0));
        vec4 TexSmplY = (Select.y < 0.5)  ?  texture(TexYn, TexCoordY/textureSize(TexYn,0))  :  texture(TexYp, TexCoordY/textureSize(TexYp,0));
        vec4 TexSmplZ = (Select.z < 0.5)  ?  texture(TexZn, TexCoordZ/textureSize(TexZn,0))  :  texture(TexZp, TexCoordZ/textureSize(TexZp,0));

        vec3 BlendMask = vec3(TexSmplX.a, TexSmplY.a, TexSmplZ.a);

        vec3 Blend = pow(Clamp(Blend_Overlay(BlendMask, abs(Nrm))), vec3(BiasExp)); //  Does this need clamp() ???

        return (TexSmplX*Blend.x  +  TexSmplY*Blend.y  +  TexSmplZ*Blend.z) / SumOf(Blend);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
""";}
