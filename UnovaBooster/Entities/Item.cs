using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UnovaBooster.Enums;

namespace UnovaBooster.Entities
{
    public class Item : Base
    {
        public string Name { get; set; }
        [ForeignKey("ItemType")]
        public int ItemTypeID { get; set; }
        public decimal StoreOriginalPrice { get; set; }
        public decimal StorePromotionalPrice { get; set; }

        public ItemType Type { get; set; }
    }
}
