using System.Text;  
using System.Text.RegularExpressions;

namespace Binary
{
    public static class Common{
        public static bool ValidateStringInput(string str){
            bool flag = true;

            if(string.IsNullOrEmpty(str)){
                Console.WriteLine("String empty");
                flag = false;
            }
            if(str.Split(" ").Length > 1){
                Console.WriteLine("String has space/s");
                flag = false;
            }
            var regex = new Regex("^[0-1]{1,}$");
            if(!regex.IsMatch(str)){
                Console.WriteLine("String should only contain 0s and 1s");
                flag = false;
            }
            return flag;
        }
    }
    public class Driver{
        Solution s = new Solution();

        public void Options(){
            Console.WriteLine("Add 2 binary strings: Press 1");
            Console.WriteLine("Decimal to binary: Press 2");
            Console.WriteLine("Binary to Decimal: Press 3");
            Console.WriteLine("Power of 2: Press 4");

            string? input = Console.ReadLine();
            if(!string.IsNullOrEmpty(input)){
                switch(input){
                    case "1":
                        CallAdd2BinaryStrings();
                        break;
                    case "2":
                        CallDecimalToBinary();
                        break;
                    case "3":
                        CallBinaryToDecimal();
                        break;
                    case "4":
                        CallCaluclatrPowerOf2();
                        break;    
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        public void CallDecimalToBinary(){
            Console.Clear();
            Console.WriteLine("Enter a decimal number");
            int x = Convert.ToInt32(Console.ReadLine());

            string b = s.DecimalToBinary(x);
            Console.WriteLine("Binary Representation is :" + b);
        }

        public void CallBinaryToDecimal(){
            Console.Clear();
            Console.WriteLine("Enter a binary string");
            string? str = Console.ReadLine();

            //validate input
            if (Common.ValidateStringInput(str)){
                var dec = s.BinaryToDecimal(str);
                Console.WriteLine("Decimal equivalent is :" + dec);
            }
        }

        public void CallCaluclatrPowerOf2(){
            Console.Clear();
            Console.WriteLine("Enter a decimal number");
            int x = Convert.ToInt32(Console.ReadLine());

            int pow = s.PowOf2(x);
            Console.WriteLine(pow);
        }

        public void CallAdd2BinaryStrings(){
            Console.Clear();
            Console.WriteLine("Enter 2 binary numbers, 1 per line");
            string? str1 = Console.ReadLine();
            string? str2 = Console.ReadLine();

            //validate input
            if (Common.ValidateStringInput(str1) && Common.ValidateStringInput(str2)){
                var addition = s.Add2BinaryStrings(str1, str2);
                Console.WriteLine(addition);
            }
        }
    }
}