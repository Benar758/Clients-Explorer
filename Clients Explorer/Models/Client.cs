using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clients_Explorer.Models
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Новый клиент
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="taxesPayerNumber">ИНН</param>
        public Client(string name, string taxesPayerNumber)
        {
            Name = name;
            TaxesPayerNumber = taxesPayerNumber;
            CreationDate = GetCurrentDate();
        }

        public Client()
        {
            CreationDate = GetCurrentDate();
            RefreshDate = GetCurrentDate();
            Founders = new List<Founder>();
        }

        /// <summary>
        /// Id Для БД 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [Required]
        [StringLength(255)]
        [Display(Name = "Имя или название: ")]
        public string Name { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        [Required]
        [StringLength(12)]
        [Display(Name = "ИНН: ")]
        public string TaxesPayerNumber { get; set; }

        /// <summary>
        /// Тип клиента
        /// </summary>
        [Display(Name = "Тип: ")]
        public string Type { get; set; }

        /// <summary>
        /// Дата добавления клиента
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата обновления данных о клиенте
        /// </summary>
        public DateTime RefreshDate { get; set; }

        public List<Founder> Founders { get; set; }

        internal DateTime GetCurrentDate() { return DateTime.Now; }

        internal string GetClientType()
        {
            if (this is LegalEntity) { return "Юр. лицо"; }
            else { return "ИП"; }
        }
    }
}
