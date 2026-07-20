
namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    /*##########################################################################################################################################################
                                                                        Coordinate Space
                                                   "Y Up"                                               "Z Up"
                                          (right-handed, default)                                   (right-handed)

                                                +Y  Up                                               +Z  Up
                                               |                                                    |
                                               |                                                    |
                                               |                                                    |    +Y  Far
                                               |                                                    |  /
                                               |                                                    | /
                                               |            +X  Right                               |/           +X  Right
                                               ●------------                                        ●------------
                                              /
                                             /
                                            /                                   <DefineConstants>$(DefineConstants);Z_UP;</DefineConstants>
                                             +Z  Near

    //########################################################################################################################################################*/
    /*##########################################################################################################################################################
                                                                    Component-wise Comparison
                                                                 (result is not component-wise)

                                           |                                                                               ●
                                           | (B >= A) == TRUE                                             (B < A) == FALSE
                                           ●
                                           |       (B > A) == TRUE                                                   A
                                           |     ●                                                  ----●-----------●
                                           |             (B > A) == FALSE              (B < A) == FALSE             |
                                           ●-----------●----                                                  ●     |
                                          A                                                   (B < A) == TRUE       |
                                                                                                                    ●
                                    ●                                                              (B <= A) == TRUE |
                                      (B > A) == FALSE                                                              |

    //########################################################################################################################################################*/
    //##########################################################################################################################################################
    #if DEBUG || true
        internal static bool IsApproximatelyZero(this v1 A)   => abs(A)   < EPS6;
        internal static bool IsApproximatelyZero(this v2 A)   => abs(A)   < EPS6;
        internal static bool IsApproximatelyZero(this v3 A)   => abs(A)   < EPS6;
        internal static bool IsApproximatelyZero(this v4 A)   => abs(A)   < EPS6;

        internal static bool IsApproximately(this v1 A, v1 B) => abs(B-A) < EPS6;
        internal static bool IsApproximately(this v2 A, v2 B) => abs(B-A) < EPS6;
        internal static bool IsApproximately(this v3 A, v3 B) => abs(B-A) < EPS6;
        internal static bool IsApproximately(this v4 A, v4 B) => abs(B-A) < EPS6;

        internal static bool IsRoughly(this v1 A, v1 B)       => abs(B-A) < EPS4;
        internal static bool IsRoughly(this v2 A, v2 B)       => abs(B-A) < EPS4;
        internal static bool IsRoughly(this v3 A, v3 B)       => abs(B-A) < EPS4;
        internal static bool IsRoughly(this v4 A, v4 B)       => abs(B-A) < EPS4;
    #endif
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
