using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigitAYLogic
{
    /// <summary>
    /// Software package
    /// </summary>
    public class SoftwarePackage : ISoftwarePackage
    {
        public string PackageName { get; set; }
        public string PackageVersion { get; set; }

    }
}
