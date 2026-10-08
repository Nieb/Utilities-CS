//##############################################################################################################################################################
//##############################################################################################################################################################
//
//      [In(line)]    <--    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//
//--------------------------------------------------------------------------------------------------------------------------------------------------------------

global using In = System.Runtime.CompilerServices.MethodImplAttribute;
global using static InlineConstant;

static class InlineConstant {
    public const System.Runtime.CompilerServices.MethodImplOptions line = System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining;
}

//##############################################################################################################################################################
//##############################################################################################################################################################
//
//  error CS0509: 'InlineAttribute': cannot derive from sealed type 'MethodImplAttribute'    :(
//
//--------------------------------------------------------------------------------------------------------------------------------------------------------------

//static class InlineAttribute : System.Runtime.CompilerServices.MethodImplAttribute {
//    public InlineAttribute() : base(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining) {}
//}

//##############################################################################################################################################################
//##############################################################################################################################################################
//
//      [Impl(AggressiveInlining|AggressiveOptimization)]    <--    [MethodImpl(MethodImplOptions.AggressiveInlining|MethodImplOptions.AggressiveOptimization)]
//
//      [Impl(AggressiveInlining)]                           <--    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//
//      [Impl(AggressiveOptimization)]                       <--    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
//          This appears to be relevant only to CIL/CLR/JIT optimization behavior.
//          Native-AOT compilation always goes through optimization.
//
//--------------------------------------------------------------------------------------------------------------------------------------------------------------

//global using Impl = System.Runtime.CompilerServices.MethodImplAttribute;
//global using static System.Runtime.CompilerServices.MethodImplOptions;

/*
    MethodImplOptions

        Unmanaged               The method is implemented in unmanaged code.


        ForwardRef              The method is declared, but its implementation is provided elsewhere.


        InternalCall            The call is internal, that is, it calls a method that's implemented within the Common-Language-Runtime.


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
