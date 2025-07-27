using AutoMapper;
using EvoltisChallenge.Api.Domain.Interfaces;
using EvoltisChallenge.Api.Infraestructure.dbEntities.Interfaces;

namespace EvoltisChallenge.Api.Infraestructure;

public abstract class Repository<TDomainModel, TDomainId, TEntityModel, TEntityId>(
    IMapper autoMapper)
    where TEntityModel : class, IEntity<TEntityId>
    where TDomainModel : class, IDomainEntity<TDomainId>
{
    private readonly IMapper _autoMapper = autoMapper;

    protected virtual TDomainModel? MapToDomainModel(TEntityModel? entityModel) =>
        entityModel is null ? null : _autoMapper.Map<TEntityModel?, TDomainModel?>(entityModel);

    protected virtual TEntityModel MapToEntityModel(TDomainModel domainModel) =>
        _autoMapper.Map<TDomainModel, TEntityModel>(domainModel);

    protected virtual IEnumerable<TDomainModel> MapToDomainModel(IEnumerable<TEntityModel> entityModel) =>
        entityModel is null ? [] : _autoMapper.Map<IEnumerable<TDomainModel>>(entityModel);

    protected virtual IEnumerable<TEntityModel> MapToEntityModel(IEnumerable<TDomainModel> domainModel) =>
        _autoMapper.Map<IEnumerable<TDomainModel>, IEnumerable<TEntityModel>>(domainModel);
}

public abstract class Repository<TDomainModel, TEntityModel, TId>(
    IMapper autoMapper)
    : Repository<TDomainModel, TId, TEntityModel, TId>(autoMapper)
    where TEntityModel : class, IEntity<TId>
    where TDomainModel : class, IDomainEntity<TId>
{
}
