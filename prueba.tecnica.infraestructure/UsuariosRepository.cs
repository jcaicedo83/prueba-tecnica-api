using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using prueba.tecnica.core.dto;
using prueba.tecnica.core.interfaces.repository;
using prueba.tecnica.infraestructure.Models;

namespace prueba.tecnica.infraestructure
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly IConfiguration _config;
        private string _dbName;

        public UsuariosRepository(IConfiguration config)
        {
            _config = config;
            _dbName = _config.GetConnectionString("sqlDb");
        }
        public ResponseItem Consultar(requestItem item)
        {
            ResponseItem response = new ResponseItem { ok = false, mensaje = string.Empty, resultado = null };

            try {
                using (DboContext _db = new DboContext(_dbName)) {
                    var result = (from user in _db.Usuarios
                                  select user).ToList();
                    response.resultado = result;
                    response.ok = true;
                    _db.Database.CloseConnection();
                }
            }catch(Exception ex)
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
                using (DboContext _db = new DboContext(_dbName))
                {
                    Usuario user = new Usuario { FechaNacimiento = item.fechaNacimiento, Nombre= item.nombre, Sexo=item.sexo };

                    _db.Add(user);
                    _db.SaveChanges();
                    _db.Database.CloseConnection();

                    response.ok = true;
                    response.mensaje = "registro insertado con exito";
                }
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
                using (DboContext _db = new DboContext(_dbName))
                {
                    Usuario user = new Usuario { FechaNacimiento = item.fechaNacimiento, Nombre = item.nombre, Sexo = item.sexo, IdUsuario=item.id };

                    _db.Update(user);
                    _db.SaveChanges();
                    _db.Database.CloseConnection();

                    response.ok = true;
                    response.mensaje = "registro ajustado con exito";
                }

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
                using (DboContext _db = new DboContext(_dbName))
                {
                    Usuario user = new Usuario { FechaNacimiento = item.fechaNacimiento, Nombre = item.nombre, Sexo = item.sexo, IdUsuario=item.id };

                    _db.Remove(user);
                    _db.SaveChanges();
                    _db.Database.CloseConnection();

                    response.ok = true;
                    response.mensaje = "registro ajustado con exito";
                }

            }
            catch (Exception ex)
            {
                response.mensaje = ex.Message;
            }
            return response;
        }
    }
}