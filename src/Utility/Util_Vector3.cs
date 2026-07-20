using VEC2 = System.Numerics.Vector2;
using VEC3 = System.Numerics.Vector3;
using VEC4 = System.Numerics.Vector4;

namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec3 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public float x;    [FieldOffset(0)] public float r;
    [FieldOffset(4)] public float y;    [FieldOffset(4)] public float g;
    [FieldOffset(8)] public float z;    [FieldOffset(8)] public float b;

    //==========================================================================================================================================================
    [FieldOffset(0)] public vec2 xy;
    [FieldOffset(4)] public vec2 yz;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public vec2 xz  {get => new vec2(x,z);    set {x=value.x; z=value.y;}}
    public vec2 zy  {get => new vec2(z,y);    set {z=value.x; y=value.y;}}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public vec3 xzy {get => new vec3(x,z,y);  set {x=value.x; z=value.y; y=value.z;}}
    public vec3 zyx {get => new vec3(z,y,x);  set {z=value.x; y=value.y; x=value.z;}}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public vec4 xyz_ => new vec4(x,y,z,0);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining)] public vec3() {}
    [Impl(AggressiveInlining)] public vec3(v1 X, v1 Y, v1 Z) {x=X;   y=Y;   z=Z;  }
    [Impl(AggressiveInlining)] public vec3(v1 V            ) {x=V;   y=V;   z=V;  }

    [Impl(AggressiveInlining)] public vec3(v2 V,       v1 Z) {x=V.x; y=V.y; z=Z;  }
    [Impl(AggressiveInlining)] public vec3(i2 V,       v1 Z) {x=V.x; y=V.y; z=Z;  }

    [Impl(AggressiveInlining)] public vec3(i3 V            ) {x=V.x; y=V.y; z=V.z;}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [Impl(AggressiveInlining)] public static implicit operator vec3(     float[] V) => new vec3( V[0], V[1], V[2]); //             float[3]  to  vec3
    [Impl(AggressiveInlining)] public static implicit operator vec3(          V3 T) => new vec3(  T.x,  T.y,  T.z); //  (float,float,float)  to  vec3
  //[Impl(AggressiveInlining)] public static implicit operator   V3(        vec3 V) =>         (  V.x,  V.y,  V.z); //                 vec3  to  (float,float,float)
    [Impl(AggressiveInlining)] public static implicit operator vec3((v2 V, v1 z) T) => new vec3(T.V.x,T.V.y,  T.z); //         (vec2,float)  to  vec3
    [Impl(AggressiveInlining)] public static implicit operator vec3(       ivec3 V) => new vec3(  V.x,  V.y,  V.z); //                ivec3  to  vec3

    [Impl(AggressiveInlining)] public static implicit operator vec3(        VEC3 v) => new vec3(  v.X,  v.Y,  v.Z); //              Vector3  to  vec3
    [Impl(AggressiveInlining)] public static implicit operator VEC3(        vec3 V) => new VEC3(  V.x,  V.y,  V.z); //                 vec3  to  Vector3

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining)] public static vec3 operator +(vec3  A, vec3  B) => new vec3(A.x+B.x, A.y+B.y, A.z+B.z);
    [Impl(AggressiveInlining)] public static vec3 operator +(vec3  A, float B) => new vec3(A.x+B  , A.y+B  , A.z+B  );
    [Impl(AggressiveInlining)] public static vec3 operator +(float A, vec3  B) => new vec3(A  +B.x, A  +B.y, A  +B.z);

    [Impl(AggressiveInlining)] public static vec3 operator -(vec3  A, vec3  B) => new vec3(A.x-B.x, A.y-B.y, A.z-B.z);
    [Impl(AggressiveInlining)] public static vec3 operator -(vec3  A, float B) => new vec3(A.x-B  , A.y-B  , A.z-B  );
    [Impl(AggressiveInlining)] public static vec3 operator -(float A, vec3  B) => new vec3(A  -B.x, A  -B.y, A  -B.z);

    [Impl(AggressiveInlining)] public static vec3 operator -(vec3 A)           => new vec3(   -A.x,    -A.y,    -A.z);

    [Impl(AggressiveInlining)] public static vec3 operator *(vec3  A, vec3  B) => new vec3(A.x*B.x, A.y*B.y, A.z*B.z);
    [Impl(AggressiveInlining)] public static vec3 operator *(vec3  A, float B) => new vec3(A.x*B  , A.y*B  , A.z*B  );
    [Impl(AggressiveInlining)] public static vec3 operator *(float A, vec3  B) => new vec3(A  *B.x, A  *B.y, A  *B.z);

    [Impl(AggressiveInlining)] public static vec3 operator /(vec3  A, vec3  B) => new vec3(A.x/B.x, A.y/B.y, A.z/B.z);
    [Impl(AggressiveInlining)] public static vec3 operator /(vec3  A, float B) => new vec3(A.x/B  , A.y/B  , A.z/B  );
    [Impl(AggressiveInlining)] public static vec3 operator /(float A, vec3  B) => new vec3(A  /B.x, A  /B.y, A  /B.z);

    [Impl(AggressiveInlining)] public static vec3 operator %(vec3  A, vec3  B) => new vec3(A.x%B.x, A.y%B.y, A.z%B.z);
    [Impl(AggressiveInlining)] public static vec3 operator %(vec3  A, float B) => new vec3(A.x%B  , A.y%B  , A.z%B  );
    [Impl(AggressiveInlining)] public static vec3 operator %(float A, vec3  B) => new vec3(A  %B.x, A  %B.y, A  %B.z);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining)] public static bool operator ==(vec3  A, vec3  B) => (A.x==B.x && A.y==B.y && A.z==B.z);
    [Impl(AggressiveInlining)] public static bool operator ==(vec3  A, float B) => (A.x==B   && A.y==B   && A.z==B  );

    [Impl(AggressiveInlining)] public static bool operator !=(vec3  A, vec3  B) => (A.x!=B.x || A.y!=B.y || A.z!=B.z);
    [Impl(AggressiveInlining)] public static bool operator !=(vec3  A, float B) => (A.x!=B   || A.y!=B   || A.z!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining)] public static bool operator  <(vec3  A, vec3  B) => (A.x< B.x && A.y< B.y && A.z< B.z);
    [Impl(AggressiveInlining)] public static bool operator  <(vec3  A, float B) => (A.x< B   && A.y< B   && A.z< B  );

    [Impl(AggressiveInlining)] public static bool operator  >(vec3  A, vec3  B) => (A.x> B.x && A.y> B.y && A.z> B.z);
    [Impl(AggressiveInlining)] public static bool operator  >(vec3  A, float B) => (A.x> B   && A.y> B   && A.z> B  );

    [Impl(AggressiveInlining)] public static bool operator <=(vec3  A, vec3  B) => (A.x<=B.x && A.y<=B.y && A.z<=B.z);
    [Impl(AggressiveInlining)] public static bool operator <=(vec3  A, float B) => (A.x<=B   && A.y<=B   && A.z<=B  );

    [Impl(AggressiveInlining)] public static bool operator >=(vec3  A, vec3  B) => (A.x>=B.x && A.y>=B.y && A.z>=B.z);
    [Impl(AggressiveInlining)] public static bool operator >=(vec3  A, float B) => (A.x>=B   && A.y>=B   && A.z>=B  );

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
