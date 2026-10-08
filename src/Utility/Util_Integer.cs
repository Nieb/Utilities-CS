
namespace Utility;
internal static class INT {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Absolute" Value
    //  NOTE:  Does not check for overflow.    -(-2_147_483_648)
    //
    [In(line)] internal static  s8 abs( s8 A) =>  s8((A >= 0) ? A : -A);
    [In(line)] internal static s16 abs(s16 A) => s16((A >= 0) ? A : -A);
    [In(line)] internal static s32 abs(s32 A) =>     (A >= 0) ? A : -A;
    [In(line)] internal static s64 abs(s64 A) =>     (A >= 0) ? A : -A;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Clamp"
    //                *Inclusive*  *Inclusive*
    //      clamp( A, LowerBounds, UpperBounds )
    //
#if false
    [In(line)] internal static s32 clamp(s32 A, s32 L, s32 U) => (A < L) ? L : (A > U) ? U : A;
    [In(line)] internal static u32 clamp(u32 A, u32 L, u32 U) => (A < L) ? L : (A > U) ? U : A;

    [In(line)] internal static s64 clamp(s64 A, s64 L, s64 U) => (A < L) ? L : (A > U) ? U : A;
    [In(line)] internal static u64 clamp(u64 A, u64 L, u64 U) => (A < L) ? L : (A > U) ? U : A;
#else
    [In(line)] internal static s32 clamp(s32 A, s32 L, s32 U) => System.Math.Clamp(A,L,U);
    [In(line)] internal static u32 clamp(u32 A, u32 L, u32 U) => System.Math.Clamp(A,L,U);

    [In(line)] internal static s64 clamp(s64 A, s64 L, s64 U) => System.Math.Clamp(A,L,U);
    [In(line)] internal static u64 clamp(u64 A, u64 L, u64 U) => System.Math.Clamp(A,L,U);
#endif

    [In(line)] internal static i2 clamp(i2 A, i1 L, i1 U) => new i2(clamp(A.x,L  ,U  ), clamp(A.y,L  ,U  ));
    [In(line)] internal static i2 clamp(i2 A, i2 L, i2 U) => new i2(clamp(A.x,L.x,U.x), clamp(A.y,L.y,U.y));
    [In(line)] internal static i3 clamp(i3 A, i1 L, i1 U) => new i3(clamp(A.x,L  ,U  ), clamp(A.y,L  ,U  ), clamp(A.z,L  ,U  ));
    [In(line)] internal static i3 clamp(i3 A, i3 L, i3 U) => new i3(clamp(A.x,L.x,U.x), clamp(A.y,L.y,U.y), clamp(A.z,L.z,U.z));
    [In(line)] internal static i4 clamp(i4 A, i1 L, i1 U) => new i4(clamp(A.x,L  ,U  ), clamp(A.y,L  ,U  ), clamp(A.z,L  ,U  ), clamp(A.w,L  ,U  ));
    [In(line)] internal static i4 clamp(i4 A, i4 L, i4 U) => new i4(clamp(A.x,L.x,U.x), clamp(A.y,L.y,U.y), clamp(A.z,L.z,U.z), clamp(A.w,L.w,U.w));

    //==========================================================================================================================================================
    //                                                                       "Wrap"
    //               *Inclusive*  *Exclusive*
    //      wrap( A, LowerBounds, UpperBounds )
    //      wrap( A,              UpperBounds )     LowerBounds is 0
    //
    [In(line)] internal static s16 wrap(s16 A, s16 L, s16 U) {s32 Domain = U-L;  s32 R = s16((A-L) % Domain);  return s16(R+L + ((R < 0) ? Domain : 0));}
    [In(line)] internal static s32 wrap(s32 A, s32 L, s32 U) {s32 Domain = U-L;  s32 R =     (A-L) % Domain;   return     R+L + ((R < 0) ? Domain : 0);}
    [In(line)] internal static s64 wrap(s64 A, s64 L, s64 U) {s64 Domain = U-L;  s64 R =     (A-L) % Domain;   return     R+L + ((R < 0) ? Domain : 0);}

