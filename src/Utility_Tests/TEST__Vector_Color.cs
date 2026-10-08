
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Color() {
        TESTOUT("\n[Utility.VEC -- Color]");

        //======================================================================================================================================================
        {
            bool Result = true;
            //System.Text.StringBuilder SB = new();
            for (int i = 0; i < 256; ++i) {
                //if (  UnitToByte(ByteToUnit(u8(i))) != u8(i)  )
                //    SB.AppendLine($"UnitToByte(ByteToUnit({i,3})) == {i,3}    {UnitToByte(ByteToUnit(u8(i))) == u8(i)}");
                Result = Result  &&  (  UnitToByte(ByteToUnit(u8(i))) == u8(i)  );
            }
            //TESTOUT($"{SB}");
            TEST("ByteToUnit() <> UnitToByte()", Result);
        }

        //======================================================================================================================================================
        {
            bool Result = true;
            //System.Text.StringBuilder SB = new();
            for (float v = 0f; v <= 1f; v += 0.001f) {
                //if (!Lin_to_sRGB(sRGB_to_Lin(v)).IsApproximately(v))
                //    SB.AppendLine($"Lin_to_sRGB(sRGB_to_Lin({v})) == {v}    {Lin_to_sRGB(sRGB_to_Lin(v)).IsApproximately(v)}");
                Result = Result  &&  Lin_to_sRGB(sRGB_to_Lin(v)).IsApproximately(v);
            }
            //TESTOUT($"{SB}");
            TEST("sRGB_to_Lin() <> Lin_to_sRGB()", Result);
        }

        //======================================================================================================================================================
        TEST("HSV_to_RGB()",true
            && RGB_to_HSV(1f, 0f, 0f).IsApproximately((0f, 1f, 1f))  &&  RGB_to_HSV(1.0f, 0.5f, 0.0f).IsApproximately((0.5f, 1f, 1f))
            && RGB_to_HSV(1f, 1f, 0f).IsApproximately((1f, 1f, 1f))  &&  RGB_to_HSV(0.5f, 1.0f, 0.0f).IsApproximately((1.5f, 1f, 1f))

            && RGB_to_HSV(0f, 1f, 0f).IsApproximately((2f, 1f, 1f))  &&  RGB_to_HSV(0.0f, 1.0f, 0.5f).IsApproximately((2.5f, 1f, 1f))
            && RGB_to_HSV(0f, 1f, 1f).IsApproximately((3f, 1f, 1f))  &&  RGB_to_HSV(0.0f, 0.5f, 1.0f).IsApproximately((3.5f, 1f, 1f))

            && RGB_to_HSV(0f, 0f, 1f).IsApproximately((4f, 1f, 1f))  &&  RGB_to_HSV(0.5f, 0.0f, 1.0f).IsApproximately((4.5f, 1f, 1f))
            && RGB_to_HSV(1f, 0f, 1f).IsApproximately((5f, 1f, 1f))  &&  RGB_to_HSV(1.0f, 0.0f, 0.5f).IsApproximately((5.5f, 1f, 1f))
        );

        //======================================================================================================================================================
        TEST("HSV_to_RGB()",true
            && HSV_to_RGB(-6f, 1, 1).IsApproximately((1, 0, 0))  &&  HSV_to_RGB(-5.5f, 1f, 1f).IsApproximately((1.0f, 0.5f, 0.0f))
            && HSV_to_RGB(-5f, 1, 1).IsApproximately((1, 1, 0))  &&  HSV_to_RGB(-4.5f, 1f, 1f).IsApproximately((0.5f, 1.0f, 0.0f))
            && HSV_to_RGB(-4f, 1, 1).IsApproximately((0, 1, 0))  &&  HSV_to_RGB(-3.5f, 1f, 1f).IsApproximately((0.0f, 1.0f, 0.5f))
            && HSV_to_RGB(-3f, 1, 1).IsApproximately((0, 1, 1))  &&  HSV_to_RGB(-2.5f, 1f, 1f).IsApproximately((0.0f, 0.5f, 1.0f))
            && HSV_to_RGB(-2f, 1, 1).IsApproximately((0, 0, 1))  &&  HSV_to_RGB(-1.5f, 1f, 1f).IsApproximately((0.5f, 0.0f, 1.0f))
            && HSV_to_RGB(-1f, 1, 1).IsApproximately((1, 0, 1))  &&  HSV_to_RGB(-0.5f, 1f, 1f).IsApproximately((1.0f, 0.0f, 0.5f))

            && HSV_to_RGB( 0f, 1, 1).IsApproximately((1, 0, 0))  &&  HSV_to_RGB( 0.5f, 1f, 1f).IsApproximately((1.0f, 0.5f, 0.0f))
            && HSV_to_RGB( 1f, 1, 1).IsApproximately((1, 1, 0))  &&  HSV_to_RGB( 1.5f, 1f, 1f).IsApproximately((0.5f, 1.0f, 0.0f))
            && HSV_to_RGB( 2f, 1, 1).IsApproximately((0, 1, 0))  &&  HSV_to_RGB( 2.5f, 1f, 1f).IsApproximately((0.0f, 1.0f, 0.5f))
            && HSV_to_RGB( 3f, 1, 1).IsApproximately((0, 1, 1))  &&  HSV_to_RGB( 3.5f, 1f, 1f).IsApproximately((0.0f, 0.5f, 1.0f))
            && HSV_to_RGB( 4f, 1, 1).IsApproximately((0, 0, 1))  &&  HSV_to_RGB( 4.5f, 1f, 1f).IsApproximately((0.5f, 0.0f, 1.0f))
            && HSV_to_RGB( 5f, 1, 1).IsApproximately((1, 0, 1))  &&  HSV_to_RGB( 5.5f, 1f, 1f).IsApproximately((1.0f, 0.0f, 0.5f))

            && HSV_to_RGB( 6f, 1, 1).IsApproximately((1, 0, 0))  &&  HSV_to_RGB( 6.5f, 1f, 1f).IsApproximately((1.0f, 0.5f, 0.0f))
            && HSV_to_RGB( 7f, 1, 1).IsApproximately((1, 1, 0))  &&  HSV_to_RGB( 7.5f, 1f, 1f).IsApproximately((0.5f, 1.0f, 0.0f))
            && HSV_to_RGB( 8f, 1, 1).IsApproximately((0, 1, 0))  &&  HSV_to_RGB( 8.5f, 1f, 1f).IsApproximately((0.0f, 1.0f, 0.5f))
            && HSV_to_RGB( 9f, 1, 1).IsApproximately((0, 1, 1))  &&  HSV_to_RGB( 9.5f, 1f, 1f).IsApproximately((0.0f, 0.5f, 1.0f))
            && HSV_to_RGB(10f, 1, 1).IsApproximately((0, 0, 1))  &&  HSV_to_RGB(10.5f, 1f, 1f).IsApproximately((0.5f, 0.0f, 1.0f))
            && HSV_to_RGB(11f, 1, 1).IsApproximately((1, 0, 1))  &&  HSV_to_RGB(11.5f, 1f, 1f).IsApproximately((1.0f, 0.0f, 0.5f))
        );

        //======================================================================================================================================================
        //TEST("Wavelength_to_RGB()",true
        //    //
        //);

        /*
        {
            const float Domain = 800-350; //  450
            float WavLen;
            vec3 C;
            for (int i = 255; i >= 0; --i) {
                WavLen = 350f + (i/255f)*Domain;
                C = Wavelength_to_RGB(WavLen);
                TESTOUT($"  {WavLen,7:0.000}nm  ->  {C}");
            }
        }
        */

        /*
            for (int i = 350; i < 800; ++i) {
                TESTOUT($"  {i}nm  ->  {Wavelength_to_RGB(f32(i))}");
            }
        */

        /*
            TESTOUT($"{Wavelength_to_RGB(619.68102768746162341399626298384233f)}");
            TESTOUT($"{Wavelength_to_RGB_(619.68102768746162341399626298384233f)}");
            TESTOUT($"{WavLen_to_SpectralColor(619.68102768746162341399626298384233f)}");
        */

        //======================================================================================================================================================
        TEST("ColorMap.Turbo()",true
            && ColorMap.Turbo(  0f/255f) == (0.18995f,0.07176f,0.23217f) && ColorMap.Turbo(  1f/255f) == (0.19483f,0.08339f,0.26149f)
            && ColorMap.Turbo(  2f/255f) == (0.19956f,0.09498f,0.29024f) && ColorMap.Turbo(  3f/255f) == (0.20415f,0.10652f,0.31844f)
            && ColorMap.Turbo(  4f/255f) == (0.20860f,0.11802f,0.34607f) && ColorMap.Turbo(  5f/255f) == (0.21291f,0.12947f,0.37314f)
            && ColorMap.Turbo(  6f/255f) == (0.21708f,0.14087f,0.39964f) && ColorMap.Turbo(  7f/255f) == (0.22111f,0.15223f,0.42558f)
            && ColorMap.Turbo(  8f/255f) == (0.22500f,0.16354f,0.45096f) && ColorMap.Turbo(  9f/255f) == (0.22875f,0.17481f,0.47578f)
            && ColorMap.Turbo( 10f/255f) == (0.23236f,0.18603f,0.50004f) && ColorMap.Turbo( 11f/255f) == (0.23582f,0.19720f,0.52373f)
            && ColorMap.Turbo( 12f/255f) == (0.23915f,0.20833f,0.54686f) && ColorMap.Turbo( 13f/255f) == (0.24234f,0.21941f,0.56942f)
            && ColorMap.Turbo( 14f/255f) == (0.24539f,0.23044f,0.59142f) && ColorMap.Turbo( 15f/255f) == (0.24830f,0.24143f,0.61286f)
            && ColorMap.Turbo( 16f/255f) == (0.25107f,0.25237f,0.63374f) && ColorMap.Turbo( 17f/255f) == (0.25369f,0.26327f,0.65406f)
            && ColorMap.Turbo( 18f/255f) == (0.25618f,0.27412f,0.67381f) && ColorMap.Turbo( 19f/255f) == (0.25853f,0.28492f,0.69300f)
            && ColorMap.Turbo( 20f/255f) == (0.26074f,0.29568f,0.71162f) && ColorMap.Turbo( 21f/255f) == (0.26280f,0.30639f,0.72968f)
            && ColorMap.Turbo( 22f/255f) == (0.26473f,0.31706f,0.74718f) && ColorMap.Turbo( 23f/255f) == (0.26652f,0.32768f,0.76412f)
            && ColorMap.Turbo( 24f/255f) == (0.26816f,0.33825f,0.78050f) && ColorMap.Turbo( 25f/255f) == (0.26967f,0.34878f,0.79631f)
            && ColorMap.Turbo( 26f/255f) == (0.27103f,0.35926f,0.81156f) && ColorMap.Turbo( 27f/255f) == (0.27226f,0.36970f,0.82624f)
            && ColorMap.Turbo( 28f/255f) == (0.27334f,0.38008f,0.84037f) && ColorMap.Turbo( 29f/255f) == (0.27429f,0.39043f,0.85393f)
            && ColorMap.Turbo( 30f/255f) == (0.27509f,0.40072f,0.86692f) && ColorMap.Turbo( 31f/255f) == (0.27576f,0.41097f,0.87936f)
            && ColorMap.Turbo( 32f/255f) == (0.27628f,0.42118f,0.89123f) && ColorMap.Turbo( 33f/255f) == (0.27667f,0.43134f,0.90254f)
            && ColorMap.Turbo( 34f/255f) == (0.27691f,0.44145f,0.91328f) && ColorMap.Turbo( 35f/255f) == (0.27701f,0.45152f,0.92347f)
            && ColorMap.Turbo( 36f/255f) == (0.27698f,0.46153f,0.93309f) && ColorMap.Turbo( 37f/255f) == (0.27680f,0.47151f,0.94214f)
            && ColorMap.Turbo( 38f/255f) == (0.27648f,0.48144f,0.95064f) && ColorMap.Turbo( 39f/255f) == (0.27603f,0.49132f,0.95857f)
            && ColorMap.Turbo( 40f/255f) == (0.27543f,0.50115f,0.96594f) && ColorMap.Turbo( 41f/255f) == (0.27469f,0.51094f,0.97275f)
            && ColorMap.Turbo( 42f/255f) == (0.27381f,0.52069f,0.97899f) && ColorMap.Turbo( 43f/255f) == (0.27273f,0.53040f,0.98461f)
            && ColorMap.Turbo( 44f/255f) == (0.27106f,0.54015f,0.98930f) && ColorMap.Turbo( 45f/255f) == (0.26878f,0.54995f,0.99303f)
            && ColorMap.Turbo( 46f/255f) == (0.26592f,0.55979f,0.99583f) && ColorMap.Turbo( 47f/255f) == (0.26252f,0.56967f,0.99773f)
            && ColorMap.Turbo( 48f/255f) == (0.25862f,0.57958f,0.99876f) && ColorMap.Turbo( 49f/255f) == (0.25425f,0.58950f,0.99896f)
            && ColorMap.Turbo( 50f/255f) == (0.24946f,0.59943f,0.99835f) && ColorMap.Turbo( 51f/255f) == (0.24427f,0.60937f,0.99697f)
            && ColorMap.Turbo( 52f/255f) == (0.23874f,0.61931f,0.99485f) && ColorMap.Turbo( 53f/255f) == (0.23288f,0.62923f,0.99202f)
            && ColorMap.Turbo( 54f/255f) == (0.22676f,0.63913f,0.98851f) && ColorMap.Turbo( 55f/255f) == (0.22039f,0.64901f,0.98436f)
            && ColorMap.Turbo( 56f/255f) == (0.21382f,0.65886f,0.97959f) && ColorMap.Turbo( 57f/255f) == (0.20708f,0.66866f,0.97423f)
            && ColorMap.Turbo( 58f/255f) == (0.20021f,0.67842f,0.96833f) && ColorMap.Turbo( 59f/255f) == (0.19326f,0.68812f,0.96190f)
            && ColorMap.Turbo( 60f/255f) == (0.18625f,0.69775f,0.95498f) && ColorMap.Turbo( 61f/255f) == (0.17923f,0.70732f,0.94761f)
            && ColorMap.Turbo( 62f/255f) == (0.17223f,0.71680f,0.93981f) && ColorMap.Turbo( 63f/255f) == (0.16529f,0.72620f,0.93161f)
            && ColorMap.Turbo( 64f/255f) == (0.15844f,0.73551f,0.92305f) && ColorMap.Turbo( 65f/255f) == (0.15173f,0.74472f,0.91416f)
            && ColorMap.Turbo( 66f/255f) == (0.14519f,0.75381f,0.90496f) && ColorMap.Turbo( 67f/255f) == (0.13886f,0.76279f,0.89550f)
            && ColorMap.Turbo( 68f/255f) == (0.13278f,0.77165f,0.88580f) && ColorMap.Turbo( 69f/255f) == (0.12698f,0.78037f,0.87590f)
            && ColorMap.Turbo( 70f/255f) == (0.12151f,0.78896f,0.86581f) && ColorMap.Turbo( 71f/255f) == (0.11639f,0.79740f,0.85559f)
            && ColorMap.Turbo( 72f/255f) == (0.11167f,0.80569f,0.84525f) && ColorMap.Turbo( 73f/255f) == (0.10738f,0.81381f,0.83484f)
            && ColorMap.Turbo( 74f/255f) == (0.10357f,0.82177f,0.82437f) && ColorMap.Turbo( 75f/255f) == (0.10026f,0.82955f,0.81389f)
            && ColorMap.Turbo( 76f/255f) == (0.09750f,0.83714f,0.80342f) && ColorMap.Turbo( 77f/255f) == (0.09532f,0.84455f,0.79299f)
            && ColorMap.Turbo( 78f/255f) == (0.09377f,0.85175f,0.78264f) && ColorMap.Turbo( 79f/255f) == (0.09287f,0.85875f,0.77240f)
            && ColorMap.Turbo( 80f/255f) == (0.09267f,0.86554f,0.76230f) && ColorMap.Turbo( 81f/255f) == (0.09320f,0.87211f,0.75237f)
            && ColorMap.Turbo( 82f/255f) == (0.09451f,0.87844f,0.74265f) && ColorMap.Turbo( 83f/255f) == (0.09662f,0.88454f,0.73316f)
            && ColorMap.Turbo( 84f/255f) == (0.09958f,0.89040f,0.72393f) && ColorMap.Turbo( 85f/255f) == (0.10342f,0.89600f,0.71500f)
            && ColorMap.Turbo( 86f/255f) == (0.10815f,0.90142f,0.70599f) && ColorMap.Turbo( 87f/255f) == (0.11374f,0.90673f,0.69651f)
            && ColorMap.Turbo( 88f/255f) == (0.12014f,0.91193f,0.68660f) && ColorMap.Turbo( 89f/255f) == (0.12733f,0.91701f,0.67627f)
            && ColorMap.Turbo( 90f/255f) == (0.13526f,0.92197f,0.66556f) && ColorMap.Turbo( 91f/255f) == (0.14391f,0.92680f,0.65448f)
            && ColorMap.Turbo( 92f/255f) == (0.15323f,0.93151f,0.64308f) && ColorMap.Turbo( 93f/255f) == (0.16319f,0.93609f,0.63137f)
            && ColorMap.Turbo( 94f/255f) == (0.17377f,0.94053f,0.61938f) && ColorMap.Turbo( 95f/255f) == (0.18491f,0.94484f,0.60713f)
            && ColorMap.Turbo( 96f/255f) == (0.19659f,0.94901f,0.59466f) && ColorMap.Turbo( 97f/255f) == (0.20877f,0.95304f,0.58199f)
            && ColorMap.Turbo( 98f/255f) == (0.22142f,0.95692f,0.56914f) && ColorMap.Turbo( 99f/255f) == (0.23449f,0.96065f,0.55614f)
            && ColorMap.Turbo(100f/255f) == (0.24797f,0.96423f,0.54303f) && ColorMap.Turbo(101f/255f) == (0.26180f,0.96765f,0.52981f)
            && ColorMap.Turbo(102f/255f) == (0.27597f,0.97092f,0.51653f) && ColorMap.Turbo(103f/255f) == (0.29042f,0.97403f,0.50321f)
            && ColorMap.Turbo(104f/255f) == (0.30513f,0.97697f,0.48987f) && ColorMap.Turbo(105f/255f) == (0.32006f,0.97974f,0.47654f)
            && ColorMap.Turbo(106f/255f) == (0.33517f,0.98234f,0.46325f) && ColorMap.Turbo(107f/255f) == (0.35043f,0.98477f,0.45002f)
            && ColorMap.Turbo(108f/255f) == (0.36581f,0.98702f,0.43688f) && ColorMap.Turbo(109f/255f) == (0.38127f,0.98909f,0.42386f)
            && ColorMap.Turbo(110f/255f) == (0.39678f,0.99098f,0.41098f) && ColorMap.Turbo(111f/255f) == (0.41229f,0.99268f,0.39826f)
            && ColorMap.Turbo(112f/255f) == (0.42778f,0.99419f,0.38575f) && ColorMap.Turbo(113f/255f) == (0.44321f,0.99551f,0.37345f)
            && ColorMap.Turbo(114f/255f) == (0.45854f,0.99663f,0.36140f) && ColorMap.Turbo(115f/255f) == (0.47375f,0.99755f,0.34963f)
            && ColorMap.Turbo(116f/255f) == (0.48879f,0.99828f,0.33816f) && ColorMap.Turbo(117f/255f) == (0.50362f,0.99879f,0.32701f)
            && ColorMap.Turbo(118f/255f) == (0.51822f,0.99910f,0.31622f) && ColorMap.Turbo(119f/255f) == (0.53255f,0.99919f,0.30581f)
            && ColorMap.Turbo(120f/255f) == (0.54658f,0.99907f,0.29581f) && ColorMap.Turbo(121f/255f) == (0.56026f,0.99873f,0.28623f)
            && ColorMap.Turbo(122f/255f) == (0.57357f,0.99817f,0.27712f) && ColorMap.Turbo(123f/255f) == (0.58646f,0.99739f,0.26849f)
            && ColorMap.Turbo(124f/255f) == (0.59891f,0.99638f,0.26038f) && ColorMap.Turbo(125f/255f) == (0.61088f,0.99514f,0.25280f)
            && ColorMap.Turbo(126f/255f) == (0.62233f,0.99366f,0.24579f) && ColorMap.Turbo(127f/255f) == (0.63323f,0.99195f,0.23937f)
            && ColorMap.Turbo(128f/255f) == (0.64362f,0.98999f,0.23356f) && ColorMap.Turbo(129f/255f) == (0.65394f,0.98775f,0.22835f)
            && ColorMap.Turbo(130f/255f) == (0.66428f,0.98524f,0.22370f) && ColorMap.Turbo(131f/255f) == (0.67462f,0.98246f,0.21960f)
            && ColorMap.Turbo(132f/255f) == (0.68494f,0.97941f,0.21602f) && ColorMap.Turbo(133f/255f) == (0.69525f,0.97610f,0.21294f)
            && ColorMap.Turbo(134f/255f) == (0.70553f,0.97255f,0.21032f) && ColorMap.Turbo(135f/255f) == (0.71577f,0.96875f,0.20815f)
            && ColorMap.Turbo(136f/255f) == (0.72596f,0.96470f,0.20640f) && ColorMap.Turbo(137f/255f) == (0.73610f,0.96043f,0.20504f)
            && ColorMap.Turbo(138f/255f) == (0.74617f,0.95593f,0.20406f) && ColorMap.Turbo(139f/255f) == (0.75617f,0.95121f,0.20343f)
            && ColorMap.Turbo(140f/255f) == (0.76608f,0.94627f,0.20311f) && ColorMap.Turbo(141f/255f) == (0.77591f,0.94113f,0.20310f)
            && ColorMap.Turbo(142f/255f) == (0.78563f,0.93579f,0.20336f) && ColorMap.Turbo(143f/255f) == (0.79524f,0.93025f,0.20386f)
            && ColorMap.Turbo(144f/255f) == (0.80473f,0.92452f,0.20459f) && ColorMap.Turbo(145f/255f) == (0.81410f,0.91861f,0.20552f)
            && ColorMap.Turbo(146f/255f) == (0.82333f,0.91253f,0.20663f) && ColorMap.Turbo(147f/255f) == (0.83241f,0.90627f,0.20788f)
            && ColorMap.Turbo(148f/255f) == (0.84133f,0.89986f,0.20926f) && ColorMap.Turbo(149f/255f) == (0.85010f,0.89328f,0.21074f)
            && ColorMap.Turbo(150f/255f) == (0.85868f,0.88655f,0.21230f) && ColorMap.Turbo(151f/255f) == (0.86709f,0.87968f,0.21391f)
            && ColorMap.Turbo(152f/255f) == (0.87530f,0.87267f,0.21555f) && ColorMap.Turbo(153f/255f) == (0.88331f,0.86553f,0.21719f)
            && ColorMap.Turbo(154f/255f) == (0.89112f,0.85826f,0.21880f) && ColorMap.Turbo(155f/255f) == (0.89870f,0.85087f,0.22038f)
            && ColorMap.Turbo(156f/255f) == (0.90605f,0.84337f,0.22188f) && ColorMap.Turbo(157f/255f) == (0.91317f,0.83576f,0.22328f)
            && ColorMap.Turbo(158f/255f) == (0.92004f,0.82806f,0.22456f) && ColorMap.Turbo(159f/255f) == (0.92666f,0.82025f,0.22570f)
            && ColorMap.Turbo(160f/255f) == (0.93301f,0.81236f,0.22667f) && ColorMap.Turbo(161f/255f) == (0.93909f,0.80439f,0.22744f)
            && ColorMap.Turbo(162f/255f) == (0.94489f,0.79634f,0.22800f) && ColorMap.Turbo(163f/255f) == (0.95039f,0.78823f,0.22831f)
            && ColorMap.Turbo(164f/255f) == (0.95560f,0.78005f,0.22836f) && ColorMap.Turbo(165f/255f) == (0.96049f,0.77181f,0.22811f)
            && ColorMap.Turbo(166f/255f) == (0.96507f,0.76352f,0.22754f) && ColorMap.Turbo(167f/255f) == (0.96931f,0.75519f,0.22663f)
            && ColorMap.Turbo(168f/255f) == (0.97323f,0.74682f,0.22536f) && ColorMap.Turbo(169f/255f) == (0.97679f,0.73842f,0.22369f)
            && ColorMap.Turbo(170f/255f) == (0.98000f,0.73000f,0.22161f) && ColorMap.Turbo(171f/255f) == (0.98289f,0.72140f,0.21918f)
            && ColorMap.Turbo(172f/255f) == (0.98549f,0.71250f,0.21650f) && ColorMap.Turbo(173f/255f) == (0.98781f,0.70330f,0.21358f)
            && ColorMap.Turbo(174f/255f) == (0.98986f,0.69382f,0.21043f) && ColorMap.Turbo(175f/255f) == (0.99163f,0.68408f,0.20706f)
            && ColorMap.Turbo(176f/255f) == (0.99314f,0.67408f,0.20348f) && ColorMap.Turbo(177f/255f) == (0.99438f,0.66386f,0.19971f)
            && ColorMap.Turbo(178f/255f) == (0.99535f,0.65341f,0.19577f) && ColorMap.Turbo(179f/255f) == (0.99607f,0.64277f,0.19165f)
            && ColorMap.Turbo(180f/255f) == (0.99654f,0.63193f,0.18738f) && ColorMap.Turbo(181f/255f) == (0.99675f,0.62093f,0.18297f)
            && ColorMap.Turbo(182f/255f) == (0.99672f,0.60977f,0.17842f) && ColorMap.Turbo(183f/255f) == (0.99644f,0.59846f,0.17376f)
            && ColorMap.Turbo(184f/255f) == (0.99593f,0.58703f,0.16899f) && ColorMap.Turbo(185f/255f) == (0.99517f,0.57549f,0.16412f)
            && ColorMap.Turbo(186f/255f) == (0.99419f,0.56386f,0.15918f) && ColorMap.Turbo(187f/255f) == (0.99297f,0.55214f,0.15417f)
            && ColorMap.Turbo(188f/255f) == (0.99153f,0.54036f,0.14910f) && ColorMap.Turbo(189f/255f) == (0.98987f,0.52854f,0.14398f)
            && ColorMap.Turbo(190f/255f) == (0.98799f,0.51667f,0.13883f) && ColorMap.Turbo(191f/255f) == (0.98590f,0.50479f,0.13367f)
            && ColorMap.Turbo(192f/255f) == (0.98360f,0.49291f,0.12849f) && ColorMap.Turbo(193f/255f) == (0.98108f,0.48104f,0.12332f)
            && ColorMap.Turbo(194f/255f) == (0.97837f,0.46920f,0.11817f) && ColorMap.Turbo(195f/255f) == (0.97545f,0.45740f,0.11305f)
            && ColorMap.Turbo(196f/255f) == (0.97234f,0.44565f,0.10797f) && ColorMap.Turbo(197f/255f) == (0.96904f,0.43399f,0.10294f)
            && ColorMap.Turbo(198f/255f) == (0.96555f,0.42241f,0.09798f) && ColorMap.Turbo(199f/255f) == (0.96187f,0.41093f,0.09310f)
            && ColorMap.Turbo(200f/255f) == (0.95801f,0.39958f,0.08831f) && ColorMap.Turbo(201f/255f) == (0.95398f,0.38836f,0.08362f)
            && ColorMap.Turbo(202f/255f) == (0.94977f,0.37729f,0.07905f) && ColorMap.Turbo(203f/255f) == (0.94538f,0.36638f,0.07461f)
            && ColorMap.Turbo(204f/255f) == (0.94084f,0.35566f,0.07031f) && ColorMap.Turbo(205f/255f) == (0.93612f,0.34513f,0.06616f)
            && ColorMap.Turbo(206f/255f) == (0.93125f,0.33482f,0.06218f) && ColorMap.Turbo(207f/255f) == (0.92623f,0.32473f,0.05837f)
            && ColorMap.Turbo(208f/255f) == (0.92105f,0.31489f,0.05475f) && ColorMap.Turbo(209f/255f) == (0.91572f,0.30530f,0.05134f)
            && ColorMap.Turbo(210f/255f) == (0.91024f,0.29599f,0.04814f) && ColorMap.Turbo(211f/255f) == (0.90463f,0.28696f,0.04516f)
            && ColorMap.Turbo(212f/255f) == (0.89888f,0.27824f,0.04243f) && ColorMap.Turbo(213f/255f) == (0.89298f,0.26981f,0.03993f)
            && ColorMap.Turbo(214f/255f) == (0.88691f,0.26152f,0.03753f) && ColorMap.Turbo(215f/255f) == (0.88066f,0.25334f,0.03521f)
            && ColorMap.Turbo(216f/255f) == (0.87422f,0.24526f,0.03297f) && ColorMap.Turbo(217f/255f) == (0.86760f,0.23730f,0.03082f)
            && ColorMap.Turbo(218f/255f) == (0.86079f,0.22945f,0.02875f) && ColorMap.Turbo(219f/255f) == (0.85380f,0.22170f,0.02677f)
            && ColorMap.Turbo(220f/255f) == (0.84662f,0.21407f,0.02487f) && ColorMap.Turbo(221f/255f) == (0.83926f,0.20654f,0.02305f)
            && ColorMap.Turbo(222f/255f) == (0.83172f,0.19912f,0.02131f) && ColorMap.Turbo(223f/255f) == (0.82399f,0.19182f,0.01966f)
            && ColorMap.Turbo(224f/255f) == (0.81608f,0.18462f,0.01809f) && ColorMap.Turbo(225f/255f) == (0.80799f,0.17753f,0.01660f)
            && ColorMap.Turbo(226f/255f) == (0.79971f,0.17055f,0.01520f) && ColorMap.Turbo(227f/255f) == (0.79125f,0.16368f,0.01387f)
            && ColorMap.Turbo(228f/255f) == (0.78260f,0.15693f,0.01264f) && ColorMap.Turbo(229f/255f) == (0.77377f,0.15028f,0.01148f)
            && ColorMap.Turbo(230f/255f) == (0.76476f,0.14374f,0.01041f) && ColorMap.Turbo(231f/255f) == (0.75556f,0.13731f,0.00942f)
            && ColorMap.Turbo(232f/255f) == (0.74617f,0.13098f,0.00851f) && ColorMap.Turbo(233f/255f) == (0.73661f,0.12477f,0.00769f)
            && ColorMap.Turbo(234f/255f) == (0.72686f,0.11867f,0.00695f) && ColorMap.Turbo(235f/255f) == (0.71692f,0.11268f,0.00629f)
            && ColorMap.Turbo(236f/255f) == (0.70680f,0.10680f,0.00571f) && ColorMap.Turbo(237f/255f) == (0.69650f,0.10102f,0.00522f)
            && ColorMap.Turbo(238f/255f) == (0.68602f,0.09536f,0.00481f) && ColorMap.Turbo(239f/255f) == (0.67535f,0.08980f,0.00449f)
            && ColorMap.Turbo(240f/255f) == (0.66449f,0.08436f,0.00424f) && ColorMap.Turbo(241f/255f) == (0.65345f,0.07902f,0.00408f)
            && ColorMap.Turbo(242f/255f) == (0.64223f,0.07380f,0.00401f) && ColorMap.Turbo(243f/255f) == (0.63082f,0.06868f,0.00401f)
            && ColorMap.Turbo(244f/255f) == (0.61923f,0.06367f,0.00410f) && ColorMap.Turbo(245f/255f) == (0.60746f,0.05878f,0.00427f)
            && ColorMap.Turbo(246f/255f) == (0.59550f,0.05399f,0.00453f) && ColorMap.Turbo(247f/255f) == (0.58336f,0.04931f,0.00486f)
            && ColorMap.Turbo(248f/255f) == (0.57103f,0.04474f,0.00529f) && ColorMap.Turbo(249f/255f) == (0.55852f,0.04028f,0.00579f)
            && ColorMap.Turbo(250f/255f) == (0.54583f,0.03593f,0.00638f) && ColorMap.Turbo(251f/255f) == (0.53295f,0.03169f,0.00705f)
            && ColorMap.Turbo(252f/255f) == (0.51989f,0.02756f,0.00780f) && ColorMap.Turbo(253f/255f) == (0.50664f,0.02354f,0.00863f)
            && ColorMap.Turbo(254f/255f) == (0.49321f,0.01963f,0.00955f) && ColorMap.Turbo(255f/255f) == (0.47960f,0.01583f,0.01055f)
        );

        //======================================================================================================================================================
        #if false
        {
            TESTOUT("");
            vec3 C = new();
            string BLARG = "";
            for (int i = 0; i < 256; ++i) {
                C = ColorMap_Magma( ((float)i)/255f );
                BLARG += $"({round(C.r*255f),3},{round(C.g*255f),3},{round(C.b*255f),3},255)";
            }
            TESTOUT(BLARG);
        }
        #endif

        #if false
        {
            TESTOUT("");
            uint C = new();
            string BLARG = "        ";
            for (int i = 0; i < 256; ++i) {
                if (i != 0 && i%8 == 0)
                    BLARG += "\n        ";

                C = ColorMap.BlackBody(i);
                //C = ByteFlip(ColorMap.BlackBody(i));

                BLARG += $"0x{C:X8},";
            }
            TESTOUT(BLARG);
        }
        #endif

        //======================================================================================================================================================
    }
}
