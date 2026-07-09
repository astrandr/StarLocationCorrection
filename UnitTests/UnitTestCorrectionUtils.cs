using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelescopePosCorrection.Services;
using TelescopePosCorrection.Data;

namespace TelescopePosCorrection.Tests.Services
{
    [TestClass]
    public class CorrectionUtilsTests
    {
        [DataTestMethod]
        [DataRow(100f, 80f, 20f)]
        [DataRow(80f, 100f, -20f)]
        [DataRow(0f, 0f, 0f)]
        public void GetDelta_ReturnsExpected(float telescopeAngle, float objectAngle, float expected)
        {
            var telescope = AngleHMS.FromFloat(telescopeAngle);
            var obj = AngleHMS.FromFloat(objectAngle);

            var delta = CorrectionUtils.GetDelta(telescope, obj);

            Assert.AreEqual(expected, delta, 0.0001f);
        }

        [DataTestMethod]
        [DataRow(350f, 20f, 10f)]    // Wraps over 360
        [DataRow(5f, -10f, 355f)]    // Wraps below 0
        [DataRow(180f, 0f, 180f)]    // No change
        [DataRow(359f, 2f, 1f)]      // Small wrap
        [DataRow(0f, 0f, 0f)]        // Edge case
        public void AddDeltaRA_WrapsCorrectly(float objectAngle, float delta, float expected)
        {
            var obj = AngleHMS.FromFloat(objectAngle);

            var result = CorrectionUtils.AddDeltaRA(obj, delta);

            Assert.AreEqual(expected, result.Angle, 0.0001f);
        }

        [DataTestMethod]
        [DataRow(350f, 20f, 370f)]    // No wrapping, result is 370
        [DataRow(5f, -10f, -5f)]      // No wrapping, result is -5
        [DataRow(180f, 0f, 180f)]     // No change
        [DataRow(359f, 2f, 361f)]     // No wrapping, result is 361
        [DataRow(0f, 0f, 0f)]         // Edge case
        public void AddDeltaDEC_NoWrapping(float objectAngle, float delta, float expected)
        {
            var obj = AngleHMS.FromFloat(objectAngle);

            var result = CorrectionUtils.AddDeltaDEC(obj, delta);

            Assert.AreEqual(expected, result.Angle, 0.0001f);
        }

    }
}
