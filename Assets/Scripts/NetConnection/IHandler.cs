using System.Collections;
using System.Collections.Generic;

namespace NetConnection
{
    public interface IHandle
    {
        void MessageReceive(SocketModel model);

    }
}