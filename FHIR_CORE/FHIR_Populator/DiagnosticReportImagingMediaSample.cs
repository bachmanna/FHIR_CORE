using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;

namespace FHIR_CORE
{
    //The DiagnosticReportImagingMediaSample class populates, validates, parse and serializes Clinical Artifact - DiagnosticReport Imaging Media
    class DiagnosticReportImagingMediaSample
    {
        //public static void Main()
        //{
        //    try
        //    {
        //        string strErrOut = "";
        //        Console.WriteLine("Inside DiagnosticReportImagingMediaSample");
        //        fnDiagnosticReportImagingMediaSample(ref strErrOut);
        //        Console.ReadKey();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("DiagnosticReportImagingMediaSample ERROR:---" + e.Message);
        //    }

        //}
        static bool fnDiagnosticReportImagingMediaSample(ref string strError_OUT)
        {
            bool blnReturn = true;
            try
            {
                Bundle diagnosticReportImagingMediaBundle = new Bundle();
                diagnosticReportImagingMediaBundle = populateDiagnosticReportImagingMediaBundle();

                string strErr_OUT = "";
                bool isValid = ResourcePopulator.ValidateProfile(diagnosticReportImagingMediaBundle, ref strErr_OUT);
                //   isValid = true;
                if (isValid != true)
                {
                    Console.WriteLine(strErr_OUT);
                }
                else
                {
                    Console.WriteLine("Validated populated DiagnosticReportImagingMedia bundle successfully");
                    bool isProfileCreated = ResourcePopulator.seralize_WriteFile("diagnosticReportImagingMediaBundle.json", diagnosticReportImagingMediaBundle);
                    if (isProfileCreated == false)
                    {
                        Console.WriteLine("Error in Profile File creation");
                    }
                    else
                    {
                        Console.WriteLine("Success");
                    }
                }
                strError_OUT = "";
                return blnReturn;
            }
            catch (Exception ex)
            {
                blnReturn = false;
                strError_OUT = ex.ToString();
                return blnReturn;
            }
        }
        static Bundle populateDiagnosticReportImagingMediaBundle()
        {
            // Set metadata about the resource            
            Bundle diagnosticReportBundle = new Bundle()
            {
                // Set logical id of this artifact
                Id = "DiagnosticReport-Imaging-Media-02",
                Meta = new Meta()
                {
                    VersionId = "1",
                    LastUpdatedElement = new Instant(new DateTimeOffset(2020, 07, 09, 15, 32, 26, new TimeSpan(1, 0, 0))),
                    Profile = new List<string>()
                    {
                      "https://nrces.in/ndhm/fhir/r4/StructureDefinition/DocumentBundle",
                    },
                    // Set Confidentiality as defined by affinity domain
                    Security = new List<Coding>()
                    {
                        new Coding("http://terminology.hl7.org/CodeSystem/v3-Confidentiality", "V", "very restricted"),
                    }
                },
            };

            // Set version-independent identifier for the Bundle
            Identifier identifier = new Identifier();
            identifier.Value = "9932f74d-2812-4be0-bd50-ed76eeab301d";
            identifier.System = "http://hip.in";
            diagnosticReportBundle.Identifier = identifier;

            // Set Bundle Type 
            diagnosticReportBundle.Type = Bundle.BundleType.Document;

            ////// Set Timestamp  
            var dtStr = "2020-07-09T15:32:26.605+05:30";
            diagnosticReportBundle.TimestampElement = new Instant(DateTime.Parse(dtStr));

            var bundleEntry1 = new Bundle.EntryComponent();
            bundleEntry1.FullUrl = "Composition/Composition-01";
            bundleEntry1.Resource = ResourcePopulator.populateDiagnosticReportRecordMediaCompositionResource();
            diagnosticReportBundle.Entry.Add(bundleEntry1);

            var bundleEntry2 = new Bundle.EntryComponent();
            bundleEntry2.FullUrl = "Patient/Patient-01";
            bundleEntry2.Resource = ResourcePopulator.populatePatientResource();
            diagnosticReportBundle.Entry.Add(bundleEntry2);

            var bundleEntry3 = new Bundle.EntryComponent();
            bundleEntry3.FullUrl = "Practitioner/Practitioner-01";
            bundleEntry3.Resource = ResourcePopulator.populatePractitionerResource();
            diagnosticReportBundle.Entry.Add(bundleEntry3);

            var bundleEntry4 = new Bundle.EntryComponent();
            bundleEntry4.FullUrl = "Organization/Organization-01";
            bundleEntry4.Resource = ResourcePopulator.populateOrganizationResource();
            diagnosticReportBundle.Entry.Add(bundleEntry4);

            var bundleEntry5 = new Bundle.EntryComponent();
            bundleEntry5.FullUrl = "DiagnosticReport/DiagnosticReport-01";
            bundleEntry5.Resource = ResourcePopulator.populateDiagnosticReportMediaResource();
            diagnosticReportBundle.Entry.Add(bundleEntry5);         

            var bundleEntry6 = new Bundle.EntryComponent();
            bundleEntry6.FullUrl = "Media/Media-01";
            bundleEntry6.Resource = ResourcePopulator.populateMediaResource();
            diagnosticReportBundle.Entry.Add(bundleEntry6);

            var bundleEntry7 = new Bundle.EntryComponent();
            bundleEntry7.FullUrl = "ServiceRequest/ServiceRequest-01";
            bundleEntry7.Resource = ResourcePopulator.populateServiceRequestResource();
            diagnosticReportBundle.Entry.Add(bundleEntry7);

            var bundleEntry8 = new Bundle.EntryComponent();
            bundleEntry8.FullUrl = "Practitioner/Practitioner-02";
            bundleEntry8.Resource = ResourcePopulator.populateSecondPractitionerResource();
            diagnosticReportBundle.Entry.Add(bundleEntry8);       

            var bundleEntry9 = new Bundle.EntryComponent();
            bundleEntry9.FullUrl = "DocumentReference/DocumentReference-01";
            bundleEntry9.Resource = ResourcePopulator.populateDocumentReferenceResource();
            diagnosticReportBundle.Entry.Add(bundleEntry9);

            diagnosticReportBundle.Signature = ResourcePopulator.populateSignature();

            return diagnosticReportBundle;
        }
    }
}
