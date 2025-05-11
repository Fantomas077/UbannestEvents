using UbannestEvents.Models;

namespace UbannestEvents.ViewModels
{
    public class HomeVM
    {
        public List<Event>?IncommingsEvent {  get; set; }
        public List<Event>? TodayEvents { get; set; }
        public List<Event>? MostView { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
