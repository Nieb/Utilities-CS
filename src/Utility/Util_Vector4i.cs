using VEC2 = System.Numerics.Vector2;
using VEC3 = System.Numerics.Vector3;
using VEC4 = System.Numerics.Vector4;

namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec4 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public int x;         [FieldOffset( 0)] public int r;
    [FieldOffset( 4)] public int y;         [FieldOffset( 4)] public int g;
    [FieldOffset( 8)] public int z;         [FieldOffset( 8)] public int b;
    [FieldOffset(12)] public int w;         [FieldOffset(12)] public int a;

    //==========================================================================================================================================================
    [FieldOffset( 0)] public ivec3 xyz;     [FieldOffset( 0)] public ivec3 rgb;

    [FieldOffset( 0)] public ivec2 xy;
    [FieldOffset( 4)] public ivec2 yz;
    [FieldOffset( 8)] public ivec2 zw;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public ivec2 xz {get => new ivec2(x,z);  set {x=value.x; z=value.y;}}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] public ivec4() {}
    [Impl(AggressiveInlining)] public ivec4(i1 X, i1 Y, i1 Z, i1 W) {x=X; y=Y; z=Z; w=W;}
    [Impl(AggressiveInlining)] public ivec4(i1 V                  ) {x=V; y=V; z=V; w=V;}

    [Impl(AggressiveInlining)] public ivec4(i2 vA     , i2 vB     ) {x=vA.x; y=vA.y; z=vB.x; w=vB.y;}
    [Impl(AggressiveInlining)] public ivec4(i3 V            , i1 W) {x=V.x;  y=V.y;  z=V.z;  w=W;   }

    [Impl(AggressiveInlining)] public ivec4(v4 V                  ) {x=RoundToInt(V.x); y=RoundToInt(V.y); z=RoundToInt(V.z); w=RoundToInt(V.w);}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [Impl(AggressiveInlining)] public static implicit operator ivec4(       int[] V) => new ivec4( V[0], V[1], V[2], V[3]); //             int[4]  to  ivec4
    [Impl(AggressiveInlining)] public static implicit operator ivec4(          I4 T) => new ivec4(  T.x,  T.y,  T.z,  T.w); //  (int,int,int,int)  to  ivec4
  //[Impl(AggressiveInlining)] public static implicit operator    I4(        vec4 V) =>          (  V.x,  V.y,  V.z,  V.w); //              ivec4  to  (int,int,int,int)
    [Impl(AggressiveInlining)] public static implicit operator ivec4((i2 A, i2 B) T) => new ivec4(T.A.x,T.A.y,T.B.x,T.B.y); //      (ivec2,ivec2)  to  ivec4
    [Impl(AggressiveInlining)] public static implicit operator ivec4((i3 V, i1 w) T) => new ivec4(T.V.x,T.V.y,T.V.z,  T.w); //        (ivec3,int)  to  ivec4

    [Impl(AggressiveInlining)] public static implicit operator  VEC4(       ivec4 V) => new  VEC4(  V.x,  V.y,  V.z,  V.w); //              ivec4  to  Vector4

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining)] public static ivec4 operator +(ivec4 A, ivec4 B) => new ivec4(A.x+B.x, A.y+B.y, A.z+B.z, A.w+B.w);
    [Impl(AggressiveInlining)] public static ivec4 operator +(ivec4 A, int   B) => new ivec4(A.x+B  , A.y+B  , A.z+B  , A.w+B  );
    [Impl(AggressiveInlining)] public static ivec4 operator +(int   A, ivec4 B) => new ivec4(A  +B.x, A  +B.y, A  +B.z, A  +B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator -(ivec4 A, ivec4 B) => new ivec4(A.x-B.x, A.y-B.y, A.z-B.z, A.w-B.w);
    [Impl(AggressiveInlining)] public static ivec4 operator -(ivec4 A, int   B) => new ivec4(A.x-B  , A.y-B  , A.z-B  , A.w-B  );
    [Impl(AggressiveInlining)] public static ivec4 operator -(int   A, ivec4 B) => new ivec4(A  -B.x, A  -B.y, A  -B.z, A  -B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator -(ivec4 A)          => new ivec4(   -A.x,    -A.y,    -A.z,    -A.w);

    [Impl(AggressiveInlining)] public static ivec4 operator *(ivec4 A, ivec4 B) => new ivec4(A.x*B.x, A.y*B.y, A.z*B.z, A.w*B.w);
    [Impl(AggressiveInlining)] public static ivec4 operator *(ivec4 A, int   B) => new ivec4(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [Impl(AggressiveInlining)] public static ivec4 operator *(int   A, ivec4 B) => new ivec4(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator /(ivec4 A, ivec4 B) => new ivec4(A.x/B.x, A.y/B.y, A.z/B.z, A.w/B.w);
    [Impl(AggressiveInlining)] public static ivec4 operator /(ivec4 A, int   B) => new ivec4(A.x/B  , A.y/B  , A.z/B  , A.w/B  );
    [Impl(AggressiveInlining)] public static ivec4 operator /(int   A, ivec4 B) => new ivec4(A  /B.x, A  /B.y, A  /B.z, A  /B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator %(ivec4 A, ivec4 B) => new ivec4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w);
    [Impl(AggressiveInlining)] public static ivec4 operator %(ivec4 A, int   B) => new ivec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
    [Impl(AggressiveInlining)] public static ivec4 operator %(int   A, ivec4 B) => new ivec4(A  %B.x, A  %B.y, A  %B.z, A  %B.w);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(also shifts signed-bit)

    [Impl(AggressiveInlining)] public static ivec4 operator   ~(ivec4 A)          => new ivec4(   ~A.x,    ~A.y,    ~A.z,    ~A.w);

    [Impl(AggressiveInlining)] public static ivec4 operator   &(ivec4 A, ivec4 B) => new ivec4(A.x&B.x, A.y&B.y, A.z&B.z, A.w&B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator   |(ivec4 A, ivec4 B) => new ivec4(A.x|B.x, A.y|B.y, A.z|B.z, A.w|B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator   ^(ivec4 A, ivec4 B) => new ivec4(A.x^B.x, A.y^B.y, A.z^B.z, A.w^B.w);

    [Impl(AggressiveInlining)] public static ivec4 operator  <<(ivec4 A, int   n) => new ivec4(A.x <<n, A.y <<n, A.z <<n, A.w <<n);
    [Impl(AggressiveInlining)] public static ivec4 operator  >>(ivec4 A, int   n) => new ivec4(A.x >>n, A.y >>n, A.z >>n, A.w >>n);
    [Impl(AggressiveInlining)] public static ivec4 operator >>>(ivec4 A, int   n) => new ivec4(A.x>>>n, A.y>>>n, A.z>>>n, A.w>>>n);

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(ivec4 A, ivec4 B) => (A.x==B.x && A.y==B.y && A.z==B.z && A.w==B.w);
    [Impl(AggressiveInlining)] public static bool operator ==(ivec4 A, int   B) => (A.x==B   && A.y==B   && A.z==B   && A.w==B  );

    [Impl(AggressiveInlining)] public static bool operator !=(ivec4 A, ivec4 B) => (A.x!=B.x || A.y!=B.y || A.z!=B.z || A.w!=B.w);
    [Impl(AggressiveInlining)] public static bool operator !=(ivec4 A, int   B) => (A.x!=B   || A.y!=B   || A.z!=B   || A.w!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] public static bool operator  <(ivec4 A, ivec4 B) => (A.x< B.x && A.y< B.y && A.z< B.z && A.w< B.w);
    [Impl(AggressiveInlining)] public static bool operator  <(ivec4 A, int   B) => (A.x< B   && A.y< B   && A.z< B   && A.w< B  );

    [Impl(AggressiveInlining)] public static bool operator  >(ivec4 A, ivec4 B) => (A.x> B.x && A.y> B.y && A.z> B.z && A.w> B.w);
    [Impl(AggressiveInlining)] public static bool operator  >(ivec4 A, int   B) => (A.x> B   && A.y> B   && A.z> B   && A.w> B  );

    [Impl(AggressiveInlining)] public static bool operator <=(ivec4 A, ivec4 B) => (A.x<=B.x && A.y<=B.y && A.z<=B.z && A.w<=B.w);
    [Impl(AggressiveInlining)] public static bool operator <=(ivec4 A, int   B) => (A.x<=B   && A.y<=B   && A.z<=B   && A.w<=B  );

    [Impl(AggressiveInlining)] public static bool operator >=(ivec4 A, ivec4 B) => (A.x>=B.x && A.y>=B.y && A.z>=B.z && A.w>=B.w);
    [Impl(AggressiveInlining)] public static bool operator >=(ivec4 A, int   B) => (A.x>=B   && A.y>=B   && A.z>=B   && A.w>=B  );

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
