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
    [Table("LEITURA", Schema = "SIMI")]
    public class Leitura
    {
        [Key]
        [Column("LEIT_ID")]
        public decimal IdLeitura { get; set; }

        [ForeignKey("Dispositivo")]
        [Column("LEIT_DISP_ID")]
        public decimal? IdDispositivo { get; set; }

        public Dispositivo? Dispositivo { get; set; }

        [Column("LEIT_VALOR_CHAMA")]
        public string? ValorChama { get; set; }

        [Column("LEIT_VALOR_GAS")]
        public string? ValorGas { get; set; }

        [Column("LEIT_JSON")]
        public string? JsonLeitura { get; set; }

        [Column("LEIT_DTHR_CRIACAO")]
        public DateTime? DataLeitura { get; set; }
    }
}
