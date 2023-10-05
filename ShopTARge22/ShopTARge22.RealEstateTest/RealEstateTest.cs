using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge22.ApplicationServices.Services;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;

namespace ShopTARge22.RealEstateTest
{
	public class RealEstateTest : TestBase
	{
		public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()

		{   //Arrange
			RealEstateDto realEstate = new();

			realEstate.Address = "asd";
			realEstate.SizeSqrM = 1024;
			realEstate.RoomCount = 5;
			realEstate.Floor = 3;
			realEstate.BuildingType = "asd";
			realEstate.BuiltInYear = DateTime.Now;
			realEstate.CreatedAt = DateTime.Now;
			realEstate.UpdatedAt = DateTime.Now;

			//Act
			var result = await Svc<IRealEstatesServices>().Create(realEstate);

			//Assert
			Assert.NotNull(result);

		}
		[Fact]
		public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
		{
			//Arrange
			//Küsime realestate, mida ei ole olemas

			Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
			Guid guid = Guid.Parse("4978d0a4-6357-11ee-8c99-0242ac120002");


			//Act
			//peame kutsuma esile meetodi, mis on realEstateService classis

			await Svc<IRealEstatesServices>().DetailsAsync(guid);

			//Assert
			//assertimise võrdlus, et võrrelda kahte huidi
			Assert.NotEqual(wrongGuid, guid);

		}

		[Fact]
		public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
		{
			// Arrange
			Guid databaseGuid = Guid.Parse(Guid.NewGuid().ToString());
			Guid guid = Guid.Parse("4978d0a4-6357-11ee-8c99-0242ac120002");


			// Act
			await Svc<IRealEstatesServices>().DetailsAsync(guid);

			// Assert
			Assert.Equal(databaseGuid, guid);
		}
	}
}