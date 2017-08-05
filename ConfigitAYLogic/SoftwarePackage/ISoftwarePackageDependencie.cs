using System.Collections.Generic;

namespace ConfigitAYLogic
{
    public interface ISoftwarePackageDependencie
    {
        ISoftwarePackageDependencie DependOn { get; set; }

        void AddDependOn(ISoftwarePackageDependencie data);
        bool CheckDependencie(List<ISoftwarePackage> data);
        List<ISoftwarePackage> GetAllDependenciesAsList();
    }
}