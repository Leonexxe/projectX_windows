/*
Author: Leon Nitschke-Höfer (leonexxe@leonexxe.de)
main.cpp (c) 2021
Desc: description
Created:  2021-07-04T14:46:13.244Z
Modified: 2021-07-04T16:10:44.821Z
*/

#include <projectX/OS_AUTOCONFIG.h>
#include <projectX/COMPILER_AUTOCONFIG.h>
#include <projectX/sysout.h>
#include <thread>

bool csRunning = 1;

void UI_THR()
{
    system("dotnet C:\\users\\administrator\\OneDrive\\Dokumente\\github\\ProjectX_windows\\ProjectX_WIN_UI\\ProjectX_WIN_UI\\bin\\Debug\\net5.0-windows\\ProjectX_WIN_UI.dll");
    csRunning = 0;
}

int main()
{
    std::thread Thread_UI = std::thread(UI_THR);
    Thread_UI.join();
    return 0;
}