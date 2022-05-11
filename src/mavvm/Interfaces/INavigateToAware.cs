using System;
namespace mavvm
{
	public interface INavigateToAware
	{
		void NavigatedTo(NavigationParameters parameters);
	}
}

