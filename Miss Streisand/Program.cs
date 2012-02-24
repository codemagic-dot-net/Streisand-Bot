using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

/*
 * This is the Barbara Bot Main Class
* 
* (C) Marcel Flaig codemagic.net
* and 
* (c) Para
* Thanks to Pasi Havia 17.11.2001 http://koti.mbnet.fi/~curupted for his great IRCbot Tutorial
*/

namespace Barbara
{
    class IrcBot
    {

        public static string strSERVER = "irc.telecomix.org";
        private static int PORT = 6667;

        // User information defined in RFC 2812 (Internet Relay Chat: Client Protocol) is sent to irc server
        private static string USER = "USER Barby 8 * :I'm a Barbara Streisand bot";
        private static string strNick = "Barbara";

        private static string strCHANNEL = "#streisandbottest";

        // StreamWriter is declared here so that PingSender can access it
        public static StreamWriter writer;
        public static StreamReader reader;
        public static string inputLine;


        static void Main(string[] args)
        {
            NetworkStream stream;
            TcpClient irc;

            string strXMLPath = "C:\\sample.xml";
            XMLoutput.read(strXMLPath);

            string nickname;
            try
            {
                irc = new TcpClient(strSERVER, PORT);
                stream = irc.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                PingSender ping = new PingSender();
                ping.Start();

                Status status = new Status();
                status.Start();

                writer.WriteLine(USER);
                writer.Flush();
                writer.WriteLine("NICK " + strNick);
                writer.Flush();
                writer.WriteLine("JOIN " + strCHANNEL);
                writer.Flush();

                while (true)
                {
                    while ((inputLine = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(inputLine);

                        if (inputLine.EndsWith("JOIN :" + strCHANNEL))
                        {
                            // Parse nickname of person who joined the channel
                            nickname = inputLine.Substring(1, inputLine.IndexOf("!") - 1);
                            // Welcome the nickname to channel by sending a notice
                            writer.WriteLine("NOTICE " + nickname + " :Hi " + nickname +
                            " and welcome to " + strCHANNEL + " channel!");
                            writer.Flush();

                            Thread.Sleep(2000);
                        }




                    }

                    writer.Close();
                    reader.Close();
                    irc.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Thread.Sleep(5000);
                string[] argv = { };
                Main(argv);
            }
        }
    }
}