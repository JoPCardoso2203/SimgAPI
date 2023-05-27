using SimgAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase
    {
        bool Adicionar<T>(T objeto);
        bool Atualizar<T>(T objeto);
    }
}
