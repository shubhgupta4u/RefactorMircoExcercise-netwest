using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient3
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.

        private IAlarm _anAlarm;

        public AnAlarmClient3()
        {
            this._anAlarm = DependencyResolver.Instance.Resolve<IAlarm>();
        }

        public void DoSomething()
        {
            _anAlarm.Check();
        }

        public void DoSomethingElse()
        {
            bool isAlarmOn = _anAlarm.AlarmOn;
        }
    }
}
