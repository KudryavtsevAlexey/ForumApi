using KudryavtsevAlexey.Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;

namespace KudryavtsevAlexey.Forum.Services.Dtos.User
{
    public record SubscriberDto(
        int Id,
        string UserName,
        string Name,
        int OrganizationId,
        OrganizationDto Organization,
        List<ApplicationUserDto> Users,
        string ImageUrl) : BaseDto(Id);
}
