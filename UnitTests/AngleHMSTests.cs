using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelescopePosCorrection.Data;

namespace TelescopePosCorrection.Tests.Data
{
    [TestClass]
    public class AngleHMSTests
    {
        [DataTestMethod]
        [DataRow("12:30:15", 12f, 30f, 15f, true)]
        [DataRow("0:0:0", 0f, 0f, 0f, true)]
        [DataRow("23:59:59", 23f, 59f, 59f, true)]
        [DataRow("bad:input:string", 0f, 0f, 0f, false)]
        [DataRow("12:30", 0f, 0f, 0f, false)]
        public void TryParse_ParsesCorrectly(string input, float expectedH, float expectedM, float expectedS, bool expectedResult)
        {
            var result = AngleHMS.TryParse(input, out var angle);

            Assert.AreEqual(expectedResult, result);
            if (expectedResult)
            {
                Assert.IsNotNull(angle);
                Assert.AreEqual(expectedH, angle.H, 0.0001f);
                Assert.AreEqual(expectedM, angle.M, 0.0001f);
                Assert.AreEqual(expectedS, angle.S, 0.0001f);
            }
            else
            {
                Assert.IsNull(angle);
            }
        }

        [DataTestMethod]
        [DataRow(12f, 30f, 15f, "12:30:15")]
        [DataRow(0f, 0f, 0f, "00:00:00")]
        [DataRow(-1f, -2f, -3f, "-01:02:03")]
        public void ToHMSString_FormatsCorrectly(float h, float m, float s, string expected)
        {
            var angle = new AngleHMS { H = h, M = m, S = s };
            var result = angle.ToHMSString();
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(0f, 0f, 0f, 0f)]
        [DataRow(1f, 0f, 0f, 15f)]
        [DataRow(0f, 1f, 0f, 0.25f)]
        [DataRow(0f, 0f, 60f, 0.25f)]
        [DataRow(2f, 30f, 30f, 37.625f)]
        public void Angle_ComputesCorrectly(float h, float m, float s, float expectedAngle)
        {
            var angle = new AngleHMS { H = h, M = m, S = s };
            Assert.AreEqual(expectedAngle, angle.Angle, 0.0001f);
        }

        [DataTestMethod]
        [DataRow(0f, 0f, 0f, 0f)]
        [DataRow(15f, 1f, 0f, 0f)]
        [DataRow(30.25f, 2f, 1f, 0f)]
        [DataRow(37.625f, 2f, 30f, 30f)]
        public void FromFloat_CreatesCorrectHMS(float inputAngle, float expectedH, float expectedM, float expectedS)
        {
            var angle = AngleHMS.FromFloat(inputAngle);
            Assert.AreEqual(expectedH, angle.H, 0.0001f);
            Assert.AreEqual(expectedM, angle.M, 0.0001f);
            Assert.AreEqual(expectedS, angle.S, 0.0001f);
        }

    }
}
