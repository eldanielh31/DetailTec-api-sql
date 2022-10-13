using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public TrabajadoresController(IConfiguration configuration,IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select Cedula, Nombre,Apellido1, Apellido2, Ingreso, 
                            Nacimiento, Edad, Password_trab, Rol, Pago              
                            from
                            dbo.Trabajadores
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Trabajadores emp)
        {
            string query = @"
                           insert into dbo.Trabajadores (Cedula, Nombre, Apellido1, Apellido2, Ingreso, Nacimiento ,
                           Password_trab, Rol, Pago) 
                           values (@Cedula, @Nombre, @Apellido1, @Apellido2, @Ingreso, @Nacimiento,
                             @Password_trab, @Rol, @Pago)             
                     
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Cedula", emp.Cedula);
                    myCommand.Parameters.AddWithValue("@Nombre", emp.Nombre);
                    myCommand.Parameters.AddWithValue("@Apellido1", emp.Apellido1);
                    myCommand.Parameters.AddWithValue("@Apellido2", emp.Apellido2);
                    myCommand.Parameters.AddWithValue("@Ingreso", emp.Ingreso);
                    myCommand.Parameters.AddWithValue("@Nacimiento", emp.Nacimiento);
                    myCommand.Parameters.AddWithValue("@Password_trab", emp.Password_trab);
                    myCommand.Parameters.AddWithValue("@Rol", emp.Rol);
                    myCommand.Parameters.AddWithValue("@Pago", emp.Pago);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Trabajadores emp)
        {
            string query = @"
                            update dbo.Trabajadores
                            set Nombre=@Nombre,
                            Apellido1=@Apellido1,
                            Apellido2=@Apellido2,
                            Ingreso = @Ingreso,
                            Nacimiento = @Nacimiento,
                            Edad = @Edad,
                            Password_trab = @Password_trab,
                            Rol = @Rol,
                            Pago = @Pago
                            where Cedula= @Cedula
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Cedula", emp.Cedula);
                    myCommand.Parameters.AddWithValue("@Nombre", emp.Nombre);
                    myCommand.Parameters.AddWithValue("@Apellido1", emp.Apellido1);
                    myCommand.Parameters.AddWithValue("@Apellido2", emp.Apellido2);
                    myCommand.Parameters.AddWithValue("@Ingreso", emp.Ingreso);
                    myCommand.Parameters.AddWithValue("@Nacimiento", emp.Nacimiento);
                    myCommand.Parameters.AddWithValue("@Edad", emp.Edad);
                    myCommand.Parameters.AddWithValue("@Password_trab", emp.Password_trab);
                    myCommand.Parameters.AddWithValue("@Rol", emp.Rol);
                    myCommand.Parameters.AddWithValue("@Pago", emp.Pago);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{Cedula}")]
        public JsonResult Delete(int Cedula)
        {
            string query = @"
                           delete from dbo.Trabajadores
                            where Cedula=@Cedula
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Cedula", Cedula);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
        

    }
}
