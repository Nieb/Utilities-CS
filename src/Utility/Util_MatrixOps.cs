
namespace Utility;
internal static partial class MAT {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  All of these assume:
    //      Going from right-handed Y-Up|Z-Up coordinate-space  to  native OpenGL coordinate-space.
    //      (Vec * Mat) usage.
    //
    //  (Mat * Vec) usage will require transposition:
    //      glProgramUniformMatrix4fv(
    //            program: ProgramID,
    //           location: UniformLocation,
    //              count: 1,
    //          transpose: true,
    //              value: Matrix
    //      );
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  DepthRange == (Near, Far);
    //
    [Impl(AggressiveInlining)] public static mat4 ToView2D(vec2 ViewSize, vec2 DepthRange=default, //float ViewDepthNear, float ViewDepthFar,
                                                           bool CornerOrigin=true, bool FlipX=false, bool FlipY=false) {
        float x0 = 0f, x1 = (FlipX ? -2f : 2f)/ViewSize.x;
        float y0 = 0f, y1 = (FlipY ? -2f : 2f)/ViewSize.y;
        float z0 = 0f, z1 = 1f;

        if (CornerOrigin) {
            x0 = (FlipX ? 1f : -1f);
            y0 = (FlipY ? 1f : -1f);
        }

        if (DepthRange != 0f) {
            float N = DepthRange.x;
            float F = DepthRange.y;
            float dZ = (F-N);

            z0 = -(F+N)/dZ;
            z1 =     2f/dZ;
        }

        return new mat4(
            x1,  0,  0, x0,
             0, y1,  0, y0,
             0,  0, z1, z0,
             0,  0,  0,  1
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Translate World-to-View.
    //
    //  Combined version.
    //
    //      ToView(  CameraPos,  CameraPch,  CameraYaw  )
    //
    [Impl(AggressiveInlining)] public static mat4 ToView(vec3 Pos, float Pch, float Yaw) {
        (float SinPch, float CosPch) = sincos(-Pch);
        (float SinYaw, float CosYaw) = sincos(-Yaw);
        #if Z_UP
            return new mat4(
                        CosYaw,             0,        SinYaw,  -Pos.x*(       CosYaw)                  - Pos.y*(       SinYaw),
                 SinPch*SinYaw,        CosPch,-SinPch*CosYaw,  -Pos.x*(SinPch*SinYaw) - Pos.z*(CosPch) + Pos.y*(SinPch*CosYaw),
                -CosPch*SinYaw,        SinPch, CosPch*CosYaw,   Pos.x*(CosPch*SinYaw) - Pos.z*(SinPch) - Pos.y*(CosPch*CosYaw),
                             0,             0,             0,                                                                1
            );
        #else
            return new(); //  todo...
        #endif
    }

    //==========================================================================================================================================================
    //
    //  Reference version.
    //
    [Impl(AggressiveInlining)] public static mat4 ToView___(vec3 Pos, float Pch, float Yaw) {
        (float SinPch, float CosPch) = sincos(-Pch);
        (float SinYaw, float CosYaw) = sincos(-Yaw);
        mat4 mPch = new(
                  1,      0,      0,      0,
                  0, CosPch,-SinPch,      0,
                  0, SinPch, CosPch,      0,
                  0,      0,      0,      1
        );
        mat4 mYaw = new(
             CosYaw,      0, SinYaw,      0,
                  0,      1,      0,      0,
            -SinYaw,      0, CosYaw,      0,
                  0,      0,      0,      1
        );
        #if Z_UP
            mat4 mPos = new(
                1, 0, 0, -Pos.x,
                0, 1, 0, -Pos.z,
                0, 0, 1, -Pos.y,
                0, 0, 0,      1
            );
        #else
            mat4 mPos = new(
                1, 0, 0, -Pos.x,
                0, 1, 0, -Pos.y,
                0, 0, 1,  Pos.z, //  This will reverse Triangle Indices.  Use glFrontFace(GL_CW);
                0, 0, 0,      1
            );
        #endif
        return mPch * mYaw * mPos;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Project View-to-Orthographic
    //
    [Impl(AggressiveInlining)] public static mat4 ToOrthographic(float ViewRadiusX, float ViewRadiusY, float ViewDepthNear, float ViewDepthFar) {
        float N = ViewDepthNear;
        float F = ViewDepthFar;
        float dZ = (F-N);

        float R = ViewRadiusX;
        float T = ViewRadiusY;

        return new mat4(
            1/R,   0,    0,         0,
              0, 1/T,    0,         0,
              0,   0, 2/dZ, -(F+N)/dZ,
              0,   0,    0,         1
        );
    }

    //==========================================================================================================================================================
    //
    //  Asymmetric-Frustum version
    //
    [Impl(AggressiveInlining)] public static mat4 ToOrthographicAsymmetric() {
        return new(); //  todo...
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Project View-to-Perspective
    //
    //  https://www.desmos.com/calculator/4armk0kenc
    //
    [Impl(AggressiveInlining)] public static mat4 ToPerspective(float ViewAspectX, float FovY, float ViewDepthNear, float ViewDepthFar) {
        float F = ViewDepthFar;
        float N = ViewDepthNear;

        float T =  N * tan(FovY/2);
        float B = -T;

        float R =  T * ViewAspectX;
        float L = -R;

        float dX = (R-L); //  Width  at NearPlane.
        float dY = (T-B); //  Height at NearPlane.
        float dZ = (F-N); //  DepthRange  Near to Far.

        return new mat4(
            (2*N)/dX,        0,        0,           0,
                   0, (2*N)/dY,        0,           0,
                   0,        0, (F+N)/dZ, -(2*F*N)/dZ,
                   0,        0,        1,           0
        );
    }

    //==========================================================================================================================================================
    //
    //  Asymmetric-Frustum version
    //
    [Impl(AggressiveInlining)] public static mat4 ToPerspectiveAsymmetric() {
        return new(); //  todo...

        //return new mat4(
        //    (2*N)/dX,        0, (R+L)/dX,           0,
        //           0, (2*N)/dY, (T+B)/dY,           0,
        //           0,        0, (F+N)/dZ, -(2*F*N)/dZ,
        //           0,        0,        1,           0
        //);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
