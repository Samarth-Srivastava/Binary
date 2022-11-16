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
				num += Int32.Parse(binary[i].ToString())*PowOf2(j);
			}
			return num;
		}

		//for powers of 2 we can use bit shift right or left 
		public int PowOf2(int N){
			return 1 << N;
		}

		public string Add2BinaryStrings(string str1, string str2){
			char[] chr1 = str1.ToCharArray();
			char[] chr2 = str2.ToCharArray();
			string chr3 = "";
			
			int carry = 0;
			for (int i = 0; i < str1.Length; i++)
			{
				int sum = (int.Parse(chr1[i].ToString()) + int.Parse(chr2[i].ToString()) + carry)%2;
				carry = (int.Parse(chr1[i].ToString()) + int.Parse(chr2[i].ToString()))/2;
				chr3 = sum.ToString() + chr3;	
			}
			chr3 = carry.ToString() + chr3;	
			return chr3;
		}
	}
}
