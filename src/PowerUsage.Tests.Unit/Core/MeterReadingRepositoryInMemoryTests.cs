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
            await repo.SaveAsync(CreateTestReading());

            var all = await repo.GetAllAsync();

            all.ShouldContain(CreateTestReading());
        }

        [Fact]
        public async Task GetTimeWindow_InWindow_IsReturned()
        {
            var repo = new MeterReadingRepositoryInMemory();
            await repo.SaveAsync(CreateTestReading());

            var window = new TimeWindow(new DateTime(2023, 6, 1), new DateTime(2023, 7, 1));

            var all = await repo.GetReadingsAsync(window);

            all.ShouldContain(CreateTestReading());
        }

        private MeterReading CreateTestReading()
        {
            return new MeterReading(new DateTime(2023, 6, 11), new TotalKilowattHours(0));
        }
    }
}