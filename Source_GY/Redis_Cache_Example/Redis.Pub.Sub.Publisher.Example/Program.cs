using StackExchange.Redis;

namespace Redis.Pub.Sub.Publisher.Example
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await PublishMessagesAsync();
        }

        static async Task PublishMessagesAsync()
        {
            ConnectionMultiplexer connection = await ConnectionMultiplexer.ConnectAsync("localhost:1453");
            ISubscriber subscriber = connection.GetSubscriber();

            while (true)
            {
                Console.Write("Mesaj: ");
                string message = Console.ReadLine();
                await subscriber.PublishAsync("mychannel", message);
            }
        }
    }
}
