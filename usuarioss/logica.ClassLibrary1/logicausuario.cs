using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accesodatos;
using Accesodatos.ClassLibrary1;

namespace logica.ClassLibrary1
{
    //consulta a la BD
   public class logicausuario
    {
        private static DCMATRICULADataContext dc = new DCMATRICULADataContext();

        public static List <Usuario> getAllUsers()

        {

            try
            {
                var lista = dc.Usuario.Where(data => data.usu_status == 'A');
                return lista.ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuario"+ ex.Message) ;
            }
       }
        public static Usuario getUsersXId(int IdUsuario)

        {

            try
            {
                var usuario = dc.Usuario.Where(data => data.usu_status == 'A'
                && data.usu_id.Equals(IdUsuario)).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuario" + ex.Message);
            }
        }
        public static Usuario getUserXlogin(string email, string clave)

        {

            try
            {
                var usuario = dc.Usuario.Where(data => data.usu_status == 'A'
                && data.usu_correo.Equals(email)&& data.usu_password.Equals(clave)).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener email" + ex.Message);
            }
        }
        public static bool SaveUser(Usuario dataUsuario)

        {

            try
            {
                bool result = false;
                dataUsuario.usu_add = DateTime.Now;
                dataUsuario.usu_status = 'A';

                dc.Usuario.InsertOnSubmit(dataUsuario);
                dc.SubmitChanges();
                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al guardad" + ex.Message);
            }
        }
        public static bool updateUser(Usuario dataUsuario)

        {

            try
            {
                bool result = false;
                dc.SubmitChanges();//actualizar datos
                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al modificar usuario" + ex.Message);
            }
        }
        public static bool deleteUser(Usuario dataUsuario)

        {

            try
            {
                bool result = false;
                dataUsuario.usu_status = 'I';
                dc.SubmitChanges();
                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al eliminar usuario" + ex.Message);
            }
        }
    }

}
