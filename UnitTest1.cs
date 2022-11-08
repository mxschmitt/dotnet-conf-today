using System.Text.RegularExpressions;
using Microsoft.Playwright.MSTest;
using Microsoft.Playwright;

namespace PlaywrightDotnetConf;

[TestClass]
public class Tests : PageTest
{
    [TestMethod]
    public async Task MyTest()
    {
        await Page.GotoAsync("https://dotnetpodcasts.azurewebsites.net/");

        await Page.GetByRole(AriaRole.Link, new() { NameString = "Discover more" }).ClickAsync();

        await Page.GetByRole(AriaRole.Link, new() { NameString = ".NET Rocks!  .NET Rocks! Carl Franklin" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = ".NET Rocks!" })).ToBeVisibleAsync();

        await Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = "Carl Franklin" })).ToBeVisibleAsync();

        await Page.GetByRole(AriaRole.Heading, new() { NameString = "Testing Angular Forms with Martine Dowden" }).ClickAsync();

        // Click on the "Listen Later" button
        await Page.Locator("button:nth-child(2)").First.ClickAsync();

        await Page.GetByRole(AriaRole.Link, new() { NameString = "Listen Later" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = "Testing Angular Forms with Martine Dowden" })).ToBeVisibleAsync();

        await Expect(Page.GetByRole(AriaRole.Heading, new() { NameString = ".NET Rocks!" })).ToBeVisibleAsync();

    }
}
