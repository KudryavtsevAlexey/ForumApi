using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    public class TagService : ITagService
    {
        private readonly ForumDbContext _dbContext;
        private readonly IMapper _mapper;

        public TagService(ForumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TagDto> GetTagById(int tagId)
        {
            var tag = await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == tagId);

            if (tag is null)
            {
                throw new TagNotFoundException(tagId);
            }

            var tagDto = _mapper.Map<TagDto>(tag);

            return tagDto;
        }

        public async Task<List<TagDto>> GetAllTags()
        {
            var tags = await _dbContext.Tags.ToListAsync();

            var tagsDtos = _mapper.Map<List<TagDto>>(tags);

            return tagsDtos;
        }

        public async Task CreateTag(CreateTagDto tagDto)
        {
            var tag = _mapper.Map<Tag>(tagDto);

            await _dbContext.Tags.AddAsync(tag);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTag(int tagId, UpdateTagDto tagDto)
        {
            var tag = await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == tagId);

            if (tag is null)
            {
                throw new TagNotFoundException(tagId);
            }

            tag.Name = tagDto.Name;

            _dbContext.Tags.Update(tag);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeteteTag(int tagId)
        {
            var tag = await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == tagId);

            if (tag is null)
            {
                throw new TagNotFoundException(tagId);
            }

            _dbContext.Tags.Remove(tag);
            await _dbContext.SaveChangesAsync();
        }
    }
}
