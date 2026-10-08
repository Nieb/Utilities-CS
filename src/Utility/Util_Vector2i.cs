using Vector2 = System.Numerics.Vector2;    using float2 = (float x, float y);                      using int2 = (int x, int y);
using Vector3 = System.Numerics.Vector3;    using float3 = (float x, float y, float z);             using int3 = (int x, int y, int z);
using Vector4 = System.Numerics.Vector4;    using float4 = (float x, float y, float z, float w);    using int4 = (int x, int y, int z, int w);

namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec2 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public int x;                                              [FieldOffset(0)] public int u;
    [FieldOffset(4)] public int y;                                              [FieldOffset(4)] public int v;

    //==========================================================================================================================================================
    public ivec2 xy {get => this;            set => this=value;}

    public ivec2 yx {get => new ivec2(y,x);  set {x=value.y; y=value.x;}}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public ivec3 xy_ => new ivec3(x,y,0);
    public ivec3 x_y => new ivec3(x,0,y);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] public ivec2() {}
    [In(line)] public ivec2(int X, int Y) {x=X; y=Y;}
    [In(line)] public ivec2(int V       ) {x=V; y=V;}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [In(line)] public static implicit operator   ivec2(int[] V) => new   ivec2(V[0],V[1]); //     int[2]  to  ivec2
    [In(line)] public static implicit operator Vector2(ivec2 V) => new Vector2( V.x, V.y); //      ivec2  to  Vector2

    [In(line)] public static implicit operator   ivec2( int2 T) => new   ivec2( T.x, T.y); //  (int,int)  to  ivec2
  //[In(line)] public static implicit operator    int2(ivec2 V) =>            ( V.x, V.y); //      ivec2  to  (int,int)

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [In(line)] public static ivec2 operator +(ivec2 A, ivec2 B) => new ivec2(A.x+B.x, A.y+B.y);
    [In(line)] public static ivec2 operator +(ivec2 A, int   B) => new ivec2(A.x+B  , A.y+B  );
    [In(line)] public static ivec2 operator +(int   A, ivec2 B) => new ivec2(A  +B.x, A  +B.y);

    [In(line)] public static ivec2 operator -(ivec2 A, ivec2 B) => new ivec2(A.x-B.x, A.y-B.y);
    [In(line)] public static ivec2 operator -(ivec2 A, int   B) => new ivec2(A.x-B  , A.y-B  );
    [In(line)] public static ivec2 operator -(int   A, ivec2 B) => new ivec2(A  -B.x, A  -B.y);

    [In(line)] public static ivec2 operator -(ivec2 A)          => new ivec2(   -A.x,    -A.y);

    [In(line)] public static ivec2 operator *(ivec2 A, ivec2 B) => new ivec2(A.x*B.x, A.y*B.y);
    [In(line)] public static ivec2 operator *(ivec2 A, int   B) => new ivec2(A.x*B  , A.y*B  );
    [In(line)] public static ivec2 operator *(int   A, ivec2 B) => new ivec2(A  *B.x, A  *B.y);

    [In(line)] public static ivec2 operator /(ivec2 A, ivec2 B) => new ivec2(A.x/B.x, A.y/B.y);
    [In(line)] public static ivec2 operator /(ivec2 A, int   B) => new ivec2(A.x/B  , A.y/B  );
    [In(line)] public static ivec2 operator /(int   A, ivec2 B) => new ivec2(A  /B.x, A  /B.y);

    [In(line)] public static ivec2 operator %(ivec2 A, ivec2 B) => new ivec2(A.x%B.x, A.y%B.y);
    [In(line)] public static ivec2 operator %(ivec2 A, int   B) => new ivec2(A.x%B  , A.y%B  );
    [In(line)] public static ivec2 operator %(int   A, ivec2 B) => new ivec2(A  %B.x, A  %B.y);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] public static  vec2 operator +(ivec2 A, float B) => new  vec2(A.x+B  , A.y+B  );
    [In(line)] public static  vec2 operator +(float A, ivec2 B) => new  vec2(A  +B.x, A  +B.y);

    [In(line)] public static  vec2 operator -(ivec2 A, float B) => new  vec2(A.x-B  , A.y-B  );
    [In(line)] public static  vec2 operator -(float A, ivec2 B) => new  vec2(A  -B.x, A  -B.y);

    [In(line)] public static  vec2 operator *(ivec2 A, float B) => new  vec2(A.x*B  , A.y*B  );
    [In(line)] public static  vec2 operator *(float A, ivec2 B) => new  vec2(A  *B.x, A  *B.y);

    [In(line)] public static  vec2 operator /(ivec2 A, float B) => new  vec2(A.x/B  , A.y/B  );
    [In(line)] public static  vec2 operator /(float A, ivec2 B) => new  vec2(A  /B.x, A  /B.y);

    [In(line)] public static  vec2 operator %(ivec2 A, float B) => new  vec2(A.x%B  , A.y%B  );
    [In(line)] public static  vec2 operator %(float A, ivec2 B) => new  vec2(A  %B.x, A  %B.y);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [In(line)] public static bool operator ==(ivec2 A, ivec2 B) => (A.x==B.x && A.y==B.y);
    [In(line)] public static bool operator ==(ivec2 A, int   B) => (A.x==B   && A.y==B  );

    [In(line)] public static bool operator !=(ivec2 A, ivec2 B) => (A.x!=B.x || A.y!=B.y);
    [In(line)] public static bool operator !=(ivec2 A, int   B) => (A.x!=B   || A.y!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] public static bool operator  <(ivec2 A, ivec2 B) => (A.x< B.x && A.y< B.y);
    [In(line)] public static bool operator  <(ivec2 A, int   B) => (A.x< B   && A.y< B  );

    [In(line)] public static bool operator  >(ivec2 A, ivec2 B) => (A.x> B.x && A.y> B.y);
    [In(line)] public static bool operator  >(ivec2 A, int   B) => (A.x> B   && A.y> B  );

    [In(line)] public static bool operator <=(ivec2 A, ivec2 B) => (A.x<=B.x && A.y<=B.y);
    [In(line)] public static bool operator <=(ivec2 A, int   B) => (A.x<=B   && A.y<=B  );

    [In(line)] public static bool operator >=(ivec2 A, ivec2 B) => (A.x>=B.x && A.y>=B.y);
    [In(line)] public static bool operator >=(ivec2 A, int   B) => (A.x>=B   && A.y>=B  );

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

        return $"({X},{Y})";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,3},{this.y,3})";

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
