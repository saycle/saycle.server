using AutoMapper;
using saycle.server.Models;
using saycle.server.ViewModels.Story;
using saycle.server.ViewModels.User;

namespace saycle.server.Handlers
{
    /// <summary>
    /// MappingProfile to map between ViewModels and Model-entities.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Configure all mappings directions.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<CreateUserViewModel, User>();
            CreateMap<CreateStoryViewModel, Story>();
        }
    }
}
