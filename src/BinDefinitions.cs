using System;
using System.Runtime.InteropServices;

namespace VCLibNet
{
    internal static class BinDefinitions
    {
#if __OSX
        private const string DllName = "libvclib.dylib";
#elif __Linux
        private const string DllName = "libvclib.so";
#elif __Win
        private const string DllName = "vclib.dll";
#else
        private const string DllName = "NOT_SUPPORTED";
#endif

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SPTK_mgcep([In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]double[] spectrum, int sp_length,
            double alpha, double gamma, int order, int fft_length, int itype, int otype,
            int min_iter, int max_iter, int recursions,
            double eps, double end_cond, int etype, double min_det, [In][Out] IntPtr mcep);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SPTK_mlsadf([In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]double[] wavform, int wavform_length,
        [In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]double[] mcep, int mcep_length,
            int order, double alpha, int frame_period, int i_period, int pade,
            int is_tranpose, int is_invrese, int is_coef_b, int is_without_gain, [In][Out] IntPtr y);
    }
}