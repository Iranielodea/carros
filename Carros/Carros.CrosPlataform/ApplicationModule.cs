using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using Carros.Dominio.Servicos;
using Carros.Infra.Dapper.Repositorio;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.CrosPlataform
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind(typeof(IUnitOfWork)).To(typeof(UnitOfWork));
            Bind(typeof(IRepositoryCidade)).To(typeof(RepositoryCidadeDapper));

            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind(typeof(IServiceCidade)).To(typeof(ServiceCidade));
        }
    }
}
