using AutoFixture;
using AutoFixture.AutoMoq;

namespace Simple.DataCore.SQLIntegrationTests
{
    public class TestsBase
    {
        protected Fixture fixture;
        [SetUp]
        public virtual void Setup()
        {
            fixture = new();
            fixture.Customize(new AutoMoqCustomization());
        }
    }
}
