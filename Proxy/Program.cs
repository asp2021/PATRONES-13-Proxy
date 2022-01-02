using System;

namespace Proxy
{

    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("El automovil esta siendo conducido");
        }
    }

    public class Driver
    {
        private int _age;
        private bool _hasLicence;

        public Driver(int age, bool hasLicence)
        {
            _age = age;
            _hasLicence = hasLicence;
        }

        internal bool CanDrive() => _age >= 18 && _hasLicence;
    }

    public class CarProxy : ICar
    {
        private Car _car = new Car();
        private Driver _driver;

        public CarProxy(Driver driver)
        {
            _driver = driver;
        }

        public void Drive()
        {
            if (_driver.CanDrive())
                _car.Drive();
            else
                Console.WriteLine("El conductor no puede conducir");
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PROXY" + "\n");
            Console.WriteLine("Otorgar un objeto que puede actuar como sustituto del objeto real" );
            Console.WriteLine("Se da donde el recurso que necesitamos consumir no se encuentra en el mismo servidor o en la misma red.");
            Console.WriteLine("Es usado para proteger el acceso al recurso que se necesita consumir." + '\n');

            ICar car = new CarProxy(new Driver(18, true));
            car.Drive();
            Console.ReadLine();
        }
    }
}
