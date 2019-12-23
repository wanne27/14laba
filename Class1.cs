using System;
using System.Collections.Generic;
using System.Text;

namespace _14laba
{
      [Serializable]
      public class Description        
      {
        public string name;

        public int mass;

        public Description(string NAME,int MASS)
        {
            name = NAME;
            mass = MASS;
        }
        public Description()
        {

        }
            public string Cost(int cost)
            {

                return $"Стоимость {name} = {cost}";
            }

            public virtual string Lifetime(int life_time)
            {
                return $"Срок службы {name} = {life_time} лет";
            }

       


      }

          [Serializable]
        public class Mate : Description      //мат
        {
        public Mate(string NAME, int MASS, int LENGHT, int WIDTH, int AREA): base (NAME,MASS)
        {
            length = LENGHT;
            width = WIDTH;
            area = AREA;


        }
        public Mate()
        {

        }
            public int length { get; set; }  //длина

            public int width { get; set; }   //ширина

            public int area { get; set; }    //площадь

            public override string ToString()
            {

                Console.WriteLine("Данные об объекте : ");

                Console.WriteLine($"Название : {name}");

                Console.WriteLine($"Длина : {length}");

                Console.WriteLine($"Масса : {mass}");

                Console.WriteLine($"Ширина : {width}");

                Console.WriteLine($"Площадь : {area}");



                return $"{name} {length} {width} {mass} {area}";
            }
        }
    
}
