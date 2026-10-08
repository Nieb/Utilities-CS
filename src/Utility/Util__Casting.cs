
namespace Utility;
internal static class Casting {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] internal static f32 BitCast_f32(s32 I) => new Data32(){I=I}.F;
    [In(line)] internal static f32 BitCast_f32(u32 U) => new Data32(){U=U}.F;

    [In(line)] internal static s32 BitCast_s32(f32 F) => new Data32(){F=F}.I;
    [In(line)] internal static s32 BitCast_s32(u32 U) => new Data32(){U=U}.I;

    [In(line)] internal static u32 BitCast_u32(f32 F) => new Data32(){F=F}.U;
    [In(line)] internal static u32 BitCast_u32(s32 I) => new Data32(){I=I}.U;

    //==========================================================================================================================================================
    [In(line)] internal static f64 BitCast_f64(s64 I) => new Data64(){I=I}.F;
    [In(line)] internal static f64 BitCast_f64(u64 U) => new Data64(){U=U}.F;

    [In(line)] internal static s64 BitCast_s64(f64 F) => new Data64(){F=F}.I;
    [In(line)] internal static s64 BitCast_s64(u64 U) => new Data64(){U=U}.I;

    [In(line)] internal static u64 BitCast_u64(f64 F) => new Data64(){F=F}.U;
    [In(line)] internal static u64 BitCast_u64(s64 I) => new Data64(){I=I}.U;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  All BYTE,SHORT operations result in an INT.  :(
    //
    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static  u8 ClampToByte  (f32 A) =>  (u8)clamp(round(A), (f32)MIN_u8,  (f32)MAX_u8);
    [In(line)] internal static  u8 ClampToByte  (s32 A) =>  (u8)clamp(      A , (s32)MIN_u8,  (s32)MAX_u8);
    [In(line)] internal static  u8 ClampToByte  (s64 A) =>  (u8)clamp(      A , (s64)MIN_u8,  (s64)MAX_u8);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static s16 ClampToShort (f32 A) => (s16)clamp(round(A), (f32)MIN_s16, (f32)MAX_s16);
    [In(line)] internal static s16 ClampToShort (s32 A) => (s16)clamp(      A , (s32)MIN_s16, (s32)MAX_s16);
    [In(line)] internal static s16 ClampToShort (s64 A) => (s16)clamp(      A , (s64)MIN_s16, (s64)MAX_s16);

    [In(line)] internal static u16 ClampToUshort(f32 A) => (u16)clamp(round(A), (f32)MIN_u16, (f32)MAX_u16);
    [In(line)] internal static u16 ClampToUshort(s32 A) => (u16)clamp(      A , (s32)MIN_u16, (s32)MAX_u16);
    [In(line)] internal static u16 ClampToUshort(s64 A) => (u16)clamp(      A , (s64)MIN_u16, (s64)MAX_u16);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
  //[In(line)] internal static s32 ClampToInt   (f32 A) => (s32)clamp(round(A), (f32)MIN_s32, (f32)MAX_s32);
  //[In(line)] internal static s32 ClampToInt   (s64 A) => (s32)clamp(      A , (s64)MIN_s32, (s64)MAX_s32);

  //[In(line)] internal static u32 ClampToUint  (s32 A) => (u32)clamp(      A , (s32)MIN_u32,      MAX_s32);
  //[In(line)] internal static u32 ClampToUint  (s64 A) => (u32)clamp(      A , (s64)MIN_u32, (s64)MAX_u32);

    //==========================================================================================================================================================
    [In(line)] internal static i1 FloorToInt(v1 A) => (int)floor(A);
    [In(line)] internal static i2 FloorToInt(v2 A) => new ivec2(FloorToInt(A.x), FloorToInt(A.y));
    [In(line)] internal static i3 FloorToInt(v3 A) => new ivec3(FloorToInt(A.x), FloorToInt(A.y), FloorToInt(A.z));
    [In(line)] internal static i4 FloorToInt(v4 A) => new ivec4(FloorToInt(A.x), FloorToInt(A.y), FloorToInt(A.z), FloorToInt(A.w));

    [In(line)] internal static i1  CeilToInt(v1 A) => (int)ceil(A);
    [In(line)] internal static i2  CeilToInt(v2 A) => new ivec2(CeilToInt(A.x), CeilToInt(A.y));
    [In(line)] internal static i3  CeilToInt(v3 A) => new ivec3(CeilToInt(A.x), CeilToInt(A.y), CeilToInt(A.z));
    [In(line)] internal static i4  CeilToInt(v4 A) => new ivec4(CeilToInt(A.x), CeilToInt(A.y), CeilToInt(A.z), CeilToInt(A.w));

    [In(line)] internal static i1 RoundToInt(v1 A) => (int)round(A);
    [In(line)] internal static i2 RoundToInt(v2 A) => new ivec2(RoundToInt(A.x), RoundToInt(A.y));
    [In(line)] internal static i3 RoundToInt(v3 A) => new ivec3(RoundToInt(A.x), RoundToInt(A.y), RoundToInt(A.z));
    [In(line)] internal static i4 RoundToInt(v4 A) => new ivec4(RoundToInt(A.x), RoundToInt(A.y), RoundToInt(A.z), RoundToInt(A.w));

    [In(line)] internal static i1  SnapToInt(v1 A) {int rA = RoundToInt(A);  return (abs(A - rA) < EPS6) ? rA : FloorToInt(A);} //  Damn floats and their fuzzy edges... :[
    [In(line)] internal static i2  SnapToInt(v2 A) => new ivec2(SnapToInt(A.x), SnapToInt(A.y));
    [In(line)] internal static i3  SnapToInt(v3 A) => new ivec3(SnapToInt(A.x), SnapToInt(A.y), SnapToInt(A.z));
    [In(line)] internal static i4  SnapToInt(v4 A) => new ivec4(SnapToInt(A.x), SnapToInt(A.y), SnapToInt(A.z), SnapToInt(A.w));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] internal static s32 FloorToInt(f64 A) => (s32)floor(A);
    [In(line)] internal static s32  CeilToInt(f64 A) => (s32)ceil(A);
    [In(line)] internal static s32 RoundToInt(f64 A) => (s32)round(A);

  //[In(line)] internal static s64 RoundToLong(f32 A) => (s64)round(A);
  //[In(line)] internal static s64 RoundToLong(f64 A) => (s64)round(A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  This syntax is dumb.  :P
    //      (type)value;
    //      (type)expres / sion;
    //      (type)(expres / sion);
    //
    //  With this syntax, "order of operations" or "what/when exactly is being cast" is unambiguous:
    //      type(value);
    //      type(expres / sion);
    //
    [In(line)] internal static  s8  s8( u8 A) =>  (s8)A;        [In(line)] internal static  u8  u8( s8 A) =>  (u8)A;
    [In(line)] internal static  s8  s8(s16 A) =>  (s8)A;        [In(line)] internal static  u8  u8(s16 A) =>  (u8)A;
    [In(line)] internal static  s8  s8(u16 A) =>  (s8)A;        [In(line)] internal static  u8  u8(u16 A) =>  (u8)A;
    [In(line)] internal static  s8  s8(s32 A) =>  (s8)A;        [In(line)] internal static  u8  u8(s32 A) =>  (u8)A;
    [In(line)] internal static  s8  s8(u32 A) =>  (s8)A;        [In(line)] internal static  u8  u8(u32 A) =>  (u8)A;
    [In(line)] internal static  s8  s8(s64 A) =>  (s8)A;        [In(line)] internal static  u8  u8(s64 A) =>  (u8)A;
    [In(line)] internal static  s8  s8(u64 A) =>  (s8)A;        [In(line)] internal static  u8  u8(u64 A) =>  (u8)A;
    [In(line)] internal static  s8  s8(f32 A) =>  (s8)A;        [In(line)] internal static  u8  u8(f32 A) =>  (u8)A;
    [In(line)] internal static  s8  s8(f64 A) =>  (s8)A;        [In(line)] internal static  u8  u8(f64 A) =>  (u8)A;

    [In(line)] internal static s16 s16( s8 A) => (s16)A;        [In(line)] internal static u16 u16( s8 A) => (u16)A;
    [In(line)] internal static s16 s16( u8 A) => (s16)A;        [In(line)] internal static u16 u16( u8 A) => (u16)A;
    [In(line)] internal static s16 s16(u16 A) => (s16)A;        [In(line)] internal static u16 u16(s16 A) => (u16)A;
    [In(line)] internal static s16 s16(s32 A) => (s16)A;        [In(line)] internal static u16 u16(s32 A) => (u16)A;
    [In(line)] internal static s16 s16(u32 A) => (s16)A;        [In(line)] internal static u16 u16(u32 A) => (u16)A;
    [In(line)] internal static s16 s16(s64 A) => (s16)A;        [In(line)] internal static u16 u16(s64 A) => (u16)A;
    [In(line)] internal static s16 s16(u64 A) => (s16)A;        [In(line)] internal static u16 u16(u64 A) => (u16)A;
    [In(line)] internal static s16 s16(f32 A) => (s16)A;        [In(line)] internal static u16 u16(f32 A) => (u16)A;
    [In(line)] internal static s16 s16(f64 A) => (s16)A;        [In(line)] internal static u16 u16(f64 A) => (u16)A;

    [In(line)] internal static s32 s32( s8 A) => (s32)A;        [In(line)] internal static u32 u32( s8 A) => (u32)A;
    [In(line)] internal static s32 s32( u8 A) => (s32)A;        [In(line)] internal static u32 u32( u8 A) => (u32)A;
    [In(line)] internal static s32 s32(s16 A) => (s32)A;        [In(line)] internal static u32 u32(s16 A) => (u32)A;
    [In(line)] internal static s32 s32(u16 A) => (s32)A;        [In(line)] internal static u32 u32(u16 A) => (u32)A;
    [In(line)] internal static s32 s32(u32 A) => (s32)A;        [In(line)] internal static u32 u32(s32 A) => (u32)A;
    [In(line)] internal static s32 s32(s64 A) => (s32)A;        [In(line)] internal static u32 u32(s64 A) => (u32)A;
    [In(line)] internal static s32 s32(u64 A) => (s32)A;        [In(line)] internal static u32 u32(u64 A) => (u32)A;
    [In(line)] internal static s32 s32(f32 A) => (s32)A;        [In(line)] internal static u32 u32(f32 A) => (u32)A;
    [In(line)] internal static s32 s32(f64 A) => (s32)A;        [In(line)] internal static u32 u32(f64 A) => (u32)A;

    [In(line)] internal static s64 s64( s8 A) => (s64)A;        [In(line)] internal static u64 u64( s8 A) => (u64)A;
    [In(line)] internal static s64 s64( u8 A) => (s64)A;        [In(line)] internal static u64 u64( u8 A) => (u64)A;
    [In(line)] internal static s64 s64(s16 A) => (s64)A;        [In(line)] internal static u64 u64(s16 A) => (u64)A;
    [In(line)] internal static s64 s64(u16 A) => (s64)A;        [In(line)] internal static u64 u64(u16 A) => (u64)A;
    [In(line)] internal static s64 s64(s32 A) => (s64)A;        [In(line)] internal static u64 u64(s32 A) => (u64)A;
    [In(line)] internal static s64 s64(u32 A) => (s64)A;        [In(line)] internal static u64 u64(u32 A) => (u64)A;
    [In(line)] internal static s64 s64(u64 A) => (s64)A;        [In(line)] internal static u64 u64(s64 A) => (u64)A;
    [In(line)] internal static s64 s64(f32 A) => (s64)A;        [In(line)] internal static u64 u64(f32 A) => (u64)A;
    [In(line)] internal static s64 s64(f64 A) => (s64)A;        [In(line)] internal static u64 u64(f64 A) => (u64)A;

    //==========================================================================================================================================================
    [In(line)] internal static f32 f32( s8 A) => (f32)A;
    [In(line)] internal static f32 f32( u8 A) => (f32)A;
    [In(line)] internal static f32 f32(s16 A) => (f32)A;
    [In(line)] internal static f32 f32(u16 A) => (f32)A;
    [In(line)] internal static f32 f32(s32 A) => (f32)A;
    [In(line)] internal static f32 f32(u32 A) => (f32)A;
    [In(line)] internal static f32 f32(s64 A) => (f32)A;
    [In(line)] internal static f32 f32(u64 A) => (f32)A;
    [In(line)] internal static f32 f32(f64 A) => (f32)A;

    [In(line)] internal static f64 f64( s8 A) => (f64)A;
    [In(line)] internal static f64 f64( u8 A) => (f64)A;
    [In(line)] internal static f64 f64(s16 A) => (f64)A;
    [In(line)] internal static f64 f64(u16 A) => (f64)A;
    [In(line)] internal static f64 f64(s32 A) => (f64)A;
    [In(line)] internal static f64 f64(u32 A) => (f64)A;
    [In(line)] internal static f64 f64(s64 A) => (f64)A;
    [In(line)] internal static f64 f64(u64 A) => (f64)A;
    [In(line)] internal static f64 f64(f32 A) => (f64)A;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
