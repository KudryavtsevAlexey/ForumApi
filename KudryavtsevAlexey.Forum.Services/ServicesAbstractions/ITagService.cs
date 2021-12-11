using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITagService
{
    Task<TagDto> GetTagById(int tagId);

    Task<List<TagDto>> GetAllTags();

    Task CreateTag(CreateTagDto tagDto);

    Task UpdateTag(int tagId, UpdateTagDto tagDto);

    Task DeteteTag(int tagId);
}