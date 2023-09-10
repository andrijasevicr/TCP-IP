using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Newtonsoft.Json;

namespace JSONMessageExchangeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                int port = 50169;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                server.Start();

                Console.WriteLine("Server started...");
                Console.WriteLine("Waiting for a connection...");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected to a client!");

                NetworkStream stream = client.GetStream();

                int message = 10;
                int init = 1;

                while (message != 0)
                {

                    if (init == 1)
                    {
                        // Reading JSON message from the client
                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        string jsonMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"Received message : " + jsonMessage);

                        Console.WriteLine("Write on which message you want to response [first, second, ... ,fifth]: ");
                        string messageString = Console.ReadLine();
                        if (messageString == "first")
                        {
                            message = 1;
                            init = 0;
                        }
                        else if (messageString == "second")
                        {
                            message = 2;
                            init = 0;
                        }
                        else if (messageString == "third")
                        {
                            message = 3;
                            init = 0;
                        }
                        else if (messageString == "fourth")
                        {
                            message = 4;
                            init = 0;
                        }
                        else if (messageString == "fifth")
                        {
                            message = 5;
                            init = 0;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input: ");
                            init = 1;
                        }
                    }

                    if (message == 1)
                    {
                        // Sending response back to the client
                        // Creating and sending JSON message
                        string jsonMessage1ResponsePath = "D:\\Master\\IKMIP\\Komunikacija\\message1response.json";
                        string jsonMessage1Response = File.ReadAllText(jsonMessage1ResponsePath);

                        byte[] responseBuffer = Encoding.UTF8.GetBytes(jsonMessage1Response);
                        stream.Write(responseBuffer, 0, responseBuffer.Length);
                        init = 1;
                    }
                    else if (message == 2) 
                    {
                        // Sending response back to the client
                        // Creating and sending JSON message
                        string jsonMessage2ResponsePath = "D:\\Master\\IKMIP\\Komunikacija\\message2response.json";
                        string jsonMessage2Response = File.ReadAllText(jsonMessage2ResponsePath);

                        byte[] responseBuffer = Encoding.UTF8.GetBytes(jsonMessage2Response);
                        stream.Write(responseBuffer, 0, responseBuffer.Length);
                        init = 1;
                    }
                    else if (message == 3)
                    {
                        // Sending response back to the client
                        // Creating and sending JSON message
                        string jsonMessage3ResponsePath = "D:\\Master\\IKMIP\\Komunikacija\\message3response.json";
                        string jsonMessage3Response = File.ReadAllText(jsonMessage3ResponsePath);

                        byte[] responseBuffer = Encoding.UTF8.GetBytes(jsonMessage3Response);
                        stream.Write(responseBuffer, 0, responseBuffer.Length);
                        init = 1;
                    }
                    else if (message == 4)
                    {
                        // Sending response back to the client
                        // Creating and sending JSON message
                        string jsonMessage4ResponsePath = "D:\\Master\\IKMIP\\Komunikacija\\message4response.json";
                        string jsonMessage4Response = File.ReadAllText(jsonMessage4ResponsePath);

                        byte[] responseBuffer = Encoding.UTF8.GetBytes(jsonMessage4Response);
                        stream.Write(responseBuffer, 0, responseBuffer.Length);
                        init = 1;
                    }
                    else if (message == 4)
                    {
                        // Sending response back to the client
                        // Creating and sending JSON message
                        string jsonMessage4ResponsePath = "D:\\Master\\IKMIP\\Komunikacija\\message4response.json";
                        string jsonMessage4Response = File.ReadAllText(jsonMessage4ResponsePath);

                        byte[] responseBuffer = Encoding.UTF8.GetBytes(jsonMessage4Response);
                        stream.Write(responseBuffer, 0, responseBuffer.Length);
                        init = 1;
                    }
                    else if (message == 5)
                    {
                        // Sending response back to the client
                        // Creating and sending JSON message
                        string jsonMessage5ResponsePath = "D:\\Master\\IKMIP\\Komunikacija\\message5response.json";
                        string jsonMessage5Response = File.ReadAllText(jsonMessage5ResponsePath);

                        byte[] responseBuffer = Encoding.UTF8.GetBytes(jsonMessage5Response);
                        stream.Write(responseBuffer, 0, responseBuffer.Length);
                        init = 1;
                    }


                }
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("Server stopped. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
