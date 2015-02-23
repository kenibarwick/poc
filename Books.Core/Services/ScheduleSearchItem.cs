namespace Books.Core.Services
{
    public class ScheduleSearchItem
    {
        public RootObject rootObject { get; set; }

        public override string ToString()
        {
            return rootObject.name;
        }
    }
}