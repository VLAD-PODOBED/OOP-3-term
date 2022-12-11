using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    internal class Flight
    {
		public string FlightName; // where + wherefrom
		private string Where;
		private string WhereFrom;
		private DateTime DepartureTime;
        public Brigade brigade = new Brigade();
		
		public string PropWhere
		{
			get { return Where; }
			set { Where = value; }
		}
		public string PropWhereFrom
		{
			get { return WhereFrom; }
			set { WhereFrom = value; }
		}
		public DateTime PropDepartureTime
        {
			get { return DepartureTime; }
			set { DepartureTime = value; }
		}
		public Flight(string WhereFrom, string Where, DateTime DepartureTime)
		{
			PropWhere = Where;
			PropWhereFrom = WhereFrom;
			PropDepartureTime = DepartureTime;
			FlightName = $"{WhereFrom}-{Where}";
		}
	}
}
