using System;

namespace Books.Core.Services
{
    public class ScheduleService
        : IScheduleService
    {
        private readonly ISimpleRestService _simpleRestService;

        public ScheduleService(ISimpleRestService simpleRestService)
        {
            _simpleRestService = simpleRestService;
        }

        public void StartSearchAsync(string whatFor, Action<ScheduleSearchResult> success, Action<Exception> error)
        {
            string address = string.Format("http://ciafadmin.herokuapp.com/api/schedule?q={0}",
                                            Uri.EscapeDataString(whatFor));
            _simpleRestService.MakeRequest<ScheduleSearchResult>(address,
                "GET", success, error);
        }
    }
}
