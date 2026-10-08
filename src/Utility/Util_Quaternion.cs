using Vector2 = System.Numerics.Vector2;    using float2 = (float x, float y);                      using int2 = (int x, int y);
using Vector3 = System.Numerics.Vector3;    using float3 = (float x, float y, float z);             using int3 = (int x, int y, int z);
using Vector4 = System.Numerics.Vector4;    using float4 = (float x, float y, float z, float w);    using int4 = (int x, int y, int z, int w);

#pragma warning disable CS8981 //  The type name '*' only contains lower-cased ASCII characters.  Such names may become reserved for the language.
namespace Utility;
internal static partial class QUAT {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct quat : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  A Quaternion can be thought of as a way of encoding an Orientation (Pitch, Yaw, Roll).
    //      With some convenient properties, such as trivially compounding rotations.
    //      Also, some inconvenient properties, such as double-coverage.
    //
    //      It doesn't explicitly store Direction.  However, if all of your code agrees on a
    //      default Direction for a (0,0,0) Orientation, then it can implicitly store Direction.
    //
    //  A Vector3 can be interpreted as a Direction with Magnitude (vector length).
    //      Two axes of Orientation can be derived from it, such as Pitch & Yaw.
    //      However, there is not enough information for a third axis.
    //
    //  https://www.desmos.com/calculator/bsimzxqgde
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public float x;
    [FieldOffset( 4)] public float y;
    [FieldOffset( 8)] public float z;
    [FieldOffset(12)] public float w;

    //==========================================================================================================================================================
    [FieldOffset( 0)] public vec3 xyz;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
  //public readonly bool IsValid => abs(sqrt(this.x*this.x + this.y*this.y + this.z*this.z + this.w*this.w) - 1f) < EPS6;
    public readonly bool IsValid => abs(     this.x*this.x + this.y*this.y + this.z*this.z + this.w*this.w  - 1f) < EPS5;

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  When a Quaternion is created with "Theta = 0", all "Axis" information is lost.
    //
    public readonly vec3 Axis {
        get {
            float d = sqrt(1f - this.w*this.w);
            return (d < EPS6) ? new vec3(1f, 0f, 0f) // Default Axis if Theta == 0.
                              : this.xyz / d;
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
  //public readonly float Theta => 2f * acos(this.w);
    public readonly float Theta => 2f * acos(clamp(this.w, -1f, 1f));

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Returns the exact opposite rotation (-Pitch, -Yaw, -Roll)
    //
    public readonly quat Conjugate => new quat(-this.x, -this.y, -this.z, this.w);
    public readonly quat Inverse   => this.Conjugate; // Valid for unit quaternions.

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
  //[In(line)] public void Normalize() {
  //    float len = sqrt(this.x*this.x + this.y*this.y + this.z*this.z + this.w*this.w);
  //    if (len < EPS5) {this.x  =  0f; this.y  =  0f; this.z  =  0f; this.w  =  1f;}
  //    else            {this.x /= len; this.y /= len; this.z /= len; this.w /= len;}
  //}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      quat A = default;   Zeroed out.
    //      quat B = new();     Identity.
    //
    [In(line)] public quat() {this.x=0f; this.y=0f; this.z=0f; this.w=1f;}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [In(line)] public quat(float X, float Y, float Z, float W) {this.x=X; this.y=Y; this.z=Z; this.w=W;}

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  "Axis" should be normalized.
    //
    [In(line)] public quat(vec3 Axis, float Theta) {
        (float SinT, float CosT) = sincos(Theta / 2f);
        this.x = Axis.x * SinT;
        this.y = Axis.y * SinT;
        this.z = Axis.z * SinT;
        this.w = CosT;
    }

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [In(line)] public static implicit operator quat(      float4 T) => new quat(T.x, T.y, T.z, T.w); //  (float,float,float,float)  to  quat
    [In(line)] public static implicit operator quat((v3 A, v1 w) T) => new quat(          T.A, T.w); //               (vec3,float)  to  quat

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                 Operators Quaternion
    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Compounds two rotations together:  (A * B)  ==  "Rotate by qA, then by qB"
    //
    [In(line)] public static quat operator *(quat A, quat B) => new quat(A.w*B.x + A.x*B.w + A.y*B.z - A.z*B.y,
                                                                         A.w*B.y - A.x*B.z + A.y*B.w + A.z*B.x,
                                                                         A.w*B.z + A.x*B.y - A.y*B.x + A.z*B.w,
                                                                         A.w*B.w - A.x*B.x - A.y*B.y - A.z*B.z );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Rotate vec3 by quat.
    //
    [In(line)] public static vec3 operator *(vec3 A, quat B) {vec3 T = 2f * cross(B.xyz,A);  return A + (T * B.w) + cross(B.xyz, T);}

    //==========================================================================================================================================================
    //                                                                 Operators Scalar

    [In(line)] public static quat operator +(quat  A, quat  B) => new quat(A.x+B.x, A.y+B.y, A.z+B.z, A.w+B.w);

    [In(line)] public static quat operator -(quat  A)          => new quat(   -A.x,    -A.y,    -A.z,    -A.w);

    [In(line)] public static quat operator *(quat  A, float B) => new quat(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [In(line)] public static quat operator *(float A, quat  B) => new quat(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [In(line)] public static quat operator /(quat  A, float B) => new quat(A.x/B  , A.y/B  , A.z/B  , A.w/B  );

    //==========================================================================================================================================================
    //                                                                 Operators Logical                                ==  !=  <  >  <=  >=     ( ! && || )

    [In(line)] public static bool operator ==(quat A, quat B) => (A.x==B.x && A.y==B.y && A.z==B.z && A.w==B.w);
    [In(line)] public static bool operator !=(quat A, quat B) => (A.x!=B.x || A.y!=B.y || A.z!=B.z || A.w!=B.w);

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
#pragma warning restore CS8981 //  The type name '*' only contains lower-cased ascii characters.  Such names may become reserved for the language.
