
namespace Utility;
internal static class INT {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Absolute" Value
    //  NOTE:  Does not check for overflow.    -(-2_147_483_648)
    //
    [Impl(AggressiveInlining)] internal static  s8 abs( s8 A) =>  s8((A >= 0) ? A : -A);
    [Impl(AggressiveInlining)] internal static s16 abs(s16 A) => s16((A >= 0) ? A : -A);
    [Impl(AggressiveInlining)] internal static s32 abs(s32 A) =>     (A >= 0) ? A : -A;
    [Impl(AggressiveInlining)] internal static s64 abs(s64 A) =>     (A >= 0) ? A : -A;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Clamp"
    //                *Inclusive*  *Inclusive*
    //      clamp( A, LowerBounds, UpperBounds )
    //
  //[Impl(AggressiveInlining)] internal static  s8 clamp( s8 A,  s8 L,  s8 U) => (A < L) ? L : (A > U) ? U : A;
  //[Impl(AggressiveInlining)] internal static  u8 clamp( u8 A,  u8 L,  u8 U) => (A < L) ? L : (A > U) ? U : A;

  //[Impl(AggressiveInlining)] internal static s16 clamp(s16 A, s16 L, s16 U) => (A < L) ? L : (A > U) ? U : A;         ambiguous call...
  //[Impl(AggressiveInlining)] internal static u16 clamp(u16 A, u16 L, u16 U) => (A < L) ? L : (A > U) ? U : A;             implicit cast:   short -> int

    [Impl(AggressiveInlining)] internal static s32 clamp(s32 A, s32 L, s32 U) => (A < L) ? L : (A > U) ? U : A;
    [Impl(AggressiveInlining)] internal static u32 clamp(u32 A, u32 L, u32 U) => (A < L) ? L : (A > U) ? U : A;

    [Impl(AggressiveInlining)] internal static s64 clamp(s64 A, s64 L, s64 U) => (A < L) ? L : (A > U) ? U : A;
    [Impl(AggressiveInlining)] internal static u64 clamp(u64 A, u64 L, u64 U) => (A < L) ? L : (A > U) ? U : A;

    //==========================================================================================================================================================
    //                                                                       "Wrap"
    //               *Inclusive*  *Exclusive*
    //      wrap( A, LowerBounds, UpperBounds )
    //      wrap( A,              UpperBounds )     LowerBounds is 0
    //
    [Impl(AggressiveInlining)] internal static s16 wrap(s16 A, s16 L, s16 U) {s32 Domain = U-L;  A = s16((A-L) % Domain);  return s16(A+L + ((A < 0) ? Domain : 0));}
    [Impl(AggressiveInlining)] internal static s32 wrap(s32 A, s32 L, s32 U) {s32 Domain = U-L;  A =     (A-L) % Domain;   return     A+L + ((A < 0) ? Domain : 0);}
    [Impl(AggressiveInlining)] internal static s64 wrap(s64 A, s64 L, s64 U) {s64 Domain = U-L;  A =     (A-L) % Domain;   return     A+L + ((A < 0) ? Domain : 0);}

