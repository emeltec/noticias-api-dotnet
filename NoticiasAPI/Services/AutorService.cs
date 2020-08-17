using NoticiasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI.Services
{
    public class AutorService
    {
        public readonly NoticiasDBContext _noticiaDbContext;

        public AutorService(NoticiasDBContext noticiasDbContext)
        {
            _noticiaDbContext = noticiasDbContext;
        }

        public List<Autor> Obtener()
        {
            var resultado = _noticiaDbContext.Autor.ToList();
            return resultado;
        }

        public Boolean AgregarAutor(Autor _autor)
        {
            try
            {
                _noticiaDbContext.Autor.Add(_autor);
                _noticiaDbContext.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Boolean EditarAutor(Autor _autor)
        {
            try
            {
                var autorBD = _noticiaDbContext.Autor.Where(busqueda => busqueda.AutorID == _autor.AutorID).FirstOrDefault();
                autorBD.Nombre = _autor.Nombre;
                autorBD.Apellido = _autor.Apellido;

                _noticiaDbContext.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Boolean EliminarAutor(int autorID)
        {
            try
            {
                var noticiaBD = _noticiaDbContext.Autor.Where(busqueda => busqueda.AutorID == autorID).FirstOrDefault();
                _noticiaDbContext.Remove(noticiaBD);
                _noticiaDbContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
