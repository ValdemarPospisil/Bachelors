using GoodAccess.Shared;
using System.IO.Pipes;
using System.Text;
using System.Runtime.InteropServices;

namespace CLIService.GoodAccess.Main
{
    public class SenderReader
    {
        private readonly Logger _logger;
        private readonly string _pipeName;
        private NamedPipeServerStream? _serverStream;
        private StreamReader? _reader;
        private StreamWriter? _writer;
        private const string SocketFullPath = "/tmp/CoreFxPipe_ga-cli.sock";

        public SenderReader(Logger logger, string pipeName = "ga-cli.sock")
        {
            _logger = logger;
            _pipeName = pipeName;
        }

        public void ReinitializePipe()
        {
            _logger.Info("SenderReader: Reinitializing pipe...");
            Stop();
            CreatePipe();
        }

        public bool CreatePipe()
        {
            try
            {
                CleanupStaleSocket(SocketFullPath);

                _serverStream = new NamedPipeServerStream(
                    _pipeName,
                    PipeDirection.InOut,
                    1, // Max 1 client 
                    PipeTransmissionMode.Byte,
                    PipeOptions.Asynchronous
                );
                
                SetSocketPermissions(SocketFullPath);

                _logger.Info($"SenderReader: Pipe created '{_pipeName}'. Waiting for permissions setup...");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }

        public void SetSocketPermissions(string fullSocketPath)
        {
            if (File.Exists(fullSocketPath))
            {
                try
                {
                    // Nastavíme 666 (rw-rw-rw-)
                    File.SetUnixFileMode(fullSocketPath, 
                        UnixFileMode.UserRead | UnixFileMode.UserWrite | 
                        UnixFileMode.GroupRead | UnixFileMode.GroupWrite | 
                        UnixFileMode.OtherRead | UnixFileMode.OtherWrite);
                        
                    _logger.Info($"SenderReader: Permissions set to 666 for {SocketFullPath}");
                }
                catch (Exception ex)
                {
                 //   _logger.Error($"SenderReader: Failed to set permissions: {ex.Message}");
                    _logger.Error(ex);
                }
            }
        }

        private void CleanupStaleSocket(string fullSocketPath)
        {
            if (File.Exists(fullSocketPath))
            {
                try
                {
                    _logger.Info($"SenderReader: Found stale socket at {fullSocketPath}. Deleting...");
                    File.Delete(fullSocketPath);
                }
                catch (Exception ex)
                {
                    _logger.Info($"SenderReader: Failed to delete stale socket: {ex.Message}");
                }
            }
        }

        public async Task WaitForConnectionAsync(CancellationToken token)
        {
            if (_serverStream == null) throw new InvalidOperationException("Pipe not created");
            
            await _serverStream.WaitForConnectionAsync(token);

            // UTF8 bez BOM (Byte Order Mark)
            var utf8NoBom = new UTF8Encoding(false);

            _reader = new StreamReader(_serverStream, utf8NoBom, leaveOpen: true);
            _writer = new StreamWriter(_serverStream, utf8NoBom, leaveOpen: true) 
            { 
                AutoFlush = true // Flushnout buffer hned po WriteLine
            };
        }

        public async Task<string?> ReadMessageAsync()
        {
            if (_reader == null) return null;
            return await _reader.ReadLineAsync();
        }

        public async Task SendMessageAsync(string message)
        {
            if (_writer == null || _serverStream == null || !_serverStream.IsConnected) 
            {
                _logger.Info("SenderReader: Client is not connected. Dropping response.");
                return;
            }

            try 
            {
                await _writer.WriteLineAsync(message);
            }
            catch (IOException)
            {
                _logger.Info("SenderReader: Client disconnected before response could be sent. (Broken Pipe)");
            }
            catch (ObjectDisposedException)
            {
                _logger.Info("SenderReader: Pipe was disposed during write.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        public void Disconnect()
    {
        try
        {
            _reader?.Dispose();
            _writer?.Dispose();
            
            if (_serverStream != null) 
            {
                _serverStream.Disconnect(); 
            }
        }
        catch (Exception ex)
        {
            _logger.Info($"[SenderReader] Disconnect warning: {ex.Message}");
        }
    }

        public void Stop()
        {
            Disconnect();
            _serverStream?.Dispose();
        }
        
        public bool IsConnected => _serverStream != null && _serverStream.IsConnected;
    }
}
