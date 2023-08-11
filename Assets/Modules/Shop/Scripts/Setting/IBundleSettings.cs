using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Shop.Setting
{
    public interface IBundleSettings
    {
        ReadOnlyCollection<BundleSetting> Bundles { get; }
    }
}