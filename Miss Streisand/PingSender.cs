using System;
using System.Threading;

/*
 * Sends Ping every Thread.Sleep (15000);
* 
* (C) Marcel Flaig codemagic.net
* and 
* (c) Para
* Thanks to Pasi Havia 17.11.2001 http://koti.mbnet.fi/~curupted for his great IRCbot Tutorial
*/

namespace Barbara
{
class PingSender
{
static string PING = "PING :";
private Thread pingSender;
// Empty constructor makes instance of Thread
public PingSender()
{
pingSender = new Thread (new ThreadStart (this.Run) );
}
// Starts the thread
public void Start ()
{
pingSender.Start ();
}
// Send PING to irc server every 15 seconds
public void Run ()
{
while (true)
{
IrcBot.writer.WriteLine (PING + IrcBot.strSERVER);
IrcBot.writer.Flush ();
Thread.Sleep (15000);
}
}
}}