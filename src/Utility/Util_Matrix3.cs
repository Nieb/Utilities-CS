using MAT4 = System.Numerics.Matrix4x4;

namespace Utility;
internal static partial class MAT {
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct mat3 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //                                          |       Col 0          Col 1          Col 2
    //                                  --------+---------------------------------------------------
    //                  [i] [x,y] **      Row 0 |   [0] [0,0] XX   [1] [1,0] YX   [2] [2,0] ZX
    //                   [Col, Row]       Row 1 |   [3] [0,1] XY   [4] [1,1] YY   [5] [2,1] ZY
    //                                    Row 2 |   [6] [0,2] XZ   [7] [1,2] YZ   [8] [2,2] ZZ
    //                                          |
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public float xx;  [FieldOffset( 4)] public float yx;  [FieldOffset( 8)] public float zx;
    [FieldOffset(12)] public float xy;  [FieldOffset(16)] public float yy;  [FieldOffset(20)] public float zy;
    [FieldOffset(24)] public float xz;  [FieldOffset(28)] public float yz;  [FieldOffset(32)] public float zz;

    //==========================================================================================================================================================
    public vec3 Col0 {get => new vec3(xx,xy,xz); set {xx=value.x; xy=value.y; xz=value.z;}}
    public vec3 Col1 {get => new vec3(yx,yy,yz); set {yx=value.x; yy=value.y; yz=value.z;}}
    public vec3 Col2 {get => new vec3(zx,zy,zz); set {zx=value.x; zy=value.y; zz=value.z;}}

    [FieldOffset( 0)] public vec3 Row0;    [FieldOffset( 0)] public vec3 RowX;
    [FieldOffset(12)] public vec3 Row1;    [FieldOffset(12)] public vec3 RowY;
    [FieldOffset(24)] public vec3 Row2;    [FieldOffset(24)] public vec3 RowZ;

    //==========================================================================================================================================================
    [FieldOffset(0)] private InlineArray9_Float index;

    public float this[int i] {
        [In(line)] get => this.index[i];
        [In(line)] set => this.index[i] = value;
    }

    public float this[int x, int y] {
        #if DEBUG
            get =>                       (x<0||x>2||y<0||y>2) ? throw new System.IndexOutOfRangeException() : this.index[x + 3*y];
            set => this.index[x + 3*y] = (x<0||x>2||y<0||y>2) ? throw new System.IndexOutOfRangeException() : value;
        #else
            [In(line)] get => this.index[x + 3*y];
            [In(line)] set => this.index[x + 3*y] = value;
        #endif
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      mat3 A = default;   Zeroed out.
    //      mat3 B = new();     Identity.
    //
    [In(line)] public mat3() {
        xx=1f; yx=0f; zx=0f;
        xy=0f; yy=1f; zy=0f;
        xz=0f; yz=0f; zz=1f;
    }

    [In(line)] public mat3(float V) {
        xx=V; yx=V; zx=V;
        xy=V; yy=V; zy=V;
        xz=V; yz=V; zz=V;
    }

    [In(line)] public mat3(float XX, float YX, float ZX,
                           float XY, float YY, float ZY,
                           float XZ, float YZ, float ZZ) {
        xx=XX; yx=YX; zx=ZX;
        xy=XY; yy=YY; zy=ZY;
        xz=XZ; yz=YZ; zz=ZZ;
    }

    [In(line)] public mat3(float[] V) {
        xx=V[0]; yx=V[1]; zx=V[2];
        xy=V[3]; yy=V[4]; zy=V[5];
        xz=V[6]; yz=V[7]; zz=V[8];
    }

    //  Truncate Mat4 to Mat3:
    [In(line)] public mat3(mat4 M) {
        xx=M.xx; yx=M.yx; zx=M.zx;
        xy=M.xy; yy=M.yy; zy=M.zy;
        xz=M.xz; yz=M.yz; zz=M.zz;
    }

    //==========================================================================================================================================================
    //                                                                  Directly Assign
    [In(line)] public static implicit operator mat3(float[] V) => new mat3(V); //   float[9]  to  mat3
    [In(line)] public static implicit operator mat3(   mat4 M) => new mat3(M); //       mat4  to  mat3

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %
    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //      Result = (Mat * Mat)
    //
    public static mat3 operator *(mat3 A, mat3 B) => new mat3(XX: A.xx*B.xx + A.yx*B.xy + A.zx*B.xz,
                                                              YX: A.xx*B.yx + A.yx*B.yy + A.zx*B.yz,
                                                              ZX: A.xx*B.zx + A.yx*B.zy + A.zx*B.zz,

                                                              XY: A.xy*B.xx + A.yy*B.xy + A.zy*B.xz,
                                                              YY: A.xy*B.yx + A.yy*B.yy + A.zy*B.yz,
                                                              ZY: A.xy*B.zx + A.yy*B.zy + A.zy*B.zz,

                                                              XZ: A.xz*B.xx + A.yz*B.xy + A.zz*B.xz,
                                                              YZ: A.xz*B.yx + A.yz*B.yy + A.zz*B.yz,
                                                              ZZ: A.xz*B.zx + A.yz*B.zy + A.zz*B.zz );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //                                     Vx    Vy    Vz   |
    //                                  --------------------+----
    //                                     Mxx + Myx + Mzx  | Rx
    //                                                      |
    //      Result = (Vec * Mat)           Mxy + Myy + Mzy  | Ry
    //                                                      |
    //                                     Mxz + Myz + Mzz  | Rz
    //                                                      |
    //
    public static vec3 operator *(vec3 V, mat3 M) => new vec3(V.x*M.xx + V.y*M.yx + V.z*M.zx,
                                                              V.x*M.xy + V.y*M.yy + V.z*M.zy,
                                                              V.x*M.xz + V.y*M.yz + V.z*M.zz );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //                                      |
    //                                   Vx |  Mxx  Myx  Mzx
    //                                      |  +    +    +
    //      Result = (Mat * Vec)         Vy |  Mxy  Myy  Mzy
    //                                      |  +    +    +
    //                                   Vz |  Mxz  Myz  Mzz
    //                                  ----+-----------------
    //                                      |  Rx   Ry   Rz
    //
    public static vec3 operator *(mat3 M, vec3 V) => new vec3(V.x*M.xx + V.x*M.xy + V.x*M.xz,
                                                              V.y*M.yx + V.y*M.yy + V.y*M.yz,
                                                              V.z*M.zx + V.z*M.zy + V.z*M.zz );

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    public static bool operator ==(mat3 A, mat3 B) => (A.xx==B.xx && A.yx==B.yx && A.zx==B.zx &&
                                                       A.xy==B.xy && A.yy==B.yy && A.zy==B.zy &&
                                                       A.xz==B.xz && A.yz==B.yz && A.zz==B.zz );

    public static bool operator !=(mat3 A, mat3 B) => (A.xx!=B.xx || A.yx!=B.yx || A.zx!=B.zx ||
                                                       A.xy!=B.xy || A.yy!=B.yy || A.zy!=B.zy ||
                                                       A.xz!=B.xz || A.yz!=B.yz || A.zz!=B.zz );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly override string ToString() => $"""
        |  {xx,8:0.00000}  {yx,8:0.00000}  {zx,8:0.00000}  |
        |  {xy,8:0.00000}  {yy,8:0.00000}  {zy,8:0.00000}  |
        |  {xz,8:0.00000}  {yz,8:0.00000}  {zz,8:0.00000}  |
    """;

    //==========================================================================================================================================================
    //  Required by types that implement "==" or "!=" operator:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}}

