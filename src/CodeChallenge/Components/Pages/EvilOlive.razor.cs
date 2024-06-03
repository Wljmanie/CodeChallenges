using System.Text.RegularExpressions;

namespace CodeChallenge.Components.Pages{
    public partial class EvilOlive{
        private string input = string.Empty;
        private string output = string.Empty;
        private bool isPalidrome = false;

        public void Palindrome(string input){
            char[] chars = Regex.Replace(input.ToLower(), "[^a-z0-9]+", "").ToCharArray();
            string cleanInput = new string(chars);
            Array.Reverse(chars);
            output = new string(chars);
            isPalidrome = output == cleanInput;
        }

        public string GetOutput() => output;
        public bool IsPalidrome() => isPalidrome;
    }
}