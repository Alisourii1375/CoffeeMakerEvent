
using CoffeeMaker.Models;

namespace CoffeeMaker
{
    public class Vending
    {
        private double _coffcapacity;
        public readonly long CaffeenPercentage;
        public const long WaterHardLevel=98;
        public delegate bool SelfClean();
        public event SelfClean SelfCleanEvent;
        public delegate bool WaterEvent();
        public event WaterEvent WaterEmptingEvent;
        public delegate bool CofeeEvent();
        public event CofeeEvent CofeeEmptiEvent;





        public void CleanDevice_SystemFire()
        {

             SelfCleanEvent.Invoke();
           
        }

        private  bool   CleanDevice()
        {
            Console.WriteLine("Device Cleaned");
            return true;
        }

        public void WaterEmpti_Reaset()
        {

            WaterEmptingEvent.Invoke();

        }

        private bool WaterEmpti()
        {
            Console.WriteLine("WaterContinerEmpti");
            return true;
        }

        public void CofeeEmpti_Reaset()
        {

            CofeeEmptiEvent.Invoke();
        
        }
        private static bool CofeeEmpti()
        {

            Console.WriteLine("CofeecontinerEmpri");
            return true;
        }






        public delegate void NotifyUse(string message);
        public double CoffeeCapacity
        {
            get { return _coffcapacity; }
            set { if (value < 0) _coffcapacity = 0; else _coffcapacity = value; }
        }



        private double _watercapacity;

        public double WaterCapcity
        {
            get { return _watercapacity; }
            set { if (value < 0) _watercapacity = 0; else _watercapacity = value; }
        }

        //Display  Level Of Coffee And Water
        public double WaterLevel => WaterCapcity;
        public double CoffeeLevel => CoffeeCapacity;

        public Func<bool> CofeeEmptingEvent { get; }

        public Vending(double coffeeInserted, double waterInserted,long coffeenPercentage)
        {
            CoffeeCapacity = coffeeInserted;
            WaterCapcity = waterInserted;
            CaffeenPercentage = coffeenPercentage;
            SelfCleanEvent += CleanDevice;
            WaterEmptingEvent += WaterEmpti;
            CofeeEmptingEvent += CofeeEmpti;
            








         ////   Timer timer = new Timer(CleanDevice_SystemFire,3000,3000,1)

        }

        public int coffeeNumber;
        public static int NumberOfDevice;

        //public static Vending CreatObject(double coffeeInserted, double waterInserted)
        //{
        //    try
        //    {
        //        NumberOfDevice++;
        //        if (NumberOfDevice <= 3)
        //        {
        //            return new Vending(coffeeInserted, waterInserted);
        //        }

        //        else
        //        {
        //            throw new Exception("Max Obj is 3");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }

        //}

        /// <summary>
        /// Fill Vending  Capacity
        /// </summary>
        /// 



        public Coffee MakeEspersso()
        {

            try
            {

                var result = CheckResource();
                if (result == true)
                {
                    BoilWater();
                    CoffeeGrind();
                    BrewCoffee();

                    CoffeeCapacity = CoffeeCapacity - 20;
                    WaterCapcity = WaterCapcity - 50;
                    coffeeNumber++;
                    SendMessage("Your Coffeee  Is Ready", SendSms);
                    return new Coffee();


                }


                else
                {
                    return null;
                }

                /// CheckForZeroValue();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private static void CoffeeGrind()
        {
            CoffeeGrind();
        }

        public void SendMessage(string  message, NotifyUse notify)
        {
            notify(message);

        }
       public  void  SendSms(string message)
        {

            Console.WriteLine("This  Mesasage  send By Sms:"+  message);
        }

        public void SendEmail(string message)
        {

            Console.WriteLine(" this message send  by email"+ message);
        }

        //public enum GrindSize
        //{
        //   Small,medium,larg
        //}

          


        private bool CheckResource()
        {

            bool result = false;
            if (WaterLevel <= 0)
            {

                throw new Exception("WaterLevel  Finshed!");

            }
            if (CoffeeLevel <= 0)
            {

                throw new Exception("Coffee  Finshed!");

            }
            else
            {
                result = true;
            }

            return result;

        }

        private Coffee BrewCoffee()
        {
            return null;
            Console.WriteLine("BrewCoffee");
        }

        public enum CoffeeSize
        {
            Small,
            Medium,
            Large
        }
      // mishe soeech am zd mn zdm khata dashtm ostad!!!!!!!!!!!!
        public class CoffeeGrinder
        {
            public void CoffeGrind(CoffeeSize size)
            {
                if (size == CoffeeSize.Small)
                {
                    Console.WriteLine("smallasiab...");
                    // کوچگ
                }
                else if (size == CoffeeSize.Medium)
                {
                    Console.WriteLine("meduomasiab...");
                    // متوسط
                }
                else if (size == CoffeeSize.Large)
                {
                    Console.WriteLine("larjasiab...");
                    // بزرگ
                }
                else
                {
                    Console.WriteLine("nsmoshakhas");
                }
            }
        }

        private Water BoilWater()
        {
            return null;
            Console.WriteLine("BoilWater");
        }



        //private void   Payment()
        //{

        //}
    }
}
