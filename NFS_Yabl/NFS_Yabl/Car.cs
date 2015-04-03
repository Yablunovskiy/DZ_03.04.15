using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFS_Yabl
{
    class Car
    {
        public string Model { get; set; }
        public int MaxSpeed { get; set; }
        public double Speed_Up { get; set; }
        public double Nitro { get; set; }
        public string TypeOfBrakes { get; set; }
        public string Transmission { get; set; }

        public Car()
        {
            Model = "";
            MaxSpeed = 0;
            Speed_Up = 0;
            Nitro = 0;
            TypeOfBrakes = "";
            Transmission = "";
        }

        public Car(string model, int maxspeed, double speed_up, double nitro, string typeofbrakes, string transmission)
        {
            Model= model;
            MaxSpeed = maxspeed;
            Speed_Up = speed_up;
            Nitro = nitro;
            TypeOfBrakes = typeofbrakes;
            Transmission = transmission;
        }

        public override string ToString()
        {
            return String.Format("\n\tМодель: {0}, Макс скорость {1}км.в час,  Ускорение 100м за {2}сек. \n\t Нитро {3}сек, Тип тормазов: {4}, Тип трансмиссии: {5}", Model, MaxSpeed, Speed_Up, Nitro, TypeOfBrakes, Transmission);
        }

        public static bool operator == (Car B, Car A)
        {
            if (A.MaxSpeed == B.MaxSpeed && A.Speed_Up == B.Speed_Up && A.Nitro == B.Nitro && A.TypeOfBrakes == B.TypeOfBrakes && A.Transmission == B.Transmission)
                return true;
            else
                return false;
        }

        public static bool operator !=(Car B, Car A)
        {
            if (A.MaxSpeed != B.MaxSpeed || A.Speed_Up != B.Speed_Up || A.Nitro != B.Nitro || A.TypeOfBrakes != B.TypeOfBrakes || A.Transmission != B.Transmission)
                return true;
            else
                return false;
        }

    }
}
