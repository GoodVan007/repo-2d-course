using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    public class Hotel
    {
        public WindowSide Side; // ориентация окон
        public string NumberOfBeds; // Количество кроватей
        public readonly string HotelRoom; // Номер (только для чтения)
        public string DayPrise; // Цена за сутки
        public readonly DateTime Date; // дата и время освобождения номера

        public Hotel(WindowSide side, string numberOfBeds, string hotelRoom, string prise)
        {
            Side = side;
            NumberOfBeds = numberOfBeds;
            HotelRoom = hotelRoom;
            DayPrise = prise;
        }
        public int TimeOfRelease
        {
            get
            {
                return DateTime.Now.Day + Date.Day;
            }
        }

        public override string ToString()
        {
            return $"{HotelRoom}, {NumberOfBeds}, {DayPrise}";
        }
        public void PrintInfo()
        {
            Console.WriteLine(this);

            var side = "";
            switch (Side)
            {
                case WindowSide.North:
                    side = "Север";
                    break;
                case WindowSide.South:
                    side = "Юг";
                    break;
                case WindowSide.West:
                    side = "Запад";
                    break;
                case WindowSide.East:
                    side = "Восток";
                    break;
            }
            Console.WriteLine($"Номер: {HotelRoom}. " +
                $"\nЧисло кроватей: {NumberOfBeds}. " +
                $"\nОриентация Окон: {Side}. " +
                $"\nЦена за сутки: {DayPrise}.");

        }
        
    }
}
