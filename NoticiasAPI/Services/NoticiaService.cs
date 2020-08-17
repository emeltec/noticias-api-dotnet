using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasAPI.Services
{
    public class NoticiaService
    {
        public readonly NoticiasDBContext _noticiaDbContext;

        public NoticiaService(NoticiasDBContext noticiaDbContext)
        {
            _noticiaDbContext = noticiaDbContext;
        }

        public List<Noticia> Obtener()
        {
            var resultado = _noticiaDbContext.Noticia.Include(x => x.Autor).ToList();
            return resultado;
        }

        public Boolean AgregarNoticia(Noticia _noticia)
        {
            try
            {
                _noticiaDbContext.Noticia.Add(_noticia);
                _noticiaDbContext.SaveChanges();
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
            
        }

        public Boolean EditarNoticia(Noticia _noticia)
        {
            try
            {
                var noticiaBD = _noticiaDbContext.Noticia.Where(busqueda => busqueda.NoticiaID == _noticia.NoticiaID).FirstOrDefault();
                noticiaBD.Titulo = _noticia.Titulo;
                noticiaBD.Descripcion = _noticia.Descripcion;
                noticiaBD.Contenido = _noticia.Contenido;
                noticiaBD.Fecha = _noticia.Fecha;
                noticiaBD.AutorID = _noticia.AutorID;

                _noticiaDbContext.SaveChanges();

                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }

        public Boolean EliminarNoticia(int _noticiaID)
        {
            try
            {
                var noticiaBD = _noticiaDbContext.Noticia.Where(busqueda => busqueda.NoticiaID == _noticiaID).FirstOrDefault();
                _noticiaDbContext.Remove(noticiaBD);
                _noticiaDbContext.SaveChanges();
                
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
