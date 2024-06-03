using CodeChallenge.Components.Pages;

namespace NUnitTest;

public class FizzBuzzTests{
    private FizzBuzz fizzBuzz = new FizzBuzz();
    public static IEnumerable<(FizzBuzzModel,int)> TestCases(){
        yield return ( new FizzBuzzModel{fromNumber = 1, toNumber = 1000, fizzNumber = 3, buzzNumber = 5}, 1000);
        yield return ( new FizzBuzzModel{fromNumber = -1000, toNumber = 1000, fizzNumber = 3, buzzNumber = 5}, 2001);
        yield return ( new FizzBuzzModel{fromNumber = 1000, toNumber = -1001, fizzNumber = 3, buzzNumber = 5}, 2002);
        yield return ( new FizzBuzzModel{fromNumber = 1, toNumber = 100000, fizzNumber = 3, buzzNumber = 5},0);
    } 

    [TestCase(1,3,5, ExpectedResult = "<span>1</span>")]
    [TestCase(-2221,3,5, ExpectedResult = "<span>-2221</span>")]
    [TestCase(3,3,5, ExpectedResult = "<span class=\"fizz\">Fizz</span>")]
    [TestCase(5,3,5, ExpectedResult = "<span class=\"buzz\">Buzz</span>")]
    [TestCase(15,3,5, ExpectedResult = "<span class=\"fizz\">Fizz</span><span class=\"buzz\">Buzz</span>")]
    [TestCase(7,3,5, ExpectedResult = "<span>7</span>")]
    [TestCase(8,8,5, ExpectedResult = "<span class=\"fizz\">Fizz</span>")]
    [TestCase(21,22,7, ExpectedResult = "<span class=\"buzz\">Buzz</span>")]
    public string FizzBuzzGet(int i, int fizz, int buzz){
        return fizzBuzz.GetFizzBuzz(i,fizz,buzz);
    }

    [TestCaseSource(nameof(TestCases))]
    public void FizzBuzzCreate((FizzBuzzModel fbm, int expected) td){
        fizzBuzz.CreateFizzBuzz(td.fbm);
        Assert.That(td.expected, Is.EqualTo(fizzBuzz.FizzBuzzList!.Count));
    }
}