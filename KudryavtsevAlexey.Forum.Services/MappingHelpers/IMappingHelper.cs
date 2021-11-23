using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.MappingHelpers
{
    public interface IMappingHelper<T1, T2> where T1 : class where T2 : class
    {
        T1 MapModelToFirstType(T2 model);

        T2 MapModelToSecondType(T1 model);

        List<T1> MapListModelsToFirstType(IEnumerable<T2> models);

        List<T2> MapListModelsToSecondType(IEnumerable<T1> models);
    }
}
