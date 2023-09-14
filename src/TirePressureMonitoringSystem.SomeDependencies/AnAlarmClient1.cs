using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient1
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.
        public AnAlarmClient1()
        {
            IAlarm anAlarm = DependencyResolver.Instance.Resolve<IAlarm>();
            anAlarm.Check();
            bool isAlarmOn = anAlarm.AlarmOn;
        }
    }
}
