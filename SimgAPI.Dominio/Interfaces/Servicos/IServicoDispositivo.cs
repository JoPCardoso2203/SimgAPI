﻿using SimgAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Dominio.Interfaces.Servicos
{
    public interface IServicoDispositivo
    {
        Usuario? ObterLoginUsuarioPorDispositivoId(decimal idDispositivo);
    }
}
