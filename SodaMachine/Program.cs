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
            Can roobeer = new RootBeer();
            Customer me = new Customer();
            me.GatherCoinsFromWallet(roobeer);
            Simulation simulation = new Simulation();
            simulation.Simulate();
        }
    }
}
