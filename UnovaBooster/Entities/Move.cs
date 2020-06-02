using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnovaBooster.Entities
{
    public class Move : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("ElementType")]
        public int? ElementTypeID { get; set; }

        public ElementType ElementType { get; set; }
    }
}