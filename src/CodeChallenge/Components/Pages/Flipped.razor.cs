namespace CodeChallenge.Components.Pages{
    public partial class Flipped{
        private string input = string.Empty;
        private string output = string.Empty;

        private void Flip(string input){
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            output = new string(chars);
        }
    }
}