using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tavis;

namespace JsonDiffPatch
{
    public class TestOperation : Operation
    {


        public override void Write(JsonWriter writer)
        {
            writer.WriteStartObject();

            WriteOp(writer, "test");
            WritePath(writer, Path);
            WriteOldValue(writer, OldValue);
            WriteValue(writer, Value);

            writer.WriteEndObject();
        }

        public override void Read(JObject jOperation)
        {
            Path = new JsonPointer((string)jOperation.GetValue("path"));
            Value = jOperation.GetValue("value");
        }
    }
}