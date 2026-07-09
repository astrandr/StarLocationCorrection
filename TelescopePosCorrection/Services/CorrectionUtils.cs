using TelescopePosCorrection.Data;

namespace TelescopePosCorrection.Services
{
    public static class CorrectionUtils
    {
        public static float GetDelta(AngleHMS telescopePosition, AngleHMS objectPosition)
        {
            return telescopePosition.Angle - objectPosition.Angle;
        }

        public static AngleHMS AddDeltaRA(AngleHMS objectPosition, float positionDelta)
        {
            var correctedPosition = objectPosition.Angle + positionDelta;
            if (correctedPosition < 0) correctedPosition = 360 + correctedPosition;
            if (correctedPosition > 360) correctedPosition = correctedPosition - 360;
            return AngleHMS.FromFloat(correctedPosition);
        }

        public static AngleHMS AddDeltaDEC(AngleHMS objectPosition, float positionDelta)
        {
            var correctedPosition = objectPosition.Angle + positionDelta;
            if (correctedPosition < 0) correctedPosition = 360 + correctedPosition;
            if (correctedPosition > 360) correctedPosition = correctedPosition - 360;
            return AngleHMS.FromFloat(correctedPosition);
        }
    }
}
