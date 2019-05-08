using System;
using SocketTcpClient;

public class Bridge
{
    private Speaker speak;

    public Bridge() {
        speak = new Speaker(1024, "127.0.0.1");
    }

}
