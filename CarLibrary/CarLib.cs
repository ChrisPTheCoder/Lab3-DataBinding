using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace CarLibrary
{
    [Flags]
     public enum ACCESSORIES
    {
        None = 0,
        DVDPlayer = 1,
        SecurityClock = 2,
        GPS = 4,
        Camera = 8,
        Warmer = 16,
        BluetoothAccessories = 32
    }

    public class CarLib : INotifyPropertyChanged
    {
        static private int NUMBEROFCAR = 1;
        private int carID;
        private string carName;
        private double carSpeed;
        private bool used;
        private Color color;
        //ACCESSORIES accessory;
        private List<ACCESSORIES> accessory;// = new List<ACCESSORIES>();
        private static ObservableCollection<CarLib> cars = new ObservableCollection<CarLib>();

        public int CarID
        {
            get
            {
                return carID;
            }
            private set
            {
                carID = NUMBEROFCAR;
                Notify("CarID");
                NUMBEROFCAR++;
            }
        }
        public string CarName
        {
            get
            {
                return carName;
            }
            private set
            {
                carName = value;
                Notify("CarName");
            }
        }
        public double CarSpeed
        {
            get
            {
                return carSpeed;
            }
            private set
            {
                carSpeed = value;
                Notify("CarSpeed");
            }
        }
        public bool Used
        {
            get
            {
                return used;
            }
            private set
            {
                used = value;
                Notify("Used");
            }
        }
        public Color Color
        {
            get
            {
                return color;
            }
            private set
            {
                color = value;
                Notify("Color");
            }
        }
        public List<ACCESSORIES> Accessory
        {
            get
            {
                return accessory;
            }
            private set
            {
                accessory = value;
                Notify("Accessory");
            }
        }

        public static void CreateCar(string carName, double carSpeed, bool used, Color color,
           ACCESSORIES accessory)
        {
            CarLib car = new CarLib
            {
                CarID = NUMBEROFCAR,
                CarName = carName,
                CarSpeed = carSpeed,
                Used = used,
                Color = color
            };
            car.Accessory.Add(accessory);
            cars.Add(car);
            NUMBEROFCAR++;
        }

        public static ObservableCollection<CarLib> GetListOfCars()
        {
            return cars;
        }
        public static CarLib GetCarInfo(int carID)
        {
            foreach (CarLib car in cars)
            {
                //for (int i = 0; i < cars.Count; i++)
                //{
                if (car.carID == carID)
                {
                    return car;
                }
                //}                 
            }
            throw new Exception("Car is not found");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public static void CreateSampleCars()
        {
            CarLib.CreateCar("Honda", 400, true, Color.Aquamarine, ACCESSORIES.Camera);
            CarLib.CreateCar("Nissan", 400, true, Color.Aquamarine, ACCESSORIES.Camera);
            CarLib.CreateCar("Mazda", 400, true, Color.Aquamarine, ACCESSORIES.GPS | ACCESSORIES.DVDPlayer);
            CarLib.CreateCar("Ford", 400, true, Color.Aquamarine, ACCESSORIES.Camera | ACCESSORIES.SecurityClock);
            CarLib.CreateCar("Nissan", 400, true, Color.Aquamarine, ACCESSORIES.None);
            CarLib.CreateCar("Honda", 400, true, Color.Aquamarine, ACCESSORIES.Warmer);
        }
    }
}