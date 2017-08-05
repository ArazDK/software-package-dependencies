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
    public class SoftwarePackageDependencie : SoftwarePackage, ISoftwarePackageDependencie
    {
        public ISoftwarePackageDependencie DependOn { get; set; }

        public void AddDependOn(ISoftwarePackageDependencie data)
        {
            if (DependOn == null)
            {
                DependOn = data;
            }
            else
            {
                DependOn.AddDependOn(data);
            }
        }
        /// <summary>
        /// REcursive Check for Dependency
        /// </summary>
        /// <param name="data">List of packaged</param>
        /// <returns></returns>
        public bool CheckDependencie(List<ISoftwarePackage> data)
        {
            bool returnValue = true;

            for (int i = 0; i < data.Count; i++)
            {
                ISoftwarePackage tData = data[i];

                if (PackageName == tData.PackageName && PackageVersion == tData.PackageVersion)
                {
                    List<ISoftwarePackage> tList = new List<ISoftwarePackage>(data);
                    tList.RemoveAt(i);
                    returnValue = DependOn.CheckDependencie(tList);
                }
                else
                {
                    returnValue = false;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Get all children
        /// </summary>
        /// <returns>List of all children</returns>
        public List<ISoftwarePackage> GetAllDependenciesAsList()
        {
            List<ISoftwarePackage> tList = new List<ISoftwarePackage>();

            if (DependOn !=null)
            {
                tList.AddRange(DependOn.GetAllDependenciesAsList());
            }

            tList.Add(new SoftwarePackage() { PackageName = this.PackageName, PackageVersion = this.PackageVersion });

            return tList;
        }
    }
}
