using Microsoft.EntityFrameworkCore;
using ResearchApi;
using System;
using Xunit;

public class ResearchContextFixture : IDisposable
{
    private bool _disposed;
    public ResearchContext Context { get; private set; }
    public ResearchContext ContextWithout {get; private set;}

        public ResearchContextFixture()
        {
            var options = new DbContextOptionsBuilder<ResearchContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            Context = new ResearchContext(options);
            LoadData(options);

            var optionsleeg = new DbContextOptionsBuilder<ResearchContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            ContextWithout = new ResearchContext(optionsleeg);

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