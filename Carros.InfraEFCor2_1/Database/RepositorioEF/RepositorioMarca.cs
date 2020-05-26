using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.InfraEFCor2_1.Database.ContextoPrincipal;

namespace Carros.InfraEFCor2_1.Database.RepositorioEF
{
    public class RepositorioMarca : RepositorioBase<Marca>, IRepositorioMarca
    {
        public RepositorioMarca(Contexto contexto) : base(contexto)
        {
        }


        //public Marca ObterPorid(int id)
        //{
        //    return RetornarPorId(id);
        //}

        //public void Excluir(int id)
        //{
        //    var model = RetornarPorId(id);
        //    Deletar(model);
        //    Commit();
        //}

        //public void Salvar(Marca model)
        //{
        //    if (model.Id > 0)
        //    {

        //        Alterar(model);
        //    }
        //    else
        //    {
        //        model.Id = Sequencial();
        //        Adicionar(model);
        //    }
        //    Commit();
        //}

        //public List<Marca> ListarPorNome(string nome, int id = 0)
        //{
        //    var resultado = RetornarTodos();

        //    if (id > 0)
        //        resultado = resultado.Where(x => x.Id == id);
        //    else
        //        resultado = resultado.Where(x => x.Descricao.Contains(nome)).OrderBy(x => x.Descricao);

        //    return resultado.ToList();
        //}

        public int Sequencial()
        {
            //TODO: metodo não utilizado
            //var seq = new RepositorioGenerator(_contexto);
            //var tt = _contexto.MarcaSet.FromSql("SELECT GEN_ID(SEQ_MARCA,1) FROM RDBDATABASE");
            //return tt.Single().Id;
            return 0;
        }
    }
}
