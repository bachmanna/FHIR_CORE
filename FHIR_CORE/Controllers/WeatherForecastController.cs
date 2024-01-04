using FHIR_CORE.Models;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;

namespace FHIR_CORE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


    }


    //[ApiController]
    //[Route("[controller]")]
    public class PrescriptionSampleController : ControllerBase
    {
        private readonly ILogger<PrescriptionSampleController> _logger;

        public PrescriptionSampleController(ILogger<PrescriptionSampleController> logger)
        {
            _logger = logger;
        }


        //GeneratePrescription
        [HttpPost("GeneratePrescription", Name = "GeneratePrescription")]
        public IActionResult GeneratePrescription([FromBody] FHIRinputs model)
        {
            try
            {
                string strErrorOut = "";
                //bool result = PrescriptionSample.fnPrescriptionSample(ref strErrorOut);
                Bundle PrescriptionBundle = new Bundle();
                PrescriptionBundle = PrescriptionSample.populatePrescriptionBundle();
                ResourcePopulator.ValidateProfile(PrescriptionBundle, ref strErrorOut);

                bool isProfileCreated = ResourcePopulator.seralize_WriteFile("PrescriptionBundle.json", PrescriptionBundle);

                if (isProfileCreated)
                {
                    return Ok(PrescriptionBundle);
                }
                else
                {
                    return BadRequest($"Error generating prescription: {strErrorOut}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        //GeneratepopulateDiagnosticReportImagingDCMBundle
        [HttpPost("GeneratepopulateDiagnosticReportImagingDCMBundle", Name = "GeneratepopulateDiagnosticReportImagingDCMBundle")]
        public IActionResult GeneratepopulateDiagnosticReportImagingDCMBundle([FromBody] FHIRinputs model)
        {
            try
            {
                string strErrorOut = "";
                //bool result = PrescriptionSample.fnPrescriptionSample(ref strErrorOut);
                Bundle diagnosticReportImagingDCMBundle = new Bundle();
                diagnosticReportImagingDCMBundle = DiagnosticReportImagingDcmSample.populateDiagnosticReportImagingDCMBundle();
                ResourcePopulator.ValidateProfile(diagnosticReportImagingDCMBundle, ref strErrorOut);

                bool isProfileCreated = ResourcePopulator.seralize_WriteFile("PrescriptionBundle.json", diagnosticReportImagingDCMBundle);

                if (isProfileCreated)
                {
                    return Ok(diagnosticReportImagingDCMBundle);
                }
                else
                {
                    return BadRequest($"Error generating prescription: {strErrorOut}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("GeneratepopulatePatientResource", Name = "GeneratepopulatePatientResource")]
        public IActionResult GeneratepopulatePatientResource([FromBody] FHIRinputs model)
        {
            try
            {
                string strErrorOut = "";
                //bool result = PrescriptionSample.fnPrescriptionSample(ref strErrorOut);
                //Bundle diagnosticReportImagingDCMBundle = new Bundle();
                // object populatePatientResource = ResourcePopulator.populatePatientResource();
                // ResourcePopulator.ValidateProfile(populatePatientResource, ref strErrorOut);

                var bundleEntry2 = new Bundle.EntryComponent();
                bundleEntry2.FullUrl = "Patient/Patient-01";
                bundleEntry2.Resource = ResourcePopulator.populatePatientResource();

                // bool isProfileCreated = ResourcePopulator.seralize_WriteFile("PrescriptionBundle.json", bundleEntry2);
                bool isProfileCreated = true;
                if (isProfileCreated)
                {
                    return Ok(bundleEntry2);
                }
                else
                {
                    return BadRequest($"Error generating prescription: {strErrorOut}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}