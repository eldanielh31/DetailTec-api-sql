﻿using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Carro
    {
        public int placa { get; set; }
        public string cedula { get; set; }



        public void setPlaca(int newPlaca)
        {
            this.placa = newPlaca;
        }
        public void setCedula(string newCedula)
        {
            this.cedula = newCedula;
        }



    }
}