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

        [Fact]
        public async Task GetTimeWindow_BeforeWindow_IsNotReturned()
        {
            var repo = new MeterReadingRepositoryInMemory();

            await repo.SaveAsync(CreateTestReading(new DateTime(2023, 5, 1)));

            var window = new TimeWindow(new DateTime(2023, 6, 1), new DateTime(2023, 7, 1));

            var all = await repo.GetReadingsAsync(window);

            all.ShouldNotContain(CreateTestReading(new DateTime(2023, 5, 1)));
        }

        private MeterReading CreateTestReading(DateTime? customTimestamp = null)
        {
            var ts = customTimestamp ?? new DateTime(2023, 6, 11);
            return new MeterReading(ts, new TotalKilowattHours(0));
        }
    }
}