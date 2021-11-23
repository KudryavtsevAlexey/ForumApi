using System.Collections.Generic;
using AutoMapper;

namespace KudryavtsevAlexey.Forum.Services.MappingHelpers
{
    public class MappingHelper<T1, T2> : IMappingHelper<T1, T2> where T1 : class where T2 : class
    {
        private readonly IMapper _mapper;

        public MappingHelper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public T1 MapModelToFirstType(T2 model)
        {
            return _mapper.Map<T1>(model);
        }

        public T2 MapModelToSecondType(T1 model)
        {
            return _mapper.Map<T2>(model);
        }

        public List<T1> MapListModelsToFirstType(IEnumerable<T2> models)
        {
            List<T1> mappedModels = new List<T1>();

            foreach (var model in models)
            {
                mappedModels.Add(_mapper.Map<T1>(model));
            }

            return mappedModels;
        }

        public List<T2> MapListModelsToSecondType(IEnumerable<T1> models)
        {
            List<T2> mappedModels = new List<T2>();

            foreach (var model in models)
            {
                mappedModels.Add(_mapper.Map<T2>(model));
            }

            return mappedModels;
        }
    }
}
