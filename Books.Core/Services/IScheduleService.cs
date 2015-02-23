using System;

namespace Books.Core.Services
{
    public interface IScheduleService
    {
        void StartSearchAsync(string whatFor, Action<ScheduleSearchResult> success, Action<Exception> error);
    }
}