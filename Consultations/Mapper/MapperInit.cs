using AutoMapper;

namespace Consultations.Mapper
{
    public class MapperInit
    {
        public static void Init(IMapperConfigurationExpression configuration)
        {
            var profiles =
                from type in typeof(MapperInit).Assembly.GetTypes()
                where type.BaseType == typeof(Profile)
                select type;
            foreach (var profile in profiles)
            {
                configuration.AddProfile(profile);
            }
        }
    }
}
