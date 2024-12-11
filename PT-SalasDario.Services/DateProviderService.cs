namespace PT_SalasDario.Services
{
    public class DateProviderService : IDateProviderService
    {
        public DateTime Now { get => DateTime.Now; }
    }
}
