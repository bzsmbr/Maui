using Solution.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Core.Model;

public class ManufacturerModel
{
    public uint Id { get; set; }
    
    public string Name { get; set; }

    public ManufacturerModel()
    {
    }

    public ManufacturerModel(uint id, string name)
    {
        Id = id;
        Name = name;
    }

    public ManufacturerModel(ManufacturerEntity entity)
    {
        Id = entity.Id;
        Name = entity.Name;
    }
}

