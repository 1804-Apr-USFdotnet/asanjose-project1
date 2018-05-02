using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace ClassProj
{

    public class Serializer
    {

        public static void Serialize(Object type, string filename= "MOCK_DATA.json"){
            JsonSerializer serializer = new JsonSerializer();

            using(StreamWriter streamWriter = new StreamWriter(filename))
            using(JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(writer, type);
            }

         }



        public static List<T> DeSerializer<T>(List<T> type)
        {


            List<T> restaurants = new List<T>();
            restaurants = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(@"MOCK_DATA.json"));


            return restaurants;




        }
    }


}