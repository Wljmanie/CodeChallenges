using CodeChallenge.Components.Pages;

namespace NUnitTest;

public class MortgageTests{
    private Mortgage mortgage = new Mortgage();
    
    [TestCase(123.12, 1, 4.3, ExpectedResult = 12)]
    [TestCase(-123.12, 1, 4.3, ExpectedResult = 0)]
    [TestCase(123.12, 0, 4.3, ExpectedResult = 0)]
    [TestCase(123.12, 1, -4.3, ExpectedResult = 0)]
    [TestCase(12334324.12, 12, 22.3, ExpectedResult = 144)]
    public int CreateMortgage(double loan, int years, double InterestPercentage){
        MortgageModel mm = new MortgageModel{Years = years, InterestPercentage = InterestPercentage, MortgageLoan = loan};

        mortgage.CreateMortgage(mm);
        return mortgage.GetListLength();
    }
}