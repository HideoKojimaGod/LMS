using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Material
    {
        string materialName;
        string materialPath;

        public Material(string name, string path)
        {
            materialName = name;
            materialPath = path;
        }
        public string GetMaterialName()
        {
            return materialName;
        }
        public void SetMaterialName(string name)
        {
            materialName = name;
        }
        public string GetMaterialPath()
        {
            return materialPath;
        }
        public void SetMaterialPath(string path)
        {
            materialPath = path;
        }

    }
}
