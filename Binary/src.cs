namespace Binary{
	public class Solution{

		public string DecimalToBinary(int num){
			string str = "";

			while(num > 0){
				int rem = num %2;
				str = rem + str;
				num = num/2;
			}
			return str;
		}

		public int BinaryToDecimal(string binary){
			int num = 0;
			int N = binary.Length;
			for (int i = 0, j = N-1; i < N; i++, j--)
			{
				num += Int32.Parse(binary[i].ToString())*(int)PowOf2(j);
			}
			return num;
		}

		//for powers of 2 we can use bit shift right or left 
		public double PowOf2(int N){
			if(N < 0)
				return 1 >> N;
			else
				return 1 << N;
		}

		public string OnesComplement(string binary, int bits = 30){
			string OnesComplement = "";
			int N = binary.Length;

			binary = FillBinary(binary, bits-N);

			for (int i = 0; i < bits; i++)
			{
				OnesComplement = OnesComplement + (binary[i] == '0' ? "1" : "0");
			}

			return OnesComplement;
		}

		public string TwosComplement(string binary, int bits = 30){
			
			return Add2BinaryStrings(OnesComplement(binary, bits), "1");
		}

		public int NegativeOfANumber(int num){
			// -1 * num

			string bin = DecimalToBinary(num);
			string twos = TwosComplement(bin);
			int dec = BinaryToDecimal(twos);
			return (int)(dec - PowOf2(30));
		}

		public string FillBinary(string binary, int bits = 30){
			int binaryLength = binary.Length;
			for (int i = 0; i < bits; i++)
			{
				binary = "0" + binary;
			}
			return binary;
		}

		public string Diff2BinaryStrings(string str1, string str2){
			int str1Length = str1.Length;
			int str2Length = str2.Length;
			int N = Math.Max(str1Length, str2Length);

			//get twos complement for smaller number
			string strfirst = str1Length > str2Length ? str1 : str2;
			string strsecnd = str1Length < str2Length ? str1 : str2;
			strsecnd = TwosComplement(strsecnd);

			string dif = Add2BinaryStrings(strfirst, strsecnd);
			return dif.Substring(dif.Length - N, N);
		}

		public string Add2BinaryStrings(string str1, string str2){
			string strfirst = str1.Length > str2.Length ? str1 : str2;
			string strsecnd = str1.Length <= str2.Length ? str1 : str2;

			char[] chr1 = strfirst.ToCharArray();
			char[] chr2 = strsecnd.ToCharArray();
			string str3 = "";

			int carry = 0;
			int i = chr1.Length -1;
			int j = chr2.Length -1;

			while(carry > 0 || j >= 0){
				int f = i < 0 ? 0 : int.Parse(chr1[i].ToString());
				int s = j < 0 ? 0 : int.Parse(chr2[j].ToString());
				int temp = f + s + carry;
				i--;
				j--;
				int sum = temp%2;
				carry = temp/2;
				str3 = sum.ToString() + str3;	
			}

			str3 = i >= 0 ? strfirst.Substring(0, i+1) + str3 : str3;
			return str3;
		}
	
		/*
		a & 1 == 0 => a is even, 0th bit is unset
		a | 1 == 1 => a is odd, 0th bit is set

		a & 0 = 0
		a & a = a
		a | 0 = a
		a | a = a
		a ^ 0 = a
		a ^ a = 0
		*/

		// Single unique number
		public int[] GetSingleNumber(int[] arr, int N){
			// int x = 0;
			// for (int i = 0; i < N; i++)
			// {
			// 	x = x ^ arr[i];
			// }
			// return x;

			// another way
			int[] allSingleNumbers = new int[N];
			Dictionary<int, int> dic = new Dictionary<int, int>();
			for (int i = 0; i < N; i++)
			{
				if(dic.ContainsKey(arr[i])){
					dic[arr[i]] += 1;
				}
				else{
					dic.Add(arr[i], 1);
				}
			}
			int counter = 0;
			foreach (int item in dic.Keys)
			{
				if(dic[item] == 1){
					allSingleNumbers[counter] = item;
					counter++;
				}
			}
			return allSingleNumbers;
		}
	
		public bool Is_Ith_Bit_Set(int N, int i){
			/*idea is, odd numbers have 0th bit as 1 and even numbers have 0th bit as 0
			so AND operation of odd numbers with 1 gives output 1, while for even numbers it gives 0
			so to check i-th bit, right shift the given number i bits and, this makes i-th bit as 0th bit
			and then we can use AND operation with 1
			*/
			return (((N >> i) & 1) == 1);
		}

		public bool isOdd(int N){
			return Is_Ith_Bit_Set(N, 0);
		}

		public bool isEven(int N){
			return !Is_Ith_Bit_Set(N, 0);
		}

		public int Set_Ith_Bit(int N, int i){
			// Approach 1:
			// bool a = Is_Ith_Bit_Set(N, i);
			// if(a){
			// 	return N;
			// }
			// else{
			// 	return N + (1 << i);
			// }
			// Approach 2
			/* if we do OR operation, we don't need to check if ith bit is already set
			as an OR operation for 1 and 1 will give 1
			*/
			return N | (1 << i);
		}

		public long UnSet_Ith_Bit(long N, int i){
			long a = 1 << i;
			long b = ~a;
			long c = N & b;
			return c;
		}

		public int CountNumberOfSetBits(int N){
			int count= 0;
			while(N > 0){
				if((N & 1) == 1){
					count++;
				}
				N = N >> 1;
			}
			return count;
		}

		public int[] BitWiseOperations(int A, int B){
			int[] arr = new int[5];
			arr[0] = A & B;
			arr[1] = A | B;
			arr[2] = A ^ B;
			arr[3] = ~A;  
			arr[4] = ~B;
			return arr;
		}

		/*doing AND operation for any N with N-1 unsets the right most set bit
		if N is a power of 2 => N & N-1 is 0, as there is 1 set bit in N
		*/

		/*to get x set bits, (1 << x)-1
		*/

		public int findMod(string A, int B) {
			int N = A.Length;
			int sum = 0;
			int exp = 1;
			for(int i = N-1; i >= 0; i--){
				int digit = Int32.Parse(A[i].ToString());
				sum += (digit%B)*(exp%B);
				sum = sum%B;
				exp = (exp*10)%B;
			}
			return sum;
    	}
	}
}
