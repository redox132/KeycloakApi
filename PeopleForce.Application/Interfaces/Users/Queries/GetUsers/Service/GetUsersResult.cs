using System;

namespace PeopleForce.Application.Interfaces.Users.Queries.GetUsers.Service;

public record GetUsersResult(Guid Id, string Name, string Email);