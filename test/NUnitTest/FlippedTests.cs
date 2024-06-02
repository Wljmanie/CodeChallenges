using System.Runtime.CompilerServices;
using CodeChallenge.Components.Pages;

namespace NUnitTest;

public class FlippedTests
{
    [SetUp]
    public void Setup()
    {
    }
    private Flipped flipped = new Flipped();
    private string testcase1 = "Test";
    private string testcase2 = "A long test With Multiple words and weird symbols like ;*728154%$#@!)(*&^{}[,.<>'\"]\\|)";
    private string testcase3 = "123";
    private string testcase1expectation = "tseT";
    private string testcase2expectation = ")|\\]\"'><.,[}{^&*()!@#$%451827*; ekil slobmys driew dna sdrow elpitluM htiW tset gnol A";
    private string testcase3expectation = "321";

    [Test]
    public void FlippingInput()
    {
        flipped.Flip(testcase1);
        Assert.That(testcase1expectation, Is.EqualTo(flipped.GetOutput()));
    }

    [Test]
    public void FlippingInputSymbols(){
        flipped.Flip(testcase2);
        Assert.That(testcase2expectation, Is.EqualTo(flipped.GetOutput()));
    }

    [Test]
    public void FlippingInputNumbers(){
        flipped.Flip(testcase3);
        Assert.That(testcase3expectation, Is.EqualTo(flipped.GetOutput()));
    }
}