using System;
namespace mavvm.Attibutes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class SectionRouteAttribute : Attribute
	{
		public string SectionRoute { get; }

		public SectionRouteAttribute(string sectionRoute)
		{
			SectionRoute = sectionRoute;
		}
	}
}

