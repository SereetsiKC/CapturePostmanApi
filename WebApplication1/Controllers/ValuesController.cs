using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] dynamic value)
        {
            var dPostmanresultsTestdataJson = "D:\\PostmanResults_TestData.json";

            var file = System.IO.File.Open(dPostmanresultsTestdataJson,FileMode.OpenOrCreate);

            file.Close();

            var fileContentsDeserialized = JsonConvert.DeserializeObject<List<dynamic>>(Encoding.Default.GetString(System.IO.File.ReadAllBytes(dPostmanresultsTestdataJson)));

            if (fileContentsDeserialized == null)
            {
                fileContentsDeserialized = new List<dynamic>();
            }

            fileContentsDeserialized.Add(value);


            System.IO.File.WriteAllText(dPostmanresultsTestdataJson,JsonConvert.SerializeObject(fileContentsDeserialized));
            
            return new JsonResult(new {Success = "true"});
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    //public class RulesRequest
    //{
    //    public string LoanType { get; set; }
    //    public string PropertyType { get; set; }
    //    public decimal SafetyScore { get; set; }
    //    public decimal AccuracyScore { get; set; }
    //    public decimal PredictedValue { get; set; }
    //    public decimal PreviousValue { get; set; }
    //    public decimal PurchasePrice { get; set; }
    //    public int RQG { get; set; }
    //    public int LTV { get; set; }
    //    public string PreviousValuationDate { get; set; }
    //    public int PropertyId { get; set; }

    //    public string Response { get; set; }
    //    public string MinimumComparableSales { get; set; }
    //}


    public class ComparableSale
    {
        public double areaUnderRoof { get; set; }
        public double bathRooms { get; set; }
        public double bedRooms { get; set; }
        public double cadastralCoordinateX { get; set; }
        public double cadastralCoordinateY { get; set; }
        public bool cash { get; set; }
        public int comparableAvgSalesPrice { get; set; }
        public int distanceM { get; set; }
        public string erfPortion { get; set; }
        public double garages { get; set; }
        public bool otpFlag { get; set; }
        public bool otpFlg { get; set; }
        public int propertySize { get; set; }
        public int regDate { get; set; }
        public double relevancePerc { get; set; }
        public int rm2 { get; set; }
        public int saleDate { get; set; }
        public int salePrice { get; set; }
        public object schemeName { get; set; }
        public int seqNo { get; set; }
        public string streetAddress { get; set; }
        public string township { get; set; }
        public int unit { get; set; }
    }

    public class EnumeratorArea
    {
        public double exposure { get; set; }
        public double bondPenetration { get; set; }
        public double marketShare { get; set; }
    }

    public class SectionalScheme
    {
        public object exposure { get; set; }
        public object bondPenetration { get; set; }
        public object marketShare { get; set; }
    }

    public class RiskMeasures
    {
        public double riskQualityGrade { get; set; }
        public double replacementCostFactor { get; set; }
        public int replacementCostValue { get; set; }
        public EnumeratorArea enumeratorArea { get; set; }
        public SectionalScheme sectionalScheme { get; set; }
    }

    public class Valuation
    {
        public int estimatedValue { get; set; }
        public int expectedHigh { get; set; }
        public int expectedLow { get; set; }
        public int safetyScore { get; set; }
        public int accuracyScore { get; set; }
    }

    public class RulesRequest
    {
        public string outcome { get; set; }
        public int propertyId { get; set; }
        public int propertySize { get; set; }
        public string staffwareCaseNumber { get; set; }
        public string loanType { get; set; }
        public List<object> flags { get; set; }
        public List<ComparableSale> comparableSales { get; set; }
        public RiskMeasures riskMeasures { get; set; }
        public Valuation valuation { get; set; }
    }
}
