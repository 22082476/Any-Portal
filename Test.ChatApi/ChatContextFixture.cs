using ChatApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public abstract class ChatContextFixture : IDisposable
    {
        private bool _disposed;

        public ChatContext Context { get; private set; }
        public ChatContext ContextWithout { get; private set; }

        public ChatContextFixture()
        {
            var options = new DbContextOptionsBuilder<ChatContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            Context = new ChatContext(options);

            // Voeg testgegevens toe aan de context
            LoadData(options);


            var options2 = new DbContextOptionsBuilder<ChatContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            ContextWithout = new ChatContext(options2);
        }

        protected virtual void LoadData (DbContextOptions options){}

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Opruimen van resources indien nodig
                    Context.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }