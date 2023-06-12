using PowerUsage.Core.Values;
using PowerUsage.Infrastrucure;
using Shouldly;

namespace PowerUsage.Tests.Unit.Core
{
    public class MeterReadingRepositoryInMemoryTests
    {
        [Fact]
        public async Task StoreMeterReading()
        {
            var repo = new MeterReadingRepositoryInMemory();
            await repo.SaveAsync(new MeterReading(new DateTime(2023, 6, 11), new TotalKilowattHours(0)));

            var all = await repo.GetAllAsync();

            all.ShouldContain(new MeterReading(new DateTime(2023, 6, 11), new TotalKilowattHours(0)));
        }
    }
}