﻿using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace NRSoft.CloudBackup.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class CloudBackupBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "CloudBackup";
    }
}
