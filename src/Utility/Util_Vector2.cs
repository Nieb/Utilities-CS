using Vector2 = System.Numerics.Vector2;    using float2 = (float x, float y);                      using int2 = (int x, int y);
using Vector3 = System.Numerics.Vector3;    using float3 = (float x, float y, float z);             using int3 = (int x, int y, int z);
using Vector4 = System.Numerics.Vector4;    using float4 = (float x, float y, float z, float w);    using int4 = (int x, int y, int z, int w);

namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec2 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public float x;                                            [FieldOffset(0)] public float u;
    [FieldOffset(4)] public float y;                                            [FieldOffset(4)] public float v;

    //==========================================================================================================================================================
    public vec2 xy {get => this;           set => this=value;}

    public vec2 yx {get => new vec2(y,x);  set {x=value.y; y=value.x;}}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public vec3 xy_ => new vec3(x,y,0);
    public vec3 x_y => new vec3(x,0,y);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] public vec2() {}
    [In(line)] public vec2(float X, float Y) {x=X; y=Y;}
    [In(line)] public vec2(float V         ) {x=V; y=V;}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [In(line)] public static implicit operator    vec2(float[] V) => new    vec2(V[0],V[1]); //       float[2]  to  vec2
    [In(line)] public static implicit operator    vec2(  ivec2 V) => new    vec2( V.x, V.y); //          ivec2  to  vec2
    [In(line)] public static implicit operator Vector2(   vec2 V) => new Vector2( V.x, V.y); //           vec2  to  Vector2
    [In(line)] public static implicit operator    vec2(Vector2 v) => new    vec2( v.X, v.Y); //        Vector2  to  vec2

    [In(line)] public static implicit operator    vec2( float2 T) => new    vec2( T.x, T.y); //  (float,float)  to  vec2
  //[In(line)] public static implicit operator  float2(   vec2 V) =>            ( V.x, V.y); //           vec2  to  (float,float)

  //[In(line)] public static implicit operator Vector2( float2 T) => new    vec2( T.x, T.y); //  (float,float)  to  Vector2  :(

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [In(line)] public static vec2 operator +( vec2 A,  vec2 B) => new vec2(A.x+B.x, A.y+B.y);
    [In(line)] public static vec2 operator +( vec2 A, float B) => new vec2(A.x+B  , A.y+B  );
    [In(line)] public static vec2 operator +(float A,  vec2 B) => new vec2(A  +B.x, A  +B.y);

    [In(line)] public static vec2 operator -( vec2 A,  vec2 B) => new vec2(A.x-B.x, A.y-B.y);
    [In(line)] public static vec2 operator -( vec2 A, float B) => new vec2(A.x-B  , A.y-B  );
    [In(line)] public static vec2 operator -(float A,  vec2 B) => new vec2(A  -B.x, A  -B.y);

    [In(line)] public static vec2 operator -( vec2 A)          => new vec2(   -A.x,    -A.y);

    [In(line)] public static vec2 operator *( vec2 A,  vec2 B) => new vec2(A.x*B.x, A.y*B.y);
    [In(line)] public static vec2 operator *( vec2 A, float B) => new vec2(A.x*B  , A.y*B  );
    [In(line)] public static vec2 operator *(float A,  vec2 B) => new vec2(A  *B.x, A  *B.y);

    [In(line)] public static vec2 operator /( vec2 A,  vec2 B) => new vec2(A.x/B.x, A.y/B.y);
    [In(line)] public static vec2 operator /( vec2 A, float B) => new vec2(A.x/B  , A.y/B  );
    [In(line)] public static vec2 operator /(float A,  vec2 B) => new vec2(A  /B.x, A  /B.y);

    [In(line)] public static vec2 operator %( vec2 A,  vec2 B) => new vec2(A.x%B.x, A.y%B.y);
    [In(line)] public static vec2 operator %( vec2 A, float B) => new vec2(A.x%B  , A.y%B  );
    [In(line)] public static vec2 operator %(float A,  vec2 B) => new vec2(A  %B.x, A  %B.y);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [In(line)] public static bool operator ==( vec2 A,  vec2 B) => (A.x==B.x && A.y==B.y);
    [In(line)] public static bool operator ==( vec2 A, float B) => (A.x==B   && A.y==B  );

    [In(line)] public static bool operator !=( vec2 A,  vec2 B) => (A.x!=B.x || A.y!=B.y);
    [In(line)] public static bool operator !=( vec2 A, float B) => (A.x!=B   || A.y!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] public static bool operator  <( vec2 A,  vec2 B) => (A.x< B.x && A.y< B.y);
    [In(line)] public static bool operator  <( vec2 A, float B) => (A.x< B   && A.y< B  );

    [In(line)] public static bool operator  >( vec2 A,  vec2 B) => (A.x> B.x && A.y> B.y);
    [In(line)] public static bool operator  >( vec2 A, float B) => (A.x> B   && A.y> B  );

    [In(line)] public static bool operator <=( vec2 A,  vec2 B) => (A.x<=B.x && A.y<=B.y);
    [In(line)] public static bool operator <=( vec2 A, float B) => (A.x<=B   && A.y<=B  );

    [In(line)] public static bool operator >=( vec2 A,  vec2 B) => (A.x>=B.x && A.y>=B.y);
    [In(line)] public static bool operator >=( vec2 A, float B) => (A.x>=B   && A.y>=B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly string ToString(string FormatStr, System.IFormatProvider FormatProvider) {
        _ = FormatProvider;
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length+1;

        string X = this.x.ToString(FormatStr).PadLeft(Padding);
        string Y = this.y.ToString(FormatStr).PadLeft(Padding);

        return $"({X},{Y})";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,9:0.000000},{this.y,9:0.000000})";

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;  //  warning CS0660: 'T' defines operator == or != but does not override Object.Equals(object o)
    public readonly override int GetHashCode() => 0;            //  warning CS0661: 'T' defines operator == or != but does not override Object.GetHashCode()

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
