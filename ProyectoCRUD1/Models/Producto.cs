﻿using System.ComponentModel.DataAnnotations;
namespace ProyectoCRUD1.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        [Required]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        [Required]
        public int cantidad { get; set; }
}
}
