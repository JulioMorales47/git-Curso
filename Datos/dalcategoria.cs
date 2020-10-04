using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class dalcategoria
    {
        public List<becategoria> listadocategoria(Boolean ?estado)
        {
            List<becategoria> lst = new List<becategoria>();
            SqlConnection cnn = new SqlConnection(dalconexion.obtenerconexion());
            cnn.Open();
            SqlCommand objcom = new SqlCommand("sp_obtenerlistadocategoriaporestado",cnn);
            objcom.CommandType = CommandType.StoredProcedure;
            SqlParameter pestado = new SqlParameter("@estado", estado);
            objcom.Parameters.Add(pestado);
            SqlDataReader dr = objcom.ExecuteReader();

            while (dr.Read())
            {
                becategoria obj = new becategoria();
                obj.idcategoria = Convert.ToInt32(dr["idcategoria"]);
                obj.codigo = (dr["codigo"]).ToString();
                obj.descripcion = (dr["descripcion"]).ToString();
                obj.estado = Convert.ToBoolean(dr["estado"]);
                lst.Add(obj);
            }
            cnn.Close();
            return lst;
        }

        public becategoria obtenercategoria(Int32 idcategoria)
        {
            becategoria obj = null;
            SqlConnection cnn = new SqlConnection(dalconexion.obtenerconexion());
            cnn.Open();
            SqlCommand objcom = new SqlCommand("sp_obtenercategoriaporid", cnn);
            objcom.CommandType = CommandType.StoredProcedure;
            SqlParameter pestado = new SqlParameter("@idcategoria", idcategoria);
            objcom.Parameters.Add(pestado);
            SqlDataReader dr = objcom.ExecuteReader();

            if(dr.Read())
            {
                obj = new becategoria();
                obj.idcategoria = Convert.ToInt32(dr["idcategoria"]);
                obj.codigo = (dr["codigo"]).ToString();
                obj.descripcion = (dr["descripcion"]).ToString();
                obj.estado = Convert.ToBoolean(dr["estado"]);                
            }
            cnn.Close();
            return obj;
        }

        public Boolean insertarcategoria(becategoria obj)
        {
            Boolean exito = false;
            SqlConnection cnn = new SqlConnection(dalconexion.obtenerconexion());
            cnn.Open();
            SqlCommand objcom = new SqlCommand("sp_insertarcategoria", cnn);
            objcom.CommandType = CommandType.StoredProcedure;
            SqlParameter pcodigo = new SqlParameter("@codigo",obj.codigo);
            SqlParameter pdescripcion = new SqlParameter("@descripcion", obj.descripcion);
            objcom.Parameters.Add(pcodigo);
            objcom.Parameters.Add(pdescripcion);
            exito = Convert.ToBoolean(objcom.ExecuteNonQuery());
            cnn.Close();
            return exito;
        }

        public Boolean actualizarcategoria(becategoria obj)
        {
            Boolean exito = false;
            SqlConnection cnn = new SqlConnection(dalconexion.obtenerconexion());
            cnn.Open();
            SqlCommand objcom = new SqlCommand("sp_actualizarcategoria", cnn);
            objcom.CommandType = CommandType.StoredProcedure;
            SqlParameter pidcategoria = new SqlParameter("@idcategoria", obj.idcategoria);
            SqlParameter pcodigo = new SqlParameter("@codigo", obj.codigo);
            SqlParameter pdescripcion = new SqlParameter("@descripcion", obj.descripcion);
            SqlParameter pestado = new SqlParameter("@estado", obj.estado);
            objcom.Parameters.Add(pidcategoria);
            objcom.Parameters.Add(pcodigo);
            objcom.Parameters.Add(pdescripcion);
            objcom.Parameters.Add(pestado);
            exito = Convert.ToBoolean(objcom.ExecuteNonQuery());
            cnn.Close();
            return exito;
        }

        public Boolean eliminarcategoria(Int32 idcategoria)
        {
            Boolean exito = false;
            SqlConnection cnn = new SqlConnection(dalconexion.obtenerconexion());
            cnn.Open();
            SqlCommand objcom = new SqlCommand("sp_eliminarcategoria", cnn);
            objcom.CommandType = CommandType.StoredProcedure;
            SqlParameter pidcategoria = new SqlParameter("@idcategoria", idcategoria);
            objcom.Parameters.Add(pidcategoria);
            exito = Convert.ToBoolean(objcom.ExecuteNonQuery());
            cnn.Close();
            return exito;
        }

        public List<becategoria> listadocategoriapaginacion(Int32 pagina,Int32 nroregistros)
        {
            List<becategoria> lst = new List<becategoria>();
            SqlConnection cnn = new SqlConnection(dalconexion.obtenerconexion());
            cnn.Open();
            SqlCommand objcom = new SqlCommand("sp_listadocategoria_paginacion", cnn);
            objcom.CommandType = CommandType.StoredProcedure;
            SqlParameter ppagina = new SqlParameter("@pagina", pagina);
            SqlParameter pnroregistros = new SqlParameter("@nroregistros", nroregistros);
            objcom.Parameters.Add(ppagina);
            objcom.Parameters.Add(pnroregistros);
            SqlDataReader dr = objcom.ExecuteReader();

            while (dr.Read())
            {
                becategoria obj = new becategoria();
                obj.idcategoria = Convert.ToInt32(dr["idcategoria"]);
                obj.codigo = (dr["codigo"]).ToString();
                obj.descripcion = (dr["descripcion"]).ToString();
                obj.estado = Convert.ToBoolean(dr["estado"]);
                lst.Add(obj);
            }
            cnn.Close();
            return lst;
        }


        public Int32 listadocategoriapaginacioncount(Int32 nroregistros)
        {
            Int32 nropaginas = 0;

            SqlConnection cnn = new SqlConnection(dalconexion.obtenerconexion());
            cnn.Open();
            SqlCommand objcom = new SqlCommand("sp_listadocategoria_paginacion_count", cnn);
            objcom.CommandType = CommandType.StoredProcedure;
            SqlParameter pnroregistros = new SqlParameter("@nroregistros", nroregistros);
            objcom.Parameters.Add(pnroregistros);

            nropaginas = Convert.ToInt32(objcom.ExecuteScalar());

            cnn.Close();
            return nropaginas;
        }


    }
}
