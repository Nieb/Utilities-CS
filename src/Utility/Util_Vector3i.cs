using VEC2 = System.Numerics.Vector2;
using VEC3 = System.Numerics.Vector3;
using VEC4 = System.Numerics.Vector4;

namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec3 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public int x;      [FieldOffset(0)] public int r;
    [FieldOffset(4)] public int y;      [FieldOffset(4)] public int g;
    [FieldOffset(8)] public int z;      [FieldOffset(8)] public int b;

    //==========================================================================================================================================================
    [FieldOffset(0)] public ivec2 xy;
    [FieldOffset(4)] public ivec2 yz;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public ivec2 xz  {get => new ivec2(x,z);    set {x=value.x; z=value.y;}}
    public ivec2 zy  {get => new ivec2(z,y);    set {z=value.x; y=value.y;}}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public ivec3 xzy {get => new ivec3(x,z,y);  set {x=value.x; z=value.y; y=value.z;}}
    public ivec3 zyx {get => new ivec3(z,y,x);  set {z=value.x; y=value.y; x=value.z;}}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public ivec4 xyz_ => new ivec4(x,y,z,0);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] public ivec3() {}
    [Impl(AggressiveInlining)] public ivec3(i1 X, i1 Y, i1 Z) {x=X; y=Y; z=Z;}
    [Impl(AggressiveInlining)] public ivec3(i1 V            ) {x=V; y=V; z=V;}

    [Impl(AggressiveInlining)] public ivec3(v3 V            ) {x=RoundToInt(V.x); y=RoundToInt(V.y); z=RoundToInt(V.z);}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [Impl(AggressiveInlining)] public static implicit operator ivec3(int[] V) => new ivec3(V[0],V[1],V[2]); //         int[3]  to  ivec3
    [Impl(AggressiveInlining)] public static implicit operator ivec3(   I3 T) => new ivec3( T.x, T.y, T.z); //  (int,int,int)  to  ivec3
  //[Impl(AggressiveInlining)] public static implicit operator    I3(ivec3 V) =>          ( V.x, V.y, V.z); //          ivec3  to  (int,int,int)

    [Impl(AggressiveInlining)] public static implicit operator  VEC3(ivec3 V) => new  VEC3( V.x, V.y, V.z); //          ivec3  to  Vector3

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining)] public static ivec3 operator +(ivec3 A, ivec3 B) => new ivec3(A.x+B.x, A.y+B.y, A.z+B.z);
    [Impl(AggressiveInlining)] public static ivec3 operator +(ivec3 A, int   B) => new ivec3(A.x+B  , A.y+B  , A.z+B  );
    [Impl(AggressiveInlining)] public static ivec3 operator +(int   A, ivec3 B) => new ivec3(A  +B.x, A  +B.y, A  +B.z);

    [Impl(AggressiveInlining)] public static ivec3 operator -(ivec3 A, ivec3 B) => new ivec3(A.x-B.x, A.y-B.y, A.z-B.z);
    [Impl(AggressiveInlining)] public static ivec3 operator -(ivec3 A, int   B) => new ivec3(A.x-B  , A.y-B  , A.z-B  );
    [Impl(AggressiveInlining)] public static ivec3 operator -(int   A, ivec3 B) => new ivec3(A  -B.x, A  -B.y, A  -B.z);

    [Impl(AggressiveInlining)] public static ivec3 operator -(ivec3 A)          => new ivec3(   -A.x,    -A.y,    -A.z);

    [Impl(AggressiveInlining)] public static ivec3 operator *(ivec3 A, ivec3 B) => new ivec3(A.x*B.x, A.y*B.y, A.z*B.z);
    [Impl(AggressiveInlining)] public static ivec3 operator *(ivec3 A, int   B) => new ivec3(A.x*B  , A.y*B  , A.z*B  );
    [Impl(AggressiveInlining)] public static ivec3 operator *(int   A, ivec3 B) => new ivec3(A  *B.x, A  *B.y, A  *B.z);

    [Impl(AggressiveInlining)] public static ivec3 operator /(ivec3 A, ivec3 B) => new ivec3(A.x/B.x, A.y/B.y, A.z/B.z);
    [Impl(AggressiveInlining)] public static ivec3 operator /(ivec3 A, int   B) => new ivec3(A.x/B  , A.y/B  , A.z/B  );
    [Impl(AggressiveInlining)] public static ivec3 operator /(int   A, ivec3 B) => new ivec3(A  /B.x, A  /B.y, A  /B.z);

    [Impl(AggressiveInlining)] public static ivec3 operator %(ivec3 A, ivec3 B) => new ivec3(A.x%B.x, A.y%B.y, A.z%B.z);
    [Impl(AggressiveInlining)] public static ivec3 operator %(ivec3 A, int   B) => new ivec3(A.x%B  , A.y%B  , A.z%B  );
    [Impl(AggressiveInlining)] public static ivec3 operator %(int   A, ivec3 B) => new ivec3(A  %B.x, A  %B.y, A  %B.z);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(ivec3 A, ivec3 B) => (A.x==B.x && A.y==B.y && A.z==B.z);
    [Impl(AggressiveInlining)] public static bool operator ==(ivec3 A, int   B) => (A.x==B   && A.y==B   && A.z==B  );

    [Impl(AggressiveInlining)] public static bool operator !=(ivec3 A, ivec3 B) => (A.x!=B.x || A.y!=B.y || A.z!=B.z);
    [Impl(AggressiveInlining)] public static bool operator !=(ivec3 A, int   B) => (A.x!=B   || A.y!=B   || A.z!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] public static bool operator  <(ivec3 A, ivec3 B) => (A.x< B.x && A.y< B.y && A.z< B.z);
    [Impl(AggressiveInlining)] public static bool operator  <(ivec3 A, int   B) => (A.x< B   && A.y< B   && A.z< B  );

    [Impl(AggressiveInlining)] public static bool operator  >(ivec3 A, ivec3 B) => (A.x> B.x && A.y> B.y && A.z> B.z);
    [Impl(AggressiveInlining)] public static bool operator  >(ivec3 A, int   B) => (A.x> B   && A.y> B   && A.z> B  );

    [Impl(AggressiveInlining)] public static bool operator <=(ivec3 A, ivec3 B) => (A.x<=B.x && A.y<=B.y && A.z<=B.z);
    [Impl(AggressiveInlining)] public static bool operator <=(ivec3 A, int   B) => (A.x<=B   && A.y<=B   && A.z<=B  );

    [Impl(AggressiveInlining)] public static bool operator >=(ivec3 A, ivec3 B) => (A.x>=B.x && A.y>=B.y && A.z>=B.z);
    [Impl(AggressiveInlining)] public static bool operator >=(ivec3 A, int   B) => (A.x>=B   && A.y>=B   && A.z>=B  );

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

        return $"({X},{Y},{Z})";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,3},{this.y,3},{this.z,3})";

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
