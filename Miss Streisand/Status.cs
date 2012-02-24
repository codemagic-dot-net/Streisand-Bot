using System;
using System.Threading;
using System.IO;
/*
 * The !status trigger
* 
* (C) Marcel Flaig codemagic.net
* and 
* (c) Para
*/
namespace Barbara
{
class Status
{

private Thread threadStatus;
// Empty constructor makes instance of Thread
public Status ()
{
threadStatus = new Thread (new ThreadStart (this.Run) );
}
// Starts the thread
public void Start ()
{
threadStatus.Start ();
}

string nickname;

public void Run ()
{
   
   

while (true)
{
    while (IrcBot.inputLine != null)
    {
        if (IrcBot.inputLine.EndsWith("!status"))
        {
            nickname = IrcBot.inputLine.Substring(1, IrcBot.inputLine.IndexOf("!") - 1);
            IrcBot.writer.WriteLine("NOTICE " + nickname + " :Everyone 's working hard!");
            IrcBot.writer.Flush();
            Thread.Sleep(10000);
            Console.WriteLine("NOTICE " + nickname + " :Everyone 's working hard!");
        }
    }
}
}
}}