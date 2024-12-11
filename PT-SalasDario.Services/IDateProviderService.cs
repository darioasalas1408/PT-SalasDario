namespace PT_SalasDario.Services
{
    /// <summary>
    /// Esta interfaz tiene el propósito de poder manejar la configuración de fechas/horas  de la App, en un sólo lugar. Además de poder ser inyectada en los casos de test
    /// </summary>
    public interface IDateProviderService
    {
        public DateTime Now { get; }
    }
}
