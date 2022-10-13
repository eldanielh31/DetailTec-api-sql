using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Clientes
    {
        public int Cedula { get; set; }
        public string Cliente_Nombre { get; set; }
        public string Cliente_Apellido1 { get; set; }

        public string Cliente_Apellido2 { get; set; }

        public string Email { get; set; }

        public string Usuario { get; set; }

        public string Password_cliente { get; set; }

        public void setCedula(int newCedula)
        {
            this.Cedula = newCedula;
        }
        public void setNombre(string newCliente_Nombre)
        {
            this.Cliente_Nombre = newCliente_Nombre;
        }
        public void setCliente_Apellido1(string newCliente_Apellido1)
        {
            this.Cliente_Apellido1 = newCliente_Apellido1;
        }
        public void setCliente_Apellido2(string newCliente_Apellido2)
        {
            this.Cliente_Apellido2 = newCliente_Apellido2;
        }
        public void setEmail(string newEmail)
        {
            this.Email = newEmail;
        }
        public void setUsuario(string newUsuario)
        {
            this.Usuario = newUsuario;
        }
        public void setPassword_cliente(string newPassword_cliente)
        {
            this.Password_cliente = newPassword_cliente;
        }


    }
}