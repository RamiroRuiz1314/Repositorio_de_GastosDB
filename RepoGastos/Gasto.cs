using System;
using System.Collections.Generic;
using System.Text;

namespace RepoGastos
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Categoria { get; set; }

        public override string ToString()
        {
            return $"{Id}; Descripcion: {Descripcion}|| Monto: {Monto}|| Categoria: {Categoria}";
        }
    }
}