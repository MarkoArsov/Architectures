using Commmon.Result;
using Domain.Entities;


namespace Infrastructure.Repositories.Interfaces
{
    public interface IPropertyListingRepository
    {
        Task<Result<IEnumerable<PropertyListing>>> GetAllAsync();

        Task<Result<PropertyListing>> GetByIdAsync(int id);

        void Add(PropertyListing property);

        void Update(PropertyListing property);

        void Delete(PropertyListing property);
    }

}
