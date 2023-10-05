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

		[Fact]
		public async Task Should_DeleteByIdRealEstate_whenDeleteRealEstate()
		{

			RealEstateDto realEstate = MockRealEstateData();

			var addRealEstate = await Svc<IRealEstatesServices>().Create(realEstate);
			var result = await Svc<IRealEstatesServices>().Delete((Guid)addRealEstate.Id);


			Assert.Equal(result, addRealEstate);
		}


		[Fact]
		public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteREalEstate()
		{
			RealEstateDto realEstate = MockRealEstateData();

			var realEstate1 = await Svc<IRealEstatesServices>().Create(realEstate);
			var realEstate2 = await Svc<IRealEstatesServices>().Create(realEstate);

			var result = await Svc<IRealEstatesServices>().Delete((Guid)realEstate2.Id);

			Assert.NotEqual(result.Id, realEstate1.Id);

		}



		[Fact]
		public async Task Should_UpdateRealEstate_WhenUpdateData()
		{
			//vaja luua guid, mida hakkame kasutama update puhul

			var guid = new Guid("4978d0a4-6357-11ee-8c99-0242ac120002");

			RealEstateDto dto = MockRealEstateData();

			//vaja saada domainist andmed kätte
			//kasutam domaini andmeid
			RealEstateDto realEstate = new();

			realEstate.Id = Guid.Parse("4978d0a4-6357-11ee-8c99-0242ac120002");
			realEstate.Address = "Address123";
			realEstate.SizeSqrM = 890;
			realEstate.RoomCount = 9;
			realEstate.Floor = 9;
			realEstate.BuildingType = "qwerty";
			realEstate.BuiltInYear = DateTime.Now.AddYears(1);

			await Svc<IRealEstatesServices>().Update(dto);

			Assert.Equal(realEstate.Id, guid);
			Assert.DoesNotMatch(realEstate.Address, dto.Address);
			Assert.DoesNotMatch(realEstate.Floor.ToString(), dto.Floor.ToString());
			Assert.Equal(realEstate.RoomCount, dto.RoomCount);
		}

		[Fact]
		public async Task Should_UpdateRealEstate_WhenUpdateDataVersion2()
		{
			RealEstateDto dto = MockRealEstateData();
			var createRealEstate = await Svc<RealEstatesServices>().Create(dto);

			RealEstateDto update = MockRealEstateData();
			var result = await Svc<IRealEstatesServices>().Update(update);

			Assert.DoesNotMatch(result.Address, createRealEstate.Address);
			Assert.NotEqual(result.UpdatedAt, createRealEstate.UpdatedAt);
			Assert.Equal(result.CreatedAt, createRealEstate.CreatedAt);
		}


		private RealEstateDto MockRealEstateData()
		{
			RealEstateDto realEstate = new()
			{
				Address = "asd",
				SizeSqrM = 123,
				RoomCount = 5,
				Floor = 4,
				BuildingType = "asd",
				BuiltInYear = DateTime.Now,
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
			};
			return realEstate;
		}

		private RealEstateDto MockUpdateRealEstateData()
		{
			RealEstateDto realEstate = new()
			{
				Address = "asdasd",
				SizeSqrM = 123123,
				RoomCount = 55,
				Floor = 33,
				BuildingType = "asd",
				BuiltInYear = DateTime.Now.AddYears(1),
				CreatedAt = DateTime.Now.AddYears(1),
				UpdatedAt = DateTime.Now.AddYears(1),
			};
			return realEstate;
		}
}