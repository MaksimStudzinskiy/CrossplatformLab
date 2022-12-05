using System.Linq;

namespace LabsLibrary
{
	public class Lab1
	{
		public Lab1(string firstLine, string secondLine, string thirdLine, string fourthLine, string fifthLine)
		{
			_firstLine = firstLine;
			_secondLine = secondLine;
			_thirdLine = thirdLine;
			_fourthLine = fourthLine;
			_fifthLine = fifthLine;
		}

		private readonly string _firstLine;
		private readonly string _secondLine;
		private readonly string _thirdLine;
		private readonly string _fourthLine;
		private readonly string _fifthLine;

		public string Run(string inputFile = "INPUT.TXT")
		{
			int final_result = 0;
			string[] Line_1 = _firstLine.Split(' ');

			int N = int.Parse(Line_1[0]);
			int M = int.Parse(Line_1[1]);

			if (N < 1 || N > 109 || M < 1 || M > 109)
			{
				return "Incorrect input data";
			}

			int holes_1 = int.Parse(_secondLine);
			if (holes_1 == 0)
			{
				return "0";
			}

			int holes_2 = int.Parse(_fourthLine);
			if (holes_2 == 0)
			{
				return "0";
			}

			bool[,] coordinates_1 = new bool[M, N];
			bool[,] coordinates_2 = new bool[M, N];
			string[] holesPos_1 = _thirdLine.Split(';', System.StringSplitOptions.RemoveEmptyEntries).Select(row => row.Trim()).ToArray();
			string[] holesPos_2 = _fifthLine.Split(';', System.StringSplitOptions.RemoveEmptyEntries).Select(row => row.Trim()).ToArray();

			foreach (string holePos in holesPos_1)
			{
				for (int y = int.Parse(holePos.Split(' ')[1]); y <= int.Parse(holePos.Split(' ')[3]); y++)
				{
					for (int x = int.Parse(holePos.Split(' ')[0]); x <= int.Parse(holePos.Split(' ')[2]); x++)
					{
						coordinates_1[y, x] = true;
					}
				}
			}

			foreach (string holePos in holesPos_2)
			{
				for (int y = int.Parse(holePos.Split(' ')[1]); y <= int.Parse(holePos.Split(' ')[3]); y++)
				{
					for (int x = int.Parse(holePos.Split(' ')[0]); x <= int.Parse(holePos.Split(' ')[2]); x++)
					{
						coordinates_2[y, x] = true;
					}
				}
			}

			int result_1 = 0;
			foreach (string holePos in holesPos_1)
			{
				bool isHole = false;
				for (int y = int.Parse(holePos.Split(' ')[1]); y <= int.Parse(holePos.Split(' ')[3]); y++)
				{
					for (int x = int.Parse(holePos.Split(' ')[0]); x <= int.Parse(holePos.Split(' ')[2]); x++)
					{
						if (coordinates_2[y, x] == true)
						{
							isHole = true;
						}
					}
				}
				if (isHole)
				{
					result_1++;
				}
			}

			int result_2 = 0;
			foreach (string holePos in holesPos_2)
			{
				bool isHole = false;
				for (int y = int.Parse(holePos.Split(' ')[1]); y <= int.Parse(holePos.Split(' ')[3]); y++)
				{
					for (int x = int.Parse(holePos.Split(' ')[0]); x <= int.Parse(holePos.Split(' ')[2]); x++)
					{
						if (coordinates_1[y, x] == true)
						{
							isHole = true;
						}
					}
				}

				if (isHole)
				{
					result_2++;
				}
			}

			if (result_1 > result_2)
			{
				final_result = result_1;
			}
			else
			{
				final_result = result_2;
			}

			return final_result.ToString();
		}
	}
}
