using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Medicamento
{
    internal class Lote
    {
        private int id;
        private int qtde;
        private DateTime venc;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public int Qtde
        {
            set { qtde = value; }
            get { return qtde; }
        }

        public DateTime Venc
        {
            set { venc = value; }
            get { return venc; }
        }


        public Lote()
        {
            Id = 0;
            Qtde = 0;
            Venc = DateTime.Now;
        }

        public Lote(int id, int qtde, DateTime venc)
        {
            Id = id;
            Qtde = qtde;
            Venc = venc;
        }

        public override string ToString()
        {
            return Id + " - " + Qtde + " - " + Venc;
        }


    }
}
