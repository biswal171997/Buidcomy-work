﻿using BUIDCO.Domain.AdminConsole.ProjectLink;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.ProjectLink
{
    public interface IProjectLinkServiceProvider
    {
        string AddProjectLink(Project objProjectlink);
        Task<ViewProjectLink> GetAllActiveProjectLink();
        Task<ViewProjectLink> GetAllInActiveProjectLink();
        string InactiveProjectLink(int id, int updatedby);
        string ActiveProjectLink(int id, int updatedby);
        Task<ViewProjectLink> GetById(int id);
        string UpdateProjectLink(Project objProjectlink);

    }
}
