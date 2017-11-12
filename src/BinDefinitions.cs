using System;
using System.Runtime.InteropServices;

namespace VCLibNet.Definition.Bin
{
    internal static class DoubleDefinitions
    {
        private const string DllName = "vclib_double";

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SPTK_mgcep([In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]double[] spectrum, int sp_length,
            double alpha, double gamma, int order, int fft_length, int itype, int otype,
            int min_iter, int max_iter, int recursions,
            double eps, double end_cond, int etype, double min_det, [In][Out] IntPtr mcep);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SPTK_mlsadf([In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]double[] wavform, int wavform_length,
        [In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]double[] mcep, int mcep_length,
            int order, double alpha, int frame_period, int i_period, int pade,
            int is_tranpose, int is_invrese, int is_coef_b, int is_without_gain, [In][Out] IntPtr y);
    }

    internal static class FloatDefinitions
    {
        private const string DllName = "vclib_float";

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SPTK_mgcep([In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]float[] spectrum, int sp_length,
            double alpha, double gamma, int order, int fft_length, int itype, int otype,
            int min_iter, int max_iter, int recursions,
            double eps, double end_cond, int etype, double min_det, [In][Out] IntPtr mcep);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SPTK_mlsadf([In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]float[] wavform, int wavform_length,
        [In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]float[] mcep, int mcep_length,
            int order, double alpha, int frame_period, int i_period, int pade,
            int is_tranpose, int is_invrese, int is_coef_b, int is_without_gain, [In][Out] IntPtr y);
    }
}