using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        //Member Variables (Has A)
        public Wallet Wallet;
        public Backpack Backpack;

        //Constructor (Spawner)
        public Customer()
        {
            Wallet = new Wallet();
            Backpack = new Backpack();
        }
        //Member Methods (Can Do)

        //This method will be the main logic for a customer to retrieve coins from their wallet.
        //Takes in the selected can for price reference
        //Will need to get user input for coins they would like to add.
        //When all is said and done this method will return a list of coin objects that the customer will use a payment for their soda.
        public List<Coin> GatherCoinsFromWallet(Can selectedCan)
        {
            List<Coin> payment = new List<Coin>();
            double sodaPrice = selectedCan.Price;
            while (true)
            {
                string UserSelectedCoinName = UserInterface.CoinSelection(selectedCan, payment);
                if (UserSelectedCoinName == "Done")
                {
                    return payment;
                }
                else
                {
                    Coin foundCoin = GetCoinFromWallet(UserSelectedCoinName);
                    payment.Add(foundCoin);
                }
            }
          
          
           
              
            
        }
        //Returns a coin object from the wallet based on the name passed into it.
        //Returns null if no coin can be found
        public Coin GetCoinFromWallet(string coinName)
        {
            for (int i = 0; i < Wallet.Coins.Count; i++)
            {
                if(Wallet.Coins[i].Name == coinName)
                {
                    Coin foundCoin = Wallet.Coins[i];
                    Wallet.Coins.Remove(foundCoin);
                    return foundCoin;
                }
            }
            return null;
        }
        //Takes in a list of coin objects to add into the customers wallet.
        public void AddCoinsIntoWallet(List<Coin> coinsToAdd)
        {
            for (int i = 0; i < coinsToAdd.Count; i++)
            {
                Wallet.Coins.Add(coinsToAdd[i]);

            }
            
        }
        //Takes in a can object to add to the customers backpack.
        public void AddCanToBackpack(Can purchasedCan)
        {

            Backpack.cans.Add(purchasedCan);
        }
    }
}
