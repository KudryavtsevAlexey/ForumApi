using KudryavtsevAlexey.Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record SubscriberDto(
        int Id,
        string UserName,
        string Name,
        int OrganizationId,
        OrganizationDto Organization,
        List<UserDto> Users,
        string ImageUrl) : BaseDto(Id);
}
