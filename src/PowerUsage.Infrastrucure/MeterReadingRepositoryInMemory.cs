using PowerUsage.Core.Values;

namespace PowerUsage.Infrastrucure;

public class MeterReadingRepositoryInMemory
{
    public Task<List<MeterReading>> GetAllAsync()
    {
        return Task.FromResult<List<MeterReading>>(null);
    }

    public Task SaveAsync(MeterReading meterReading)
    {
        return Task.CompletedTask;
    }
}