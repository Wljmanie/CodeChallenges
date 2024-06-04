using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace CodeChallenge.Components.Pages{
    public partial class Mortgage{
        [SupplyParameterFromForm]
        public MortgageModel MortgageModel {get;set;} = new();
        private double monthyInterestPercentage;
        private double monthlyCost;
        private double totalInterest;
        private double totalCost;
        private List<Payment> payments = new List<Payment>();

        public void CreateMortgage(){
            CreateMortgage(MortgageModel);
        }

        public void CreateMortgage(MortgageModel mm){
            payments = new List<Payment>();
            if(mm.Years <= 0) return;
            if(mm.InterestPercentage < 0.01) return;
            if(mm.MortgageLoan < 0.1)return;
            totalInterest = 0;
            totalCost = 0;
            monthyInterestPercentage = mm.InterestPercentage / 100 / 12;
            double years = Convert.ToDouble(mm.Years);
            mm.MortgageLoan = Math.Round(mm.MortgageLoan,2);
            monthlyCost = ((monthyInterestPercentage * mm.MortgageLoan)/ (1 - Math.Pow( 1+monthyInterestPercentage , -years * 12)));
            monthlyCost = Math.Round(monthlyCost, 2);
            double balanceThisMonth = Math.Round(mm.MortgageLoan + mm.MortgageLoan * monthyInterestPercentage, 2);
            double interestThisMonth = Math.Round(balanceThisMonth - mm.MortgageLoan, 2);
            double principalThisMonth = Math.Round(monthlyCost - interestThisMonth, 2);
            balanceThisMonth = Math.Round(balanceThisMonth - monthlyCost, 2);

            for(int i = 1; i < mm.Years * 12; i++ ){
                payments.Add(new Payment{
                    period = i,
                    payment = monthlyCost,
                    interest = interestThisMonth,
                    pricipal = principalThisMonth,
                    balance = balanceThisMonth
                });
                interestThisMonth = Math.Round(balanceThisMonth * monthyInterestPercentage, 2);
                totalInterest += interestThisMonth;
                principalThisMonth = Math.Round(monthlyCost - interestThisMonth, 2);
                balanceThisMonth = Math.Round(balanceThisMonth - principalThisMonth, 2);
            }
            
            totalInterest += interestThisMonth;
            totalInterest = Math.Round(totalInterest,2);
            payments.Add(new Payment{
                period = mm.Years * 12,
                payment = interestThisMonth + principalThisMonth + balanceThisMonth,
                interest = interestThisMonth,
                pricipal = principalThisMonth + balanceThisMonth,
                balance = 0
            });
            totalCost = Math.Round(totalInterest + mm.MortgageLoan, 2);
        }
    public int GetListLength() => payments.Count;
    }

    public class MortgageModel(){
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "You need a positive value for the loan.")]
        public double MortgageLoan {get; set;} = 300000.00;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You need a positive number of years.")]
        public int Years {get; set;} = 30;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "You need a positive value for the interest percentage.")]
        public double InterestPercentage {get; set;} = 6.5;
    }    

    public record struct Payment(
        int period,
        double payment,
        double interest,
        double pricipal,
        double balance
    );
}
    