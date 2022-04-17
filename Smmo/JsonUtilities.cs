using System.Text.Json.Serialization;
using System.Text.Json;

namespace StepNKill.Smmo
{
	public class FalseAndNullToLongConverter : JsonConverter<long>
	{
		public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			switch(reader.TokenType)
			{
				case JsonTokenType.Null:
				case JsonTokenType.False:
					{
						Console.WriteLine($"Json token type: {reader.TokenType} which is not long, value set to -1");
						return -1;
					}

				default:
					{
						return reader.GetInt64();
					}
			}
		}

		public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value);
		}
	}

	public class NullToEmptyStringConverter : JsonConverter<string>
	{
		// Override default null handling
		public override bool HandleNull => true;

		// Check the type
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(string);
		}

		// Ignore for this exampke
		public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{

			if(reader.TokenType == JsonTokenType.Null || reader.TokenType == JsonTokenType.False)
			{
				Console.WriteLine($"Json token type: {reader.TokenType} which is null or false, value set to 'not set' ");
				return "not set was null";
			}
			else
			{
				return reader.GetString();
			}

		}

		public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
		{
			if(value == null)
			{
				writer.WriteStringValue("");
			}
			else
			{
				writer.WriteStringValue(value);
			}
		}
	}


	//Jsonconverter from unix time to datetimeoffset
	public class UnixTimeToDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
	{
		public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if(reader.TokenType == JsonTokenType.Null)
			{
				return default;
			}
			else
			{
				return DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64());
			}
		}

		public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value.ToUnixTimeSeconds());
		}
	}
}
