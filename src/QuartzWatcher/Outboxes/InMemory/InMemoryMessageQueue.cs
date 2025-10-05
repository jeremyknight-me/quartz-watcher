using System.Threading.Channels;

namespace QuartzWatcher.Outboxes.InMemory;

internal sealed class InMemoryMessageQueue
{
    private readonly Channel<QuartzMessage> _channel
        = Channel.CreateUnbounded<QuartzMessage>();

    //private readonly Channel<QuartzMessage> _channel
    //    = Channel.CreateBounded<QuartzMessage>(new BoundedChannelOptions(10000)
    //    {
    //        FullMode = BoundedChannelFullMode.Wait
    //    });

    /// <summary>
    /// Gets the reader for consuming messages from the queue.
    /// </summary>
    public ChannelReader<QuartzMessage> Reader => _channel.Reader;

    /// <summary>
    /// Gets the writer for producing messages to the queue.
    /// </summary>
    public ChannelWriter<QuartzMessage> Writer => _channel.Writer;
}
