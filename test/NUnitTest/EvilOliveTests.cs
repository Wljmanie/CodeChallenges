using CodeChallenge.Components.Pages;

namespace NUnitTest;

public class EvilOliveTests{
    private EvilOlive evilOlive = new EvilOlive();

    [SetUp]
    public void SetUp(){
    }
    
    [TestCase("Evil Olive","evilolive",true)]
    [TestCase("Baas, neem een racecar, neem een Saab.","baasneemeenracecarneemeensaab",true)]
    [TestCase("Evill Olive","evilollive",false)]
    [TestCase("Evil123","321live",false)]
    [TestCase("321Evil123","321live123",false)]
    [TestCase("321 Evil Olive 123","321evilolive123",true)]
    public void EvilOliveInput(string input, string expected, bool isTrue){
        evilOlive.Palindrome(input);
        Assert.That(expected, Is.EqualTo(evilOlive.GetOutput()));
        Assert.That(isTrue, Is.EqualTo(evilOlive.IsPalidrome()));
    }

}