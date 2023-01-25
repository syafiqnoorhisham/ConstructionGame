using System;
using System.Collections.Generic;

namespace ConstructionGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var myHouse = new Building()
            .AddKitchen()
            .AddBedroom("master")
            .AddBedroom("guest")
            .AddBalcony();

            var normalHouse = myHouse.Build();

            //kitchen, master room, guest room, balcony
            Console.WriteLine(normalHouse.Describe());

            myHouse.AddKitchen().AddBedroom("another");

            var luxuryHouse = myHouse.Build();

            //it only shows the kitchen after build
            //kitchen, master room, guest room, balcony, kitchen, another room
            Console.WriteLine(luxuryHouse.Describe());
            Console.WriteLine("press any key to close this window ...");
            Console.ReadKey();

        }

        class Building
        {
            private List<string> _rooms = new List<string>();

            public Building AddKitchen()
            {
                _rooms.Add("kitchen");
                return this;
            }

            public Building AddBedroom(string roomType)
            {
                _rooms.Add($"{roomType} room");
                return this;
            }

            public Building AddBalcony()
            {
                _rooms.Add("balcony");
                return this;
            }

            public Building AddBathroom()
            {
                _rooms.Add("bathroom");
                return this;
            }

            public House Build()
            {
                return new House(_rooms);
            }
        }

        class House
        {
            private List<string> _rooms;
            public House(List<string> rooms)
            {
                _rooms = rooms;
            }

            public string Describe()
            {
                return string.Join(", ", _rooms);
            }
        }
    }


}

