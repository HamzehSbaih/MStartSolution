using MStart.Common.DTO_s;
using MStart.DataAccess.Entities;
using MStart.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.DataAccess.CustomRepositories
{
    public class ImageRepository : Repository<UserImage>
    {
        public ImageRepository(UnitOfWork uow) : base(uow) { }


        public int AddImages(UserImageDTO dto)
        {
            var savedImages = new UserImage()
            {
                file_stream = dto.file_stream,
                Id = dto.Id,
                file_name = dto.FileNameWithExtension,
                file_type = dto.ContentType
            };
            Create(savedImages);
            _uow.Save();
            int isSaved = 0;
            if (savedImages.Id > 0)
            {
                isSaved = savedImages.Id;
            }
            else
            {
                isSaved = 0;
            }
            return isSaved;
        }




    }
}
