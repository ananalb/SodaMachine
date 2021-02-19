using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SodaMachine sodaMachine = new SodaMachine();
          
            //sodaMachine.GatherChange(0.50);
            List<Coin> testPayment = new List<Coin>() { new Quarter(), new Quarter(), new Dime(), new Nickel(), new Penny() };
            Can rootBeer = new RootBeer();
            Customer bob = new Customer();
            sodaMachine.CalculateTransaction(testPayment, rootBeer, bob);

            ////Can roobeer = new RootBeer();
            ////Customer me = new Customer();
            ////me.GatherCoinsFromWallet(roobeer);
            //Can cola = new Cola();
            //Customer you = new Customer();
            //you.GatherCoinsFromWallet(cola);
            //Simulation simulation = new Simulation();
            //simulation.Simulate();
        }
    }
}
