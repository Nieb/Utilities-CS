using VEC2 = System.Numerics.Vector2;
using VEC3 = System.Numerics.Vector3;
using VEC4 = System.Numerics.Vector4;

namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec4 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public float x;       [FieldOffset( 0)] public float r;
    [FieldOffset( 4)] public float y;       [FieldOffset( 4)] public float g;
    [FieldOffset( 8)] public float z;       [FieldOffset( 8)] public float b;
    [FieldOffset(12)] public float w;       [FieldOffset(12)] public float a;

    //==========================================================================================================================================================
    [FieldOffset( 0)] public vec3 xyz;      [FieldOffset( 0)] public vec3 rgb;

    [FieldOffset( 0)] public vec2 xy;
    [FieldOffset( 4)] public vec2 yz;
    [FieldOffset( 8)] public vec2 zw;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public vec2 xz {get => new vec2(x,z);  set {x=value.x; z=value.y;}}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] public vec4() {}
    [Impl(AggressiveInlining)] public vec4(v1 X, v1 Y, v1 Z, v1 W) {x=X;    y=Y;    z=Z;    w=W;   }
    [Impl(AggressiveInlining)] public vec4(v1 V                  ) {x=V;    y=V;    z=V;    w=V;   }

    [Impl(AggressiveInlining)] public vec4(v2 XY     , v2 ZW     ) {x=XY.x; y=XY.y; z=ZW.x; w=ZW.y;}
    [Impl(AggressiveInlining)] public vec4(v3 V            , v1 W) {x=V.x;  y=V.y;  z=V.z;  w=W;   }
    [Impl(AggressiveInlining)] public vec4(i4 V                  ) {x=V.x;  y=V.y;  z=V.z;  w=V.w; }

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [Impl(AggressiveInlining)] public static implicit operator vec4(     float[] V) => new vec4( V[0], V[1], V[2], V[3]); //                   float[4]  to  vec4
    [Impl(AggressiveInlining)] public static implicit operator vec4(          V4 T) => new vec4(  T.x,  T.y,  T.z,  T.w); //  (float,float,float,float)  to  vec4
  //[Impl(AggressiveInlining)] public static implicit operator   V4(        vec4 V) =>         (  V.x,  V.y,  V.z,  V.w); //                       vec4  to  (float,float,float,float)
    [Impl(AggressiveInlining)] public static implicit operator vec4(       ivec4 V) => new vec4(  V.x,  V.y,  V.z,  V.w); //                      ivec4  to  vec4
    [Impl(AggressiveInlining)] public static implicit operator vec4((v2 A, v2 B) T) => new vec4(T.A.x,T.A.y,T.B.x,T.B.y); //                (vec2,vec2)  to  vec4
    [Impl(AggressiveInlining)] public static implicit operator vec4((v3 V, v1 w) T) => new vec4(T.V.x,T.V.y,T.V.z,  T.w); //               (vec3,float)  to  vec4

    [Impl(AggressiveInlining)] public static implicit operator vec4(        VEC4 v) => new vec4(  v.X,  v.Y,  v.Z,  v.W); //                    Vector4  to  vec4
    [Impl(AggressiveInlining)] public static implicit operator VEC4(        vec4 V) => new VEC4(  V.x,  V.y,  V.z,  V.w); //                       vec4  to  Vector4

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining)] public static vec4 operator +(vec4  A, vec4  B) => new vec4(A.x+B.x, A.y+B.y, A.z+B.z, A.w+B.w);
    [Impl(AggressiveInlining)] public static vec4 operator +(vec4  A, float B) => new vec4(A.x+B  , A.y+B  , A.z+B  , A.w+B  );
    [Impl(AggressiveInlining)] public static vec4 operator +(float A, vec4  B) => new vec4(A  +B.x, A  +B.y, A  +B.z, A  +B.w);

    [Impl(AggressiveInlining)] public static vec4 operator -(vec4  A, vec4  B) => new vec4(A.x-B.x, A.y-B.y, A.z-B.z, A.w-B.w);
    [Impl(AggressiveInlining)] public static vec4 operator -(vec4  A, float B) => new vec4(A.x-B  , A.y-B  , A.z-B  , A.w-B  );
    [Impl(AggressiveInlining)] public static vec4 operator -(float A, vec4  B) => new vec4(A  -B.x, A  -B.y, A  -B.z, A  -B.w);

    [Impl(AggressiveInlining)] public static vec4 operator -(vec4 A)           => new vec4(   -A.x,    -A.y,    -A.z,    -A.w);

    [Impl(AggressiveInlining)] public static vec4 operator *(vec4  A, vec4  B) => new vec4(A.x*B.x, A.y*B.y, A.z*B.z, A.w*B.w);
    [Impl(AggressiveInlining)] public static vec4 operator *(vec4  A, float B) => new vec4(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [Impl(AggressiveInlining)] public static vec4 operator *(float A, vec4  B) => new vec4(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [Impl(AggressiveInlining)] public static vec4 operator /(vec4  A, vec4  B) => new vec4(A.x/B.x, A.y/B.y, A.z/B.z, A.w/B.w);
    [Impl(AggressiveInlining)] public static vec4 operator /(vec4  A, float B) => new vec4(A.x/B  , A.y/B  , A.z/B  , A.w/B  );
    [Impl(AggressiveInlining)] public static vec4 operator /(float A, vec4  B) => new vec4(A  /B.x, A  /B.y, A  /B.z, A  /B.w);

    [Impl(AggressiveInlining)] public static vec4 operator %(vec4  A, vec4  B) => new vec4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w);
    [Impl(AggressiveInlining)] public static vec4 operator %(vec4  A, float B) => new vec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
    [Impl(AggressiveInlining)] public static vec4 operator %(float A, vec4  B) => new vec4(A  %B.x, A  %B.y, A  %B.z, A  %B.w);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(vec4 A, vec4  B) => (A.x==B.x && A.y==B.y && A.z==B.z && A.w==B.w);
    [Impl(AggressiveInlining)] public static bool operator ==(vec4 A, float B) => (A.x==B   && A.y==B   && A.z==B   && A.w==B  );

    [Impl(AggressiveInlining)] public static bool operator !=(vec4 A, vec4  B) => (A.x!=B.x || A.y!=B.y || A.z!=B.z || A.w!=B.w);
    [Impl(AggressiveInlining)] public static bool operator !=(vec4 A, float B) => (A.x!=B   || A.y!=B   || A.z!=B   || A.w!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] public static bool operator  <(vec4 A, vec4  B) => (A.x< B.x && A.y< B.y && A.z< B.z && A.w< B.w);
    [Impl(AggressiveInlining)] public static bool operator  <(vec4 A, float B) => (A.x< B   && A.y< B   && A.z< B   && A.w< B  );

    [Impl(AggressiveInlining)] public static bool operator  >(vec4 A, vec4  B) => (A.x> B.x && A.y> B.y && A.z> B.z && A.w> B.w);
    [Impl(AggressiveInlining)] public static bool operator  >(vec4 A, float B) => (A.x> B   && A.y> B   && A.z> B   && A.w> B  );

    [Impl(AggressiveInlining)] public static bool operator <=(vec4 A, vec4  B) => (A.x<=B.x && A.y<=B.y && A.z<=B.z && A.w<=B.w);
    [Impl(AggressiveInlining)] public static bool operator <=(vec4 A, float B) => (A.x<=B   && A.y<=B   && A.z<=B   && A.w<=B  );

    [Impl(AggressiveInlining)] public static bool operator >=(vec4 A, vec4  B) => (A.x>=B.x && A.y>=B.y && A.z>=B.z && A.w>=B.w);
    [Impl(AggressiveInlining)] public static bool operator >=(vec4 A, float B) => (A.x>=B   && A.y>=B   && A.z>=B   && A.w>=B  );

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
