using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        Queue<Vehicle> vehiclesQueue = new Queue<Vehicle>();
        vehiclesQueue.Enqueue(new Vehicle("M1", "BMW"));
        vehiclesQueue.Enqueue(new Vehicle("Bike", "Halayoulya"));
        vehiclesQueue.Enqueue(new Vehicle("Destroyer", "Jeap"));
        vehiclesQueue.Enqueue(new Vehicle("LandCruser", "Coupee"));

        VehiclesTraffic vehicles = new VehiclesTraffic(vehiclesQueue);
        vehicles.Simulation();
    }

    public class VehiclesTraffic
    {
        private Queue<Vehicle> _vehicles;
        public VehiclesTraffic(Queue<Vehicle> vehicles)
        {
            _vehicles = vehicles;
        }

        public void Simulation()
        {
            while (_vehicles.Count > 0)
            {
                Console.WriteLine($"\n[SIGNAL GREEN] {_vehicles.Dequeue()} has passed the signal.");
                
                if (_vehicles.Count > 0)
                {
                    Console.WriteLine("Vehicles waiting: " + string.Join(", ", _vehicles));
                    
                    Console.Write("Next vehicle approaching..."); 
                    Thread.Sleep(1500); 
                }
                else
                {
                    Console.WriteLine("No vehicles waiting. Traffic is clear.");
                }
            }
        }
    }

    public class Vehicle
    {
        private string _name;
        private string _model;
        public Vehicle(string Name, string Model)
        {
            _name = Name;
            _model = Model;
        }

        public override string ToString()
        {
            return $"{_model} {_name}";
        }
    }
}