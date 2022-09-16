using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    public class Taxi : TransportePublico
    {
        private string NombreVehiculo { get => "Taxi"; }
        public Taxi(int cantidadPasajeros) : base(cantidadPasajeros)
        {

        }

        public override string Avanzar()
        {
            throw new NotImplementedException();
        }

        public override string Detenerse()
        {
            throw new NotImplementedException();
        }

        public override string Nombre()
        {
            return $"{NombreVehiculo}";
        }
    }
}
