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
    [Table("ALERTA", Schema = "SIMI")]
    public class Alerta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ALER_ID")]
        [Description("")]
        public decimal IdAlerta { get; set; }

        [ForeignKey("Dispositivo")]
        [Column("ALER_DISP_ID")]
        public decimal? IdDispositivo { get; set; }

        public Dispositivo? Dispositivo { get; set; }

        [Column("ALER_DTHR_CRIACAO")]
        public DateTime? DataAlerta { get; set;}
    }
}
