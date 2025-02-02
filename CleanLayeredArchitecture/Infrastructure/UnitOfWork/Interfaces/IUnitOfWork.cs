using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IPropertyListingRepository PropertyListings { get; }

        public Task<int> CommitAsync();
    }
}
