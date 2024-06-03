using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Components;

namespace CodeChallenge.Components.Pages{
    public partial class FizzBuzz{
        [SupplyParameterFromForm]
        FizzBuzzModel FizzBuzzModel {get;set;} = new FizzBuzzModel();

        public List<string>? FizzBuzzList;

        public void CreateFizzBuzz(){
            CreateFizzBuzz(FizzBuzzModel);
        }

        public void CreateFizzBuzz(FizzBuzzModel fbm){
            FizzBuzzList = new List<string>();
            if(fbm.fromNumber > fbm.toNumber){
                if(fbm.fromNumber - fbm.toNumber > 10000){
                    return;
                }
                for(int i = fbm.fromNumber; i >= fbm.toNumber; i--){
                    FizzBuzzList.Add(GetFizzBuzz(i, fbm.fizzNumber, fbm.buzzNumber));
                }
            }
            else if(fbm.toNumber - fbm.fromNumber > 10000){
                    return;
            }
            for(int i = fbm.fromNumber; i <= fbm.toNumber; i++){
                FizzBuzzList.Add(GetFizzBuzz(i, fbm.fizzNumber, fbm.buzzNumber));
            }
        }

        public string GetFizzBuzz(int i, int fizz, int buzz){
            string s = string.Empty;
            if(i%fizz == 0)
                s += "<span class=\"fizz\">Fizz</span>";
            if(i%buzz == 0)
                s += "<span class=\"buzz\">Buzz</span>";
            if(s.Length == 0)
                s += $"<span>{i}</span>";
            return s;       
        }
    }

    public class FizzBuzzModel(){
        [Required]
        public int fromNumber = 1;
        [Required]
        public int toNumber = 10;
        [Required]
        public int fizzNumber = 3;
        [Required]
        public int buzzNumber = 5;
    }      
}          
           
                 