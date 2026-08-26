using PeopleForce.Application.Interfaces.Users.Queries.GetUsers.Service;

namespace PeopleForce.Api.Controllers.Users.Queries.GetUsers;

public record GetUsersResponse( List<GetUsersResult> Users);