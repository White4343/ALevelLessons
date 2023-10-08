namespace AsyncApp
{
    internal class Program
    {
        static async Task<string> ReadFromFileAsync(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return await reader.ReadToEndAsync();
            }
        }

        static async Task<string> ReadHelloAsync()
        {
            return await ReadFromFileAsync("Hello.txt");
        }

        static async Task<string> ReadWorldAsync()
        {
            return await ReadFromFileAsync("World.txt");
        }

        static async Task<string> ConcatenateAsync()
        {
            Task<string> helloTask = ReadHelloAsync();
            Task<string> worldTask = ReadWorldAsync();

            await Task.WhenAll(helloTask, worldTask);

            return $"{await helloTask} {await worldTask}";
        }

        static void Main()
        {
            string result = ConcatenateAsync().Result;
            Console.WriteLine(result);
        }
    }
}