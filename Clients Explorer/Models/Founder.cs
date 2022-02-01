using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clients_Explorer.Models
{
    /// <summary>
    /// Учредитель
    /// </summary>
    public class Founder
    {
        /// <summary>
        /// Новый учредитель
        /// </summary>
        /// <param name="fullName">ФИО</param>
        /// <param name="taxesPayerNumber">ИНН</param>
        public Founder(string fullName, string taxesPayerNumber)
        {
            FullName = fullName;
            TaxesPayerNumber = taxesPayerNumber;
            CreationDate = DateTime.Now;
            RefreshDate = DateTime.Now;
        }

        public Founder() 
        {
            CreationDate = DateTime.Now;
            RefreshDate = DateTime.Now;
        }

        /// <summary>
        /// Id учредителя
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        [Required]
        [StringLength(255)]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        [Required]
        [StringLength(12)]
        [Display(Name = "ИНН")]
        public string TaxesPayerNumber { get; set; }

        /// <summary>
        /// Дата добавления учредителя
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата обновления данных об учредителе
        /// </summary>
        public DateTime RefreshDate { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
