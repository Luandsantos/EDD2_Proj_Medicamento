using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Medicamento
{
    class Medicamentos
    {
 
        private List<Medicamento> listaMedicamentos;

        public List<Medicamento> ListaMedicamentos
        {
			get { return listaMedicamentos; }
			set { listaMedicamentos = value; }
		}

        public Medicamentos()
        {
            ListaMedicamentos = new List<Medicamento>();
        }

        public void adicionar(Medicamento medicamento)
        {
            ListaMedicamentos.Add(medicamento);
        }

        public bool deletar(Medicamento medicamento)
        {
            if (medicamento.qtdeDisponivel() <= 0)
            {
                ListaMedicamentos.Remove(medicamento);
                return true;
            } else
            {
                return false;
            }
        }
        public Medicamento pesquisar(Medicamento medicamento)
        {
            foreach (Medicamento medicina in ListaMedicamentos)
            {
                if (medicina.Id == medicamento.Id)
                {
                    return medicina;
                }
            }
            return null;
        }
    }
}
