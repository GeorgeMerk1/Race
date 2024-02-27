using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp8
{
        public delegate void Finish(double a, double b, string c);
    public abstract class Avto
    {
    public double speed;
    public double location;
    public Random rnd;
    public double RndSpeed;
    public string Name;
    public double MaxSpeed;
    public int Distance;
    public int Time;
        
        public Avto()
        { 
        speed = 0.0;
        location = 0.0;
        rnd = new Random();
        RndSpeed = 0;
            Name = string.Empty;
            MaxSpeed = 0;
            Distance = 500;
            Time = 50;
        }

        public Avto(double MaxSpeed)
        {
           this.MaxSpeed = MaxSpeed;
        }

        public abstract void Go();

       
    }

    public class SportCar : Avto
    {
    public SportCar() 
    {
            RndSpeed = 10; 
            Name = "McQueen";
            MaxSpeed = 50.6;
    }
        public override void Go()
        {
            for (int i = 0; i < Time; i++)
            {
                if (speed > RndSpeed && speed > 0)
                {
                    speed += rnd.Next(-(int)RndSpeed, (int)RndSpeed);
                }
                else if (speed == 0 && speed == RndSpeed)
                {
                    speed = RndSpeed + 1;
                }
                location += speed;
            }
        }
        ///private GoStart finish;
        public event Finish FinishEvent;

        public void Finish(int Dictance, double Location, string Name)
        { 
        this.Name = Name;
        this.location = Location;
        this.Distance = Dictance;


        }

        public void GoStart(string Name)
        {
            this.Name = Name;
            Console.WriteLine($"{Name} готов к старту");

        }
    }
    //public class PassengerCar : Avto
    //{ 

    //}
    //public class HardCar : Avto
    //{ 

    //}
    //public class Bus : Avto
    //{ 

    //}

    delegate void TickD();
    internal class Program
    {
        static void Main(string[] args)
        {
            
        SportCar sportCar = new SportCar();
            TickD tickD = sportCar.Go;


            while (true)
            {
                tickD();


            }
        //GoStart goStartDelegate = sportCar.GoStart;
        //sportCar.StartEvent += goStartDelegate;
        }
    }
}
