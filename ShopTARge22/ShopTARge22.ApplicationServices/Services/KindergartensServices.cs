using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;
using System;
using System.Threading.Tasks;

namespace ShopTARge22.ApplicationServices.Services
{
    public class KindergartensServices : IKindergartensServices
    {
        private readonly ShopTARge22Context _context;


        public KindergartensServices(ShopTARge22Context context)
        {
            _context = context;
        }



        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            // Create a new Kindergarten instance
            Kindergarten kindergarten = new Kindergarten
            {

                Id = Guid.NewGuid(),
                GroupName = dto.GroupName,
                ChildrenCount = dto.ChildrenCount,
                KindergartenName = dto.KindergartenName,
                Teacher = dto.Teacher,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            // Add the new Kindergarten to the context and save changes
            _context.Kindergartens.Add(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }


        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            // Retrieve the existing Kindergarten by Id
            Kindergarten kindergarten = await _context.Kindergartens.FindAsync(dto.Id);

            if (kindergarten == null)
            {
                return null; // Kindergarten not found, handle appropriately
            }

            // Update properties from the DTO
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.Teacher = dto.Teacher;
            kindergarten.CreatedAt = dto.CreatedAt;
            kindergarten.UpdatedAt = DateTime.Now;

            // Update the Kindergarten entity in the context and save changes
            _context.Kindergartens.Update(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }




        public async Task<Kindergarten> DetailsAsync(Guid id)
        {
            var result = await _context.Kindergartens.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Kindergarten> Delete(Guid id)
        {
            // Retrieve the Kindergarten to be deleted
            var kindergarten = await _context.Kindergartens.FindAsync(id);

            if (kindergarten == null)
            {
                return null; // Kindergarten not found, handle appropriately
            }

            // Remove the Kindergarten entity from the context and save changes
            _context.Kindergartens.Remove(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }
    }
}
    