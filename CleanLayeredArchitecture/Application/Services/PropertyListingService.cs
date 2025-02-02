using Application.Dtos;
using Application.Factories.Interfaces;
using Application.Services.Interfaces;
using Commmon.Result;
using Domain.Entities;
using Infrastructure.UnitOfWork.Interfaces;

namespace Application.Services
{
    public class PropertyListingService : IPropertyListingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPropertyListingFactory _propertyListingFactory;

        public PropertyListingService(IUnitOfWork unitOfWork, IPropertyListingFactory propertyListingFactory)
        {
            _unitOfWork = unitOfWork;
            _propertyListingFactory = propertyListingFactory;
        }

        public async Task<Result<IEnumerable<PropertyListing>>> GetAllAsync()
        {
            return await _unitOfWork.PropertyListings.GetAllAsync();
        }

        public async Task<Result<PropertyListing>> GetByIdAsync(int id)
        {
            return await _unitOfWork.PropertyListings.GetByIdAsync(id);
        }

        public async Task<Result<PropertyListing>> AddAsync(PropertyListingDto dto)
        {
            var propertyResult = _propertyListingFactory.Create(dto.Id, dto.Title, dto.Description, dto.Price);

            if (!propertyResult.Success)
            {
                return Result<PropertyListing>.FailureResult(propertyResult.Error);
            }

            _unitOfWork.PropertyListings.Add(propertyResult.Value);
            await _unitOfWork.CommitAsync();

            return Result<PropertyListing>.SuccessResult(propertyResult.Value);
        }

        public async Task<Result<PropertyListing>> UpdateAsync(PropertyListingDto dto)
        {
            var propertyResult = _propertyListingFactory.Create(dto.Id, dto.Title, dto.Description, dto.Price);

            if (!propertyResult.Success)
            {
                return Result<PropertyListing>.FailureResult(propertyResult.Error);
            }

            _unitOfWork.PropertyListings.Update(propertyResult.Value);
            await _unitOfWork.CommitAsync();

            return Result<PropertyListing>.SuccessResult(propertyResult.Value);
        }

        public async Task<Result<PropertyListing>> DeleteAsync(int id)
        {
            var propertyResult = await _unitOfWork.PropertyListings.GetByIdAsync(id);

            if (!propertyResult.Success)
            {
                return Result<PropertyListing>.FailureResult(propertyResult.Error);
            }

            _unitOfWork.PropertyListings.Delete(propertyResult.Value);
            await _unitOfWork.CommitAsync();

            return Result<PropertyListing>.SuccessResult(propertyResult.Value);
        }
    }

}
