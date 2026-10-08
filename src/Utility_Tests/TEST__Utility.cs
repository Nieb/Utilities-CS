using CompilerServices = System.Runtime.CompilerServices;
using InteropServices  = System.Runtime.InteropServices;

namespace UtilityTest;
internal static partial class Program {
    static void Test__Utility() {
        TESTOUT("\n[Utility]");

        //######################################################################################################################################################
        //######################################################################################################################################################
        //
        //      System.Runtime.CompilerServices.Unsafe.SizeOf<T>()   determines the size in managed .NET memory
        //      System.Runtime.InteropServices.Marshal.SizeOf<T>()   determines the size for unmanaged memory interoperability (P/Invoke)
        //
        //======================================================================================================================================================
        TEST("bool is 1-ish bytes", sizeof(bool) == 1  &&  CompilerServices.Unsafe.SizeOf<bool>() == 1
            #if DEBUG
                &&  InteropServices.Marshal.SizeOf<bool>() == 4
            #else
                &&  InteropServices.Marshal.SizeOf<bool>() == 1
            #endif
        );

        //======================================================================================================================================================
        TEST("f16 is 2 bytes",                       CompilerServices.Unsafe.SizeOf<f16>() == 2  &&  InteropServices.Marshal.SizeOf<f16>() == 2);
        TEST("f32 is 4 bytes", sizeof(f32) == 4  &&  CompilerServices.Unsafe.SizeOf<f32>() == 4  &&  InteropServices.Marshal.SizeOf<f32>() == 4);
        TEST("f64 is 8 bytes", sizeof(f64) == 8  &&  CompilerServices.Unsafe.SizeOf<f64>() == 8  &&  InteropServices.Marshal.SizeOf<f64>() == 8);

        TEST(" s8 is 1 byte",  sizeof( s8) == 1  &&  CompilerServices.Unsafe.SizeOf< s8>() == 1  &&  InteropServices.Marshal.SizeOf< s8>() == 1);
        TEST("s16 is 2 bytes", sizeof(s16) == 2  &&  CompilerServices.Unsafe.SizeOf<s16>() == 2  &&  InteropServices.Marshal.SizeOf<s16>() == 2);
        TEST("s32 is 4 bytes", sizeof(s32) == 4  &&  CompilerServices.Unsafe.SizeOf<s32>() == 4  &&  InteropServices.Marshal.SizeOf<s32>() == 4);
        TEST("s64 is 8 bytes", sizeof(s64) == 8  &&  CompilerServices.Unsafe.SizeOf<s64>() == 8  &&  InteropServices.Marshal.SizeOf<s64>() == 8);

        TEST(" u8 is 1 byte",  sizeof( u8) == 1  &&  CompilerServices.Unsafe.SizeOf< u8>() == 1  &&  InteropServices.Marshal.SizeOf< u8>() == 1);
        TEST("u16 is 2 bytes", sizeof(u16) == 2  &&  CompilerServices.Unsafe.SizeOf<u16>() == 2  &&  InteropServices.Marshal.SizeOf<u16>() == 2);
        TEST("u32 is 4 bytes", sizeof(u32) == 4  &&  CompilerServices.Unsafe.SizeOf<u32>() == 4  &&  InteropServices.Marshal.SizeOf<u32>() == 4);
        TEST("u64 is 8 bytes", sizeof(u64) == 8  &&  CompilerServices.Unsafe.SizeOf<u64>() == 8  &&  InteropServices.Marshal.SizeOf<u64>() == 8);

        //======================================================================================================================================================
        TEST(" vec2 is  8 bytes", CompilerServices.Unsafe.SizeOf< vec2>() ==  8  &&  InteropServices.Marshal.SizeOf< vec2>() ==  8);
        TEST("ivec2 is  8 bytes", CompilerServices.Unsafe.SizeOf<ivec2>() ==  8  &&  InteropServices.Marshal.SizeOf<ivec2>() ==  8);

        TEST(" vec3 is 12 bytes", CompilerServices.Unsafe.SizeOf< vec3>() == 12  &&  InteropServices.Marshal.SizeOf< vec3>() == 12);
        TEST("ivec3 is 12 bytes", CompilerServices.Unsafe.SizeOf<ivec3>() == 12  &&  InteropServices.Marshal.SizeOf<ivec3>() == 12);

        TEST(" vec4 is 16 bytes", CompilerServices.Unsafe.SizeOf< vec4>() == 16  &&  InteropServices.Marshal.SizeOf< vec4>() == 16);
        TEST("ivec4 is 16 bytes", CompilerServices.Unsafe.SizeOf<ivec4>() == 16  &&  InteropServices.Marshal.SizeOf<ivec4>() == 16);

        //======================================================================================================================================================
        TEST("bvec4 is  4 bytes", CompilerServices.Unsafe.SizeOf<bvec4>() ==  4  &&  InteropServices.Marshal.SizeOf<bvec4>() ==  4);
        TEST("bvec8 is  8 bytes", CompilerServices.Unsafe.SizeOf<bvec8>() ==  8  &&  InteropServices.Marshal.SizeOf<bvec8>() ==  8);

        //======================================================================================================================================================
        TEST(" mat2 is 16 bytes", CompilerServices.Unsafe.SizeOf< mat2>() == 16  &&  InteropServices.Marshal.SizeOf< mat2>() == 16);
        TEST(" mat3 is 36 bytes", CompilerServices.Unsafe.SizeOf< mat3>() == 36  &&  InteropServices.Marshal.SizeOf< mat3>() == 36);
        TEST(" mat4 is 64 bytes", CompilerServices.Unsafe.SizeOf< mat4>() == 64  &&  InteropServices.Marshal.SizeOf< mat4>() == 64);

        //======================================================================================================================================================
        TEST("Data32 is 4 bytes", InteropServices.Marshal.SizeOf<Data32>() == 4);
        TEST("Data64 is 8 bytes", InteropServices.Marshal.SizeOf<Data64>() == 8);

        //======================================================================================================================================================
        #if false
            TESTOUT($"""
                Tuples appear to use 8 byte packing.  Alignment as well?

                                                     (int,int) is {CompilerServices.Unsafe.SizeOf<(int,int)            >(),3} bytes
                                                 (int,int,int) is {CompilerServices.Unsafe.SizeOf<(int,int,int)        >(),3} bytes
                                             (int,int,int,int) is {CompilerServices.Unsafe.SizeOf<(int,int,int,int)    >(),3} bytes
                                         (int,int,int,int,int) is {CompilerServices.Unsafe.SizeOf<(int,int,int,int,int)>(),3} bytes

                                                 (float,float) is {CompilerServices.Unsafe.SizeOf<(float,float)                  >(),3} bytes
                                           (float,float,float) is {CompilerServices.Unsafe.SizeOf<(float,float,float)            >(),3} bytes
                                     (float,float,float,float) is {CompilerServices.Unsafe.SizeOf<(float,float,float,float)      >(),3} bytes
                               (float,float,float,float,float) is {CompilerServices.Unsafe.SizeOf<(float,float,float,float,float)>(),3} bytes

                Well, they use 8 byte packing after the first 4.

                                                 (short,short) is {CompilerServices.Unsafe.SizeOf<(short,short)                  >(),3} bytes
                                           (short,short,short) is {CompilerServices.Unsafe.SizeOf<(short,short,short)            >(),3} bytes
                                     (short,short,short,short) is {CompilerServices.Unsafe.SizeOf<(short,short,short,short)      >(),3} bytes
                               (short,short,short,short,short) is {CompilerServices.Unsafe.SizeOf<(short,short,short,short,short)>(),3} bytes

                                                   (byte,byte) is {CompilerServices.Unsafe.SizeOf<(byte,byte)               >(),3} bytes
                                              (byte,byte,byte) is {CompilerServices.Unsafe.SizeOf<(byte,byte,byte)          >(),3} bytes
                                         (byte,byte,byte,byte) is {CompilerServices.Unsafe.SizeOf<(byte,byte,byte,byte)     >(),3} bytes
                                    (byte,byte,byte,byte,byte) is {CompilerServices.Unsafe.SizeOf<(byte,byte,byte,byte,byte)>(),3} bytes
                (byte,byte,byte,byte,byte,byte,byte,byte,byte) is {CompilerServices.Unsafe.SizeOf<(byte,byte,byte,byte,byte,byte,byte,byte,byte)>(),3} bytes    (9 bytes)
            """);
            /*
                {InteropServices.Marshal.SizeOf<I3>()}
                {InteropServices.Marshal.SizeOf<F4>()}
            */
        #endif
        #if false
            TESTOUT($"""
                                   bool: {sizeof(bool  ),2} bytes

                                                             sizeof(bool):  {sizeof(bool)}    {sizeof(bool) == 1}
                                   CompilerServices.Unsafe.SizeOf<bool>():  {CompilerServices.Unsafe.SizeOf<bool>()}    {CompilerServices.Unsafe.SizeOf<bool>() == 1}
                                   InteropServices.Marshal.SizeOf<bool>():  {InteropServices.Marshal.SizeOf<bool>()}    {InteropServices.Marshal.SizeOf<bool>() == 4}

                                  sbyte: {sizeof(sbyte ),2} bytes       byte: {sizeof(byte  ),2} bytes
                                  short: {sizeof(short ),2} bytes     ushort: {sizeof(ushort),2} bytes
                                    int: {sizeof(int   ),2} bytes       uint: {sizeof(uint  ),2} bytes
                                   long: {sizeof(long  ),2} bytes      ulong: {sizeof(ulong ),2} bytes

                                  float: {sizeof(float ),2} bytes
                                 double: {sizeof(double),2} bytes

                System.Numerics.Vector2: {InteropServices.Marshal.SizeOf<System.Numerics.Vector2>(),2} bytes
                System.Numerics.Vector3: {InteropServices.Marshal.SizeOf<System.Numerics.Vector3>(),2} bytes
                System.Numerics.Vector4: {InteropServices.Marshal.SizeOf<System.Numerics.Vector4>(),2} bytes

                System.Numerics.Matrix4: {InteropServices.Marshal.SizeOf<System.Numerics.Matrix4x4>(),2} bytes
            """);
        #endif
        #if false
            TESTOUT($"""
                vec2 is {InteropServices.Marshal.SizeOf<vec2>()} bytes
                vec3 is {InteropServices.Marshal.SizeOf<vec3>()} bytes
                vec4 is {InteropServices.Marshal.SizeOf<vec4>()} bytes

                mat2 is {InteropServices.Marshal.SizeOf<mat2>()} bytes
                mat3 is {InteropServices.Marshal.SizeOf<mat3>()} bytes
                mat4 is {InteropServices.Marshal.SizeOf<mat4>()} bytes

                Data32 is {InteropServices.Marshal.SizeOf<Data32>()} bytes
                Data64 is {InteropServices.Marshal.SizeOf<Data64>()} bytes
            """);
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            Data32[] A = [
                 123.456f,
                -123.456f,
                 123456789,
                -123456789,
                 0xFF00_0000u,
            ];

            TEST("Data32",true
                && A[0] ==  123.456f
                && A[1] == -123.456f
                && A[2] ==  123456789
                && A[3] == -123456789
                && A[4] ==  0xFF00_0000u
            );
        }

