using Portal.Infrastructure.EF;
using Portal.Infrastructure.Repositories.Posts;
using Portal.Infrastructure.Repositories.SystemLogs;
using System;

namespace Portal.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        IPostRepository PostRepository { get; }
        ILogRepository LogRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext Context;
        public IPostRepository PostRepository { get; }
        public ILogRepository LogRepository { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            IPostRepository postRepository,
            ILogRepository logRepository
            )
        {
            Context = context;
            PostRepository = postRepository;
            LogRepository = logRepository;
        }

        //public IBookRepository BookRepository
        //{
        //    get
        //    {
        //        if (_bookRepository == null)
        //            _bookRepository = new BookRepository(Context);
        //        return _bookRepository;
        //    }
        //}

        public void Dispose()
        {
            Context?.Dispose();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}