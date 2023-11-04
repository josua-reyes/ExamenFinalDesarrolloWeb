using CapaLogicaNegocio;
using CapaModelos.DTO;
using CapaModelos.Modelos;
using System.Web.Services;
using System.Xml;

namespace WebServicesSOAP
{
    /// <summary>
    /// Descripción breve de examenFinal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]

    public class examenFinal : System.Web.Services.WebService
    {
        ExamenFinalBll _examenFinalBll;

        [WebMethod]
        public AgregarMusicoAGrupoRespuesta AgregarMusicoAGrupo(int idMusico, int idGrupo)
        {
            _examenFinalBll = new ExamenFinalBll();
            return _examenFinalBll.AgregarMusicoAGrupo(idMusico, idGrupo);
        }

        [WebMethod]
        public XmlDocument ObtenerMusicoPorGenero(int idGenero)
        {
            _examenFinalBll = new ExamenFinalBll();
            return _examenFinalBll.ObtenerMusicoPorGenero(idGenero).ObtenerDocumentoXML();
        }

        [WebMethod]
        public XmlDocument ObtenerGrupoMasGenerosMusicales()
        {
            _examenFinalBll = new ExamenFinalBll();
            return _examenFinalBll.ObtenerGrupoMasGenerosMusicales().ObtenerDocumentoXML();
        }

        [WebMethod]
        public XmlDocument ObtenerGruposIntegrantes()
        {
            _examenFinalBll = new ExamenFinalBll();
            return _examenFinalBll.ObtenerGruposIntegrantes().ObtenerDocumentoXML();
        }
    }
}
