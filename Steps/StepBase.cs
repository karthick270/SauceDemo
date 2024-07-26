using BoDi;
using SauceDemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.Steps
{
    public abstract class StepBase : TechTalk.SpecFlow.Steps
    {
        protected readonly IObjectContainer Container;

        protected StepBase(IObjectContainer container)
        {
            Container = container;
        }

        protected TPage GetPage<TPage>() where TPage : BasePage
        {
            return Container.Resolve<TPage>();
        }
    }
}
