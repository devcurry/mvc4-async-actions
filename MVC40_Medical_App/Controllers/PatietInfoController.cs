using MVC40_Medical_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MVC40_Medical_App.Controllers
{
    public class PatietInfoController : Controller
    {
        //
        // GET: /PatietInfo/

        public  async Task<ActionResult> Index()
        {
            List<Task> patientTasks = new List<Task>();

            //Make Call to Radiology Service
            using (WebClient webclientRadiology = new WebClient())
            {
                Uri uriRadiology = new Uri("http://localhost:2125/Radiology.svc/Radiology");
                patientTasks.Add(webclientRadiology.DownloadStringTaskAsync(uriRadiology));
            }

            //Make Call to Pathology Service
            using (WebClient webclientPathology = new WebClient())
            {
                Uri uriPathology = new Uri("http://localhost:2119/Pathology.svc/Pathology");
                patientTasks.Add(webclientPathology.DownloadStringTaskAsync(uriPathology));
            }

            //Make Call to IPD Service
            using (WebClient webclientIPD = new WebClient())
            {
                Uri uriIPD = new Uri("http://localhost:2126/IPD.svc/IPD");
                patientTasks.Add(webclientIPD.DownloadStringTaskAsync(uriIPD));
            }

            //This is Executed when all the Asynchronous Calls are completed. 
            //This will pass the data to the new List<Task> of task 
            await Task.WhenAll(patientTasks);


            //S1: Start Working on the Result -> Radiology

            var RadiologyDetails = ((Task<string>)patientTasks[0]).Result; //The Result at index 0 in List

            XDocument xdocRadiology = XDocument.Parse(RadiologyDetails);


            var RadiologyData = from rd in xdocRadiology.Descendants("RadiologyDetails")
                                select
                                new RadiologyDetails
                                {
                                    PatientId = Convert.ToInt32(rd.Descendants("PatientId").First().Value),
                                    PatientRdiologyDetails = rd.Descendants("PatientRdiologyDetails").First().Value,
                                    RadiologyBill = Convert.ToInt32(rd.Descendants("RadiologyBill").First().Value)
                                };

            ViewBag.Radiology = RadiologyData;

            //S2: Start Working on the Result -> Pathology 

            var PathologyDetails = ((Task<string>)patientTasks[1]).Result; //The Result at index 1 in List

            XDocument xdocPathology = XDocument.Parse(PathologyDetails);

            var PathologyData = from pd in xdocPathology.Descendants("PathologyDetils")
                                select
                                new PathologyDetils()
                                {
                                    PatientId = Convert.ToInt32(pd.Descendants("PatientId").First().Value),
                                    PathologyDetails = pd.Descendants("PathologyDetails").First().Value,
                                    PathologyBill = Convert.ToInt32(pd.Descendants("PathologyBill").First().Value)
                                };

            ViewBag.Pathology = PathologyData;

            //S3: Start Working on result -> IPD
            var IPDDetails = ((Task<string>)patientTasks[2]).Result; //The Result at index 2 in List

            XDocument xdocIPD = XDocument.Parse(IPDDetails);
            var IPDData = from ipd in xdocIPD.Descendants("IPDDetails")
                          select
                        new IPDDetails()
                        {
                            PatientId = Convert.ToInt32(ipd .Descendants("PatientId").First().Value),
                            IPDCheckDetails = ipd.Descendants("IPDCheckDetails").First().Value,
                            IPDBill = Convert.ToInt32(ipd.Descendants("IPDBill").First().Value)
                        };

            ViewBag.IPD = IPDData;
            return View();
        }




    }
}
