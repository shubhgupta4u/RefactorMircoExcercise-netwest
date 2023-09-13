using System;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Sensor : Interfaces.ISensor
    {
        //
        // The reading of the pressure value from the sensor is simulated in this implementation.
        // Because the focus of the exercise is on the other class.
        //
        #region Private Members
        private const double OFFSET = 16d;
        private readonly Random _randomPressureSampleSimulator;
        #endregion
        #region Constructor
        public Sensor()
        {
            this._randomPressureSampleSimulator = new Random();
        }
        #endregion
        #region Interfaces.ISensor Methods
        /// <inheritdoc/>
        public double PopNextPressurePsiValue()
        {
            try
            {
                double pressureTelemetryValue = this.ReadPressureSample();
                return OFFSET + pressureTelemetryValue;
            }
            catch
            {
                throw;
            }

        }
        #endregion

        #region Private Methods
        private double ReadPressureSample()
        {
            // Simulate info read from a real sensor in a real tire
            return 6 * _randomPressureSampleSimulator.NextDouble() * _randomPressureSampleSimulator.NextDouble();
        }
        #endregion
    }
}
