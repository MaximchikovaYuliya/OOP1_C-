using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace LR_5_6_7
{
    interface IDescriptive
    {
        int Speed { get; set; }
        int Shipload { get; set; }
        int NumberOfSeats { get; set; }
        int Displacement { get; set; }
        string Name { get; set; }
    }

    [DataContract]
    [Serializable]
    public sealed partial class Captain: IComparable<Captain>                                                            //бесплодный класс
    {
        [DataMember]
        private int age;
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18 || value > 65) 
                {
                    throw new CaptainAgeException("Invalid captain's age.");
                }
                else
                {
                    age = value;
                }
            }
        }

        public Captain() { }

        public Captain(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString() => Name + " " + Age;

        public int CompareTo(Captain obj)
        {
            if (Age > obj.Age)
                return 1;
            if (Age < obj.Age)
                return -1;
            else
                return 0;
        }

    }

    public abstract class Vehicle: IDescriptive
    {
        private int speed;
        public Captain captain;
        public int Speed
        {
            get { return speed; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid speed.");
                }
                else
                {
                    speed = value;
                }
            }
        }
        public int Shipload { get; set; }
        public int NumberOfSeats { get; set; }
        public int Displacement { get; set; }
        public string Name { get; set; }
        public abstract void Swim();

        public Vehicle(string name, int speed, int shipload, int numberOfPassengers, int displacement, Captain captain)
        {
            Name = name;
            Speed = speed;
            Shipload = shipload;
            NumberOfSeats = numberOfPassengers;
            Displacement = displacement;
            this.captain = captain;
        }
    }

    public class Ship : Vehicle
    {
        public Ship(string name, int speed, int shipload, int numberOfPassengers, int displacement, Captain captain) : base(name, speed, shipload, numberOfPassengers, displacement, captain) { }
        public override void Swim()
        {
            Console.WriteLine("Ship is swimming.");
        }
        public override string ToString() => "Ship-> name: " + Name + ", speed: " + Speed + " ,shipload: " + Shipload + " , number of passengers: " + NumberOfSeats + ", captain: " + captain;
    }

    public class Steamship : Vehicle
    {
        public Steamship(string name, int speed, int shipload, int numberOfPassengers, int displacement, Captain captain) : base(name, speed, shipload, numberOfPassengers, displacement, captain) { }
        public override void Swim()
        {
            Console.WriteLine("Steamship is swimming.");
        }
        public override string ToString() => "Steamship-> name: " + Name + ", speed: " + Speed + " ,shipload: " + Shipload + " , number of passengers: " + NumberOfSeats + ", captain: " + captain;
    }

    public class Sailboat : Vehicle
    {
        public Sailboat(string name, int speed, int shipload, int numberOfPassengers, int displacement, Captain captain) : base(name, speed, shipload, numberOfPassengers, displacement, captain) { }
        public override void Swim()
        {
            Console.WriteLine("Sailboat is swimming.");
        }
        public override string ToString() => "Sailboat-> name: " + Name + ", speed: " + Speed + " ,shipload: " + Shipload + " , number of passengers: " + NumberOfSeats + ", captain: " + captain;
    }

    public class Corvette : Vehicle
    {
        public Corvette(string name, int speed, int shipload, int numberOfPassengers, int displacement, Captain captain) : base(name, speed, shipload, numberOfPassengers, displacement, captain) { }
        public override void Swim()
        {
            Console.WriteLine("Corvette is swimming.");
        }
        public override string ToString() => "Corvette-> name: " + Name + ", speed: " + Speed + " ,shipload: " + Shipload + " , number of passengers: " + NumberOfSeats + ", captain: " + captain;
    }

    public class Boat : Vehicle
    {
        public Boat(string name, int speed, int shipload, int numberOfPassengers, int displacement, Captain captain) : base(name, speed, shipload, numberOfPassengers, displacement, captain) { }
        public override void Swim()
        {
            Console.WriteLine("Boat is swimming.");
        }
        public override string ToString() => "Boat-> name: " + Name + ", speed: " + Speed + " ,shipload: " + Shipload + " , number of passengers: " + NumberOfSeats + ", captain: " + captain;
    }

    public class Printer
    {
        public virtual string IAmPrinting(Vehicle obj)
        {
            Debug.Assert(obj != null, "Object is null");                                            //Assert
            return obj.GetType() + " " + obj.ToString();   
        }
    }

    partial class PartialClass
    {
        enum Days { Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    }

    public class PortContainer                                                                      //класс-контейнер                                                       
    {
        public string Name { get; set; }
        public List<Vehicle> allVehicles = new List<Vehicle>();

        public PortContainer(string name)
        {
            Name = name;
        }

        public void Add(params Vehicle[] vehicles)
        {
            allVehicles.AddRange(vehicles);
        }

        public void Delete(Vehicle vehicle)
        {
            if (!allVehicles.Contains(vehicle))
                throw new DeleteVehicleException("List doesn't contain deleted object.");
            allVehicles.Remove(vehicle);
        }

        public void Display()
        {
            if (allVehicles.Count == 0) 
                throw new EmptyPortException("Empty port.");
            Console.WriteLine("\n---------------------------" + this.Name + "---------------------------");
            foreach (var x in allVehicles)
                Console.WriteLine(x);
            Console.WriteLine();
        }
    }

    public class PortController                                                                //класс-контроллер
    {
        private PortContainer port;

        public PortController() { }

        public PortController(PortContainer port)
        {
            this.port = port;
        }

        public float GetAverageDisplacementOfSailboats()
        {
            int sum = 0;
            int count = 0;
            foreach(var x in port.allVehicles)
            {
                if (x is Sailboat)
                {
                    sum += x.Displacement;
                    count++;
                }
            }
            if (count == 0)
                throw new DivideByZeroException("Attempt to divide by zero.");
            return (float)sum / count;
        }

        public int GetAverageNumberOfSeatsOnSteamships()
        {
            int sum = 0;
            int count = 0;
            foreach (var x in port.allVehicles)
            {
                if (x is Steamship)
                {
                    sum += x.NumberOfSeats;
                    count++;
                }
            }
            if (count == 0)
                throw new DivideByZeroException();
            return sum / count;
        }

        public List<Vehicle> GetVehicles(int captainAge)                                      //все транспортные средства на которых плавают капитаны моложе 35 лет
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            foreach (var x in port.allVehicles)
            {
                if (x.captain.Age < captainAge)
                {
                    vehicles.Add(x);
                }
            }
            return vehicles;
        }
    }

    public class CaptainAgeException : ApplicationException
    {
        public CaptainAgeException(string message) : base(message) { }
    }

    public class DeleteVehicleException : ApplicationException
    {
        public DeleteVehicleException(string message) : base(message) { }
    }

    public class EmptyPortException : ApplicationException
    {
        public EmptyPortException(string message) : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Captain john = new Captain("John", 28);
                Captain jack = new Captain("Jack", 30);
                Captain travis = new Captain("Travis", 40);
                Captain sam = new Captain("Sam", 23);
                Captain george = new Captain("George", 28);
                //Captain tom = new Captain("Tom", 10);
                Ship avrora = new Ship("Avrora", 40, 100, 500, 25000, john);                //объект класса
                Sailboat marianna = new Sailboat("Marianna", 60, 150, 80, 20000, jack);
                Steamship ghost = new Steamship("Ghost", 50, 190, 50, 5000, travis);
                Corvette claymore = new Corvette("Claymore", 60, 70, 100, 2500, sam);
                Sailboat anna = new Sailboat("Anna", 50, 170, 70, 30000, jack);
                Steamship otto = new Steamship("Otto", 60, 160, 80, 8000, travis);
                Boat sword = new Boat("Sword", 90, 50, 6, 1000, george);
                //Boat rose = new Boat("Sword", -90, 80, 4, 2000, george);
                Printer printer = new Printer();
                IDescriptive obj = avrora;                                                  //ссылка типа интерфейс на объект класса (не доступны методы, объявленные в классе)
                Object obj1 = sword;
                Vehicle obj2 = claymore as Vehicle;                                         //LR_5.Vehicle {LR_5.Corvette}
                Captain obj3 = obj1 as Captain;                                             //null (приведение не удалось)
                var vehicles = new { obj, obj1, obj2, obj3 };
                Console.WriteLine("Number of seats of Avrora -> " + obj.NumberOfSeats);
                avrora.Swim();
                bool checkObj = obj is Ship;                                                //true
                bool checkObj1 = obj1 is Captain;                                           //false
                Vehicle emptyObj = null;
                //printer.IAmPrinting(emptyObj);
                Console.WriteLine(printer.IAmPrinting(avrora));
                Console.WriteLine(printer.IAmPrinting(marianna));
                Console.WriteLine(printer.IAmPrinting(ghost));
                Console.WriteLine(printer.IAmPrinting(claymore));
                Console.WriteLine(printer.IAmPrinting(sword));
                PortContainer auckland = new PortContainer("Auckland");
                PortContainer busan = new PortContainer("Busan");
                PortContainer vancouver = new PortContainer("Vancouver");
                PortController busanController = new PortController(busan);
                PortController aucklandController = new PortController(auckland);
                busan.Add(avrora);
                //busanController.GetAverageDisplacementOfSailboats();
                //vancouver.Display();
                auckland.Add(avrora, marianna, ghost);
                auckland.Delete(avrora);
                //auckland.Delete(avrora);
                auckland.Add(claymore, sword, otto, anna);
                auckland.Display();
                Console.WriteLine($"Average displacement of sailboats in Auckland -> {aucklandController.GetAverageDisplacementOfSailboats()}");
                Console.WriteLine($"Average number of seats on steamships in Auckland -> {aucklandController.GetAverageNumberOfSeatsOnSteamships()}");
                List<Vehicle> specialVehicles = aucklandController.GetVehicles(35);
                Console.WriteLine($"All vehicles driven by captains younger than 35 years in Auckland -> {specialVehicles.ListToString()}");            
            }
            catch(CaptainAgeException ex)
            {
                Console.WriteLine($"Error: " + ex.Message + " Method that caused error: " + ex.TargetSite);
            }
            catch(DeleteVehicleException ex)
            {
                Console.WriteLine($"Error: " + ex.Message + " Method that caused error: " + ex.TargetSite);
            }
            catch (EmptyPortException ex)
            {
                Console.WriteLine($"Error: " + ex.Message + " Method that caused error: " + ex.TargetSite);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: " + ex.Message + " Method that caused error: " + ex.TargetSite);
            }

            catch(ArgumentException ex)
            {
                Console.WriteLine($"Error: " + ex.Message + " Method that caused error: " + ex.TargetSite);
            }

            catch
            {
                Console.WriteLine("Error.");
            }

            finally
            {
                Console.ReadKey();
            }
        }
    }
}
