using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO.Abstractions;
using TDDMicroExercises.TelemetrySystem;
using TDDMicroExercises.TelemetrySystem.Interfaces;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;
using TDDMicroExercises.TurnTicketDispenser;
using TDDMicroExercises.TurnTicketDispenser.Interfaces;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces;

namespace TDDMicroExercises
{
    public sealed class DependencyResolver
    {
        #region Private Members
        private static readonly Lazy<DependencyResolver> lazy = new Lazy<DependencyResolver>(() => new DependencyResolver());
        private readonly IServiceCollection _serviceCollection;
        private IServiceProvider _serviceProvider;
        #endregion

        #region Constructor
        private DependencyResolver()
        {
            this._serviceCollection = new ServiceCollection();
            this.ConfigureService();
            this._serviceProvider = this._serviceCollection.BuildServiceProvider();
        }
        #endregion

        #region Properties
        public static DependencyResolver Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        #endregion
        #region Properties
        public void Init()
        {
            IServiceCollection services = new ServiceCollection();
        }
        public T Resolve<T>()
        {
            return this._serviceProvider.GetService<T>();
        }
        private void ConfigureService()
        {
            this._serviceCollection.AddSingleton<IAlarm, Alarm>();
            this._serviceCollection.AddSingleton<ISensor, Sensor>();

            this._serviceCollection.AddSingleton<ITelemetryClient, TelemetryClient>();
            this._serviceCollection.AddSingleton<ITelemetryDiagnosticControls, TelemetryDiagnosticControls>();

            this._serviceCollection.AddSingleton<ITicketDispenser, TicketDispenser>();
            this._serviceCollection.AddSingleton<ITurnNumberSequence, TurnNumberSequence>();

            this._serviceCollection.AddSingleton<IFileSystem, FileSystem>();
            this._serviceCollection.AddSingleton<IUnicodeFileToHtmlTextConverter, TDDMicroExercises.UnicodeFileToHtmlTextConverter.UnicodeFileToHtmlTextConverter>();
        }
        #endregion
    }
}
