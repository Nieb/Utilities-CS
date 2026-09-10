
namespace Utility;
internal static class Random {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  NOTE:  Random is not ThreadSafe...                  https://learn.microsoft.com/en-us/dotnet/api/system.random.shared?view=net-10.0
    //
    //                          *Inclusive*  *Exclusive*
    //      System.Random.Next( LowerBounds, UpperBounds );
    //
    private static readonly System.Random R = new();

  //private static readonly object                ThreadLock = new();
  //private static readonly System.Threading.Lock ThreadLock = new();
    //  https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-9/#threading
    //  https://learn.microsoft.com/en-us/dotnet/api/system.threading.lock?view=net-9.0

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //                  *Inclusive*  *Inclusive*
    //      RandomType( LowerBounds, UpperBounds );
    //
    internal static u8  RandomByte (u8  L=MIN_u8 , u8  U=MAX_u8 ) => ClampToByte (R.NextInt64(s64(L), s64(U)+1)); //(R.Next     (s32(L), s32(U)+1));

    internal static s16 RandomShort(s16 L=MIN_s16, s16 U=MAX_s16) => ClampToShort(R.NextInt64(s64(L), s64(U)+1)); //(R.Next     (s32(L), s32(U)+1));

    internal static s32 RandomInt  (s32 L=MIN_s32, s32 U=MAX_s32) => ClampToInt  (R.NextInt64(s64(L), s64(U)+1));
    internal static u32 RandomUint (u32 L=MIN_u32, u32 U=MAX_u32) => ClampToUint (R.NextInt64(s64(L), s64(U)+1));

    //==========================================================================================================================================================
    //
    //  Fill byte[] array with random values.
    //
    //      byte[] MyArray = new byte[256];
    //      MyArray.Randomize();
    //
    internal static void Randomize(this byte[] A) => R.NextBytes(A);

    //==========================================================================================================================================================
    //
    //      Random1()  == -1.0 to 1.0
    //      Random1u() ==  0.0 to 1.0
    //
    internal static v1 Random1()  => f32(  R.NextInt64(-1_000_000L,1_000_001L) / 1_000_000d  ); //f32(  R.Next(-1_000_000,1_000_001) / 1_000_000f  );
    internal static v1 Random1u() => f32(  R.NextInt64(         0L,1_000_001L) / 1_000_000d  ); //f32(  R.Next(         0,1_000_001) / 1_000_000f  );

    internal static v2 Random2()  => normalize(new vec2(Random1() ,Random1() ));
    internal static v2 Random2u() => normalize(new vec2(Random1u(),Random1u()));

    internal static v3 Random3()  => normalize(new vec3(Random1() ,Random1() ,Random1() ));
    internal static v3 Random3u() => normalize(new vec3(Random1u(),Random1u(),Random1u()));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Pitch  |  RotX  |  PosY  |  TexV  |   Latitude (South  –90   +90  North)
    //  Yaw    |  RotY  |  PosX  |  TexU  |  Longitude (West  -180  +180  East )
    //
    /*
    internal static vec3 Random3a() {
        float Pch = Random1() * PIH;
        float Yaw = Random1() * PI;

        //  Bias away from poles to get an even distribution:
        Pch = asin(Pch);

        float CosPch = cos(Pch);

        return normalize(new vec3(
             CosPch * sin(Yaw),
                     -sin(Pch),
            -CosPch * cos(Yaw)
        ));
    }
    */

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
