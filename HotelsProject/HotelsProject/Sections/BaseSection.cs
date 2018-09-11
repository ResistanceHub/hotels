using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsProject.PageObjetcs;
using OpenQA.Selenium;

namespace HotelsProject.Sections
{
	public abstract class BaseSection : BaseObject
	{
		protected string SectionSelector { get; }

		protected BaseSection(IWebDriver driver, string sectionSelector) : base(driver)
		{
			SectionSelector = sectionSelector;
		}
	}
}
