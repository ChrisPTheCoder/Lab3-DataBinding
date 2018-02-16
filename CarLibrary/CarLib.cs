using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace CarLibrary
{
    class CarLib : INotifyPropertyChanged
    {
        [Flags]
        enum ACCESSORIES
        {
            DVDPlayer = 1,
            SecurityClock = 2,
            GPS = 4,
            Camera = 8,
            Warmer = 16,
            BluetoothAccessories = 32,
        }


        static int NUMBEROFCAR = 1;
        int carID;
        string carName;
        double carSpeed;
        bool used;
        //Color carColor = new Color();
        List<ACCESSORIES> accessory = new List<ACCESSORIES> { };


        public event PropertyChangedEventHandler PropertyChanged;

        protected int CarID
        {
            get
            {
                return carID;
            }
            set
            {
                carID = NUMBEROFCAR;
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
            }
        }
        List<ACCESSORIES> Accessory
        {
            get
            {
                return accessory;
            }
            set
            {
                accessory.Add(Enum.Parse(typeof(ACCESSORIES), value));
            }
        }
    }
}