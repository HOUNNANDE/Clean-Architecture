namespace AspNetCore.Courses.Section15
{
	public class XunitDefault
	{
		public int Num1 { get; set; }
		public int  Num2 { get; set; } 

		public XunitDefault(int num1, int num2) {
			Num1= num1;	
			Num2= num2;
		}
		
		public int GetCalculator() {


			return Num1 + Num2;  
		}
	}
}
