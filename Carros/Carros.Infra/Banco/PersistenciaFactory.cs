namespace Carros.Infra.Banco
{
    public class PersistenciaFactory
    {
        public Persistencia Instanciar()
        {
            return new PersistenciaDapper();
        }
    }
}
