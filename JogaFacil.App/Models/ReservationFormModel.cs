using JogaFacil.App.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace JogaFacil.App.Models
{
    public class ReservationFormModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "É necessário selecionar a quadra que deseja reservar")]
        public string ArenaId { get; set; }

        [Required (ErrorMessage = "É necessário selecionar a data da reserva")]
        [DateRangeValidation (ErrorMessage = "A data selecionada não pode ser menor que hoje")]
        public DateTime Date { get; set; }

        [Required (ErrorMessage = "É necessário selecionar o horário da reserva")]
        public DateTime Time { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
