using System;
using Hl7.Fhir.Model;
using System.Collections.Generic;

namespace FHIR_CORE
{
    class HealthDocumentRecordSample
    {
        //public static void Main()
        //{
        //    try
        //    {
        //        string strErrOut = "";
        //        Console.WriteLine("Inside HealthDocumentRecordSample");
        //        fnHealthDocumentRecordSample(ref strErrOut);
        //        Console.ReadKey();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("HealthDocumentRecordSample ERROR:---" + e.Message);
        //    }

        //}
        static bool fnHealthDocumentRecordSample(ref string strError_OUT)
        {
            bool blnReturn = true;
            try
            {
                Bundle HealthDocumentRecordBundle = new Bundle();
                HealthDocumentRecordBundle = populateHealthDocumentRecordSample();

                string strErr_OUT = "";
                bool isValid = ResourcePopulator.ValidateProfile(HealthDocumentRecordBundle, ref strErr_OUT);
                //   isValid = true;
                if (isValid != true)
                {
                    Console.WriteLine(strErr_OUT);
                }
                else
                {
                    Console.WriteLine("Validated populated HealthDocumentRecord bundle successfully");
                    bool isProfileCreated = ResourcePopulator.seralize_WriteFile("HealthDocumentRecordBundle.json", HealthDocumentRecordBundle);
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
        static Bundle populateHealthDocumentRecordSample()
        {
            // Set metadata about the resource            
            Bundle HealthDocumentRecordBundle = new Bundle()
            {
                // Set logical id of this artifact
                Id = "HealthDocumentRecord-01",
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
            identifier.Value = "305fecc2-4ba2-46cc-9ccd-efa755aff51d";
            identifier.System = "http://hip.in";
            HealthDocumentRecordBundle.Identifier = identifier;

            // Set Bundle Type 
            HealthDocumentRecordBundle.Type = Bundle.BundleType.Document;

            ////// Set Timestamp  
            var dtStr = "2020-07-09T15:32:26.605+05:30";
            HealthDocumentRecordBundle.TimestampElement = new Instant(DateTime.Parse(dtStr));

            var bundleEntry1 = new Bundle.EntryComponent();
            bundleEntry1.FullUrl = "Composition/Composition-01";
            bundleEntry1.Resource = ResourcePopulator.populateHealthDocumentRecordCompositionResource();
            HealthDocumentRecordBundle.Entry.Add(bundleEntry1);

            var bundleEntry2 = new Bundle.EntryComponent();
            bundleEntry2.FullUrl = "Practitioner/Practitioner-01";
            bundleEntry2.Resource = ResourcePopulator.populatePractitionerResource();
            HealthDocumentRecordBundle.Entry.Add(bundleEntry2);

            var bundleEntry3 = new Bundle.EntryComponent();
            bundleEntry3.FullUrl = "Patient/Patient-01";
            bundleEntry3.Resource = ResourcePopulator.populatePatientResource();
            HealthDocumentRecordBundle.Entry.Add(bundleEntry3);

            var bundleEntry4 = new Bundle.EntryComponent();
            bundleEntry4.FullUrl = "DocumentReference/DocumentReference-01";
            bundleEntry4.Resource = ResourcePopulator.populateDocumentReferenceResource();
            HealthDocumentRecordBundle.Entry.Add(bundleEntry4);

            HealthDocumentRecordBundle.Signature = ResourcePopulator.populateSignature();

            return HealthDocumentRecordBundle;
        }
    }
}
