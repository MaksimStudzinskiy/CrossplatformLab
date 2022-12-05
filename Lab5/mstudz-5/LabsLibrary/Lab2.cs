namespace LabsLibrary
{
	public class Lab2
	{
		public Lab2(string firstInput, string secondInput)
		{
			_firstInput = firstInput;
			_secondInput = secondInput;
		}

		private readonly string _firstInput;
		private readonly string _secondInput;

		public string Run(string inputFile = "INPUT.TXT")
		{

			var str1 = _firstInput;
			var str2 = _secondInput;

			bool flag = Equal(str1, str2);

			if (flag == false) return "NO";
			else return "YES";
		}

		public static bool Equal(string A, string B)
		{
			bool answ = true;
			foreach (var v in B)
				if (!A.Contains(v))
				{
					answ = false;
					break;
				}

			return answ;
		}
	}
}
