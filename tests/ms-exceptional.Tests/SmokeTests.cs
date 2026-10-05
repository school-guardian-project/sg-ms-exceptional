using System.Reflection;

namespace ms_exceptional.Tests;

/// <summary>
/// Setup smoke test. It fails whenever the API project stops compiling or its
/// entry point is renamed, which is the only thing this branch wires up.
/// </summary>
public class SmokeTests
{
    [Fact]
    public void ApiAssembly_ExposesProgramEntryPoint()
    {
        var assembly = Assembly.Load("ms-exceptional.Api");

        Assert.NotNull(assembly.GetType("Program"));
    }
}
