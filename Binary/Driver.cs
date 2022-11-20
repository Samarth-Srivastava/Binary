using System.Text;  
using System.Text.RegularExpressions;

namespace Binary
{
    public static class Common{
        public static bool ValidateStringInput(string str){
            bool flag = true;

            if(str.Split(" ").Length > 1){
                Console.WriteLine("String has space/s");
                flag = false;
            }
            var regex = new Regex("^[0-1]{1,}$");
            if(!regex.IsMatch(str) && str.Length > 0){
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
            Console.WriteLine("Ones Complement: Press 5");
            Console.WriteLine("Twos Complement: Press 6");
            Console.WriteLine("Negative Number: Press 7");
            Console.WriteLine("Difference 2 binary strings: Press 8");
            Console.WriteLine("Single Numbers: Press 9");
            Console.WriteLine("Check if i-th bit is set : Press 10");
            Console.WriteLine("Check even : Press 11");
            Console.WriteLine("Check odd : Press 12");
            Console.WriteLine("Bitwise Operations on 2 numbers : Press 13");
            Console.WriteLine("Set Ith Bit : Press 14");
            Console.WriteLine("UnSet Ith Bit : Press 15");
            Console.WriteLine("Find Mod : Press 16");
            Console.WriteLine("Find Majority Element : Press 17");

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
                    case "5":
                        CallOnesComplement();
                        break;
                    case "6":
                        CallTwosComplement();
                        break;
                    case "7":
                        CallNegativeNumber();
                        break;
                    case "8":
                        CallDiff2BinaryStrings();
                        break;
                    case "9":
                        CallSingleNumbers();
                        break;
                    case "10":
                        CallCheckBit();
                        break;
                    case "11":
                        CallCheckEven();
                        break;
                    case "12":
                        CallCheckOdd();
                        break;
                    case "13":
                        CallBitWise();
                        break;
                    case "14":
                        CallSetBit();
                        break;
                    case "15":
                        CallUnSetBit();
                        break;
                    case "16":
                        CallFindMod();
                        break;
                    case "17":
                        CallMaojorityElement();
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

            double pow = s.PowOf2(x);
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

        public void CallOnesComplement(){
            Console.Clear();
            Console.WriteLine("Enter a binary number");
            string? str1 = Console.ReadLine();

            if (Common.ValidateStringInput(str1)){
                var addition = s.OnesComplement(str1);
                Console.WriteLine(addition);
            }
        }

        public void CallTwosComplement(){
            Console.Clear();
            Console.WriteLine("Enter a binary number");
            string? str1 = Console.ReadLine();

            if (Common.ValidateStringInput(str1)){
                var addition = s.TwosComplement(str1);
                Console.WriteLine(addition);
            }
        }

        public void CallNegativeNumber(){
            Console.Clear();
            Console.WriteLine("Enter a decimal number");
            int str1 = Convert.ToInt32(Console.ReadLine());

            var addition = s.NegativeOfANumber(str1);
            
            Console.WriteLine(addition);
        }

        public void CallDiff2BinaryStrings(){
            Console.Clear();
            Console.WriteLine("Enter 2 binary numbers, 1 per line");
            string? str1 = Console.ReadLine();
            string? str2 = Console.ReadLine();

            //validate input
            if (Common.ValidateStringInput(str1) && Common.ValidateStringInput(str2)){
                var addition = s.Diff2BinaryStrings(str1, str2);
                Console.WriteLine(addition);
            }
        }

        public void CallSingleNumbers(){
            Console.Clear();
            Console.WriteLine("Enter Integer Array with spaces in between");

            string? line = Console.ReadLine();
            string[] n_arr_str = string.IsNullOrEmpty(line) ? new string[0] : line.Split(' ');

            int[] arr = new int[n_arr_str.Length];
            for (int i = 0; i < n_arr_str.Length; i++)
            {
                arr[i] = Convert.ToInt32(n_arr_str[i]);
            }

           int[] singles = s.GetSingleNumber(arr, arr.Length);

            Console.WriteLine("Single numbers are :");
            for (int i = 0; i < singles.Length; i++)
            {
                Console.Write(Convert.ToInt32(singles[i]) + " ");
            }
        }

        public void CallCheckBit(){
            Console.Clear();
            Console.WriteLine("Enter a number");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of bit to check");
            int i = Convert.ToInt32(Console.ReadLine());

            bool a = s.Is_Ith_Bit_Set(N, i);
            Console.WriteLine(a);
        }

         public void CallCheckEven(){
            Console.Clear();
            Console.WriteLine("Enter a number");
            int N = Convert.ToInt32(Console.ReadLine());

            bool a = s.isEven(N);
            Console.WriteLine(a);
        }

        public void CallCheckOdd(){
            Console.Clear();
            Console.WriteLine("Enter a number");
            int N = Convert.ToInt32(Console.ReadLine());

            bool a = s.isOdd(N);
            Console.WriteLine(a);
        }

        public void CallBitWise(){
            Console.Clear();
            Console.WriteLine("Enter two numbers, 1 per line");
            int A = Convert.ToInt32(Console.ReadLine());
            int B = Convert.ToInt32(Console.ReadLine());

            int[] arr = s.BitWiseOperations(A, B);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    
        public void CallSetBit(){
            Console.Clear();
            Console.WriteLine("Enter a number");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of bit to check");
            int i = Convert.ToInt32(Console.ReadLine());

            int a = s.Set_Ith_Bit(N, i);
            Console.WriteLine(a);
        }

        public void CallUnSetBit(){
            Console.Clear();
            Console.WriteLine("Enter a number");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of bit to check");
            int i = Convert.ToInt32(Console.ReadLine());

            long a = s.UnSet_Ith_Bit(N, i);
            Console.WriteLine(a);
        }

        public void CallFindMod(){
            Console.Clear();
            Console.WriteLine("Enter any number");
            string A = Console.ReadLine();

            Console.WriteLine("Enter divisor");
            int B = Convert.ToInt32(Console.ReadLine());

            int a = s.findMod(A, B);
            Console.WriteLine(a);
        }

        public void CallMaojorityElement(){
            Console.Clear();
            Console.WriteLine("Enter Integer Array with spaces in between");

            string? line = Console.ReadLine();
            string[] n_arr_str = string.IsNullOrEmpty(line) ? new string[0] : line.Split(' ');

            int[] arr = new int[n_arr_str.Length];
            for (int i = 0; i < n_arr_str.Length; i++)
            {
                arr[i] = Convert.ToInt32(n_arr_str[i]);
            }

            int maj = s.MajorityElement(arr, arr.Length);
            Console.WriteLine(maj == -1 ? "No Majority element found" : "Majority Element is : " + maj);
        }
    }
}