using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    internal class Flight
    {
        public enum FlightState         // pat STATE
        {
            THE_PLANE_IS_ON_THE_RUNWAY,
            THE_PLANE_TOOK_OFF,
            THE_PLANE_HAS_ARRIVED
        }
        public FlightState State { get; set; }
        public Flight(FlightState ws) => State = ws;

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


        

        public void Go()
        {
            if (State == FlightState.THE_PLANE_IS_ON_THE_RUNWAY)
            {
                Console.WriteLine("Началась загрузка книга в подписку");
                State = FlightState.THE_PLANE_TOOK_OFF;
            }
            else if (State == FlightState.THE_PLANE_TOOK_OFF)
            {
                Console.WriteLine("Книга добавлена");
                State = FlightState.THE_PLANE_HAS_ARRIVED;
            }
            else if (State == FlightState.THE_PLANE_HAS_ARRIVED)
            {
                Console.WriteLine("Можете чиатть");
            }
        }
        public void Stop()
        {
            if (State == FlightState.THE_PLANE_TOOK_OFF)
            {
                Console.WriteLine("Подписка закончиась");
                State = FlightState.THE_PLANE_IS_ON_THE_RUNWAY;
            }
            else if (State == FlightState.THE_PLANE_HAS_ARRIVED)
            {
                Console.WriteLine("Нельзя читать ");
                State = FlightState.THE_PLANE_TOOK_OFF;
            }
        }
    }
}
