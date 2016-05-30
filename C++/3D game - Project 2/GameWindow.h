#pragma once
#ifndef GAME_WINDOW
#define GAME_WINDOW

#include "Win32OGLWindow.h"

class Shader;

class GameWindow :
	public Win32OGLWindow
{
private:
	static GameWindow *self;
	Shader* shader;

public:
	GameWindow(Shader* shader, wstring title, int width, int height);
	virtual ~GameWindow();

	bool create();

protected:
	void runOneFrame();
	void update();
	void render();
	static LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);
};

#endif

