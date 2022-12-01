namespace LabsLibrary
{
	public static class Lab3
	{
		public class graf
		{
			public string name { get; set; }

			public string n1
			{
				get { return name.Substring(0, 3); }
				set { }
			}
			public string n2
			{
				get { return name.Substring(3, 3); }
				set { }
			}
		}

		public static string Run(string inputFile = "INPUT.TXT")
		{
			List<graf> grafs = new List<graf>();

			using (StreamReader reader = new StreamReader(inputFile))
			{
				int linecount = 0;

				string line;
				while ((line = reader.ReadLine()) != null)
				{
					if (linecount == 0)
					{
						linecount++;
						continue;
					}
					else
					{
						grafs.Add(new graf { name = line });
					}
				}
			}

			var result = algoritm(grafs);
			return result;
		}

		public static string algoritm(List<graf> grafs)
		{
			int count = 0;

			for (int i = 0; i < grafs.Count - 1; i++)
			{
				for (int j = i + 1; j < grafs.Count; j++)
				{
					if (grafs[i].n2 == grafs[j].n1)
					{
						if (j == i + 1)
						{
							break;
						}
						else
						{
							graf tmp = grafs[i + 1];
							grafs[i + 1] = grafs[j];
							grafs[j] = tmp;

							break;
						}
					}
					else if (j == grafs.Count - 1)
					{
						count++;
					}
				}
			}

			if (grafs[grafs.Count - 1].n2 != grafs[0].n1)
			{
				count++;
			}

			return count.ToString();
		}
	}
}
