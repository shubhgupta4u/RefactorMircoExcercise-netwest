using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient2
    {
        // A class with the only goal of simulating a dependency on Alert
        // that has impact on the refactoring.

        private void DoSomething()
        {
            IAlarm anAlarm = DependencyResolver.Instance.Resolve<IAlarm>();
            anAlarm.Check();
            bool isAlarmOn = anAlarm.AlarmOn;
        }
    }
}
