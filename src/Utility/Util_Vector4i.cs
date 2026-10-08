using Vector2 = System.Numerics.Vector2;    using float2 = (float x, float y);                      using int2 = (int x, int y);
using Vector3 = System.Numerics.Vector3;    using float3 = (float x, float y, float z);             using int3 = (int x, int y, int z);
using Vector4 = System.Numerics.Vector4;    using float4 = (float x, float y, float z, float w);    using int4 = (int x, int y, int z, int w);

namespace Utility;
internal static partial class VEC {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec4 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public int x;                                             [FieldOffset( 0)] public int r;
    [FieldOffset( 4)] public int y;                                             [FieldOffset( 4)] public int g;
    [FieldOffset( 8)] public int z;                                             [FieldOffset( 8)] public int b;
    [FieldOffset(12)] public int w;                                             [FieldOffset(12)] public int a;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [FieldOffset( 0)] public ivec2 xy;                                          [FieldOffset( 0)] public ivec2 rg;
    [FieldOffset( 4)] public ivec2 yz;                                          [FieldOffset( 4)] public ivec2 gb;
    [FieldOffset( 8)] public ivec2 zw;                                          [FieldOffset( 8)] public ivec2 ba;

    [FieldOffset( 0)] public ivec3 xyz;                                         [FieldOffset( 0)] public ivec3 rgb;
    [FieldOffset( 4)] public ivec3 yzw;                                         [FieldOffset( 4)] public ivec3 gba;

    //==========================================================================================================================================================
    public ivec2 xz {get => new ivec2(x,z);  set {x=value.x; z=value.y;}}
    public ivec2 xw {get => new ivec2(x,w);  set {x=value.x; w=value.y;}}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    public ivec4 xyzw {get => this;  set => this=value;}                        public ivec4 rgba {get => this;  set => this=value;}

