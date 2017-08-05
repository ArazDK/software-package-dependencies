using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigitAYLogic
{
    /// <summary>
    /// Software Package BL
    /// </summary>
    public class SoftwarePackageBL
    {
        public List<ISoftwarePackage> Packages { get; set; }
        public List<ISoftwarePackageDependencie> Dependencies { get; set; }

        /// <summary>
        /// Check if all logic is correct
        /// </summary>
        /// <returns>True if passed or not</returns>
        public bool Check()
        {
            bool retuenValue = false;

            if (Dependencies == null || Dependencies.Count == 0)
            {
                return true;
            }

            //If more than one version of a package is required the installation is invalid.
           if( CheckMultiVersionFound())
            {
                return false;
            }
            //Your task is            to check if installing the packages (along with all packages required by dependencies) is   valid.
            foreach (var item in Dependencies)
            {
                if (!retuenValue)
                {
                    retuenValue =     item.CheckDependencie(Packages);

                 //   retuenValue = Packages.All(p=> item.Exists(q=>q.PackageName == p.PackageName && q.PackageVersion == p.PackageVersion));
                }
            }

            return retuenValue;
        }

        /// <summary>
        /// Do a list and check for multi versions
        /// </summary>
        /// <returns>true if found multi versions</returns>
        private bool CheckMultiVersionFound()
        {
            bool retuenValue = false;

            //Find all Dependencies 
            List<ISoftwarePackage> tAll = new List<ISoftwarePackage>();
          
           foreach (var item in Dependencies)
            {
                tAll.AddRange(item.GetAllDependenciesAsList());
            }

           //Find distinct name
            var queryPackageName = (from o in tAll
                         select new
                         {
                             o.PackageName
                         }).Distinct();


            //Find distinct name
            foreach (var item in queryPackageName)
            {

                //Find versionsno
                var queryPackageVersion = (from o in tAll.FindAll(p=>p.PackageName == item.PackageName)
                                        select new
                                        {
                                            o.PackageVersion
                                        }).Distinct();

                //If more than one, multi versions. File not valid
                if (queryPackageVersion.Count()>1)
                {
                    return true;
                }
            }           
            return retuenValue;
        }
    }
}
