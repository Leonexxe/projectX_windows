/*############################################################################################################
# File: c:\Users\Administrator\OneDrive\Dokumente\GitHub\projectX_windows\API_RESPOND.cpp                    #
# Project: c:\Users\Administrator\OneDrive\Dokumente\GitHub\projectX_windows                                 #
# Created Date: Wednesday, September 8th 2021, 12:31:05 am                                                   #
# Author: Leonexxe (Leon Marcellus Nitschke-Höfer)                                                           #
# -----                                                                                                      #
# Copyright (c) 2021 Leon Marcellus Nitschke-Höfer (Leonexxe)                                                #
# -----                                                                                                      #
# You may not remove or alter this copyright header.                                                         #
############################################################################################################*/
#pragma once
#include "main.h"
px::application<PX_THREADSLOTS>* APP_MAIN = nullptr;
std::string APIInterpreter(std::string* msg, px::connection* conn)
{
    APP_MAIN->LOG(px::InfoPrefix() + "("+conn->ADDR.IP+":"+std::to_string(conn->ADDR.port)+") "+*msg+"\n");
    int TYPE_ERROR = 1;
    int TYPE = 0;
    if(msg[1] == "x")
        TYPE = TYPE_ERROR;
    else if(msg->size() < 5000)
        return "0x0002";
    return "0";
}