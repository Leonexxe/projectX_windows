/*############################################################################################################
# File: c:\Users\Administrator\OneDrive\Dokumente\GitHub\projectX_windows\MOD_SERVER.cpp                     #
# Project: c:\Users\Administrator\OneDrive\Dokumente\GitHub\projectX_windows                                 #
# Created Date: Wednesday, September 8th 2021, 9:42:04 am                                                    #
# Author: Leonexxe (Leon Marcellus Nitschke-Höfer)                                                           #
# -----                                                                                                      #
# Copyright (c) 2021 Leon Marcellus Nitschke-Höfer (Leonexxe)                                                #
# -----                                                                                                      #
# You may not remove or alter this copyright header.                                                         #
############################################################################################################*/
#pragma once
#define PX_MOD_SERVER_BUF_SIZE 4096
#include "main.h"
std::string SEND_TO_CS = ".";
void SEND_TO_UI(std::string s)
{
    while(SEND_TO_CS != ""){Sleep(10);}
    SEND_TO_CS = s;
}
std::string MOD_SERVER_INTERPRETER(std::string msg,std::string IP, px::server<PX_MOD_SERVER_BUF_SIZE>* serv)
{
    APP_MAIN->LOG(px::InfoPrefix()+"REQUEST: " + msg +"\n");
    if(msg == "000")
    {
        SEND_TO_CS = "";
        APP_MAIN->LOG(px::InfoPrefix() + "UI waiting for command...\n");
        while(SEND_TO_CS == ""){Sleep(10);}
        APP_MAIN->LOG(px::InfoPrefix() + "Command send to UI: "+ SEND_TO_CS+"\n");
        return SEND_TO_CS;
    }
    if(msg == "001")
    {
        return "OK";
    }
    if(msg.substr(0,3) == "ini")
    {
        std::list<std::string> segments = strSplit(msg,",");
        std::string RETURN = APP_MAIN->getINI(px::tools::lists::getElementByIndex(&segments,0),px::tools::lists::getElementByIndex(&segments,1));
        APP_MAIN->LOG(px::InfoPrefix() + "response: "+RETURN+"\n");
        return RETURN;
    }
    return "0x0002";
}