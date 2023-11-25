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
    [Table("DISPOSITIVO", Schema = "SIMI")]
    public class Dispositivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DISP_ID")]
        [Description("")]
        public decimal IdDispositivo { get; set; }

        [ForeignKey("IdUsuario")]
        [Column("DISP_USUA_ID")]
        public decimal? IdUsuario { get; set; }

        public Usuario? Usuario { get; set; }

        [Column("DISP_DTHR_CRIACAO")]
        public DateTime? DataCriacaoDispositivo { get; set; }

        public ICollection<Alerta>? Alertas { get; set; }

        public ICollection<Leitura>? Leituras { get; set; }
    }
}
