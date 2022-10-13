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
    public class ClientesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public ClientesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select Cedula, Cliente_Nombre,Cliente_Apellido1, Cliente_Apellido2, Email, 
                            Usuario, Password_cliente              
                            from
                            dbo.Cliente
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
        public JsonResult Post(Clientes emp)
        {
            string query = @"
                           insert into dbo.Cliente (Cedula, Cliente_Nombre, Cliente_Apellido1, Cliente_Apellido2, Email, Usuario, Password_cliente) 
                           values (@Cedula, @Cliente_Nombre, @Cliente_Apellido1, @Cliente_Apellido2, @Email, @Usuario,
                             @Password_cliente)             
                     
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
                    myCommand.Parameters.AddWithValue("@Cliente_Nombre", emp.Cliente_Nombre);
                    myCommand.Parameters.AddWithValue("@Cliente_Apellido1", emp.Cliente_Apellido1);
                    myCommand.Parameters.AddWithValue("@Cliente_Apellido2", emp.Cliente_Apellido2);
                    myCommand.Parameters.AddWithValue("@Email", emp.Email);
                    myCommand.Parameters.AddWithValue("@Usuario", emp.Usuario);
                    myCommand.Parameters.AddWithValue("@Password_cliente", emp.Password_cliente);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Clientes emp)
        {
            string query = @"
                           update dbo.Cliente
                           set Cliente_Nombre=@Cliente_Nombre,
                            Cliente_Apellido1=@Cliente_Apellido1,
                            Cliente_Apellido2=@Cliente_Apellido2,
                            Email = @Email,
                            Usuario = @Usuario,
                            Password_cliente = @Password_cliente
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
                    myCommand.Parameters.AddWithValue("@Cliente_Nombre", emp.Cliente_Nombre);
                    myCommand.Parameters.AddWithValue("@Cliente_Apellido1", emp.Cliente_Apellido1);
                    myCommand.Parameters.AddWithValue("@Cliente_Apellido2", emp.Cliente_Apellido2);
                    myCommand.Parameters.AddWithValue("@Email", emp.Email);
                    myCommand.Parameters.AddWithValue("@Usuario", emp.Usuario);
                    myCommand.Parameters.AddWithValue("@Password_cliente", emp.Password_cliente);                 
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                           delete from dbo.Cliente
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
                    myCommand.Parameters.AddWithValue("@Cedula", id);

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
