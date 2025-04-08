using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

class JSONStorage {

    private string filePath = "../storage/inventory_manager.json";
    public Dictionary<string, BaseClass> objects { get; set; } = new Dictionary<string, BaseClass>();

    public Dictionary<string, BaseClass> All() {
        return objects;
    }

    public void New(BaseClass obj) {
        string key = $"{obj.GetType().Name}.{obj.id}";
        objects[key] = obj;
    }

    public void Save() {
        var options = new JsonSerializationOptions
        {
            WriteIndented = true;
            Converters = { new BaseClassConverter() }
        };

        string jsonString = JsonSerializer.Serialize(objects, options);
        File.WriteAllText(filePath, jsonString);
    }

    public void Load() {
        if (!File.Exists(filePath)) {
            return;
        }

        var options = new JsonSerializationOptions
        {
            Converters = { new BaseClassConverter() }
        };

        string jsonString = File.ReadAllText(filePath);
        objects = JsonSerializer.Deserialize<Dictionary<string, BaseClass>>(jsonString, options);
    }

     public class BaseClassConverter : JsonConverter<BaseClass>
    {
        public override BaseClass Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                if (!root.TryGetProperty("id", out JsonElement idProp))
                    throw new JsonException("Missing id property.");

                if (!root.TryGetProperty("name", out JsonElement nameProp))
                    throw new JsonException("Missing name property.");

                // Guess type from known fields
                if (root.TryGetProperty("price", out _))
                    return JsonSerializer.Deserialize<Item>(root.GetRawText(), options);
                else if (root.TryGetProperty("user_id", out _))
                    return JsonSerializer.Deserialize<Inventory>(root.GetRawText(), options);
                else
                    return JsonSerializer.Deserialize<User>(root.GetRawText(), options);
            }
        }

        public override void Write(Utf8JsonWriter writer, BaseClass value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }

}