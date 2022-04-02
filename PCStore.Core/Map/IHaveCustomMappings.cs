using AutoMapper;

namespace PCStore.Core.Map
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
