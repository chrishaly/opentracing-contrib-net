using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace OpenTracing.Contrib.NetCore
{
    /// <summary>
    /// Starts and stops all OpenTracing instrumentation components.
    /// </summary>
    public class InstrumentationService : IHostedService
    {
        private readonly DiagnosticManager _diagnosticsManager;

        public InstrumentationService(DiagnosticManager diagnosticsManager)
        {
            _diagnosticsManager = diagnosticsManager ?? throw new ArgumentNullException(nameof(diagnosticsManager));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _diagnosticsManager.Start();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _diagnosticsManager.Stop();

            return Task.CompletedTask;
        }
    }
}