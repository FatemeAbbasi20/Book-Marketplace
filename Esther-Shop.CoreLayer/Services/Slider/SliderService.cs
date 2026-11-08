using Esther_Shop.CoreLayer.Dtos.Sliders;
using Esther_Shop.CoreLayer.Mappers;
using Esther_Shop.CoreLayer.Services.FileManager;
using Esther_Shop.CoreLayer.Utilities;
using Esther_Shop.DataLayer.Context;
using Esther_Shop.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esther_Shop.CoreLayer.Services.Slider
{
    public class SliderService : ISliderService
    {
        private readonly BlogContext _context;
        private readonly IFileManager _fileManager;
        public SliderService(BlogContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }

        public OperationResult CreateSlider(CreateSliderDto Command)
        {
          var  imageName = _fileManager.SaveFileAndReturnName(Command.ImageFile, Directions.SliderImage);
            var Slider = new DataLayer.Entities.Slider()
            {
                Link=Command.Link,Title=Command.Title,
                DisplayOrder=Command.DisplayOrder,
                IsActive=Command.IsActive,
                ImageName= imageName
            };
            _context.Sliders.Add(Slider);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditSlider(EditSliderDto Command)
        {
            var silder = _context.Sliders.FirstOrDefault(d => d.Id == Command.SliderId);
            if (silder == null)
                return OperationResult.NotFound();
            silder.Title=Command.Title;
            silder.Link=Command.Link;
            silder.IsActive=Command.IsActive;
            silder.DisplayOrder=Command.DisplayOrder;
            if (Command.ImageFile != null)
            {
                _fileManager.DeleteFile(silder.ImageName, Directions.SliderImage);
                silder.ImageName = _fileManager.SaveFileAndReturnName(Command.ImageFile, Directions.SliderImage);
            }
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<SliderDto> GetActiveSliders()
        {
            return _context.Sliders.Where(d => d.IsActive).OrderBy(x => x.DisplayOrder).Select(Slider => SliderMapper.MapToDto(Slider)).ToList();

        }

        public List<SliderDto> GetAllSliders()
        {
            return _context.Sliders.OrderBy(x=>x.DisplayOrder).Select(Slider =>SliderMapper.MapToDto(Slider) ).ToList();
        }

        public SliderDto GetSliderById(int sliderId)
        {
            var slider= _context.Sliders.FirstOrDefault(p => p.Id == sliderId);
            if (slider == null)
                return null;
            return SliderMapper.MapToDto(slider);
           
        }
    }
}
