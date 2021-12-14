using System;
using System.Collections.Generic;

#nullable disable

namespace CoreWebApiJWT.DataContexts
{
    public partial class ProductImage
    {
        public int ProductImageId { get; set; }
        public int? ProductId { get; set; }
        public string ProductImageUrl { get; set; }
        public string ImageCaption { get; set; }

        public virtual ProductTable Product { get; set; }
    }
}
