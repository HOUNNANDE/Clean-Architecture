using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AspNetCore.Courses.Section15.Infrastructures.Common
{
	public class JsonConveterOptions: JsonConverter<DateTimeOffset>
	{
		public override DateTimeOffset Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options) =>
				DateTimeOffset.ParseExact(reader.GetString()!,
					"MM/dd/yyyy", CultureInfo.InvariantCulture);

		public override void Write(
			Utf8JsonWriter writer,
			DateTimeOffset dateTimeValue,
			JsonSerializerOptions options) =>
				writer.WriteStringValue(dateTimeValue.ToString(
					"MM/dd/yyyy", CultureInfo.InvariantCulture));
	}
}
