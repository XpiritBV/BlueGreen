using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlueGreen.HealthChecks
{
    public class IsBuggyCheck : IHealthCheck
    {
        private readonly bool isBuggy;

        public IsBuggyCheck(IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            string buggy = configuration["buggy"];
            isBuggy = string.Equals(buggy, "true", StringComparison.InvariantCultureIgnoreCase);
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var healthStatus = isBuggy ? HealthStatus.Unhealthy : HealthStatus.Healthy;
            var result = new HealthCheckResult(healthStatus);
            return Task.FromResult(result);
        }
    }
}
