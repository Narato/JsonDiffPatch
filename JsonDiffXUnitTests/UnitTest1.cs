using System;
using Xunit;
using JsonDiffPatch;
using Newtonsoft.Json.Linq;

namespace JsonDiffXUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void UpdateSchemaTest()
        {
            #region jsonDefinitions
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
							""type"": ""string"",
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
            #endregion

            var existing = JToken.Parse(jsonValidationSchema);
            var newOne = JToken.Parse(updatedJsonValidationSchema);

            var result = new JsonDiffer().Diff(existing, newOne, false);
            PatchDocument test2 = result;
        }
    }
}
