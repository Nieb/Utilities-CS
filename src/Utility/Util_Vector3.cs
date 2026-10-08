using Vector2 = System.Numerics.Vector2;    using float2 = (float x, float y);                      using int2 = (int x, int y);
using Vector3 = System.Numerics.Vector3;    using float3 = (float x, float y, float z);             using int3 = (int x, int y, int z);
using Vector4 = System.Numerics.Vector4;    using float4 = (float x, float y, float z, float w);    using int4 = (int x, int y, int z, int w);

namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec3 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public float x;                                            [FieldOffset(0)] public float r;
    [FieldOffset(4)] public float y;                                            [FieldOffset(4)] public float g;
    [FieldOffset(8)] public float z;                                            [FieldOffset(8)] public float b;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [FieldOffset(0)] public vec2 xy;                                            [FieldOffset(0)] public vec2 rg;
    [FieldOffset(4)] public vec2 yz;                                            [FieldOffset(4)] public vec2 gb;

    //==========================================================================================================================================================
    public vec2 xz  {get => new vec2(x,z);    set {x=value.x; z=value.y;}}
    public vec2 zy  {get => new vec2(z,y);    set {z=value.x; y=value.y;}}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public vec3 xyz {get => this;             set => this=value;}               public vec3 rgb {get => this;  set => this=value;}

    public vec3 xzy {get => new vec3(x,z,y);  set {x=value.x; z=value.y; y=value.z;}}
    public vec3 zyx {get => new vec3(z,y,x);  set {z=value.x; y=value.y; x=value.z;}}

    public vec3 xy_  => new vec3(x,y,0);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public vec4 xyz_ => new vec4(x,y,z,0);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] public vec3() {}
    [In(line)] public vec3(float X, float Y, float Z) {x=X; y=Y; z=Z;}
    [In(line)] public vec3(float V                  ) {x=V; y=V; z=V;}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [In(line)] public static implicit operator    vec3(     float[] V) => new    vec3( V[0], V[1], V[2]); //             float[3]  to  vec3
    [In(line)] public static implicit operator    vec3(       ivec3 V) => new    vec3(  V.x,  V.y,  V.z); //                ivec3  to  vec3
    [In(line)] public static implicit operator Vector3(        vec3 V) => new Vector3(  V.x,  V.y,  V.z); //                 vec3  to  Vector3
    [In(line)] public static implicit operator    vec3(     Vector3 v) => new    vec3(  v.X,  v.Y,  v.Z); //              Vector3  to  vec3

    [In(line)] public static implicit operator    vec3(      float3 T) => new    vec3(  T.x,  T.y,  T.z); //  (float,float,float)  to  vec3
  //[In(line)] public static implicit operator  float3(        vec3 V) =>            (  V.x,  V.y,  V.z); //                 vec3  to  (float,float,float)
    [In(line)] public static implicit operator    vec3((v2 V, v1 z) T) => new    vec3(T.V.x,T.V.y,  T.z); //         (vec2,float)  to  vec3

  //[In(line)] public static implicit operator Vector3(      float3 T) => new Vector3(  T.x,  T.y,  T.z); //  (float,float,float)  to  Vector3  :(

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [In(line)] public static vec3 operator +(vec3  A, vec3  B) => new vec3(A.x+B.x, A.y+B.y, A.z+B.z);
    [In(line)] public static vec3 operator +(vec3  A, float B) => new vec3(A.x+B  , A.y+B  , A.z+B  );
    [In(line)] public static vec3 operator +(float A, vec3  B) => new vec3(A  +B.x, A  +B.y, A  +B.z);

    [In(line)] public static vec3 operator -(vec3  A, vec3  B) => new vec3(A.x-B.x, A.y-B.y, A.z-B.z);
    [In(line)] public static vec3 operator -(vec3  A, float B) => new vec3(A.x-B  , A.y-B  , A.z-B  );
    [In(line)] public static vec3 operator -(float A, vec3  B) => new vec3(A  -B.x, A  -B.y, A  -B.z);

    [In(line)] public static vec3 operator -(vec3 A)           => new vec3(   -A.x,    -A.y,    -A.z);

    [In(line)] public static vec3 operator *(vec3  A, vec3  B) => new vec3(A.x*B.x, A.y*B.y, A.z*B.z);
    [In(line)] public static vec3 operator *(vec3  A, float B) => new vec3(A.x*B  , A.y*B  , A.z*B  );
    [In(line)] public static vec3 operator *(float A, vec3  B) => new vec3(A  *B.x, A  *B.y, A  *B.z);

    [In(line)] public static vec3 operator /(vec3  A, vec3  B) => new vec3(A.x/B.x, A.y/B.y, A.z/B.z);
    [In(line)] public static vec3 operator /(vec3  A, float B) => new vec3(A.x/B  , A.y/B  , A.z/B  );
    [In(line)] public static vec3 operator /(float A, vec3  B) => new vec3(A  /B.x, A  /B.y, A  /B.z);

    [In(line)] public static vec3 operator %(vec3  A, vec3  B) => new vec3(A.x%B.x, A.y%B.y, A.z%B.z);
    [In(line)] public static vec3 operator %(vec3  A, float B) => new vec3(A.x%B  , A.y%B  , A.z%B  );
    [In(line)] public static vec3 operator %(float A, vec3  B) => new vec3(A  %B.x, A  %B.y, A  %B.z);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [In(line)] public static bool operator ==(vec3  A, vec3  B) => (A.x==B.x && A.y==B.y && A.z==B.z);
    [In(line)] public static bool operator ==(vec3  A, float B) => (A.x==B   && A.y==B   && A.z==B  );

    [In(line)] public static bool operator !=(vec3  A, vec3  B) => (A.x!=B.x || A.y!=B.y || A.z!=B.z);
    [In(line)] public static bool operator !=(vec3  A, float B) => (A.x!=B   || A.y!=B   || A.z!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] public static bool operator  <(vec3  A, vec3  B) => (A.x< B.x && A.y< B.y && A.z< B.z);
    [In(line)] public static bool operator  <(vec3  A, float B) => (A.x< B   && A.y< B   && A.z< B  );

    [In(line)] public static bool operator  >(vec3  A, vec3  B) => (A.x> B.x && A.y> B.y && A.z> B.z);
    [In(line)] public static bool operator  >(vec3  A, float B) => (A.x> B   && A.y> B   && A.z> B  );

    [In(line)] public static bool operator <=(vec3  A, vec3  B) => (A.x<=B.x && A.y<=B.y && A.z<=B.z);
    [In(line)] public static bool operator <=(vec3  A, float B) => (A.x<=B   && A.y<=B   && A.z<=B  );

    [In(line)] public static bool operator >=(vec3  A, vec3  B) => (A.x>=B.x && A.y>=B.y && A.z>=B.z);
    [In(line)] public static bool operator >=(vec3  A, float B) => (A.x>=B   && A.y>=B   && A.z>=B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly string ToString(string FormatStr, System.IFormatProvider FormatProvider) {
        _ = FormatProvider;
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length+1;

        #if true
            string X = FNZ(this.x).ToString(FormatStr).PadLeft(Padding);
            string Y = FNZ(this.y).ToString(FormatStr).PadLeft(Padding);
            string Z = FNZ(this.z).ToString(FormatStr).PadLeft(Padding);
        #else
            string X = this.x.ToString(FormatStr).PadLeft(Padding);
            string Y = this.y.ToString(FormatStr).PadLeft(Padding);
            string Z = this.z.ToString(FormatStr).PadLeft(Padding);
        #endif

        return $"({X},{Y},{Z})";
    }

    #if true
        public readonly override string ToString() => $"({FNZ(this.x),9:0.000000},{FNZ(this.y),9:0.000000},{FNZ(this.z),9:0.000000})";
    #else
        public readonly override string ToString() => $"({this.x,9:0.000000},{this.y,9:0.000000},{this.z,9:0.000000})";
    #endif

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}
