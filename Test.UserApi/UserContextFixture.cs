
using Microsoft.EntityFrameworkCore;

public abstract class UserContextFixture : IDisposable
    {
        private bool _disposed;

        public UserContext Context { get; private set; }
        public UserContext ContextWithout { get; private set; }

        public UserContextFixture()
        {
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            Context = new UserContext(options);

            // Voeg testgegevens toe aan de context
            LoadData(options);


            var options2 = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            ContextWithout = new UserContext(options2);
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