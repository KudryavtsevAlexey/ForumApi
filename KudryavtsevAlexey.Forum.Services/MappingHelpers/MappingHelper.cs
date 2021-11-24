using System.Collections.Generic;
using AutoMapper;
using KudryavtsevAlexey.Forum.Services.ServiceManager;

namespace KudryavtsevAlexey.Forum.Services.MappingHelpers
{
    public static class MappingHelper
    {
        public static T1 MapModelToFirstType<T1,T2>(T2 model, IMapper mapper) where T1 : class where T2:class
        {
            return mapper.Map<T1>(model);
        }

        public static T2 MapModelToSecondType<T1,T2>(T1 model, IMapper mapper) where T1 : class where T2 : class
        {
            return mapper.Map<T2>(model);
        }

        public static List<T1> MapListModelsToFirstType<T1,T2>(IEnumerable<T2> models, IMapper mapper) where T1 : class where T2 : class
        {
            List<T1> mappedModels = new List<T1>();

            foreach (var model in models)
            {
                mappedModels.Add(mapper.Map<T1>(model));
            }

            return mappedModels;
        }

        public static List<T2> MapListModelsToSecondType<T1, T2>(IEnumerable<T1> models, IMapper mapper) where T1 : class where T2 : class
        {
            List<T2> mappedModels = new List<T2>();

            foreach (var model in models)
            {
                mappedModels.Add(mapper.Map<T2>(model));
            }

            return mappedModels;
        }
    }
}
