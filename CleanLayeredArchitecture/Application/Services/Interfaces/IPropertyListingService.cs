using Application.Dtos;
using Commmon.Result;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IPropertyListingService
    {
        public Task<Result<IEnumerable<PropertyListing>>> GetAllAsync();

        public Task<Result<PropertyListing>> GetByIdAsync(int id);

        public Task<Result<PropertyListing>> AddAsync(PropertyListingDto property);

        public Task<Result<PropertyListing>> UpdateAsync(PropertyListingDto property);

        public Task<Result<PropertyListing>> DeleteAsync(int id);
    }
}
