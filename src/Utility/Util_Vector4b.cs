
namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct bvec4 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "bvec4" is interoperable-ish with "uint" via implicit operators.
    //
    //      0xXxYyZzWw   (X, Y, Z, W)
    //      0xRrGgBbAa   (Red, Green, Blue, Alpha)
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(3)] public u8 x;  [FieldOffset(3)] public u8 r;
    [FieldOffset(2)] public u8 y;  [FieldOffset(2)] public u8 g;
    [FieldOffset(1)] public u8 z;  [FieldOffset(1)] public u8 b;
    [FieldOffset(0)] public u8 w;  [FieldOffset(0)] public u8 a;    [FieldOffset(0)] private u32 U;

    public uint ABGR => ByteFlip(this.U);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] public bvec4() {}
    [In(line)] public bvec4(u8 X, u8 Y, u8 Z, u8 W) {x=X; y=Y; z=Z; w=W;}
    [In(line)] public bvec4(u32 XYZW)               {U = XYZW;}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [In(line)] public static implicit operator   u32(                   bvec4 A) => A.U;                        //                  bvec4  to  uint
    [In(line)] public static implicit operator bvec4(                   u32   A) => new bvec4(A);               //                   uint  to  bvec4

    [In(line)] public static implicit operator bvec4((u8 x, u8 y, u8 z, u8 w) T) => new bvec4(T.x,T.y,T.z,T.w); //  (byte,byte,byte,byte)  to  bvec4

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [In(line)] public static bvec4 operator +(bvec4 A, bvec4 B) => new bvec4(ClampToByte(A.x+B.x),ClampToByte(A.y+B.y),ClampToByte(A.z+B.z),ClampToByte(A.w+B.w));

    [In(line)] public static bvec4 operator -(bvec4 A, bvec4 B) => new bvec4(ClampToByte(A.x-B.x),ClampToByte(A.y-B.y),ClampToByte(A.z-B.z),ClampToByte(A.w-B.w));

    [In(line)] public static bvec4 operator *(bvec4 A, bvec4 B) => new bvec4(ClampToByte(A.x*B.x),ClampToByte(A.y*B.y),ClampToByte(A.z*B.z),ClampToByte(A.w*B.w));

    [In(line)] public static bvec4 operator /(bvec4 A, bvec4 B) => new bvec4(ClampToByte(A.x/B.x),ClampToByte(A.y/B.y),ClampToByte(A.z/B.z),ClampToByte(A.w/B.w));

    [In(line)] public static bvec4 operator %(bvec4 A, bvec4 B) => new bvec4(ClampToByte(A.x%B.x),ClampToByte(A.y%B.y),ClampToByte(A.z%B.z),ClampToByte(A.w%B.w));

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    [In(line)] public static bvec4 operator ~(bvec4 A)          => (~A.U);

    [In(line)] public static bvec4 operator &(bvec4 A, bvec4 B) => (A.U & B.U);
    [In(line)] public static bvec4 operator &(bvec4 A, uint  B) => (A.U & B  );
    [In(line)] public static bvec4 operator &(uint  A, bvec4 B) => (A   & B.U);

    [In(line)] public static bvec4 operator |(bvec4 A, bvec4 B) => (A.U | B.U);
    [In(line)] public static bvec4 operator |(bvec4 A, uint  B) => (A.U | B  );
    [In(line)] public static bvec4 operator |(uint  A, bvec4 B) => (A   | B.U);

    [In(line)] public static bvec4 operator ^(bvec4 A, bvec4 B) => (A.U ^ B.U);
    [In(line)] public static bvec4 operator ^(bvec4 A, uint  B) => (A.U ^ B  );
    [In(line)] public static bvec4 operator ^(uint  A, bvec4 B) => (A   ^ B.U);

    [In(line)] public static bvec4 operator <<(bvec4 A, int n)  => (A.U << n);
    [In(line)] public static bvec4 operator >>(bvec4 A, int n)  => (A.U >> n);

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [In(line)] public static bool operator ==(bvec4 A, bvec4 B) => (A.U == B.U);
    [In(line)] public static bool operator ==(bvec4 A, uint  B) => (A.U == B  );
    [In(line)] public static bool operator ==(uint  A, bvec4 B) => (A   == B.U);

    [In(line)] public static bool operator !=(bvec4 A, bvec4 B) => (A.U != B.U);
    [In(line)] public static bool operator !=(bvec4 A, uint  B) => (A.U != B  );
    [In(line)] public static bool operator !=(uint  A, bvec4 B) => (A   != B.U);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly string ToString(string FormatStr, System.IFormatProvider FormatProvider) {
        _ = FormatProvider;
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length;

        string X = this.x.ToString(FormatStr).PadLeft(Padding);
        string Y = this.y.ToString(FormatStr).PadLeft(Padding);
        string Z = this.z.ToString(FormatStr).PadLeft(Padding);
        string W = this.w.ToString(FormatStr).PadLeft(Padding);

        return $"({X},{Y},{Z},{W})";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,3},{this.y,3},{this.z,3},{this.w,3})";

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
