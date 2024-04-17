using StackExchange.Redis;

namespace Redis.Pub.Sub.Subsciber.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            ConnectionMultiplexer connection = await ConnectionMultiplexer.ConnectAsync("localhost:1453");
            ISubscriber subscriber = connection.GetSubscriber();

            subscriber.SubscribeAsync("mychannel", (channel, message) =>
            {
                Console.WriteLine(message);
            });

            Console.Read();
        }
    }
}
