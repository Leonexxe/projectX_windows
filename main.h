/*
Author: Leon Nitschke-Höfer (leonexxe@leonexxe.de)
main.h (c) 2021
Desc: description
Created:  2021-08-21T04:39:01.845Z
Modified: 2021-09-02T16:01:23.644Z
*/

#pragma once
#define PX_APP_EXTENSION_CSUI
#define PX_APP_SYSOUT_DONT_CHECK_FORM
#define PX_APP_BIND_RUNTIME_TO_UI
//#define PX_APP_ENABLE_PXE3_FILE_ENCRYPTION
#define PX_THREADSLOTS 100
#define PX_NET_BUFFER_SIZE 224000

//wxWidgets
#define WXUSINGDLL
#include <wx/wx.h>
//#include <wx/setup.h>
//#include <wx/msw/rcdefs.h>

//projectX
#include <projectX/AUTOCONFIG.h>
#include <projectX/app.h>
#include <projectX/sysout.h>
#include <projectX/math/conv.cpp>
#include "API_RESPOND.cpp"
#include "MOD_SERVER.cpp"
#include "UI/UI_MAIN.cpp"

//class PX_CLIENT : public wxApp
//{
//    public:
//    PX_CLIENT();
//
//    private:
//    UI_MAIN* m_frame = nullptr;
//
//    public:
//    virtual bool OnInit() wxOVERRIDE;
//};
