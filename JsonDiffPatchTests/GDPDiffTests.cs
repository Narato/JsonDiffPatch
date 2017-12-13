using JsonDiffPatch;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace JsonDiffPatch.Tests
{
    public class GDPDiffTests
    {
        [Test]
        public void Move_property()
        {
            string jsonValidationSchema = @"
               {
                ""$schema"": ""http://json-schema.org/draft-04/schema#"",
                ""title"": ""Person"",
                ""type"": ""object"",
					""properties"": {
						""firstName"": {
							""type"": ""string""
						},
						""lastName"": {
							""type"": ""string""
						},
						""age"": {
							""description"": ""Age in years"",
							""type"": ""integer""
						}					                 
                    },               
                ""additionalProperties"": false               
             }";


            var dataType = new DataType
            {
                Key = "test",
                Name = "test",
                ValidationSchema = jsonValidationSchema
            };

            string updatedJsonValidationSchema = @"
               {
                ""$schema"": ""http://json-schema.org/draft-04/schema#"",
                ""title"": ""Person"",
                ""type"": ""object"",
					""properties"": {
						""firstName"": {
							""type"": ""string"",
                            ""additionalProperties"": false               
                            
						},
						""lastName"": {
							""type"": ""string"",
                            ""additionalProperties"": false               
                
						},
						""age"": {
							""description"": ""Age in years"",
							""type"": ""integer"",
                            ""additionalProperties"": false
						},
                        ""email"": {
                            ""description"": ""Private email address"",
                            ""type"": ""string"",
                            ""additionalProperties"": false
                        }					                 
                    },               
                ""additionalProperties"": false               
             }";



        }
    }
}
