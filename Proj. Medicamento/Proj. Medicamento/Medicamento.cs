using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Proj.Medicamento
{
    internal class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes = new Queue<Lote>();

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Laboratorio
        {
            get { return laboratorio; }
            set { laboratorio = value; }
        }

        public Queue<Lote> Lotes
        {
            get { return lotes; }
            set { lotes = value; }
        }

        public Medicamento()
        {
            Id = 0;
            Nome = "";
            Laboratorio = "";
            Lotes = new Queue<Lote>();
        }

        public Medicamento(int id)
        {
            Id = id;
            Nome = "";
            Laboratorio = "";
            Lotes = new Queue<Lote>();
        }

        public  Medicamento(int id, string nome, string laboratorio)
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
            Lotes = new Queue<Lote>();
        }

        public int qtdeDisponivel()
        {
            int qtde_medicamentos = 0;
            foreach (Lote lote in Lotes)
            {
                qtde_medicamentos += lote.Qtde;
            }
            return qtde_medicamentos;
        }

        public void comprar(Lote lote)
        {
            Lotes.Enqueue(lote);
        }

        public bool vender(int qtde)
        {
            int qtde_alterada = qtde;
            int lotes_vendidos = 0;
            if (qtdeDisponivel() >= qtde)
            {
                foreach (Lote lote in Lotes)
                {
                    if (0 >= qtde_alterada)
                    {
                        Console.WriteLine("teste1");
                        break;
                    }
                    int lote_qtde_original = lote.Qtde;
                    lote.Qtde -= qtde_alterada;
                    if (0 >= lote.Qtde)
                    {
                        Console.WriteLine("teste2");
                        lotes_vendidos++;
                    }
                    qtde_alterada -= lote_qtde_original;
                }
                for (int i = 0; i < lotes_vendidos; i++)
                {
                    Console.WriteLine("teste3");
                    Lotes.Dequeue();
                }
                if (0 >= qtde_alterada)
                {
                    Console.WriteLine("teste4");
                    return true;
                }
                return false;
            } 
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return Id + " - " + Nome + " - " + Laboratorio + " - " + qtdeDisponivel(); 
        }

        public override bool Equals(object obj)
        {
            return obj is Medicamento other && Id == other.Id;
        }
    }
}
