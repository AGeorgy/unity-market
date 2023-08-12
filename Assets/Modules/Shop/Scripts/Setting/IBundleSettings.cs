using System.Collections.Generic;

namespace Shop.Setting
{
    public interface IBundleSettings
    {
        List<IBundleSetting> Bundles { get; }
    }
}