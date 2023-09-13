namespace TDDMicroExercises.TirePressureMonitoringSystem.Interfaces
{
    /// <summary>
    /// Alarm class to monitor tire pressure and set an alarm if the pressure falls outside of the expected range 
    /// </summary>
    public interface IAlarm
    {
        /// <summary>
        /// Check tire pressure and set an alarm if the pressure falls outside of the expected range
        /// </summary>
        void Check();
        /// <summary>
        /// Determine whether Alarm is ON or OFF
        /// </summary>
        bool AlarmOn { get; }
    }
}
