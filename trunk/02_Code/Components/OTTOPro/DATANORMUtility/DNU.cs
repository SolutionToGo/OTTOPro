using dcm.Trinity.Definition;
using dcm.Trinity.SDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATANORMUtility
{
    public static class DNU
    {
        public static DataSet ProccessFile(string SourceFilePath,string AppDataPath)
        {
            DataSet ds = new DataSet();
            try
            {
                string FileName = Path.GetFileNameWithoutExtension(SourceFilePath);
                var resultFile = AppDataPath + "\\" + FileName + ".xml";
                //Validating Datanorm file
                var adapterType = InferAdapterFromFile(SourceFilePath);
                var factory = new AdapterFactory(@"C:\Program Files (x86)\datacrossmedia\trinity6\moduls");
                var adapter = factory.CreateAdapter(adapterType);
                //Authenticate license
                AuthorizeAdapter(adapter);
                //Attaching Event Handlers
                AttachEventHandlers(adapter);
                //Proccessing file
                adapter.Run(SourceFilePath, resultFile);
                ds.ReadXml(resultFile);
            }
            catch (AdapterFailureException ex){throw ex;}
            catch(Exception ex) { throw ex; }
            return ds;
        }

        /// <summary>
        ///  Code to identify DataNorm file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static TrinityAdapter InferAdapterFromFile(string path)
        {
            try
            {
                var normIdentifier = new dcm.NormIdentifyLib.NormIdentifier();
                var normInfo = normIdentifier.IdentifyNorm(path);
                if (normInfo.Norm != dcm.NormIdentifyLib.Norm.DATANORM)
                    throw new ArgumentException("Not a DATANORM file");
                switch (normInfo.Version)
                {
                    case "3": return TrinityAdapter.ImportDN3;
                    case "4": return TrinityAdapter.ImportDN4;
                    case "5": return TrinityAdapter.ImportDN5;
                    default: throw new InvalidOperationException("Not a known DATANORM version");
                }
            }
            catch (Exception ex){throw ex;}
        }

        /// <summary>
        /// Code to authorize the license
        /// </summary>
        /// <param name="adapter"></param>
        private static void AuthorizeAdapter(Adapter adapter)
        {
            try
            {
                var authorizer = new AdapterAuthorizer("betasystems+fz/TD22vq%X:VMbb58W@");
                authorizer.Authorize(adapter);
            }
            catch (Exception ex){throw ex;}
        }

        /// <summary>
        ///  Code to attach event handlers
        /// </summary>
        /// <param name="adapter"></param>
        private static void AttachEventHandlers(Adapter adapter)
        {
            try
            {
                adapter.ProgressChanged += (sender, e) =>
                              Console.WriteLine("{0} of {1}", e.Current, e.Maximum);

                adapter.UserLog.LineWritten += (sender, e) =>
                  Console.WriteLine("(at {0}): {1}", e.Timestamp, e.Text);
            }
            catch (Exception ex){throw ex;}
        }
    }
}