using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimgAPI.Dominio.Entidades
{
    [Table("USUARIO", Schema = "SIMI")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("USUA_ID")]
        [Description("")]
        public decimal IdUsuario { get; set; }

        [Column("USUA_NOME")]
        public string? NomeUsuario { get; set; }

        [Column("USUA_LOGIN")]
        public string? LoginUsuario { get; set; }

        [Column("USUA_SENHA")]
        public string? SenhaUsuario { get; set; }

        [Column("USUA_TELEFONE")]
        public string? TelefoneUsuario { get; set; }

        [Column("USUA_DTHR_CRIACAO")]
        public DateTime? DataCriacaoUsuario { get; set; }

        public ICollection<Dispositivo>? Dispositivos { get; set; }
    }
}
