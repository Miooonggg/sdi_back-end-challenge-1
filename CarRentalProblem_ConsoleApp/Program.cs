using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Program will keep asking for input as long as it is true or correct
            while (true)
            {
                List<Car> cars = new List<Car>()
                {
                    new Car("Size S", 5, 5000),
                    new Car("Size M", 10, 8000),
                    new Car("Size L", 15, 12000)
                };

                Console.Write("Please input number (seats): ");

                if (!int.TryParse(Console.ReadLine(), out int seatsNeeded) || seatsNeeded <= 0)
                {
                    Console.WriteLine("Please provide a valid number.");
                    Console.Write("Do you want to try again? (Y/N): ");
                    string choice = Console.ReadLine();

                    if (choice.ToUpper() == "Y")
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Thank you!");
                        break;
                    }
                }

                foreach (Car car in cars)
                {
                    int howMany = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(seatsNeeded) / Convert.ToDouble(car.Seat)));
                    car.HowMany = howMany;
                    car.TotalCost = car.Cost * howMany;
                }

                var cheapestCar = cars.OrderBy(x => x.TotalCost).ThenBy(x => x.HowMany).First();

                if (cheapestCar != null)
                {
                    Console.WriteLine($"{cheapestCar.Name} x {cheapestCar.HowMany}");
                    Console.WriteLine($"Total = PHP {cheapestCar.TotalCost}");
                }
            }

        }
    }
    internal class Car
    {
        public Car(string name, int seat, int cost)
        {
            Name = name;
            Seat = seat;
            Cost = cost;
        }
        public string Name { get; set; }
        public int Seat { get; set; }
        public int Cost { get; set; }
        public int HowMany { get; set; }
        public int TotalCost { get; set; }

    }
}