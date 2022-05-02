using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile);
    }
}
