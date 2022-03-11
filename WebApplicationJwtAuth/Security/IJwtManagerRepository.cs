using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationJwtAuth.Models;

namespace WebApplicationJwtAuth.Security
{
    public interface IJwtManagerRepository
    {
        Token Authenticate(User users);
    }
}
