using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structure_BLL.Services
{
    public class FormatterForCrewService
    {
        public string ToCsv(CrewByApiDto crew)
        {
            string result = crew.Id + "," + crew.Pilot[0].Id + "," + crew.Pilot[0].BirthDate + ","
                + crew.Pilot[0].CrewId + "," + crew.Pilot[0].Exp + ","
                 + crew.Pilot[0].FirstName + "," + crew.Pilot[0].LastName;
            string stewardessId = "";
            foreach (var stewardess in crew.Stewardess)
            {
                stewardessId += "," + stewardess.Id;
            }
            result += stewardessId + "\n";
            return result;
        }
    }
}
