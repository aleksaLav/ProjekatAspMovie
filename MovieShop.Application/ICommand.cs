using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

    public interface IQuery<TSearch, TResualt> : IUseCase
    {
        TResualt Execute(TSearch search);
    }


    public interface IUseCase
    {
        public int Id { get; }
        public string Name { get;}
    }
}
