//##############################################################################################################################################################
//##############################################################################################################################################################
global using Utility;

global using static Utility.Array;
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

global using static Utility.VEC;
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
global using u16 = ushort;  //  System.UInt1        Unsigned 16-bit Integer

global using s32 =  int;    //  System.Int32          Signed 32-bit Integer
global using u32 = uint;    //  System.UInt3        Unsigned 32-bit Integer

global using s64 =  long;   //  System.Int64          Signed 64-bit Integer
global using u64 = ulong;   //  System.UInt6        Unsigned 64-bit Integer

//--------------------------------------------------------------------------------------------------------------------------------------------------------------
global using f16 = System.Half;
global using f32 = float;   //  System.Single
global using f64 = double;  //  System.Double

//--------------------------------------------------------------------------------------------------------------------------------------------------------------
global using d32 = Utility.DATA.Data32;
global using d64 = Utility.DATA.Data64;

//==============================================================================================================================================================
//#pragma warning disable CS8981 //  warning CS8981: The type name '' only contains lower-cased ascii characters.  Such names may become reserved for the language.
//    global using iptr = nint;   //  System.IntPtr         Signed 32-bit or 64-bit integer
//    global using uptr = nuint;  //  System.UIntPtr      Unsigned 32-bit or 64-bit integer
//#pragma warning restore CS8981

//==============================================================================================================================================================
global using b4 = Utility.VEC.bvec4;
global using b8 = Utility.VEC.bvec8;

global using i1 = int;
global using i2 = Utility.VEC.ivec2;    global using I2 = (int x, int y);
global using i3 = Utility.VEC.ivec3;    global using I3 = (int x, int y, int z);
global using i4 = Utility.VEC.ivec4;    global using I4 = (int x, int y, int z, int w);

global using v1 = float;
global using v2 = Utility.VEC.vec2;     global using V2 = (float x, float y);
global using v3 = Utility.VEC.vec3;     global using V3 = (float x, float y, float z);
global using v4 = Utility.VEC.vec4;     global using V4 = (float x, float y, float z, float w);

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

//##############################################################################################################################################################
//##############################################################################################################################################################
//                                                                   Method Implementation

global using Impl = System.Runtime.CompilerServices.MethodImplAttribute;
global using static System.Runtime.CompilerServices.MethodImplOptions;

/*
    [Impl(AggressiveInlining|AggressiveOptimization)]
    [Impl(AggressiveInlining)]
    [Impl(AggressiveOptimization)]      This appears to only be relevant to CIL/JIT optimization behavior.
                                        Native-AOT compilation always goes through optimization.

    [MethodImpl(MethodImplOptions.AggressiveInlining|MethodImplOptions.AggressiveOptimization)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
*/

/*
    MethodImplOptions

        Unmanaged               The method is implemented in unmanaged code.


        ForwardRef              The method is declared, but its implementation is provided elsewhere.


        InternalCall            The call is internal, that is, it calls a method that's implemented within the common language runtime.


        PreserveSig             The method signature is exported exactly as declared.


        Synchronized            The method can be executed by only one thread at a time.

                                Static methods lock on the type, whereas
                                instance methods lock on the instance.

                                Only one thread can execute in any of the instance functions,
                                and only one thread can execute in any of a class's static functions.


        NoInlining              The method cannot be inlined.
                                Inlining is an optimization by which a method call is replaced with the method body.


        NoOptimization          The method is not optimized by the just-in-time (JIT) compiler
                                or by native code generation (see Ngen.exe) when debugging possible code generation problems.


        AggressiveInlining      The method should be inlined if possible.
                                Unnecessary use of this attribute can reduce performance.
                                The attribute might cause implementation limits to be encountered that will result in slower generated code.
                                Always measure performance to ensure it's helpful to apply this attribute.

        AggressiveOptimization  The method contains code that should always be optimized for performance.

                                Methods that apply this attribute bypass the first tier of tiered compilation
                                and therefore don't benefit from optimizations that rely on tiered compilation.

                                Those optimizations include dynamic PGO and optimizations based on initialized classes.

                                It's rarely appropriate to use this attribute.
                                Use of this attribute may also increase memory use.
                                Always measure performance to ensure it's helpful to apply this attribute.
*/
