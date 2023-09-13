namespace TDDMicroExercises.TelemetrySystem.Interfaces
{
    public interface ITelemetryClient
    {
        /// <summary>
        /// Determine whether connected with Telemetry Server or not
        /// </summary>
        bool OnlineStatus { get; }

        /// <summary>
        /// To make connection with Telemetry Server
        /// </summary>
        /// <param name="telemetryServerConnectionString"></param>
        void Connect(string telemetryServerConnectionString);

        /// <summary>
        /// To disconnect from Telemetry Server
        /// </summary>
        void Disconnect();

        /// <summary>
        /// To send a diagnostic request
        /// </summary>
        /// <param name="message"></param>
        void Send(string message);

        /// <summary>
        /// To recieved telemetry response
        /// </summary>
        /// <returns></returns>
        string Receive();
    }
}
