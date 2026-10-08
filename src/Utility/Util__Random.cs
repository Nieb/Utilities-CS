
namespace Utility;
internal static class Random {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //                   *Inclusive*  *Exclusive*
    //           R.Next( LowerBounds, UpperBounds );
    //      R.NextInt64( LowerBounds, UpperBounds );        Upon testing, ".NextInt64()" seems to be a bit faster than ".Next()".
    //
    //     R.NextSingle();      These have bias issues.
    //     R.NextDouble();      Also, not inclusive of "1.0".
    //
  //private static readonly System.Random R = new(); //  Not ThreadSafe...
    private static readonly System.Random R = System.Random.Shared;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                   Random Integer
    //                  *Inclusive*  *Inclusive*
    //      RandomType( LowerBounds, UpperBounds );
    //
    [In(line)] internal static u8  RandomByte (u8  L=MIN_u8 , u8  U=MAX_u8 ) =>  u8(R.NextInt64(s64(L), s64(U)+1));

    [In(line)] internal static s16 RandomShort(s16 L=MIN_s16, s16 U=MAX_s16) => s16(R.NextInt64(s64(L), s64(U)+1));

    [In(line)] internal static s32 RandomInt  (s32 L=MIN_s32, s32 U=MAX_s32) => s32(R.NextInt64(s64(L), s64(U)+1));
    [In(line)] internal static u32 RandomUint (u32 L=MIN_u32, u32 U=MAX_u32) => u32(R.NextInt64(s64(L), s64(U)+1));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                   Random Bytes
    //  Fill byte[] array with random values.
    //
    //      byte[] MyArray = new byte[256];
    //      MyArray.Randomize();
    //
    [In(line)] internal static void Randomize(this byte[] A) => R.NextBytes(A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                   Random Float32
    //  NOTE:  Vectors are not normalized.
    //         If normalized, they will bias towards diagonals.
    //
    //       Random1() ==  -1.###_###  to  1.###_###
    //      Random1u() ==   0.###_###  to  1.###_###
    //
    [In(line)] internal static v1 Random1()  => f32(  R.NextInt64(-1_000_000L,1_000_001L)/1_000_000d  );
    [In(line)] internal static v1 Random1u() => f32(  R.NextInt64(         0L,1_000_001L)/1_000_000d  );

    [In(line)] internal static v2 Random2()  => new vec2( Random1(), Random1());
    [In(line)] internal static v2 Random2u() => new vec2(Random1u(),Random1u());

    [In(line)] internal static v3 Random3()  => new vec3( Random1(), Random1(), Random1());
    [In(line)] internal static v3 Random3u() => new vec3(Random1u(),Random1u(),Random1u());

    [In(line)] internal static v4 Random4()  => new vec4( Random1(), Random1(), Random1(), Random1());
    [In(line)] internal static v4 Random4u() => new vec4(Random1u(),Random1u(),Random1u(),Random1u());

    //==========================================================================================================================================================
    //
    //  NOTE:  Vectors are not normalized.
    //         If normalized, they will bias towards diagonals.
    //
    //       Random1(  10)  ==    -10.###_##  to    10.###_##
    //       Random1( 100)  ==   -100.###_#   to   100.###_#
    //       Random1(1000)  ==  -1000.###     to  1000.###
    //
    //      Random1u(1000)  ==      0.###     to  1000.###
    //
    [In(line)] internal static v1 Random1( uint Domain) => f32(  R.NextInt64(-1_000_000L,1_000_001L)/(1_000_000d/Domain)  );
    [In(line)] internal static v1 Random1u(uint Domain) => f32(  R.NextInt64(         0L,1_000_001L)/(1_000_000d/Domain)  );

    [In(line)] internal static v2 Random2( uint D) => new vec2( Random1(D), Random1(D));
    [In(line)] internal static v2 Random2u(uint D) => new vec2(Random1u(D),Random1u(D));

    [In(line)] internal static v3 Random3( uint D) => new vec3( Random1(D), Random1(D), Random1(D));
    [In(line)] internal static v3 Random3u(uint D) => new vec3(Random1u(D),Random1u(D),Random1u(D));

    [In(line)] internal static v4 Random4( uint D) => new vec4( Random1(D), Random1(D), Random1(D), Random1(D));
    [In(line)] internal static v4 Random4u(uint D) => new vec4(Random1u(D),Random1u(D),Random1u(D),Random1u(D));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                              Random Normalized Vector
    //
    //  Pitch  |  RotX  |  PosY  |  TexV  |   Latitude (South  –90   +90  North)
    //  Yaw    |  RotY  |  PosX  |  TexU  |  Longitude (West  -180  +180  East )
    //
    //==========================================================================================================================================================
    internal static v2 Random2n() {
        float Theta = Random1() * PI;
        return new vec2(cos(Theta), sin(Theta));
    }

    //==========================================================================================================================================================
    internal static vec3 Random3n() {
        float Y = Random1();
        float R = sqrt(1f - Y*Y); //  Radius of the circle at height Y.

        float Yaw = Random1() * PI;
        (float SinYaw, float CosYaw) = sincos(Yaw);

        return new vec3(R*SinYaw,  Y,  R*CosYaw); //  By projecting Y on to Sphere via R, pole-bias is canceled out.
    }
    /*internal static vec3 Random3n() {
        float Pch = asin(Random1()); //  Bias away from poles to get an even distribution.
        float Yaw = Random1() * PI;
        (float SinPch, float CosPch) = sincos(Pch);
        (float SinYaw, float CosYaw) = sincos(Yaw);
        return normalize(CosPch*SinYaw,  -SinPch,  -CosPch*CosYaw);
    }*/

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  "Domain" is normalized.
    //      "DomainPch" (-1 to 1) --> (-PIH to PIH)
    //      "DomainYaw" (-1 to 1) --> (-PI  to PI )   Negation effectively does nothing.
    //
    internal static vec3 Random3n(float DomainPch, float DomainYaw) {
        float Y = Random1()*DomainPch;
        float R = sqrt(1f - Y*Y);

        float Yaw = Random1()*DomainYaw * PI;
        (float SinYaw, float CosYaw) = sincos(Yaw);

        #if Z_UP
            return new vec3(R*SinYaw,  R*CosYaw,  Y);
        #else
            return new vec3(R*SinYaw,  Y,  R*CosYaw);
        #endif
    }

    //==========================================================================================================================================================
    //
    //  As it turns out, there are some practical applications for this...
    //  It's not just maths wankery, I promise!
    //
    internal static vec4 Random4n() {
        float r1 = sqrt(Random1u());
        float Theta1 = Random1() * PI;
        float X = r1 * cos(Theta1);
        float Y = r1 * sin(Theta1);

        float r2 = sqrt(Random1u());
        float Theta2 = Random1() * PI;
        float Z = r2 * cos(Theta2);
        float W = r2 * sin(Theta2);

        float Scale = sqrt((1f - r1*r1) / (r2*r2));

        return new vec4(X, Y, Z*Scale, W*Scale);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
