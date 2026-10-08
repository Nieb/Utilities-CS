
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Interpolation() {
        TESTOUT("\n[Utility.VEC -- Interpolation]");

        //======================================================================================================================================================
        TEST("Mix()",true
            && Mix(0.0f, 1.7f, 3.4f).IsApproximately(1.7f)
            && Mix(0.5f, 1.7f, 3.4f).IsApproximately(2.55f)
            && Mix(1.0f, 1.7f, 3.4f).IsApproximately(3.4f)

            && Mix(         0.0f , new vec2(1.7f), new vec2(3.4f)).IsApproximately(new vec2(1.70f))
            && Mix(         0.5f , new vec2(1.7f), new vec2(3.4f)).IsApproximately(new vec2(2.55f))
            && Mix(         1.0f , new vec2(1.7f), new vec2(3.4f)).IsApproximately(new vec2(3.40f))
            && Mix(new vec2(0.0f), new vec2(1.7f), new vec2(3.4f)).IsApproximately(new vec2(1.70f))
            && Mix(new vec2(0.5f), new vec2(1.7f), new vec2(3.4f)).IsApproximately(new vec2(2.55f))
            && Mix(new vec2(1.0f), new vec2(1.7f), new vec2(3.4f)).IsApproximately(new vec2(3.40f))

            && Mix(         0.0f , new vec3(1.7f), new vec3(3.4f)).IsApproximately(new vec3(1.70f))
            && Mix(         0.5f , new vec3(1.7f), new vec3(3.4f)).IsApproximately(new vec3(2.55f))
            && Mix(         1.0f , new vec3(1.7f), new vec3(3.4f)).IsApproximately(new vec3(3.40f))
            && Mix(new vec3(0.0f), new vec3(1.7f), new vec3(3.4f)).IsApproximately(new vec3(1.70f))
            && Mix(new vec3(0.5f), new vec3(1.7f), new vec3(3.4f)).IsApproximately(new vec3(2.55f))
            && Mix(new vec3(1.0f), new vec3(1.7f), new vec3(3.4f)).IsApproximately(new vec3(3.40f))

            && Mix(         0.0f , new vec4(1.7f), new vec4(3.4f)).IsApproximately(new vec4(1.70f))
            && Mix(         0.5f , new vec4(1.7f), new vec4(3.4f)).IsApproximately(new vec4(2.55f))
            && Mix(         1.0f , new vec4(1.7f), new vec4(3.4f)).IsApproximately(new vec4(3.40f))
            && Mix(new vec4(0.0f), new vec4(1.7f), new vec4(3.4f)).IsApproximately(new vec4(1.70f))
            && Mix(new vec4(0.5f), new vec4(1.7f), new vec4(3.4f)).IsApproximately(new vec4(2.55f))
            && Mix(new vec4(1.0f), new vec4(1.7f), new vec4(3.4f)).IsApproximately(new vec4(3.40f))
        );

        TEST("BiMix()",true
            && BiMix((0f, 0f), 0f, 1f, 2f, 3f).IsApproximately(0f)
            && BiMix((1f, 0f), 0f, 1f, 2f, 3f).IsApproximately(1f)
            && BiMix((0f, 1f), 0f, 1f, 2f, 3f).IsApproximately(2f)
            && BiMix((1f, 1f), 0f, 1f, 2f, 3f).IsApproximately(3f)

            && BiMix((0.25f, 0.25f), 0f, 1f, 2f, 3f).IsApproximately(0.75f)
            && BiMix((0.50f, 0.25f), 0f, 1f, 2f, 3f).IsApproximately(1.00f)
            && BiMix((0.75f, 0.25f), 0f, 1f, 2f, 3f).IsApproximately(1.25f)
            && BiMix((0.25f, 0.50f), 0f, 1f, 2f, 3f).IsApproximately(1.25f)
            && BiMix((0.50f, 0.50f), 0f, 1f, 2f, 3f).IsApproximately(1.50f)
            && BiMix((0.75f, 0.50f), 0f, 1f, 2f, 3f).IsApproximately(1.75f)
            && BiMix((0.25f, 0.75f), 0f, 1f, 2f, 3f).IsApproximately(1.75f)
            && BiMix((0.50f, 0.75f), 0f, 1f, 2f, 3f).IsApproximately(2.00f)
            && BiMix((0.75f, 0.75f), 0f, 1f, 2f, 3f).IsApproximately(2.25f)

            && BiMix((0f, 0f), new vec2(0f), new vec2(1f), new vec2(2f), new vec2(3f)).IsApproximately(new vec2(0f))
            && BiMix((1f, 0f), new vec2(0f), new vec2(1f), new vec2(2f), new vec2(3f)).IsApproximately(new vec2(1f))
            && BiMix((0f, 1f), new vec2(0f), new vec2(1f), new vec2(2f), new vec2(3f)).IsApproximately(new vec2(2f))
            && BiMix((1f, 1f), new vec2(0f), new vec2(1f), new vec2(2f), new vec2(3f)).IsApproximately(new vec2(3f))

            && BiMix((0f, 0f), new vec3(0f), new vec3(1f), new vec3(2f), new vec3(3f)).IsApproximately(new vec3(0f))
            && BiMix((1f, 0f), new vec3(0f), new vec3(1f), new vec3(2f), new vec3(3f)).IsApproximately(new vec3(1f))
            && BiMix((0f, 1f), new vec3(0f), new vec3(1f), new vec3(2f), new vec3(3f)).IsApproximately(new vec3(2f))
            && BiMix((1f, 1f), new vec3(0f), new vec3(1f), new vec3(2f), new vec3(3f)).IsApproximately(new vec3(3f))

            && BiMix((0f, 0f), new vec4(0f), new vec4(1f), new vec4(2f), new vec4(3f)).IsApproximately(new vec4(0f))
            && BiMix((1f, 0f), new vec4(0f), new vec4(1f), new vec4(2f), new vec4(3f)).IsApproximately(new vec4(1f))
            && BiMix((0f, 1f), new vec4(0f), new vec4(1f), new vec4(2f), new vec4(3f)).IsApproximately(new vec4(2f))
            && BiMix((1f, 1f), new vec4(0f), new vec4(1f), new vec4(2f), new vec4(3f)).IsApproximately(new vec4(3f))
        );

        TEST("SmoothMix()",true
            && SmoothMix(0.0f , 1.7f, 3.4f).IsApproximately(1.7f)
            && SmoothMix(0.25f, 1.7f, 3.4f).IsApproximately(1.965625f)
            && SmoothMix(0.5f , 1.7f, 3.4f).IsApproximately(2.55f)
            && SmoothMix(0.75f, 1.7f, 3.4f).IsApproximately(3.134375f)
            && SmoothMix(1.0f , 1.7f, 3.4f).IsApproximately(3.4f)

            && SmoothMix(0.0f,  new vec2(1.7f), new vec2(3.4f)).IsApproximately(new vec2(1.7f))
            && SmoothMix(0.25f, new vec2(1.7f), new vec2(3.4f)).IsApproximately(new vec2(1.965625f))
            && SmoothMix(0.5f,  new vec2(1.7f), new vec2(3.4f)).IsApproximately(new vec2(2.55f))
            && SmoothMix(0.75f, new vec2(1.7f), new vec2(3.4f)).IsApproximately(new vec2(3.134375f))
            && SmoothMix(1.0f,  new vec2(1.7f), new vec2(3.4f)).IsApproximately(new vec2(3.4f))

            && SmoothMix(0.0f,  new vec3(1.7f), new vec3(3.4f)).IsApproximately(new vec3(1.7f))
            && SmoothMix(0.25f, new vec3(1.7f), new vec3(3.4f)).IsApproximately(new vec3(1.965625f))
            && SmoothMix(0.5f,  new vec3(1.7f), new vec3(3.4f)).IsApproximately(new vec3(2.55f))
            && SmoothMix(0.75f, new vec3(1.7f), new vec3(3.4f)).IsApproximately(new vec3(3.134375f))
            && SmoothMix(1.0f,  new vec3(1.7f), new vec3(3.4f)).IsApproximately(new vec3(3.4f))

            && SmoothMix(0.0f,  new vec4(1.7f), new vec4(3.4f)).IsApproximately(new vec4(1.7f))
            && SmoothMix(0.25f, new vec4(1.7f), new vec4(3.4f)).IsApproximately(new vec4(1.965625f))
            && SmoothMix(0.5f,  new vec4(1.7f), new vec4(3.4f)).IsApproximately(new vec4(2.55f))
            && SmoothMix(0.75f, new vec4(1.7f), new vec4(3.4f)).IsApproximately(new vec4(3.134375f))
            && SmoothMix(1.0f,  new vec4(1.7f), new vec4(3.4f)).IsApproximately(new vec4(3.4f))
        );

        //======================================================================================================================================================
        TEST("Step()",true
            && Step(-2.00f, -1f) == 0f
            && Step(-1.50f, -1f) == 0f
            && Step(-1.01f, -1f) == 0f
            && Step(-1.00f, -1f) == 1f
            && Step(-0.99f, -1f) == 1f
            && Step(-0.50f, -1f) == 1f
            && Step( 0.00f, -1f) == 1f

            && Step(0.00f, 1f) == 0f
            && Step(0.50f, 1f) == 0f
            && Step(0.99f, 1f) == 0f
            && Step(1.00f, 1f) == 1f
            && Step(1.01f, 1f) == 1f
            && Step(1.50f, 1f) == 1f
            && Step(2.00f, 1f) == 1f
        );

        TEST("LinearStep()",true
            && LinearStep(1.70f , 1.7f, 3.4f).IsApproximately(0.0f)
            && LinearStep(2.125f, 1.7f, 3.4f).IsApproximately(0.25f)
            && LinearStep(2.55f , 1.7f, 3.4f).IsApproximately(0.5f)
            && LinearStep(2.975f, 1.7f, 3.4f).IsApproximately(0.75f)
            && LinearStep(3.40f , 1.7f, 3.4f).IsApproximately(1.0f)
        );

        TEST("SmoothStep()",true
            && SmoothStep(1.70f , 1.7f, 3.4f).IsApproximately(0.0f)
            && SmoothStep(2.125f, 1.7f, 3.4f).IsApproximately(0.15625f) //   5/32
            && SmoothStep(2.55f , 1.7f, 3.4f).IsApproximately(0.5f)
            && SmoothStep(2.975f, 1.7f, 3.4f).IsApproximately(0.84375f) //  27/32
            && SmoothStep(3.40f , 1.7f, 3.4f).IsApproximately(1.0f)
        );

        //======================================================================================================================================================
        TEST("QuadStep() & PowerStep()",true
            && QuadStep(-0.2f).IsApproximately(PowerStep(-0.2f, 2f))
            && QuadStep(-0.1f).IsApproximately(PowerStep(-0.1f, 2f))
            && QuadStep( 0.0f).IsApproximately(PowerStep( 0.0f, 2f))
            && QuadStep( 0.1f).IsApproximately(PowerStep( 0.1f, 2f))
            && QuadStep( 0.2f).IsApproximately(PowerStep( 0.2f, 2f))
            && QuadStep( 0.3f).IsApproximately(PowerStep( 0.3f, 2f))
            && QuadStep( 0.4f).IsApproximately(PowerStep( 0.4f, 2f))
            && QuadStep( 0.5f).IsApproximately(PowerStep( 0.5f, 2f))
            && QuadStep( 0.6f).IsApproximately(PowerStep( 0.6f, 2f))
            && QuadStep( 0.7f).IsApproximately(PowerStep( 0.7f, 2f))
            && QuadStep( 0.8f).IsApproximately(PowerStep( 0.8f, 2f))
            && QuadStep( 0.9f).IsApproximately(PowerStep( 0.9f, 2f))
            && QuadStep( 1.0f).IsApproximately(PowerStep( 1.0f, 2f))
            && QuadStep( 1.1f).IsApproximately(PowerStep( 1.1f, 2f))
            && QuadStep( 1.2f).IsApproximately(PowerStep( 1.2f, 2f))
        );

        //======================================================================================================================================================
    }
}
