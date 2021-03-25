using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pluralsight.BegCShCollections.TopTenPops
{
	class CsvReader
	{
		private string _csvFilePath;

		public CsvReader(string csvFilePath)
		{
			this._csvFilePath = csvFilePath;
		}

		public Country[] ReadFirstNCountries(int nCountries)
        {
			Country[] countries = new Country[nCountries];
			return countries;
        }

		public Country ReadCountryFromCsvLine(string csvLine)
        {
			string[] parts = csvLine.Split(',');

			string name = parts[0];
			string code = parts[1];
			string region = parts[2];
			int population = int.Parse(parts[3]);

			return new Country(name, code, region, population);
        }

	}
}
