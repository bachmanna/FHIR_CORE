using System;
using Hl7.Fhir.Model;
using System.Collections.Generic;

namespace FHIR_CORE
{
    //The DischargeSummarySample class populates, validates, parse and serializes Clinical Artifact - DischargeSummary
    class DischargeSummarySample
    {
        //public static void Main()
        //{
        //    try
        //    {
        //        string strErrOut = "";
        //        Console.WriteLine("Inside DischargeSummarySample");
        //        fnDischargeSummarySample(ref strErrOut);
        //        Console.ReadKey();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("DischargeSummarySample ERROR:---" + e.Message);
        //    }

        //}
        static bool fnDischargeSummarySample(ref string strError_OUT)
        {
            bool blnReturn = true;
            try
            {
                Bundle dischargeSummaryBundle = new Bundle();
                dischargeSummaryBundle = populateDischargeSummaryBundle();

                string strErr_OUT = "";
                bool isValid =ResourcePopulator.ValidateProfile(dischargeSummaryBundle, ref strErr_OUT);
                //   isValid = true;
                if (isValid != true)
                {
                    Console.WriteLine(strErr_OUT);
                }
                else
                {
                    Console.WriteLine("Validated populated DischargeSummary bundle successfully");
                    bool isProfileCreated = ResourcePopulator.seralize_WriteFile("DischargeSummaryBundle.json", dischargeSummaryBundle);
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
        static Bundle populateDischargeSummaryBundle()
        {
            // Set metadata about the resource
            Bundle dischargeSummaryBundle = new Bundle()
            {
                // Set logical id of this artifact
                Id = "discharge-bundle-01-my",
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
            identifier.Value = "eba2ef3a-320f-4f16-8789-ed64965943a3";
            identifier.System = "http://hip.in";
            dischargeSummaryBundle.Identifier = identifier;

            // Set Bundle Type 
            dischargeSummaryBundle.Type = Bundle.BundleType.Document;

            ////// Set Timestamp  
            var dtStr = "2020-07-09T15:32:26.605+05:30";
            dischargeSummaryBundle.TimestampElement = new Instant(DateTime.Parse(dtStr));

            var bundleEntry1 = new Bundle.EntryComponent();
            bundleEntry1.FullUrl = "Composition/Composition-01";
            bundleEntry1.Resource = ResourcePopulator.populateDischargeSummaryCompositionResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry1);

            var bundleEntry2 = new Bundle.EntryComponent();
            bundleEntry2.FullUrl = "Practitioner/Practitioner-01";
            bundleEntry2.Resource = ResourcePopulator.populatePractitionerResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry2);


            var bundleEntry4 = new Bundle.EntryComponent();
            bundleEntry4.FullUrl = "Organization/Organization-01";
            bundleEntry4.Resource = ResourcePopulator.populateSecondOrganizationResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry4);

            var bundleEntry5 = new Bundle.EntryComponent();
            bundleEntry5.FullUrl = "Patient/Patient-01";
            bundleEntry5.Resource = ResourcePopulator.populatePatientResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry5);
            
            var bundleEntry6 = new Bundle.EntryComponent();
            bundleEntry6.FullUrl = "Encounter/Encounter-02";
            bundleEntry6.Resource = ResourcePopulator.populateSecondEncounterResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry6);         

            var bundleEntry7 = new Bundle.EntryComponent();
            bundleEntry7.FullUrl = "Condition/Condition-01";
            bundleEntry7.Resource = ResourcePopulator.populateFourthConditionResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry7);

            var bundleEntry8 = new Bundle.EntryComponent();
            bundleEntry8.FullUrl = "Condition/Condition-02";
            bundleEntry8.Resource = ResourcePopulator.populateFifthConditionResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry8);
            
            var bundleEntry9 = new Bundle.EntryComponent();
            bundleEntry9.FullUrl = "DiagnosticReport/DiagnosticReport-01";
            bundleEntry9.Resource = ResourcePopulator.populateDiagonosticReportLabResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry9);

            var bundleEntry10 = new Bundle.EntryComponent();
            bundleEntry10.FullUrl = "Observation/Observation-cholesterol";
            bundleEntry10.Resource = ResourcePopulator.populateCholesterolObservationResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry10);

            var bundleEntry11 = new Bundle.EntryComponent();
            bundleEntry11.FullUrl = "Observation/Observation-triglyceride";
            bundleEntry11.Resource = ResourcePopulator.populateTriglycerideObservationResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry11);

            var bundleEntry12 = new Bundle.EntryComponent();
            bundleEntry12.FullUrl = "Observation/Observation-cholesterol-in-hdl";
            bundleEntry12.Resource = ResourcePopulator.populateCholesterolInHDLObservationResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry12);

            var bundleEntry13 = new Bundle.EntryComponent();
            bundleEntry13.FullUrl = "Procedure/Procedure-01";
            bundleEntry13.Resource = ResourcePopulator.populateProcedureResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry13);

            var bundleEntry14 = new Bundle.EntryComponent();
            bundleEntry14.FullUrl = "Procedure/Procedure-02";
            bundleEntry14.Resource = ResourcePopulator.populateSecondProcedureResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry14);

            var bundleEntry15 = new Bundle.EntryComponent();
            bundleEntry15.FullUrl = "CarePlan/CarePlan-01";
            bundleEntry15.Resource = ResourcePopulator.populateSecondCarePlanResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry15);

            var bundleEntry16 = new Bundle.EntryComponent();
            bundleEntry16.FullUrl = "DocumentReference/DocumentReference-01";
            bundleEntry16.Resource = ResourcePopulator.populateDocumentReferenceResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry16);

            var bundleEntry17 = new Bundle.EntryComponent();
            bundleEntry17.FullUrl = "Appointment/Appointment-01";
            bundleEntry17.Resource = ResourcePopulator.populateAppointmentResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry17);

            var bundleEntry18 = new Bundle.EntryComponent();
            bundleEntry18.FullUrl = "Specimen/Specimen-01";
            bundleEntry18.Resource = ResourcePopulator.populateSpecimenResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry18);

            var bundleEntry19 = new Bundle.EntryComponent();
            bundleEntry19.FullUrl = "MedicationRequest/MedicationRequest-01";
            bundleEntry19.Resource = ResourcePopulator.populateMedicationRequestResource();
            dischargeSummaryBundle.Entry.Add(bundleEntry19);

            dischargeSummaryBundle.Signature = ResourcePopulator.populateSignature();

            return dischargeSummaryBundle;
        }
    }
}
