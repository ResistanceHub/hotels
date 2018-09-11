using HotelsProject.Sections;
using OpenQA.Selenium;

namespace HotelsProject.PageObjetcs
{
	public class HomePage : BasePageObject
	{
		private const string searchSelectionSelector = "div.horus__row--query";
		public HomePage(IWebDriver driver) : base(driver)
		{
		}

		public SearchSection SearchSection => new SearchSection(Driver, searchSelectionSelector);
		//		public SearchSection SearchSection
		//		{
		//			get { return new SearchSection(Driver, searchSelectionSelector); }
		//		}
		
		//		public SearchSection SearchSection() => new SearchSection(Driver, searchSelectionSelector);


		public HomePageSections Sections => new HomePageSections(Driver);

		

		

		public string Title()
		{
			var title = Driver.FindElement(By.CssSelector("#js-fullscreen-hero .hero__line"));
			return title.Text;
		}
	}
}