    [Impl(AggressiveInlining)] internal static s16 wrap(s16 A,        s16 U) {                   A = s16(A     %      U);  return s16(A   + ((A < 0) ?      U : 0));}
    [Impl(AggressiveInlining)] internal static s32 wrap(s32 A,        s32 U) {                   A =    (A     %      U);  return     A   + ((A < 0) ?      U : 0);}
    [Impl(AggressiveInlining)] internal static s64 wrap(s64 A,        s64 U) {                   A =    (A     %      U);  return     A   + ((A < 0) ?      U : 0);}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Get previous/next Index, with Array.Length wrapping.
    //  Essentially, a less-gross version of the above wrap() function that only works with positive integers in the 0 to N range.
    //
    //      Blarg[ prev(i, Blarg.Length) ]      Equivalent to:  Blarg[ prev(i, 1, Blarg.Length) ]
    //      Blarg[ next(i, Blarg.Length) ]      Equivalent to:  Blarg[ next(i, 1, Blarg.Length) ]
    //
    //      Blarg[ prev(i, 2, Blarg.Length) ]
    //      Blarg[ next(i, 2, Blarg.Length) ]
    //
  //[Impl(AggressiveInlining)] internal static s16 prev(s16 i,           s32 U) => s16((i <= 0) ? U-1 : --i);
  //[Impl(AggressiveInlining)] internal static u16 prev(u16 i,           s32 U) => u16((i <= 0) ? U-1 : --i);
    [Impl(AggressiveInlining)] internal static s32 prev(s32 i,           s32 U) =>     (i <= 0) ?       U-1 : --i;
    [Impl(AggressiveInlining)] internal static u32 prev(u32 i,           s32 U) =>     (i <= 0) ? (uint)U-1 : --i;
  //[Impl(AggressiveInlining)] internal static s64 prev(s64 i,           s32 U) =>     (i <= 0) ? U-1 : --i;
  //[Impl(AggressiveInlining)] internal static u64 prev(u64 i,           s32 U) =>     (i <= 0) ? U-1 : --i;

  //[Impl(AggressiveInlining)] internal static s16 next(s16 i,           s32 U) => s16((++i >= U) ? 0 : i);
  //[Impl(AggressiveInlining)] internal static u16 next(u16 i,           s32 U) => u16((++i >= U) ? 0 : i);
    [Impl(AggressiveInlining)] internal static s32 next(s32 i,           s32 U) =>     (++i >= U) ? 0 : i;
    [Impl(AggressiveInlining)] internal static u32 next(u32 i,           s32 U) =>     (++i >= U) ? 0 : i;
  //[Impl(AggressiveInlining)] internal static s64 next(s64 i,           s32 U) =>     (++i >= U) ? 0 : i;
  //[Impl(AggressiveInlining)] internal static u64 next(u64 i,           s32 U) =>     (++i >= U) ? 0 : i;

  //[Impl(AggressiveInlining)] internal static s16 prev(s16 i, s16 Step, s16 U) => ((i = s16(i-Step)) <  0) ? s16(i+U) : i;
    [Impl(AggressiveInlining)] internal static s32 prev(s32 i, s32 Step, s32 U) => ((i =     i-Step ) <  0) ?     i+U  : i;
////[Impl(AggressiveInlining)] internal static u32 prev(u32 i, s32 Step, s32 U) => ((i =     i-Step ) <  0) ?     i+U  : i;
  //[Impl(AggressiveInlining)] internal static s64 prev(s64 i, s64 Step, s64 U) => ((i =     i-Step ) <  0) ?     i+U  : i;

  //[Impl(AggressiveInlining)] internal static s16 next(s16 i, s16 Step, s16 U) => ((i = s16(i+Step)) >= U) ? s16(i-U) : i;
    [Impl(AggressiveInlining)] internal static s32 next(s32 i, s32 Step, s32 U) => ((i =     i+Step ) >= U) ?     i-U  : i;
////[Impl(AggressiveInlining)] internal static u32 next(u32 i, s32 Step, s32 U) => ((i =     i+Step ) >= U) ?     i-U  : i;
  //[Impl(AggressiveInlining)] internal static s64 next(s64 i, s64 Step, s64 U) => ((i =     i+Step ) >= U) ?     i-U  : i;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Minimum" Value
    [Impl(AggressiveInlining)] internal static  u8 min( u8 A,  u8 B)               => (A < B) ? A : B;
    [Impl(AggressiveInlining)] internal static u16 min(u16 A, u16 B)               => (A < B) ? A : B;
    [Impl(AggressiveInlining)] internal static u32 min(u32 A, u32 B)               => (A < B) ? A : B;
    [Impl(AggressiveInlining)] internal static u64 min(u64 A, u64 B)               => (A < B) ? A : B;

