
using System;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls : ITelemetryDiagnosticControls
    {
        #region Private Members
        private const string DiagnosticChannelConnectionString = "*111#";
        private readonly ITelemetryClient _telemetryClient;
        private string _diagnosticInfo = string.Empty;
        #endregion

        #region Constructors
        public TelemetryDiagnosticControls(ITelemetryClient telemetryClient)
        {
            this._telemetryClient = telemetryClient;
        }
        public string DiagnosticInfo
        {
            get { return this._diagnosticInfo; }
            set { this._diagnosticInfo = value; }
        }
        #endregion

        #region
        /// <inheritdoc/>
        public void CheckTransmission()
        {
            this._diagnosticInfo = string.Empty;

            this._telemetryClient.Disconnect();

            int retryLeft = 3;
            while (this._telemetryClient.OnlineStatus == false && retryLeft > 0)
            {
                this._telemetryClient.Connect(DiagnosticChannelConnectionString);
                retryLeft -= 1;
            }

            if (this._telemetryClient.OnlineStatus == false)
            {
                throw new Exception("Unable to connect.");
            }

            this._telemetryClient.Send(TelemetryClient.DIAGNOSTIC_MESSAGE);
            this._diagnosticInfo = _telemetryClient.Receive();
        }
        #endregion
    }
}