    [In(line)] internal static s16 wrap(s16 A,        s16 U) {                   s16 R = s16(  A   %    U  );  return s16(R   + ((R < 0) ?      U : 0));}
    [In(line)] internal static s32 wrap(s32 A,        s32 U) {                   s32 R =    (  A   %    U  );  return     R   + ((R < 0) ?      U : 0);}
    [In(line)] internal static s64 wrap(s64 A,        s64 U) {                   s64 R =    (  A   %    U  );  return     R   + ((R < 0) ?      U : 0);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Minimum" Value
    [In(line)] internal static  u8 min( u8 A,  u8 B)               => (A < B) ? A : B;
    [In(line)] internal static u16 min(u16 A, u16 B)               => (A < B) ? A : B;
    [In(line)] internal static u32 min(u32 A, u32 B)               => (A < B) ? A : B;
    [In(line)] internal static u64 min(u64 A, u64 B)               => (A < B) ? A : B;

    [In(line)] internal static  s8 min( s8 A,  s8 B)               => (A < B) ? A : B;
    [In(line)] internal static s16 min(s16 A, s16 B)               => (A < B) ? A : B;
    [In(line)] internal static s32 min(s32 A, s32 B)               => (A < B) ? A : B;
    [In(line)] internal static s64 min(s64 A, s64 B)               => (A < B) ? A : B;

    [In(line)] internal static s32 min(s32 A, s32 B, s32 C)        => (A < B) ? ((A < C) ? A : C)
                                                                              : ((B < C) ? B : C);

    [In(line)] internal static s32 min(s32 A, s32 B, s32 C, s32 D) => (A < B) ? ((A < C) ? ((A < D) ? A : D)
                                                                                         : ((C < D) ? C : D))
                                                                              : ((B < C) ? ((B < D) ? B : D)
                                                                                         : ((C < D) ? C : D));

    [In(line)] internal static i2 min(i2 A, i1 B) => new i2(min(A.x,B  ), min(A.y,B  ));
    [In(line)] internal static i2 min(i1 A, i2 B) => new i2(min(A  ,B.x), min(A  ,B.y));
    [In(line)] internal static i3 min(i3 A, i1 B) => new i3(min(A.x,B  ), min(A.y,B  ), min(A.z,B  ));
    [In(line)] internal static i3 min(i1 A, i3 B) => new i3(min(A  ,B.x), min(A  ,B.y), min(A  ,B.z));
    [In(line)] internal static i4 min(i4 A, i1 B) => new i4(min(A.x,B  ), min(A.y,B  ), min(A.z,B  ), min(A.w,B  ));
    [In(line)] internal static i4 min(i1 A, i4 B) => new i4(min(A  ,B.x), min(A  ,B.y), min(A  ,B.z), min(A  ,B.w));

    [In(line)] internal static i2 min(i2 A, i2 B)             => new i2(min(A.x,B.x),         min(A.y,B.y));
    [In(line)] internal static i2 min(i2 A, i2 B, i2 C)       => new i2(min(A.x,B.x,C.x),     min(A.y,B.y,C.y));
    [In(line)] internal static i2 min(i2 A, i2 B, i2 C, i2 D) => new i2(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y));
    [In(line)] internal static i3 min(i3 A, i3 B)             => new i3(min(A.x,B.x),         min(A.y,B.y),         min(A.z,B.z));
    [In(line)] internal static i3 min(i3 A, i3 B, i3 C)       => new i3(min(A.x,B.x,C.x),     min(A.y,B.y,C.y),     min(A.z,B.z,C.z));
    [In(line)] internal static i3 min(i3 A, i3 B, i3 C, i3 D) => new i3(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z));
    [In(line)] internal static i4 min(i4 A, i4 B)             => new i4(min(A.x,B.x),         min(A.y,B.y),         min(A.z,B.z),         min(A.w,B.w));
    [In(line)] internal static i4 min(i4 A, i4 B, i4 C)       => new i4(min(A.x,B.x,C.x),     min(A.y,B.y,C.y),     min(A.z,B.z,C.z),     min(A.w,B.w,C.w));
    [In(line)] internal static i4 min(i4 A, i4 B, i4 C, i4 D) => new i4(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z), min(A.w,B.w,C.w,D.w));

    //==========================================================================================================================================================
    //                                                                  "Maximum" Value
    [In(line)] internal static  u8 max( u8 A,  u8 B)               => (A > B) ? A : B;
    [In(line)] internal static u16 max(u16 A, u16 B)               => (A > B) ? A : B;
    [In(line)] internal static u32 max(u32 A, u32 B)               => (A > B) ? A : B;
    [In(line)] internal static u64 max(u64 A, u64 B)               => (A > B) ? A : B;

    [In(line)] internal static  s8 max( s8 A,  s8 B)               => (A > B) ? A : B;
    [In(line)] internal static s16 max(s16 A, s16 B)               => (A > B) ? A : B;
    [In(line)] internal static s32 max(s32 A, s32 B)               => (A > B) ? A : B;
    [In(line)] internal static s64 max(s64 A, s64 B)               => (A > B) ? A : B;

    [In(line)] internal static s32 max(s32 A, s32 B, s32 C)        => (A > B) ? ((A > C) ? A : C)
                                                                              : ((B > C) ? B : C);

    [In(line)] internal static s32 max(s32 A, s32 B, s32 C, s32 D) => (A > B) ? ((A > C) ? ((A > D) ? A : D)
                                                                                         : ((C > D) ? C : D))
                                                                              : ((B > C) ? ((B > D) ? B : D)
                                                                                         : ((C > D) ? C : D));

    [In(line)] internal static i2 max(i2 A, i1 B) => new i2(max(A.x,B  ), max(A.y,B  ));
    [In(line)] internal static i2 max(i1 A, i2 B) => new i2(max(A  ,B.x), max(A  ,B.y));
    [In(line)] internal static i3 max(i3 A, i1 B) => new i3(max(A.x,B  ), max(A.y,B  ), max(A.z,B  ));
    [In(line)] internal static i3 max(i1 A, i3 B) => new i3(max(A  ,B.x), max(A  ,B.y), max(A  ,B.z));
    [In(line)] internal static i4 max(i4 A, i1 B) => new i4(max(A.x,B  ), max(A.y,B  ), max(A.z,B  ), max(A.w,B  ));
    [In(line)] internal static i4 max(i1 A, i4 B) => new i4(max(A  ,B.x), max(A  ,B.y), max(A  ,B.z), max(A  ,B.w));

    [In(line)] internal static i2 max(i2 A, i2 B)             => new i2(max(A.x,B.x),         max(A.y,B.y));
    [In(line)] internal static i2 max(i2 A, i2 B, i2 C)       => new i2(max(A.x,B.x,C.x),     max(A.y,B.y,C.y));
    [In(line)] internal static i2 max(i2 A, i2 B, i2 C, i2 D) => new i2(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y));
    [In(line)] internal static i3 max(i3 A, i3 B)             => new i3(max(A.x,B.x),         max(A.y,B.y),         max(A.z,B.z));
    [In(line)] internal static i3 max(i3 A, i3 B, i3 C)       => new i3(max(A.x,B.x,C.x),     max(A.y,B.y,C.y),     max(A.z,B.z,C.z));
    [In(line)] internal static i3 max(i3 A, i3 B, i3 C, i3 D) => new i3(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z));
    [In(line)] internal static i4 max(i4 A, i4 B)             => new i4(max(A.x,B.x),         max(A.y,B.y),         max(A.z,B.z),         max(A.w,B.w));
    [In(line)] internal static i4 max(i4 A, i4 B, i4 C)       => new i4(max(A.x,B.x,C.x),     max(A.y,B.y,C.y),     max(A.z,B.z,C.z),     max(A.w,B.w,C.w));
    [In(line)] internal static i4 max(i4 A, i4 B, i4 C, i4 D) => new i4(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z), max(A.w,B.w,C.w,D.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                 Euclidean "Modulo"
    [In(line)] internal static int mod(int A, int B) {int R = A % B; return R + (R < 0 ? (B < 0 ? -B : B) : 0);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Round" To
    //  Each component rounded to the nearest 'N'.
    //
    //      round(  Value,  RoundTo  )
    //      floor(  Value,  FloorTo  )
    //       ceil(  Value,  CeilingTo  )
    //
    [In(line)] internal static i1 round(i1 A, i1 N) => (A < 0) ? N*((A - N/2 + ((N&1)!=0?0:1) )/N)
                                                               : N*((A + N/2                  )/N);

    [In(line)] internal static i1 floor(i1 A, i1 N) => (A < 0) ? N*((A - N + 1)/N)
                                                               : N*(     A     /N);

    [In(line)] internal static i1  ceil(i1 A, i1 N) => (A < 0) ? N*(     A     /N)
                                                               : N*((A + N - 1)/N);

    [In(line)] internal static i2 round(i2 A, i1 N) => new i2(round(A.x,N), round(A.y,N));
    [In(line)] internal static i3 round(i3 A, i1 N) => new i3(round(A.x,N), round(A.y,N), round(A.z,N));
    [In(line)] internal static i4 round(i4 A, i1 N) => new i4(round(A.x,N), round(A.y,N), round(A.z,N), round(A.w,N));

    [In(line)] internal static i2 floor(i2 A, i1 N) => new i2(floor(A.x,N), floor(A.y,N));
    [In(line)] internal static i3 floor(i3 A, i1 N) => new i3(floor(A.x,N), floor(A.y,N), floor(A.z,N));
    [In(line)] internal static i4 floor(i4 A, i1 N) => new i4(floor(A.x,N), floor(A.y,N), floor(A.z,N), floor(A.w,N));

    [In(line)] internal static i2  ceil(i2 A, i1 N) => new i2(ceil(A.x,N), ceil(A.y,N));
    [In(line)] internal static i3  ceil(i3 A, i1 N) => new i3(ceil(A.x,N), ceil(A.y,N), ceil(A.z,N));
    [In(line)] internal static i4  ceil(i4 A, i1 N) => new i4(ceil(A.x,N), ceil(A.y,N), ceil(A.z,N), ceil(A.w,N));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                       "Sign"
    [In(line)] internal static  s8 sign( s8 A) =>  s8((A < 0) ? -1 : 1);
    [In(line)] internal static s16 sign(s16 A) => s16((A < 0) ? -1 : 1);
    [In(line)] internal static s32 sign(s32 A) =>     (A < 0) ? -1 : 1;
    [In(line)] internal static s64 sign(s64 A) =>     (A < 0) ? -1 : 1;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Square"
    [In(line)] internal static i1 sq(i1 A) => (A*A);
    [In(line)] internal static i2 sq(i2 A) => (A*A);
    [In(line)] internal static i3 sq(i3 A) => (A*A);
    [In(line)] internal static i4 sq(i4 A) => (A*A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                             "Trunkate" base10 Digits
    //  NOTE:  Doesn't handle "-" symbol...
    //
    //      trunk(12345, -2) ==   345
    //      trunk(12345,  2) == 123
    //
    internal static int trunk(int A, int Digits) {
        if (Digits == 0)
            return A;

        string Astr = A.ToString();

        return (Digits > 0) ? (Astr.Length <=  Digits) ? 0 : System.Convert.ToInt32(Astr.Remove(Astr.Length-Digits,  Digits))  //  Truncate Right
                            : (Astr.Length <= -Digits) ? 0 : System.Convert.ToInt32(Astr.Remove(                 0, -Digits)); //  Truncate Left
    }

    internal static long trunk(long A, int Digits) {
        if (Digits == 0)
            return A;

        string Astr = A.ToString();

        return (Digits > 0) ? (Astr.Length <=  Digits) ? 0 : System.Convert.ToInt64(Astr.Remove(Astr.Length-Digits,  Digits))  //  Truncate Right
                            : (Astr.Length <= -Digits) ? 0 : System.Convert.ToInt64(Astr.Remove(                 0, -Digits)); //  Truncate Left
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
