using System;
using Core.Web;
using System.Collections.Generic;

namespace Starter.Web
{
    public class PhotoViewModel : ViewModelBase
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public bool IsDefault { get; set; }

        public int PersonId { get; set; }
    }

    public class PhotoListViewModel : ViewModelBase
    {
        public PhotoListViewModel WithPhotos(IList<PhotoViewModel> photos)
        {
            this.Photos = photos;
            return this;
        }

        public IList<PhotoViewModel> Photos { get; set; }
    }
}