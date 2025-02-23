using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Tests.Helpers
{
    internal class TestHelper
    {
        internal static bool IsGithubActionRun => Environment.GetEnvironmentVariable("GITHUB_ACTIONS") == "true";
    }
}
