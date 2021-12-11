using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITagService
{
    Task<TagDto> GetTagById(int id);

    Task<List<TagDto>> GetAllTags();

    Task CreateTag(CreateTagDto tagDto);

    Task UpdateTag(int id, UpdateTagDto tagDto);

    Task DeteteTag(int id);
}