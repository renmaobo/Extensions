using System;
using Xunit;

namespace MaoBo.Extensions.XUnitTestProject.System
{
    /// <summary>
    /// long type extension test
    /// </summary>
    public class LongExtensionTest
    {
        /// <summary>
        /// test timestamp
        /// </summary>
        [Fact]
        public void TestTimestamp()
        {
            long timestamp = DateTime.Now.GetCurrentTimestamp();
            Assert.NotNull(timestamp);
            Assert.NotEqual(timestamp, 0.0);
        }
    }
}
