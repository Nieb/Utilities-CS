//##############################################################################################################################################################
//##############################################################################################################################################################
global using Utility;

global using static Utility.Array;
global using static Utility.Array_Indexing;
global using static Utility.BitOps;
global using static Utility.Casting;
global using static Utility.Constants;
global using static Utility.Miscellaneous;
global using static Utility.Random;

global using static Utility.DATA;
global using static Utility.FLT;
global using static Utility.INT;
global using static Utility.STR;

global using static Utility.MAT;
global using static Utility.QUAT;

global using static Utility.VEC;
global using static Utility.VEC_Collision;
global using static Utility.VEC_Collision2;
global using static Utility.VEC_Collision3;
global using static Utility.VEC_Color;
global using static Utility.VEC_Filter;
global using static Utility.VEC_Generate;
global using static Utility.VEC_Geometry;
global using static Utility.VEC_Interpolation;
global using static Utility.VEC_Interpolation2;
global using static Utility.VEC_Miscellaneous;
global using static Utility.VEC_Projection;
global using static Utility.VEC_Rotation;
global using static Utility.VEC_Triangle;

//##############################################################################################################################################################
//##############################################################################################################################################################
//global using  b8 = bool;    //  System.Boolean

//--------------------------------------------------------------------------------------------------------------------------------------------------------------
global using  s8 = sbyte;   //  System.SByte          Signed  8-bit Integer
global using  u8 =  byte;   //  System.Byte         Unsigned  8-bit Integer

global using s16 =  short;  //  System.Int16          Signed 16-bit Integer
global using u16 = ushort;  //  System.UInt16       Unsigned 16-bit Integer

global using s32 =  int;    //  System.Int32          Signed 32-bit Integer
global using u32 = uint;    //  System.UInt32       Unsigned 32-bit Integer

global using s64 =  long;   //  System.Int64          Signed 64-bit Integer
global using u64 = ulong;   //  System.UInt64       Unsigned 64-bit Integer

//--------------------------------------------------------------------------------------------------------------------------------------------------------------
global using f16 = System.Half;
global using f32 = float;   //  System.Single
global using f64 = double;  //  System.Double

//--------------------------------------------------------------------------------------------------------------------------------------------------------------
global using d32 = Utility.DATA.Data32;
global using d64 = Utility.DATA.Data64;

//==============================================================================================================================================================
//#pragma warning disable CS8981 //  warning CS8981: The type name '*' only contains lower-cased ASCII characters.  Such names may become reserved for the language.
//    global using iptr = nint;   //  System.IntPtr         Signed 32-bit or 64-bit integer
//    global using uptr = nuint;  //  System.UIntPtr      Unsigned 32-bit or 64-bit integer
//#pragma warning restore CS8981

//==============================================================================================================================================================
global using b4 = Utility.VEC.bvec4;
global using b8 = Utility.VEC.bvec8;

global using i1 = int;
global using i2 = Utility.VEC.ivec2;
global using i3 = Utility.VEC.ivec3;
global using i4 = Utility.VEC.ivec4;

global using v1 = float;
global using v2 = Utility.VEC.vec2;
global using v3 = Utility.VEC.vec3;
global using v4 = Utility.VEC.vec4;

global using m2 = Utility.MAT.mat2;
global using m3 = Utility.MAT.mat3;
global using m4 = Utility.MAT.mat4;

//##############################################################################################################################################################
//##############################################################################################################################################################
//                                                                       Struct Layout
//                  [StructLayout(LayoutKind.Auto)]
//                  [StructLayout(LayoutKind.Explicit)]
//                  [StructLayout(LayoutKind.Sequential)]
//
//                  [FieldOffset(0)]
//                  [FieldOffset(4)]
//
global using StructLayout = System.Runtime.InteropServices.StructLayoutAttribute;
global using LayoutKind   = System.Runtime.InteropServices.LayoutKind;
global using FieldOffset  = System.Runtime.InteropServices.FieldOffsetAttribute;
