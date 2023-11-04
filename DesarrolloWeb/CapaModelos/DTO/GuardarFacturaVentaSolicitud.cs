using CapaModelos.Modelos;

namespace CapaModelos.DTO
{
    public class AgregarMusicoAGrupoSolicitud
    {
        public Factura Factura {  get; set; }

        public AgregarMusicoAGrupoSolicitud()
        {
            Factura = new Factura();
        }
    }
}
