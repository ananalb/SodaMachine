using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        //Member Variables (Has A)
        private List<Coin> _register;
        private List<Can> _inventory;

        //Constructor (Spawner)
        public SodaMachine()
        {
            _register = new List<Coin>();
            _inventory = new List<Can>();
            FillInventory();
            FillRegister();
        }

        //Member Methods (Can Do)

        //A method to fill the sodamachines register with coin objects.
        public void FillRegister()
        {
            for (int i = 0; i < 20; i++)
            {
                Coin myCoin = new Quarter();
                _register.Add(myCoin);
            }
            for (int i = 0; i < 10; i++)
            {
                Coin myCoin = new Dime();
                _register.Add(myCoin);
            }
            for (int i = 0; i < 20; i++)
            {
                Coin myCoin = new Nickel();
                _register.Add(myCoin);
            }
            for (int i = 0; i < 50; i++)
            {
                Coin myCoin = new Penny();
                _register.Add(myCoin);
            }

        }
        //A method to fill the sodamachines inventory with soda can objects.
        public void FillInventory()

        {   for(int i = 0; i < 10; i++)
            {
                OrangeSoda orangeSoda = new OrangeSoda();
                _inventory.Add(orangeSoda);               
            }

            for (int i = 0; i < 10; i++)
            {
                Cola cola = new Cola();
                _inventory.Add(cola);
            }

            for (int i = 0; i < 10; i++)
            {
                RootBeer rootbeer = new RootBeer();
                _inventory.Add(rootbeer);
            }
            
        }
        //Method to be called to start a transaction.
        //Takes in a customer which can be passed freely to which ever method needs it.
        public void BeginTransaction(Customer customer)
        {
            bool willProceed = UserInterface.DisplayWelcomeInstructions(_inventory);
            if (willProceed)
            {
                Transaction(customer);
            }
        }
        
        //This is the main transaction logic think of it like "runGame".  This is where the user will be prompted for the desired soda.
        //grab the desired soda from the inventory.
        //get payment from the user.
        //pass payment to the calculate transaction method to finish up the transaction based on the results.
        private void Transaction(Customer customer)
        {
            string CustomerCanSelection = "";
            Can canchoice = GetSodaFromInventory(CustomerCanSelection);
            List<Coin> Payment = new List<Coin>(); 
            CalculateTransaction(Payment, canchoice, customer);

          
        }
        

        //above and below are last methods to do

        //This is the main method for calculating the result of the transaction.
        //It takes in the payment from the customer, the soda object they selected, and the customer who is purchasing the soda.
        //This is the method that will determine the following:
        //If the payment is greater than the price of the soda, and if the sodamachine has enough change to return: Despense soda, and change to the customer.
        //If the payment is greater than the cost of the soda, but the machine does not have ample change: Despense payment back to the customer.
        //If the payment is exact to the cost of the soda:  Dispense soda. 
        //If the payment does not meet the cost of the soda: despense payment back to the customer.
        public void CalculateTransaction(List<Coin> payment, Can chosenSoda, Customer customer)
        {
            double totalPaymentValue = TotalCoinValue(payment);
            double canPrice = chosenSoda.Price;
                                           
            if (totalPaymentValue > canPrice)
            {
                if (totalPaymentValue > canPrice)
                {   
                    DetermineChange(totalPaymentValue,canPrice);
                    GatherChange(totalPaymentValue);               
                    customer.AddCoinsIntoWallet(payment);

                }
                _inventory.Remove(chosenSoda);

            }
            else if (totalPaymentValue == canPrice)
            {

                _inventory.Remove(chosenSoda);
                customer.AddCanToBackpack(chosenSoda);             
               
            }
            else if (totalPaymentValue < canPrice)
            {                             
                DepositCoinsIntoRegister(payment);
                customer.AddCoinsIntoWallet(payment);
                Console.WriteLine($"Please deposit ${canPrice} to get your chosen soda");                            
            }
        }
        //Takes in the value of the amount of change needed. 
        //Attempts to gather all the required coins from the sodamachine's register to make change. 
        //Returns the list of coins as change to despense. 
        //If the change cannot be made, return null.
        public  List<Coin> GatherChange(double changeValue)
        {

            List<Coin> coins = new List<Coin>();        
            
            while(changeValue > 0)
            {
                if(changeValue >= 0.25 && RegisterHasCoin("Quarter"))
                {
                    Coin quarter = GetCoinFromRegister("Quarter");
                    coins.Add(quarter);
                    changeValue -= 0.25;
                }
                else if (changeValue >= 0.10 && RegisterHasCoin("Dime"))
                {
                    Coin dime = GetCoinFromRegister("Dime");
                    coins.Add(dime);
                    changeValue -= 0.10;
                }
                else if (changeValue >= 0.05 && RegisterHasCoin("Nickel"))
                {
                    Coin nickel = GetCoinFromRegister("Nickel");
                    coins.Add(nickel);
                    changeValue -= 0.05;
                }
                else if (changeValue >= 0.01 && RegisterHasCoin("Penny"))
                {
                    Coin penny = GetCoinFromRegister("Penny");
                    coins.Add(penny);
                    changeValue -= 0.01;
                }
                else
                {                 
                    Console.WriteLine("Sorry, the machine can't make change");
                    DepositCoinsIntoRegister(coins);
                    Console.WriteLine("The machine can't dispense the soda");
                    return null;
                }              
            }
            return coins;
        }        

        //Gets a soda from the inventory based on the name of the soda.
        private Can GetSodaFromInventory(string nameOfSoda)
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                if(_inventory[i].Name == nameOfSoda)
                {
                    Can foundSoda = _inventory[i];
                    _inventory.Remove(foundSoda);
                    return foundSoda;
                }
            }
            return null;
        }
        //Reusable method to check if the register has a coin of that name.
        //If it does have one, return true.  Else, false.
        private bool RegisterHasCoin(string name)
        {
            for (int i = 0; i < _register.Count; i++)
            {
                if (_register[i].Name == name)
                {
                    return true;
                }               
            }
            return false;
        }
        //Reusable method to return a coin from the register.
        //Returns null if no coin can be found of that name.
        private Coin GetCoinFromRegister(string name)
        {
            
            for (int i = 0; i < _register.Count; i++)
            {
              if (_register[i].Name == name)
              {
                     Coin foundCoin = _register[i];
                    _register.Remove(foundCoin);
                     return foundCoin;
                }
            }
               return null;
            
        }
        //Takes in the total payment amount and the price of can to return the change amount.
        private double DetermineChange(double totalPayment, double canPrice)
        {
           double totalChange = totalPayment - canPrice;
           return totalChange;

        }
        //Takes in a list of coins to return the total value of the coins as a double.
        private double TotalCoinValue(List<Coin> payment)
        {
            double SodaMachinetotalValue = 0;
            foreach(Coin coin in payment)
            {
                SodaMachinetotalValue += coin.Value;

            }
            return SodaMachinetotalValue;
            
        }
        //Puts a list of coins into the soda machines register.
        private void DepositCoinsIntoRegister(List<Coin> coins)
        {
            for(int i = 0; i < coins.Count; i++) 
            {
                _register.Add(coins[i]);

            }
        }
    }
}
