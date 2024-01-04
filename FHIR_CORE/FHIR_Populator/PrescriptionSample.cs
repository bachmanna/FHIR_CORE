using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Hl7.Fhir.Validation;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification.Source;
using System.Text;

namespace FHIR_CORE
{
   // The PrescriptionSample class populates, validates, parse and serializes Clinical Artifact - Prescription
    class PrescriptionSample
    {
        //public static void Main()
        //{
        //    try
        //    {
        //        string strErrOut = "";
        //        Console.WriteLine("Inside PrescriptionSample");
        //        fnPrescriptionSample(ref strErrOut);
        //        Console.ReadKey();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("PrescriptionSample ERROR:---" +e.Message);
        //    }
            
        //}

        public static bool fnPrescriptionSample(ref string strError_OUT)
        {
            bool blnReturn = true;
            try
            {
                Bundle PrescriptionBundle = new Bundle();
                PrescriptionBundle = populatePrescriptionBundle();

                string strErr_OUT = "";
                bool isValid = ResourcePopulator.ValidateProfile(PrescriptionBundle, ref strErr_OUT);
                if (isValid != true)
                {
                    Console.WriteLine(strErr_OUT);
                }
                else
                {
                    Console.WriteLine("Validated populated Prescription bundle successfully");
                    bool isProfileCreated = ResourcePopulator.seralize_WriteFile("PrescriptionBundle.json", PrescriptionBundle);
                    if (isProfileCreated == false)
                    {
                        Console.WriteLine("Error in Profile File creation");
                        blnReturn = false;
                    }
                    else
                    {
                        Console.WriteLine("Prescription bundle file created Successfully");
                        blnReturn = true;
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
       public static Bundle populatePrescriptionBundle()
        {
            // Set metadata about the resource
            Bundle prescriptionBundle = new Bundle()
            {
                // Set logical id of this artifact
                Id = "Prescription-01",
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
            identifier.ElementId = "BundelID";
            identifier.Value = "bc3c6c57-2053-4d0e-ac40-139ccccff645";
            identifier.System = "http://hip.in";
            prescriptionBundle.Identifier = identifier;

            // Set Bundle Type 
            prescriptionBundle.Type = Bundle.BundleType.Document;

            ////// Set Timestamp  
            var dtStr = "2020-07-09T15:32:26.605+05:30";
            prescriptionBundle.TimestampElement = new Instant(DateTime.Parse(dtStr));

            var bundleEntry1 = new Bundle.EntryComponent();
            bundleEntry1.FullUrl = "Composition/Composition-01";
            bundleEntry1.Resource = ResourcePopulator.populatePrescriptionCompositionResource();
            prescriptionBundle.Entry.Add(bundleEntry1);

            var bundleEntry2 = new Bundle.EntryComponent();
            bundleEntry2.FullUrl = "Patient/Patient-01";
            bundleEntry2.Resource = ResourcePopulator.populatePatientResource();
            prescriptionBundle.Entry.Add(bundleEntry2);


            var bundleEntry3 = new Bundle.EntryComponent();
            bundleEntry3.FullUrl = "Practitioner/Practitioner-01";
            bundleEntry3.Resource = ResourcePopulator.populatePractitionerResource();
            prescriptionBundle.Entry.Add(bundleEntry3);


            var bundleEntry4 = new Bundle.EntryComponent();
            bundleEntry4.FullUrl = "MedicationRequest/MedicationRequest-01";
            bundleEntry4.Resource = ResourcePopulator.populateMedicationRequestResource();
            prescriptionBundle.Entry.Add(bundleEntry4);

            var bundleEntry5 = new Bundle.EntryComponent();
            bundleEntry5.FullUrl = "MedicationRequest/MedicationRequest-02";
            bundleEntry5.Resource = ResourcePopulator.populateSecondMedicationRequestResource();
            prescriptionBundle.Entry.Add(bundleEntry5);


            var bundleEntry6 = new Bundle.EntryComponent();
            bundleEntry6.FullUrl = "Condition/Condition-01";
            bundleEntry6.Resource = ResourcePopulator.populateConditionResource();
            prescriptionBundle.Entry.Add(bundleEntry6);


            var bundleEntry7 = new Bundle.EntryComponent();
            bundleEntry7.FullUrl = "Binary/Binary-01";
            bundleEntry7.Resource = ResourcePopulator.populateBinaryResource();
            prescriptionBundle.Entry.Add(bundleEntry7);
                      
            prescriptionBundle.Signature = ResourcePopulator.populateSignature();

            return prescriptionBundle;
        }

       
    }
}