    [Impl(AggressiveInlining)] internal static  s8 min( s8 A,  s8 B)               => (A < B) ? A : B;
    [Impl(AggressiveInlining)] internal static s16 min(s16 A, s16 B)               => (A < B) ? A : B;
    [Impl(AggressiveInlining)] internal static s32 min(s32 A, s32 B)               => (A < B) ? A : B;
    [Impl(AggressiveInlining)] internal static s64 min(s64 A, s64 B)               => (A < B) ? A : B;

    [Impl(AggressiveInlining)] internal static s32 min(s32 A, s32 B, s32 C)        => (A < B) ? ((A < C) ? A : C)
                                                                                              : ((B < C) ? B : C);

    [Impl(AggressiveInlining)] internal static s32 min(s32 A, s32 B, s32 C, s32 D) => (A < B) ? ((A < C) ? ((A < D) ? A : D)
                                                                                                         : ((C < D) ? C : D))
                                                                                              : ((B < C) ? ((B < D) ? B : D)
                                                                                                         : ((C < D) ? C : D));

    [Impl(AggressiveInlining)] internal static i2 min(i2 A, i1 B) => new i2(min(A.x,B  ), min(A.y,B  ));
    [Impl(AggressiveInlining)] internal static i2 min(i1 A, i2 B) => new i2(min(A  ,B.x), min(A  ,B.y));
    [Impl(AggressiveInlining)] internal static i3 min(i3 A, i1 B) => new i3(min(A.x,B  ), min(A.y,B  ), min(A.z,B  ));
    [Impl(AggressiveInlining)] internal static i3 min(i1 A, i3 B) => new i3(min(A  ,B.x), min(A  ,B.y), min(A  ,B.z));
    [Impl(AggressiveInlining)] internal static i4 min(i4 A, i1 B) => new i4(min(A.x,B  ), min(A.y,B  ), min(A.z,B  ), min(A.w,B  ));
    [Impl(AggressiveInlining)] internal static i4 min(i1 A, i4 B) => new i4(min(A  ,B.x), min(A  ,B.y), min(A  ,B.z), min(A  ,B.w));

