using NUnit.Framework;
using Xamarin.UITest;
using Xamariners.EndToEnd.Xamarin.Demo.Features;

namespace Xamariners.EndToEnd.Xamarin.Demo
{
    [TestFixture(Platform.Android)]
#if __Apple__
    [TestFixture(Platform.iOS)]
#endif
    public partial class EntryToLabelPageFeature : BaseLocalFeature
    {
        public EntryToLabelPageFeature(Platform platform) : base(platform)
        {
        }
    }
}