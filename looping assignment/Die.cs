using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class Die
    {
        private int _roll;
        private Random _generator;
        private ConsoleColor _color;

        // the die variable
        public Die()
        {
            _generator = new Random();
            _roll = _generator.Next(1, 7);
            _color = ConsoleColor.Gray;
        }

        // giv colour
        public Die(ConsoleColor color)
        {
            _generator = new Random();
            _roll = _generator.Next(1, 7);
            _color = color;

        }

        // roll get return roll
        public int Roll
        {
            get { return _roll; }
        }

        // color get return color set color value
        public ConsoleColor Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public override string ToString()
        {
            return _roll.ToString();
        }

        public void RollDie()
        {
            _roll = _generator.Next(1, 7);
        }

        public void DrawRoll()
        {
            Console.ForegroundColor = _color;

            if (_roll == 1)
                Console.WriteLine("-----\r\n|   |\r\n| o |\r\n|   |\r\n-----");
            else if (_roll == 2)
                Console.WriteLine("-----\r\n|o  |\r\n|   |\r\n|  o|\r\n-----");
            else if (_roll == 3)
                Console.WriteLine("-----\r\n|o  |\r\n| o |\r\n|  o|\r\n-----");
            else if (_roll == 4)
                Console.WriteLine("-----\r\n|o o|\r\n|   |\r\n|o o|\r\n-----");
            else if (_roll == 5)
                Console.WriteLine("-----\r\n|o o|\r\n| o |\r\n|o o|\r\n-----");
            else if (_roll == 6)
                Console.WriteLine("-----\r\n|o o|\r\n|o o|\r\n|o o|\r\n-----");
            else
                Console.WriteLine("-----\r\n|   |\r\n| ? |\r\n|   |\r\n-----");

                Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
