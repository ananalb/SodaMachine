using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        //Member Variables (Has A)
        public List<Coin> Coins;
        public Card card;
        //Constructor (Spawner)
        public Wallet()
        {
            Coins = new List<Coin>();
            card = new Card();
            FillRegister();
        }
        //Member Methods (Can Do)
        //Fills wallet with starting money
        private void FillRegister()
        {
            for(int i = 0; i < 20; i++)
            {
                Coin myCoin = new Quarter();
                Coins.Add(myCoin);
            }
            for (int i = 0; i < 10; i++)
            {
                Coin myCoin = new Dime();
                Coins.Add(myCoin);
            }
            for(int i = 0; i < 20; i++)
            {
                Coin myCoin = new Nickel();
                Coins.Add(myCoin);
            }
            for (int i = 0; i < 50; i++)
            {
                Coin myCoin = new Penny();
                Coins.Add(myCoin);
            }
            
                Card myCard = new Card();
                myCard.availableFunds.Equals(100);

        }
    }
}