        //======================================================================================================================================================
        {
            Data64[] A = [
                 123456.789123d,
                -123456.789123d,
                 123456789123456789L,
                -123456789123456789L,
                 0xFF00_0000_0000_0000ul,
            ];

            TEST("Data64",true
                && A[0] ==  123456.789123d
                && A[1] == -123456.789123d
                && A[2] ==  123456789123456789L
                && A[3] == -123456789123456789L
                && A[4] ==  0xFF00_0000_0000_0000ul
            );
        }

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            DataArray A = new DataArray(256);
            //DataArray B = new DataArray(256);

            for (int i = 0; i < 64; ++i) {A.u32[i] = (uint)i;}

            //var View = B.f32;
            //for (int i = 0; i < 64; ++i) {View[i] = (float)i;}

            TEST("DataArray",true
                &&  A.u64[ 0]==0x_0000_0001_0000_0000  &&  A.u32[ 0]== 0  &&  A.u16[ 0]== 0  &&  A.u8[ 0]== 0
                &&  A.u64[ 6]==0x_0000_000D_0000_000C  &&  A.u32[12]==12  &&  A.u16[12]== 6  &&  A.u8[12]== 3
                &&  A.u64[12]==0x_0000_0019_0000_0018  &&  A.u32[24]==24  &&  A.u16[24]==12  &&  A.u8[24]== 6
                &&  A.u64[18]==0x_0000_0025_0000_0024  &&  A.u32[36]==36  &&  A.u16[36]==18  &&  A.u8[36]== 9
                &&  A.u64[24]==0x_0000_0031_0000_0030  &&  A.u32[48]==48  &&  A.u16[48]==24  &&  A.u8[48]==12

                && A. u8.Length == 256
                && A.u16.Length == 128
                && A.u32.Length ==  64
                && A.u64.Length ==  32

                //&& B.f32[ 0] ==  0f
                //&& B.f32[12] == 12f
                //&& B.f32[24] == 24f
                //&& B.f32[36] == 36f
                //&& B.f32[48] == 48f
                //&& B. s8.Length == 256
                //&& B.f16.Length == 128
                //&& B.f32.Length ==  64
                //&& B.f64.Length ==  32
            );
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------
        #if false
        {
            const int SIZE = 1024; //88_000;
            const int LEN  = SIZE/4;
            long t1a = 0, t2a = 0, t3a = 0, t4a = 0,
                 t1b = 0, t2b = 0, t3b = 0, t4b = 0;


            System.GC.Collect();  System.GC.WaitForPendingFinalizers();


            t4a = System.Diagnostics.Stopwatch.GetTimestamp();
            DataArray A = new DataArray(SIZE);
            DataArray B = new DataArray(SIZE);
            t4b = System.Diagnostics.Stopwatch.GetTimestamp();


            System.GC.Collect();  System.GC.WaitForPendingFinalizers();


            t3a = System.Diagnostics.Stopwatch.GetTimestamp();
            var View = B.u32;                                   //  Creating this takes 4000~ cycles...     Regardless of DataArray size.
            t3b = System.Diagnostics.Stopwatch.GetTimestamp();


            System.GC.Collect();  System.GC.WaitForPendingFinalizers();


            t1a = System.Diagnostics.Stopwatch.GetTimestamp();
            for (int i = 0; i < LEN; ++i) {A.u32[i] = (uint)i;}
            t1b = System.Diagnostics.Stopwatch.GetTimestamp();


            System.GC.Collect();  System.GC.WaitForPendingFinalizers();


            t2a = System.Diagnostics.Stopwatch.GetTimestamp();
            for (int i = 0; i < LEN; ++i) {View[i] = (uint)i;}
            t2b = System.Diagnostics.Stopwatch.GetTimestamp();


            System.GC.Collect();  System.GC.WaitForPendingFinalizers();

            double Frequency = (double)System.Diagnostics.Stopwatch.Frequency;

            TESTOUT($"""
                Stopwatch.Frequency        {CommaDelimit(System.Diagnostics.Stopwatch.Frequency)}
                Stopwatch.IsHighResolution {System.Diagnostics.Stopwatch.IsHighResolution}

                DataArray(SIZE) {t4b-t4a,5} cycles    {(t4b-t4a)/Frequency,5:F9}

                       A.u32[i] {t1b-t1a,5} cycles    {(t1b-t1a)/Frequency,5:F9}

                        View[i] {t2b-t2a,5} cycles    {(t2b-t2a)/Frequency,5:F9}
                  View = B.u32; {t3b-t3a,5} cycles    {(t3b-t3a)/Frequency,5:F9}
                          total {t2b-t2a + t3b-t3a,5} cycles    {(t2b-t2a + t3b-t3a)/Frequency,5:F9}
            """);


            TEST("___DataArray___",true
                && A.u32[ 0] ==  0  &&  A.u16[ 0] ==  0  &&  A.u8[ 0] ==  0  &&  A.u64[ 0] == 0x_0000_0001_0000_0000
                && A.u32[12] == 12  &&  A.u16[12] ==  6  &&  A.u8[12] ==  3  &&  A.u64[ 6] == 0x_0000_000D_0000_000C
                && A.u32[24] == 24  &&  A.u16[24] == 12  &&  A.u8[24] ==  6  &&  A.u64[12] == 0x_0000_0019_0000_0018
                && A.u32[36] == 36  &&  A.u16[36] == 18  &&  A.u8[36] ==  9  &&  A.u64[18] == 0x_0000_0025_0000_0024
                && A.u32[48] == 48  &&  A.u16[48] == 24  &&  A.u8[48] == 12  &&  A.u64[24] == 0x_0000_0031_0000_0030
                && A. u8.Length == SIZE
                && A.u16.Length == SIZE/2
                && A.u32.Length == SIZE/4
                && A.u64.Length == SIZE/8

                && B.u32[ 0] ==  0  &&  B.u16[ 0] ==  0  &&  B.u8[ 0] ==  0  &&  B.u64[ 0] == 0x_0000_0001_0000_0000
                && B.u32[12] == 12  &&  B.u16[12] ==  6  &&  B.u8[12] ==  3  &&  B.u64[ 6] == 0x_0000_000D_0000_000C
                && B.u32[24] == 24  &&  B.u16[24] == 12  &&  B.u8[24] ==  6  &&  B.u64[12] == 0x_0000_0019_0000_0018
                && B.u32[36] == 36  &&  B.u16[36] == 18  &&  B.u8[36] ==  9  &&  B.u64[18] == 0x_0000_0025_0000_0024
                && B.u32[48] == 48  &&  B.u16[48] == 24  &&  B.u8[48] == 12  &&  B.u64[24] == 0x_0000_0031_0000_0030
                && B. u8.Length == SIZE
                && B.u16.Length == SIZE/2
                && B.u32.Length == SIZE/4
                && B.u64.Length == SIZE/8
            );
        }
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
        #if false
            TESTOUT($"""

                {BitCast_ToF32(0x3EAAAAABu):F98}
                {ONE_THIRD:F98}

                {IntToBinaryString(0x3EAAAAABu)}
                {IntToBinaryString(BitCast_ToU32(ONE_THIRD))}


                {BitCast_ToF32(0x3F2AAAABu):F98}
                {TWO_THIRD:F98}
                {IntToBinaryString(0x3F2AAAABu)}
                {IntToBinaryString(BitCast_ToU32(TWO_THIRD))}



                {0.000000000000123456f:F98}
            """);
            /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                TESTOUT($"""
                    ...
                    {BitCast_ToF32(0x3EAAAAABu):F98}
                    {ONE_THIRD:F98}

                    {IntToBinaryString(0x3EAAAAABu)}
                    {IntToBinaryString(BitCast_ToU32(ONE_THIRD))}
                    ...
                """);

