using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TDDMicroExercises.TelemetrySystem.Interfaces;
using TDDMicroExercisesTests.Attributes;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    [TestClass()]
    public class TelemetryDiagnosticControlsTests
    {
        #region Private Members
        private ITelemetryDiagnosticControls _diagnosticControls;
        private Mock<ITelemetryClient> _telemetryClientMock;
        #endregion

        [TestInitialize]
        public void Initialize()
        {
            this._telemetryClientMock = new Mock<ITelemetryClient>();
            this._diagnosticControls = new TelemetryDiagnosticControls(this._telemetryClientMock.Object);
        }

        [TestMethod]
        [DataRow(true, "AT#UD", DisplayName = "Should successfuly send diagnostic message and receive status message response")]
        public void TelemetryDiagnosticControls_SuccessTransmission_Test(bool onlineStatus, string _diagnosticMessage)
        {
            //Arrange
            this._telemetryClientMock.SetupGet(x => x.OnlineStatus).Returns(onlineStatus);
            this._telemetryClientMock.Setup(x => x.Send(It.IsAny<string>()));
            this._telemetryClientMock.Setup(x => x.Receive()).Returns("Mocked diagnostic message");

            _telemetryClientMock.Setup(x => x.Receive())
                .Returns(_diagnosticMessage);

            //Act
            this._diagnosticControls.CheckTransmission();

            //Assert
            this._telemetryClientMock.Verify(x => x.Disconnect(), Times.Once);
            this._telemetryClientMock.Verify(x => x.Send(_diagnosticMessage), Times.Once);
            this._telemetryClientMock.Verify(x => x.Receive(), Times.Once);
            Assert.AreEqual(this._diagnosticControls.DiagnosticInfo, _diagnosticMessage);
        }

        [TestMethod]
        [DataRow(false, "AT#UD", DisplayName = "Should successfuly connect, send diagnostic message and receive status message response")]
        public void TelemetryDiagnosticControls_SuccessFulConnectionAndTransmission_Test(bool onlineStatus, string _diagnosticMessage)
        {
            //Arrange
            this._telemetryClientMock.SetupGet(x => x.OnlineStatus).Returns(onlineStatus);
            this._telemetryClientMock.Setup(x => x.Connect((It.IsAny<string>())))
              .Callback<string>((x) =>
              {
                  this._telemetryClientMock.SetupGet(y => y.OnlineStatus).Returns(true);
              });

            this._telemetryClientMock.Setup(x => x.Send(It.IsAny<string>()));

            this._telemetryClientMock.Setup(x => x.Receive()).Returns(_diagnosticMessage);

            _telemetryClientMock.Setup(x => x.Receive())
                .Returns(_diagnosticMessage);

            //Act
            this._diagnosticControls.CheckTransmission();

            //Assert
            this._telemetryClientMock.Verify(x => x.Connect(It.IsAny<string>()), Times.Once);
            this._telemetryClientMock.Verify(x => x.Disconnect(), Times.Once);
            this._telemetryClientMock.Verify(x => x.Send(_diagnosticMessage), Times.Once);
            this._telemetryClientMock.Verify(x => x.Receive(), Times.Once);
            Assert.AreEqual(this._diagnosticControls.DiagnosticInfo, _diagnosticMessage);
        }

        [TestMethod]
        [DataRow(false, false, DisplayName = "Should throw unable to connect excpetion")]
        [ExpectedExceptionWithMessage(typeof(Exception), "Unable to connect.")]
        public void TelemetryDiagnosticControls_FailedTransmission_Test(bool onlineStatus, bool expectedOnlineStatus)
        {
            //Arrange
            this._telemetryClientMock.SetupGet(x => x.OnlineStatus).Returns(onlineStatus);
            this._telemetryClientMock.Setup(x => x.Connect((It.IsAny<string>())))
              .Callback<string>((x) =>
              {
                  this._telemetryClientMock.SetupGet(y => y.OnlineStatus).Returns(onlineStatus);
              }); ;

            //Act
            this._diagnosticControls.CheckTransmission();

            //Assert
            this._telemetryClientMock.Verify(x => x.Connect(It.IsAny<string>()), Times.AtLeast(3));
            Assert.Equals("onlineStatus", expectedOnlineStatus);
        }
    }
}