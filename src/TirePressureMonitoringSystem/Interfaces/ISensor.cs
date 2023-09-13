namespace TDDMicroExercises.TirePressureMonitoringSystem.Interfaces
{
    /// <summary>
    /// Sensor class to simulates the behaviour of a real tire sensor, providing random but realistic values
    /// </summary>
    public interface ISensor
    {
        /// <summary>
        /// Get random but realistic value of a  tire pressure measured by real Sensor.
        /// </summary>
        /// <returns>Tier Pressure Psi Value</returns>
        double PopNextPressurePsiValue();
    }
}
