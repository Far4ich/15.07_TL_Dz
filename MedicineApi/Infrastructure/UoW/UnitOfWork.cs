using MedicineApi.Infrastructure.Data;

namespace MedicineApi.Infrastructure.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly MedicineContext _ctx;

    public UnitOfWork(MedicineContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        return await _ctx.SaveEntitiesAsync(cancellationToken);
    }
}