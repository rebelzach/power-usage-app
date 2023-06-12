using PowerUsage.Core.Values;

namespace PowerUsage.Infrastrucure;

public class MeterReadingRepositoryInMemory
{
    private readonly List<MeterReading> _meterReadings = new();

    public Task<List<MeterReading>> GetAllAsync()
    {
        return Task.FromResult(_meterReadings.ToList());
    }

    public Task SaveAsync(MeterReading meterReading)
    {
        _meterReadings.Add(meterReading);

        return Task.CompletedTask;
    }
}