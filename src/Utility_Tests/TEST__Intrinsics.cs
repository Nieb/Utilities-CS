using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace UtilityTest;
internal static partial class Program {
    static void Test__Intrinsics() {
            TESTOUT($"""

            [Intrinsics]
                 Vector64.IsHardwareAccelerated: {System.Runtime.Intrinsics.Vector64.IsHardwareAccelerated}
                Vector128.IsHardwareAccelerated: {System.Runtime.Intrinsics.Vector128.IsHardwareAccelerated}
                Vector256.IsHardwareAccelerated: {System.Runtime.Intrinsics.Vector256.IsHardwareAccelerated}
                Vector512.IsHardwareAccelerated: {System.Runtime.Intrinsics.Vector512.IsHardwareAccelerated}

                     X86Base: {X86Base      .IsSupported,-5}  X64: {X86Base      .X64.IsSupported}

                         SSE: {Sse          .IsSupported,-5}  X64: {Sse          .X64.IsSupported}
                        SSE2: {Sse2         .IsSupported,-5}  X64: {Sse2         .X64.IsSupported} ***   Up to "SSE2" is guaranteed for all x86-64 CPUs
                        SSE3: {Sse3         .IsSupported,-5}  X64: {Sse3         .X64.IsSupported}
                       SSSE3: {Ssse3        .IsSupported,-5}  X64: {Ssse3        .X64.IsSupported}
                       SSE41: {Sse41        .IsSupported,-5}  X64: {Sse41        .X64.IsSupported}
                       SSE42: {Sse42        .IsSupported,-5}  X64: {Sse42        .X64.IsSupported}

                        Avx : {Avx          .IsSupported,-5}  X64: {Avx          .X64.IsSupported}
                        Avx2: {Avx2         .IsSupported,-5}  X64: {Avx2         .X64.IsSupported}

                 Avx512 BW  : {Avx512BW     .IsSupported,-5}  X64: {Avx512BW     .X64.IsSupported,-5}  VL: {Avx512BW       .VL.IsSupported}
                 Avx512 CD  : {Avx512CD     .IsSupported,-5}  X64: {Avx512CD     .X64.IsSupported,-5}  VL: {Avx512CD       .VL.IsSupported}
                 Avx512 DQ  : {Avx512DQ     .IsSupported,-5}  X64: {Avx512DQ     .X64.IsSupported,-5}  VL: {Avx512DQ       .VL.IsSupported}
                 Avx512 F   : {Avx512F      .IsSupported,-5}  X64: {Avx512F      .X64.IsSupported,-5}  VL: {Avx512F        .VL.IsSupported}
                 Avx512 Vbmi: {Avx512Vbmi   .IsSupported,-5}  X64: {Avx512Vbmi   .X64.IsSupported,-5}  VL: {Avx512Vbmi     .VL.IsSupported}

            """);
        #if false
            TESTOUT($"""
                     Avx10v1: {Avx10v1      .IsSupported,-5}  X64: {Avx10v1      .X64.IsSupported}
                Avx10v1.V512: {Avx10v1.V512 .IsSupported,-5}  X64: {Avx10v1.V512 .X64.IsSupported}

                     AvxVnni: {AvxVnni      .IsSupported,-5}  X64: {AvxVnni      .X64.IsSupported}

            """);
        #endif
        #if true
            TESTOUT($"""
                         Aes: {Aes          .IsSupported,-5}  X64: {Aes          .X64.IsSupported}

                        Bmi1: {Bmi1         .IsSupported,-5}  X64: {Bmi1         .X64.IsSupported}
                        Bmi2: {Bmi2         .IsSupported,-5}  X64: {Bmi2         .X64.IsSupported}

                         Fma: {Fma          .IsSupported,-5}  X64: {Fma          .X64.IsSupported}

                       Lzcnt: {Lzcnt        .IsSupported,-5}  X64: {Lzcnt        .X64.IsSupported}

                   Pclmulqdq: {Pclmulqdq    .IsSupported,-5}  X64: {Pclmulqdq    .X64.IsSupported}

                      Popcnt: {Popcnt       .IsSupported,-5}  X64: {Popcnt       .X64.IsSupported}

                X86Serialize: {X86Serialize .IsSupported,-5}  X64: {X86Serialize .X64.IsSupported}

            """);
        #endif
    }
}
