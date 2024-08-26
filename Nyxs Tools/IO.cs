using System.Text.Json;

namespace Nyxs_Tools
{
    public class IOToolsBoolException<T> : Exception {
        public IOToolsBoolException() {}
        public IOToolsBoolException(string message) : base (message) {}
    }
    public class IO
    {
        public static string Prompt(string prompt) {
            Console.WriteLine(prompt);
            return Console.ReadLine()!;
        }
        public static T VerifyPrompt<T>(string prompt) {
            T verified = default!;
            bool fail = false;
            do {
                fail = false;
                try {
                    verified = (T)Convert.ChangeType(Prompt(prompt), typeof(T));   
                } catch(FormatException) {
                    Console.WriteLine($"Input couldn't be converted to {typeof(T)}");
                    fail = true;
                }
            }
            while(fail); 
            return verified;
        }
        public static bool boolPrompt(string prompt) {
            bool fail = false;
            do {
                if(fail == true) {
                    Console.WriteLine("Invalid Input");
                    fail = false;
                }
                switch(Prompt(prompt).ToLower()) {
                    case "y":
                    case "yes":
                    case "1":
                    case "true":
                        return true;
                    case "n":
                    case "no":
                    case "0":
                    case "false":
                        return false;
                    default:
                        fail = true;
                        break;
                }
            } while(fail);
            throw new Exception("IOTools BoolPrompt Failed!");
        }
        public static T ReadJson<T>(string path) {
            T output = default!;
            try {
                T returnVal = JsonSerializer.Deserialize<T>(File.ReadAllText(path))!;
            } catch(FileNotFoundException) {
                Console.WriteLine("Cannot find File");
            } catch(JsonException) {
                Console.WriteLine("Couldn't parse json");
            } catch(Exception e) {
                Console.WriteLine(e);
            }
            
            
            return output;
        }
        public static void WriteJson(string path, object input) {
            File.WriteAllText(JsonSerializer.Serialize(input), path);
        }
    }
}