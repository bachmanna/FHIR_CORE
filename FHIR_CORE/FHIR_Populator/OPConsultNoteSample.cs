using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Hl7.Fhir.Validation;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification.Source;
using Newtonsoft.Json;
using System.Xml;


namespace FHIR_CORE
{
    //The OPConsultNoteSample class populates, validates, parse and serializes Clinical Artifact - OPConsultNote
    class OPConsultNoteSample
    {
        //public static void Main()
        //{
        //    try
        //    {
        //        string strErrOut = "";
        //        Console.WriteLine("Inside OPConsultNoteSample");
        //        fnOPConsultNoteSample(ref strErrOut);
        //        Console.ReadKey();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("OPConsultNoteSample ERROR:---" + e.Message);
        //    }

        //}
        static bool fnOPConsultNoteSample(ref string strError_OUT)
        {
            bool blnReturn = true;
            try
            {
                Bundle OPConsultNoteSample = new Bundle();
                OPConsultNoteSample = populateOPConsultNoteBundle();

                string strErr_OUT = "";
                bool isValid =ResourcePopulator.ValidateProfile(OPConsultNoteSample, ref strErr_OUT);
                //   isValid = true;
                if (isValid != true)
                {
                    Console.WriteLine(strErr_OUT);
                }
                else
                {
                    Console.WriteLine("Validated populated OPConsultNoteSample bundle successfully");
                    bool isProfileCreated = ResourcePopulator.seralize_WriteFile("OPConsultNoteBundle.json", OPConsultNoteSample);
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
        static Bundle populateOPConsultNoteBundle()
        {
            // Set metadata about the resource            
            Bundle OPConsultNoteBundle = new Bundle()
            {
                // Set logical id of this artifact
                Id = "OPConsultNote-01",
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
            OPConsultNoteBundle.Identifier = identifier;

            // Set Bundle Type 
            OPConsultNoteBundle.Type = Bundle.BundleType.Document;

            ////// Set Timestamp  
            var dtStr = "2020-07-09T15:32:26.605+05:30";
            OPConsultNoteBundle.TimestampElement = new Instant(DateTime.Parse(dtStr));

            var bundleEntry1 = new Bundle.EntryComponent();
            bundleEntry1.FullUrl = "Composition/Composition-01";
            bundleEntry1.Resource = ResourcePopulator.populateOPConsultNoteCompositionResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry1);

            var bundleEntry2 = new Bundle.EntryComponent();
            bundleEntry2.FullUrl = "Practitioner/Practitioner-01";
            bundleEntry2.Resource = ResourcePopulator.populatePractitionerResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry2);


            var bundleEntry3 = new Bundle.EntryComponent();
            bundleEntry3.FullUrl = "Organization/Organization-01";
            bundleEntry3.Resource = ResourcePopulator.populateOrganizationResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry3);


            var bundleEntry4 = new Bundle.EntryComponent();
            bundleEntry4.FullUrl = "Patient/Patient-01";
            bundleEntry4.Resource = ResourcePopulator.populatePatientResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry4);


            var bundleEntry5 = new Bundle.EntryComponent();
            bundleEntry5.FullUrl = "Encounter/Encounter-01";
            bundleEntry5.Resource = ResourcePopulator.populateEncounterResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry5);


            var bundleEntry6 = new Bundle.EntryComponent();
            bundleEntry6.FullUrl = "AllergyIntolerance/AllergyIntolerance-01";
            bundleEntry6.Resource = ResourcePopulator.populateAllergyIntoleranceResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry6);

            var bundleEntry7 = new Bundle.EntryComponent();
            bundleEntry7.FullUrl = "Appointment/Appointment-01";
            bundleEntry7.Resource = ResourcePopulator.populateAppointmentResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry7);

            var bundleEntry8 = new Bundle.EntryComponent();
            bundleEntry8.FullUrl = "Condition/Condition-01";
            bundleEntry8.Resource = ResourcePopulator.populateConditionResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry8);

            var bundleEntry9 = new Bundle.EntryComponent();
            bundleEntry9.FullUrl = "Condition/Condition-02";
            bundleEntry9.Resource = ResourcePopulator.populateSecondConditionResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry9);

            var bundleEntry10 = new Bundle.EntryComponent();
            bundleEntry10.FullUrl = "Condition/Condition-03";
            bundleEntry10.Resource = ResourcePopulator.populateThirdConditionResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry10);

            var bundleEntry11 = new Bundle.EntryComponent();
            bundleEntry11.FullUrl = "Procedure/Procedure-01";
            bundleEntry11.Resource = ResourcePopulator.populateProcedureResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry11);

            var bundleEntry12 = new Bundle.EntryComponent();
            bundleEntry12.FullUrl = "ServiceRequest/ServiceRequest-01";
            bundleEntry12.Resource = ResourcePopulator.populateServiceRequestResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry12);

            var bundleEntry13 = new Bundle.EntryComponent();
            bundleEntry13.FullUrl = "MedicationStatement/MedicationStatement-01";
            bundleEntry13.Resource = ResourcePopulator.populateMedicationStatementResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry13);

            var bundleEntry14 = new Bundle.EntryComponent();
            bundleEntry14.FullUrl = "MedicationRequest/MedicationRequest-01";
            bundleEntry14.Resource = ResourcePopulator.populateMedicationRequestResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry14);

            var bundleEntry15 = new Bundle.EntryComponent();
            bundleEntry15.FullUrl = "DocumentReference/DocumentReference-01";
            bundleEntry15.Resource = ResourcePopulator.populateDocumentReferenceResource();
            OPConsultNoteBundle.Entry.Add(bundleEntry15);

            OPConsultNoteBundle.Signature = ResourcePopulator.populateSignature();

            return OPConsultNoteBundle;
        }
    }
}
