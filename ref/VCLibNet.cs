using System;

namespace VCLibNet
{
    public class Bin
    {
        public static double[] mgcep(double[] spectrum,
            double alpha = 0.35, double gamma = 0.0, int order = 25, int fft_length = 256,
            int itype = 0, int otype = 0, int min_iter = 2, int max_iter = 30, int recursions = -1,
            double eps = 0.0, double end_cond = 0.001, int etype = 0, double min_det = 0.000001)
        {
            throw null;
        }

        public static double[] mlsadf(double[] wavform, double[] mcep,
            int order = 25, double alpha = 0.35, int frame_period = 100, int i_period = 1, int pade = 4,
            bool is_tranpose = false, bool is_invrese = false, bool is_coef_b = false, bool is_without_gain = false)
        {
            throw null;
        }

        public static float[] mgcep(float[] spectrum,
            double alpha = 0.35, double gamma = 0.0, int order = 25, int fft_length = 256,
            int itype = 0, int otype = 0, int min_iter = 2, int max_iter = 30, int recursions = -1,
            double eps = 0.0, double end_cond = 0.001, int etype = 0, double min_det = 0.000001)
        {
            throw null;
        }

        public static float[] mlsadf(float[] wavform, float[] mcep,
            int order = 25, double alpha = 0.35, int frame_period = 100, int i_period = 1, int pade = 4,
            bool is_tranpose = false, bool is_invrese = false, bool is_coef_b = false, bool is_without_gain = false)
        {
            throw null;
        }

        public static double[] DifferentialMelCepstrumCompensation(double[] rawform, double[] sp, double[] mcep,
            double alpha, double gamma, int mcep_order, int fft_length, int itype, int otype,
            int min_iter, int max_iter, int recursions,
            double eps, double end_cond, int etype, double min_det,int frame_period, int interpolate_period)
        {
            throw null;
        }

        public static float[] DifferentialMelCepstrumCompensation(float[] rawform, float[] sp, float[] mcep,
            double alpha, double gamma, int mcep_order, int fft_length, int itype, int otype,
            int min_iter, int max_iter, int recursions,
            double eps, double end_cond, int etype, double min_det,int frame_period, int interpolate_period)
        {
            throw null;
        }
    }
}