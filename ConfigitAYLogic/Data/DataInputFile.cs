using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigitAYLogic
{
   public class DataInputFile : IDisposable, IDataInput
    {

       public SoftwarePackageBL GetData(string path)
        {
            SoftwarePackageBL returnValue = new SoftwarePackageBL();

            if (File.Exists(path))
            {

                int SoftwarePackageNo = int.Parse(File.ReadAllLines(path).Take(1).First());

                returnValue.Packages = GetSoftwarePackage(File.ReadAllLines(path).Skip(1).Take(SoftwarePackageNo).Select(l => l.Split(',')).ToArray());
                try
                {

              
                int SoftwarePackageDependenciesNo = int.Parse(File.ReadAllLines(path).Skip(SoftwarePackageNo + 1).Take(1).First());

                returnValue.Dependencies = GetSoftwarePackageDependencies(File.ReadAllLines(path).Skip(SoftwarePackageNo + 2).Take(SoftwarePackageDependenciesNo).ToArray());
  }
                catch (Exception)
                {
                    
                }
            }
            else
            {
                throw new FileNotFoundException(path + " not found");
            }
            return returnValue;
        }

        private List<ISoftwarePackageDependencie> GetSoftwarePackageDependencies(string[] lines)
        {
            List<ISoftwarePackageDependencie> retuenValue = new List<ISoftwarePackageDependencie>();

            foreach (var item in lines)
            {
                string[] data = item.Split(',');

                if (data != null && data.Length > 1)
                {
                    SoftwarePackageDependencie tmpValue = null;
                    for (int j = 0; j < data.Length; j = j + 2)
                    {
                        if (!string.IsNullOrEmpty(data[j]))
                        {
                            SoftwarePackageDependencie tData = new SoftwarePackageDependencie() { PackageName = data[j], PackageVersion = data[j + 1] };
                            if (tmpValue == null)
                            {
                                tmpValue =tData;
                            }
                            else
                            {
                                tmpValue.AddDependOn(tData);
                            }
                        }
                    }

                   
                    retuenValue.Add(tmpValue);
                }
            }
            return retuenValue;
        }

        private List<ISoftwarePackage> GetSoftwarePackage(string[][] data)
        {
            List<ISoftwarePackage> retuenValue = new List<ISoftwarePackage>();
            if (data != null && data.Length > 0)
            {

                for (int i = 0; i < data.Length; i++)
                {
                    string name = data[i][0];
                    if (data[i].Length > 1)
                    {

                        for (int j = 1; j < data[i].Length; j++)
                        {
                            if (!string.IsNullOrEmpty(data[i][j]))
                            {
                                retuenValue.Add(new SoftwarePackage() { PackageName = name, PackageVersion = data[i][j] });
                            }
                        }
                    }
                }
            }
            return retuenValue;
        }



        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DataInput() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
