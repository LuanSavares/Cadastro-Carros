using System;
using System.Collections.Generic;
using DIO.Carros.Interfaces;

namespace DIO.Carros
{
    public class CarroRepositorio : IRepositorio<Carro>
    {
        private List<Carro> listaCarro = new List<Carro>();
        public void Atualiza(int id, Carro objeto)
        {
            listaCarro[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaCarro[id].Excluir();
        }

        public void Insere(Carro objeto)
        {
            listaCarro.Add(objeto);
        }

        public List<Carro> Lista()
        {
            return listaCarro;
        }

        public int ProximoId()
        {
            return listaCarro.Count;
        }

        public Carro RetornaPorID(int id)
        {
            return listaCarro[id];
        }
    }
}