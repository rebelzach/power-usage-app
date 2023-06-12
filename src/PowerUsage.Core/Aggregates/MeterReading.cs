using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerUsage.Core.Values;

public record MeterReading(DateTime Timestamp, TotalKilowattHours TotalKilowattHours);
