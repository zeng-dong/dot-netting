# System.Text.Json

What if You Do Not Have a Class to Deserialize To?
There are several options if you do not have a specific class to deserialize to 
Use JSON DOM, Utf8JsonReader, or automatically creating the class in Visual Studio

## Deserialization Default Behavior
- Property name matching is case-sensitive
- If the JSON object contains a value for a read-only property, the value is ignored, and no exception is thrown
- Non-public constructors are ignored by the serializer
- Deserialization to immutable objects or properties that don't have public set accessors is supported
- Enums are supported as numbers
- Fields are ignored
- Comments or trailing commas cause an exception to be thrown
- The default maximum depth is 64