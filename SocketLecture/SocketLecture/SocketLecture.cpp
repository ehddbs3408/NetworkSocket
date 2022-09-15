#undef UNICODE

#define WIN32_LEAN_AND_MEAN

#include <windows.h>
#include <winsock2.h>
#include <ws2tcpip.h>
#include <stdlib.h>
#include <stdio.h>

//추가 라이브러리
#include <thread>
#include <vector>
#include <iostream>
#include <string>

// Need to link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")
// #pragma comment (lib, "Mswsock.lib")

#define DEFAULT_BUFLEN 512 //
#define DEFAULT_PORT "27015"

#pragma region Use
//
struct client_type
{
    int id;
    SOCKET socket;
};

const char OPTION_VALUE = 1;
const int MAX_CLIENTS = 5;

int process_client(client_type& new_client, std::vector<client_type>& client_array, std::thread& thread);
int main();

int process_client(client_type& new_client, std::vector<client_type>& client_array, std::thread& thread)
{
    std::string msg = "";
    char tempmsg[DEFAULT_BUFLEN] = "";
    while (true)
    {
        memset(tempmsg, 0, DEFAULT_BUFLEN);

        if (new_client.socket != 0)
        {
            int iResult = recv(new_client.socket, tempmsg, DEFAULT_BUFLEN, 0);

            if (iResult != SOCKET_ERROR)
            {
                if (strcmp("", tempmsg))
                {
                    msg = "client # " + std::to_string(new_client.id) + ": " + tempmsg;
                }
                std::cout << msg.c_str() << std::endl;

                for (int i = 0; i < MAX_CLIENTS; i++)
                {
                    if (new_client.id != i)
                    {
                        iResult = send(client_array[i].socket, msg.c_str(), strlen(msg.c_str()), 0);
                    }
                }
            }
            else
            {
                msg = "client #" + std::to_string(new_client.id) + "disconnected";
                std::cout << msg << std::endl;

                closesocket(new_client.socket);
                closesocket(client_array[new_client.id].socket);

                client_array[new_client.id].socket = INVALID_SOCKET;

                for (int i = 0; i < MAX_CLIENTS; i++)
                {
                    if (client_array[i].socket != INVALID_SOCKET)
                    {
                        iResult = send(client_array[i].socket, msg.c_str(), strlen(msg.c_str()), 0);
                    }
                }
                break;
            }
        }
        thread.detach();
        return 0;
    }
    
}

//
#pragma endregion



int main(void)
{
    WSADATA wsaData; //소켓 정보
    int iResult;

    SOCKET server_socket = INVALID_SOCKET;//

    struct addrinfo* server = NULL;
    struct addrinfo hints;

    // use==========
    std::string msg = "";
    std::vector<client_type> client(MAX_CLIENTS);
    int num_client = 0;
    int temp_id = -1;
    std::thread my_thread[MAX_CLIENTS];

    // Initialize Winsock
    std::cout << "Initializing winsock..." << std::endl; //Debug.log

    iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
    if (iResult != 0) {
        printf("WSAStartup failed with error: %d\n", iResult);
        return 1;
    }

    ZeroMemory(&hints, sizeof(hints));
    hints.ai_family = AF_INET;
    hints.ai_socktype = SOCK_STREAM;
    hints.ai_protocol = IPPROTO_TCP;
    hints.ai_flags = AI_PASSIVE;

    std::cout << "Setting up server" << std::endl; //Debug.log
    getaddrinfo(NULL, DEFAULT_PORT, &hints, &server);

    std::cout << "Creating socket " << std::endl; //Debug.log
    server_socket = socket(server->ai_family, server->ai_socktype, server->ai_protocol); //소켓 생성 ( 주소영역, 소켓 타입, 프로토콜)

    setsockopt(server_socket, SOL_SOCKET, SO_REUSEADDR, &OPTION_VALUE, sizeof(int));
    setsockopt(server_socket, IPPROTO_TCP, TCP_NODELAY, &OPTION_VALUE, sizeof(int));

    std::cout << "Binding socket..." << std::endl; //Debug.log
    bind(server_socket, server->ai_addr, (int)server->ai_addrlen); //주소지정

    std::cout << "Listening... " << std::endl; //Debug.log
    listen(server_socket, SOMAXCONN); //클라이언트 요청할수 있도록 설정

    for (int i = 0; i < MAX_CLIENTS; i++)
    {
        client[i] = { -1,INVALID_SOCKET };
    }

    while (true)
    {
        SOCKET incoming = INVALID_SOCKET;
        incoming = accept(server_socket, NULL, NULL); //

        if (incoming == INVALID_SOCKET)
        {
            continue;
        }
        num_client = -1;
        temp_id = -1;

        for (int i = 0; i < MAX_CLIENTS; i++)
        {
            if (client[i].socket == INVALID_SOCKET && temp_id == -1) {
                client[i].socket = incoming;
                client[i].id = i;
                temp_id = i;
            }
            if(client[i].socket != INVALID_SOCKET)
            {
                num_client++;
            }
               
        }
        if (temp_id != -1)
        {
            std::cout << "Client # " << client[temp_id].id << "Accept" << std::endl;
            msg = std::to_string(client[temp_id].id);
            send(client[temp_id].socket, msg.c_str(), strlen(msg.c_str()), 0);
            my_thread[temp_id] = std::thread(process_client, std::ref(client[temp_id]), std::ref(client), std::ref(my_thread[temp_id]));
        }
        else
        {
            msg = "server is full";
            send(incoming, msg.c_str(), strlen(msg.c_str()), 0);
            std::cout << msg << std::endl;
        }
    }


    // No longer need server socket
    
    closesocket(server_socket);

    for (int i = 0; i < MAX_CLIENTS; i++)
    {
        my_thread[i].detach();
        closesocket(client[i].socket);
    }



    WSACleanup();
    std::cout << "end" << std::endl;

    return 0;
}