    [Impl(AggressiveInlining)] internal static i2 min(i2 A, i2 B)             => new i2(min(A.x,B.x),         min(A.y,B.y));
    [Impl(AggressiveInlining)] internal static i2 min(i2 A, i2 B, i2 C)       => new i2(min(A.x,B.x,C.x),     min(A.y,B.y,C.y));
    [Impl(AggressiveInlining)] internal static i2 min(i2 A, i2 B, i2 C, i2 D) => new i2(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y));
    [Impl(AggressiveInlining)] internal static i3 min(i3 A, i3 B)             => new i3(min(A.x,B.x),         min(A.y,B.y),         min(A.z,B.z));
    [Impl(AggressiveInlining)] internal static i3 min(i3 A, i3 B, i3 C)       => new i3(min(A.x,B.x,C.x),     min(A.y,B.y,C.y),     min(A.z,B.z,C.z));
    [Impl(AggressiveInlining)] internal static i3 min(i3 A, i3 B, i3 C, i3 D) => new i3(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z));
    [Impl(AggressiveInlining)] internal static i4 min(i4 A, i4 B)             => new i4(min(A.x,B.x),         min(A.y,B.y),         min(A.z,B.z),         min(A.w,B.w));
    [Impl(AggressiveInlining)] internal static i4 min(i4 A, i4 B, i4 C)       => new i4(min(A.x,B.x,C.x),     min(A.y,B.y,C.y),     min(A.z,B.z,C.z),     min(A.w,B.w,C.w));
    [Impl(AggressiveInlining)] internal static i4 min(i4 A, i4 B, i4 C, i4 D) => new i4(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z), min(A.w,B.w,C.w,D.w));

    //==========================================================================================================================================================
    //                                                                  "Maximum" Value
    [Impl(AggressiveInlining)] internal static  u8 max( u8 A,  u8 B)               => (A > B) ? A : B;
    [Impl(AggressiveInlining)] internal static u16 max(u16 A, u16 B)               => (A > B) ? A : B;
    [Impl(AggressiveInlining)] internal static u32 max(u32 A, u32 B)               => (A > B) ? A : B;
    [Impl(AggressiveInlining)] internal static u64 max(u64 A, u64 B)               => (A > B) ? A : B;

    [Impl(AggressiveInlining)] internal static  s8 max( s8 A,  s8 B)               => (A > B) ? A : B;
    [Impl(AggressiveInlining)] internal static s16 max(s16 A, s16 B)               => (A > B) ? A : B;
    [Impl(AggressiveInlining)] internal static s32 max(s32 A, s32 B)               => (A > B) ? A : B;
    [Impl(AggressiveInlining)] internal static s64 max(s64 A, s64 B)               => (A > B) ? A : B;

    [Impl(AggressiveInlining)] internal static s32 max(s32 A, s32 B, s32 C)        => (A > B) ? ((A > C) ? A : C)
                                                                                              : ((B > C) ? B : C);

    [Impl(AggressiveInlining)] internal static s32 max(s32 A, s32 B, s32 C, s32 D) => (A > B) ? ((A > C) ? ((A > D) ? A : D)
                                                                                                         : ((C > D) ? C : D))
                                                                                              : ((B > C) ? ((B > D) ? B : D)
                                                                                                         : ((C > D) ? C : D));

    [Impl(AggressiveInlining)] internal static i2 max(i2 A, i1 B) => new i2(max(A.x,B  ), max(A.y,B  ));
    [Impl(AggressiveInlining)] internal static i2 max(i1 A, i2 B) => new i2(max(A  ,B.x), max(A  ,B.y));
    [Impl(AggressiveInlining)] internal static i3 max(i3 A, i1 B) => new i3(max(A.x,B  ), max(A.y,B  ), max(A.z,B  ));
    [Impl(AggressiveInlining)] internal static i3 max(i1 A, i3 B) => new i3(max(A  ,B.x), max(A  ,B.y), max(A  ,B.z));
    [Impl(AggressiveInlining)] internal static i4 max(i4 A, i1 B) => new i4(max(A.x,B  ), max(A.y,B  ), max(A.z,B  ), max(A.w,B  ));
    [Impl(AggressiveInlining)] internal static i4 max(i1 A, i4 B) => new i4(max(A  ,B.x), max(A  ,B.y), max(A  ,B.z), max(A  ,B.w));

    [Impl(AggressiveInlining)] internal static i2 max(i2 A, i2 B)             => new i2(max(A.x,B.x),         max(A.y,B.y));
    [Impl(AggressiveInlining)] internal static i2 max(i2 A, i2 B, i2 C)       => new i2(max(A.x,B.x,C.x),     max(A.y,B.y,C.y));
    [Impl(AggressiveInlining)] internal static i2 max(i2 A, i2 B, i2 C, i2 D) => new i2(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y));
    [Impl(AggressiveInlining)] internal static i3 max(i3 A, i3 B)             => new i3(max(A.x,B.x),         max(A.y,B.y),         max(A.z,B.z));
    [Impl(AggressiveInlining)] internal static i3 max(i3 A, i3 B, i3 C)       => new i3(max(A.x,B.x,C.x),     max(A.y,B.y,C.y),     max(A.z,B.z,C.z));
    [Impl(AggressiveInlining)] internal static i3 max(i3 A, i3 B, i3 C, i3 D) => new i3(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z));
    [Impl(AggressiveInlining)] internal static i4 max(i4 A, i4 B)             => new i4(max(A.x,B.x),         max(A.y,B.y),         max(A.z,B.z),         max(A.w,B.w));
    [Impl(AggressiveInlining)] internal static i4 max(i4 A, i4 B, i4 C)       => new i4(max(A.x,B.x,C.x),     max(A.y,B.y,C.y),     max(A.z,B.z,C.z),     max(A.w,B.w,C.w));
    [Impl(AggressiveInlining)] internal static i4 max(i4 A, i4 B, i4 C, i4 D) => new i4(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z), max(A.w,B.w,C.w,D.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                 Euclidean "Modulo"
    [Impl(AggressiveInlining)] internal static int mod(int A, int B) {int R = A % B; return R + (R < 0 ? (B < 0 ? -B : B) : 0);}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Round" To
    //  Each component rounded to the nearest 'N'.
    //
    //      round(  Value,  RoundTo  )
    //      floor(  Value,  FloorTo  )
    //       ceil(  Value,  CeilingTo  )
    //
    [Impl(AggressiveInlining)] internal static i1 round(i1 A, i1 N) => (A < 0) ? N*((A - N/2 + ((N&1)!=0?0:1) )/N)
                                                                               : N*((A + N/2                  )/N);

    [Impl(AggressiveInlining)] internal static i1 floor(i1 A, i1 N) => (A < 0) ? N*((A - N + 1)/N)
                                                                               : N*(     A     /N);

    [Impl(AggressiveInlining)] internal static i1  ceil(i1 A, i1 N) => (A < 0) ? N*(     A     /N)
                                                                               : N*((A + N - 1)/N);

    [Impl(AggressiveInlining)] internal static i2 round(i2 A, i1 N) => new i2(round(A.x,N), round(A.y,N));
    [Impl(AggressiveInlining)] internal static i3 round(i3 A, i1 N) => new i3(round(A.x,N), round(A.y,N), round(A.z,N));
    [Impl(AggressiveInlining)] internal static i4 round(i4 A, i1 N) => new i4(round(A.x,N), round(A.y,N), round(A.z,N), round(A.w,N));

    [Impl(AggressiveInlining)] internal static i2 floor(i2 A, i1 N) => new i2(floor(A.x,N), floor(A.y,N));
    [Impl(AggressiveInlining)] internal static i3 floor(i3 A, i1 N) => new i3(floor(A.x,N), floor(A.y,N), floor(A.z,N));
    [Impl(AggressiveInlining)] internal static i4 floor(i4 A, i1 N) => new i4(floor(A.x,N), floor(A.y,N), floor(A.z,N), floor(A.w,N));

    [Impl(AggressiveInlining)] internal static i2 ceil(i2 A, i1 N) => new i2(ceil(A.x,N), ceil(A.y,N));
    [Impl(AggressiveInlining)] internal static i3 ceil(i3 A, i1 N) => new i3(ceil(A.x,N), ceil(A.y,N), ceil(A.z,N));
    [Impl(AggressiveInlining)] internal static i4 ceil(i4 A, i1 N) => new i4(ceil(A.x,N), ceil(A.y,N), ceil(A.z,N), ceil(A.w,N));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                       "Sign"
    [Impl(AggressiveInlining)] internal static  s8 sign( s8 A) =>  s8((A < 0) ? -1 : 1);
    [Impl(AggressiveInlining)] internal static s16 sign(s16 A) => s16((A < 0) ? -1 : 1);
    [Impl(AggressiveInlining)] internal static s32 sign(s32 A) =>     (A < 0) ? -1 : 1;
    [Impl(AggressiveInlining)] internal static s64 sign(s64 A) =>     (A < 0) ? -1 : 1;

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

        return (Digits > 0) ? (Astr.Length <=  Digits) ? 0 : System.Convert.ToInt32(Astr.Remove(Astr.Length-Digits,  Digits))  // Truncate Right
                            : (Astr.Length <= -Digits) ? 0 : System.Convert.ToInt32(Astr.Remove(                 0, -Digits)); // Truncate Left
    }

    internal static long trunk(long A, int Digits) {
        if (Digits == 0)
            return A;

        string Astr = A.ToString();

        return (Digits > 0) ? (Astr.Length <=  Digits) ? 0 : System.Convert.ToInt64(Astr.Remove(Astr.Length-Digits,  Digits))  // Truncate Right
                            : (Astr.Length <= -Digits) ? 0 : System.Convert.ToInt64(Astr.Remove(                 0, -Digits)); // Truncate Left
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
