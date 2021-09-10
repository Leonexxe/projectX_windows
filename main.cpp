/*############################################################################################################
# File: c:\Users\Administrator\OneDrive\Dokumente\GitHub\projectX_windows\main.cpp                           #
# Project: c:\Users\Administrator\OneDrive\Dokumente\GitHub\projectX_windows                                 #
# Created Date: Sunday, July 4th 2021, 4:46:12 pm                                                            #
# Author: Leonexxe (Leon Marcellus Nitschke-Höfer)                                                           #
# -----                                                                                                      #
# Copyright (c) 2021 Leon Marcellus Nitschke-Höfer (Leonexxe)                                                #
# -----                                                                                                      #
# You may not remove or alter this copyright header.                                                         #
############################################################################################################*/
#define PX_DEBUG
#include "main.h"

void MOD_SERVER(px::application<PX_THREADSLOTS>* app)
{
    px::server<PX_MOD_SERVER_BUF_SIZE> SERVER = 
        app->getServer<PX_MOD_SERVER_BUF_SIZE>(6001,&MOD_SERVER_INTERPRETER);
    SERVER.run();
    PX_CODE_KEEP_ALIVE
}

void MAIN_THR(px::application<PX_THREADSLOTS>* app)
{
    //! main
    app->LOG(px::InfoPrefix()+"launching UI...\n");
    app->RUN_UI("C:\\PX_WIN\\ProjectX_WIN_UI.exe");
    app->loadINI();
    SEND_TO_UI("000");
    app->LOG(px::InfoPrefix()+"fetching some data from the API...\n");
    px::connection* API = app->getServerConnection("127.0.0.1",6000,&APIInterpreter,px::net::STR,"0000000;");
    API->disconnectAfterReceive = 1;
    API->_connect();
    app->LOG(px::InfoPrefix()+"decrypting data...\n");
    app->LOG(px::InfoPrefix()+"formatting data...\n");
    app->saveINI();
    
    //*encryption test
//    std::string msg = "Hello world";
//    std::string eMSG = "";
//    std::string deMSG = "";
//    app->m_pxe3.encrypt(&eMSG,&msg);
//    app->m_pxe3.decrypt(&deMSG,&eMSG);
//    using namespace px::console_colors::_8colors;
//    app->LOG(px::getCustomPrefix("CRYPTO TEST",black) + "msg: " + msg     + "\n");
//    app->LOG(px::getCustomPrefix("CRYPTO TEST",black) + "eMSG: " + eMSG   + "\n");
//    app->LOG(px::getCustomPrefix("CRYPTO TEST",black) + "deMSG: " + deMSG + "\n");
    
    //! leave this to the end
    PX_CODE_KEEP_ALIVE
}

int main(int argc, char** argv)
{
    #ifdef PX_WIN
        //tell windows not to display stupid error boxes for stupid runtime errors
        _set_abort_behavior(0, _WRITE_ABORT_MSG);
    #endif
    px::placeSignalHandlers();
    const char* __UNIQUE__ = 
    #include "randKey.txt"
    ;
    unsigned long long IID;
    int cryptoLength;
    std::string tUIID,tUCL;
    int I = 0;
    for(I = 0;I<19;I++)
        tUIID.push_back(__UNIQUE__[I]);
    for(I=19;I<30;I++)
        tUCL.push_back(__UNIQUE__[I]);
    IID = std::stoul(tUIID,nullptr,16);
    cryptoLength = std::stoul(tUCL,nullptr,16);
    std::string uSTR = __UNIQUE__;
    std::string temp_key = uSTR.substr(30,uSTR.size());
    std::cout << px::InfoPrefix() << "tUIID: " << tUIID                        << "\n";
    std::cout << px::InfoPrefix() << "tUCL: "  << tUCL                         << "\n";
    std::cout << px::InfoPrefix() << "UIID: "  << std::to_string(IID)          << "\n";
    std::cout << px::InfoPrefix() << "UCL: "   << std::to_string(cryptoLength) << "\n";
    px::application<PX_THREADSLOTS> app(&MAIN_THR,argc,argv,"projectX.exe",
    #ifdef PX_APP_ENABLE_PXE3_FILE_ENCRYPTION
        PXE3::PXE3(temp_key,cryptoLength),
    #endif
    "C:\\PX_WIN","projectX");
    APP_MAIN = &app;
    app.openLog("MODS");
    app.openLog("API");
    app.RUN();
    px::startAPPMonitor(&app);
    app.openThread("MOD_SERVER",&MOD_SERVER);
    app.EXECUTE_WHEN_OUT_OF_CODE_IN_MAIN();
    PX_CODE_KEEP_ALIVE
    return 0;
}