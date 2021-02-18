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
           
            //Can roobeer = new RootBeer();
            //Customer me = new Customer();
            //me.GatherCoinsFromWallet(roobeer);
            Can cola = new Cola();
            Customer you = new Customer();
            you.GatherCoinsFromWallet(cola);
            Simulation simulation = new Simulation();
            simulation.Simulate();
        }
    }
}
