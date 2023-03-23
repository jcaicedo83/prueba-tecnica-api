using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using prueba.tecnica.core.dto;
using prueba.tecnica.infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba.tecnica.infraestructure
{
    public class DbRepository
    {
        private readonly IConfiguration _config;
        private string _dbName;
        private SqlConnection _conn;

        public DbRepository(IConfiguration config)
        {
            _config = config;
            _dbName = _config.GetConnectionString("sqlDb");
        }

        public bool Conectar() {
            if (_conn == null)
                _conn = new SqlConnection(_dbName);

            if (_conn.State == System.Data.ConnectionState.Open)
                return true;

            return false;
        }
        public ResponseItem Consultar(requestItem item)
        {
            ResponseItem response = new ResponseItem { ok = false, mensaje = string.Empty, resultado = null };

            try
            {
                Conectar();
                SqlCommand _cmd = new SqlCommand("prcConsultar", _conn);
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader _dr=  _cmd.ExecuteReader();
                _conn.Close();
                response.ok = true;

            }
            catch (Exception ex)
            {
                response.mensaje = ex.Message;
            }

            return response;
        }
        public ResponseItem Insertar(requestItem item)
        {
            ResponseItem response = new ResponseItem { ok = false, mensaje = string.Empty, resultado = null };
            try
            {
                Conectar();
                SqlCommand _cmd = new SqlCommand("prcInsertar", new SqlConnection(_dbName));
                _cmd.Parameters.Add(new SqlParameter("@sexo", item.sexo));
                _cmd.Parameters.Add(new SqlParameter("@nombre", item.nombre));
                _cmd.Parameters.Add(new SqlParameter("@fecha_nacimiento", item.fechaNacimiento));
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                _cmd.ExecuteNonQuery();
                _conn.Close();

                response.ok = true;
                response.mensaje = "registro insertado con exito";
                
            }
            catch (Exception ex)
            {
                response.mensaje = ex.Message;
            }
            return response;
        }
        public ResponseItem Actualizar(requestItem item)
        {
            ResponseItem response = new ResponseItem { ok = false, mensaje = string.Empty, resultado = null };
            try
            {
                Conectar();
                SqlCommand _cmd = new SqlCommand("prcActualizar", new SqlConnection(_dbName));
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                _cmd.Parameters.Add(new SqlParameter("@id", item.id));
                _cmd.Parameters.Add(new SqlParameter("@sexo", item.sexo));
                _cmd.Parameters.Add(new SqlParameter("@nombre", item.nombre));
                _cmd.Parameters.Add(new SqlParameter("@fecha_nacimiento", item.fechaNacimiento));
                _cmd.ExecuteNonQuery();
                _conn.Close();

                response.ok = true;
                response.mensaje = "registro ajustado con exito";
                

            }
            catch (Exception ex)
            {
                response.mensaje = ex.Message;
            }
            return response;
        }
        public ResponseItem Eliminar(requestItem item)
        {
            ResponseItem response = new ResponseItem { ok = false, mensaje = string.Empty, resultado = null };
            try
            {
                Conectar();
                SqlCommand _cmd = new SqlCommand("prcEliminar", new SqlConnection(_dbName));
                _cmd.Parameters.Add(new SqlParameter("@id", item.id));
                _cmd.CommandType = System.Data.CommandType.StoredProcedure;
                _cmd.ExecuteNonQuery();
                _conn.Close();

                response.ok = true;
                response.mensaje = "registro ajustado con exito";
                

            }
            catch (Exception ex)
            {
                response.mensaje = ex.Message;
            }
            return response;
        }
    }
}
