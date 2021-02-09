using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework.Internal.Execution;
using Codecool.LifeOfAnts.Ants;
using Codecool.LifeOfAnts.Utilities;
using System.Collections.Generic;

namespace Codecool.LifeOfAnts
{
    //using System.ComponentModel.DataAnnotations;
    //using Codecool.LifeOfAnts.Ants;

    /// <summary>
    /// Colony
    /// </summary>
    [SuppressMessage("ReSharper", "SA1101")]
    public class Colony
    {
        public int Width { get; }
        private List<Ant> _listOfAnts;
        private char[,] _arena;
        public Queen QueenAnt { get; }
        public EventHandler OnMove;
        private Random _random;
        public string Msg { get; set; }

        public Colony(int width)
        {
            _listOfAnts = new List<Ant>();
            
            _random = new Random();

            Width = width;
            
            CreateArena();

            int x = (int)Math.Round((double)((Width + 2) / 2));
            QueenAnt = new Queen(new Position(x, x), Direction.East, this);
        }

        public bool IsValidPosition(Position position)
        {
            Position topLeft = new Position(1, 1);
            Position topRight = new Position(Width, Width);

            return position.X >= topLeft.X && position.X <= topRight.X && position.Y >= topLeft.Y &&
                   position.Y <= topRight.Y;
        }

        private void CreateArena()
        {
            
            _arena = new char[Width + 2, Width + 2];
            
            for (int x = 0; x < (Width + 2); x++)
            {
                for (int y = 0; y < (Width + 2); y++)
                {
                    if (x == 0 || x == Width + 1 || y == 0 || y == Width + 1)
                    {
                        _arena[x, y] = '#';
                    }
                    else
                        _arena[x, y] = ' ';
                }
            }
        }

        public void ArenaModifyPosition(Position position, char value)
        {
            _arena[position.X, position.Y] = value;
        }

        private List<Ant> GenrateAntsByType<T>(int antQuantity)
            where T : Ant
        {
            List<Ant> ants = new List<Ant>();
            Position position;

            position = typeof(T) == typeof(Soldier) ? GetValidPosition("soldier") : GetValidPosition();

            for (int i = 0; i < antQuantity; i++)
            {
                var parameters = new object[3] {position, Direction.East, this};
                var ant = Activator.CreateInstance(typeof(T), parameters) as T;
                ants.Add(ant);
            }

            return ants;
        }

        private Direction RandomDirection()
        {
            return (Direction)(byte)_random.Next(0, 4);
        }

        public void GenerateAnts(int workersQuantity, int soldiersQuantity, int droneQuantity)
        {
            _listOfAnts.AddRange(GenrateAntsByType<Worker>(workersQuantity));
            _listOfAnts.AddRange(GenrateAntsByType<Soldier>(soldiersQuantity));
            _listOfAnts.AddRange(GenrateAntsByType<Drone>(droneQuantity));
        }

        public void GenerateAnts_tmp(int workersQuantity, int soldiersQuantity, int droneQuantity)
        {
            for (int i = 0; i < workersQuantity; i++)
            {
                Position position = GetValidPosition();

                Worker worker = new Worker(position, Direction.East, this);

                _listOfAnts.Add(worker);
            }
            
            for (int i = 0; i < soldiersQuantity; i++)
            {
                _listOfAnts.Add(new Soldier(GetValidPosition("soldier"), Direction.East, this));
            }
            
            for (int i = 0; i < droneQuantity; i++)
            {
                _listOfAnts.Add(new Drone(GetValidPosition(), Direction.East, this));
            }
        }

        public Position GetValidPosition(string antType=null)
        {
            int x = 0;
            int y = 0;
            
            if (antType == "soldier")
            { 
                x = _random.Next(2, Width);
                y = _random.Next(2, Width);
            }
            else
            {
                x = _random.Next(1, Width + 1);
                y = _random.Next(1, Width + 1);
            }

            return new Position(x, y);
        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            OnMove?.Invoke(this, EventArgs.Empty);
            ArenaModifyPosition(QueenAnt.Position, 'Q');
            Display();
            Console.WriteLine($"Queen's mood: {QueenAnt.Mood.ToString()}");
            Console.WriteLine(Msg);
            Msg = "";
        }

        /// <summary>
        /// DisplayAttribute
        /// </summary>
        public void DisplayAttribute()
        {
            
        }

        public void Display()
        {
            Console.Clear();
            
            for (int y = 0; y < _arena.GetLength(1); y++)
            {
                for (int x = 0; x < _arena.GetLength(0); x++)
                {
                    Console.Write(_arena[x, y]);
                }
                
                Console.Write("\n");
            }
        }
    }
}