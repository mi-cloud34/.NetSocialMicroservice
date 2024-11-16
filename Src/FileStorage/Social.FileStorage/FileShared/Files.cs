using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Shared.FileShared
{

    public class Files : Entity
    {
        //public string FileName { get; set; }

        public string Storage { get; set; }
        // [NotMapped]
        // public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
