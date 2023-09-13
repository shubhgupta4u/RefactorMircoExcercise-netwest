namespace TDDMicroExercises.TelemetrySystem.Interfaces
{
    public interface ITelemetryDiagnosticControls
    {
        /// <summary>
        /// Received Diagnostic Response
        /// </summary>
        string DiagnosticInfo { get; set; }

        /// <summary>
        /// Check transmission with Telemetry Server
        /// </summary>
        void CheckTransmission();
    }
}
