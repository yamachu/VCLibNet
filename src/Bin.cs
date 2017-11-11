using System;
using System.Runtime.InteropServices;
using VCLibNet.Definition.Bin;

namespace VCLibNet
{
    public class Bin
    {
        public static double[] mgcep(double[] spectrum,
            double alpha = 0.35, double gamma = 0.0, int order = 25, int fft_length = 256,
            int itype = 0, int otype = 0, int min_iter = 2, int max_iter = 30, int recursions = -1,
            double eps = 0.0, double end_cond = 0.001, int etype = 0, double min_det = 0.000001)
        {
            var f0_length = spectrum.Length / (fft_length / 2 + 1);
            var mcep = new double[(order + 1) * f0_length];

            IntPtr ptr_mcep = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * mcep.Length);

            DoubleDefinitions.SPTK_mgcep(spectrum, spectrum.Length, alpha, gamma, order, fft_length,
                itype, otype, min_iter, max_iter, recursions, eps, end_cond, etype, min_det, ptr_mcep);

            Marshal.Copy(ptr_mcep, mcep, 0, mcep.Length);
            Marshal.FreeHGlobal(ptr_mcep);

            return mcep;
        }

        public static float[] mgcep(float[] spectrum,
            double alpha = 0.35, double gamma = 0.0, int order = 25, int fft_length = 256,
            int itype = 0, int otype = 0, int min_iter = 2, int max_iter = 30, int recursions = -1,
            double eps = 0.0, double end_cond = 0.001, int etype = 0, double min_det = 0.000001)
        {
            var f0_length = spectrum.Length / (fft_length / 2 + 1);
            var mcep = new float[(order + 1) * f0_length];

            IntPtr ptr_mcep = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * mcep.Length);

            FloatDefinitions.SPTK_mgcep(spectrum, spectrum.Length, alpha, gamma, order, fft_length,
                itype, otype, min_iter, max_iter, recursions, eps, end_cond, etype, min_det, ptr_mcep);

            Marshal.Copy(ptr_mcep, mcep, 0, mcep.Length);
            Marshal.FreeHGlobal(ptr_mcep);

            return mcep;
        }

        public static double[] mlsadf(double[] wavform, double[] mcep,
            int order = 25, double alpha = 0.35, int frame_period = 100, int i_period = 1, int pade = 4,
            bool is_tranpose = false, bool is_invrese = false, bool is_coef_b = false, bool is_without_gain = false)
        {
            var y = new double[wavform.Length];

            IntPtr ptr_y = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * y.Length);

            DoubleDefinitions.SPTK_mlsadf(wavform, wavform.Length, mcep, mcep.Length, order, alpha, frame_period, i_period, pade, is_tranpose ? 1 : 0, is_invrese ? 1 : 0, is_coef_b ? 1 : 0, is_without_gain ? 1 : 0, ptr_y);

            Marshal.Copy(ptr_y, y, 0, y.Length);
            Marshal.FreeHGlobal(ptr_y);

            return y;
        }

        public static float[] mlsadf(float[] wavform, float[] mcep,
            int order = 25, double alpha = 0.35, int frame_period = 100, int i_period = 1, int pade = 4,
            bool is_tranpose = false, bool is_invrese = false, bool is_coef_b = false, bool is_without_gain = false)
        {
            var y = new float[wavform.Length];

            IntPtr ptr_y = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * y.Length);

            FloatDefinitions.SPTK_mlsadf(wavform, wavform.Length, mcep, mcep.Length, order, alpha, frame_period, i_period, pade, is_tranpose ? 1 : 0, is_invrese ? 1 : 0, is_coef_b ? 1 : 0, is_without_gain ? 1 : 0, ptr_y);

            Marshal.Copy(ptr_y, y, 0, y.Length);
            Marshal.FreeHGlobal(ptr_y);

            return y;
        }
    }
}