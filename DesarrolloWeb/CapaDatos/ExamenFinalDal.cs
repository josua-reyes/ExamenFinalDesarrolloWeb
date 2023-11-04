using CapaModelos.DTO;
using CapaModelos.Modelos;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Data;
using System.IO;

namespace CapaDatos
{
    public class ExamenFinalDal : ConexionBaseDatos
    {
        public ExamenFinalDal()
        {

        }
        public ResultadoConsultaDatos EjecutarConsulta(string consultaSql)
        {
            ResultadoConsultaDatos resultadoConsultaDatos = new ResultadoConsultaDatos();

            try
            {
                using (_Connection = new OracleConnection(_CadenaConexion))
                {
                    _Connection.Open();

                    using (OracleCommand command = new OracleCommand(consultaSql, _Connection))
                    {
                        command.CommandType = CommandType.Text;

                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(resultadoConsultaDatos.Datos);
                        }
                    }
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(resultadoConsultaDatos.Datos);

                using (StringWriter sw = new StringWriter())
                {
                    ds.WriteXml(sw);
                    resultadoConsultaDatos.XmlDatos = sw.ToString();
                }

                resultadoConsultaDatos.Estado = "EXITO";
            }
            catch (Exception ex)
            {
                resultadoConsultaDatos.Estado = "ERROR";
                resultadoConsultaDatos.DescripcionError = ex.Message;
            }
            finally
            {
                _Connection.Close();
            }

            return resultadoConsultaDatos;
        }

        public AgregarMusicoAGrupoRespuesta AgregarMusicoAGrupo(int idMusico, int idGrupo)
        {
            AgregarMusicoAGrupoRespuesta agregarMusicoAGrupoRespuesta = new AgregarMusicoAGrupoRespuesta();

            try
            {
                using (_Connection = new OracleConnection(_CadenaConexion))
                {
                    _Connection.Open();
                    try
                    {
                        _Transaction = _Connection.BeginTransaction();

                        using (_Command = new OracleCommand("ExamenFinal.AgregarMusicoAGrupo", _Connection))
                        {
                            _Command.Transaction = _Transaction;
                            _Command.CommandType = CommandType.StoredProcedure;

                            _Command.Parameters.Add("p_IdMusico", OracleDbType.Int32).Value = idMusico;
                            _Command.Parameters.Add("p_IdGrupo", OracleDbType.Int32).Value = idGrupo;
                            _Command.Parameters.Add("p_Estado", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                            _Command.Parameters.Add("p_DescripcionError", OracleDbType.Varchar2, 2000).Direction = ParameterDirection.Output;

                            _Command.ExecuteNonQuery();

                            agregarMusicoAGrupoRespuesta.Estado = _Command.Parameters["p_Estado"].Value.ToString();
                            agregarMusicoAGrupoRespuesta.DescripcionError = _Command.Parameters["p_DescripcionError"].Value.ToString();

                            if (!agregarMusicoAGrupoRespuesta.Estado.Contains("EXITO"))
                            {
                                throw new Exception(agregarMusicoAGrupoRespuesta.DescripcionError);
                            }
                        }
                        _Transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        _Transaction.Rollback();
                        agregarMusicoAGrupoRespuesta.Estado = "ERROR";
                        agregarMusicoAGrupoRespuesta.DescripcionError = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                agregarMusicoAGrupoRespuesta.Estado = "ERROR";
                agregarMusicoAGrupoRespuesta.DescripcionError = ex.Message;

            }
            finally
            {
                _Connection.Close();
            }
            return agregarMusicoAGrupoRespuesta;
        }

        public ResultadoConsultaDatos ObtenerMusicoPorGenero(int idGenero)
        {
            string consultaSql = $@"
                    SELECT
                      m.nombre AS nombre_del_musico,
                      ge.descripcion AS genero
                    FROM musico m
                    JOIN musicosgrupos mg
                      ON m.idmusico = mg.idmusico
                    JOIN grupo g
                      ON mg.idgrupo = g.idgrupo
                    JOIN generosgrupos gg
                      ON g.idgrupo = gg.idgrupo
                    JOIN genero ge
                      ON gg.idgenero = ge.idgenero
                    WHERE ge.idgenero = {idGenero}
                    ORDER BY ge.descripcion, m.nombre";

            return EjecutarConsulta(consultaSql);
        }

        public ResultadoConsultaDatos ObtenerGrupoMasGenerosMusicales()
        {
            string consultaSql = $@"
                    WITH ConteoGeneros
                    AS (SELECT
                      g.idgrupo,
                      COUNT(DISTINCT gg.idgenero) AS cantidad_generos
                    FROM grupo g
                    JOIN generosgrupos gg
                      ON g.idgrupo = gg.idgrupo
                    GROUP BY g.idgrupo)
                    SELECT
                      g.nombre AS nombre_del_grupo,
                      cg.cantidad_generos
                    FROM grupo g
                    JOIN ConteoGeneros cg
                      ON g.idgrupo = cg.idgrupo
                    WHERE cg.cantidad_generos = (SELECT
                      MAX(cantidad_generos)
                    FROM ConteoGeneros)";

            return EjecutarConsulta(consultaSql);
        }

        public ResultadoConsultaDatos ObtenerGruposIntegrantes()
        {
            string consultaSql = $@"
                    SELECT
                      g.nombre AS nombre_del_grupo,
                      m.nombre AS nombre_del_musico
                    FROM grupo g
                    LEFT JOIN musicosgrupos mg
                      ON g.idgrupo = mg.idgrupo
                    LEFT JOIN musico m
                      ON mg.idmusico = m.idmusico
                    ORDER BY g.nombre, m.nombre";

            return EjecutarConsulta(consultaSql);
        }

    }
}
