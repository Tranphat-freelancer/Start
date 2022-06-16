using System;
using System.Collections.Generic;
using System.Text;
using Main.Localization;
using Volo.Abp.Application.Services;

namespace Main;

/* Inherit your application services from this class.
 */
public abstract class MainAppService : ApplicationService
{
    protected MainAppService()
    {
        LocalizationResource = typeof(MainResource);
    }
}
