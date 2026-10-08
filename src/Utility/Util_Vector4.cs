using Vector2 = System.Numerics.Vector2;    using float2 = (float x, float y);                      using int2 = (int x, int y);
using Vector3 = System.Numerics.Vector3;    using float3 = (float x, float y, float z);             using int3 = (int x, int y, int z);
using Vector4 = System.Numerics.Vector4;    using float4 = (float x, float y, float z, float w);    using int4 = (int x, int y, int z, int w);

namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec4 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public float x;                                           [FieldOffset( 0)] public float r;
    [FieldOffset( 4)] public float y;                                           [FieldOffset( 4)] public float g;
    [FieldOffset( 8)] public float z;                                           [FieldOffset( 8)] public float b;
    [FieldOffset(12)] public float w;                                           [FieldOffset(12)] public float a;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [FieldOffset( 0)] public vec2 xy;                                           [FieldOffset( 0)] public vec2 rg;
    [FieldOffset( 4)] public vec2 yz;                                           [FieldOffset( 4)] public vec2 gb;
    [FieldOffset( 8)] public vec2 zw;                                           [FieldOffset( 8)] public vec2 ba;

    [FieldOffset( 0)] public vec3 xyz;                                          [FieldOffset( 0)] public vec3 rgb;
    [FieldOffset( 4)] public vec3 yzw;                                          [FieldOffset( 4)] public vec3 gba;

    //==========================================================================================================================================================
    public vec2 xz {get => new vec2(x,z);  set {x=value.x; z=value.y;}}
    public vec2 xw {get => new vec2(x,w);  set {x=value.x; w=value.y;}}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public vec4 xyzw {get => this;  set => this=value;}                         public vec4 rgba {get => this;  set => this=value;}

    public vec4 xyz_ => new vec4(x,y,z,0f);

    public vec4 xyz1 => new vec4(x,y,z,1f);
    public vec4 xzy1 => new vec4(x,z,y,1f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] public vec4() {}
    [In(line)] public vec4(float X, float Y, float Z, float W) {x=X; y=Y; z=Z; w=W;}
    [In(line)] public vec4(float V                           ) {x=V; y=V; z=V; w=V;}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [In(line)] public static implicit operator    vec4(     float[] V) => new    vec4( V[0], V[1], V[2], V[3]); //                   float[4]  to  vec4
    [In(line)] public static implicit operator    vec4(       ivec4 V) => new    vec4(  V.x,  V.y,  V.z,  V.w); //                      ivec4  to  vec4
    [In(line)] public static implicit operator Vector4(        vec4 V) => new Vector4(  V.x,  V.y,  V.z,  V.w); //                       vec4  to  Vector4
    [In(line)] public static implicit operator    vec4(     Vector4 v) => new    vec4(  v.X,  v.Y,  v.Z,  v.W); //                    Vector4  to  vec4

    [In(line)] public static implicit operator    vec4(      float4 T) => new    vec4(  T.x,  T.y,  T.z,  T.w); //  (float,float,float,float)  to  vec4
  //[In(line)] public static implicit operator  float4(        vec4 V) =>            (  V.x,  V.y,  V.z,  V.w); //                       vec4  to  (float,float,float,float)
    [In(line)] public static implicit operator    vec4((v2 A, v2 B) T) => new    vec4(T.A.x,T.A.y,T.B.x,T.B.y); //                (vec2,vec2)  to  vec4
    [In(line)] public static implicit operator    vec4((v3 V, v1 w) T) => new    vec4(T.V.x,T.V.y,T.V.z,  T.w); //               (vec3,float)  to  vec4

  //[In(line)] public static implicit operator Vector4(      float4 T) => new Vector4(  T.x,  T.y,  T.z,  T.w); //  (float,float,float,float)  to  Vector4  :(

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [In(line)] public static vec4 operator +(vec4  A, vec4  B) => new vec4(A.x+B.x, A.y+B.y, A.z+B.z, A.w+B.w);
    [In(line)] public static vec4 operator +(vec4  A, float B) => new vec4(A.x+B  , A.y+B  , A.z+B  , A.w+B  );
    [In(line)] public static vec4 operator +(float A, vec4  B) => new vec4(A  +B.x, A  +B.y, A  +B.z, A  +B.w);

    [In(line)] public static vec4 operator -(vec4  A, vec4  B) => new vec4(A.x-B.x, A.y-B.y, A.z-B.z, A.w-B.w);
    [In(line)] public static vec4 operator -(vec4  A, float B) => new vec4(A.x-B  , A.y-B  , A.z-B  , A.w-B  );
    [In(line)] public static vec4 operator -(float A, vec4  B) => new vec4(A  -B.x, A  -B.y, A  -B.z, A  -B.w);

    [In(line)] public static vec4 operator -(vec4 A)           => new vec4(   -A.x,    -A.y,    -A.z,    -A.w);

    [In(line)] public static vec4 operator *(vec4  A, vec4  B) => new vec4(A.x*B.x, A.y*B.y, A.z*B.z, A.w*B.w);
    [In(line)] public static vec4 operator *(vec4  A, float B) => new vec4(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [In(line)] public static vec4 operator *(float A, vec4  B) => new vec4(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [In(line)] public static vec4 operator /(vec4  A, vec4  B) => new vec4(A.x/B.x, A.y/B.y, A.z/B.z, A.w/B.w);
    [In(line)] public static vec4 operator /(vec4  A, float B) => new vec4(A.x/B  , A.y/B  , A.z/B  , A.w/B  );
    [In(line)] public static vec4 operator /(float A, vec4  B) => new vec4(A  /B.x, A  /B.y, A  /B.z, A  /B.w);

    [In(line)] public static vec4 operator %(vec4  A, vec4  B) => new vec4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w);
    [In(line)] public static vec4 operator %(vec4  A, float B) => new vec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
    [In(line)] public static vec4 operator %(float A, vec4  B) => new vec4(A  %B.x, A  %B.y, A  %B.z, A  %B.w);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [In(line)] public static bool operator ==(vec4 A, vec4  B) => (A.x==B.x && A.y==B.y && A.z==B.z && A.w==B.w);
    [In(line)] public static bool operator ==(vec4 A, float B) => (A.x==B   && A.y==B   && A.z==B   && A.w==B  );

    [In(line)] public static bool operator !=(vec4 A, vec4  B) => (A.x!=B.x || A.y!=B.y || A.z!=B.z || A.w!=B.w);
    [In(line)] public static bool operator !=(vec4 A, float B) => (A.x!=B   || A.y!=B   || A.z!=B   || A.w!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] public static bool operator  <(vec4 A, vec4  B) => (A.x< B.x && A.y< B.y && A.z< B.z && A.w< B.w);
    [In(line)] public static bool operator  <(vec4 A, float B) => (A.x< B   && A.y< B   && A.z< B   && A.w< B  );

    [In(line)] public static bool operator  >(vec4 A, vec4  B) => (A.x> B.x && A.y> B.y && A.z> B.z && A.w> B.w);
    [In(line)] public static bool operator  >(vec4 A, float B) => (A.x> B   && A.y> B   && A.z> B   && A.w> B  );

    [In(line)] public static bool operator <=(vec4 A, vec4  B) => (A.x<=B.x && A.y<=B.y && A.z<=B.z && A.w<=B.w);
    [In(line)] public static bool operator <=(vec4 A, float B) => (A.x<=B   && A.y<=B   && A.z<=B   && A.w<=B  );

    [In(line)] public static bool operator >=(vec4 A, vec4  B) => (A.x>=B.x && A.y>=B.y && A.z>=B.z && A.w>=B.w);
    [In(line)] public static bool operator >=(vec4 A, float B) => (A.x>=B   && A.y>=B   && A.z>=B   && A.w>=B  );

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
        string Z = this.z.ToString(FormatStr).PadLeft(Padding);
        string W = this.w.ToString(FormatStr).PadLeft(Padding);

        return $"({X},{Y},{Z},{W})";
    }

    //==========================================================================================================================================================
    public readonly override string ToString() => $"({this.x,9:0.000000},{this.y,9:0.000000},{this.z,9:0.000000},{this.w,9:0.000000})";

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
