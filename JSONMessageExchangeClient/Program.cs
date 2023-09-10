using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace JSONMessageExchangeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int port = 50169;
                TcpClient client = new TcpClient("127.0.0.1", port);

                NetworkStream stream = client.GetStream();

                int message = 10;
                int init = 1;

                while(message != 0)
                {
                    if(init == 1)
                    {
                        Console.WriteLine("Write which message you want to send [first, second, ... ,fifth]: ");
                        string messageString = Console.ReadLine();
                        if(messageString == "first" ) 
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
                        // Creating and sending JSON message
                        string jsonMessage1Path = "D:\\Master\\IKMIP\\Komunikacija\\message1.json";
                        string jsonMessage1 = File.ReadAllText(jsonMessage1Path);

                        byte[] buffer = Encoding.UTF8.GetBytes(jsonMessage1);
                        stream.Write(buffer, 0, buffer.Length);

                        // Reading response from the server
                        byte[] responseBuffer = new byte[1024];
                        int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
                        string jsonResponse = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                        Console.WriteLine($"Received response to message :" + jsonResponse);
                        init = 1;
                    }
                    else if (message == 2) 
                    {
                        // Creating and sending JSON message
                        string jsonMessage2Path = "D:\\Master\\IKMIP\\Komunikacija\\message2.json";
                        string jsonMessage2 = File.ReadAllText(jsonMessage2Path);

                        byte[] buffer = Encoding.UTF8.GetBytes(jsonMessage2);
                        stream.Write(buffer, 0, buffer.Length);

                        // Reading response from the server
                        byte[] responseBuffer = new byte[1024];
                        int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
                        string jsonResponse = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                        Console.WriteLine($"Received response to message :" + jsonResponse);
                        init = 1;
                    }
                    else if (message == 3)
                    {
                        // Creating and sending JSON message
                        string jsonMessage3Path = "D:\\Master\\IKMIP\\Komunikacija\\message3.json";
                        string jsonMessage3 = File.ReadAllText(jsonMessage3Path);

                        byte[] buffer = Encoding.UTF8.GetBytes(jsonMessage3);
                        stream.Write(buffer, 0, buffer.Length);

                        // Reading response from the server
                        byte[] responseBuffer = new byte[1024];
                        int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
                        string jsonResponse = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                        Console.WriteLine($"Received response to message :" + jsonResponse);
                        init = 1;
                    }
                    else if (message == 4)
                    {
                        // Creating and sending JSON message
                        string jsonMessage4Path = "D:\\Master\\IKMIP\\Komunikacija\\message4.json";
                        string jsonMessage4 = File.ReadAllText(jsonMessage4Path);

                        byte[] buffer = Encoding.UTF8.GetBytes(jsonMessage4);
                        stream.Write(buffer, 0, buffer.Length);

                        // Reading response from the server
                        byte[] responseBuffer = new byte[1024];
                        int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
                        string jsonResponse = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                        Console.WriteLine($"Received response to message :" + jsonResponse);
                        init = 1;
                    }
                    else if (message == 5)
                    {
                        // Creating and sending JSON message
                        string jsonMessage5Path = "D:\\Master\\IKMIP\\Komunikacija\\message5.json";
                        string jsonMessage5 = File.ReadAllText(jsonMessage5Path);

                        byte[] buffer = Encoding.UTF8.GetBytes(jsonMessage5);
                        stream.Write(buffer, 0, buffer.Length);

                        // Reading response from the server
                        byte[] responseBuffer = new byte[1024];
                        int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
                        string jsonResponse = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);

                        Console.WriteLine($"Received response to message :" + jsonResponse);
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

            Console.WriteLine("Client program finished. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
