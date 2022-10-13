using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Trabajadores
    {
        public int Cedula { get; set; }
        public string Nombre {get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string  Ingreso { get; set; }
        public string Nacimiento { get; set; }
        public string Edad { get; set; }
        public string Password_trab { get; set; }
        public string Rol { get; set; }
        public string Pago { get; set; }
        public void setCedula (int newCedula)
        {
            this.Cedula = newCedula;
        }
        public void setNombre(string newNombre)
        {
            this.Nombre = newNombre;
        }
        public void setApellido1(string newApellido1)
        {
            this.Apellido1 = newApellido1;
        }
        public void setApellido2(string newApellido2)
        {
            this.Apellido2 = newApellido2;
        }
        public void setIngreso(string newIngreso)
        {
            this.Ingreso = newIngreso;
        }
        public void setNacimiento(string newNacimiento)
        {
            this.Nacimiento = newNacimiento;
        }
        public void setPassword_trab(string newPassword_trab)
        {
            this.Password_trab = newPassword_trab;
        }
        public void setRol(string newRol)
        {
            this.Rol = newRol;
        }
        public void setPago(string newPago)
        {
            this.Pago = newPago;
        }



    }
}


