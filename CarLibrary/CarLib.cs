using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace CarLibrary
{
    [Flags]
     enum ACCESSORIES
    {
        None = 0,
        DVDPlayer = 1,
        SecurityClock = 2,
        GPS = 4,
        Camera = 8,
        Warmer = 16,
        BluetoothAccessories = 32
    }

    class CarLib : INotifyPropertyChanged
    {
        static int NUMBEROFCAR = 1;
        int carID;
        string carName;
        double carSpeed;
        bool used;
        Color color;
        //ACCESSORIES accessory;
        List<ACCESSORIES> accessory;// = new List<ACCESSORIES>();
        public ObservableCollection<CarLib> cars = CarLib.GetAllCars();

        protected int CarID
        {
            get
            {
                return carID;
            }
            set
            {
                carID = NUMBEROFCAR;
                Notify("CarID");
                NUMBEROFCAR++;
            }
        }
        protected string CarName
        {
            get
            {
                return carName;
            }
            set
            {
                carName = value;
                Notify("CarName");
            }
        }
        protected double CarSpeed
        {
            get
            {
                return carSpeed;
            }
            set
            {
                carSpeed = value;
                Notify("CarSpeed");
            }
        }
        protected bool Used
        {
            get
            {
                return used;
            }
            set
            {
                used = value;
                Notify("Used");
            }
        }
        protected Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                Notify("Color");
            }
        }
        protected List<ACCESSORIES> Accessory
        {
            get
            {
                return accessory;
            }
            set
            {
                accessory = value;
                Notify("Accessory");
            }
        }

        public CarLib(string carName, double carSpeed, bool used, Color color,
           ACCESSORIES accessory)
        {            
            this.CarID = NUMBEROFCAR;
            this.CarName = carName;
            this.CarSpeed = carSpeed;
            this.Used = used;
            this.Color = color;
            this.Accessory.Add(accessory);
            NUMBEROFCAR++;              
        }

        public static CarLib CreateCar(string carName, double carSpeed, bool used, Color color,
           ACCESSORIES accessory)
        {
            CarLib car = new CarLib(carName, carSpeed, used, color, accessory);   
            
            return car;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public static ObservableCollection<CarLib> GetAllCars()
        {
            ObservableCollection<CarLib> cars = new ObservableCollection<CarLib>();

            return cars;
        }
}