    public ivec4 xyz_ => new ivec4(x,y,z,0);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] public ivec4() {}
    [In(line)] public ivec4(int X, int Y, int Z, int W) {x=X; y=Y; z=Z; w=W;}
    [In(line)] public ivec4(int V                     ) {x=V; y=V; z=V; w=V;}

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [In(line)] public static implicit operator Vector4(       ivec4 V) => new Vector4(  V.x,  V.y,  V.z,  V.w); //              ivec4  to  Vector4

    [In(line)] public static implicit operator   ivec4(       int[] V) => new   ivec4( V[0], V[1], V[2], V[3]); //             int[4]  to  ivec4

    [In(line)] public static implicit operator   ivec4(        int4 T) => new   ivec4(  T.x,  T.y,  T.z,  T.w); //  (int,int,int,int)  to  ivec4
  //[In(line)] public static implicit operator    int4(        vec4 V) =>            (  V.x,  V.y,  V.z,  V.w); //              ivec4  to  (int,int,int,int)
    [In(line)] public static implicit operator   ivec4((i2 A, i2 B) T) => new   ivec4(T.A.x,T.A.y,T.B.x,T.B.y); //      (ivec2,ivec2)  to  ivec4
    [In(line)] public static implicit operator   ivec4((i3 V, i1 w) T) => new   ivec4(T.V.x,T.V.y,T.V.z,  T.w); //        (ivec3,int)  to  ivec4

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [In(line)] public static ivec4 operator +(ivec4 A, ivec4 B) => new ivec4(A.x+B.x, A.y+B.y, A.z+B.z, A.w+B.w);
    [In(line)] public static ivec4 operator +(ivec4 A, int   B) => new ivec4(A.x+B  , A.y+B  , A.z+B  , A.w+B  );
    [In(line)] public static ivec4 operator +(int   A, ivec4 B) => new ivec4(A  +B.x, A  +B.y, A  +B.z, A  +B.w);

    [In(line)] public static ivec4 operator -(ivec4 A, ivec4 B) => new ivec4(A.x-B.x, A.y-B.y, A.z-B.z, A.w-B.w);
    [In(line)] public static ivec4 operator -(ivec4 A, int   B) => new ivec4(A.x-B  , A.y-B  , A.z-B  , A.w-B  );
    [In(line)] public static ivec4 operator -(int   A, ivec4 B) => new ivec4(A  -B.x, A  -B.y, A  -B.z, A  -B.w);

    [In(line)] public static ivec4 operator -(ivec4 A)          => new ivec4(   -A.x,    -A.y,    -A.z,    -A.w);

    [In(line)] public static ivec4 operator *(ivec4 A, ivec4 B) => new ivec4(A.x*B.x, A.y*B.y, A.z*B.z, A.w*B.w);
    [In(line)] public static ivec4 operator *(ivec4 A, int   B) => new ivec4(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [In(line)] public static ivec4 operator *(int   A, ivec4 B) => new ivec4(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [In(line)] public static ivec4 operator /(ivec4 A, ivec4 B) => new ivec4(A.x/B.x, A.y/B.y, A.z/B.z, A.w/B.w);
    [In(line)] public static ivec4 operator /(ivec4 A, int   B) => new ivec4(A.x/B  , A.y/B  , A.z/B  , A.w/B  );
    [In(line)] public static ivec4 operator /(int   A, ivec4 B) => new ivec4(A  /B.x, A  /B.y, A  /B.z, A  /B.w);

    [In(line)] public static ivec4 operator %(ivec4 A, ivec4 B) => new ivec4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w);
    [In(line)] public static ivec4 operator %(ivec4 A, int   B) => new ivec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
    [In(line)] public static ivec4 operator %(int   A, ivec4 B) => new ivec4(A  %B.x, A  %B.y, A  %B.z, A  %B.w);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] public static  vec4 operator +(ivec4 A, float B) => new  vec4(A.x+B  , A.y+B  , A.z+B  , A.w+B  );
    [In(line)] public static  vec4 operator +(float A, ivec4 B) => new  vec4(A  +B.x, A  +B.y, A  +B.z, A  +B.w);

    [In(line)] public static  vec4 operator -(ivec4 A, float B) => new  vec4(A.x-B  , A.y-B  , A.z-B  , A.w-B  );
    [In(line)] public static  vec4 operator -(float A, ivec4 B) => new  vec4(A  -B.x, A  -B.y, A  -B.z, A  -B.w);

    [In(line)] public static  vec4 operator *(ivec4 A, float B) => new  vec4(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [In(line)] public static  vec4 operator *(float A, ivec4 B) => new  vec4(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [In(line)] public static  vec4 operator /(ivec4 A, float B) => new  vec4(A.x/B  , A.y/B  , A.z/B  , A.w/B  );
    [In(line)] public static  vec4 operator /(float A, ivec4 B) => new  vec4(A  /B.x, A  /B.y, A  /B.z, A  /B.w);

    [In(line)] public static  vec4 operator %(ivec4 A, float B) => new  vec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
    [In(line)] public static  vec4 operator %(float A, ivec4 B) => new  vec4(A  %B.x, A  %B.y, A  %B.z, A  %B.w);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(also shifts signed-bit)

    [In(line)] public static ivec4 operator   ~(ivec4 A)          => new ivec4(   ~A.x,    ~A.y,    ~A.z,    ~A.w);

    [In(line)] public static ivec4 operator   &(ivec4 A, ivec4 B) => new ivec4(A.x&B.x, A.y&B.y, A.z&B.z, A.w&B.w);

    [In(line)] public static ivec4 operator   |(ivec4 A, ivec4 B) => new ivec4(A.x|B.x, A.y|B.y, A.z|B.z, A.w|B.w);

    [In(line)] public static ivec4 operator   ^(ivec4 A, ivec4 B) => new ivec4(A.x^B.x, A.y^B.y, A.z^B.z, A.w^B.w);

    [In(line)] public static ivec4 operator  <<(ivec4 A, int   n) => new ivec4(A.x <<n, A.y <<n, A.z <<n, A.w <<n);
    [In(line)] public static ivec4 operator  >>(ivec4 A, int   n) => new ivec4(A.x >>n, A.y >>n, A.z >>n, A.w >>n);
    [In(line)] public static ivec4 operator >>>(ivec4 A, int   n) => new ivec4(A.x>>>n, A.y>>>n, A.z>>>n, A.w>>>n);

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [In(line)] public static bool operator ==(ivec4 A, ivec4 B) => (A.x==B.x && A.y==B.y && A.z==B.z && A.w==B.w);
    [In(line)] public static bool operator ==(ivec4 A, int   B) => (A.x==B   && A.y==B   && A.z==B   && A.w==B  );

    [In(line)] public static bool operator !=(ivec4 A, ivec4 B) => (A.x!=B.x || A.y!=B.y || A.z!=B.z || A.w!=B.w);
    [In(line)] public static bool operator !=(ivec4 A, int   B) => (A.x!=B   || A.y!=B   || A.z!=B   || A.w!=B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] public static bool operator  <(ivec4 A, ivec4 B) => (A.x< B.x && A.y< B.y && A.z< B.z && A.w< B.w);
    [In(line)] public static bool operator  <(ivec4 A, int   B) => (A.x< B   && A.y< B   && A.z< B   && A.w< B  );

    [In(line)] public static bool operator  >(ivec4 A, ivec4 B) => (A.x> B.x && A.y> B.y && A.z> B.z && A.w> B.w);
    [In(line)] public static bool operator  >(ivec4 A, int   B) => (A.x> B   && A.y> B   && A.z> B   && A.w> B  );

    [In(line)] public static bool operator <=(ivec4 A, ivec4 B) => (A.x<=B.x && A.y<=B.y && A.z<=B.z && A.w<=B.w);
    [In(line)] public static bool operator <=(ivec4 A, int   B) => (A.x<=B   && A.y<=B   && A.z<=B   && A.w<=B  );

    [In(line)] public static bool operator >=(ivec4 A, ivec4 B) => (A.x>=B.x && A.y>=B.y && A.z>=B.z && A.w>=B.w);
    [In(line)] public static bool operator >=(ivec4 A, int   B) => (A.x>=B   && A.y>=B   && A.z>=B   && A.w>=B  );

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
