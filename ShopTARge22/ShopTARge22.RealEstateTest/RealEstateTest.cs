using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;

namespace ShopTARge22.RealEstateTest
{
	public class RealEstateTest : TestBase
	{
		public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
		{
			RealEstateDto realEstate = new();

			realEstate.Address = "asd";
			realEstate.SizeSqrM = 1024;
			realEstate.RoomCount = 5;
			realEstate.Floor = 3;
			realEstate.BuildingType = "asd";
			realEstate.BuiltInYear = DateTime.Now;
			realEstate.CreatedAt = DateTime.Now;
			realEstate.UpdatedAt = DateTime.Now;

			var result = await Svc<IRealEstatesServices>().Create(realEstate);

		}
	}
}
