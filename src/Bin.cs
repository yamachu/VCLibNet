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
            IntPtr ptr_y = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * wavform.Length);

            var length = DoubleDefinitions.SPTK_mlsadf(wavform, wavform.Length, mcep, mcep.Length, order, alpha, frame_period, i_period, pade, is_tranpose ? 1 : 0, is_invrese ? 1 : 0, is_coef_b ? 1 : 0, is_without_gain ? 1 : 0, ptr_y);

            var y = new double[length];

            Marshal.Copy(ptr_y, y, 0, y.Length);
            Marshal.FreeHGlobal(ptr_y);

            return y;
        }

        public static float[] mlsadf(float[] wavform, float[] mcep,
            int order = 25, double alpha = 0.35, int frame_period = 100, int i_period = 1, int pade = 4,
            bool is_tranpose = false, bool is_invrese = false, bool is_coef_b = false, bool is_without_gain = false)
        {
            IntPtr ptr_y = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * wavform.Length);

            var length = FloatDefinitions.SPTK_mlsadf(wavform, wavform.Length, mcep, mcep.Length, order, alpha, frame_period, i_period, pade, is_tranpose ? 1 : 0, is_invrese ? 1 : 0, is_coef_b ? 1 : 0, is_without_gain ? 1 : 0, ptr_y);

            var y = new float[length];

            Marshal.Copy(ptr_y, y, 0, y.Length);
            Marshal.FreeHGlobal(ptr_y);

            return y;
        }

        public static float[] GetUserMcep(float[] spectrum)
        {
            IntPtr ptr_mcep = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * spectrum.Length);

            FloatDefinitions.GetUserMcep(spectrum, spectrum.Length, ptr_mcep);

            var mcep = new float[spectrum.Length];

            Marshal.Copy(ptr_mcep, mcep, 0, mcep.Length);
            Marshal.FreeHGlobal(ptr_mcep);

            return mcep;
        }

        public static float[] GetCompensationWavForm(float[] x, float[] userMcep, float[] targetMcep)
        {
            IntPtr ptr_y = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * x.Length);

            var y_length = FloatDefinitions.GetCompensationWavForm(x, x.Length, userMcep, targetMcep, userMcep.Length, ptr_y);

            var y = new float[y_length];

            Marshal.Copy(ptr_y, y, 0, y.Length);
            Marshal.FreeHGlobal(ptr_y);

            return y;
        }

        public static double[] GetUserMcep(double[] spectrum)
        {
            IntPtr ptr_mcep = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * spectrum.Length);

            DoubleDefinitions.GetUserMcep(spectrum, spectrum.Length, ptr_mcep);

            var mcep = new double[spectrum.Length];

            Marshal.Copy(ptr_mcep, mcep, 0, mcep.Length);
            Marshal.FreeHGlobal(ptr_mcep);

            return mcep;
        }

        public static double[] GetCompensationWavForm(double[] x, double[] userMcep, double[] targetMcep)
        {
            IntPtr ptr_y = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(double)) * x.Length);

            var y_length = DoubleDefinitions.GetCompensationWavForm(x, x.Length, userMcep, targetMcep, userMcep.Length, ptr_y);

            var y = new double[y_length];

            Marshal.Copy(ptr_y, y, 0, y.Length);
            Marshal.FreeHGlobal(ptr_y);

            return y;
        }

        public static float[] Standardization1DArray(float[] source, int dim)
        {
            IntPtr ptr_result = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * source.Length);

            FloatDefinitions.Standardization1DArray(source, source.Length, dim, ptr_result);

            var result = new float[source.Length];

            Marshal.Copy(ptr_result, result, 0, result.Length);
            Marshal.FreeHGlobal(ptr_result);

            return result;
        }

        public static float[] UnStandardization1DArray(float[] source, int dim, float[] means, float[] sds)
        {
            IntPtr ptr_result = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * source.Length);

            FloatDefinitions.UnStandardization1DArray(source, source.Length, dim, means, sds, ptr_result);

            var result = new float[source.Length];

            Marshal.Copy(ptr_result, result, 0, result.Length);
            Marshal.FreeHGlobal(ptr_result);
            
            return result;
        }

        public static float[] VarianceCompensation(float[] source, int dim, float[] coef)
        {
            IntPtr ptr_result = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(float)) * source.Length);

            FloatDefinitions.VarianceCompensation(source, source.Length, dim, coef, ptr_result);

            var result = new float[source.Length];

            Marshal.Copy(ptr_result, result, 0, result.Length);
            Marshal.FreeHGlobal(ptr_result);
            
            return result;
        }
    }
}