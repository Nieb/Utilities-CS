
namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    /*##########################################################################################################################################################
                                                                        Coordinate Space
                                                    Y-Up                                                 Z-Up
                                    Default     Right-Handed                                         Right-Handed

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
                                                                  Result is NOT component-wise!
                                           |                                                                               ●
                                           | (B >= A) == true                                             (B < A) == false
                                           ●
                                           |       (B > A) == true                                                   A
                                           |     ●                                                  ----●-----------●
                                           |             (B > A) == false              (B < A) == false             |
                                           ●-----------●----                                                  ●     |
                                          A                                                   (B < A) == true       |
                                                                                                                    ●
                                    ●                                                              (B <= A) == true |
                                      (B > A) == false                                                              |

    //########################################################################################################################################################*/
    //##########################################################################################################################################################
    [In(line)] public static System.ReadOnlySpan< int >.Enumerator GetEnumerator(this in ivec2 V) => ((System.ReadOnlySpan< int >)V).GetEnumerator();
    [In(line)] public static System.ReadOnlySpan<float>.Enumerator GetEnumerator(this in  vec2 V) => ((System.ReadOnlySpan<float>)V).GetEnumerator();
    [In(line)] public static System.ReadOnlySpan< int >.Enumerator GetEnumerator(this in ivec3 V) => ((System.ReadOnlySpan< int >)V).GetEnumerator();
    [In(line)] public static System.ReadOnlySpan<float>.Enumerator GetEnumerator(this in  vec3 V) => ((System.ReadOnlySpan<float>)V).GetEnumerator();
    [In(line)] public static System.ReadOnlySpan< int >.Enumerator GetEnumerator(this in ivec4 V) => ((System.ReadOnlySpan< int >)V).GetEnumerator();
    [In(line)] public static System.ReadOnlySpan<float>.Enumerator GetEnumerator(this in  vec4 V) => ((System.ReadOnlySpan<float>)V).GetEnumerator();

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
