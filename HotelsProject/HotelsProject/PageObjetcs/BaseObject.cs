using OpenQA.Selenium;

// should say "why" you have some line of code
// but you should not say "what" the code does

// parent of all objects that use the web driver
namespace HotelsProject.PageObjetcs
{
	public abstract class BaseObject
	{
		public IWebDriver Driver { get; }
		// Declaring the variable
		

		protected BaseObject(IWebDriver driver)
		{
			Driver = driver;
			// Initialize 
		}

	}
}
