
namespace Utility;
internal static partial class VEC_Miscellaneous {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  A & B should be normalized.
    //
    //          B     M            M
    //           \   /              \
    //            \ /                \
    //             o-----A            o-----A
    //                               /
    //                              /
    //                             B
    //
    //  https://www.desmos.com/calculator/0bfrvyicjc
    //
    internal static vec2 Bisect(vec2 An, vec2 Bn) {
        vec2 Bisector = An + Bn;
        return (abs(Bisector) < EPS6) ? rot_lf(An)
                                      : normalize((cross(An,Bn) < 0f) ? -Bisector : Bisector);
    }

    /*internal static vec2 Bisect(vec2 A, vec2 B) {
        float tA = atan2(A.y, A.x);
        float tB = atan2(B.y, B.x);

        float dAB = (tB-tA + PI2) % PI2; //  "+ PI2" to compensate for negative modulo behavior.

        float tM = tA + (dAB * 0.5f);

        (float mSin, float mCos) = sincos(tM);
        return new vec2(mCos, mSin);
    }*/

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  ViewAspectX == ViewSizeX/ViewSizeY      16/9  == 1.777~
    //  ViewAspectY == ViewSizeY/ViewSizeX       9/16 == 0.5625
    //
    //  NOTE:  This is for a Planar-Projection Camera!  Not a Radial-Projection.
    //
    [In(line)] internal static float FovX_FromY(float FovY, float ViewAspectX)               => 2f * atan2(tan(FovY/2f) * ViewAspectX, 1f);
    [In(line)] internal static float FovY_FromX(float FovX, float ViewAspectY)               => 2f * atan2(tan(FovX/2f) * ViewAspectY, 1f);

    //==========================================================================================================================================================
    [In(line)] internal static float FovX_FromY_Stereographic(float FovY, float ViewAspectX) => 4f * atan2(tan(FovY/4f) * ViewAspectX, 1f);
    [In(line)] internal static float FovY_FromX_Stereographic(float FovX, float ViewAspectY) => 4f * atan2(tan(FovX/4f) * ViewAspectY, 1f);

    //==========================================================================================================================================================
    //internal static float FovX_FromY_Equidistant(float FovY, float ViewAspectX) => FovY * ViewAspectX;

    //internal static float FovX_FromY_Equisolid(float FovY, float ViewAspectX) => 2f * asin(sin(FovY / 2f) * ViewAspectX);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  AKA: HaversineDistance
    //
    //  Inputs are a Rotation-Vector (Pitch, Yaw) in radians.
    //  Output is Distance in radians (0 to PI).
    //
    internal static float SphericalDistance(vec2 A, vec2 B) {
        vec2 d = 0.5f - 0.5f*cos(B-A);
        return 2f * asin(sqrt( d.x  +  d.y*cos(A.x)*cos(B.x) ));
    }

    //==========================================================================================================================================================
    //
    //  Inputs are a Unit-Direction-Vector.
    //  Output is Distance in radians (0 to PI).
    //
    //internal static float SphericalDistance(vec3 A, vec3 B) => acos(dot(A,B));                    //  Not numerically stable?    acos() == NaN  from tiny overshoots.
    //internal static float SphericalDistance(vec3 A, vec3 B) => acos(clamp(dot(A,B), -1f, 1f));
    internal static float SphericalDistance(vec3 A, vec3 B) => atan2(length(cross(A,B)), dot(A,B));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [In(line)] internal static v1 WeightedSum(v1 A,v1 B,            v2 W) => (A*W.x + B*W.y);
    [In(line)] internal static v2 WeightedSum(v2 A,v2 B,            v2 W) => (A*W.x + B*W.y);
    [In(line)] internal static v3 WeightedSum(v3 A,v3 B,            v2 W) => (A*W.x + B*W.y);
    [In(line)] internal static v4 WeightedSum(v4 A,v4 B,            v2 W) => (A*W.x + B*W.y);

    [In(line)] internal static v1 WeightedSum(v1 A,v1 B,v1 C,       v3 W) => (A*W.x + B*W.y + C*W.z);
    [In(line)] internal static v2 WeightedSum(v2 A,v2 B,v2 C,       v3 W) => (A*W.x + B*W.y + C*W.z);
    [In(line)] internal static v3 WeightedSum(v3 A,v3 B,v3 C,       v3 W) => (A*W.x + B*W.y + C*W.z);
    [In(line)] internal static v4 WeightedSum(v4 A,v4 B,v4 C,       v3 W) => (A*W.x + B*W.y + C*W.z);

    [In(line)] internal static v1 WeightedSum(v1 A,v1 B,v1 C,v1 D,  v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);
    [In(line)] internal static v2 WeightedSum(v2 A,v2 B,v2 C,v2 D,  v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);
    [In(line)] internal static v3 WeightedSum(v3 A,v3 B,v3 C,v3 D,  v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);
    [In(line)] internal static v4 WeightedSum(v4 A,v4 B,v4 C,v4 D,  v4 W) => (A*W.x + B*W.y + C*W.z + D*W.w);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Efficient DDA Circle Outline
    //  by Casey Muratori
    //
    //      KC_Circle(  Radius,  Padding-LowerBounds,  Padding-UpperBounds  )
    //
    internal static uint[] KC_Circle(int R, int PadLow=1, int PadUpr=2, uint CenterColor=0xFF0000FFu, uint CircleColor=0x996633FFu, uint BgColor=0x000000FFu) {  //  RrGgBbAa
        int R2 = R+R;
        int X  =  R;
        int Y  =  0;
        int dY = -2;
        int dX = R2+R2 - 4;
        int D  = R2 - 1;

        int Pos = PadLow + R;
        int Dim = Pos + 1 + R + PadUpr;

        uint[] Bitmap = new uint[Dim*Dim];

        Bitmap.FillWith(BgColor);

        Bitmap[Pos+(Pos*Dim)] = CenterColor;

        while (Y <= X) {
            Bitmap[Pos-X + ((Pos-Y) * Dim)] = CircleColor; //  (-X, -Y)
            Bitmap[Pos+X + ((Pos-Y) * Dim)] = CircleColor; //  ( X, -Y)
            Bitmap[Pos-X + ((Pos+Y) * Dim)] = CircleColor; //  (-X,  Y)
            Bitmap[Pos+X + ((Pos+Y) * Dim)] = CircleColor; //  ( X,  Y)      X decrements    R  to  R/2
            Bitmap[Pos-Y + ((Pos-X) * Dim)] = CircleColor; //  (-Y, -X)      Y increments    0  to  R/2
            Bitmap[Pos+Y + ((Pos-X) * Dim)] = CircleColor; //  ( Y, -X)
            Bitmap[Pos-Y + ((Pos+X) * Dim)] = CircleColor; //  (-Y,  X)
            Bitmap[Pos+Y + ((Pos+X) * Dim)] = CircleColor; //  ( Y,  X)

            D  += dY;
            dY -=  4;
            Y  +=  1;

            #if false
                if (D < 0) {
                    D  += dX;
                    dX -= 4;
                    X  -= 1;
                }
            #else //  Branchless version:
                int Mask = (D >> 31);
                D  +=  dX & Mask;
                dX -=   4 & Mask;
                X  +=       Mask;
            #endif
        }

        return Bitmap;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
