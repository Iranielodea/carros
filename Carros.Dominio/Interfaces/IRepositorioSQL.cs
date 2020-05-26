namespace Carros.Dominio.Interfaces
{
    public interface IRepositorioSQL
    {
        void ExecutarSQL(string instrucaoSQL);
    }
}
