
namespace Utility;
internal static partial class DATA {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct Data32 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public f32 F = default;
    [FieldOffset(0)] public s32 I = default;
    [FieldOffset(0)] public u32 U = default;

    //==========================================================================================================================================================
    [In(line)] public override string ToString() => $"[F:{this.F,9}  I:{this.I,11}  U:{this.U,11}]";

    //==========================================================================================================================================================
    [In(line)] public Data32() {}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [In(line)] public static implicit operator Data32(f32 F) => new Data32(){F = F}; //  float  to  Data32
    [In(line)] public static implicit operator Data32(s32 I) => new Data32(){I = I}; //    int  to  Data32
    [In(line)] public static implicit operator Data32(u32 U) => new Data32(){U = U}; //   uint  to  Data32

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [In(line)] public static f32 operator +(Data32 A, f32 B) => (A.F + B);
    [In(line)] public static s32 operator +(Data32 A, s32 B) => (A.I + B);
    [In(line)] public static u32 operator +(Data32 A, u32 B) => (A.U + B);

    [In(line)] public static f32 operator -(Data32 A, f32 B) => (A.F - B);
    [In(line)] public static s32 operator -(Data32 A, s32 B) => (A.I - B);
    [In(line)] public static u32 operator -(Data32 A, u32 B) => (A.U - B);

  //[In(line)] public static f32 operator -(Data32 A) => -A.F;
  //[In(line)] public static s32 operator -(Data32 A) => -A.I;

    [In(line)] public static f32 operator *(Data32 A, f32 B) => (A.F * B);
    [In(line)] public static s32 operator *(Data32 A, s32 B) => (A.I * B);
    [In(line)] public static u32 operator *(Data32 A, u32 B) => (A.U * B);

    [In(line)] public static f32 operator /(Data32 A, f32 B) => (A.F / B);
    [In(line)] public static s32 operator /(Data32 A, s32 B) => (A.I / B);
    [In(line)] public static u32 operator /(Data32 A, u32 B) => (A.U / B);

    [In(line)] public static f32 operator %(Data32 A, f32 B) => (A.F % B);
    [In(line)] public static s32 operator %(Data32 A, s32 B) => (A.I % B);
    [In(line)] public static u32 operator %(Data32 A, u32 B) => (A.U % B);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    [In(line)] public static u32 operator ~(Data32 A) => (~A.U);

    [In(line)] public static u32 operator &(Data32 A, Data32 B) => (A.U & B.U);
    [In(line)] public static u32 operator &(Data32 A,    u32 B) => (A.U & B  );
    [In(line)] public static u32 operator &(   u32 A, Data32 B) => (A   & B.U);

    [In(line)] public static u32 operator |(Data32 A, Data32 B) => (A.U | B.U);
    [In(line)] public static u32 operator |(Data32 A,    u32 B) => (A.U | B  );
    [In(line)] public static u32 operator |(   u32 A, Data32 B) => (A   | B.U);

    [In(line)] public static u32 operator ^(Data32 A, Data32 B) => (A.U ^ B.U);
    [In(line)] public static u32 operator ^(Data32 A,    u32 B) => (A.U ^ B  );
    [In(line)] public static u32 operator ^(   u32 A, Data32 B) => (A   ^ B.U);

    [In(line)] public static u32 operator <<(Data32 A, int n)  => (A.U << n);
    [In(line)] public static u32 operator >>(Data32 A, int n)  => (A.U >> n);

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [In(line)] public static bool operator ==(Data32 A, f32 B) => (A.F == B);
    [In(line)] public static bool operator ==(Data32 A, s32 B) => (A.I == B);
    [In(line)] public static bool operator ==(Data32 A, u32 B) => (A.U == B);

    [In(line)] public static bool operator !=(Data32 A, f32 B) => (A.F != B);
    [In(line)] public static bool operator !=(Data32 A, s32 B) => (A.I != B);
    [In(line)] public static bool operator !=(Data32 A, u32 B) => (A.U != B);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] public static bool operator  <(Data32 A, f32 B) => (A.F <  B);
    [In(line)] public static bool operator  <(Data32 A, s32 B) => (A.I <  B);
    [In(line)] public static bool operator  <(Data32 A, u32 B) => (A.U <  B);

    [In(line)] public static bool operator  >(Data32 A, f32 B) => (A.F >  B);
    [In(line)] public static bool operator  >(Data32 A, s32 B) => (A.I >  B);
    [In(line)] public static bool operator  >(Data32 A, u32 B) => (A.U >  B);

    [In(line)] public static bool operator <=(Data32 A, f32 B) => (A.F <= B);
    [In(line)] public static bool operator <=(Data32 A, s32 B) => (A.I <= B);
    [In(line)] public static bool operator <=(Data32 A, u32 B) => (A.U <= B);

    [In(line)] public static bool operator >=(Data32 A, f32 B) => (A.F >= B);
    [In(line)] public static bool operator >=(Data32 A, s32 B) => (A.I >= B);
    [In(line)] public static bool operator >=(Data32 A, u32 B) => (A.U >= B);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
