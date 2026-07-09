using System;

namespace TelescopePosCorrection.Data
{
    public class AngleHMS
    {
        public float H { get; set; }
        public float M { get; set; }
        public float S { get; set; }
        public float Angle => H * 15 + M * 0.25f + S * 0.25f / 60;

        public static bool TryParse(string angleHMS, out AngleHMS angle)
        {
            angle = null;

            var tokens = angleHMS.Split(new char[] { ':' }, System.StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 3 && float.TryParse(tokens[0], out float h) && float.TryParse(tokens[1], out float m) && float.TryParse(tokens[2], out float s))
            {
                angle = new AngleHMS
                {
                    H = h,
                    M = m,
                    S = s
                };
                return true;
            }

            return false;
        }


        public string ToHMSString()
        {
            string s = "";
            if (H < 0 || M < 0 || S < 0)
            {
                s = "-";
            }
            s += string.Format("{0}:{1}:{2}", Abs(H).ToString("00"), Abs(M).ToString("00"), Abs(S).ToString("00"));
            return s;
        }

        public static AngleHMS FromFloat(float angle)
        {
            var result = new AngleHMS();
            result.H = (float) Math.Truncate((double)(angle / 15f));
            var anglesMinutesRemained = angle - result.H * 15;
            result.M = (float) Math.Truncate((double)(anglesMinutesRemained * 4));
            var secondsAnglesRemainder = (anglesMinutesRemained - result.M * 0.25f) * 240;
            result.S = secondsAnglesRemainder;

            return result;
        }

        private float Abs(float a) => a >= 0? a : -a;
    }
}
