using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Hl7.Fhir.Validation;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification.Source;

namespace FHIR_CORE
{
    class WellnessRecordSample
    {
        //public static void Main()
        //{
        //    try
        //    {
        //        string strErrOut = "";
        //        Console.WriteLine("Inside WellnessRecordSample");
        //        fnWellnessRecordSample(ref strErrOut);
        //        Console.ReadKey();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("WellnessRecordSample ERROR:---" + e.Message);
        //    }

        //}

        static bool fnWellnessRecordSample(ref string strError_OUT)
        {
            bool blnReturn = true;
            try
            {
                Bundle WellnessRecordBundle = new Bundle();
                WellnessRecordBundle = populateWellnessRecordBundle();

                string strErr_OUT = "";
                bool isValid = ResourcePopulator.ValidateProfile(WellnessRecordBundle, ref strErr_OUT);
                //   isValid = true;
                if (isValid != true)
                {
                    Console.WriteLine(strErr_OUT);
                }
                else
                {
                    Console.WriteLine("Validated populated WellnessRecord bundle successfully");
                    bool isProfileCreated = ResourcePopulator.seralize_WriteFile("WellnessRecordBundle.json", WellnessRecordBundle);
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
        static Bundle populateWellnessRecordBundle()
        {
            // Set metadata about the resource            
            Bundle WellnessRecordBundle = new Bundle()
            {
                // Set logical id of this artifact
                Id = "WellnessRecord-01",
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
            WellnessRecordBundle.Identifier = identifier;

            // Set Bundle Type 
            WellnessRecordBundle.Type = Bundle.BundleType.Document;

            ////// Set Timestamp  
            var dtStr = "2020-07-09T15:32:26.605+05:30";
            WellnessRecordBundle.TimestampElement = new Instant(DateTime.Parse(dtStr));

            var bundleEntry1 = new Bundle.EntryComponent();
            bundleEntry1.FullUrl = "Composition/Composition-01";
            bundleEntry1.Resource = ResourcePopulator.populateWellnessRecordCompositionResource();
            WellnessRecordBundle.Entry.Add(bundleEntry1);

            var bundleEntry2 = new Bundle.EntryComponent();
            bundleEntry2.FullUrl = "Practitioner/Practitioner-01";
            bundleEntry2.Resource = ResourcePopulator.populatePractitionerResource();
            WellnessRecordBundle.Entry.Add(bundleEntry2);

            var bundleEntry3 = new Bundle.EntryComponent();
            bundleEntry3.FullUrl = "Patient/Patient-01";
            bundleEntry3.Resource = ResourcePopulator.populatePatientResource();
            WellnessRecordBundle.Entry.Add(bundleEntry3);

            var bundleEntry4 = new Bundle.EntryComponent();
            bundleEntry4.FullUrl = "Organization/Organization-01";
            bundleEntry4.Resource = ResourcePopulator.populateOrganizationResource();
            WellnessRecordBundle.Entry.Add(bundleEntry4);

            var bundleEntry5 = new Bundle.EntryComponent();
            bundleEntry5.FullUrl = "Observation/respiratory-rate";
            bundleEntry5.Resource = ResourcePopulator.populateRespitaryRateResource();
            WellnessRecordBundle.Entry.Add(bundleEntry5);

            var bundleEntry6 = new Bundle.EntryComponent();
            bundleEntry6.FullUrl = "Observation/heart-rate";
            bundleEntry6.Resource = ResourcePopulator.populateHeartRateResource();
            WellnessRecordBundle.Entry.Add(bundleEntry6);

            var bundleEntry7 = new Bundle.EntryComponent();
            bundleEntry7.FullUrl = "Observation/oxygen-saturation";
            bundleEntry7.Resource = ResourcePopulator.populateOxygenSaturationResource();
            WellnessRecordBundle.Entry.Add(bundleEntry7);

            var bundleEntry8 = new Bundle.EntryComponent();
            bundleEntry8.FullUrl = "Observation/body-temperature";
            bundleEntry8.Resource = ResourcePopulator.populateBodyTemperatureResource();
            WellnessRecordBundle.Entry.Add(bundleEntry8);

            var bundleEntry9 = new Bundle.EntryComponent();
            bundleEntry9.FullUrl = "Observation/body-height";
            bundleEntry9.Resource = ResourcePopulator.populateBodyHeightResource();
            WellnessRecordBundle.Entry.Add(bundleEntry9);

            var bundleEntry10 = new Bundle.EntryComponent();
            bundleEntry10.FullUrl = "Observation/body-weight";
            bundleEntry10.Resource = ResourcePopulator.populateBodyWeightResource();
            WellnessRecordBundle.Entry.Add(bundleEntry10);

            var bundleEntry11 = new Bundle.EntryComponent();
            bundleEntry11.FullUrl = "Observation/bmi";
            bundleEntry11.Resource = ResourcePopulator.populateBMIResource();
            WellnessRecordBundle.Entry.Add(bundleEntry11);

            var bundleEntry12 = new Bundle.EntryComponent();
            bundleEntry12.FullUrl = "Observation/blood-pressure";
            bundleEntry12.Resource = ResourcePopulator.populateBloodPressureResource();
            WellnessRecordBundle.Entry.Add(bundleEntry12);

            var bundleEntry13 = new Bundle.EntryComponent();
            bundleEntry13.FullUrl = "Observation/StepCount";
            bundleEntry13.Resource = ResourcePopulator.populateStepCountResource();
            WellnessRecordBundle.Entry.Add(bundleEntry13);

            var bundleEntry14 = new Bundle.EntryComponent();
            bundleEntry14.FullUrl = "Observation/CaloriesBurned";
            bundleEntry14.Resource = ResourcePopulator.populateCaloriesBurnedResource();
            WellnessRecordBundle.Entry.Add(bundleEntry14);

            var bundleEntry15 = new Bundle.EntryComponent();
            bundleEntry15.FullUrl = "Observation/SleepDuration";
            bundleEntry15.Resource = ResourcePopulator.populateSleepDurationResource();
            WellnessRecordBundle.Entry.Add(bundleEntry15);

            var bundleEntry16 = new Bundle.EntryComponent();
            bundleEntry16.FullUrl = "Observation/BodyFatMass";
            bundleEntry16.Resource = ResourcePopulator.populateBodyFatMassResource();
            WellnessRecordBundle.Entry.Add(bundleEntry16);

            var bundleEntry17 = new Bundle.EntryComponent();
            bundleEntry17.FullUrl = "Observation/BloodGlucose";
            bundleEntry17.Resource = ResourcePopulator.populateBloodGlucoseResource();
            WellnessRecordBundle.Entry.Add(bundleEntry17);

            var bundleEntry18 = new Bundle.EntryComponent();
            bundleEntry18.FullUrl = "Observation/FluidIntake";
            bundleEntry18.Resource = ResourcePopulator.populateFluidIntakeResource();
            WellnessRecordBundle.Entry.Add(bundleEntry18);

            var bundleEntry19 = new Bundle.EntryComponent();
            bundleEntry19.FullUrl = "Observation/CalorieIntake";
            bundleEntry19.Resource = ResourcePopulator.populateCalorieIntakeResource();
            WellnessRecordBundle.Entry.Add(bundleEntry19);

            var bundleEntry20 = new Bundle.EntryComponent();
            bundleEntry20.FullUrl = "Observation/AgeOfMenarche";
            bundleEntry20.Resource = ResourcePopulator.populateAgeOfMenarcheResource();
            WellnessRecordBundle.Entry.Add(bundleEntry20);

            var bundleEntry21 = new Bundle.EntryComponent();
            bundleEntry21.FullUrl = "Observation/LastMenstrualPeriod";
            bundleEntry21.Resource = ResourcePopulator.populateLastMenstrualPeriodResource();
            WellnessRecordBundle.Entry.Add(bundleEntry21);

            var bundleEntry22 = new Bundle.EntryComponent();
            bundleEntry22.FullUrl = "Observation/DietType";
            bundleEntry22.Resource = ResourcePopulator.populateDietTypeResource();
            WellnessRecordBundle.Entry.Add(bundleEntry22);

            var bundleEntry23 = new Bundle.EntryComponent();
            bundleEntry23.FullUrl = "Observation/TobaccoSmokingStatus";
            bundleEntry23.Resource = ResourcePopulator.populateTobaccoSmokingStatusResource();
            WellnessRecordBundle.Entry.Add(bundleEntry23);

            var bundleEntry24 = new Bundle.EntryComponent();
            bundleEntry24.FullUrl = "DocumentReference/DocumentReference-01";
            bundleEntry24.Resource = ResourcePopulator.populateDocumentReferenceResource();
            WellnessRecordBundle.Entry.Add(bundleEntry24);


            return WellnessRecordBundle;
        }
    }
}
