using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment2
{
    
    /// <summary>
    /// Programming Assignment 2 solution
    /// </summary>
    class Program
    {
        /// <summary>
        /// Deals 2 cards to 3 players and displays cards for players
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            List<Card> player1Hand = new List<Card>();
            List<Card> player2Hand = new List<Card>();
            List<Card> player3Hand = new List<Card>();

            // print welcome message
            Console.WriteLine("Hello. Let's play a game!");
            Console.WriteLine();

            // create and shuffle a deck
            Deck deck = new Deck();
            deck.Shuffle();

            // deal 2 cards each to 3 players (deal properly, dealing
            // the first card to each player before dealing the
            // second card to each player)
            for(int i = 0; i <= 1; i++)
            {
                player1Hand.Add(deck.TakeTopCard());
                player2Hand.Add(deck.TakeTopCard());
                player3Hand.Add(deck.TakeTopCard());
            }

            // flip all the cards over
            for (int i = 0; i <= 1; i++)
            {
                player1Hand[i].FlipOver();
                player2Hand[i].FlipOver();
                player3Hand[i].FlipOver();
            }

            // print the cards for player 1
            Console.WriteLine("Player1 Cards:");
            Console.WriteLine(player1Hand[0].Rank + " of " + player1Hand[0].Suit);
            Console.WriteLine(player1Hand[1].Rank + " of " + player1Hand[1].Suit);
            Console.WriteLine();

            // print the cards for player 2
            Console.WriteLine("Player2 Cards:");
            Console.WriteLine(player2Hand[0].Rank + " of " + player2Hand[0].Suit);
            Console.WriteLine(player2Hand[1].Rank + " of " + player2Hand[1].Suit);
            Console.WriteLine();

            // print the cards for player 3
            Console.WriteLine("Player3 Cards:");
            Console.WriteLine(player3Hand[0].Rank + " of " + player3Hand[0].Suit);
            Console.WriteLine(player3Hand[1].Rank + " of " + player3Hand[1].Suit);

            Console.WriteLine();
        }
    }
}
