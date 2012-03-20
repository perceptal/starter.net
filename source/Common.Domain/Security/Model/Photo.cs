using System;
using Core.Domain;

namespace Common.Domain
{
    public class Photo : Entity
    {
        public Photo()
        {
        }

        public Photo(string caption, byte[] image)
        {
            this.Caption = caption;
            this.Image = image;
        }

        public virtual byte[] Image { get; set; }

        public virtual string Caption { get; set; }

        public virtual Person Person { get; set; }
    }
}
