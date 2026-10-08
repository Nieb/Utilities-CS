
namespace Utility;
internal static partial class DATA {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct Data64 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public f64 F = default;
    [FieldOffset(0)] public s64 I = default;
    [FieldOffset(0)] public u64 U = default;

    //==========================================================================================================================================================
    [In(line)] public override string ToString() => $"[F:{this.F,9}  I:{this.I,11}  U:{this.U,11}]";

    //==========================================================================================================================================================
    [In(line)] public Data64() {}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [In(line)] public static implicit operator Data64(f64 F) => new Data64(){F = F}; //  double  to  Data64
    [In(line)] public static implicit operator Data64(s64 I) => new Data64(){I = I}; //    long  to  Data64
    [In(line)] public static implicit operator Data64(u64 U) => new Data64(){U = U}; //   ulong  to  Data64

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [In(line)] public static f64 operator +(Data64 A, f64 B) => (A.F + B);
    [In(line)] public static s64 operator +(Data64 A, s64 B) => (A.I + B);
    [In(line)] public static u64 operator +(Data64 A, u64 B) => (A.U + B);

    [In(line)] public static f64 operator -(Data64 A, f64 B) => (A.F - B);
    [In(line)] public static s64 operator -(Data64 A, s64 B) => (A.I - B);
    [In(line)] public static u64 operator -(Data64 A, u64 B) => (A.U - B);

  //[In(line)] public static f64 operator -(Data64 A) => -A.F;
  //[In(line)] public static s64 operator -(Data64 A) => -A.I;

    [In(line)] public static f64 operator *(Data64 A, f64 B) => (A.F * B);
    [In(line)] public static s64 operator *(Data64 A, s64 B) => (A.I * B);
    [In(line)] public static u64 operator *(Data64 A, u64 B) => (A.U * B);

    [In(line)] public static f64 operator /(Data64 A, f64 B) => (A.F / B);
    [In(line)] public static s64 operator /(Data64 A, s64 B) => (A.I / B);
    [In(line)] public static u64 operator /(Data64 A, u64 B) => (A.U / B);

    [In(line)] public static f64 operator %(Data64 A, f64 B) => (A.F % B);
    [In(line)] public static s64 operator %(Data64 A, s64 B) => (A.I % B);
    [In(line)] public static u64 operator %(Data64 A, u64 B) => (A.U % B);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    [In(line)] public static u64 operator ~(Data64 A) => (~A.U);

    [In(line)] public static u64 operator &(Data64 A, Data64 B) => (A.U & B.U);
    [In(line)] public static u64 operator &(Data64 A,    u64 B) => (A.U & B  );
    [In(line)] public static u64 operator &(   u64 A, Data64 B) => (A   & B.U);

    [In(line)] public static u64 operator |(Data64 A, Data64 B) => (A.U | B.U);
    [In(line)] public static u64 operator |(Data64 A,    u64 B) => (A.U | B  );
    [In(line)] public static u64 operator |(   u64 A, Data64 B) => (A   | B.U);

    [In(line)] public static u64 operator ^(Data64 A, Data64 B) => (A.U ^ B.U);
    [In(line)] public static u64 operator ^(Data64 A,    u64 B) => (A.U ^ B  );
    [In(line)] public static u64 operator ^(   u64 A, Data64 B) => (A   ^ B.U);

    [In(line)] public static u64 operator <<(Data64 A, int n)  => (A.U << n);
    [In(line)] public static u64 operator >>(Data64 A, int n)  => (A.U >> n);

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [In(line)] public static bool operator ==(Data64 A, f64 B) => (A.F == B);
    [In(line)] public static bool operator ==(Data64 A, s64 B) => (A.I == B);
    [In(line)] public static bool operator ==(Data64 A, u64 B) => (A.U == B);

    [In(line)] public static bool operator !=(Data64 A, f64 B) => (A.F != B);
    [In(line)] public static bool operator !=(Data64 A, s64 B) => (A.I != B);
    [In(line)] public static bool operator !=(Data64 A, u64 B) => (A.U != B);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] public static bool operator  <(Data64 A, f64 B) => (A.F <  B);
    [In(line)] public static bool operator  <(Data64 A, s64 B) => (A.I <  B);
    [In(line)] public static bool operator  <(Data64 A, u64 B) => (A.U <  B);

    [In(line)] public static bool operator  >(Data64 A, f64 B) => (A.F >  B);
    [In(line)] public static bool operator  >(Data64 A, s64 B) => (A.I >  B);
    [In(line)] public static bool operator  >(Data64 A, u64 B) => (A.U >  B);

    [In(line)] public static bool operator <=(Data64 A, f64 B) => (A.F <= B);
    [In(line)] public static bool operator <=(Data64 A, s64 B) => (A.I <= B);
    [In(line)] public static bool operator <=(Data64 A, u64 B) => (A.U <= B);

    [In(line)] public static bool operator >=(Data64 A, f64 B) => (A.F >= B);
    [In(line)] public static bool operator >=(Data64 A, s64 B) => (A.I >= B);
    [In(line)] public static bool operator >=(Data64 A, u64 B) => (A.U >= B);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