                    0.33333334326744079589843750000000000000000000000000000000000000000000000000000000000000000000000000
                    0.33333334326744079589843750000000000000000000000000000000000000000000000000000000000000000000000000

                    00111110_10101010_10101010_10101011
                                                                                wtf?    where did this newline come from???    only happens with full TESTOUT() from above...
                    00111110_10101010_10101010_10101011

            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                TESTOUT($"""
                    ...
                    {BitCast_ToF32(0x3EAAAAABu):F98}
                    {ONE_THIRD:F98}
                    {IntToBinaryString(0x3EAAAAABu)}
                    {IntToBinaryString(BitCast_ToU32(ONE_THIRD))}
                    ...
                """);

                    0.33333334326744079589843750000000000000000000000000000000000000000000000000000000000000000000000000
                    0.33333334326744079589843750000000000000000000000000000000000000000000000000000000000000000000000000
                    00111110_10101010_10101010_10101011
                    00111110_10101010_10101010_10101011

            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        #endif

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            uint A = 0b_10101010_10101010_10101010_10101010u;
            uint B = 0b_11001100_11001100_11001100_11001100u;
            uint C = 0b_10001000_10001000_10001000_10001000u;
            uint D = 0b_11111111_00000000_11111111_00000000u;

            TEST("BitFlip(uint)",true
                && BitFlip(BitFlip(A)) == A
                && BitFlip(BitFlip(B)) == B
                && BitFlip(BitFlip(C)) == C
                && BitFlip(BitFlip(D)) == D
            );

            bvec4 vA = A;
            bvec4 vB = B;
            bvec4 vC = C;
            bvec4 vD = D;

            TEST("ByteFlip(bvec4)",true
                && ByteFlip(ByteFlip(A)) == A
                && ByteFlip(ByteFlip(B)) == B
                && ByteFlip(ByteFlip(C)) == C
                && ByteFlip(ByteFlip(D)) == D

                && ByteFlip(ByteFlip(vA)) == vA
                && ByteFlip(ByteFlip(vB)) == vB
                && ByteFlip(ByteFlip(vC)) == vC
                && ByteFlip(ByteFlip(vD)) == vD
            );
        }

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
