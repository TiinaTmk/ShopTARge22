using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge22.SpaceshipTest;
using ShopTARge22.ApplicationServices.Services;


using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;

namespace ShopTARge22.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()

        {   //Arrange
            SpaceshipDto spaceship = new();

            spaceship.Name = "asd";
            spaceship.Type = "1024";
            spaceship.BuiltDate = DateTime.Now;
            spaceship.Passengers = 5;
            spaceship.CargoWeight = 3;
            spaceship.Crew = 5;
            spaceship.EnginePower = 5;


            //Act
            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            //Assert
            Assert.NotNull(result);

        }



        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            //Arrange
            //Küsime realestate, mida ei ole olemas

            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("4978d0a4-6357-11ee-8c99-0242ac120002");


            //Act
            //peame kutsuma esile meetodi, mis on realEstateService classis

            await Svc<ISpaceshipsServices>().DetailsAsync(guid);

            //Assert
            //assertimise võrdlus, et võrrelda kahte huidi
            Assert.NotEqual(wrongGuid, guid);

        }

        [Fact]
        public async Task Should_GetByIdSpaceship_WhenReturnsEqual()
        {
            // Arrange
            Guid databaseGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("4978d0a4-6357-11ee-8c99-0242ac120002");


            // Act
            await Svc<ISpaceshipsServices>().DetailsAsync(guid);

            // Assert
            Assert.Equal(databaseGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_whenDeleteSpaceship()
        {

            SpaceshipDto spaceship = MockSpaceshipData();

            var addSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
            var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship.Id);


            Assert.Equal(result, addSpaceship);
        }


        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDto spaceship = MockSpaceshipData();

            var spaceship1 = await Svc<ISpaceshipsServices>().Create(spaceship);
            var spaceship2 = await Svc<ISpaceshipsServices>().Create(spaceship);

            var result = await Svc<ISpaceshipsServices>().Delete((Guid)spaceship2.Id);

            Assert.NotEqual(result.Id, spaceship1.Id);

        }



        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            //vaja luua guid, mida hakkame kasutama update puhul

            var guid = new Guid("4978d0a4-6357-11ee-8c99-0242ac120002");

            SpaceshipDto dto = MockSpaceshipData();

            //vaja saada domainist andmed kätte
            //kasutam domaini andmeid
            SpaceshipDto spaceship = new();

            spaceship.Id = Guid.Parse("4978d0a4-6357-11ee-8c99-0242ac120002");
            spaceship.Name = "asd";
            spaceship.Type = "1024";
            spaceship.BuiltDate = DateTime.Now.AddYears(1);
            spaceship.Passengers = 5;
            spaceship.CargoWeight = 3;
            spaceship.Crew = 5;
            spaceship.EnginePower = 5;



            await Svc<ISpaceshipsServices>().Update(dto);

            Assert.Equal(spaceship.Id, guid);
            Assert.DoesNotMatch(spaceship.Name, dto.Name);
            Assert.DoesNotMatch(spaceship.Type.ToString(), dto.Type.ToString());
            Assert.Equal(spaceship.CargoWeight, dto.CargoWeight);
        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateDataVersion2()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<SpaceshipsServices>().Create(dto);

            SpaceshipDto update = MockSpaceshipData();
            var result = await Svc<ISpaceshipsServices>().Update(update);

            Assert.DoesNotMatch(result.Name, createSpaceship.Name);
            Assert.NotEqual(result.ModifiedAt, createSpaceship.ModifiedAt);
            //Assert.Equal(result.CreatedAt, createRealEstate.CreatedAt);
        }




        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var createSpaceship = await Svc<ISpaceshipsServices>().Create(dto);

            SpaceshipDto nullUpdate = MockNullSpaceship();
            var result = await Svc<ISpaceshipsServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);

        }





        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Name = "asd",
                Type = "123",
                BuiltDate = DateTime.Now,
                Passengers = 5,
                CargoWeight = 4,
                Crew = 3,
                EnginePower = 5
        };
            return spaceship;
        }


    private SpaceshipDto MockUpdateSpaceshipData()
    {
        SpaceshipDto spaceship = new()
        {

            Name = "asd",
            Type = "123",
            BuiltDate = DateTime.Now.AddYears(1),
            Passengers = 5,
            CargoWeight = 4,
            Crew = 3,
            EnginePower = 5
        };
        return spaceship;
    }

    private SpaceshipDto MockNullSpaceship()
    {
        SpaceshipDto nullDto = new()
        {
            Id = null,
            Name = "asd",
            Type = "123",
            BuiltDate = DateTime.Now.AddYears(-1),
            Passengers = 5,
            CargoWeight = 4,
            Crew = 3,
            EnginePower = 5
        };
            return nullDto;
        }
    }
}
        
    


