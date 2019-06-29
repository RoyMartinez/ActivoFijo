using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ActivoFijoEntities();
            var empresa = new empresa();
            context.empresa.ToList().ForEach(p => Console.WriteLine(p.nombre));
            Console.ReadLine();
        }
    }
}
