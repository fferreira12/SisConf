using SisConf.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SisconfFrontEnd.Models
{
    public class CreateInsumoViewModel
    {

        private readonly List<Marca> _marcas;

        [Display(Name = "Marca")]
        public int SelectedMarcaId { get; set; }

        public Insumo Insumo { get; set; }

        public IEnumerable<SelectListItem> FlavorItems
        {
            get { return new SelectList(_marcas, "Id", "Name"); }
        }
    }
}