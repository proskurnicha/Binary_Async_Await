using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface IParceService
    {
        Task<List<CrewByApiDto>> GetCrews();
    }
}
