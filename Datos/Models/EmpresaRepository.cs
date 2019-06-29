using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class EmpresaRepository
    {
        public static List<empresa> GetAll()
        {
            try
            {
                using (ActivoFijoEntities context = new ActivoFijoEntities())
                {
                    return context.empresa.ToList();
                }
            }
            catch(Exception ex)
            {
                return new List<empresa>();
            }
        }
    }
}
