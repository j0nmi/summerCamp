﻿using Context;
using Entidades.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly ContextoConversor _context;

        public RepositorioUsuarios(ContextoConversor context)
        {
            _context = context;
        }

        public async Task<Usuario> obtenerUsuario(Guid id)
        {

            return _context.usuarios.Include(p => p.pais).FirstOrDefault(m => m.id == id);
        }

        public async Task<int> guardarCambios()
        {
            return _context.SaveChanges();
        }
    }
}
