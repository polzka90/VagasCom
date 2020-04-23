using System;
using System.Collections.Generic;
using System.Text;
using VagasCom.Domain.Models;

namespace VagasCom.Domain.Interfaces.Services
{
    public interface IApplicationsService
    {
        bool ApplicationInsert(Application application);
    }
}
