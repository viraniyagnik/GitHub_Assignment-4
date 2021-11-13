using System;
using A4.Task2Abstract;
// Make sure to uncomment the ToString methods when you are ready!

namespace A4.Task2Interface
{
	interface ICarryPassengers
	{
		 string CarryPassengers();
		
	}
	class Ship 
	{
	
		public double Displacement { get; }

		public Ship(double displacement)
		{
			Displacement = displacement;
		}


		public  string CarryPassengers()
		{
			return "This type of ship does not carry passengers.";
		}

		public override string ToString()
		{
			return $"A ship that displaces {Math.Round(Displacement, 2)} tons of water";
		}
	}

	class CruiseShip : Ship, ICarryPassengers
	{

		
		// it inherit from Ship as well as extend ICarryPassenger

		private int NumPassengers;

		public CruiseShip(double displacement, int numPassengers) : base(displacement)
		{
			NumPassengers = numPassengers;
		}

		public string CarryPassengers()
		{
			return $"{base.ToString()}   and is carrying {NumPassengers} passengers on a Caribbean Cruise";
		}
		public override string ToString() => CarryPassengers();
	}

	class BigRig
	{
		
		public int NumTires;

		public BigRig(int numTires)
		{
			NumTires = numTires;
		}
		public  string CarryPassengers()
		{
			return "This type of vehicle does not carry passengers.";
		}

		

		public override string ToString() => $"A vehicle with {NumTires} tires"; 
	}

	class TourBus : BigRig, ICarryPassengers
	{

		// it  inherit from BigRig as well as extend ICarryPassenger
		private int numPassengers;
		public TourBus(int numTires, int numPassengers) : base(numTires)
		{
			this.numPassengers = numPassengers;
		}

		public  string CarryPassengers()
		{
			return $"{base.ToString()} and is carrying {numPassengers} passengers on a cross country tour.";
		}
		public override string ToString() => CarryPassengers();
	}
}
