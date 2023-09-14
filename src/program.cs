using System;
using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises
{
    class program
    {
        static void Main(string[] args)
        {
            var service = DependencyResolver.Instance.Resolve<IAlarm>();
            service.Check();
            Console.WriteLine(string.Format("Alarm Status: {0}", service.AlarmOn ? "ON" : "OFF"));

            Console.ReadKey();
        }
    }
}
