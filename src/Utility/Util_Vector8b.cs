
namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct bvec8 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(7)] public u8 b0;
    [FieldOffset(6)] public u8 b1;    [FieldOffset(6)] public u16 s0;
    [FieldOffset(5)] public u8 b2;
    [FieldOffset(4)] public u8 b3;    [FieldOffset(4)] public u16 s1;    [FieldOffset(4)] public u32 i0;
    [FieldOffset(3)] public u8 b4;
    [FieldOffset(2)] public u8 b5;    [FieldOffset(2)] public u16 s2;
    [FieldOffset(1)] public u8 b6;
    [FieldOffset(0)] public u8 b7;    [FieldOffset(0)] public u16 s3;    [FieldOffset(0)] public u32 i1;    [FieldOffset(0)] private u64 L;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] public bvec8() {}
    [In(line)] public bvec8(u64 V)                                          {L=V;}
    [In(line)] public bvec8(u32 A, u32 B)                                   {i0=A; i1=B;}
    [In(line)] public bvec8(u16 A, u16 B, u16 C, u16 D)                     {s0=A; s1=B; s2=C; s3=D;}
    [In(line)] public bvec8(u8 A, u8 B, u8 C, u8 D, u8 E, u8 F, u8 G, u8 H) {b0=A; b1=B; b2=C; b3=D; b4=E; b5=F; b6=G; b7=H;}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [In(line)] public static implicit operator   u64(bvec8 A) => A.L;               //  bvec8  to  ulong
    [In(line)] public static implicit operator bvec8(u64   A) => new bvec8(A);      //  ulong  to  bvec8

  //[In(line)] public static implicit operator bvec8((u32 a, u32 b)                                   T) => new bvec8(T.a,T.b);
  //[In(line)] public static implicit operator bvec8((u16 a, u16 b, u16 c, u16 d)                     T) => new bvec8(T.a,T.b,T.c,T.d);
  //[In(line)] public static implicit operator bvec8((u8 a, u8 b, u8 c, u8 d, u8 e, u8 f, u8 g, u8 h) T) => new bvec8(T.a,T.b,T.c,T.d,T.e,T.f,T.g,T.h);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
