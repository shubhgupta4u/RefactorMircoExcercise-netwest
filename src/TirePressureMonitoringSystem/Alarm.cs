using System;
using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    /// <inheritdoc/>
    public class Alarm : Interfaces.IAlarm, IDisposable
    {
        #region Private Members
        private const double LOW_PRESSURE_THRESHOLD = 17;
        private const double HIGH_PRESSURE_THRESHOLD = 21;
        private ISensor _sensor;
        bool _alarmOn = false;
        #endregion

        #region Constructors
        public Alarm() : this(new Sensor())
        {
        }
        public Alarm(ISensor sensor)
        {
            this._sensor = sensor;
        }
        #endregion

        #region Interfaces.IAlarm Methods
        /// <inheritdoc/>
        public void Check()
        {
            if (this._sensor != null)
            {
                try
                {
                    double psiPressureValue = _sensor.PopNextPressurePsiValue();

                    if (psiPressureValue < Alarm.LOW_PRESSURE_THRESHOLD || Alarm.HIGH_PRESSURE_THRESHOLD < psiPressureValue)
                    {
                        _alarmOn = true;
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public bool AlarmOn
        {
            get { return this._alarmOn; }
        }
        #endregion

        #region IDisposable Methods

        public void Dispose()
        {
            this._sensor = null;
        }
        #endregion
    }
}
