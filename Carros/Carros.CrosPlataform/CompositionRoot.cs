using Ninject;
using Ninject.Modules;
using Ninject.Parameters;

namespace Carros.CrosPlataform
{
    public class CompositionRoot
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }

        public static T ResolveWithArgument<T>(ConstructorArgument argument)
        {
            return _ninjectKernel.Get<T>(argument);
        }
    }
}
