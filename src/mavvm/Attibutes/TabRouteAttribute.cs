using System;
namespace mavvm.Attibutes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class TabRouteAttribute : Attribute
	{
		public string TabRoute { get; }

		public TabRouteAttribute(string tabRoute)
		{
			TabRoute = tabRoute;
		}
	}
}

