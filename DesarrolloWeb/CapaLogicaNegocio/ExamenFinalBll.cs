using CapaDatos;
using CapaModelos.DTO;
using CapaModelos.Modelos;

namespace CapaLogicaNegocio
{
    public class ExamenFinalBll
    {
        ExamenFinalDal _examenFinalDal;
        public ExamenFinalBll()
        {
            _examenFinalDal = new ExamenFinalDal();

        }

        public AgregarMusicoAGrupoRespuesta AgregarMusicoAGrupo(int idMusico, int idGrupo, string instrumento)
        {
            return _examenFinalDal.AgregarMusicoAGrupo(idMusico, idGrupo, instrumento);
        }

        public ResultadoConsultaDatos ObtenerMusicoPorGenero(int idGenero)
        {
            return _examenFinalDal.ObtenerMusicoPorGenero(idGenero);
        }

        public ResultadoConsultaDatos ObtenerGrupoMasGenerosMusicales()
        {
            return _examenFinalDal.ObtenerGrupoMasGenerosMusicales();
        }

        public ResultadoConsultaDatos ObtenerGruposIntegrantes()
        {
            return _examenFinalDal.ObtenerGruposIntegrantes();
        }
    }
}
