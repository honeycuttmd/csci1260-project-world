namespace HappyTails;

/// <summary>
/// Represents a log used to record rescue center messages and manage the log file.
/// </summary>
public class RescueLog : IDisposable
{
    private StreamWriter _writer;
    private string _path;
    private int _count;
    private bool _isClosed;

    public string Path
    {
        get { return _path; }
    }

    public int Count
    {
        get { return _count; }
    }

    public bool IsClosed
    {
        get { return _isClosed; }
    }

    /// <summary>
    /// Creates a rescue log using the specified file path.
    /// </summary>
    public RescueLog(string path)
    {
        _path = path;
        _writer = new StreamWriter(path, true);
        _count = 0;
        _isClosed = false;

        _writer.WriteLine("LOG OPENED");
    }

    /// <summary>
    /// Closes the log and releases the resources used by the log writer.
    /// </summary>
    public void Dispose()
    {
        if (!_isClosed)
        {
            _writer.WriteLine($"LOG CLOSED - {_count} LINES WRITTEN");

            _writer.Dispose();
            _isClosed = true;
        }
    }

    /// <summary>
    /// Writes a message to the log and updates the number of messages written.
    /// </summary>
    public void Write(string message)
    {
        if (_isClosed)
        {
            throw new ObjectDisposedException(nameof(RescueLog));
        }

        _writer.WriteLine(message);
        _count++;
    }
}