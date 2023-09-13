using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
    [TestClass()]
    public class AlarmTests
    {
        #region Private Members
        private IAlarm _alarm;
        private Mock<ISensor> _mockSensor;
        #endregion

        [TestInitialize]
        public void Initialize()
        {
            this._mockSensor = new Mock<ISensor>();
            this._alarm = new Alarm(this._mockSensor.Object);
        }


        [TestMethod("AlarmCheckTest")]
        [DataRow(17, false, DisplayName = "Should Set OFF Alarm for Tire Pressure Lower Boundary Test Value")]
        [DataRow(21, false, DisplayName = "Should Set OFF Alarm for Tire Pressure Upper Boundary Tes Valuet")]
        [DataRow(19, false, DisplayName = "Should Set OFF Alarm for Tire Pressure Within Boundary Test Value")]
        [DataRow(22, true, DisplayName = "Should Set ON Alarm for Tire Pressure Below Lower Boundary Test Value")]
        [DataRow(16, true, DisplayName = "Should Set ON Alarm for Tire Pressure Above Upper Boundary Test Value")]
        public void CheckTest(double tirePressurePsiVal, bool expected)
        {
            // Arrange
            this._mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(tirePressurePsiVal);

            // Act
            this._alarm.Check();

            // Assert
            Assert.AreEqual<bool>(this._alarm.AlarmOn, expected, "Tire Pressure psi value :{0} and Alarm expected to be {1}", new object[] { tirePressurePsiVal, expected ? "OFF" : "ON" });
        }

        [TestCleanup]
        public void Cleanup()
        {
            IDisposable obj = (IDisposable)this._alarm;
            if (obj != null)
            {
                obj.Dispose();
            }
        }
    }
}