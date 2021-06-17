using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Application
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase userCase, IActor actor, object useCaseData);
    }
}
