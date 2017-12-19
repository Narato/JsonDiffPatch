using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tavis;

namespace JsonDiffPatch
{
    public class AddOperation : Operation
    {


        public override void Write(JsonWriter writer)
        {
            writer.WriteStartObject();

            WriteOp(writer, "add");
            WritePath(writer,Path);
            WriteOldValue(writer, "");
            WriteValue(writer,Value);

            writer.WriteEndObject();
        }

        public override void Read(JObject jOperation)
        {
            Path = new JsonPointer((string)jOperation.GetValue("path"));
            Value = jOperation.GetValue("value");
            OldValue = jOperation.GetValue("oldvalue");
        }
    }
}