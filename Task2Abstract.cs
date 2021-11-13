using System;
using A4.Task2Abstract;
using A4.Task2Interface;

namespace A4.Task2Abstract
{

	abstract class PassengerCarrier 
	{
		public abstract string CarryPassengers();
	}

	class Ship : PassengerCarrier
	{
		public double Displacement { get; }

		public Ship(double displacement)
		{
			Displacement = displacement;
		}

		public override string CarryPassengers()
		{
			return "This type of ship does not carry passengers.";
		}

		public override string ToString()
		{
			return $"A ship that displaces {Math.Round(Displacement,2)} tons of water";
		}
	}

	class CruiseShip : Ship
	{
		private int numPassengers;
		public CruiseShip(double displacement, int numPassengers) : base(displacement)
		{
			this.numPassengers = numPassengers;
		}

		public override string CarryPassengers()
		{
			return $"{base.ToString()} and is carrying {numPassengers} passengers on a Caribbean Cruise";
		}

		public override string ToString() => CarryPassengers();
	}

	class BigRig : PassengerCarrier
	{
		public int NumTires;

		public BigRig(int numTires)
		{
			NumTires = numTires;
		}
		public override string CarryPassengers()
		{
			return "This type of vehicle does not carry passengers.";
		}

		public override string ToString()
		{
			return $"A vehicle with {NumTires} tires";
		}
	}

	class TourBus : BigRig
	{
		private int numPassengers;
		public TourBus(int numTires, int numPassengers) : base(numTires)
		{
			this.numPassengers = numPassengers;
		}

		public override string CarryPassengers()
		{
			return $"{base.ToString()} and is carrying {numPassengers} passengers on a cross country tour.";
		}

		public override string ToString() => CarryPassengers();
	}
}

