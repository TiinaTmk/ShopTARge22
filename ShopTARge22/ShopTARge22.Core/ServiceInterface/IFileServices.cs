using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship spaceship);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
		Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);  
		void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain);


    }
}
