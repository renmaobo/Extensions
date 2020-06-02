using System;
using Xunit;

namespace MaoBo.Extensions.XUnitTestProject.System
{
    public class StringExtensionTest
    {
        [Fact]
        public void TestMd5()
        {
            string value = $"123456".ToMD5String();

        }
    }
}
