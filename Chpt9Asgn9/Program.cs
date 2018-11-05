using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Chpt9Asgn9
{


           /**
             *  Player battle simulator
             *  Keegan Johnson
             *  11-5-18
             *  CIS 129
             *  Chapter 9 Assignment 9
             *  This program is to simulate a battle between two computer players to see who will win.
             * 
             */




    /**
      * this class holds any info for a player object
      */
    class Player
    {
        
        public string name; // this variable is to hold any player names given to the player object spawned
        public int health; // this variable is to hold any player health given to the player object spawned
        private int maxHealth = 100; // this variable sets the max health at 100
        private int minHealth = 0; // this variable sets the min health at 0

        /**
          *  this method is to set up the base player class when a player instance is called
          */
        public Player()
        {
            if(health < minHealth) // if health is less than 0
            {
                health = minHealth; // set health to 0
            }
            else if(health > maxHealth) // if health is greater than 100
            {
                health = maxHealth; // set health to 100
            }

            name = "Player 1"; // sets the base name to player 1

            health = maxHealth; // sets health to 100
            
        }

        /**
          * this is an overloaded player class to handle any other player instances
          * @param name1 passes a string into the method
          * @param health1 passes a int into the method
          */
        public Player(string name1, int health1)
        {

            name = name1; // gets string and sets string to name for a different player instance
            health = health1; // gets int and sets int to health for a different player instance
            
            
        }

        /**  
          * this attack method is to handle the attacking of player instances
          * @param player passes in a player class into the method
          */
        public void Attack(Player player)
        {

            Random randomHit = new Random(); // generates a random number
            int hit = randomHit.Next(1, 26); // sets clamp on generator so that is can only generate a number between 1 and 25

            if (hit >= 1 && hit <= 15) // if random number is between 1 and 15
            {
                player.health -= hit; // player takes that random number as damage
                WriteLine("Hit for " + hit); // and lets viewer know how much one player was hit for
            }
            else if (hit >= 16 && hit <= 25) // else if the random number is between 16 and 25
            {
                WriteLine("Attack Missed"); // the attack was a miss
            }
        }

        /**
          *  this boolean method is to handle if the player is alive or not by returning true or false
          */
        public Boolean IsAlive()
        {
            if (health <= 0) // if health goes below 0
            {
                return false; // player is not alive
            }
            else // else health isn't 0
            {
                return true; // so player is alive
            }
        }

    }

    class Asg09
    {
        static void Main(string[] args)
        {
            int playerTurn = 1;

            Player player01 = new Player();
            Player player02 = new Player("player02", 100);
            while(player02.IsAlive() && player01.IsAlive())
            {
                
                if(playerTurn == 1 && player01.health > 0)
                {
                    WriteLine("Player 1: " + player01.health);
                    WriteLine("Player 2: " + player02.health);
                    WriteLine();
                    WriteLine("Player 1's turn");
                    ReadLine();
                    WriteLine("Player 1 Attacks Player 2");
                    player01.Attack(player02);
                    ReadLine();
                    playerTurn++;
                    Clear();
                }
                else if(playerTurn == 2 && player02.health > 0)
                {
                    WriteLine("Player 1: " + player01.health);
                    WriteLine("Player 2: " + player02.health);
                    WriteLine();
                    WriteLine("Player 2's turn");
                    ReadLine();
                    WriteLine("Player 2 Attacks Player 1");
                    player02.Attack(player01);
                    ReadLine();
                    playerTurn--;
                    Clear();

                }

            }

            if (playerTurn == 1)
            {
                WriteLine("Player 2 Wins!");
                ReadLine();
            }
            else
            {
                WriteLine("Player 1 Wins!");
                ReadLine();
            }
        }
    }
}
