using GiftBagOfBases.Commands;
using System;

namespace GiftBagOfBases.Interfaces.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}