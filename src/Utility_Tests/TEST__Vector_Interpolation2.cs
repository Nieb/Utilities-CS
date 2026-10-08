
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Interpolation2() {
        TESTOUT("\n[Utility.VEC -- Interpolation2]");

        //======================================================================================================================================================
        TEST("Gaussian()",true
            && Gaussian(0.0f).IsApproximately(1.00000000000000000000000000000000000000000000000000f)
            && Gaussian(0.1f).IsApproximately(0.99004983374916805357390597718003655777207908125384f)
            && Gaussian(0.2f).IsApproximately(0.96078943915232320943921069132324588602797209371792f)
            && Gaussian(0.3f).IsApproximately(0.91393118527122818674735354649952061021058519482681f)
            && Gaussian(0.4f).IsApproximately(0.85214378896621133845634698146856265977417032594943f)
            && Gaussian(0.5f).IsApproximately(0.77880078307140486824517026697832064729677229042614f)
            && Gaussian(0.6f).IsApproximately(0.69767632607103105720912926383816033022870445079537f)
            && Gaussian(0.7f).IsApproximately(0.61262639418441606898857996801904692620620135874223f)
            && Gaussian(0.8f).IsApproximately(0.52729242404304855724369460856631448248616903286625f)
            && Gaussian(0.9f).IsApproximately(0.44485806622294113448144543910579857785059448612779f)
            && Gaussian(1.0f).IsApproximately(0.36787944117144232159552377016146086744581113103177f)
            && Gaussian(2.0f).IsApproximately(0.01831563888873418029371802127324124221191206755348f)
            && Gaussian(3.0f).IsApproximately(0.00012340980408667954949763669073003382607215283229f)
            && Gaussian(4.0f).IsApproximately(0.00000011253517471925911451377517906012719163794080f)

            && Gaussian(1.51742712938514635086297239354987845739358126204360f).IsApproximately(0.1f)
            && Gaussian(2.14596602628934723963618357029004740046995929308816f).IsApproximately(0.01f)
            && Gaussian(2.62826088487846598931506067905049800217432041985170f).IsApproximately(0.001f)
            && Gaussian(3.03485425877029270172594478709975691478716252408720f).IsApproximately(0.0001f)
            && Gaussian(3.39307021220755589894154507142812819688028338107494f).IsApproximately(0.00001f)
            && Gaussian(3.71692218884983844695240676130448316029231609101984f).IsApproximately(0.000001f)
            && Gaussian(4.01473481701572909605273348472917499511120140628107f).IsApproximately(0.0000001f)
            && Gaussian(4.29193205257869447927236714058009480093991858617632f).IsApproximately(0.00000001f)
            && Gaussian(4.55228138815543905258891718064963537218074378613080f).IsApproximately(0.000000001f)
        );

        #if false
            TESTOUT($"""

                Gaussian(0.0) = {Gaussian(0.0f):N64}  {Gaussian(0.0f).IsApproximately(1.00000000000f)}
                Gaussian(0.1) = {Gaussian(0.1f):N64}  {Gaussian(0.1f).IsApproximately(0.99004983374f)}
                Gaussian(0.2) = {Gaussian(0.2f):N64}  {Gaussian(0.2f).IsApproximately(0.96078943915f)}
                Gaussian(0.3) = {Gaussian(0.3f):N64}  {Gaussian(0.3f).IsApproximately(0.91393118527f)}
                Gaussian(0.4) = {Gaussian(0.4f):N64}  {Gaussian(0.4f).IsApproximately(0.85214378896f)}
                Gaussian(0.5) = {Gaussian(0.5f):N64}  {Gaussian(0.5f).IsApproximately(0.77880078307f)}
                Gaussian(0.6) = {Gaussian(0.6f):N64}  {Gaussian(0.6f).IsApproximately(0.69767632607f)}
                Gaussian(0.7) = {Gaussian(0.7f):N64}  {Gaussian(0.7f).IsApproximately(0.61262639418f)}
                Gaussian(0.8) = {Gaussian(0.8f):N64}  {Gaussian(0.8f).IsApproximately(0.52729242404f)}
                Gaussian(0.9) = {Gaussian(0.9f):N64}  {Gaussian(0.9f).IsApproximately(0.44485806622f)}
                Gaussian(1.0) = {Gaussian(1.0f):N64}  {Gaussian(1.0f).IsApproximately(0.36787944117f)}
                Gaussian(2.0) = {Gaussian(2.0f):N64}  {Gaussian(2.0f).IsApproximately(0.01831563888f)}
                Gaussian(3.0) = {Gaussian(3.0f):N64}  {Gaussian(3.0f).IsApproximately(0.00012340980f)}
                Gaussian(4.0) = {Gaussian(4.0f):N64}  {Gaussian(4.0f).IsApproximately(0.00000011253f)}

                Gaussian(1.51742712939) {Gaussian(1.51742712939f):N64} {Gaussian(1.51742712939f).IsApproximately(0.1f)}
                Gaussian(2.14596602629) {Gaussian(2.14596602629f):N64} {Gaussian(2.14596602629f).IsApproximately(0.01f)}
                Gaussian(2.62826088488) {Gaussian(2.62826088488f):N64} {Gaussian(2.62826088488f).IsApproximately(0.001f)}
                Gaussian(3.03485425877) {Gaussian(3.03485425877f):N64} {Gaussian(3.03485425877f).IsApproximately(0.0001f)}
                Gaussian(3.39307021221) {Gaussian(3.39307021221f):N64} {Gaussian(3.39307021221f).IsApproximately(0.00001f)}
                Gaussian(3.71692218885) {Gaussian(3.71692218885f):N64} {Gaussian(3.71692218885f).IsApproximately(0.000001f)}
                Gaussian(4.01473481702) {Gaussian(4.01473481702f):N64} {Gaussian(4.01473481702f).IsApproximately(0.0000001f)}
                Gaussian(4.29193205258) {Gaussian(4.29193205258f):N64} {Gaussian(4.29193205258f).IsApproximately(0.00000001f)}
                Gaussian(4.55228138816) {Gaussian(4.55228138816f):N64} {Gaussian(4.55228138816f).IsApproximately(0.000000001f)}
            """);
        #endif

        //======================================================================================================================================================
        TEST("Lanczos()",true
            && Lanczos(0f).IsNaN()
            && Lanczos(EPS9).IsApproximately(1f)

            && Lanczos( PI ).IsApproximately(0f)
            && Lanczos( PI2).IsApproximately(0f)
            && Lanczos( PI3).IsApproximately(0f)
            && Lanczos( PI4).IsApproximately(0f)
        );

        #if false
            TESTOUT($"""

                Lanczos(PI) = {Lanczos(PI):N64}
            """);
        #endif

        //======================================================================================================================================================
    }
}
