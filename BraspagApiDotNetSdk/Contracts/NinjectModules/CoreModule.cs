using Ninject;
using Ninject.Modules;
using RestSharp;

namespace BraspagApiDotNetSdk.Contracts.NinjectModules
{
	public class CoreModule : NinjectModule
	{
		private static IKernel _kernel;

		public static IKernel CoreKernel
		{
			get { return _kernel ?? (_kernel = new StandardKernel(new CoreModule())); }
		}

		public override void Load()
		{
			Bind<IRestClient>().To<RestClient>();
		}
		
	}
}
