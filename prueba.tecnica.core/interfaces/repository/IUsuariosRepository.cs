using prueba.tecnica.core.dto;

namespace prueba.tecnica.core.interfaces.repository
{
    public interface IUsuariosRepository
    {
        ResponseItem Actualizar(requestItem item);
        ResponseItem Consultar(requestItem item);
        ResponseItem Eliminar(requestItem item);
        ResponseItem Insertar(requestItem item);
    }
}