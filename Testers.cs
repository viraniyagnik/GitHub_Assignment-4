using System;
using System.Collections.Generic;

namespace A4
{
	static class Task1Tester
	{
		private const int NUM_TEST_CARDS = 10;
		private static readonly Random rand = new Random(2718);
		public static void Test()
		{
			List<Card> cards = new List<Card>() { };
			for (int i = 0; i < NUM_TEST_CARDS; ++i)
			{
				cards.Add(RandomCard());
			}

			PrintCards(cards);
			try 
			{ 
				cards.Sort(new CardComparerByValue()); 
				Console.WriteLine("\n... Sorting Cards ...\n");
				PrintCards(cards);
			}
			catch (InvalidOperationException e)
			{
				Console.WriteLine("\n*** CardComparer is not implemented correctly ***\n"); 
			}
		}

		private static Card RandomCard()
		{
			return new Card((Values)rand.Next(13), (Suits)rand.Next(4));
		}

		private static void PrintCards(List<Card> cards)
		{
			foreach (var card in cards)
			{
				Console.WriteLine(card);
			}
		}
	}

	static class Task2Tester
	{
		private const int NUM_CARRIERS = 7;
		private const int MAX_DISPLACEMENT = 100000;
		private const int MAX_PASSENGERS = 100;
		private const int MAX_TIRES = 12;
		private const int MIN_TIRES = 4;
		private static readonly Random rand = new Random(3141592);
		
		public static void Test()
		{
			TestAbstract();
			Console.WriteLine();
			TestInterface();
		}

		private static void TestAbstract()
		{
			Console.WriteLine("\t\t***Output using an abstract class***");
			List<Task2Abstract.PassengerCarrier> carriers = new List<Task2Abstract.PassengerCarrier>() { };
			for (int i = 0; i < NUM_CARRIERS; ++i)
			{
				var passengers = rand.Next(MAX_PASSENGERS);
				if (rand.NextDouble() <= 0.5)
				{
					var displacement = rand.NextDouble() * MAX_DISPLACEMENT;
					carriers.Add(new Task2Abstract.CruiseShip(displacement, passengers));
				}
				else
				{
					var numTires = rand.Next(MIN_TIRES, MAX_TIRES);
					numTires = numTires % 2 == 0 ? numTires : numTires + 1;
					carriers.Add(new Task2Abstract.TourBus(numTires, passengers));
				}
			}
			PrintCarrier<Task2Abstract.PassengerCarrier>(carriers);
		}

		private static void TestInterface()
		{
			Console.WriteLine("\t\t***Output using an interface***");
			List<Task2Interface.ICarryPassengers> carriers = new List<Task2Interface.ICarryPassengers>() { };
			for (int i = 0; i < NUM_CARRIERS; ++i)
			{
				var passengers = rand.Next(MAX_PASSENGERS);
				if (rand.NextDouble() <= 0.5)
				{
					var displacement = rand.NextDouble() * MAX_DISPLACEMENT;
					carriers.Add(new Task2Interface.CruiseShip(displacement, passengers));
				}
				else
				{
					var numTires = rand.Next(MIN_TIRES, MAX_TIRES);
					numTires = numTires % 2 == 0 ? numTires : numTires + 1;
					carriers.Add(new Task2Interface.TourBus(numTires, passengers));
				}
			}
			PrintCarrier<Task2Interface.ICarryPassengers>(carriers);
		}

		private static void PrintCarrier<T>(List<T> carriers)
		{
			foreach (var carrier in carriers)
			{
				Console.WriteLine(carrier);
			}
		}
	}
}
