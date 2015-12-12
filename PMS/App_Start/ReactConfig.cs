using PMS.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ReactConfig), "Configure")]

namespace PMS.Web
{
	public static class ReactConfig
	{
		public static void Configure()
		{
		}
	}
}