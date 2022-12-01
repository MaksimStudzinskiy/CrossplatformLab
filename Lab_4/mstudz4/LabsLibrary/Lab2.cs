namespace LabsLibrary
{
	public static class Lab2
	{
		public static string Run(string inputFile = "INPUT.TXT")
		{
			string str1 = "", str2 = "";

			using (StreamReader reader = new StreamReader(inputFile))
			{
				int linecount = 0;

				string line;
				while ((line = reader.ReadLine()) != null)
				{
					if (linecount == 0)
					{
						str1 = line;
					}
					else
					{
						str2 = line;
					}

					linecount++;
				}
			}

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
